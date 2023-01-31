using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Extra
{
    public int ExtraId { get; set; }

    public string ExtraName { get; set; } = null!;

    public string ExtraDescription { get; set; } = null!;

    public virtual ICollection<PackageExtra> PackageExtras { get; } = new List<PackageExtra>();
}
