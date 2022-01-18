using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDTO loginDTO)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDTO);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public IActionResult ActionResultByClient(ClientLoginDTO clientLoginDTO)
        {
            var result = _authenticationService.CreateTokenByClient(clientLoginDTO);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var result = await _authenticationService.RevokeRefreshTokenAsync(refreshTokenDTO.RefreshToken);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var result = await _authenticationService.CreateTokenByRefreshTokenAsync(refreshTokenDTO.RefreshToken);
            return ActionResultInstance(result);
        }

    }
}
