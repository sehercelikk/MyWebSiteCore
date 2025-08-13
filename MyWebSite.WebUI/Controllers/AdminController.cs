using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Business.Abstract.IGeneric;
using MyWebSite.Entities.Concrete;
using MyWebSite.WebUI.Models;

namespace MyWebSite.WebUI.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IGenericService _genericService;
    private readonly UserManager<Admin> _userManager;
    private readonly SignInManager<Admin> _signInManager;

    public AdminController(IGenericService genericService, UserManager<Admin> userManager, SignInManager<Admin> signInManager)
    {
        _genericService = genericService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(string userName,string password,string role)
    {
        var user = new Admin
        {
            UserName = userName,
            Role = role
        };
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View();


    }

    #region Hakkımda İşlemleri
    public async Task<IActionResult> Index()
    {
        var result = await _genericService.MyAboutService.GetAllAsync();
        if (result == null)
        {
            return NotFound("Kullanıcı bilgileri bulunamadı");
        }
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        var result = await _genericService.MyAboutService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAbout(MyAbout model, IFormFile imageFile)
    {
        var result = await _genericService.MyAboutService.UpdateMyAbout(model, imageFile);
        return RedirectToAction("Index");
    }

    #endregion


    #region  Eğitim İşlemleri

    public async Task<IActionResult> Education()
    {
        var result = await _genericService.EducationService.GetAllAsync();
        if (result == null)
        {
            TempData["Message"] = "Gösterilecek Eğitim bilgisi yok";
        }
        return View(result);
    }


    public async Task<IActionResult> DeleteEducation(int id)
    {
        var findId = await _genericService.EducationService.DeleteEducation(id);
        if (findId == null)
            TempData["Message"] = "Silme işlemi başarısız.";
        return RedirectToAction("Education");

    }

    [HttpGet]
    public async Task<IActionResult> UpdateEducation(int id)
    {
        var result = await _genericService.EducationService.GetByIdAsync(id);
        if (result == null)
        {
            TempData["Message"] = "Eğitim bilgisi bulunamadı.";
            return RedirectToAction("Education");
        }
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEducation(Education model)
    {
        var result = await _genericService.EducationService.UpdateEducation(model);
        return RedirectToAction("Education");
    }


    [HttpGet]
    public async Task<IActionResult> AddEducation() => View();

    [HttpPost]
    public async Task<IActionResult> AddEducation(Education model)
    {
        var result = await _genericService.EducationService.AddEducation(model);
        if (result == null)
        {
            TempData["Message"] = "Eğitim bilgisi eklenemedi.";
            return View();
        }
        return RedirectToAction("Education");
    }

    #endregion


    #region Deneyim İşlemleri

    public async Task<IActionResult> Experience()
    {
        var value = await _genericService.ExperienceService.GetAllAsync();
        if (value == null)
        {
            TempData["Message"] = "Gösterilecek Deneyim bilgisi yok";
        }
        return View(value);
    }

    [HttpGet]
    public async Task<IActionResult> AddExperience() => View();

    [HttpPost]
    public async Task<IActionResult> AddExperience(Experience model)
    {
        var result = await _genericService.ExperienceService.AddEducation(model);
        return RedirectToAction("Experience");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateExperience(int id)
    {
        var result = await _genericService.ExperienceService.GetByIdAsync(id);
        if (result == null)
        {
            TempData["Message"] = "Deneyim bilgisi bulunamadı.";
            return RedirectToAction("Experience");
        }
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateExperience(Experience model)
    {
        var result = await _genericService.ExperienceService.UpdateEducation(model);
        return RedirectToAction("Experience");
    }


    [HttpGet]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var result = await _genericService.ExperienceService.DeleteEducation(id);
        if (result == null)
        {
            TempData["Message"] = "Silme işlemi başarısız.";
        }
        return RedirectToAction("Experience");
    }
    #endregion

    #region Görev Tanım İşlemleri
    public async Task<IActionResult> JobDescription()
    {
        var result = await _genericService.JobDescriptionService.GetAllAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddJobDescription() => View();

    [HttpPost]
    public async Task<IActionResult> AddJobDescription(JobDescription model)
    {
        await _genericService.JobDescriptionService.AddEducation(model);
        return RedirectToAction("JobDescription");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateJobDescription(int id)
    {
        var findId= await _genericService.JobDescriptionService.GetByIdAsync(id);
        return View(findId);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateJobDescription(JobDescription model)
    {
        await _genericService.JobDescriptionService.UpdateEducation(model);
        return RedirectToAction("JobDescription");
    }

    public async Task<IActionResult> DeleteJobDescription(int id)
    {
        await _genericService.JobDescriptionService.DeleteEducation(id);
        return RedirectToAction("JobDescription");
    }

    #endregion

    #region Hobi İşlemleri
    public async Task<IActionResult> Hobby()
    {
        var result = await _genericService.HobbyService.GetAllAsync();
        return View(result);
    }

    public async Task<IActionResult> AddHobby()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddHobby(Hobby hobby, IFormFile imageFile)
    {
        await _genericService.HobbyService.AddHobby(hobby, imageFile);
        return RedirectToAction("Hobby");
    }

    public async Task<IActionResult> UpdateHobby(int id)
    {
        var findEntity=await _genericService.HobbyService.GetByIdAsync(id);
        return View(findEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateHobby(Hobby hobby,IFormFile imageFile )
    {
        await _genericService.HobbyService.UpdateHobby(hobby,imageFile);
        return RedirectToAction("Hobby");
    }
    public async Task<IActionResult> DeleteHobby(int id)
    {
        await _genericService.HobbyService.DeleteHobby(id);
        return RedirectToAction("Hobby");
    }

    #endregion

    #region Proje İşlemleri
    public async Task<IActionResult> Project()
    {
        var result = await _genericService.ProjectService.GetAllAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddProject()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProject(Project model)
    {
        await _genericService.ProjectService.AddProject(model);
        return RedirectToAction("Project");
    }


    [HttpGet]
    public async Task<IActionResult> UpdateProject(int id)
    {
        var findId= await _genericService.ProjectService.GetByIdAsync(id);
        return View(findId);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProject(Project model)
    {
        await _genericService.ProjectService.UpdateProject(model);
        return RedirectToAction("Project");
    }
    public async Task<IActionResult> DeleteProject(int id)
    {
        await _genericService.ProjectService.DeleteProject(id);
        return RedirectToAction("Project");
    }

    #endregion

    #region Sertifika İşlemleri
    public async Task<IActionResult> Sertificate()
    {
        var result = await _genericService.SertificateService.GetAllAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> AddSertificate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSertificate(Sertificate model)
    {
        await _genericService.SertificateService.AddSertificate(model);
        return RedirectToAction("Sertificate");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSertificate(int id)
    {
        var result= await _genericService.SertificateService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSertificate(Sertificate model)
    {
        await _genericService.SertificateService.UpdateSertificate(model);
        return RedirectToAction("Sertificate");
    }

    public async Task<IActionResult> DeleteSertificate(int id)
    {
        await _genericService.SertificateService.DeleteSertificate(id);
        return RedirectToAction("Sertificate");
    }

    #endregion

    #region Beceri İşlemleri
    public async Task<IActionResult> Skill()
    {
        var result = await _genericService.SkillService.GetAllAsync();
        return View(result);
    }

    public async Task<IActionResult> AddSkill()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddSkill(Skill model)
    {
        await _genericService.SkillService.AddAsync(model);
        return RedirectToAction("Skill");
    }
    public async Task<IActionResult> UpdateSkill(int id)
    {
        var findId = await _genericService.SkillService.GetByIdAsync(id);
        return View(findId);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSkill(Skill model)
    {
        await _genericService.SkillService.UpdateAsync(model);
        return RedirectToAction("Skill");
    }
    public async Task<IActionResult> DeleteSkill(int id)
    {
        await _genericService.SkillService.DeleteAsync(id);
        return RedirectToAction("Skill");
    }

    #endregion

    #region İletişim İşlemleri
    public async Task<IActionResult> Contact()
    {
        var result = await _genericService.ContactService.GetAllAsync(); 
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateContact(int id)
    {
        var result = await _genericService.ContactService.GetByIdAsync(id);
        return View(result);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateContact(Contact model)
    {
        var result = await _genericService.ContactService.UpdateMyContact(model);
        return RedirectToAction("Contact");
    }


    #endregion

    #region Ayarlar İşlemleri
    public async Task<IActionResult> Settings()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Settings(ResetPasswordViewModel model) //Password Change
    {
        if(!ModelState.IsValid)
        {
            ViewBag.Message = "Şifre Bilgileri Yanlış";
            ViewBag.V = "alert alert-danger";
            return View(model);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Index","Login");
        }
        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if(result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user);
            ViewBag.Message = "Şifre Güncelleme İşlemi Başarılı";
            ViewBag.V = "alert alert-success";
            return View(model);
        }
        ViewBag.Message = "Şifre Güncellenirken bir hata oluştu";
        ViewBag.V = "alert alert-danger";
        return View(model);
    }


    #endregion
}
