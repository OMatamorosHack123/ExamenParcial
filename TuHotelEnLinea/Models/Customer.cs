using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string CustomerIdCard { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<CustomerXroom> CustomerXrooms { get; } = new List<CustomerXroom>();
}
