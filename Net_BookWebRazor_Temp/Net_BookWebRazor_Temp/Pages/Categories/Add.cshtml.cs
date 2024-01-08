using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net_BookWebRazor_Temp.Data;
using Net_BookWebRazor_Temp.Model;

namespace Net_BookWebRazor_Temp.Pages.Categories
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public Category Category { get; set; }
        public AddModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            dbContext.Add(Category);
            dbContext.SaveChanges();
            TempData["success"] = "Add Category Success";
            return RedirectToPage("Index");
        }
    }
}
