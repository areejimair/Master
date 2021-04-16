using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblCompanion
    {
        public TblCompanion()
        {
            TblEpisodeCompanions = new HashSet<TblEpisodeCompanion>();
        }
        [Key]
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }

        public virtual ICollection<TblEpisodeCompanion> TblEpisodeCompanions { get; set; }
    }
}
