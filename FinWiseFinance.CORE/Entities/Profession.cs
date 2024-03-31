namespace FinWiseFinance.Core.Entities
{
    public class Profession : BaseEntity
    {
        public Profession(string title,string description)
        {
            Title = title;
            Description = description;

            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }

        public List<UserProfession> UserProfessions { get; private set; }
    }
}
