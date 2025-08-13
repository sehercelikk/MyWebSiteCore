using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite;

public interface IExperienceService
{
    Task<List<Experience>> GetAllAsync();
    Task<Experience> GetByIdAsync(int id);
    Task<string> AddEducation(Experience education);
    Task<string> DeleteEducation(int id);
    Task<string> UpdateEducation(Experience education);
}
