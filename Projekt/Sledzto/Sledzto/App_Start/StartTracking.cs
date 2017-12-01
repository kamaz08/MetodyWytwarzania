using Sledzto.Models;
using Sledzto.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto
{
    public class StartTracking
    {
        private AppDbContext db = new AppDbContext();
        public StartTracking()
        {
            db.Option
                .Where(x => !x.OneTime || x.History.Count() == 0)
                .ToList()
                .ForEach(x => TrackOptions(x));
        }

        public void TrackOptions(Option option)
        {
            switch (option.TrackigTechnique)
            {
                case TrackigTechniqueEnum.Hash:
                    new HashTrack(option).TrackPage();
                    break;

                case TrackigTechniqueEnum.Regex:
                    new RegexTrack(option).TrackPage();
                    break;
            }
        }
    }
}