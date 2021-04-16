using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoctorWho.DB;
using DoctorWho.DB.Models;

namespace DoctorWho.DB.Repositories
{
    public class TblEnemyRep : ITblEnemyRep
    {
        public DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void Create_Enemy(string Enemy_Name, string Description)
        {
            TblEnemy CreateEnemy = new TblEnemy
            {

                EnemyName = Enemy_Name,
                Description = Description
            };
            context.Add(CreateEnemy);
            context.SaveChanges();
        }
        public void update_Enemy(int id, string Enemy_Name, string Description)
        {
            var entity = context.TblEnemies.FirstOrDefault(item => item.EnemyId == id);
            if (entity != null)
            {
                if (!String.IsNullOrEmpty(Enemy_Name))
                {
                    entity.EnemyName = Enemy_Name;
                }
                if (!String.IsNullOrEmpty(Description))
                {
                    entity.Description = Description;
                }
                context.SaveChanges();
            }
        }
        public void Delete_Enemy(int id)
        {

            var DeleteRecord = new TblEnemy { EnemyId = id };
            context.TblEnemies.Attach(DeleteRecord);
            context.TblEnemies.Remove(DeleteRecord);
            context.SaveChanges();
        }
        public void GetEnemyById(int id)
        {
            TblEnemy Enemy = context.TblEnemies.FirstOrDefault(item => item.EnemyId == id);

            Console.WriteLine("-----------------Enemy Table Inforamation -------------------");
            Console.WriteLine($"Enemy Id:         {Enemy.EnemyId}");
            Console.WriteLine($"Enemy Name:     {Enemy.EnemyName}");
            Console.WriteLine($"Enemy Description:       {Enemy.Description}");
            Console.WriteLine("--------------------------------------------------");

        }
    }
}
