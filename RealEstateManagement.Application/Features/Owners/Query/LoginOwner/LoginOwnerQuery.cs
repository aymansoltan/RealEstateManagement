
namespace RealEstateManagement.Application.Features.Owners.Query.LoginOwner
{
    public class LoginOwnerQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
