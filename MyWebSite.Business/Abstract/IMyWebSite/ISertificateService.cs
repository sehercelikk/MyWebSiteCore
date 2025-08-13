using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite
{
    public interface ISertificateService
    {
        Task<List<Sertificate>> GetAllAsync();
        Task<Sertificate> GetByIdAsync(int id);
        Task<string> AddSertificate(Sertificate sertificate);
        Task<string> DeleteSertificate(int id);
        Task<string> UpdateSertificate(Sertificate sertificate);
    }
}
