using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblEpisodeEnemy
    {
        [Key]
        public int EpisodeEnemyId { get; set; }
        public int? EpisodeId { get; set; }
        public int? EnemyId { get; set; }

        public virtual TblEnemy Enemy { get; set; }
        public virtual TblEpisode Episode { get; set; }
    }
}
