using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblEpisodeCompanion
    {
        [Key]
        public int EpisodeCompanionId { get; set; }
        public int? EpisodeId { get; set; }
        public int? CompanionId { get; set; }

        public virtual TblCompanion Companion { get; set; }
        public virtual TblEpisode Episode { get; set; }
    }
}
