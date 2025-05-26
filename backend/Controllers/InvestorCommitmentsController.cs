using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestorCommitmentsController : ControllerBase
{
    private readonly InvestmentmgmtContext _context;

    public InvestorCommitmentsController(InvestmentmgmtContext context)
    {
        _context = context;
    }

    [HttpGet("{investorId?}")]
    public async Task<IActionResult> GetInvestorCommitmentsSummary(int? investorId)
    {
        var query = _context.Commitments.AsQueryable();
        if (investorId != null)
        {
            query = query.Where(a => a.InvestorId == investorId);

        }       

        var commitments = await query
            .Select(a => new {
                a.Id,
                AssetClass = a.CommitmentAssetClass.Name,
                Currency = a.CommitmentCcy,
                a.CommitmentAmount
            })
            .ToListAsync();

        return Ok(commitments);

    }
}
