using Test.Domain;

namespace Test.UI.Models.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string ProvinceName { get; set; } // برای ذخیره نام استان
        public string CityName { get; set; } // برای ذخیره نام شهر
        public List<Province> Provinces { get; set; }
        public List<City> Cities { get; set; }


    }
}
