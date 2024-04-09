namespace FinWiseFinance.Core.Entities
{
    public class CompanyBranch(string title, string description) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool Active { get; private set; } = true;

        public List<User>? Users { get; private set; } = new List<User>();
    }
}
