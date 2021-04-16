using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.API.Models.Dto
{
    public class AuthorForCreationDto
    {
        
            public int AuthorId { get; set; }
            public string AuthorName { get; set; }
          
        //public virtual ICollection<EpisodeForCreation> TblEpisodes { get; set; }


    }
}
