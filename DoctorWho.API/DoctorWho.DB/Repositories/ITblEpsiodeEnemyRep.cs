using DoctorWho.DB.Models;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface ITblEpsiodeEnemyRep
    {
        Task<TblEpisodeEnemy> AddEps(TblEpisodeEnemy au);
        Task<TblEpisodeEnemy> GetEps(int id);
        void AddEnemyToEpisode(int enemyid, int episodeid);
    }
}