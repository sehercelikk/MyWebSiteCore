using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class JobDescription : IEntity
{
    public int Id { get; set; }
    public string JobTitle { get; set; }
}
