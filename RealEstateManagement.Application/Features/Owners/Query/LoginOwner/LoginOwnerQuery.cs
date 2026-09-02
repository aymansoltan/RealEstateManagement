using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Owners.Query.LoginOwner
{
    public class LoginOwnerQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
