using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using griptide.Domain.Entities;

namespace griptide.Models
{
    public class LinkGroupsViewModel
    {
        public IEnumerable<LinksGroups> LinkGroup { get; set; }
        public IEnumerable<LinksGroups> LeftFooterGroup { get; set; }
        public IEnumerable<LinksGroups> RightFooterGroup { get; set; }
    }
}