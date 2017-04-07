using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using DAL.Interface.Repository;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork uow;

        public AlbumService(IAlbumRepository albumRepository, IUnitOfWork uow)
        {
            this.albumRepository = albumRepository;
            this.uow = uow;
        }

        public void Create(AlbumEntity album)
        {
            albumRepository.Create(new DalAlbum()
            {
                Name = album.Name,
                UserId = album.UserId,
                CreationDate = album.CreationDate
            });
            uow.Commit();
        }

        public void Delete(AlbumEntity album)
        {
            throw new NotImplementedException();
        }

        public List<AlbumEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public AlbumEntity GetById()
        {
            throw new NotImplementedException();
        }

        public List<AlbumEntity> GetByUserId(int key)
        {
            return albumRepository.GetByUserId(key).Select(album => new AlbumEntity()
            {
                Id = album.Id,
                Name = album.Name,
                CreationDate = album.CreationDate,
                UserId = album.UserId
            }).ToList();
        }

        public bool IsExistAlbum(string name)
        {
            return albumRepository.IsExistAlbum(name);
        }

        public void Update(AlbumEntity album)
        {
            throw new NotImplementedException();
        }
    }
}
