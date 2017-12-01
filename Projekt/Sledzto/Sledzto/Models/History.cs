using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto.Models
{
    public class History
    {
        public int Id { get; set; }
        public String Message { get; set; }
        public String Last { get; set; }
        public DateTime DateTime { get; set; }
        public int OptionId { get; set; }
        
        public virtual Option Option { get; set; }
    }
}