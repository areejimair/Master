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

    public class TblAuthorRep : ITblAuthorRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public async Task<TblAuthor> AddAuthors(TblAuthor author)
        {
            var result = await context.TblAuthors.AddAsync(author);
            await context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<TblAuthor> GetAuthorss(int authorid)
        {
            return await context.TblAuthors
                .FirstOrDefaultAsync(e => e.AuthorId== authorid);
        }
        public void AddAuthor(TblAuthor author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            context.TblAuthors.Add(author);
        }
        public void Create_Author(string Author_Name)
        {
            TblAuthor CreateAuthor = new TblAuthor
            {
                AuthorName = Author_Name
            };
            context.Add(CreateAuthor);
            context.SaveChanges();
        }
        public void update_authors(int id, string Author_Name)
        {
            var entity = context.TblAuthors.FirstOrDefault(item => item.AuthorId == id);
            if (entity != null)
            {
                if (!String.IsNullOrEmpty(Author_Name))
                {
                    entity.AuthorName = Author_Name;
                }

                context.SaveChanges();
            }
        }
        public void Delete_Author(int id)
        {
            var DeleteRecord = new TblAuthor { AuthorId = id };
            context.TblAuthors.Attach(DeleteRecord);
            context.TblAuthors.Remove(DeleteRecord);
            context.SaveChanges();
        }

        public IEnumerable<TblAuthor> GetAuthors()
        {
            return context.TblAuthors.ToList<TblAuthor>();
        }

        public TblAuthor GetAuthor(int authorId)
        {
            if (authorId ==null)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return context.TblAuthors.FirstOrDefault(a => a.AuthorId == authorId);
        }

        public IEnumerable<TblAuthor> GetAuthors(IEnumerable<int> authorIds)
        {
            if (authorIds == null)
            {
                throw new ArgumentNullException(nameof(authorIds));
            }

            return context.TblAuthors.Where(a => a.AuthorId==authorIds.First())
                .OrderBy(a => a.AuthorId)
                .OrderBy(a => a.AuthorName)
                .ToList();
        }

      
        public void DeleteAuthor(TblAuthor author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            context.TblAuthors.Remove(author);
        }
        void ITblAuthorRep.UpdateAuthor(TblAuthor author)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (context.SaveChanges() >= 0);
        }

        public async Task<TblAuthor> Update_Author(TblAuthor author)
        {
            var result = await context.TblAuthors
                .FirstOrDefaultAsync(e => e.AuthorId == author.AuthorId);

            if (result != null)
            {
                result.AuthorName = author.AuthorName;
              

                await context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
