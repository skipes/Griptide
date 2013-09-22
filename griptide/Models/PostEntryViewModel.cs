using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace griptide.Models
{
    public class PostEntryViewModel
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string DateCreated { get; set; }
        public string PostBody { get; set; }
        public string Category { get; set; }
        public int CategoryID { get; set; }
    }
}