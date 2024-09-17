using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Application.Contract.Persistence
{
    public interface ICityRepository
    {
       List<City> GetAllCity();
      
         List<City> GetCityByProvinceId(int provinceid);

    }
}
