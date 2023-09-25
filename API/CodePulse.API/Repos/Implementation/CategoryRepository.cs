using CodePulse.API.Data;
using CodePulse.API.Models;
using CodePulse.API.Repos.Interfaces;

namespace CodePulse.API.Repos.Implementation
{
    public class CategoryRepctoository : ICategoryRepo
    {
        private readonly ApplicationDbContext db;
        public CategoryRepctoository(ApplicationDbContext db)
        {
                this.db = db;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return category;
        }
    }
}
