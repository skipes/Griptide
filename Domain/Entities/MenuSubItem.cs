using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace griptide.Domain.Entities
{
    public class MenuSubItem
    {
        [Key]
        public int SubMenuID { get; set; }
        public int MenuID { get; set; }
        public string SubMenuText { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public int EnabledFlag { get; set; }
        public string menuURL { get; set; }
        public string menuController { get; set; }
        public string menuAction { get; set; }
        public string AdditionalClass { get; set; }
    }
}
