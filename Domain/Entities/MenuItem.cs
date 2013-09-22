using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class MenuItem
    {
        [Key]
        public int MenuID { get; set; }
        public string MenuText { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public int EnabledFlag { get; set; }
        public string menuURL { get; set; }
        public string AdditionalClass { get; set; }
        public string MenuBreakClass { get; set; }

        [ForeignKey("MenuID")]
        public virtual List<MenuSubItem> MenuSubItems { get; set; }
    }
}
