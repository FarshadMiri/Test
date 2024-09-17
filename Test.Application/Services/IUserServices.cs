using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs;
using Test.Domain;

namespace Test.Application.Services
{
    public interface IUserServices
    {
        Task< IEnumerable<User> >GetUsers();
        void CreateUser(UserDto userDto);
        void UpdateUser(int userId, UserDto userDto);
        void DeleteUser(int userId);
    }
}
