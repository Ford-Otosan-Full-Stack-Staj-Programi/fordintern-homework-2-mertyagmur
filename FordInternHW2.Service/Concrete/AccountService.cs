using AutoMapper;
using FordInternHW2.Base.Response;
using FordInternHW2.Data.Model;
using FordInternHW2.Data.Repository.Abstract;
using FordInternHW2.Data.UnitOfWork.Abstract;
using FordInternHW2.Dto.Dto;
using FordInternHW2.Service.Abstract;
using FordInternHW2.Service.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Concrete
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IGenericRepository<Account> genericRepository;
        private readonly IMapper mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Account> genericRepository) : base(unitOfWork, mapper, genericRepository)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        public BaseResponse<AccountDto> GetByUsername(string username)
        {
            var account = genericRepository.Where(x => x.UserName == username).FirstOrDefault();
            var mapped = mapper.Map<Account, AccountDto>(account);
            return new BaseResponse<AccountDto>(mapped);
        }

    }
}