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
    public class SkillService : ManagerBaseWebSite, ISkillService
    {
        public SkillService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> AddAsync(Skill skill)
        {
            await _unitOfWork.SkillDal.AddAsync(skill);
            await _unitOfWork.SaveAsync();
            return "Kayıt Eklendi";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var findId= await _unitOfWork.SkillDal.GetByIdAsync(id);
            await _unitOfWork.SkillDal.DeleteAsync(findId);
            await _unitOfWork.SaveAsync();
            return "Skill silindi.";
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            var result= await _unitOfWork.SkillDal.GetAllAsync();
            return result;
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            var findID= await _unitOfWork.SkillDal.GetByIdAsync(id);
            return findID;
        }

        public async Task<string> UpdateAsync(Skill skill)
        {
            await _unitOfWork.SkillDal.UpdateAsync(skill);
            await _unitOfWork.SaveAsync();
            return "";
        }
    }
}
