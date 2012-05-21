using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveTile.Models;

namespace LiveTile.Controllers
{
    public class HomeController : Controller
    {
        private LiveTileContext db = new LiveTileContext();

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult MenuLayout(string name)
        {
            Menu menu = db.Menus.Include("MenuItems").Single<Menu>(m => m.Name == "Main");
            return PartialView("_MenuLayout", menu);
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
