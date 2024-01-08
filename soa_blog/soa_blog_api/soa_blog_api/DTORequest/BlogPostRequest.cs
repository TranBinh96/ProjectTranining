namespace soa_blog_api.DTORequest
{
    public class BlogPostRequest{
        public string title { get; set; }
        public string shortDescription { get; set; }
        public string content { get; set; }
        public string featuredImageUrl { get; set; }
        public string urlHandle { get; set; }
        public DateTime publishedDate { get; set; }
        public string author { get; set; }
        public Boolean isVisible { get; set; }
    }
}
