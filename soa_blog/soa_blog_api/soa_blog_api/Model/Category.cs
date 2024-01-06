using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace soa_blog_api.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }

    }
}
