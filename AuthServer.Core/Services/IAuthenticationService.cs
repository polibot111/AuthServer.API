using AuthServer.Core.DTOs;
using SharedLibrary.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDTO>> CreateTokenAsync(LoginDTO loginDto);

        Task<Response<TokenDTO>> CreateTokenByRefreshTokenAsync(string refreshToken);

        Task<Response<NoDataDTO>> RevokeRefreshTokenAsync(string refreshToken);

        Response<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDTO);
    }
}
