using AuthServer.Core.DTOs;
using SharedLibrary.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDTO>> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<Response<UserAppDTO>> GetUserByNameAsync(string userName);
    }
}
