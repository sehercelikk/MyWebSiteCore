using MyWebSite.DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Business.Concrete.ManagerBase;

public class ManagerBaseWebSite
{
    private IUnitOfWork unitOfWork;

    public IUnitOfWork _unitOfWork { get; }

    public ManagerBaseWebSite(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
