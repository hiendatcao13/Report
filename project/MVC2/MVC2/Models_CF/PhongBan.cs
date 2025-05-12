using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models_CF
{
    public class PhongBan
    {
        [Key, Column("MaPhongBan")]
        public int Id { get; set; }

        [Column("TenPhongBan")]
        [Required(ErrorMessage = "Tên phòng ban không được để trống")]
        public string TenPhongBan { get; set; } = string.Empty;

        [Column("NgayThanhLap")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày thành lập không được để trống")]
        public DateTime? NgayThanhLap { get; set; } = DateTime.Now;

        public ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
    }
}
