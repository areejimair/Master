using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.DB;
using DoctorWho.DB.Models;
using Microsoft.EntityFrameworkCore;
using DoctorWho.DB.Models;

namespace DoctorWho.DB.Repositories
{
    public class TblEpsiodeCompanionRep : ITblEpsiodeCompanionRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddCompanionToEpisode(int compid, int episodeid)
        {
            TblEpisodeCompanion obj = new TblEpisodeCompanion
            {
                EpisodeId = episodeid,
                CompanionId = compid
            };
            context.Add(obj);
            context.SaveChanges();

        }



        public async Task<TblEpisodeCompanion> AddEps(TblEpisodeCompanion ep)
        {
            var result = await context.TblEpisodeCompanions.AddAsync(ep);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblEpisodeCompanion> GetEps(int id)
        {
            return await context.TblEpisodeCompanions
                .FirstOrDefaultAsync(e => e.EpisodeId ==id);
        }
    }
}
