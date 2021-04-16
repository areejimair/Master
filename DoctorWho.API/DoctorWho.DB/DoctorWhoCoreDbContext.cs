using Microsoft.EntityFrameworkCore;
using DoctorWho.DB.Models;
using System;


namespace DoctorWho.DB
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public virtual DbSet<TblAuthor> TblAuthors { get; set; }
        public virtual DbSet<TblCompanion> TblCompanions { get; set; }
        public virtual DbSet<TblDoctor> TblDoctors { get; set; }
        public virtual DbSet<TblEnemy> TblEnemies { get; set; }
        public virtual DbSet<TblEpisode> TblEpisodes { get; set; }
        public virtual DbSet<TblEpisodeCompanion> TblEpisodeCompanions { get; set; }
        public virtual DbSet<TblEpisodeEnemy> TblEpisodeEnemies { get; set; }
        public virtual DbSet<viewEpisodes> viewEpisodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DoctorWho_Web;Trusted_Connection=True;");
         


        }
        [DbFunction(Schema = "dbo")]
        public static string fnCompanions(int id)
        {
            throw new Exception();
        }
        [DbFunction(Schema = "dbo")]
        public static string fnEnemies(int id)
        {
            throw new Exception();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TblAuthor>().HasData(
            new TblAuthor { AuthorId = 1, AuthorName = "Author1" },
            new TblAuthor { AuthorId = 2, AuthorName = "Author2" },
            new TblAuthor { AuthorId = 3, AuthorName = "Author3" },
            new TblAuthor { AuthorId = 4, AuthorName = "Author4" },
            new TblAuthor { AuthorId = 5, AuthorName = "Author5" }
           );

            modelBuilder.Entity<TblEpisode>().HasData(
         new TblEpisode
         {
             EpisodeId = 1,
             SeriesNumber = 2,
             EpisodeNumber = 5,
             EpisodeType = "comedey",
             Title = "Brooklyn99",
             EpisodeDatedate = new DateTime(2018, 6, 1),
             AuthorId = 1,
             DoctorId = 1,
             Notes = "Funny"
         },
        new TblEpisode
        {
            EpisodeId = 2,
            SeriesNumber = 2,
            EpisodeNumber = 5,
            EpisodeType = "comedey",
            Title = "Brooklyn99",
            EpisodeDatedate = new DateTime(2018, 6, 1),
            AuthorId = 2,
            DoctorId = 2,
            Notes = "Funny"
        },
         new TblEpisode
         {
             EpisodeId = 3,
             SeriesNumber = 2,
             EpisodeNumber = 5,
             EpisodeType = "comedey",
             Title = "Brooklyn99",
             EpisodeDatedate = new DateTime(2018, 6, 1),
             AuthorId = 3,
             DoctorId = 3,
             Notes = "Funny"
         },
          new TblEpisode
          {
              EpisodeId = 4,
              SeriesNumber = 2,
              EpisodeNumber = 5,
              EpisodeType = "comedey",
              Title = "Brooklyn99",
              EpisodeDatedate = new DateTime(2018, 6, 1),
              AuthorId = 4,
              DoctorId = 4,
              Notes = "Funny"
          },
           new TblEpisode
           {
               EpisodeId = 5,
               SeriesNumber = 2,
               EpisodeNumber = 5,
               EpisodeType = "comedey",
               Title = "Brooklyn99",
               EpisodeDatedate = new DateTime(2018, 6, 1),
               AuthorId = 5,
               DoctorId = 5,
               Notes = "Funny"
           }
        );
            modelBuilder.Entity<TblEpisodeEnemy>().HasData(
              new TblEpisodeEnemy { EpisodeEnemyId = 1, EpisodeId = 1, EnemyId = 1 },
              new TblEpisodeEnemy { EpisodeEnemyId = 2, EpisodeId = 2, EnemyId = 2 },
              new TblEpisodeEnemy { EpisodeEnemyId = 3, EpisodeId = 3, EnemyId = 3 },
              new TblEpisodeEnemy { EpisodeEnemyId = 4, EpisodeId = 4, EnemyId = 4 },
              new TblEpisodeEnemy { EpisodeEnemyId = 5, EpisodeId = 5, EnemyId = 5 }
             );
            modelBuilder.Entity<TblEnemy>().HasData(
             new TblEnemy { EnemyId = 1, EnemyName = "Name1", Description = "Des1" },
             new TblEnemy { EnemyId = 2, EnemyName = "Name2", Description = "Des2" },
             new TblEnemy { EnemyId = 3, EnemyName = "Name3", Description = "Des3" },
             new TblEnemy { EnemyId = 4, EnemyName = "Name4", Description = "Des4" },
             new TblEnemy { EnemyId = 5, EnemyName = "Name5", Description = "Des5" }
            );
            modelBuilder.Entity<TblEpisodeCompanion>().HasData(
             new TblEpisodeCompanion { EpisodeCompanionId = 1, EpisodeId = 1, CompanionId = 1 },
             new TblEpisodeCompanion { EpisodeCompanionId = 2, EpisodeId = 2, CompanionId = 2 },
             new TblEpisodeCompanion { EpisodeCompanionId = 3, EpisodeId = 3, CompanionId = 3 },
             new TblEpisodeCompanion { EpisodeCompanionId = 4, EpisodeId = 4, CompanionId = 4 },
             new TblEpisodeCompanion { EpisodeCompanionId = 5, EpisodeId = 5, CompanionId = 5 }
            );
            modelBuilder.Entity<TblCompanion>().HasData(
             new TblCompanion { CompanionId = 1, CompanionName = "Name1", WhoPlayed = "palyer1" },
             new TblCompanion { CompanionId = 2, CompanionName = "Name2", WhoPlayed = "palyer2" },
             new TblCompanion { CompanionId = 3, CompanionName = "Name3", WhoPlayed = "palyer3" },
             new TblCompanion { CompanionId = 4, CompanionName = "Name4", WhoPlayed = "palyer4" },
             new TblCompanion { CompanionId = 5, CompanionName = "Name5", WhoPlayed = "palyer5" }
            );

            modelBuilder.Entity<TblDoctor>().HasData(
             new TblDoctor { DoctorId = 1, DoctorNumber = 1, DoctorName = "doctor1", BirthDate = new DateTime(1990, 6, 1), FirstEpisodeDate = new DateTime(2000, 6, 1), LastEpisodeDate = new DateTime(2010, 6, 1) },
            new TblDoctor { DoctorId = 2, DoctorNumber = 2, DoctorName = "doctor2", BirthDate = new DateTime(1990, 6, 1), FirstEpisodeDate = new DateTime(2000, 6, 1), LastEpisodeDate = new DateTime(2010, 6, 1) },
             new TblDoctor { DoctorId = 3, DoctorNumber = 3, DoctorName = "doctor3", BirthDate = new DateTime(1990, 6, 1), FirstEpisodeDate = new DateTime(2000, 6, 1), LastEpisodeDate = new DateTime(2010, 6, 1) },
             new TblDoctor { DoctorId = 4, DoctorNumber = 4, DoctorName = "doctor4", BirthDate = new DateTime(1990, 6, 1), FirstEpisodeDate = new DateTime(2000, 6, 1), LastEpisodeDate = new DateTime(2010, 6, 1) },
            new TblDoctor { DoctorId = 5, DoctorNumber = 5, DoctorName = "doctor5", BirthDate = new DateTime(1990, 6, 1), FirstEpisodeDate = new DateTime(2000, 6, 1), LastEpisodeDate = new DateTime(2010, 6, 1) }
            );

            modelBuilder.Entity<viewEpisodes>().HasNoKey().ToView("ViewEpisodes");

            

        }


    }
}


