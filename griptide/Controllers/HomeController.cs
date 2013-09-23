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
    public class HomeController : Controller
    {
        private IEntryRepository entryRepository;

        public HomeController(IEntryRepository entryRepos)
        {
            entryRepository = entryRepos;

        }

        [OutputCache(Duration = 3600)]
        public ViewResult Index()
        {
            PageEntryViewModel homeViewModel = new PageEntryViewModel
            {
                ContentEntries = entryRepository.ContentEntry.Where(a => a.EntryTypeID == 1 && a.ActiveFlag == 1)
                    .OrderByDescending(a => a.EntryID).Take(10),
                QuickUpdateEntries = entryRepository.ContentEntry.Where(e => e.ActiveFlag ==1
                    && e.IsQuickUpdate == 1)
                    .OrderByDescending(a => a.EntryID).Take(10)
            };

            ViewBag.Title = "Griptide - Graphics and Web";
            ViewBag.MetaDesc = ConstantValues.HomeMetaDesc;
            ViewBag.MetaKeywords = ConstantValues.HomeMetaKeyWords;

            return View("HomePage", homeViewModel);
        }

    }
}
