using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Investor> Investors { get; set; } = new List<Investor>();
}
