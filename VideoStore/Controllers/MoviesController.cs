using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;

namespace VideoStore.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _db;
        public MoviesController()
        {
            _db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            RandomMovieViewModel customer = new RandomMovieViewModel
            {
                Movie= new Movie { Name="Shrek!"},
                Customers = _db.Customers.ToList()
               
            };
            return View(customer);
        }
      

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
       public ActionResult ByRealisedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

      

        
        
        public ActionResult MovieName()
        {
            var movie = _db.Movies;
            return View(movie);
        }


        public ActionResult MovieDetails(int id)
        {
            var movie = _db.Movies.Include(p=>p.Ganre).SingleOrDefault(p => p.Id == id);
            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        //New Customer
        public ActionResult NewCustomer()
        {
            var memberShip = _db.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipType = memberShip
            };
            return View(newCustomerViewModel);
        }

       

        //Adding new Movie
        [HttpGet]
        public ActionResult NewMovie()
        {
            RandomMovieViewModel movie = new RandomMovieViewModel
            {
                Ganre = _db.Ganres.ToList()
            };
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            var movieInDB = _db.Movies.Include(m=>m.Ganre).FirstOrDefault(m => m.Id == id);
            if (movieInDB == null) return HttpNotFound();
            RandomMovieViewModel filmViewModel = new RandomMovieViewModel
            {
                Ganre = _db.Ganres.ToList(),
                Movie = movieInDB
            };

            return View(filmViewModel);
        }

        [HttpPost]//Edit Movie
        public ActionResult EditMovie(Movie movie)
        {
            var movieInDB = _db.Movies.Single(p => p.Id == movie.Id);

            if (movieInDB == null) return HttpNotFound();

            movieInDB.Name = movie.Name;
            movieInDB.GanreId = movie.GanreId;
            movieInDB.DateReleased = movie.DateReleased;
            movieInDB.DateAdded = movie.DateAdded;

            _db.SaveChanges();
            return RedirectToAction("Customers");
        }

       
    }
}