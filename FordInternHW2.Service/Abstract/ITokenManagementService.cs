using FordInternHW2.Base.Response;
using FordInternHW2.Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Abstract
{
    public interface ITokenManagementService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
    }
}
