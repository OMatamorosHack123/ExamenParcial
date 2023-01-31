using System;
using System.Collections.Generic;

namespace TuHotelEnLinea.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
