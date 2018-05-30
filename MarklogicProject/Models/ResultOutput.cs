using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarklogicProject.Models
{
    public class ResultOutput
    {
        public string Result { get; set; }
        public string Uri { get; set; }
        public int Relevance { get; set; }
        public string Mime { get; set; }
        public string Text { get; set; }
    }
}