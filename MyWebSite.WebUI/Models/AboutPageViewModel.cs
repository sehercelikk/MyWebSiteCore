using MyWebSite.Entities.Concrete;

namespace MyWebSite.WebUI.Models;

public class AboutPageViewModel
{
    public List<MyAbout> Abouts { get; set; }
    public List<JobDescription> JobDescriptions { get; set; }
}