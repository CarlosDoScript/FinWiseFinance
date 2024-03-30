namespace FinWiseFinance.Core.Entities
{
    public class UserProfession : BaseEntity
    {
        public UserProfession(int idUser, int idProfession)
        {
            IdUser = idUser;
            IdProfession = idProfession;

            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int IdUser { get; private set; }
        public int IdProfession { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public Profession Profession { get; private set; }
        public User User { get; private set; }
    }
}
