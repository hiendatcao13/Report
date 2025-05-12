using MVC2.Models;

namespace MVC2.DAL
{
    public class SinhVienRepository(QlsinhVienContext context) : ISinhVienRepository
    {
        private readonly QlsinhVienContext _context = context;

        public List<SinhVien> GetAll()
        {
            return _context.SinhViens.ToList();
        }

        public SinhVien? GetById(int id)
        {
            return _context.SinhViens.Find(id);
        }

        public void Add(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            _context.SaveChanges();
        }

        public void Update(SinhVien sinhVien)
        {
            _context.SinhViens.Update(sinhVien);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sinhVien = _context.SinhViens.Find(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
                _context.SaveChanges();
            }
        }
    }
}
