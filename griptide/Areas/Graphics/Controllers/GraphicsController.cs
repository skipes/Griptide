using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using griptide.Domain.Abstract;
using griptide.Models;
using griptide.Domain.Entities;
using griptide.Domain.Repository.Entries;

namespace griptide.Areas.Graphics.Controllers
{
    public class GraphicsController : Controller
    {
        //private IEntryRepository entryRepository;
        //private IMenuItemRepository menuRepository;
        private IPostRepository postRepository;

        //public GraphicsController(IEntryRepository entryRepos, IMenuItemRepository menuRepos, IPostRepository postRepos)
        //{
        //    entryRepository = entryRepos;
        //    menuRepository = menuRepos;
        //    postRepository = postRepos;

        //}

        //public GraphicsController()
        //{
        //    IEntryRepository entryRepository = new entryRepository
        //    menuRepository = menuRepos;
        //    postRepository = postRepos;

        //}

        public ViewResult Index(int? postID)
        {
            EFEntryRepository entryRepository = new EFEntryRepository();
            PageEntryViewModel pageViewModel;
            if (postID == null)
            {
                // Entries with no Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 3).OrderByDescending(a => a.EntryTypeID).Take(5),
                };
            }
            else
            {
                // Entries with Posts
                pageViewModel = new PageEntryViewModel
                {
                    ContentEntries = null,
                    PostEntries = postRepository.PostEntry.Where(p => p.PostID == postID)
                };

            }

            ViewBag.Title = "Griptide - Graphics";
            ViewBag.Category = "Graphics";

            return View("Graphics", pageViewModel);
        }
    }
}
