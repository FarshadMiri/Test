using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Application.Services
{
    public interface ICityService
    {
        List<City> GetAllCities();
       List<City> GetCityByProvinceId(int provinceId);
    }
}
