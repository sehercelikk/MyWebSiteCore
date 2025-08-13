using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(int id);
        Task<string> AddAsync(Skill skill);
        Task<string> UpdateAsync(Skill skill);
        Task<string> DeleteAsync(int id);
    }
}
