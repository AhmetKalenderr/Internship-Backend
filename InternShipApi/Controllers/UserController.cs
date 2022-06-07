using AutoMapper;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserManager userManager;
        public UserController(IMapper mapper, IUserManager userManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost("addUser")]
        public async Task<Result<string>> AddUser([FromBody] UserDTO userDto)
        {
            return await userManager.AddUser(mapper.Map(userDto, new User()));
        }

        [HttpPost("loginUser")]
        public async Task<Result<string>> LoginUser([FromBody] LoginUser user)
        {

            if (userManager.LoginUser(user).Result.Success)
            {
                return await userManager.LoginUser(user);

            }
            else
            {
                Response.StatusCode = 401;
                return await userManager.LoginUser(user);
            }
        }

        [HttpPost("getusersfromapp")]

        public async Task<Result<List<UserFromApp>>> GetUserFromApp(int id)
        {
            return await userManager.GetUsersFromApp(id);
        }

        

    
    }
}
