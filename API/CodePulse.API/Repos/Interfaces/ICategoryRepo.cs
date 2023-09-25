using CodePulse.API.Models;

namespace CodePulse.API.Repos.Interfaces
{
    public interface ICategoryRepo
    {
        Task <Category> CreateAsync(Category category);
    }
}
