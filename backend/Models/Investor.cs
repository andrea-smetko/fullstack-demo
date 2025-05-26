using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Investor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? InvestorTypeId { get; set; }

    public int? InvestorCountryId { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateLastUpdated { get; set; }

    public virtual ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();

    public virtual Country? InvestorCountry { get; set; }

    public virtual InvestorType? InvestorType { get; set; }
}
