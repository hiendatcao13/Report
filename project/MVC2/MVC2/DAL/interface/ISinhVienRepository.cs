using MVC2.Models;

namespace MVC2.DAL
{
    public interface ISinhVienRepository
    {
        List<SinhVien> GetAll();
        SinhVien? GetById(int id);
        void Add(SinhVien sinhVien);
        void Update(SinhVien sinhVien);
        void Delete(int id);
    }
}
