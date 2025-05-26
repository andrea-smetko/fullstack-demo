using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestorsController : ControllerBase
{
    private readonly InvestmentmgmtContext _context;

    public InvestorsController(InvestmentmgmtContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetInvestorSummary()
    {
        var summary = await _context.Investors
            .Select(p => new
            {
                p.Id,
                p.Name,
                Type = p.InvestorType.Name,
                p.DateAdded,
                Country = p.InvestorCountry.Name,
                TotalCommitment = p.Commitments.Sum(c => c.CommitmentAmount)
            })
            .ToListAsync();

        return Ok(summary);
    }
}
