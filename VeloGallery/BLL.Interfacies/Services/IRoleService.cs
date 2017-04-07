using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        List<RoleEntity> GetAll();
        RoleEntity GetById(int toleId);
    }
}
