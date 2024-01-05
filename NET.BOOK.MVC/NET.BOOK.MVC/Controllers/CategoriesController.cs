using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NET.BOOK.MVC.Data;
using NET.BOOK.MVC.Models;

namespace NET.BOOK.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories =dbContext.Categories.ToList();

            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();

        }
        public IActionResult EditCategory(Guid? Id)
        {
            if (Id == null)
            {
                TempData["error"] = "Edit Category Error";
                return NotFound();
            }
            Category? category = dbContext.Categories.Find(Id);
            /* Category category1 = dbContext.Categories.FirstOrDefault(c => c.Id == Id);
             Category category2 = dbContext.Categories.Where(u => u.Id == Id).FirstOrDefault();*/
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult AddCategory(Category category) {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The DisplayOrder cannot exactly match the Name");
            }
            if(category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test Không Được Validate");
            }
            if (ModelState.IsValid) {
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                TempData["success"] = "Add Category Success";
                return RedirectToAction("Index");
            }
            return View();            
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                dbContext.SaveChanges();
                TempData["success"] = "Update Category Success";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult DeletePost(Guid? Id)
        {
            Category category = dbContext.Categories.Find(Id);
            if(category == null) {
                TempData["error"] = "Delete Category Error";
                return NotFound();
            }
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            TempData["success"] = "Delete Category Success";
            return RedirectToAction("Index");

        }
    }
}
