using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace griptide.Models
{
    public class GraphicsShowcaseViewModel : PageEntryViewModel
    {
        public IEnumerable<string> GraphicsFiles { get; set; }
    }
}