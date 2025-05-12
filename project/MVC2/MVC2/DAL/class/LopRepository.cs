using MVC2.Models;

namespace MVC2.DAL
{
    public class LopRepository(QlsinhVienContext context) : ILopRepository
    {
        private readonly QlsinhVienContext _context = context;

        public List<Lop> GetAll()
        {
            return _context.Lops.ToList();
        }

        public Lop? GetById(int id)
        {
            return _context.Lops.Find(id);
        }

        public void Add(Lop lop)
        {
            _context.Lops.Add(lop);
            _context.SaveChanges();
        }

        public void Update(Lop lop)
        {
            _context.Lops.Update(lop);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var lop = _context.Lops.Find(id);
            if (lop != null)
            {
                _context.Lops.Remove(lop);
                _context.SaveChanges();
            }
        }
    }
}
