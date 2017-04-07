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
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IUnitOfWork uow;

        public ImageService(IImageRepository imageRepository, IUnitOfWork uow)
        {
            this.imageRepository = imageRepository;
            this.uow = uow;
        }

        public void Create(ImageEntity image)
        {
            imageRepository.Create(new DalImage()
            {
                Name = image.Name,
                Description = image.Description,
                AlbumId = image.AlbumId,
                ExtensionId = image.ExtensionId,
                IsTradable = image.IsTradable
            });
            uow.Commit();
        }

        public void Delete(ImageEntity image)
        {
            imageRepository.Delete(new DalImage()
            {
                Id = image.Id
            });

            uow.Commit();
        }

        public void DeleteByName(string imageName)
        {
            imageRepository.DeleteByName(imageName);
            uow.Commit();
        }

        public List<ImageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ImageEntity> GetByAlbumId(int key)
        {
            var images = imageRepository.GetByAlbumId(key);
            return images?.Select(image => new ImageEntity()
            {
                Name = image.Name,
                Description = image.Description,
                AlbumId = image.AlbumId,
                ExtensionId = image.ExtensionId,
                IsTradable = image.IsTradable
            }).ToList();
        }

        public ImageEntity GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(ImageEntity image)
        {
            throw new NotImplementedException();
        }
    }
}
