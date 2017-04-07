using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IImageService
    {
        List<ImageEntity> GetAll();
        ImageEntity GetById();
        List<ImageEntity> GetByAlbumId(int key);
        void Create(ImageEntity image);
        void Delete(ImageEntity image);
        void DeleteByName(string imageName);
        void Update(ImageEntity image);
    }
}
