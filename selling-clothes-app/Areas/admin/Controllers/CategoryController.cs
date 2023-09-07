using PagedList;
using selling_clothes_app.Areas.admin.Data;
using selling_clothes_app.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace selling_clothes_app.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        private selling_clothes_dbContext da = new selling_clothes_dbContext();
        // GET: admin/Category
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }

            IEnumerable<Category> items = da.Category.OrderByDescending(x => x.CategoryId);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                var searchText = ToolClass.RemoveUnidecode(Searchtext).ToLower();
                items = items.Where(
                    x => ToolClass.RemoveUnidecode(x.CategoryName).ToLower().Contains(searchText) ||
                    ToolClass.RemoveUnidecode(x.Description).ToLower().Contains(searchText)
                    );
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(items);
        }

        // GET: admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    //Tạo đối tượng sp p
                    Category c = new Category();
                    //gán đối tượng p bằng product
                    c = model;
                    // Xu ly gan NCC va LoaiSP
                    //Thực thiện thêm p vào bẳng product
                    da.Category.Add(c);
                    //lưu xuống database
                    da.SaveChanges();

                    //gọi lại trang dssp
                    return RedirectToAction("Index"); // phải trả bẳng listproduct
                }
                catch
                {
                    return View(model);
                }
            }

            return View(model);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Category c = da.Category.FirstOrDefault(s => s.CategoryId == id);

            return View(c);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                //xác định sp cần sửa
                Category c = da.Category.First(s => s.CategoryId == category.CategoryId); // chỉ dùng first vì nếu không tìm thấy sp thì báo lỗi
                //Thực hiện sửa
                c.CategoryName = category.CategoryName;
                c.Description = category.Description;

                //lưu xuống database
                da.SaveChanges();
                //gọi lại dssp

                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                //Xác định sp cần xóa
                Category c = da.Category.First(s => s.CategoryId == id);
                //Thực hiện xóa sp
                da.Category.Remove(c);
                //gọi lại dssp
                da.SaveChanges();
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = da.Category.First(s => s.CategoryId == Convert.ToInt32(item));
                        da.Category.Remove(obj);
                        da.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}