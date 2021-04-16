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
    public class TblEpsiodeEnemyRep : ITblEpsiodeEnemyRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddEnemyToEpisode(int enemyid, int episodeid)
        {
            TblEpisodeEnemy obj = new TblEpisodeEnemy
            {
                EpisodeId = episodeid,
                EnemyId = enemyid
            };
            context.Add(obj);
            context.SaveChanges();


        }
        public async Task<TblEpisodeEnemy> AddEps(TblEpisodeEnemy ep)
        {
            var result = await context.TblEpisodeEnemies.AddAsync(ep);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblEpisodeEnemy> GetEps(int id)
        {
            return await context.TblEpisodeEnemies
                .FirstOrDefaultAsync(e => e.EpisodeId == id);
        }
    }
}
