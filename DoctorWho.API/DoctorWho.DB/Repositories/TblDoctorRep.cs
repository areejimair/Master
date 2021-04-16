using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.DB;
using DoctorWho.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB.Repositories
{
    public class TblDoctorRep : ITblDoctorRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public async Task<IEnumerable<TblDoctor>> GetDoctors()
        {
            return await context.TblDoctors.ToListAsync();
        }
        public void Create_Doctor(int Doctor_Number, string Doctor_Name, DateTime birth, DateTime FirstEpisode, DateTime LastEpisode)
        {
            TblDoctor CreateDoctor = new TblDoctor
            {
                DoctorNumber = Doctor_Number,
                DoctorName = Doctor_Name,
                BirthDate = birth,
                FirstEpisodeDate = FirstEpisode,
                LastEpisodeDate = LastEpisode


            };
            context.Add(CreateDoctor);
            context.SaveChanges();
        }
        public void update_doctors(int id, int Doctor_Number, string Doctor_Name, DateTime? birth, DateTime? FirstEpisode, DateTime? LastEpisode)
        {
            var entity = context.TblDoctors.FirstOrDefault(item => item.DoctorId == id);
            if (entity != null)
            {
                if (!String.IsNullOrEmpty(Doctor_Number.ToString()))
                {
                    entity.DoctorNumber = Doctor_Number;
                }
                if (!String.IsNullOrEmpty(Doctor_Name))
                {
                    entity.DoctorName = Doctor_Name;
                }
                if (!(birth == null))
                {
                    entity.BirthDate = birth;
                }
                if (!(FirstEpisode == null))
                {
                    entity.FirstEpisodeDate = FirstEpisode;
                }
                if (!(LastEpisode == null))
                {
                    entity.LastEpisodeDate = LastEpisode;
                }
                context.SaveChanges();
            }
        }
        public void Delete_Doctor(int id)
        {
            var DeleteRecord = new TblDoctor { DoctorId = id };
            context.TblDoctors.Attach(DeleteRecord);
            context.TblDoctors.Remove(DeleteRecord);
            context.SaveChanges();
        }
        public void GetAllDoctors()
        {
            var doctor = context.TblDoctors.ToList();
            Console.WriteLine("-----------------Doctor Table Inforamation -------------------");
            foreach (var t in doctor)
            {

                Console.WriteLine($"Doctor Id:         {t.DoctorId}");
                Console.WriteLine($"Doctor Number:     {t.DoctorNumber}");
                Console.WriteLine($"Doctor Name:       {t.DoctorName}");
                Console.WriteLine($"Doctor Birthday:   {t.BirthDate}");
                Console.WriteLine($"Doctor First Date: {t.FirstEpisodeDate}");
                Console.WriteLine($"Doctor Last Date:  {t.LastEpisodeDate}");
                Console.WriteLine("--------------------------------------------------");

            }

        }

        public void DeleteDoctor(TblDoctor doctor)
        {
           
                if (doctor== null)
                {
                    throw new ArgumentNullException(nameof(doctor));
                }

                context.TblDoctors.Remove(doctor);
           
            
        }
        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }
        public TblDoctor Get_Doctor(int Id)
        {
            if (Id==0)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return context.TblDoctors.FirstOrDefault(a => a.DoctorId == Id);
        }


        public async Task<TblDoctor> GetDoctor(int employeeId)
        {
            return await context.TblDoctors
                .FirstOrDefaultAsync(e => e.DoctorId == employeeId);
        }
        public void AddDoctor(int DoctorId, TblDoctor doctor)
        {
            if ( DoctorId==null)
            {
                throw new ArgumentNullException(nameof(DoctorId));
            }

            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }
            
            doctor.DoctorId = DoctorId;
            context.TblDoctors.Add(doctor);
        }
    }
}
