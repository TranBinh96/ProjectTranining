using soa_blog_api.Model;

namespace soa_blog_api.DTOResponse
{
    public class CategoriesDTOResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }

        public static CategoriesDTOResponse formToData(Category category)
        {
            return new CategoriesDTOResponse
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

        }
    }
}
