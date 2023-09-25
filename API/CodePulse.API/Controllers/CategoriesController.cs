using CodePulse.API.Data;
using CodePulse.API.Models;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoriesController(ICategoryRepo _categoryRepo)
        {
            this._categoryRepo = _categoryRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO request)
        {
            var category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            await _categoryRepo.CreateAsync(category);

            //Domain model to DTO
            var categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok();
        }
    }
}
