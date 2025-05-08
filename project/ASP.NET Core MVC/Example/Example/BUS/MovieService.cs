using Example.Data;
using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.BUS
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;
        public MovieService(MovieContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movie.ToListAsync();
        }
        public async Task<Movie?> GetById(int id)
        {
            return await _context.Movie.FindAsync(id);
        }
        public async Task Create(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Movie movie)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsExsist(int id)
        {
            return await _context.Movie.AnyAsync(x => x.Id == id);
        }
    }
}
