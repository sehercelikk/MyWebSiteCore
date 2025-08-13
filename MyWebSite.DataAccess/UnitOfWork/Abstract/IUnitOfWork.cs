using MyWebSite.DataAccess.Abstract;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.DataAccess.UnitOfWork.Abstract;

public interface IUnitOfWork : IAsyncDisposable
{
    IMyAboutDal MyAboutDal { get; }
    IEducationDal EducationDal { get; }
    IExperienceDal ExperienceDal { get; }
    IJobDescriptionDal JobDescriptionDal { get; }
    IHobbyDal HobbyDal { get; }
    IProjectDal ProjectDal { get; }
    ISertificateDal SertificateDal { get; }
    ISkillDal SkillDal { get; }
    IContactDal ContactDal { get; }



    Task<int> SaveAsync();
}
