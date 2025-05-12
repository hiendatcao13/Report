using MVC2.Models;

namespace MVC2.DAL
{
    public interface ILopRepository
    {
        public List<Lop> GetAll();

        public Lop? GetById(int id);

        public void Add(Lop lop);

        public void Update(Lop lop);

        public void Delete(int id);
    }
}
