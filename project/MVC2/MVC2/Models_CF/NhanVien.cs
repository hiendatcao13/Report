using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MVC2.Models_CF
{
    public class NhanVien : IValidatableObject
    {
        [Key, Column("MaNV")]
        public int Id { get; set; }

        [Column("TenNV")]
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        [StringLength(50, ErrorMessage = "Tên nhân viên không được quá 50 ký tự")]
        public string TenNV { get; set; } = string.Empty;

        [Column("GioiTinh")]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public bool GioiTinh { get; set; } = true;

        [Column("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Column("NgaySinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; } = DateTime.Now;

        [Column("DiaChi")]
        [AllowNull]
        [StringLength(100, ErrorMessage = "Địa chỉ không được quá 100 ký tự")]
        public string? DiaChi { get; set; } = string.Empty;

        [Column("MaPhongBan")]
        public int MaPhongBan { get; set; }

        public PhongBan PhongBan { get; set; } = new PhongBan();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NgaySinh > DateTime.Now)
            {
                yield return new ValidationResult(
                    "Ngày sinh không được lớn hơn ngày hiện tại",
                    new[] { nameof(NgaySinh) });
            }
        }
    }
}
