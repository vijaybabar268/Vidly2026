using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2026.Models;
using Vidly2026.ViewModels;

namespace Vidly2026.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            movie.DateAdded = DateTime.UtcNow;

            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {                
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Edit/1
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel(movie)
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // POST
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        // GET: Movies/Details/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}