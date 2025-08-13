using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite;

public interface IJobDescriptionService
{
    Task<List<JobDescription>> GetAllAsync();
    Task<JobDescription> GetByIdAsync(int id);
    Task<string> AddEducation(JobDescription education);
    Task<string> DeleteEducation(int id);
    Task<string> UpdateEducation(JobDescription education);
}
