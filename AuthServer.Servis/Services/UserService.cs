using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Servis.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserAppDTO>> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = new UserApp
            {
                Email = createUserDTO.Email,
                UserName = createUserDTO.UserName,
            };

            var result = await _userManager.CreateAsync(user, createUserDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDTO>.Fail(new ErrorDTO(errors, true), 400);
            }

            var userObj = ObjectMapper.Mapper.Map<UserAppDTO>(user);

            return Response<UserAppDTO>.Success(userObj, 200);
        }

        public async Task<Response<UserAppDTO>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<UserAppDTO>.Fail("UserName not found", 404,true);
            }

            var userObj = ObjectMapper.Mapper.Map<UserAppDTO>(user);

            return Response<UserAppDTO>.Success(userObj, 200);
        }
    }
}
