using MVC2.DAL;

namespace MVC2.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ISinhVienRepository SinhVienRepo { get; }

        public ILopRepository LopRepo { get; }
    }
}
