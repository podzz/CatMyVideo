﻿using CatMyVideo.Models;
using Storage.Video;
using Storage.WCF;
using Storage.WCF.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatMyVideo.Controllers
{
    public class UploadController : Controller
    {
        #region init
        private ApplicationUserManager _userManager;

        public UploadController()
        {
        }

        public UploadController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion

        // GET : Index
        [HttpGet]
        public ActionResult Index()
        {
            string ListFormats = "";
            FormatChecker.GetFormats().ForEach(x => ListFormats += "." + x + ",");
            ViewData["Format"] = ListFormats.Substring(0, ListFormats.Length - 2);
            return View();
        }

        // POST: Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UploadViewModel model)
        {
            if (ModelState.IsValid && model.File != null)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                string fileExtension = Path.GetExtension(model.File.FileName).Substring(1);
                try
                {
                    RemoteFileInfo fileInfo = new RemoteFileInfo();
                    fileInfo.Stream = model.File.InputStream;
                    fileInfo.InputFormat = fileExtension;

                    Engine.Dbo.Video video = new Engine.Dbo.Video()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        User = user.T_UserId,
                    };

                    fileInfo.IdVideo = Engine.BusinessManagement.Video.AddVideo(video);

                    ClientManager.UploadVideo(fileInfo);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    return RedirectToAction("Index", "Upload");
                }
                return RedirectToAction("Index", "Home");
            }

            return View("Index", model);
        }
    }
}