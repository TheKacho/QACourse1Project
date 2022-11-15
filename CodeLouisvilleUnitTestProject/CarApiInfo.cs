using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeLouisvilleUnitTestProject
{
    public class CarApiInfo
    {
        public string CarMake { get; set; }
        [JsonPropertyName("Car_Make")]

        public string CarModel{ get; set; }
        [JsonPropertyName("Car_Model")]
    }
}
