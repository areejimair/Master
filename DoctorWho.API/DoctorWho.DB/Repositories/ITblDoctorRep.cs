using DoctorWho.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface ITblDoctorRep
    {
        void AddDoctor(int id, TblDoctor doctor);
        Task<IEnumerable<TblDoctor>> GetDoctors();
        Task<TblDoctor> GetDoctor(int employeeId);
       TblDoctor Get_Doctor(int d);
        bool Save();
        void DeleteDoctor(TblDoctor doctor);
        void Create_Doctor(int Doctor_Number, string Doctor_Name, DateTime birth, DateTime FirstEpisode, DateTime LastEpisode);
        void Delete_Doctor(int id);
        void GetAllDoctors();
        void update_doctors(int id, int Doctor_Number, string Doctor_Name, DateTime? birth, DateTime? FirstEpisode, DateTime? LastEpisode);
    }
}