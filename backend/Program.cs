using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOpenApi();
builder.Services.AddDbContext<InvestmentmgmtContext>(options =>
    options.UseSqlite("Data Source=../database/investmentmgmt.db"));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}*/

app.UseHttpsRedirection();
app.MapControllers();

// Uncomment to run seed data import
/*var importer = new SeedDataParser();
await importer.ImportSeedDataAsync("");  //input filepath  */

app.UseCors();
app.Run();
