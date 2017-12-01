using Sledzto.ViewModel;
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

        public static implicit operator OptionVM(Option model) => new OptionVM{
            Id = model.Id,
            WebsiteId = model.WebsiteId,
            TrackigTechnique = model.TrackigTechnique,
            Options = model.Options,
            Frequency = model.Frequency,
            OneTime = model.OneTime
        };
    }
}