using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicationMovies_UTN.Data;
using AplicationMovies_UTN.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicationMovies_UTN.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly AplicationMovies_UTN.Data.AplicationMovies_UTNContext _context;

        public IndexModel(AplicationMovies_UTN.Data.AplicationMovies_UTNContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            var movies = from m in _context.Movie select m;

            try
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    movies = movies.Where(x => x.Title.Contains(SearchString));
                }
                if (!string.IsNullOrEmpty(MovieGenre))
                {
                    movies = movies.Where(x => x.Genre == MovieGenre);
                }
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
