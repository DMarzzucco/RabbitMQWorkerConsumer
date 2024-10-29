using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicationMovies_UTN.Model;

namespace AplicationMovies_UTN.Data
{
    public class AplicationMovies_UTNContext : DbContext
    {
        public AplicationMovies_UTNContext (DbContextOptions<AplicationMovies_UTNContext> options)
            : base(options)
        {
        }

        public DbSet<AplicationMovies_UTN.Model.Movie> Movie { get; set; } = default!;
    }
}
