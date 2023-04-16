using FordInternHW2.Base.Response;
using FordInternHW2.Base.Types;
using FordInternHW2.Dto.Dto;
using FordInternHW2.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

namespace FordInternHW2.Controllers
{
    [Route("fordhw2/api/v1.0/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Authorize]
        public async Task<BaseResponse<IEnumerable<AccountDto>>> GetAll()
        {
            Log.Debug("AccountController.GetAll");
            var response = await service.GetAllAsync();
            return response;
        }

        [HttpGet("GetUserDetail")]
        [Authorize]
        public async Task<BaseResponse<AccountDto>> GetByUsername()
        {
            Log.Debug("AccountController.GetByUsername");
            var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var response = await service.GetByIdAsync(int.Parse(id));
            return response;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<BaseResponse<AccountDto>> GetById([FromRoute] int id)
        {
            Log.Debug("AccountController.GetById");
            var response = await service.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<BaseResponse<bool>> Post([FromBody] AccountDto request)
        {
            Log.Debug("AccountController.Post");
            var response = await service.PostAsync(request);
            return response;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<BaseResponse<bool>> Put(int id, [FromBody] AccountDto request)
        {
            Log.Debug("AccountController.Put");
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            
            if (accountId.Equals(id.ToString())) {
                var response = await service.Put(id, request);
                return response;
            } else
            {
                return new BaseResponse<bool>("Not Permitted");
            }
    
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            Log.Debug("AccountController.Delete");
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            if (accountId.Equals(id.ToString()))
            {
                var response = await service.Delete(id);
                return response;
            } else
            {
                return new BaseResponse<bool>("Not Permitted");
            }
            
        }
    }
}
