using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Sertificate : IEntity
{
    public int Id { get; set; }
    public string SertificateName { get; set; }
    public string Company { get; set; }
    public string Tarih { get; set; }
}
