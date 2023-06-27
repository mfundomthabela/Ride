using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class CarMake
{
    public string CarMakeId { get; set; } = null!;

    public string CarDescription { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
