using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using griptide.Domain.Entities;

namespace griptide.Domain.Concrete
{
    public class DBContext : DbContext
    {
        public DbSet<ContentEntry> ContentEntry { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<MenuSubItem> SubMenuItem { get; set; }
        public DbSet<PostEntry> PostEntry { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<LinksGroups> LinksGroups { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}
