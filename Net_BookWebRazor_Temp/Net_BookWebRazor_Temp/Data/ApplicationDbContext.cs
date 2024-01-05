using Microsoft.EntityFrameworkCore;
using Net_BookWebRazor_Temp.Model;

namespace Net_BookWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> categories {  get; set; }
    }
}
