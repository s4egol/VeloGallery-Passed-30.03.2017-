using DAL.Interfacies.Repository;
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
    public class ImageRepository : IImageRepository
    {
        private readonly DbContext context;

        public ImageRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalImage e)
        {
            context.Set<Image>().Add(new Image()
            {
                Name = e.Name,
                Description = e.Description,
                AlbumId = e.AlbumId,
                ExtensionId = e.ExtensionId,
                IsTradable = e.IsTradable
            });
        }

        public void Delete(DalImage e)
        {
            throw new NotImplementedException();
        }

        public void DeleteByName(string nameImage)
        {
            var image = context.Set<Image>().ToList().FirstOrDefault(x => x.Name == nameImage);
            if (image != null)
                context.Set<Image>().Remove(image);
        }

        public IEnumerable<DalImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalImage> GetByAlbumId(int key)
        {
            return context.Set<Image>().Where(image => image.AlbumId == key).Select(image => new DalImage()
            {
                Name = image.Name,
                Description = image.Description,
                AlbumId = image.AlbumId.Value,
                ExtensionId = image.ExtensionId.Value,
                IsTradable = image.IsTradable
            });
        }

        public DalImage GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(DalImage e)
        {
            throw new NotImplementedException();
        }
    }
}
