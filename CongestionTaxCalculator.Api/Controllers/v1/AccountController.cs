using Microsoft.AspNetCore.Mvc;
using CongestionTaxCalculator.Application.Contracts.Identity;
using CongestionTaxCalculator.Application.Models.Identity;

namespace CongestionTaxCalculator.Api.Controllers.v1
{
    [ApiVersion("1", Deprecated = false)]
    public class AccountController : BaseController
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await authService.Login(request));
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterationRequest request)
        {
            return Ok(await authService.Register(request));
        }

    }
}
