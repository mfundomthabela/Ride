using System;
using System.Collections.Generic;

namespace Ride.Models;

public partial class Car
{
    public string CarNo { get; set; } = null!;

    public string? CarMakeId { get; set; }

    public string? CarBodyTypeId { get; set; }

    public string Model { get; set; } = null!;

    public string Kmtravelled { get; set; } = null!;

    public string ServiceKm { get; set; } = null!;

    public string AvailabLe { get; set; } = null!;

    public virtual CarBodyType? CarBodyType { get; set; }

    public virtual CarMake? CarMake { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Return1> Return1s { get; set; } = new List<Return1>();
}
