using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(IdentityUser user);
    }
}
