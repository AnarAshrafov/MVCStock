using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MVCDbStockEntities db = new MVCDbStockEntities();
        public ActionResult Index(int page = 1)
        {
            //var values = db.TBLCATEGORIES.ToList();
            var values = db.TBLCATEGORIES.ToList().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(TBLCATEGORy p1)
        {
            if (!ModelState.IsValid) { return View("NewCategory"); }
            db.TBLCATEGORIES.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id)
        {
            var ctgry = db.TBLCATEGORIES.Find(id);
            db.TBLCATEGORIES.Remove(ctgry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ctgry = db.TBLCATEGORIES.Find(id);
            return View("GetCategory",ctgry);
        }
        public ActionResult Update(TBLCATEGORy p1)
        {
            var ctgry = db.TBLCATEGORIES.Find(p1.CATEGORYID);
            ctgry.CATEGORYNAME = p1.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}