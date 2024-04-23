using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinWiseFinance.Application.Commands.DesactiveUser
{
    public class DesactiveUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
