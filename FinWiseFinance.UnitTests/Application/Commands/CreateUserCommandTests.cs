using FinWiseFinance.Application.Commands.CreateUser;
using FinWiseFinance.Application.Validators;
using FinWiseFinance.Core.Entities;
using FinWiseFinance.Core.Enums;
using FinWiseFinance.Core.Repositories;
using FinWiseFinance.Core.Services;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinWiseFinance.UnitTests.Application.Commands
{
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommandValidator _validator;
        public CreateUserCommandTests()
        {
            _validator = new CreateUserCommandValidator();
        }

        [Fact]
        public async void There_Should_Be_An_Error_When_Required_Fields_Are_Empty_Or_Null()
        {
            //Arrange
            var command = new CreateUserCommand
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                CpfCnpj = string.Empty,
                Income = 0.0M,
                CorporateReason = null,
                Type = UserTypeEnum.PHYSICAL,
                TypeSalary = UserTypeSalaryEnum.LIQUID,
                BirthDate = new DateTime(2001, 09, 13),
                Password = string.Empty,
                DayOfReceipt = new DateTime(2024, 05, 05),
                IdCompanyBranch = null
            };

            //Act
            var result = await _validator.ValidateAsync(command);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "FirstName");
            Assert.Contains(result.Errors, error => error.PropertyName == "LastName");
            Assert.Contains(result.Errors, error => error.PropertyName == "Email");
            Assert.Contains(result.Errors, error => error.PropertyName == "CpfCnpj");
            Assert.Contains(result.Errors, error => error.PropertyName == "Income");
            Assert.Contains(result.Errors, error => error.PropertyName == "Password");
        }

        [Fact]
        public async void Input_Data_Is_Validated_Without_Errors()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Carlos",
                LastName = "Henrique",
                Email = "carlosmvsep3@hotmail.com",
                PhoneNumber = "17 997411585",
                CpfCnpj = "462.644.918-29",
                //CpfCnpj = "91.753.325/0001-09",
                Income = 1500M,
                CorporateReason = null,
                Type = UserTypeEnum.PHYSICAL,
                TypeSalary = UserTypeSalaryEnum.LIQUID,
                BirthDate = new DateTime(2001, 09, 13),
                Password = "!Manchaalviverde2014",
                DayOfReceipt = new DateTime(2024, 05, 05),
                IdCompanyBranch = null
            };

            //Act
            var result = await _validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task Input_Data_Is_Executed_Returns_User_ID()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Carlos",
                LastName = "Henrique",
                Email = "carlosmvsep3@hotmail.com",
                PhoneNumber = "17 997411585",
                //CpfCnpj = "462.644.918-29",
                CpfCnpj = "91.753.325/0001-09",
                Income = 1500M,
                CorporateReason = null,
                Type = UserTypeEnum.PHYSICAL,
                TypeSalary = UserTypeSalaryEnum.LIQUID,
                BirthDate = new DateTime(2001, 09, 13),
                Password = "!Manchaalviverde2014",
                DayOfReceipt = new DateTime(2024, 05, 05),
                IdCompanyBranch = null
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act 
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            userRepositoryMock.Verify(u => u.AddAsync(It.IsAny<User>()),Times.Once);
        }


    }
}
