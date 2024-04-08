using FinWiseFinance.Application.Commands.LoginUser;
using FinWiseFinance.Application.Validators;

namespace FinWiseFinance.UnitTests.Application.Commands
{
    public class LoginUserCommandTests
    {
        private readonly LoginUserCommandValidator _validator;

        public LoginUserCommandTests()
        {
            _validator = new LoginUserCommandValidator();
        }

        [Fact]
        public async void Should_Have_Error_When_CpfCnpj_Is_Empty()
        {
            //Arrange
            var command = new LoginUserCommand
            {
                Password = "Manchaalvive&rde2014"
            };

            //Act 
            var result = await _validator.ValidateAsync(command);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "CpfCnpj");
        }

        [Fact]
        public async void Should_Have_Error_When_Password_Is_Empty()
        {
            //Arrange
            var command = new LoginUserCommand
            {
                CpfCnpj = "462.644.918-29"
            };

            //Act
            var result = await _validator.ValidateAsync(command);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "Password");
        }

        [Fact]
        public async void Should_Be_Successful_When_CpfCnpj_And_Password_Are_Correct()
        {
            //Arrange
            var command = new LoginUserCommand
            {
                //CpfCnpj = "462.644.918-29",
                CpfCnpj = "91.753.325/0001-09",
                Password = "!Manchaalviverde2014"                
            };

            //Act
            var result = await  _validator.ValidateAsync(command);

            //Assert
            Assert.True(result.IsValid);
            Assert.DoesNotContain(result.Errors, error => error.PropertyName == "CpfCnpj");
            Assert.DoesNotContain(result.Errors, error => error.PropertyName == "Password");
        }
    }
}
