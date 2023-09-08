using selling_clothes_app.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace selling_clothes_app.Areas.admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: admin/Customer
        private selling_clothes_dbContext da = new selling_clothes_dbContext();
        public ActionResult Index()
        {
            List<Customer> ds = da.Customer.Select(s => s).OrderByDescending(s => s.CustomerID).ToList();
            return View(ds);
        }


        // GET: admin/Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin/Customer/Edit/5
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

        // GET: admin/Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin/Customer/Delete/5
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
