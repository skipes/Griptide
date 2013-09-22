using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using griptide.Domain.Abstract;
using griptide.Domain.Concrete;
using griptide.Domain.Entities;

namespace griptide.Domain.Repository.Entries
{
    public class EFLinksGroupRepository : ILinksGroupsRepository
    {
        private DBContext context = new DBContext();

        public IQueryable<LinksGroups> LinksGroups
        {
            get { return context.LinksGroups; }
        }
    }
}
