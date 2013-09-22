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
    public class MainMenuController : Controller
    {
        private IMenuItemRepository MenuRepository;
        private ILinksGroupsRepository LinkGroupsRepository;

        public MainMenuController(IMenuItemRepository menuRepos, ILinksGroupsRepository linkGroups)
        {
            MenuRepository = menuRepos;
            LinkGroupsRepository = linkGroups;
        }

        [OutputCache(Duration = 3600)]
        public ActionResult Menu()
        {
            MenuList menuList = new MenuList();
            menuList.MenuItemList = MenuRepository.MenuItem.Where(e => e.EnabledFlag == 1).ToList();
            //menuList.SubMenuItemList = SubMenuRepository.SubMenuItem.Where(e => e.EnabledFlag == 1);

            return PartialView("MainMenu", menuList);
        }

        [OutputCache(Duration = 3600)]
        public ActionResult FooterMenu()
        {
            //MenuList menuList = new MenuList();
            //menuList.MenuItemList = MenuRepository.MenuItem.Where(e => e.EnabledFlag == 1).ToList();
            //menuList.SubMenuItemList = SubMenuRepository.SubMenuItem.Where(e => e.EnabledFlag == 1);
            LinkGroupsViewModel linkGroups = new LinkGroupsViewModel();
            linkGroups.LinkGroup = LinkGroupsRepository.LinksGroups.Where(e => e.ActiveFlag == 1 &&
                e.IsFooterGroup == 1).ToList();

            linkGroups.LeftFooterGroup = linkGroups.LinkGroup.Take(2).ToList();
            if (linkGroups.LinkGroup.Count() > 2)
            {
                linkGroups.RightFooterGroup = linkGroups.LinkGroup.Skip(2).Take(2).ToList();
            }

            return PartialView("~/Views/Shared/Layouts/_Footer.cshtml", linkGroups);
        }
    }
}
