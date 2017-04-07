using BLL.Interface.Entities;
using BLL.Interfacies.Services;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository repository)
        {
            this.roleRepository = repository;
        }

        public List<RoleEntity> GetAll()
        {
            return roleRepository.GetAll().Select(role => new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name
            }).ToList();
        }

        public RoleEntity GetById(int toleId)
        {
            throw new NotImplementedException();
        }

      
    }
}
