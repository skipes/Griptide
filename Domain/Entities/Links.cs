using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class Links
    {
        [Key]
        public int LinkID { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int LinkGroupID { get; set; }
    }
}
