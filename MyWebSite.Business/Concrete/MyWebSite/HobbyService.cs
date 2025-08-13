using Microsoft.AspNetCore.Http;
using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Abstract;
using MyWebSite.Entities.Concrete;

namespace MyWebSite.Business.Concrete.MyWebSite
{
    public class HobbyService : ManagerBaseWebSite, IHobbyService
    {
        public HobbyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> AddHobby(Hobby hobby, IFormFile imageFile)
        {
            if(imageFile != null || imageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hobbies");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                hobby.ImageUrl = "/images/hobbies/" + fileName;
            }

            await _unitOfWork.HobbyDal.AddAsync(hobby);
            await _unitOfWork.SaveAsync();
            return "Hobby added successfully.";
        }

        public async Task<string> DeleteHobby(int id)
        {
            var entity= await _unitOfWork.HobbyDal.GetByIdAsync(id);
            await _unitOfWork.HobbyDal.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
            return "Hobby deleted successfully.";
        }

        public async Task<List<Hobby>> GetAllAsync()
        {
            var result = await _unitOfWork.HobbyDal.GetAllAsync();
            return result;
        }

        public Task<Hobby> GetByIdAsync(int id)
        {
            var result = _unitOfWork.HobbyDal.GetByIdAsync(id);
            return result;
        }

        public async Task<string> UpdateHobby(Hobby hobby, IFormFile imageFile)
        {
            var entity= await _unitOfWork.HobbyDal.GetByIdAsync(hobby.Id);
            if (entity == null)
                return "Hobby not found.";
            entity.Name = hobby.Name;
            entity.Description = hobby.Description;
            if(imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "hobbies");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                entity.ImageUrl = "/images/hobbies/" + fileName;

            }
            
            await _unitOfWork.HobbyDal.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
            return "Hobby updated successfully.";
        }
    }
}
