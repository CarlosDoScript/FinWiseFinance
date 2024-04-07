#region SERVICES
using FinWiseFinance.API.Filters;
using FinWiseFinance.Application.Commands.CreateBank;
using FinWiseFinance.Application.Commands.LoginUser;
using FinWiseFinance.Application.Validators;
using FinWiseFinance.Core.Repositories;
using FinWiseFinance.Core.Services;
using FinWiseFinance.Infrastructure.Auth;
using FinWiseFinance.Infrastructure.Persistence;
using FinWiseFinance.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginUserCommandValidator>());

var connectionString = builder.Configuration.GetConnectionString("FinWiseFinanceCs");
builder.Services.AddDbContext<FinWiseFinanceDbContext>(f => f.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region REPOSITORIES E SERVICES
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateBankCommand).Assembly));

# endregion

#region APP 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion