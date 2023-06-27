using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class CarBodyType
{
    public string CarBodyTypeId { get; set; } = null!;

    public string TypeDescription { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
