using MyWebSite.DataAccess.Abstract;
using MyWebSite.DataAccess.Concrete;
using MyWebSite.DataAccess.Context;
using MyWebSite.DataAccess.UnitOfWork.Abstract;

namespace MyWebSite.DataAccess.UnitOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    private EfMyAboutRepository? _efMyAboutRepo;
    private EfEducationRepository? _efEducationRepo;
    private EfExperienceRepository? _efExperienceRepo;
    private EfJobDescriptionRepository? _efJobDescriptionRepository;
    private EfHobbyRepository? _efHobbyRepository;
    private EfContactRepository? _efContactRepository;
    private EfProjectRepository? _efProjectRepository;
    private EfSertificateRepository? _efSertificateRepository;
    private EfSkillRepository? _efSkillRepository;

    public IMyAboutDal MyAboutDal => _efMyAboutRepo ??= new EfMyAboutRepository(_context);
    public IEducationDal EducationDal => _efEducationRepo ??= new EfEducationRepository(_context);
    public IExperienceDal ExperienceDal => _efExperienceRepo ??= new EfExperienceRepository(_context);
    public IJobDescriptionDal JobDescriptionDal =>_efJobDescriptionRepository ??= new EfJobDescriptionRepository(_context);

    public IHobbyDal HobbyDal => _efHobbyRepository ??= new EfHobbyRepository(_context);

    public IContactDal ContactDal => _efContactRepository ??= new EfContactRepository(_context);

    public IProjectDal ProjectDal => _efProjectRepository ??= new EfProjectRepository(_context);

    public ISertificateDal SertificateDal => _efSertificateRepository ??= new EfSertificateRepository(_context);

    public ISkillDal SkillDal => _efSkillRepository ??= new EfSkillRepository(_context);

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    async Task<int> IUnitOfWork.SaveAsync() => await _context.SaveChangesAsync();
}
