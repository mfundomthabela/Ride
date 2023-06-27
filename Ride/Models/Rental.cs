using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class Rental
{
    public string RentalNo { get; set; } = null!;

    public string CarNo { get; set; } = null!;

    public string InspectorName { get; set; } = null!;

    public string DriverId { get; set; } = null!;

    public string RentalFee { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public virtual Car CarNoNavigation { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;
}
