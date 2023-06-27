using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class Return1
{
    public string ReturnId { get; set; } = null!;

    public string CarNo { get; set; } = null!;

    public string InspectorName { get; set; } = null!;

    public string DriverId { get; set; } = null!;

    public string ReturnDate { get; set; } = null!;

    public string ElapsedDate { get; set; } = null!;

    public string Fine { get; set; } = null!;

    public virtual Car CarNoNavigation { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;
}
