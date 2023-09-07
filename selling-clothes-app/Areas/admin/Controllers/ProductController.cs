using selling_clothes_app.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace selling_clothes_app.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        selling_clothes_dbContext da = new selling_clothes_dbContext();
        // GET: admin/Product
        public ActionResult Index()
        {
            List<Product> ds = da.Product.Select(s => s).OrderByDescending(s => s.ProductId).ToList();
            return View(ds);
        }

        // GET: admin/Product/Create
        public ActionResult Create()
        {
            ViewData["LoaiSP"] = new SelectList(da.Category, "CategoryId", "CategoryName");

            return View();
        }

        // POST: admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product product,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //Tạo đối tượng sp p
                Product p = new Product();
                //gán đối tượng p bằng product
                p = product;
                // Xu ly gan NCC va LoaiSP
                //Thực thiện thêm p vào bẳng product
                p.CreatedDate = DateTime.Now;
                p.ModifiedDate = DateTime.Now;

                da.Product.Add(p);
                p.CategoryId = int.Parse(collection["LoaiSP"]);
                //lưu xuống database
                da.SaveChanges();

                //gọi lại trang dssp
                return RedirectToAction("Index"); // phải trả bẳng listproduct
            }
            catch
            {
                return View(product);
            }
        }

        // GET: admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin/Product/Edit/5
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

        // GET: admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin/Product/Delete/5
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

        // GET: admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
