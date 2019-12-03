using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Itse1430.MovieLib.SqlServer;
using Itse1430.MovieLib.WebHost.Models;

namespace Itse1430.MovieLib.WebHost.Controllers
{
    /// <summary>Handles requests for movies.</summary>
    public class MovieController : Controller
    {
        public MovieController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _database = new SqlMovieDatabase (connString.ConnectionString);
        }

        /// <summary>Called to get the list of movies.</summary>        
        [HttpGet]
        public ActionResult Index ()
        {
            var items = _database.GetAll ()
                                 .OrderBy (x => x.Title)
                                 .ThenBy (x => x.ReleaseYear);

            var model = items.Select (i => i.ToModel ());

            return View (model);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View ();
        }

        [HttpGet]
        public ActionResult Delete ( int id )
        {
            var movie = _database.Get (id);
            if (movie == null)
                return HttpNotFound ();

            var model = movie.ToModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Delete ( MovieModel model )
        {
            try
            {
                _database.Remove (model.Id);

                //PRG 
                return RedirectToAction ("Index");
            } catch (Exception e)
            {
                //Don't use Exception overload - doesn't work
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var movie = _database.Get (id);
            if (movie == null)
                return HttpNotFound ();

            var model = movie.ToModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Edit ( MovieModel model )
        {
            try
            {
                //Validate
                if (ModelState.IsValid)
                {
                    //Save if valid
                    var movie = model.ToDomain ();
                    _database.Update (movie.Id, movie);

                    //PRG 
                    return RedirectToAction ("Edit", new { id = movie.Id });
                };
            } catch (Exception e)
            {
                //Don't use Exception overload - doesn't work
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        [HttpPost]
        public ActionResult Create ( MovieModel model )
        {
            try
            {
                //Validate
                if (ModelState.IsValid)
                {
                    //Save if valid
                    var movie = model.ToDomain ();
                    _database.Add (movie);

                    //PRG 
                    return RedirectToAction ("Index");
                };
            } catch (Exception e)
            {
                //Don't use Exception overload - doesn't work
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        private readonly IMovieDatabase _database;
    }
}