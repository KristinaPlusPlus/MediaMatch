﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMatch
{

    public class AbridgedDirector
    {
        public string name { get; set; }
    }

    public class movieEle
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public List<string> genres { get; set; }
        public string mpaa_rating { get; set; }
        public int runtime { get; set; }
        public string critics_consensus { get; set; }
        public ReleaseDates release_dates { get; set; }
        public Ratings ratings { get; set; }
        public string synopsis { get; set; }
        public Posters posters { get; set; }
        public List<AbridgedCast> abridged_cast { get; set; }
        public List<AbridgedDirector> abridged_directors { get; set; }
        public string studio { get; set; }
        public AlternateIds alternate_ids { get; set; }
        public Links links { get; set; }
    }
}
