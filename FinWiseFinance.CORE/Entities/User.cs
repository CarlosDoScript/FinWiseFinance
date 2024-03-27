﻿using FinWiseFinance.Core.Enums;

namespace FinWiseFinance.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string? phoneNumber, string cpfCnpj, decimal money, string? corporateReason, UserTypeEnum type, UserTypeSalaryEnum typeSalary, DateTime birthDate, DateTime createdAt,string password,DateTime dayOfReceipt)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            CpfCnpj = cpfCnpj;
            Income = money;
            CorporateReason = corporateReason;
            Type = type;
            TypeSalary = typeSalary;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Password = password;
            DayOfReceipt = dayOfReceipt;

            Active = true;
            CreatedAt = DateTime.Now;

            Professions = new List<UserProfession>();
            Bills  = new List<Bill>();
            InstallmentBills = new List<InstallmentBill>();
            DailyExpenses = new List<DailyExpense>();
            PurchaseTargets = new List<PurchaseTarget>();
            Banks = new List<Bank>();
    }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string CpfCnpj { get; private set; }
        public decimal Income { get; private set; }
        public string? CorporateReason { get; private set; }
        public UserTypeEnum Type { get; private set; }
        public UserTypeSalaryEnum TypeSalary { get; private set; }
        public DateTime DayOfReceipt { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }

        public List<UserProfession>? Professions { get; private set; }
        public List<Bill> Bills { get; private set; }
        public List<InstallmentBill> InstallmentBills { get; private set; }
        public List<DailyExpense> DailyExpenses { get; private set; }
        public List<PurchaseTarget> PurchaseTargets { get; private set; }
        public List<Bank>? Banks { get; private set; }

        public CompanyBranch? CompanyBranch { get; private set; }
    }
}
