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
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IAccountService accountService;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IGenericRepository<Person> genericRepository) : base(unitOfWork, mapper, genericRepository)
        {
            this.accountService = accountService;
        }

        public async override Task<BaseResponse<bool>> PostAsync(PersonDto insertResource)
        {
            if (insertResource.DateOfBirth < DateTime.UtcNow.AddYears(18))
            {
                return new BaseResponse<bool>("DateOfBirth was incorrect");
            }

            var response = accountService.GetByUsername(insertResource.Email);
            if (!response.Success)
            {
                return new BaseResponse<bool>(response.Message);
            }

            AccountDto account = response.Response;

            return await base.PostAsync(insertResource);
        }
    }
}
