using Microsoft.EntityFrameworkCore;
using MyWebSite.Core.DataAccess.Concrete;
using MyWebSite.DataAccess.Abstract;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.DataAccess.Concrete
{
    public class EfSkillRepository : EfGenericRepository<Skill>, ISkillDal
    {
        public EfSkillRepository(DbContext context) : base(context)
        {
        }
    }
}
