using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MVCDbStockEntities db = new MVCDbStockEntities();
        public ActionResult Index()
        {
            var values = db.TBLPRODUCTS.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.TBLCATEGORIES.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CATEGORYNAME,
                                               Value = i.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(TBLPRODUCT p1)
        {
            var ctgry = db.TBLCATEGORIES.Where(m => m.CATEGORYID == p1.TBLCATEGORy.CATEGORYID).FirstOrDefault();
            p1.TBLCATEGORy = ctgry;
            db.TBLPRODUCTS.Add(p1);
            db.TBLPRODUCTS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id)
        {
            var prdct = db.TBLPRODUCTS.Find(id);
            db.TBLPRODUCTS.Remove(prdct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            var prdct = db.TBLPRODUCTS.Find(id);
            List<SelectListItem> values = (from i in db.TBLCATEGORIES.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CATEGORYNAME,
                                               Value = i.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View("GetProduct", prdct);
        }
        public ActionResult Update(TBLPRODUCT p1)
        {
            var prdct = db.TBLPRODUCTS.Find(p1.PRODUCTID);
            prdct.PRODUCTNAME = p1.PRODUCTNAME;
            prdct.BRAND = p1.BRAND;
            prdct.PRICE = p1.PRICE;
            prdct.STOCK = p1.STOCK;
            //prdct.PRODUCTCATEGORY = p1.PRODUCTCATEGORY;
            var ctgry = db.TBLCATEGORIES.Where(m => m.CATEGORYID == p1.TBLCATEGORy.CATEGORYID).FirstOrDefault();
            prdct.PRODUCTCATEGORY = ctgry.CATEGORYID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}