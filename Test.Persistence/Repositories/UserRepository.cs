using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Domain;

namespace Test.Persistence.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        private readonly TestDbContext _context;
        public UserRepository(TestDbContext context):base(context) 
        {
                _context = context;
        }

    }
}
