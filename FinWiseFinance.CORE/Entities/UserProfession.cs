namespace FinWiseFinance.Core.Entities
{
    public class UserProfession : BaseEntity
    {
        public UserProfession(int idUser, int idProfession)
        {
            IdUser = idUser;
            IdProfession = idProfession;
        }

        public int IdUser { get; private set; }
        public int IdProfession { get; private set; }
        public Profession Profession { get; private set; }
    }
}
