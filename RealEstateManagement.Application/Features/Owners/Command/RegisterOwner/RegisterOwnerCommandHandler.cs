using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Domain.Entities;


namespace RealEstateManagement.Application.Features.Owners.Command.RegisterOwner
{
    public class RegisterOwnerCommandHandler : IRequestHandler<RegisterOwnerCommand , string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRealEstateManagementDbContext _context;
        public RegisterOwnerCommandHandler(UserManager<IdentityUser> UserManager, IRealEstateManagementDbContext context)
        {
            _userManager = UserManager;
            _context = context;
        }
        public async Task<string> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            var identityUser = new IdentityUser
            {
                UserName =  request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result =await _userManager.CreateAsync(identityUser, request.Password);

            if (result.Succeeded
                )
            {
                var owner = new Owner
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    IdentityUserId = identityUser.Id
                };

                _context.Owners.Add(owner);
                await _context.SaveChangesAsync(cancellationToken);
                return owner.Id.ToString();
            }
            else
            {
                throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
