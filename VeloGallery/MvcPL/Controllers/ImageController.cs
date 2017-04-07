using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Models;
using System.IO;
using BLL.Interfacies.Services;
using BLL.Interfacies.Entities;

namespace MvcPL.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService imageService;
        private readonly IExtensionService extensionService;

        public ImageController(IImageService imageService, IExtensionService extensionService)
        {
            this.imageService = imageService;
            this.extensionService = extensionService;
        }

        public JsonResult GetImagesForAlbum(int albumId)
        {
            var images = imageService.GetByAlbumId(albumId).Select(image => new Image()
            {
                Id = image.Id,
                Name = image.Name,
                Description = image.Description,
                AlbumId = image.AlbumId,
                ExtensionId = image.ExtensionId,
                Url = Path.Combine("\\Content", "img", image.Name)
            });
            return Json(images);
        }

        public JsonResult AddImageAjax(string fileName, string data, string description, int albumId, bool isTradable)
        {
            int index = fileName.LastIndexOf(".", StringComparison.Ordinal);
            string extension;

            if (index != -1)
                extension = fileName.Substring(index + 1);
            else
            {
                fileName += ".jpeg";
                extension = "jpeg";
            }

            var dataIndex = data.IndexOf("base64", StringComparison.Ordinal) + 7;
            var cleareData = data.Substring(dataIndex);
            var fileData = Convert.FromBase64String(cleareData);
            var bytes = fileData.ToArray();

            var path = GetPathToImg(fileName);
            using (var fileStream = System.IO.File.Create(path))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }

            var ex = extensionService.GetByName(extension);
            if (ex == null)
            {
                extensionService.Create(new ExtensionEntity()
                {
                    Name = extension
                });
            }
            imageService.Create(new ImageEntity()
            {
                Name = fileName,
                Description = description,
                ExtensionId = extensionService.GetByName(extension).Id,
                AlbumId = albumId,
                IsTradable = isTradable
            });

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFileAjax(string url)
        {
            string[] val = url.Split(new char[] { '\\' });
            imageService.DeleteByName(val[val.Length - 1]);
            var path = Server.MapPath(url);
            System.IO.File.Delete(path);
            return Json(true);
        }

        private string GetPathToImg(string fileName)
        {
            var serverPath = Server.MapPath("~");
            return Path.Combine(serverPath, "Content", "img", fileName);
        }

        public JsonResult GetImages()
        {
            //var images = imageService.GetAll().Select(i => i.ToMvcImage());
            var serverPath = Server.MapPath("~");
            var pathToImageFolder = Path.Combine(serverPath, "Content", "img");
            var imageFiles = Directory.GetFiles(pathToImageFolder);
            var imges = imageFiles.Select(BuildImage);
            return Json(imges, JsonRequestBehavior.AllowGet);
        }

        private Image BuildImage(string path)
        {
            var fileName = Path.GetFileName(path);
            var image = new Image
            {
                Url = Url.Content("~/Content/img/" + fileName),
                Name = Path.GetFileNameWithoutExtension(path)
            };

            return image;
        }

    }
}
