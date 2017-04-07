using BLL.Interface.Services;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;

        public AlbumController(IAlbumService albumService, IUserService userService)
        {
            this.albumService = albumService;
            this.userService = userService;
        }

        public JsonResult CreateAlbum(string albumName, string userEmail)
        {
            if (albumService.IsExistAlbum(albumName))
                return Json(false);
            var user = userService.GetByEmail(userEmail);
            albumService.Create(new AlbumEntity()
            {
                Name = albumName,
                UserId = user.Id,
                CreationDate = DateTime.Now
            });

            return Json(true);
        }

        public JsonResult GetAlbums(int id)
        {
            var albums = albumService.GetByUserId(id);
            ArrayList list = new ArrayList();
            if (albums.Count != 0)
                albums.ToList().ForEach(x => list.Add(new { id = x.Id, name = x.Name }));

            return Json(list);
        }

    }
}
