using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public int RoomId { get; set; }

    public string PackageName { get; set; } = null!;

    public double PackagePrice { get; set; }

    public int PackageQdays { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<PackageExtra> PackageExtras { get; } = new List<PackageExtra>();

    public virtual Room Room { get; set; } = null!;
}
