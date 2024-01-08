using Microsoft.EntityFrameworkCore;
using soa_blog_api.Model;

namespace soa_blog_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> categories {  get; set; }
        public DbSet<BlogPost> blogPosts {  get; set; }

    }
}
