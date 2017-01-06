using MVCAjax.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCAjax.Controllers
{
    public class GalleryController : Controller
    {
        public static List<Photo> photos = new List<Photo>();
        // GET: Gallery
        public GalleryController()
        {
            if (!photos.Any())
            {

                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Skimboard.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding on the ocean" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SkimboardThree.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Skimboarding of three" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "SunsetSurf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing in the sunset" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "surf.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Surfing on the ocean" } } });
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = "Water.jpg", PhotoComment = new List<Comments> { new Comments { CommentOnPicture = "Fine ocean" } } });
            }
        }
        public ActionResult Index()
        {
            return View(photos);
        }
        public ActionResult IndexPartial()
        {
            return PartialView("Index", photos);
        }
        public ActionResult AddComment(Guid id)
        {
            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            return PartialView("AddComment", p);
        }
        [HttpPost]
        public ActionResult AddComment(Guid id, string photoComment)
        {
            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            p.PhotoComment.Add(new Comments { CommentOnPicture = photoComment });
            return PartialView("Index", photos);
        }
        public ActionResult ShowImage(Guid id)
        {
            var showphoto = photos.FirstOrDefault(x => x.PhotoID == id);
            return PartialView(showphoto);
        }

        [HttpPost]
        public ActionResult DeletePicture(Guid id, Photo photo)
        {

            var p = photos.FirstOrDefault(x => x.PhotoID == id);
            string fullPath = Request.MapPath("~/Image/" + p.PhotoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
                photos.Remove(p);
            }
            return RedirectToAction("Index", photos);
        }
        public ActionResult UploadPicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(string comment, HttpPostedFileBase[] files, Photo photo)
        {
            Thread.Sleep(3000);
            if (!ModelState.IsValid)
            {
                return View(photo);
            }
            if (files == null)
            {
                ModelState.AddModelError("error", "Ingen Bild!");
                return View(photo);
            }
            foreach (var file in files)
            {
                file.SaveAs(
                Path.Combine(Server.MapPath("~/Image"), file.FileName));
                photos.Add(new Photo { PhotoID = Guid.NewGuid(), PhotoName = file.FileName, PhotoComment = new List<Comments> { new Comments { CommentOnPicture = comment } } });
            }

            return PartialView("Index", photos);
        }
    }
}