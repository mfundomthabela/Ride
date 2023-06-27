using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class Driver
{
    public string DriverId { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string DriverEmail { get; set; } = null!;

    public string DriverMobile { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Return1> Return1s { get; set; } = new List<Return1>();
}
