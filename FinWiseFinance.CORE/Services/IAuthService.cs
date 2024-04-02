namespace FinWiseFinance.Core.Services
{
    public interface IAuthService 
    {
        string GenerateJwtToken(string fullName, string email);
        string ComputeSha256Hash(string password);
    }
}
