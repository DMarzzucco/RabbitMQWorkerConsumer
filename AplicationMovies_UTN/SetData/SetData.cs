using AplicationMovies_UTN.Data;
using Microsoft.EntityFrameworkCore;
using AplicationMovies_UTN.Model;
namespace AplicationMovies_UTN.SetData
{
    public class SetData
    {
        public static void Intialize(IServiceProvider serviceProvider)
        {
            using (var context = new AplicationMovies_UTNContext(
                serviceProvider.GetRequiredService<DbContextOptions<AplicationMovies_UTNContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null Data");
                }
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                 new Movie
                 {
                     Title = "Harry Potter and the Sorcerer's Stone",
                     RelaceDate = DateTime.SpecifyKind(DateTime.Parse("2001-11-16"), DateTimeKind.Utc),
                     Genre = "Fantasy",
                     Description = "This is a Harry Potter movie, following Harry as he discovers his magical heritage.",
                     Director = "Chris Columbus",
                     Price = 20.99M
                 },

                new Movie
                {
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    RelaceDate = DateTime.SpecifyKind(DateTime.Parse("2001-12-19"), DateTimeKind.Utc),
                    Genre = "Fantasy",
                    Description = "An epic adventure where Frodo and his friends set out to destroy the One Ring.",
                    Director = "Peter Jackson",
                    Price = 25.50M
                },

                new Movie
                {
                    Title = "Inception",
                    RelaceDate = DateTime.SpecifyKind(DateTime.Parse("2010-07-16"), DateTimeKind.Utc),
                    Genre = "Sci-Fi",
                    Description = "A mind-bending thriller about dream invasion and espionage.",
                    Director = "Christopher Nolan",
                    Price = 19.99M
                },

                new Movie
                {
                    Title = "The Matrix",
                    RelaceDate = DateTime.SpecifyKind(DateTime.Parse("1999-03-31"), DateTimeKind.Utc),
                    Genre = "Sci-Fi",
                    Description = "A hacker discovers the shocking reality that the world is a simulation.",
                    Director = "The Wachowskis",
                    Price = 22.00M
                },

                new Movie
                {
                    Title = "Jurassic Park",
                    RelaceDate = DateTime.SpecifyKind(DateTime.Parse("1993-06-11"), DateTimeKind.Utc),
                    Genre = "Adventure",
                    Description = "Dinosaurs come back to life in a theme park, but things go terribly wrong.",
                    Director = "Steven Spielberg",
                    Price = 18.75M
                }
                 );
                context.SaveChanges();
            }
        }
    }
}
