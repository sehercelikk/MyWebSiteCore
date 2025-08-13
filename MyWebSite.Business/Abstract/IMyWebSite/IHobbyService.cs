using Microsoft.AspNetCore.Http;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Abstract.IMyWebSite
{
    public interface IHobbyService
    {
        Task<List<Hobby>> GetAllAsync();
        Task<Hobby> GetByIdAsync(int id);
        Task<string> AddHobby(Hobby hobby, IFormFile imageFile);
        Task<string> UpdateHobby(Hobby hobby,IFormFile imageFile);
        Task<string> DeleteHobby(int id);
    }
}
