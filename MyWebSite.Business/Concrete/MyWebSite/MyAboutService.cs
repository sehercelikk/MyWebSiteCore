using Microsoft.AspNetCore.Http;
using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Concrete;

namespace MyWebSite.Business.Concrete.MyWebSite;

public class MyAboutService : ManagerBaseWebSite, IMyAboutService
{
    public MyAboutService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<List<MyAbout>> GetAllAsync()
    {
        var message = "";
        try
        {
            var result = await _unitOfWork.MyAboutDal.GetAllAsync();
            return result;

        }
        catch (Exception ex)
        {
            message = "Kullanıcı bilgileri alınırken bir hata oluştu";
            throw new Exception(message, ex);
        }

    }

    public async Task<MyAbout> GetByIdAsync(int id)
    {
        var message = "";
        try
        {
            var result = await _unitOfWork.MyAboutDal.GetByIdAsync(id);
            if (result == null)
            {
                message = "Kullanıcı bilgileri bulunamadı";
                throw new Exception(message);
            }
            return result;
        }
        catch (Exception ex)
        {
            message = "Kullanıcı bilgileri alınırken bir hata oluştu";
            throw new Exception(message, ex);
        }
    }

    public async Task<string> UpdateMyAbout(MyAbout myAbout, IFormFile imageFile)
    {
        try
        {
            var entity = await _unitOfWork.MyAboutDal.GetByIdAsync(myAbout.Id);
            if (entity == null)
                throw new Exception("Kullanıcı bulunamadı");

            entity.Title = myAbout.Title;
            entity.Name = myAbout.Name;
            entity.Surname = myAbout.Surname;
            entity.Description = myAbout.Description;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "about");
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

                entity.ImageUrl = "/images/about/" + fileName;

            }

            await _unitOfWork.MyAboutDal.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
            var message = "Kullanıcı bilgileri başarıyla güncellendi";
            return message;
        }
        catch (Exception)
        {
            throw new Exception("Kullanıcı bilgileri güncellenirken bir hata oluştu");
        }
    }
}
