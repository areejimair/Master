using DoctorWho.DB.Models;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface ITblEpsiodeCompanionRep
    {
        Task<TblEpisodeCompanion> AddEps(TblEpisodeCompanion au);
        Task<TblEpisodeCompanion> GetEps(int id);
        void AddCompanionToEpisode(int compid, int episodeid);
    }
}