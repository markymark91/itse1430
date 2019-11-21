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
   
    public class MovieController : Controller
    {
        public MovieController ()
        {
            var connString = ConfigurationManager.ConnectionStrings ["MovieDatabase"];
            _database = new SqlMovieDatabase (connString.ConnectionString);
        }
        [HttpGet]
        public ActionResult Index()
        {
            var items = _database.GetAll();

            var model = items.Select (i => i.ToModel ());

            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}