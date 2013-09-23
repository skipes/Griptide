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
    public class WebDesignController : Controller
    {
        private IEntryRepository entryRepository;
        private IMenuItemRepository menuRepository;
        private IPostRepository postRepository;

        public WebDesignController(IEntryRepository entryRepos, IMenuItemRepository menuRepos, IPostRepository postRepos)
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
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 4 || a.EntryTypeID == 8 
                        && a.ActiveFlag == 1).OrderByDescending(a => a.EntryTypeID).Take(5),
                    QuickUpdateEntries = entryRepository.ContentEntry.Where(e => e.EntryTypeID == 2 && e.CategoryID == 0
                        && e.IsQuickUpdate == 1).Take(5)
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

            ViewBag.Title = "Griptide - Graphics";
            ViewBag.Category = "Web Design";
            ViewBag.MetaDesc = ConstantValues.WebDesignMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.WebDesignMetaKeywords;

            if (postID != null)
            {
                ViewBag.HideFeature = true;
            }
            else
            {
                ViewBag.HideFeature = false;
            }

            return View("WebDesign", pageViewModel);

        }

        public ViewResult Jquery(int? postID)
        {
            PageEntryViewModel pageViewModel;
            if (postID == null)
            {
                // Entries with no Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 8 && a.ActiveFlag == 1)
                    .OrderByDescending(a => a.EntryTypeID).Take(5),
                    //MenuItems = menuRepository.MenuItem.Where(e => e.EnabledFlag == 1).OrderByDescending(e => e.DisplayOrder)
                };
            }
            else
            {
                // Entries with Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = null,
                    //MenuItems = menuRepository.MenuItem.Where(e => e.EnabledFlag == 1).OrderByDescending(e => e.DisplayOrder),
                    PostEntry = postRepository.PostEntry.Where(p => p.PostID == postID)
                };

            }

            ViewBag.Title = "Griptide - Jquery";
            ViewBag.Category = "WebDesign";
            ViewBag.View = "Jquery";
            ViewBag.MetaDesc = ConstantValues.JqueryMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.JqueryMetaKeywords;

            return View("Jquery", pageViewModel);

        }

        public ViewResult LatestEntry()
        {
            PageEntryViewModel pageViewModel;
            pageViewModel = new PageEntryViewModel
            {
                ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 4 || a.EntryTypeID == 8 
                    && a.ActiveFlag == 1).OrderByDescending(a => a.EntryID).Take(1)
            };
            ViewBag.MetaDesc = ConstantValues.WebDesignMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.WebDesignMetaKeywords;

            return View("LatestEntry", pageViewModel);
        }

        public ViewResult Showcase()
        {
            return View("Showcase");
        }
    }
}
