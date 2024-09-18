using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        [ForeignKey("province")]
        public int ProvinceId { get; set; }
        public Province province { get; set; }

    }
}
