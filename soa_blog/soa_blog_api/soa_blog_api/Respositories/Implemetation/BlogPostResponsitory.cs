using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using soa_blog_api.Data;
using soa_blog_api.Model;
using soa_blog_api.Respositories.Interface;

namespace soa_blog_api.Respositories.Implemetation
{
    public class BlogPostResponsitory : IBlogPostResponsitory
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostResponsitory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.blogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteBlogPostByIdAsync(Guid Id)
        {
            var existsBlogPost =  await dbContext.blogPosts.FirstOrDefaultAsync(u=> u.Id== Id);
            if (existsBlogPost == null)
                return null;
            dbContext.Remove(existsBlogPost);
            return existsBlogPost;
            
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostAllAsync()
        {
            return await dbContext.blogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(Guid blogPostId)
        {          
            return await dbContext.blogPosts.FirstOrDefaultAsync(blogPost => blogPost.Id == blogPostId);
        }

        public async Task<BlogPost?> UpdateBlogPostByIdAsync(BlogPost blogPost)
        {
            var exitsBlogPost = await dbContext.blogPosts.FirstOrDefaultAsync(u=> u.Id == blogPost.Id);
            if (exitsBlogPost is null)
                return null;
            dbContext.Entry(exitsBlogPost).CurrentValues.SetValues(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }
    }
}
