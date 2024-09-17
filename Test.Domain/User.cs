using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class User:BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Family { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }  // مسیر عکس
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
    }
}
