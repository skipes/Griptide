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
    public class IdeasController : Controller
    {
        private IEntryRepository entryRepository;
        private IPostRepository postRepository;

        public IdeasController(IEntryRepository entryRepos, IPostRepository postRepos)
        {
            entryRepository = entryRepos;
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
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 6 && a.ActiveFlag == 1
                    && a.IsQuickUpdate == 0)
                    .OrderByDescending(a => a.EntryTypeID).Take(5),
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

            ViewBag.Title = "Griptide - Ideas";
            ViewBag.Category = "Ideas";

            return View("Ideas", pageViewModel);
        }

    }
}
