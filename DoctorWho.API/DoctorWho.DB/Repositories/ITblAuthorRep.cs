using DoctorWho.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorWho.DB.Repositories
{
    public interface ITblAuthorRep
    {
        Task<TblAuthor> Update_Author(TblAuthor author);
        Task<TblAuthor> AddAuthors(TblAuthor author);
        Task<TblAuthor> GetAuthorss(int authorid);
        void AddAuthor(TblAuthor author);
        void DeleteAuthor(TblAuthor author);
        void UpdateAuthor(TblAuthor author);
        bool Save();
        void Create_Author(string Author_Name);
        void Delete_Author(int id);
        void update_authors(int id, string Author_Name);
        IEnumerable<TblAuthor> GetAuthors();
        TblAuthor GetAuthor(int authorId);
        IEnumerable<TblAuthor> GetAuthors(IEnumerable<int> authorIds);
    }
}