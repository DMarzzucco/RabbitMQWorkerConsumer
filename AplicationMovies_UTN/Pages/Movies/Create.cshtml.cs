using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicationMovies_UTN.Data;
using AplicationMovies_UTN.Model;

namespace AplicationMovies_UTN.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly AplicationMovies_UTN.Data.AplicationMovies_UTNContext _context;

        public CreateModel(AplicationMovies_UTN.Data.AplicationMovies_UTNContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Movie.RelaceDate.Kind == DateTimeKind.Unspecified) 
            {
                Movie.RelaceDate = DateTime.SpecifyKind(Movie.RelaceDate, DateTimeKind.Utc);
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
