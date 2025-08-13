using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Concrete.MyWebSite
{
    public class ProjectService : ManagerBaseWebSite, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> AddProject(Project project)
        {
            await _unitOfWork.ProjectDal.AddAsync(project);
            await _unitOfWork.SaveAsync();
            return "Proje eklendi.";
        }

        public async Task<string> DeleteProject(int id)
        {
            var findId= await _unitOfWork.ProjectDal.GetByIdAsync(id);
            await _unitOfWork.ProjectDal.DeleteAsync(findId);
            await _unitOfWork.SaveAsync();
            return "Proje silindi.";
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var result = await _unitOfWork.ProjectDal.GetAllAsync();
            return result;
        }

        public Task<Project> GetByIdAsync(int id)
        {
            var findId= _unitOfWork.ProjectDal.GetByIdAsync(id);
            return findId;
        }

        public async Task<string> UpdateProject(Project project)
        {
            await _unitOfWork.ProjectDal.UpdateAsync(project);
            await _unitOfWork.SaveAsync();
            return "Proje güncellendi.";
        }
    }
}
