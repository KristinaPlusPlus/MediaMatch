using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMatch
{
    public class Refs
    {
        public List<object> similars { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public bool streamable { get; set; }
        public string total_albums { get; set; }
        public string total_singles { get; set; }
        public string total_eps { get; set; }
        public string total_lps { get; set; }
        public int total_freeplays { get; set; }
        public string total_compilations { get; set; }
        public string total_tracks { get; set; }
        public Refs refs { get; set; }
        public bool verified { get; set; }
        public int total_follows { get; set; }
        public int total_followed_by { get; set; }
    }

    public class Info
    {
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

    public class Artist
    {
        public List<Datum> data { get; set; }
        public Info info { get; set; }
        public string code { get; set; }
    }
}
