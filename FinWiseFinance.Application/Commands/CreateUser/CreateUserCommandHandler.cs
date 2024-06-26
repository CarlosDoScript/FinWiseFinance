﻿using FinWiseFinance.Application.Exthension;
using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Repositories;
using FinWiseFinance.Core.Services;
using MediatR;

namespace FinWiseFinance.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(
        IUserRepository _userRepository,
        IAuthService _authService,
        IUnitOfWork _uow
        ) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(
                    ExthensionMethods.PrimeiraLetraMaiuscula(request.FirstName),
                    ExthensionMethods.PrimeiraLetraMaiuscula(request.LastName),
                    request.Email,
                    request.PhoneNumber,
                    request.CpfCnpj,
                    request.Income,
                    ExthensionMethods.PrimeiraLetraMaiuscula(request.CorporateReason),
                    request.Type,
                    request.TypeSalary,
                    request.BirthDate,
                    passwordHash,
                    request.DayOfReceipt,
                    request.IdCompanyBranch
                );

            await _userRepository.AddAsync(user);
            await _uow.CommitAsync();

            return user?.Id ?? 0;
        }
    }
}
