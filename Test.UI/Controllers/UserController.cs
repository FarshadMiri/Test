using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Application.DTOs;
using Test.Application.Services;
using Test.Domain;
using Test.UI.Models.ViewModels.User;

namespace Test.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IProvinceService _provinceServices;
        private readonly ICityService _cityServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IProvinceService provinceService, ICityService cityService, IMapper mapper)
        {
            _userServices = userServices;
            _provinceServices = provinceService;
            _cityServices = cityService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var userDtos = await _userServices.GetUsers();
            var userViewModels = _mapper.Map<List<ShowUserViewModel>>(userDtos); 
             
            

            return View(userViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var provinces = await _provinceServices.GetAllProvinces();
            var model = new CreateUserViewModel
            {
                Provinces = provinces
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string photoPath = null;
                if (model.Photo != null && model.Photo.Length > 0)
                {
                    // تعیین مسیر پوشه و نام یکتا برای فایل
                    var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                    var filePath = Path.Combine(uploadsFolderPath, fileName);

                    // ذخیره فایل در پوشه مشخص شده
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(stream);
                    }

                    // ذخیره مسیر فایل به صورت نسبی
                    photoPath = Path.Combine("uploads", fileName);
                }
                var province = await _provinceServices.GetProvinceById(model.ProvinceId);
                var city = await _cityServices.GetCityByCityIdAsync(model.ProvinceId);

                model.ProvinceName = province.Name;
                model.CityName = city.Name;

                // مپ کردن مدل به DTO و تنظیم مسیر عکس
                var userdto = _mapper.Map<UserDto>(model);
                userdto.Photo = photoPath;



                // ذخیره اطلاعات کاربر در دیتابیس
                _userServices.CreateUser(userdto);

                return RedirectToAction("Index");
            }

            model.Provinces = await _provinceServices.GetAllProvinces();
            model.Cities = _cityServices.GetCityByProvinceId(model.ProvinceId);

            return View(model);
        }
        public JsonResult GetCitiesByProvince(int provinceId)
        {
            var cities = _cityServices.GetCityByProvinceId(provinceId)
                .Select(c => new { cityId = c.CityId, name = c.Name })
                .ToList();
            return Json(cities);
        }
    }
}
