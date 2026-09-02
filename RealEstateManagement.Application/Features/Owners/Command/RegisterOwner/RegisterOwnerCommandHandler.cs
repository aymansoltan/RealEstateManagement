using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Application.Features.Owners.Command.RegisterOwner
{
    public class RegisterOwnerCommandHandler : IRequestHandler<RegisterOwnerCommand , string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterOwnerCommandHandler(UserManager<IdentityUser> UserManager,  IUnitOfWork unitOfWork )
        {
            _userManager = UserManager;
            _unitOfWork = unitOfWork;
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

                await _unitOfWork.Owners.AddAsync(owner);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return owner.Id.ToString();
            }
            else
            {
                throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
