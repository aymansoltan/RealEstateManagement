

namespace RealEstateManagement.Application.Features.Owners.Command.RegisterOwner
{
    public class RegisterOwnerCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
