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
                CpfCnpj = "999999999999999"
            };

            //Act
            var result = await _validator.ValidateAsync(command);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.PropertyName == "Password");
        }

        [Fact]
        public async void should_be_successful_when_cpfCnpj_and_password_are_correct()
        {
            //Arrange
            var command = new LoginUserCommand
            {
                CpfCnpj = "999999999999",
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
