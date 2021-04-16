using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Models
{
   public  class viewEpisodes
    {
        public string  SeriesNumber { get; set; }
        public string EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string DoctorName { get; set; }
        public string Companions { get; set; }
        public string Enemies { get; set; }

    }
}
