using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoctorWho.DB;
using DoctorWho.DB.Models;

namespace DoctorWho.DB.Repositories
{
    public class TblCompanionRep : ITblCompanionRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void Create_Companios(string Compaion_Name, string Who_Played)
        {
            TblCompanion Createcompanion = new TblCompanion
            {

                CompanionName = Compaion_Name,
                WhoPlayed = Who_Played
            };
            context.Add(Createcompanion);
            context.SaveChanges();
        }
        public void update_companion(int id, string name, string whopayed)
        {
            var entity = context.TblCompanions.FirstOrDefault(item => item.CompanionId == id);
            if (entity != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    entity.CompanionName = name;
                }
                if (!String.IsNullOrEmpty(whopayed))
                {
                    entity.WhoPlayed = whopayed;
                }
                context.SaveChanges();
            }
        }
        public void Delete_Companions(int id)
        {
            var DeleteRecord1 = new TblEpisodeCompanion { CompanionId = id };
            context.TblEpisodeCompanions.Attach(DeleteRecord1);
            context.TblEpisodeCompanions.Remove(DeleteRecord1);
            context.SaveChanges();
            var DeleteRecord = new TblCompanion { CompanionId = id };
            context.TblCompanions.Attach(DeleteRecord);
            context.TblCompanions.Remove(DeleteRecord);
            context.SaveChanges();
        }
        public void GetCompanionById(int id)
        {
            TblCompanion comp = context.TblCompanions.FirstOrDefault(item => item.CompanionId == id);

            Console.WriteLine("-----------------Companions Table Inforamation -------------------");
            Console.WriteLine($"Companion Id:         {comp.CompanionId}");
            Console.WriteLine($"Companion Number:     {comp.CompanionName}");
            Console.WriteLine($"Who Palyed :       {comp.WhoPlayed}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
