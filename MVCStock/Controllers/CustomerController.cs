using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MVCDbStockEntities db = new MVCDbStockEntities();
        public ActionResult Index()
        {
            var values = db.TBLCUSTOMERS.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(TBLCUSTOMER p1)
        {
            if (!ModelState.IsValid) { return View("NewCustomer"); }
            db.TBLCUSTOMERS.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCustomer(int id)
        {
            var cstmr = db.TBLCUSTOMERS.Find(id);
            db.TBLCUSTOMERS.Remove(cstmr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var cstmr = db.TBLCUSTOMERS.Find(id);
            return View("GetCustomer", cstmr);
        }
        public ActionResult Update(TBLCUSTOMER p1)
        {
            var cstmr = db.TBLCUSTOMERS.Find(p1.CUSTOMERID);
            cstmr.CUSTOMERFIRSTNAME = p1.CUSTOMERFIRSTNAME;
            cstmr.CUSTOMERLASTNAME = p1.CUSTOMERLASTNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}