using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net_BookWebRazor_Temp.Data;
using Net_BookWebRazor_Temp.Model;

namespace Net_BookWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category category { get; set; }  

        public DeleteModel(ApplicationDbContext dbContext) { 
            this.dbContext = dbContext;
        }  
        public void OnGet(Guid? Id)
        {
            if(Id != null)
            {
                category = dbContext.categories.Find(Id);
            }
        }

        public IActionResult OnPost() { 
            Category? categories = dbContext.categories.Find(category.Id);
            if(categories != null)
            {
                dbContext.categories.Remove(categories);
                dbContext.SaveChanges();
                return RedirectToPage("Index");
    
            }
            return NotFound();


        }
    }
}
