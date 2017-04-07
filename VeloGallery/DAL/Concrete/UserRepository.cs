using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = new DalRole()
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name
                }
            });
        }

        public DalUser GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Email = e.Email,
                Password = e.Password,
                RoleId = e.RoleId
            };
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}