using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Data
{
    public class SeedData
    {
        public static void Intialize(IServiceProvider serviceProvider)
        {
            var option = serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>();
            using var context = new MovieContext(option);
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Inside Out",
                        ReleaseDate = DateTime.Parse("2003-01-01"),
                        Genre = "Animation",
                        Price = 15.99M
                    },

                    new Movie
                    {
                        Title = "Coco",
                        ReleaseDate = DateTime.Parse("2002-3-13"),
                        Genre = "Animation",
                        Price = 10.99M
                    },

                    new Movie
                    {
                        Title = "Element",
                        ReleaseDate = DateTime.Parse("2023-2-23"),
                        Genre = "Animation",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Inception",
                        ReleaseDate = DateTime.Parse("1999-4-15"),
                        Genre = "Fictionary",
                        Price = 11.99M
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
