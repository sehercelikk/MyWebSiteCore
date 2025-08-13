using Microsoft.AspNetCore.Http;
using MyWebSite.Entities.Concrete;

namespace MyWebSite.Business.Abstract.IMyWebSite;

public interface IMyAboutService 
{
    Task<List<MyAbout>> GetAllAsync();
    Task<MyAbout> GetByIdAsync(int id);
    Task<string> UpdateMyAbout(MyAbout myAbout, IFormFile imageFile);
}
