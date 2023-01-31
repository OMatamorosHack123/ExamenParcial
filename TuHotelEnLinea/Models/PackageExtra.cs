using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class PackageExtra
{
    public int PackageId { get; set; }

    public int ExtraId { get; set; }

    public int PackageExtraId { get; set; }

    public virtual Extra Extra { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
