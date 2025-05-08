using Example.Models;

namespace Example.BUS
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAll();
        public Task<Movie?> GetById(int id);
        public Task Create(Movie movie);
        public Task Update(Movie movie);
        public Task Delete(Movie movie);
        public Task<bool> IsExsist(int id);
    }
}
