﻿using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalExtension : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
