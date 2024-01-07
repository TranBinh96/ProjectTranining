using Microsoft.AspNetCore.Mvc;
using soa_blog_api.DTORequest;
using soa_blog_api.DTOResponse;
using soa_blog_api.Model;
using soa_blog_api.Respositories.Interface;

namespace soa_blog_api.Controllers
{
    //https://localhost:xxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly ICategoryResponsitory categoryResponsitory;
        public CategoriesController(ICategoryResponsitory categoryResponsitory)
        {
               this.categoryResponsitory = categoryResponsitory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategry(CategoriesDTORequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryResponsitory.CreateAsync(category);

            var categoyDTO = new CategoriesDTOResponse
            {
                Id = category.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            return Ok(categoyDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryResponsitory.GetAllAsync();
            var response= new List<CategoriesDTOResponse>();
            foreach (var category in categories)
            {
                response.Add(new CategoriesDTOResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await categoryResponsitory.FindById(id);
            if (existingCategory == null)
                return NotFound();
            var categoryReponse = CategoriesDTOResponse.formToData(existingCategory);
            
            return Ok(categoryReponse);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategoryById([FromRoute] Guid id,CategoriesDTORequest categoriesDTO)
        {
            var category = new Category
            {
                Id = id,
                Name = categoriesDTO.Name,
                UrlHandle = categoriesDTO.UrlHandle
            };

            await categoryResponsitory.UpdateAsync(category);

            if(category==null)
                return NotFound();
            
            return Ok(CategoriesDTOResponse.formToData(category));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategoryById([FromRoute] Guid id)
        {            
            var category =  await categoryResponsitory.DeleteAsync(id);
            if(category==null)
                return NotFound();
            return Ok(CategoriesDTOResponse.formToData(category));
        }

    }
}
