namespace DoctorWho.DB.Repositories
{
    public interface ITblCompanionRep
    {
        void Create_Companios(string Compaion_Name, string Who_Played);
        void Delete_Companions(int id);
        void GetCompanionById(int id);
        void update_companion(int id, string name, string whopayed);
    }
}