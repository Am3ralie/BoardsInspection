using System;
using System.Collections.Generic;

namespace BoardsInspection.WebAPI.Data;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }
}
