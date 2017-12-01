using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto.ViewModel
{
    public class OptionVM
    {
        public int Id { get; set; }
        public int WebsiteId { get; set; }
        public TrackigTechniqueEnum TrackigTechnique { get; set; }
        public String Options { get; set; }
        public int Frequency { get; set; }
        public bool OneTime { get; set; }
    }
}