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
    public class MenuController : Controller
    {
        private LiveTileContext db = new LiveTileContext();

        //
        // GET: /Menu/

        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        //
        // GET: /Menu/Details/5

        public ActionResult Details(int id = 0)
        {
            Menu menu = db.Menus.Include("MenuItems").Single<Menu>(m => m.Id == id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        //
        // GET: /Menu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Menu/Create

        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                // TODO: Disabled to prevent XSS attacks
                //db.Menus.Add(menu);
                //db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(menu);
        }

        //
        // GET: /Menu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        //
        // POST: /Menu/Edit/5

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                if (!IsAdminMenu(menu))
                {
                    // TODO: Disabled to prevent XSS attacks on Demo
                    //db.Entry(menu).State = EntityState.Modified;
                    //db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        //This is a hack to prevent script kiddie hackers,
        //from deleting the Main Menus in the Demo Site
        //Either remove this check or use it for something
        //more useful in your application
        private bool IsAdminMenu(Menu menu)
        {
            return (menu.Name == "Home" || menu.Name == "Menus");
        }

        //
        // GET: /Menu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        //
        // POST: /Menu/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // TODO: Disabled to prevent XSS Attacks
            //Menu menu = db.Menus.Include("MenuItems").Single<Menu>(m => m.Id == id);
            //db.Menus.Remove(menu);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}