using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Application.DTOs;
using Test.Application.DTOs.Common;
using Test.Domain;

namespace Test.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void CreateUser(UserDto userDto)
        {
            var user = new User()
            {
                UserId = userDto.UserId,
                Name = userDto.Name,
                Family = userDto.Family,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address,
                Photo = userDto.Photo,  // مسیر عکس
                CityName = userDto.CityName,
                ProvinceName = userDto.ProvinceName
            };

            _userRepository.Add(user);

        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShowUserDto>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            
            var userDtos = _mapper.Map<List<ShowUserDto>>(users);  // مپ کردن کاربران به DTOها
            return userDtos;

        }

        public void UpdateUser(int userId, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
