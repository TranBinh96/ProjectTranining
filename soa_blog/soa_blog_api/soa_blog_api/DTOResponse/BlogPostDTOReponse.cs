using Azure;
using soa_blog_api.Model;

namespace soa_blog_api.DTOResponse
{
    public class BlogPostDTOReponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public Boolean isVisible { get; set; }


        public static List<BlogPostDTOReponse> formData(List<BlogPost> listBlgPost)
        {
            List<BlogPostDTOReponse> blogPostDTOs = new List<BlogPostDTOReponse>();

            foreach (var blogPost in listBlgPost)
            {
                blogPostDTOs.Add(new BlogPostDTOReponse
                {
                    Id = blogPost.Id,
                    Title=blogPost.Title,
                    ShortDescription = blogPost.ShortDescription,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,  
                    PublishedDate = blogPost.PublishedDate,
                    isVisible = blogPost.isVisible,
                    UrlHandle = blogPost.UrlHandle,
                    Author = blogPost.Author,
                });
            }
            return blogPostDTOs;


        }
        
        public static BlogPostDTOReponse formDataByID(BlogPost BlgPost)
        {
            return new BlogPostDTOReponse {
                Id = BlgPost.Id,
                Title=BlgPost.Title,
                ShortDescription = BlgPost.ShortDescription,
                Content = BlgPost.Content,
                FeaturedImageUrl = BlgPost.FeaturedImageUrl,
                PublishedDate = BlgPost.PublishedDate,
                isVisible = BlgPost.isVisible,
                UrlHandle = BlgPost.UrlHandle,
                Author = BlgPost.Author
            };
        }


    }


}
