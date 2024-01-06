using soa_blog_api.Model;

namespace soa_blog_api.Respositories.Interface
{
    public interface ICategoryResponsitory
    {
        Task<Category> CreateAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> FindById(Guid Id);
    }
}
