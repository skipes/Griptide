using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using griptide.Domain.Abstract;
using griptide.Domain.Concrete;
using griptide.Domain.Entities;

namespace griptide.Domain.Repository.Entries
{
    public class EFImageRepository : IImagesRepository
    {
        private DBContext context = new DBContext();

        public IQueryable<Image> Image
        {
            get { return context.Image; }
        }
    }
}
