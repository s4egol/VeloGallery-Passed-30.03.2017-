using DAL.Interfacies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Data.Entity;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public DalRole GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole e)
        {
            throw new NotImplementedException();
        }
    }
}
