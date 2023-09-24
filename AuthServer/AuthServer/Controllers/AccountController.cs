using AuthServer.Dtos;
using AuthServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterRequest request)
        {
            var response = await _accountService.UserRegisterAsync(request);
            return Ok(response);
        }
    }
}
