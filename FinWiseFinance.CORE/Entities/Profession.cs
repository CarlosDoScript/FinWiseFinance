namespace FinWiseFinance.Core.Entities
{
    public class Profession : BaseEntity
    {
        public Profession(string description)
        {
            Description = description;

            Active = true;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
