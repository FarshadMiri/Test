using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Domain;

namespace Test.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private TestDbContext _context;
        public CityRepository(TestDbContext context)
        {
            _context = context;   
        }
        public List<City> GetAllCity()
        {
            return _context.Cities.ToList();
        }

        public async Task<City> GetCityByCityIdAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public List<City> GetCityByProvinceId(int provinceId)
        {
            return  _context.Cities.Where(c => c.ProvinceId == provinceId).ToList();   
        }
    }
}
