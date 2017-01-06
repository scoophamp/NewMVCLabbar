using MVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAjax.Controllers
{
    public class AlbumController : Controller
    {
        public static List<Album> albums = new List<Album>();
        // GET: Album
        public AlbumController()
        {
            if (!albums.Any())
            {
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "CheeseCollection", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Bahh" } } });
                albums.Add(new Album { AlbumID = Guid.NewGuid(), AlbumName = "Yupcheesy", Photos = new List<Photo>(), AlbumComment = new List<Comments> { new Comments { CommentOnAlbum = "Photos of cheese" } } });
            }

        }
        public ActionResult Index()
        {
            return View(albums);
        }
        public ActionResult ShowAlbum(Guid id)
        {
            var showalbum = albums.FirstOrDefault(x => x.AlbumID == id);
            return PartialView("ShowAlbum", showalbum);
        }
        public ActionResult AddComment(Guid id)
        {
            var p = albums.FirstOrDefault(x => x.AlbumID == id);
            return PartialView("AddComment", p);
        }
        [HttpPost]
        public ActionResult AddComment(Guid id, string albumComment)
        {
            var p = albums.FirstOrDefault(x => x.AlbumID == id);
            p.AlbumComment.Add(new Comments { CommentOnAlbum = albumComment });
            return PartialView("Index", albums);
        }
        public ActionResult AddPhotoToAlbum()
        {
            var model = new ViewAlbumPhoto();
            model.Photos = GalleryController.photos;
            model.Albums = AlbumController.albums;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPhotoToAlbum(IEnumerable<Guid> photos, Guid albumID)
        {
            var album = albums.FirstOrDefault(x => x.AlbumID == albumID);
            foreach (var item in photos)
            {
                album.Photos.Add(GalleryController.photos.FirstOrDefault(x => x.PhotoID == item));
            }
            return Content("OK!");
        }
    }
}