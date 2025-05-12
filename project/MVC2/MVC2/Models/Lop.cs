using System;
using System.Collections.Generic;

namespace MVC2.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? MaKhoa { get; set; }

    public virtual Khoa? MaKhoaNavigation { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
