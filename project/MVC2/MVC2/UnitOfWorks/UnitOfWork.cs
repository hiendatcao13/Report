using MVC2.DAL;
using MVC2.Models;

namespace MVC2.UnitOfWorks
{
    public class UnitOfWork(QlsinhVienContext context) : IUnitOfWork
    {
        private ISinhVienRepository _sinhVienRepo = default!;

        private ILopRepository _lopRepo = default!;

        private readonly QlsinhVienContext _context = context;


        public ISinhVienRepository SinhVienRepo
        {
            get
            {
                if (_sinhVienRepo == null)
                {
                    _sinhVienRepo = new SinhVienRepository(_context);
                }
                return _sinhVienRepo;
            }
        }
        public ILopRepository LopRepo
        {
            get
            {
                if (_lopRepo == null)
                {
                    _lopRepo = new LopRepository(_context);
                }
                return _lopRepo;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
