using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cocbasebuilder.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RankMyBase(string url)
        {
            //call the rank function and set it to score
            var score = 5;

            
            ViewBag.URL = HttpUtility.HtmlEncode(url??"");
            ViewBag.BaseScore = score;

            return View();
        }
    }
}