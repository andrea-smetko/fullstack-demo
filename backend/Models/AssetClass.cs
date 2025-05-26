using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class AssetClass
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
}
