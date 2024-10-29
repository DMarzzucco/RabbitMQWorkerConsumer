using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicationMovies_UTN.Data;
using AplicationMovies_UTN.Model;

namespace AplicationMovies_UTN.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly AplicationMovies_UTN.Data.AplicationMovies_UTNContext _context;

        public IndexModel(AplicationMovies_UTN.Data.AplicationMovies_UTNContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
