using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Owners.Query.LoginOwner
{
    public class LoginOwnerQueryHandler : IRequestHandler<LoginOwnerQuery, string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;
        public LoginOwnerQueryHandler(UserManager<IdentityUser> userManager , ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(LoginOwnerQuery request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
                throw new Exception("UserName or password not correct");

            var ispasswordcorrect =await _userManager.CheckPasswordAsync(user, request.Password);

            if (!ispasswordcorrect)
                throw new Exception("UserName or password not correct");

            var token =await _tokenService.GenerateTokenAsync(user);
            return token;
        }
    }
}
