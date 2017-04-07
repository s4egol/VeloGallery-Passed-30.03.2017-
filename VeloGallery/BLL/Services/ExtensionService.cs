using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;
using DAL.Interfacies.DTO;

namespace BLL.Services
{
    public class ExtensionService : IExtensionService
    {
        private readonly IExtensionRepository extensionRepository;
        private readonly IUnitOfWork uow;

        public ExtensionService(IExtensionRepository extensionRepository, IUnitOfWork uow)
        {
            this.extensionRepository = extensionRepository;
            this.uow = uow;
        }

        public void Create(ExtensionEntity extension)
        {
            extensionRepository.Create(new DalExtension()
            {
                Name = extension.Name
            });
            uow.Commit();
        }

        public void Delete(ExtensionEntity extension)
        {
            throw new NotImplementedException();
        }

        public List<ExtensionEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExtensionEntity GetById()
        {
            throw new NotImplementedException();
        }

        public ExtensionEntity GetByName(string key)
        {
            var extension = extensionRepository.GetByName(key);
            return extension == null ? null : new ExtensionEntity()
            {
                Id = extension.Id,
                Name = extension.Name
            };
        }
    }
}
