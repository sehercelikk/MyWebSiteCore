using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<string> AddProject(Project project);
        Task<string> UpdateProject(Project project);
        Task<string> DeleteProject(int id);
    }
}
