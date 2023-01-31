using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int PackageId { get; set; }

    public string BookingDate { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
