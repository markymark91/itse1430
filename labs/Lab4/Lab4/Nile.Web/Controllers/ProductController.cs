using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Stores.Sql;
using Nile.Web.Models;

namespace Nile.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"];
            _database = new SqlProductDatabase (connString.ConnectionString);
        }
       
        [HttpGet]
        public ActionResult Index ()
        {
            var items = _database.GetAll ()
                                 .OrderBy (x => x.Name);

            var model = items.Select (i => i.ToModel ());

            return View (model);
        }
        
       /* [HttpGet]
        public ActionResult Details(int id)
        {
            var product = _database.Get (id);
            if (product == null)
                return HttpNotFound ();

            var model = product.ToModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Details (ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToDomain ();
                    _database.Get (model.Id);

                    return RedirectToAction ("Details", new { id = product.Id });
                };
            } catch (Exception e)
            {
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }
        */
        [HttpGet]
        public ActionResult Delete ( int id )
        {
            var product = _database.Get (id);
            if (product == null)
                return HttpNotFound ();

            var model = product.ToModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Delete ( ViewModel model )
        {
            try
            {
                _database.Remove (model.Id);

                return RedirectToAction ("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        [HttpGet]
        public ActionResult Edit ( int id )
        {
            var product = _database.Get (id);
            if (product == null)
                return HttpNotFound ();

            var model = product.ToModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Edit ( ViewModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToDomain ();
                    _database.Update (product);

                    return RedirectToAction ("Edit", new { id = product.Id });
                };
            } catch (Exception e)
            {
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Create ( ViewModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = model.ToDomain ();
                    _database.Add (product);

                    return RedirectToAction ("Index");
                };
            } catch (Exception e)
            {
                ModelState.AddModelError ("", e.Message);
            };

            return View (model);
        }

        private readonly IProductDatabase _database;
    }
}