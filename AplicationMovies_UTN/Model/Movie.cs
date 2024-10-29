using System.ComponentModel.DataAnnotations;

namespace AplicationMovies_UTN.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime RelaceDate { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public decimal Price { get; set; }
    }
}
