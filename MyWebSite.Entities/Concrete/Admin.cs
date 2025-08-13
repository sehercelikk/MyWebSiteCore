using Microsoft.AspNetCore.Identity;
using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Admin : IdentityUser, IEntity
{
    public string Role { get; set; }
}
