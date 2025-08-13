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

public class EductionService : ManagerBaseWebSite, IEducationService
{
    public EductionService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    public async Task<List<Education>> GetAllAsync()
    {
        try
        {
            var result = await _unitOfWork.EducationDal.GetAllAsync();
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<string> AddEducation(Education education)
    {
        try
        {
            if(education == null)
            {
                return "Eğitim bilgisi boş olamaz.";
            }
            await _unitOfWork.EducationDal.AddAsync(education);
            await _unitOfWork.SaveAsync();
            return "Eğitim bilgisi eklendi.";

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<string> DeleteEducation(int id)
    {
        try
        {
            if(id==null || id <= 0)
            {
                return "Geçersiz eğitim bilgisi ID.";
            }
            var result = await _unitOfWork.EducationDal.GetByIdAsync(id);
            await _unitOfWork.EducationDal.DeleteAsync(result);
            await _unitOfWork.SaveAsync();
            return "Silme işlemi başarılı.";
        }
        catch (Exception)
        {

            throw;
        }
    }



    public async Task<Education> GetByIdAsync(int id)
    {
        try
        {
            if (id == null || id <= 0)
            {
                var message = "Geçersiz eğitim bilgisi ID.";
            }
            var result = await _unitOfWork.EducationDal.GetByIdAsync(id);
            if (result == null)
            {
                var message = "Eğitim bilgisi bulunamadı.";

            }
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<string> UpdateEducation(Education education)
    {
        try
        {
            if(education ==null)
            {
                return "Geçersiz eğitim bilgisi.";
            }
            var result = await _unitOfWork.EducationDal.UpdateAsync(education);
            await _unitOfWork.SaveAsync();
            return "Eğitim bilgisi güncellendi.";

        }
        catch (Exception)
        {

            throw;
        }
    }
}
