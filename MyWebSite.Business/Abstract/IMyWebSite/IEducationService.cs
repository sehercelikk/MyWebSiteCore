using MyWebSite.Entities.Concrete;

namespace MyWebSite.Business.Abstract.IMyWebSite;

public interface IEducationService
{
    Task<List<Education>> GetAllAsync();
    Task<Education> GetByIdAsync(int id);
    Task<string> AddEducation(Education education);
    Task<string> DeleteEducation(int id);
    Task<string> UpdateEducation(Education education);

}
