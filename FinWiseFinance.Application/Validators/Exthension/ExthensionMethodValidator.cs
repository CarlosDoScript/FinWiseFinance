using System.Text.RegularExpressions;

namespace FinWiseFinance.Application.Validators.Exthension
{
    public static class ExthensionMethodValidator
    {
        public static bool IsValidCpf(string cpf)
        {
            // Verifica se o CPF possui 11 dígitos numéricos
            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
                return false;

            // Cálculo do primeiro dígito verificador
            int[] cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();
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
            if (!Regex.IsMatch(cnpj, @"^\d{14}$"))
                return false;

            // Cálculo do primeiro dígito verificador
            int[] cnpjArray = cnpj.Select(c => int.Parse(c.ToString())).ToArray();
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
    }
}
