using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorWho.DB.Models
{
    public class TblAuthor
    {
        public TblAuthor()
        {
            TblEpisodes = new HashSet<TblEpisode>();
        }
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<TblEpisode> TblEpisodes { get; set; }
    }
}
