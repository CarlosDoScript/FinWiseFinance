namespace FinWiseFinance.Core.Entities
{
    public class UserProfession(int idUser, int idProfession) : BaseEntity
    {
        public int IdUser { get; private set; } = idUser;
        public int IdProfession { get; private set; } = idProfession;
        public bool Active { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public Profession Profession { get; private set; }
        public User User { get; private set; }
    }
}
