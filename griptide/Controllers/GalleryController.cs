using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using griptide.Domain.Abstract;
using griptide.Models;
using griptide.Domain.Entities;

namespace griptide.Controllers
{
    public class GalleryController : Controller
    {
        private IEntryRepository entryRepository;
        private IMenuItemRepository menuRepository;
        private IPostRepository postRepository;

        public GalleryController(IEntryRepository entryRepos, IMenuItemRepository menuRepos, IPostRepository postRepos)
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
                // Entries with no Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 5 && a.ActiveFlag == 1)
                    .OrderByDescending(a => a.EntryTypeID).Take(5),
                };
            }
            else
            {
                // Entries with Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = null,
                    PostEntry = postRepository.PostEntry.Where(p => p.PostID == postID).Take(1)
                };

            }

            ViewBag.Title = "Griptide - Gallery";
            ViewBag.Category = "Gallery";
            ViewBag.MetaDesc = ConstantValues.GalleryMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.GalleryMetaKeywords;

            return View("Gallery", pageViewModel);
        }

    }
}
