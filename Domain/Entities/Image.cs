using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace griptide.Domain.Entities
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageText { get; set; }
        public string ImageFile { get; set; }
    }
}
