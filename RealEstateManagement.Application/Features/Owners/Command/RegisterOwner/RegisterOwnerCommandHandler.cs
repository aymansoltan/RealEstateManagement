

global using Microsoft.AspNetCore.Identity;

namespace RealEstateManagement.Application.Features.Owners.Command.RegisterOwner
{
    public class RegisterOwnerCommandHandler : IRequestHandler<RegisterOwnerCommand , string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterOwnerCommandHandler(UserManager<IdentityUser> UserManager ,  IGenericRepository<Owner> ownerRepository , IUnitOfWork unitOfWork )
        {
            _userManager = UserManager;
            _ownerRepository = ownerRepository;
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

            if (result.Succeeded)
            {
                var owner = new Owner
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    IdentityUserId = identityUser.Id
                };

                await _ownerRepository.AddAsync(owner);
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
