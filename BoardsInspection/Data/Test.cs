using System;
using System.Collections.Generic;

namespace BoardsInspection.WebAPI.Data;

public partial class Test
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Type { get; set; } = null!;

    public string? Responsible { get; set; }

    public string? Result { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Product Product { get; set; } = null!;
}
