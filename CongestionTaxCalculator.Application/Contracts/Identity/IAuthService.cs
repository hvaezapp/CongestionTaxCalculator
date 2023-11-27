using CongestionTaxCalculator.Application.Models.Identity;

namespace CongestionTaxCalculator.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegisterationRequest request);
    }
}
