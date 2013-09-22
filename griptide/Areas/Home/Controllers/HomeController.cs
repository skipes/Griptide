using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using griptide.Domain.Abstract;
using griptide.Models;
using griptide.Domain.Entities;
using griptide.Domain.Repository.Entries;

namespace griptide.Controllers
{
    public class HomeController : Controller
    {
        private IEntryRepository entryRepository;
        //private IMenuItemRepository menuRepository;

        public HomeController()
        {
            EFEntryRepository entryRepository = new EFEntryRepository();
            //menuRepository = menuRepos;

        }
        
        public ViewResult Index()
        {
            EFEntryRepository entryRepository = new EFEntryRepository();
            PageEntryViewModel homeViewModel = new PageEntryViewModel
            {
                ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 1).OrderByDescending(a => a.EntryTypeID).Take(5),
                QuickUpdateEntries = entryRepository.ContentEntry.Where(e => e.EntryTypeID == 2).Take(3),
                //MenuItems = menuRepository.MenuItem.Where(e => e.EnabledFlag ==  1).OrderByDescending(e => e.DisplayOrder)
            };

            ViewBag.Title = "Griptide - Graphics and Web";

            return View("HomePage", homeViewModel);
        }

    }
}
