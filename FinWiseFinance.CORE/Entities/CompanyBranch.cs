namespace FinWiseFinance.Core.Entities
{
    public class CompanyBranch : BaseEntity
    {
        public CompanyBranch(string description, DateTime createdAt, bool active)
        {
            Description = description;
            CreatedAt = createdAt;
            Active = active;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
