﻿using System;
using System.Collections.Generic;

namespace MVC2.Models;

public partial class Khoa
{
    public string MaKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
