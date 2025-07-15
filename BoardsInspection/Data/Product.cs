using System;
using System.Collections.Generic;

namespace BoardsInspection.WebAPI.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public DateTime ProductionDate { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
