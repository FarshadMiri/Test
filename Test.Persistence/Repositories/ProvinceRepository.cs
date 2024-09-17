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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly TestDbContext _context;
        public ProvinceRepository(TestDbContext context)
        {
            _context = context; 
        }
        public async Task<List<Province>>  GetAllProvinces()
        {
           return await _context.Provinces.ToListAsync();
        }
    }
}
