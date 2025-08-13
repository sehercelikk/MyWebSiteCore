using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Business.Abstract.IGeneric;
using MyWebSite.Business.Concrete.GenericService;
using MyWebSite.DataAccess.UnitOfWork.Abstract;
using MyWebSite.DataAccess.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.IoC;

public  static class CustomIoCExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGenericService, GenericService>();
    }

}
