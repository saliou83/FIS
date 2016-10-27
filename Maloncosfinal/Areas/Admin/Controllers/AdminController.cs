using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maloncos.Models;

namespace Maloncos.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Home/
        private MaloncosEntities1 _db = new MaloncosEntities1();
        //
        // GET: /Admin/Admin/

        public ActionResult Index()
        {
            return View("/Areas/Admin/Views/Admin/Index.cshtml",_db.Articles.ToList());
        }

        //
        // GET: /Admin/Admin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Admin/Create

        public ActionResult Create()
        {
            return View("/Areas/Admin/Views/Admin/Index.cshtml");
        } 

        //
        // POST: /Admin/Admin/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Num_Articles")] Articles articlesToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _db.AddToArticles(articlesToCreate);
                _db.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("/Areas/Admin/Views/Admin/Index.cshtml");
            }
            catch
            {
                return View("/Areas/Admin/Views/Admin/Index.cshtml");
            }
        }
        
        //
        // GET: /Admin/Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Edit/5

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
        // GET: /Admin/Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Admin/Delete/5

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
