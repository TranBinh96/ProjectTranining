using Microsoft.AspNetCore.Mvc;
using soa_blog_api.DTORequest;
using soa_blog_api.DTOResponse;
using soa_blog_api.Model;
using soa_blog_api.Respositories.Interface;

namespace soa_blog_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostBlogController : Controller
    {
        private readonly IBlogPostResponsitory blogPostResponsitory;

        public PostBlogController(IBlogPostResponsitory  blogPostResponsitory) {
            this.blogPostResponsitory = blogPostResponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost() {
            List<BlogPost> blogPosts = (List<BlogPost>)await blogPostResponsitory.GetBlogPostAllAsync();
            return Ok(BlogPostDTOReponse.formData(blogPosts));        
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody]BlogPostRequest blogPostRequest) {
            BlogPost blogPost = await  blogPostResponsitory.CreateAsync(BlogPost.fromData(blogPostRequest));
            return Ok(blogPost);
        }

        [HttpGet]
        [Route("{id:Guid}")]   
        public async Task<IActionResult> GetBlogPostById([FromRoute]Guid id)
        {
            var  existingBlogPost = await blogPostResponsitory.GetBlogPostByIdAsync(id);

            if (existingBlogPost == null)
                return NotFound();

            var blogPost=  BlogPostDTOReponse.formDataByID(existingBlogPost);
            
            return Ok(blogPost);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute]Guid id,BlogPostRequest request)
        {
            var blogPost = BlogPost.fromDataUpdateID(id,request);
            await blogPostResponsitory.UpdateBlogPostByIdAsync(blogPost);
            if (blogPost == null) return NotFound();
            return Ok(blogPost);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPostById([FromRoute] Guid id)
        {
            var blogPost = await blogPostResponsitory.DeleteBlogPostByIdAsync(id);
            if (blogPost == null) return NotFound();
            return Ok(blogPost); 
        }




    }
}
