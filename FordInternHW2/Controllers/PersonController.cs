using FordInternHW2.Base.Response;
using FordInternHW2.Base.Types;
using FordInternHW2.Dto.Dto;
using FordInternHW2.Service.Abstract;
using FordInternHW2.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

namespace FordInternHW2.Controllers
{
    [Route("fordhw2/api/v1.0/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;
        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public BaseResponse<List<PersonDto>> GetAll()
        {
            Log.Debug("PersonController.GetAll");
            var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var response = service.Where(p => p.AccountId == id);
            return response;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<BaseResponse<PersonDto>> GetById(int id)
        {
            Log.Debug("PersonController.GetById");
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var response = await service.GetByIdAsync(id);
            if (accountId.Equals(response.Response.AccountId.ToString()))
            {
                var responseNew = await service.GetByIdAsync(id);
                return responseNew;
            } else
            {
                var responseNew = new BaseResponse<PersonDto>("Not permitted");
                return responseNew;
            }
        }

        [HttpPost]
        public async Task<BaseResponse<bool>> Post([FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Post");
            var role = (User.Identity as ClaimsIdentity).FindFirst("Role").Value;
            if (role == Role.Admin)
            {
                var response = await service.PostAsync(request);
                return response;
            }
            else { 
                var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
                request.AccountId = accountId;
                var response = await service.PostAsync(request);
                return response;
            }
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> Put(int id, [FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Put");
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var response = await service.GetByIdAsync(id);
            if (accountId.Equals(response.Response.AccountId.ToString()))
            {
                var responseNew = await service.Put(id, request);
                return responseNew;
            }
            else
            {
                return new BaseResponse<bool>("Not Permitted");
            }
                
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            Log.Debug("PersonController.Delete");
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var response = await service.GetByIdAsync(id);
            if (accountId.Equals(response.Response.AccountId.ToString()))
            {
                var responseNew = await service.Delete(id);
                return responseNew;
            } else
            {
                var responseNew = new BaseResponse<bool>("Not permitted");
                return responseNew;
            }
        }

    }
}
