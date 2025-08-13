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

public class SertificateService : ManagerBaseWebSite, ISertificateService
{
    public SertificateService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<string> AddSertificate(Sertificate sertificate)
    {
        await _unitOfWork.SertificateDal.AddAsync(sertificate);
        await _unitOfWork.SaveAsync();
        return "Sertifika eklendi.";
    }

    public async Task<string> DeleteSertificate(int id)
    {
        var entity =await _unitOfWork.SertificateDal.GetByIdAsync(id);
        await _unitOfWork.SertificateDal.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
        return "Sertifika silindi.";
    }

    public async Task<List<Sertificate>> GetAllAsync()
    {
        var result = await _unitOfWork.SertificateDal.GetAllAsync();
        return result;
    }

    public async Task<Sertificate> GetByIdAsync(int id)
    {
        var findId=await _unitOfWork.SertificateDal.GetByIdAsync(id);
        return findId;
    }

    public async Task<string> UpdateSertificate(Sertificate sertificate)
    {
        await _unitOfWork.SertificateDal.UpdateAsync(sertificate);
        await _unitOfWork.SaveAsync();
        return "Sertifika güncellendi.";
    }
}
