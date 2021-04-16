using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.API.Models.Dto
{
    public class DoctorforCreation:IValidatableObject
    {
        public int DoctorId { get; set; }
        [Required]
        public int? DoctorNumber { get; set; }
        [Required]
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstEpisodeDate == null)
            {
                LastEpisodeDate = null;
                yield return new ValidationResult("if FirstDate is null then lastEpsiode should be null",
                 new[] { "DoctorDto" });
            }

            if (FirstEpisodeDate <= LastEpisodeDate)
            {
                yield return new ValidationResult("LastEpisodeDate should be greater than or equal to FirstEpisodeDate",
                 new[] { "DoctorDto" });

            }
        }
    }
}
