using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Application.Services
{
    
    public interface IProvinceService
    {
        Task<List<Province>> GetAllProvinces();
        Task<Province> GetProvinceById(int id);

    }
}
