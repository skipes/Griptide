using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using griptide.Domain.Abstract;
using griptide.Models;
using griptide.Domain.Entities;
using System.IO;

namespace griptide.Controllers
{
    public class GraphicsController : Controller
    {
        private IEntryRepository entryRepository;
        private IMenuItemRepository menuRepository;
        private IPostRepository postRepository;

        public GraphicsController(IEntryRepository entryRepos, IMenuItemRepository menuRepos, IPostRepository postRepos)
        {
            entryRepository = entryRepos;
            menuRepository = menuRepos;
            postRepository = postRepos;

        }

        public ViewResult Index(int? postID)
        {
            PageEntryViewModel pageViewModel;
            if (postID == null)
            {

                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 3 &&
                        a.CategoryID == 1 && a.ActiveFlag == 1)
                        .OrderByDescending(a => a.EntryID).Take(5),
                    QuickUpdateEntries = entryRepository.ContentEntry.Where(e => e.EntryTypeID == 3 && e.CategoryID == 0
                        && e.IsQuickUpdate == 1).Take(10)
                };
            }
            else
            {
                // Entries with Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = null,
                    PostEntry = postRepository.PostEntry.Where(p => p.PostID == postID)
                };
            }

            if (postID != null)
            {
                ViewBag.HideFeature = true;
            }
            else
            {
                ViewBag.HideFeature = false;
            }

            ViewBag.Title = "Graphics";
            ViewBag.Category = "Graphics";
            ViewBag.MetaDesc = ConstantValues.GraphicsMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.GraphicsMetaKeywords;

            return View("Graphics", pageViewModel);
        }

        public ViewResult Showcase()
        {
            ViewBag.Title = "Graphics Showcase";
            GraphicsShowcaseViewModel pageViewModel = new GraphicsShowcaseViewModel();
            pageViewModel.GraphicsFiles = Directory.EnumerateFiles(Server.MapPath("~/content/images/Graphics/Showcase"))
                .Where(a => a.ToLower().EndsWith(".jpg") || a.ToLower().EndsWith(".png") || a.ToLower().EndsWith(".jpg"));
            ViewBag.MetaDesc = ConstantValues.GraphicsShowcaseMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.GraphicsShowcaseMetaKeywords;

            return View("Showcase", pageViewModel);
        }

        public ViewResult LatestEntry()
        {
            PageEntryViewModel pageViewModel;
            pageViewModel = new PageEntryViewModel
            {
                ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 3 && a.ActiveFlag == 1)
                    .OrderByDescending(a => a.EntryID).Take(1)
            };
            ViewBag.MetaDesc = ConstantValues.GraphicsMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.GraphicsMetaKeywords;

            return View("LatestEntry", pageViewModel);
        }

    }
}
