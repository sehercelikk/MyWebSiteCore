using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Experience: IEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tarih { get; set; }
}
