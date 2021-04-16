using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblEnemy
    {
        public TblEnemy()
        {
            TblEpisodeEnemies = new HashSet<TblEpisodeEnemy>();
        }
        [Key]
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblEpisodeEnemy> TblEpisodeEnemies { get; set; }
    }
}
