using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvilleUnitTestProject
{
    internal class CarModelMakeRoot
    {
        public int Count { get; set; }
        public string Description { get; set; }
        public string Criteria { get; set; }
        public List<CarApiInfo> Status { get; set; }
    }
}
