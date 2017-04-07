using DAL.Interface.Repository;
using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.Repository
{
    public interface IAlbumRepository : IRepository<DalAlbum>
    {
        IEnumerable<DalAlbum> GetByUserId(int key);
        bool IsExistAlbum(string name);
    }
}
