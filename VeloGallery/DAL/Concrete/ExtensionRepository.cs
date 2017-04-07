﻿using DAL.Interfacies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using System.Data.Entity;
using ORM;

namespace DAL.Concrete
{
    public class ExtensionRepository : IExtensionRepository
    {
        private readonly DbContext context;

        public ExtensionRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalExtension e)
        {
            context.Set<Extension>().Add(new Extension()
            {
                Name = e.Name
            });
        }

        public void Delete(DalExtension e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalExtension> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalExtension GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalExtension GetByName(string key)
        {
            var extension = context.Set<Extension>().FirstOrDefault(ex => ex.Name == key);
            return extension == null ? null : new DalExtension()
            {
                Id = extension.Id,
                Name = extension.Name
            };
        }

        public void Update(DalExtension e)
        {
            throw new NotImplementedException();
        }
    }
}
