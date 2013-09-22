using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using griptide.Domain.Abstract;
using griptide.Domain.Concrete;
using griptide.Domain.Entities;

namespace griptide.Domain.Repository.Entries
{
    public class EFLinksRepository : ILinksRepository
    {
        private DBContext context = new DBContext();

        public IQueryable<Links> Links
        {
            get { return context.Links; }
        }
    }
}
