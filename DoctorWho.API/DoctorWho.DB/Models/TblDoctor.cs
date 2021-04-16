using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblDoctor
    {
        public TblDoctor()
        {
            TblEpisodes = new HashSet<TblEpisode>();
        }

        [Key]
        public int DoctorId { get; set; }
        public int? DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }

        public virtual ICollection<TblEpisode> TblEpisodes { get; set; }
    }
}
