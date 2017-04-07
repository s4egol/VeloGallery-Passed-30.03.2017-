using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IExtensionService
    {
        List<ExtensionEntity> GetAll();
        ExtensionEntity GetById();
        ExtensionEntity GetByName(string key);
        void Create(ExtensionEntity extension);
        void Delete(ExtensionEntity extension);
    }
}
