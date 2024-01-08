using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net_BookWebRazor_Temp.Data;
using Net_BookWebRazor_Temp.Model;
using System.Xml.Serialization;

namespace Net_BookWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category category {  get; set; } 
        public EditModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public void OnGet(Guid? Id)
        {
            if (Id != null)
            {
                category = dbContext.categories.Find(Id);
            }
        }

        public IActionResult OnPost()
        {
            dbContext.Update(category);
            dbContext.SaveChanges();
            return RedirectToPage("Index");
        }


    }
}
