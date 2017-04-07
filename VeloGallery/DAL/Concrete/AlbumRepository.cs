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
    public class AlbumRepository : IAlbumRepository
    {

        private readonly DbContext context;

        public AlbumRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalAlbum e)
        {
            var album = new Album()
            {
                Name = e.Name,
                CreationDate = e.CreationDate,
                UserId = e.UserId
            };
            context.Set<Album>().Add(album);
        }

        public void Delete(DalAlbum e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAlbum> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalAlbum GetById(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAlbum> GetByUserId(int key)
        {
            return context.Set<Album>().Where(a => a.UserId == key).Select(album => new DalAlbum()
            {
                Id = album.Id,
                Name = album.Name,
                CreationDate = album.CreationDate.Value,
                UserId = album.UserId
            });
        }

        public bool IsExistAlbum(string name)
        {
            var album = context.Set<Album>().FirstOrDefault(x => x.Name == name);
            if (album != null)
                return true;
            return false;
        }

        public void Update(DalAlbum e)
        {
            throw new NotImplementedException();
        }
    }
}
