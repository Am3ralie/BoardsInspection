﻿using System;
using System.Collections.Generic;

namespace BoardsInspection.WebAPI.Data;

public partial class Efmigrationshistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
