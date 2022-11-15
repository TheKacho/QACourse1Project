using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using static System.Net.WebRequestMethods;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        public int PassengerNumber { get;  private set; }
        string baseUrl = "https://vpic.nhtsa.dot.gov/api/";
        private HttpClient client;


        public Car()
            : this(0, "", "", 0)
        {

        }

        public Car(double gasTankCap, string make, string model, double milesPerGallon)
        {
            GasTankCapacity = gasTankCap;
            Make = make;
            Model = model;
            MilesPerGallon = milesPerGallon;
        }


    }
  
}
