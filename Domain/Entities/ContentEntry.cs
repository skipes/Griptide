using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class ContentEntry
    {
        [Key]
        public int EntryID { get; set; }
        public string EntryTitle { get; set; }
        public string PostID { get; set; }
        public string DateCreated { get; set; }
        public string EntryText { get; set; }
        public int ImageID { get; set; }
        public int EntryTypeID { get; set; }
        public string EntryUrl { get; set; }
        public int ActiveFlag { get; set; }
        public int CategoryID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int IsQuickUpdate { get; set; }

        [ForeignKey("ImageID")]
        public virtual Image Image { get; set; }
    }
}
