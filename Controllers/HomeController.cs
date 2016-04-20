using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchExampleMVC.Models;
using SearchExampleMVC.ViewModels;

namespace SearchExampleMVC.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //GET: Search PartialView
        [HttpGet]
        public ActionResult _Search()
        {
            return PartialView();
        }
        //POST: Search Both partial and standard View. Takes string used in SearchResult().
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult _Search(string searchString)
        {
            //Add Server Side validation fallback
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                //Instance a new ViewModel
                SearchResultViewModel viewModel = new SearchResultViewModel();
                //Call SearchResult("MySearchString", MyDbContext)
                viewModel = ViewModels.Search.SearchResult(searchString, db);
                //Logic checking weather we got any results.
                if (viewModel.Categories.Count == 0 && viewModel.NewsPosts.Count == 0 && viewModel.Products.Count == 0)
                {
                    //Add null result handling.
                    ViewBag.ErrorMessage = "We Couldn't Find any results matching: " + searchString;
                }
                //Returns Search View and passes viewModel
                return View("Search", viewModel);
            }
            else
            {
                //Add null string handling.
                ViewBag.ErrorMessage = "Error Please Search for something";
                //Returns Search View
                return View("Search");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}