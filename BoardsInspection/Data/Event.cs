using System;
using System.Collections.Generic;

namespace BoardsInspection.WebAPI.Data;

public partial class Event
{
    public int Id { get; set; }

    public int TestId { get; set; }

    public string? EventResult { get; set; }

    public DateTime? Date { get; set; }

    public string? Place { get; set; }

    public virtual Test Test { get; set; } = null!;
}
