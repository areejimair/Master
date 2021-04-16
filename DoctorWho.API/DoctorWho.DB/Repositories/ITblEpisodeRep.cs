using DoctorWho.DB.Models;
using System;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface ITblEpisodeRep
    {
        Task<TblEpisode> AddEpsiode(TblEpisode author);
        Task<TblEpisode> GetEpsiode(int Epsiodeid);
        void Create_Episode(int seriesNumber, int episodenumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes);
        void Delete_Episode(int id);
        void update_episode(int id, int seriesNumber, int episodenumber, string episodeType, string title, DateTime? episodeDate, int authorId, int doctorId, string notes);
    }
}