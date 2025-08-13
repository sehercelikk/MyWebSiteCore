using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Contact : IEntity
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Mail { get; set; }
    public string Linkedln { get; set; }
    public string Github { get; set; }
}
