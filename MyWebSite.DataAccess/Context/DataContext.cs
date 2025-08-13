using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.DataAccess.Context;

public class DataContext : IdentityDbContext<Admin>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
 
    public DbSet<MyAbout> MyAbouts { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<JobDescription> JobDescriptions { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Sertificate> Sertificates { get; set; }
    public DbSet<Skill> Skills { get; set; }
}
