using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Commitment
{
    public int Id { get; set; }

    public int? CommitmentAssetClassId { get; set; }

    public double CommitmentAmount { get; set; }

    public string CommitmentCcy { get; set; } = null!;

    public int InvestorId { get; set; }

    public virtual AssetClass? CommitmentAssetClass { get; set; }

    public virtual Investor Investor { get; set; } = null!;
}
