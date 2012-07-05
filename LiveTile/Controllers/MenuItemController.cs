using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveTile.Models;

namespace LiveTile.Controllers
{
    public class MenuItemController : Controller
    {
        private LiveTileContext db = new LiveTileContext();

        //
        // GET: /MenuItem/

        public ActionResult Index()
        {
            return View(db.MenuItems.ToList());
        }

        //
        // GET: /MenuItem/Details/5

        public ActionResult Details(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        //
        // GET: /MenuItem/Create

        public ActionResult Create(int parentMenuId)
        {
            Menu menu = db.Menus.Single<Menu>(m => m.Id == parentMenuId);
            return View(new MenuItem { ParentMenu = menu });
        }

        //
        // POST: /MenuItem/Create

        [HttpPost]
        public ActionResult Create(int parentMenuId, MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                // TODO: Uncomment the code below
                //Menu menu = db.Menus.Single<Menu>(m => m.Id == parentMenuId);
                //menuitem.ParentMenu = menu;
                //db.MenuItems.Add(menuitem);
                //db.SaveChanges();
                return RedirectToAction("Details", "Menu", new { id = parentMenuId });
            }

            return View(menuitem);
        }

        //
        // GET: /MenuItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        //
        // POST: /MenuItem/Edit/5

        [HttpPost]
        public ActionResult Edit(int parentMenuId, MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                // TODO: Uncomment the code below
                //db.Entry(menuitem).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Details", "Menu", new { id = parentMenuId });
            }
            return View(menuitem);
        }

        //
        // GET: /MenuItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        //
        // POST: /MenuItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int parentMenuId, int id)
        {
            //TODO : Uncomment the code below
            //MenuItem menuitem = db.MenuItems.Find(id);
            //db.MenuItems.Remove(menuitem);
            //db.SaveChanges();
            return RedirectToAction("Details", "Menu", new { id = parentMenuId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}