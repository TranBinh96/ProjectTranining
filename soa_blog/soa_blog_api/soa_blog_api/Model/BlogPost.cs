using soa_blog_api.DTORequest;

namespace soa_blog_api.Model
{
    public class BlogPost
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

        public static BlogPost fromData(BlogPostRequest blogtRequest)
        {
           return new BlogPost
            {
               Title=blogtRequest.title,
                ShortDescription = blogtRequest.shortDescription,
                Content = blogtRequest.content,
                Author = blogtRequest.author,
                UrlHandle = blogtRequest.urlHandle,
                PublishedDate = blogtRequest.publishedDate,
                FeaturedImageUrl = blogtRequest.featuredImageUrl,
                isVisible = blogtRequest.isVisible
            };

        }

        public static BlogPost fromDataUpdateID(Guid id,BlogPostRequest blogtRequest)
        {
            return new BlogPost
            {
                Id =id,
                Title = blogtRequest.title,
                ShortDescription = blogtRequest.shortDescription,
                Content = blogtRequest.content,
                Author = blogtRequest.author,
                UrlHandle = blogtRequest.urlHandle,
                PublishedDate = blogtRequest.publishedDate,
                FeaturedImageUrl = blogtRequest.featuredImageUrl,
                isVisible = blogtRequest.isVisible
            };

        }

        public static implicit operator BlogPost(Task<BlogPost?> v)
        {
            throw new NotImplementedException();
        }
    }

   
}
