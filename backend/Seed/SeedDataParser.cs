using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using backend.Models;

public class SeedDataParser
{
    public async Task ImportSeedDataAsync(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<SeedRecord>();

        await using var context = new InvestmentmgmtContext();

        foreach (var record in records)
        {
            
            var country = await context.Countries
                .FirstOrDefaultAsync(c => c.Name == record.InvestorCountry);

            if (country == null)
            {
                country = new Country { Name = record.InvestorCountry };
                context.Countries.Add(country);
                await context.SaveChangesAsync();
            }

            var assetClass = await context.AssetClasses
                .FirstOrDefaultAsync(c => c.Name == record.CommitmentAssetClass);

            if (assetClass == null)
            {
                assetClass = new AssetClass { Name = record.CommitmentAssetClass };
                context.AssetClasses.Add(assetClass);
                await context.SaveChangesAsync();
            }

            var investorType = await context.InvestorTypes
                .FirstOrDefaultAsync(c => c.Name == record.InvestorType);

            if (investorType == null)
            {
                investorType = new InvestorType { Name = record.InvestorType };
                context.InvestorTypes.Add(investorType);
                await context.SaveChangesAsync();
            }

            // Get or create Investor
            var investor = await context.Investors
                .Include(p => p.Commitments)
                .FirstOrDefaultAsync(p => p.Name == record.InvestorName && p.InvestorCountryId == country.Id);

            if (investor == null)
            {
                investor = new Investor
                {
                    Name = record.InvestorName,
                    InvestorCountryId = country.Id,
                    DateAdded = record.InvestorDateAdded,
                    DateLastUpdated = record.InvestorLastUpdated,
                    InvestorTypeId = investorType.Id
                };
                context.Investors.Add(investor);
                await context.SaveChangesAsync();
            }

            var commitment = new Commitment
            {
                InvestorId = investor.Id,
                CommitmentAssetClassId = assetClass.Id,
                CommitmentAmount = record.CommitmentAmount,
                CommitmentCcy = record.CommitmentCurrency,
            };
            context.Commitments.Add(commitment);

        }

        await context.SaveChangesAsync();
        Console.WriteLine("Import complete.");
}
}