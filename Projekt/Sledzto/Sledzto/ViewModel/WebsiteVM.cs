using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto.ViewModel
{
    public class WebsiteVM
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public List<TrackigTechniqueEnum> OptionList { get; set; }
    }
}