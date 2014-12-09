using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2_PavloLysak_s00130207_.Models;

namespace CA2_PavloLysak_s00130207_.Controllers
{
    public class HomeController : Controller
    {
       MovieDb db = new MovieDb();

        //
        // GET: /Home/

       public ActionResult Index(string sortOrder)
        {
            ViewBag.dateOrder = sortOrder == "upDate" ? "downDate" : "ascDate";

           IQueryable<Movie> movies = db.MoviesContext;
            switch (sortOrder)
            {
                case "downDate":
                    movies = movies.OrderByDescending(c => c.MovieReleaseDate);
                    break;
                case "upDate":
                    movies = movies.OrderBy(c => c.MovieReleaseDate);
                    break;
            }

            return View(db.MoviesContext.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            var mvs = db.MoviesContext.Find(id);
            if (mvs == null) 
                return View();
            else
                return View(mvs);
        }

        //
        // GET: /Home/Create

        public PartialViewResult ActorPV(int id)
        {
            var movies = db.MoviesContext.Find(id);
            @ViewBag.movieId = id;
            @ViewBag.movieName = movies.MovieName;
            return PartialView("_ActorsinMovie", movies.Actors);
        }

        public ActionResult Create()
        {
            ViewBag.directorsList = db.DirectorsContext.ToList();
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db2 = new MovieDb())
                    {
                        db2.MoviesContext.Add(newMovie);
                        db2.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
              
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
