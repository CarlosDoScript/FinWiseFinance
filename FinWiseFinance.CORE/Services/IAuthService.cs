namespace FinWiseFinance.Core.Services
{
    public interface IAuthService 
    {
        string GenerateJwtToken(string firstName,string lastName, string email, string cpfCnpj);
        string ComputeSha256Hash(string password);
    }
}
