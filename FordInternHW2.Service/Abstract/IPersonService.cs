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
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
    }
}
