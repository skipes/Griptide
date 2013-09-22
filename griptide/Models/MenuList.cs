using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using griptide.Domain.Entities;

namespace griptide.Models
{
    public class MenuList
    {
        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<MenuSubItem> SubMenuItemList { get; set; }
    }
}