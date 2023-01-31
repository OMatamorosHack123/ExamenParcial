using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class CategoryRoom
{
    public int CategoryRoomId { get; set; }

    public string CategoryRoomName { get; set; } = null!;

    public string CategoryRoomDescription { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
