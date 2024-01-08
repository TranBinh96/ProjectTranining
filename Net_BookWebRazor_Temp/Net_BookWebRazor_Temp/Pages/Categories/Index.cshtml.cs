using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Net_BookWebRazor_Temp.Data;
using Net_BookWebRazor_Temp.Model;

namespace Net_BookWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public List<Category> Categories = new List<Category>();

        public IndexModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Categories  =  dbContext.categories.ToList();
           
        }
        
    }
}
