using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class LinksGroups
    {
        [Key]
        public int LinkGroupID { get; set; }
        public string LinkTitle { get; set; }
        public int ActiveFlag { get; set; }
        public int IsFooterGroup { get; set; }

        [ForeignKey("LinkGroupID")]
        public virtual List<Links> Links { get; set; }
    }
}
