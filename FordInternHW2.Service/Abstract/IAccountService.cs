using FordInternHW2.Base.Response;
using FordInternHW2.Data.Model;
using FordInternHW2.Dto.Dto;
using FordInternHW2.Service.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Abstract
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        BaseResponse<AccountDto> GetByUsername(string username);
    }
}
