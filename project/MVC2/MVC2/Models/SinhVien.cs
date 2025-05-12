using System;
using System.Collections.Generic;

namespace MVC2.Models;

public partial class SinhVien
{
    public string MaSinhVien { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? MaLop { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
