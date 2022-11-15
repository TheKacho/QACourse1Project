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
        public string MakeName { get; set; }
        [JsonPropertyName("Make_Name")]

        public string ModelName { get; set; }
        [JsonPropertyName("Model_Name")]

        public int MakeID { get; set; }
        [JsonPropertyName("Make_ID")]
    }
}
