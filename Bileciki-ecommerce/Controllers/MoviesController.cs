using Bileciki_ecommerce.Data;
using Bileciki_ecommerce.Data.Services;
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
    }
}
