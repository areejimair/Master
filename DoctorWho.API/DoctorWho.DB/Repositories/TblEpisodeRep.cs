using System;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.DB;
using DoctorWho.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.DB.Repositories
{
    public class TblEpisodeRep : ITblEpisodeRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public async Task<TblEpisode> AddEpsiode(TblEpisode epsiode)
        {
            var result = await context.TblEpisodes.AddAsync(epsiode);
            await context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<TblEpisode> GetEpsiode(int epid)
        {
            return await context.TblEpisodes
                .FirstOrDefaultAsync(e => e.EpisodeId== epid);
        }
        public void Create_Episode(int seriesNumber, int episodenumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes)
        {
            TblEpisode CreateEpisode = new TblEpisode
            {
                SeriesNumber = seriesNumber,
                EpisodeNumber = episodenumber,
                EpisodeType = episodeType,
                Title = title,
                EpisodeDatedate = episodeDate,
                AuthorId = authorId,
                DoctorId = doctorId,
                Notes = notes

            };
            context.Add(CreateEpisode);
            context.SaveChanges();
        }
        public void update_episode(int id, int seriesNumber, int episodenumber, string episodeType, string title, DateTime? episodeDate, int authorId, int doctorId, string notes)
        {
            var entity = context.TblEpisodes.FirstOrDefault(item => item.EpisodeId == id);
            if (entity != null)
            {
                if (!String.IsNullOrEmpty(seriesNumber.ToString()))
                {
                    entity.SeriesNumber = seriesNumber;
                }
                if (!String.IsNullOrEmpty(episodenumber.ToString()))
                {
                    entity.EpisodeNumber = episodenumber;
                }
                if (!String.IsNullOrEmpty(episodeType))
                {
                    entity.EpisodeType = episodeType;
                }
                if (!String.IsNullOrEmpty(title))
                {
                    entity.Title = title;
                }
                if (!(episodeDate == null))
                {
                    entity.EpisodeDatedate = episodeDate;
                }
                if (!String.IsNullOrEmpty(authorId.ToString()))
                {
                    entity.AuthorId = authorId;
                }
                if (!String.IsNullOrEmpty(doctorId.ToString()))
                {
                    entity.DoctorId = doctorId;
                }
                if (!String.IsNullOrEmpty(notes))
                {
                    entity.Notes = notes;
                }
                context.SaveChanges();
            }
        }
        public void Delete_Episode(int id)
        {
            var DeleteRecord = new TblEpisode { EpisodeId = id };
            context.TblEpisodes.Attach(DeleteRecord);
            context.TblEpisodes.Remove(DeleteRecord);
            context.SaveChanges();
        }
    }
}
