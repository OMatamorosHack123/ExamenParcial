using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int CategoryRoomId { get; set; }

    public int RoomNum { get; set; }

    public int RoomFloor { get; set; }

    public int RoomQuota { get; set; }

    public virtual CategoryRoom CategoryRoom { get; set; } = null!;

    public virtual ICollection<CustomerXroom> CustomerXrooms { get; } = new List<CustomerXroom>();

    public virtual ICollection<Package> Packages { get; } = new List<Package>();
}
