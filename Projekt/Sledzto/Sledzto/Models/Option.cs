using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int WebsiteId { get; set; }
        public TrackigTechniqueEnum TrackigTechnique { get; set; }
        public String Options { get; set; }
        public int Frequency { get; set; }
        public bool OneTime { get; set; }

        public virtual Website Website { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}