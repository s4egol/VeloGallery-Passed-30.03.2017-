using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IAlbumService
    {
        List<AlbumEntity> GetAll();
        AlbumEntity GetById();
        List<AlbumEntity> GetByUserId(int key);
        void Create(AlbumEntity album);
        void Delete(AlbumEntity album);
        void Update(AlbumEntity album);
        bool IsExistAlbum(string name);
    }
}
