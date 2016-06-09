using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<Models.CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<Models.CommentModel>
            {
                new Models.CommentModel
                {
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new Models.CommentModel
                {
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new Models.CommentModel
                {
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
        }
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
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddComment(Models.CommentModel comment)
        {
            _comments.Add(comment);
            return Content("Success :)");
        }
    }
}