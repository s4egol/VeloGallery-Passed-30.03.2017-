using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExtensionId { get; set; }
        public int AlbumId { get; set; }
        public bool IsTradable { get; set; }
        public AlbumEntity Album { get; set; }
    }
}
