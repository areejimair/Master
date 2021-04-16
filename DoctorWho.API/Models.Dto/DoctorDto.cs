using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.API.Models.Dto
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
      
        public int? DoctorNumber { get; set; }
       
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }

      
    }
}
