using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Domain;

namespace Test.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public List<City> GetAllCities()
        {
            return _cityRepository.GetAllCity();
        }

        public List<City> GetCityByProvinceId(int provinceId)
        {
            return _cityRepository.GetCityByProvinceId(provinceId);
        }
    }
}
