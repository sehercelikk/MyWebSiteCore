using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Concrete.MyWebSite;

public class JobDescriptionService : ManagerBaseWebSite, IJobDescriptionService
{
    public JobDescriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<string> AddEducation(JobDescription education)
    {
        try
        {
            var result = await _unitOfWork.JobDescriptionDal.AddAsync(education);
            await _unitOfWork.SaveAsync();
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<string> DeleteEducation(int id)
    {
        var findId= await _unitOfWork.JobDescriptionDal.GetByIdAsync(id);
        await _unitOfWork.JobDescriptionDal.DeleteAsync(findId);
        await _unitOfWork.SaveAsync();
        return "Eğitim başarıyla silindi.";
    }

    public async Task<List<JobDescription>> GetAllAsync()
    {
        var result = await _unitOfWork.JobDescriptionDal.GetAllAsync();
        return result;
    }

    public async Task<JobDescription> GetByIdAsync(int id)
    {
        var findId = await _unitOfWork.JobDescriptionDal.GetByIdAsync(id);
        return findId;
    }

    public async Task<string> UpdateEducation(JobDescription education)
    {
        await _unitOfWork.JobDescriptionDal.UpdateAsync(education);
        await _unitOfWork.SaveAsync();
        return "Eğitim başarıyla güncellendi.";
    }
}
