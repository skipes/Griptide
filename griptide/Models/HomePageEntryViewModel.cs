﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using griptide.Domain.Entities;

namespace griptide.Models
{
    public class HomePageEntryViewModel
    {
        public IEnumerable<ContentEntry> ContentEntries { get; set; }
        public IEnumerable<ContentEntry> QuickUpdateEntries { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}