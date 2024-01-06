using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using soa_blog_api.Data;
using soa_blog_api.Model;
using soa_blog_api.Respositories.Interface;

namespace soa_blog_api.Respositories.Implemetation
{
    public class CategoryResponsitory : ICategoryResponsitory
    {
        private readonly ApplicationDbContext dbConnect;

        public CategoryResponsitory(ApplicationDbContext dbConnect)
        {
            this.dbConnect = dbConnect;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbConnect.categories.AddAsync(category);
            await dbConnect.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> FindById(Guid Id)
        {
            return await dbConnect.categories.FindAsync(Id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbConnect.categories.ToListAsync();
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
           var existingCategory = await dbConnect.categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (existingCategory != null)
            {
                dbConnect.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbConnect.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
