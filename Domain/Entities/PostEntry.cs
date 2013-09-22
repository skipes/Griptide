using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class PostEntry
    {
        [Key]
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string DateCreated { get; set; }
        public string PostBody{ get; set; }
        public string PostHeader{ get; set; }
        public string PostSub { get; set; }
        public int ActiveFlag { get; set; }
        public int LinkGroupID { get; set; }

        [ForeignKey("LinkGroupID")]
        public virtual LinksGroups LinksGroup { get; set; }
    }
}
