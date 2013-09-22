﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using griptide.Domain.Entities;

namespace griptide.Domain.Abstract
{
    public interface ILinksGroupsRepository
    {
        IQueryable<LinksGroups> LinksGroups { get; }
    }
}
