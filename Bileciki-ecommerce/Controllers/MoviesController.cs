using Bileciki_ecommerce.Data;
using Bileciki_ecommerce.Data.Services;
using Bileciki_ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var moviesData = await _service.GetAllAsync(n => n.Cinema); ;
            return View(moviesData);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var moviesData = await _service.GetAllAsync(n => n.Cinema);

            if (searchString != string.Empty)
            {
                var fileredMovies = moviesData.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
                return View("Index",fileredMovies);
            }

            return View(moviesData);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownValues();
            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
            ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieVM newMovie)
        {
            

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownValues();
                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");
                return View(newMovie);
            }
                
            await _service.AddNewMovieAsync(newMovie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return NotFound();

            var result = new MovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                ProducerId = movieDetails.ProducerId,
                CinemaId=movieDetails.CinemaId,
                MovieCategory= movieDetails.MovieCategory,
                ActorsId = movieDetails.Actors_Movies.Select( x => x.ActorId ).ToList()

            };
            var movieDropdownsData = await _service.GetMovieDropdownValues();
            ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
            ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, MovieVM newMovie)
        {
            
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownValues();
                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");
                return View(newMovie);
            }

            await _service.UpdateMovieAsync(newMovie);
            return RedirectToAction("Index");
        }
    }
}
