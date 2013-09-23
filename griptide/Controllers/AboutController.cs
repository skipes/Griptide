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
    public class AboutController : Controller
    {
        private IEntryRepository entryRepository;
        private IPostRepository postRepository;

        public AboutController(IEntryRepository entryRepos, IPostRepository postRepos)
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
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 7 && a.ActiveFlag ==1).
                    OrderByDescending(a => a.EntryTypeID).Take(5),
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

            ViewBag.Title = "Griptide - About";
            ViewBag.Category = "About";
            ViewBag.MetaDesc = ConstantValues.AboutMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.AboutMetaKeyWords;

            return View("About", pageViewModel);
        }
    }
}
