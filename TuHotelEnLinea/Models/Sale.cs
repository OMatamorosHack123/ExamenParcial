using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public double SaleTotal { get; set; }

    public int BookingId { get; set; }

    public int PaymentMethodId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
