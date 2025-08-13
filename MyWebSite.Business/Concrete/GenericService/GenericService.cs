using MyWebSite.Business.Abstract.IGeneric;
using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.Business.Concrete.MyWebSite;
using MyWebSite.DataAccess.UnitOfWork.Abstract;

namespace MyWebSite.Business.Concrete.GenericService;

public class GenericService :ManagerBaseWebSite, IGenericService
{
    public GenericService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    private MyAboutService _aboutService;
    private EductionService _educationService;
    private ExperienceService _experienceService;
    private JobDescriptionService _jobDescriptionService;
    private HobbyService _hobbyService;
    private ProjectService _projectService;
    private SertificateService _sertificateService;
    private SkillService _skillService;
    private ContactService _contactService;
    public IMyAboutService MyAboutService => _aboutService ??= new MyAboutService(_unitOfWork);

    public IEducationService EducationService => _educationService ??= new EductionService(_unitOfWork);

    public IExperienceService ExperienceService => _experienceService ??= new ExperienceService(_unitOfWork);

    public IJobDescriptionService JobDescriptionService => _jobDescriptionService ??= new JobDescriptionService(_unitOfWork);

    public IHobbyService HobbyService => _hobbyService ??= new HobbyService(_unitOfWork);

    public IProjectService ProjectService => _projectService ??= new ProjectService(_unitOfWork);

    public ISertificateService SertificateService => _sertificateService ??= new SertificateService(_unitOfWork);

    public ISkillService SkillService => _skillService ??= new SkillService(_unitOfWork);

    public IContactService ContactService => _contactService ??= new ContactService(_unitOfWork);
}
