using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public void Create(UserEntity user)
        {
            userRepository.Create(new DalUser()
            {
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId
            });
            uow.Commit();
        }

        public void Delete(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetByEmail(string email)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            return user == null ? null : new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
                Role = new RoleEntity()
                {
                    Id = user.RoleId,
                    Name = user.Role.Name
                }
            };
        }

        public UserEntity GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
