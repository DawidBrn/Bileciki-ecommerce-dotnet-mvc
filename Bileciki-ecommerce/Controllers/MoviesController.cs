﻿using Bileciki_ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var moviesData = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(moviesData);
        }
    }
}
