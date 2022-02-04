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

        public async Task AddNewMovieAsync(MovieVM movieVM)
        {
            var newMovie = new Movie()
            {
                Name = movieVM.Name,
                Description = movieVM.Description,
                Price = movieVM.Price,
                StartDate = movieVM.StartDate,
                EndDate = movieVM.EndDate,
                ImageURL = movieVM.ImageURL,
                MovieCategory = movieVM.MovieCategory,
                CinemaId = movieVM.CinemaId,
                ProducerId = movieVM.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach(var actorId in movieVM.ActorsId)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
               
            }
            await _context.SaveChangesAsync();
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

        public async Task UpdateMovieAsync(MovieVM movieVM)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync( x => x.Id == movieVM.Id);
            if(dbMovie != null)
            {

                dbMovie.Name = movieVM.Name;
                    dbMovie.Description = movieVM.Description;
                    dbMovie.Price = movieVM.Price;
                    dbMovie.StartDate = movieVM.StartDate;
                    dbMovie.EndDate = movieVM.EndDate;
                    dbMovie.ImageURL = movieVM.ImageURL;
                    dbMovie.MovieCategory = movieVM.MovieCategory;
                    dbMovie.CinemaId = movieVM.CinemaId;
                    dbMovie.ProducerId = movieVM.ProducerId;
               
                await _context.SaveChangesAsync();
            }
            var existingActors = _context.Actors_Movies.Where(x => x.MovieId == movieVM.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActors);
            await _context.SaveChangesAsync();

            foreach (var actorId in movieVM.ActorsId)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = dbMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }
    }
}
