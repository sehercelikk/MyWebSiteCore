using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Entities.Concrete;

public class Skill : IEntity
{
    public int Id { get; set; }
    public string SkillName { get; set; }
    public int WhatPercentage { get; set; }
    public string Description { get; set; }
}
