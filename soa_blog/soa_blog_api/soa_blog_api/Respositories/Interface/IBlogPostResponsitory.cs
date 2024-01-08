using soa_blog_api.Model;

namespace soa_blog_api.Respositories.Interface
{
    public interface IBlogPostResponsitory
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);

        Task<IEnumerable<BlogPost>> GetBlogPostAllAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(Guid blogPostId);
        Task<BlogPost?> UpdateBlogPostByIdAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteBlogPostByIdAsync(Guid Id);

    }
}
