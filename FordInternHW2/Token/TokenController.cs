using FordInternHW2.Base.Response;
using FordInternHW2.Dto.Token;
using FordInternHW2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FordInternHW2.Token
{
    [Route("fordhw2/api/v1.0/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;
        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenManagementService.GenerateToken(request);
            return response;
        }


    }

}
