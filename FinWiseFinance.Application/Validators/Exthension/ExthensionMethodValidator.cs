using System.Text.RegularExpressions;

namespace FinWiseFinance.Application.Validators.Exthension
{
    public static class ExthensionMethodValidator
    {
        public static bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");           

            return password == null || password == string.Empty ? false : regex.IsMatch(password);
        }
        public static bool IsValidCpf(string cpf)
        {
            // Verifica se o CPF possui 11 dígitos numéricos
            if (!Regex.IsMatch(cpf, @"^([0-9]{3}\.){2}[0-9]{3}-[0-9]{2}$"))
                return false;

            // Cálculo do primeiro dígito verificador
            int[] cpfArray = cpf.Replace(".", "").Replace("-", "").Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += cpfArray[i] * (10 - i);

            int remainder = sum % 11;
            int firstVerifier = remainder < 2 ? 0 : 11 - remainder;

            // Cálculo do segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += cpfArray[i] * (11 - i);

            remainder = sum % 11;
            int secondVerifier = remainder < 2 ? 0 : 11 - remainder;

            // Retorna true se os dígitos verificadores forem válidos
            return cpfArray[9] == firstVerifier && cpfArray[10] == secondVerifier;
        }
        public static bool IsValidCnpj(string cnpj)
        {
            // Verifica se o CNPJ possui 14 dígitos numéricos
            if (Regex.IsMatch(cnpj, @"^([0-9]{2}\.?){3}[0-9]{4}\/?([0-9]{2}\-?)[0-9]{2}$"))
                return false;

            // Cálculo do primeiro dígito verificador
            int[] cnpjArray = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;
            int[] weight = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 12; i++)
                sum += cnpjArray[i] * weight[i];

            int remainder = sum % 11;
            int firstVerifier = remainder < 2 ? 0 : 11 - remainder;

            // Cálculo do segundo dígito verificador
            sum = 0;
            weight = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 13; i++)
                sum += cnpjArray[i] * weight[i];

            remainder = sum % 11;
            int secondVerifier = remainder < 2 ? 0 : 11 - remainder;

            // Retorna true se os dígitos verificadores forem válidos
            return cnpjArray[12] == firstVerifier && cnpjArray[13] == secondVerifier;
        }
        public static bool IsValidCpfOrCnpj(string value)
        {
            if (value?.Replace(".", "").Replace("-", "").Replace("/", "").Length == 11)
            {
                return IsValidCpf(value);
            }
            else if (value?.Replace(".", "").Replace("-", "").Replace("/", "").Length == 14)
            {
                return IsValidCnpj(value);
            }
            else
            {
                return false;
            }
        }

    }
}
