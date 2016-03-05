using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebApi2.Removable.Models
{
    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Method { get; set; }
    }
}