namespace FinWiseFinance.Core.Entities
{
    public class Profession(string title, string description) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool Active { get; private set; } = true;

        public List<UserProfession> UserProfessions { get; private set; }
    }
}
