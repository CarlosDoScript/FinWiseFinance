namespace FinWiseFinance.Core.Entities
{
    public class Profession : BaseEntity
    {
        public Profession(string description, DateTime createdAt)
        {
            Description = description;
            CreatedAt = createdAt;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
