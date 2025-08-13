using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.Abstract;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Concrete.MyWebSite;

public class ExperienceService : ManagerBaseWebSite, IExperienceService
{
    public ExperienceService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<string> AddEducation(Experience education)
    {
        await _unitOfWork.ExperienceDal.AddAsync(education);
        await _unitOfWork.SaveAsync();
        return "Eğitim bilgisi başarıyla eklendi.";
    }

    public async Task<string> DeleteEducation(int id)
    {
        var entity= await _unitOfWork.ExperienceDal.GetByIdAsync(id);
        await _unitOfWork.ExperienceDal.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return "Silme işlemi başarılı.";
    }

    public async Task<List<Experience>> GetAllAsync()
    {
        var result = await _unitOfWork.ExperienceDal.GetAllAsync();
        return result;
    }

    public async Task<Experience> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.ExperienceDal.GetByIdAsync(id);
        return result;
    }

    public async Task<string> UpdateEducation(Experience education)
    {
        try
        {
            var item=await _unitOfWork.ExperienceDal.UpdateAsync(education);
            await _unitOfWork.SaveAsync();
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }
}
