using MyWebSite.Business.Abstract.IMyWebSite;
using MyWebSite.Business.Concrete.ManagerBase;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.Entities.Concrete;

namespace MyWebSite.Business.Concrete.MyWebSite
{
    public class ContactService : ManagerBaseWebSite, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var result= await _unitOfWork.ContactDal.GetAllAsync();
            return result;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            try
            {
                var findId = await _unitOfWork.ContactDal.GetByIdAsync(id);
                return findId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateMyContact(Contact model)
        {
            var entity=await _unitOfWork.ContactDal.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("İletişim bilgileri bulunamadı");
            }
            entity.Address = model.Address;
            entity.Mail = model.Mail;
            entity.Linkedln = model.Linkedln;
            entity.Github = model.Github;

            await _unitOfWork.ContactDal.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
            return "İletişim bilgileri güncellendi";
        }
    }
}
