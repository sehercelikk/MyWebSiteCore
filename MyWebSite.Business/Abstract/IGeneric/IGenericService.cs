using MyWebSite.Business.Abstract.IMyWebSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IGeneric;

public interface IGenericService
{
    IMyAboutService MyAboutService { get; }
    IEducationService EducationService { get; }
    IExperienceService ExperienceService { get; }
    IJobDescriptionService JobDescriptionService { get; }
    IHobbyService HobbyService { get; }
    IProjectService ProjectService { get; }
    ISertificateService SertificateService { get; }
    ISkillService SkillService { get; }
    IContactService ContactService { get; }


}
