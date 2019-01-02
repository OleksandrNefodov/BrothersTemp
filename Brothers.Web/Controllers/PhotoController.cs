using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Brothers.Common.Models;
using Brothers.Repository.PhotoService;
using BrothersProjects.Extensions;
using System.Web;
using System.Threading.Tasks;
using Brothers.Repository.ServiceMapping;
using Brothers.Repository.ServiceMapping.Entities;
using BrothersProjects.Filters;

namespace BrothersProjects.Controllers
{
    [MyAuth]
    [Authorize]
    public class PhotoController : Controller
    {
        public string GetInfo()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null
                ? ""
                : HttpContext.Request.UrlReferrer.AbsoluteUri;

            bool isAdmin = HttpContext.User.IsInRole("admin");
            bool isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            string userName = HttpContext.User.Identity.Name;
            string authenticationType = HttpContext.User.Identity.AuthenticationType;

            string sessionCoockieId = HttpContext.Request.Cookies["ASP.NET_SessionId"].Value;

            string coockieId = HttpContext.Response.Cookies["id"].Value;

            return "<p>Browser: " + browser + "</p><p>AppUser-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                   "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>" +
                   "<p>Является ли пользователь админом: " + isAdmin + "</p>" +
                   "<p>Авторизирован ли пользователь: " + isAuthenticated + "</p>"
                   + "<p>Имя пользователя: " + HttpContext.Session["username"] + "</p>" + "<p>Тип аутентификации: " +
                   authenticationType + "</p>" + "<p>Session Coockie id: " + sessionCoockieId + "</p>" +
                   "Coockie id: " + coockieId + "</p>";       
        }

        public int Get2Plus2(int a, int b)
        {
            var param = Request.LogonUserIdentity;
            int a_1 = Int32.Parse(Request.Params["a"]);
            int b_1 = Int32.Parse(Request.Params["b"]);

            int result = a_1 + b_1;

            return result;
        }

        // GET: Photo
        public async Task<ActionResult> Photos()
        {
            List<DisplayPhoto> photos = await PhotoService.ListPhotosAsync();

            ViewBag.Photos = photos;

            return View();
        }

        public async Task<ActionResult> DeleteAsync(int id)
        {
            bool removed = await PhotoService.DeleteAsync(id);

            return RedirectToAction("Photos");
        }

        public async Task<ActionResult> AddAndEdit()
        {
            List<Album> albums = await AlbumService.ListAlbumsAsync();

            DisplayPhoto photo = TempData["photo"] as DisplayPhoto;

            photo = photo ?? new DisplayPhoto();

            IEnumerable<SelectListItem> albumNames = albums.Select(album => new SelectListItem()
            {
                Text = album.Name,
                Value = album.Id.ToString()
            }).ToList();

            ViewBag.Albums = albumNames;

            IEnumerable<SelectListItem> photoTypes = CollectionExtensions.GetEnumSelectList<ContentType>();

            ViewBag.ContentTypes = photoTypes;

            return View(photo);
        }

        [HttpPost]
        public async Task<ActionResult> Add(DisplayPhoto displayPhoto, HttpPostedFileBase file)
        {
            if (file != null)
            {
                displayPhoto.RawData = new byte[file.ContentLength];

                file.InputStream.Read(displayPhoto.RawData, 0, file.ContentLength);
            }

            Photo photo = new Photo
            {
                Id = displayPhoto.Identifier,
                Name = displayPhoto.Name,
                Type = displayPhoto.Type,
                AlbumId = displayPhoto.AlbumId,
                Size = displayPhoto.Size,
                RawData = displayPhoto.RawData
            };

            await PhotoService.AddAsync(photo);

            return RedirectPermanent("Photos");
        }

        public async Task<ActionResult> GetAsync(int id)
        {
            var photo = await PhotoService.GetAsync(id);

            var displayPhoto = new DisplayPhoto(photo);

            TempData["photo"] = displayPhoto;

            return RedirectToAction("AddAndEdit");
        }

        public FileResult DownloadImage(Photo photo, string location)
        {
            byte[] image = photo.RawData;

            FileContentResult contentResult = File(image, "img/png", photo.Name + ".png");

            if (!string.IsNullOrEmpty(location))
            {
                FilePathResult pathResult = File(location, "plain/text", "fileName");

                return pathResult;
            }

            return contentResult;
        }
    }
}