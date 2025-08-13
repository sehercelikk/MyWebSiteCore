using System.ComponentModel.DataAnnotations;

namespace MyWebSite.WebUI.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Ad Soyad gerekli")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email gerekli")]
    [EmailAddress(ErrorMessage = "Geçerli bir email girin")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Konu gerekli")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "Mesaj gerekli")]
    public string Message { get; set; }
}
