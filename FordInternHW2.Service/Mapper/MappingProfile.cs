using AutoMapper;
using FordInternHW2.Data.Model;
using FordInternHW2.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

        }
    }
}
