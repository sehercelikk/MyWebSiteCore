using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Education : IEntity
{
    public int Id { get; set; }
    public string SchoolName { get; set; }
    public string Department { get; set; }
    public string Tarih { get; set; }
}
