namespace FinWiseFinance.Application.ViewModels
{
    public record LoginUserViewModel
    {
        public LoginUserViewModel(string cpfCnpj, string token)
        {
            CpfCnpj = cpfCnpj;
            Token = token;
        }

        public string CpfCnpj { get; init; }
        public string Token { get; init; }
    }
}
