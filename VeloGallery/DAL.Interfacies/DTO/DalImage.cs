using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalImage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AlbumId { get; set; }
        public int ExtensionId { get; set; }
        public bool IsTradable { get; set; }


        public DalExtension Extension { get; set; }
        public DalAlbum Album { get; set; }
    }
}
