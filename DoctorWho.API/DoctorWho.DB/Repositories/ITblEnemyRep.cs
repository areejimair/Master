namespace DoctorWho.DB.Repositories
{
    public interface ITblEnemyRep
    {
        void Create_Enemy(string Enemy_Name, string Description);
        void Delete_Enemy(int id);
        void GetEnemyById(int id);
        void update_Enemy(int id, string Enemy_Name, string Description);
    }
}