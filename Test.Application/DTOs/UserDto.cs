using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Common;
using Test.Domain;

namespace Test.Application.DTOs
{
    public class UserDto:BaseEntityDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
         public string Photo {  get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
      


    }
}
