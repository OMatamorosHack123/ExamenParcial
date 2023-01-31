using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class CustomerXroom
{
    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public string CustomerCreatedAt { get; set; } = null!;

    public int CustomerXroomId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
