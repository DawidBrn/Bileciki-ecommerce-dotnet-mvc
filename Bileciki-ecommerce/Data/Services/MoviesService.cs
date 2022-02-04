using Bileciki_ecommerce.Data.Base;
using Bileciki_ecommerce.Models;
using Bileciki_ecommerce.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Data.Services
{
    public class MoviesService :EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.
                Include(c => c.Cinema).
                Include(p => p.Producer).
                Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id); 
            return movie;
        }

        public async Task<MovieDropdownsVM> GetMovieDropdownValues()
        {
            var response = new MovieDropdownsVM();
            response.Actors = await _context.Actors.OrderBy(n => n.Fullname).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.Fullname).ToListAsync();

            return response;
        }
    }
}
