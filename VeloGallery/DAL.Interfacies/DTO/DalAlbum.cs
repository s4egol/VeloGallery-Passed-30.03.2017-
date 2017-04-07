using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.DTO
{
    public class DalAlbum : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }


        public DalUser User { get; set; }
        public List<DalImage> Images { get; set; }
    }
}
