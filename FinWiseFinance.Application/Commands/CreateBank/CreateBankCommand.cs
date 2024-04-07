using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinWiseFinance.Application.Commands.CreateBank
{
    public class CreateBankCommand : IRequest<int>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
    }
}
