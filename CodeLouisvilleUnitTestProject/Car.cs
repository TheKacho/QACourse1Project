using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        private HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
        };

        public int NumberOfPassenger { get; private set; }
        public Car()
            : this(0, "", "", 0)
        { }

        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
        {
            NumberOfTires = 4;
            GasTankCapacity = gasTankCapacity;
            Make = make;
            Model = model;
            MilesPerGallon = milesPerGallon;
        }

        public async Task<bool> IsValidModelForMakeAsync()
        {
            string locatepoint = $"vehicles/getmodelsfromale/{base.Make}?format.json";
            string response = await _client.GetStringAsync(locatepoint);
            CarRootRespond resObject = JsonSerializer.Deserialize<CarRootRespond>(response);
            List<Result> models = resObject.Results.ToList();
            bool isValid = models.Any(x => x.Model_Name == base.Model);
            // it should return valid
            return isValid;
        }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            if (year < 1995) throw new ArgumentException("Cannot find data on any car models prior to 1995.");
            else
            {
                //pings the api for a list of information based on models post 1995
                //it will then gather based data into a json format file
                //if it doesnt then exception error is raised saying it cannot find data before 1995

                string locatepoint = $"vehicles/getmodelsformakeyear/make/{base.Make}/modelyear/{year}?format=json";
                string response = await _client.GetStringAsync(locatepoint);
                CarRootRespond resObject = JsonSerializer.Deserialize<CarRootRespond>(response);
                List<Result> models = resObject.Results.ToList();
                bool isValid = models.Any(x => x.Model_Name == base.Model);
                return isValid;
            }
        }

        public void AddPassengers(int passengers)
        {
            if (passengers > 0)
            {
                NumberOfPassenger += passengers;
                base.MilesPerGallon -= passengers * 0.2;
                //the more the passengers in the vehicle
                //the less miles per gallon it will count
            }

        
        }
        public void RemovePassengers(int passengers)
        {
            if (passengers > 0)
            {
                int removedPassengers = passengers;
                if (passengers > NumberOfPassenger)
                {
                   removedPassengers = NumberOfPassenger;
                }
                NumberOfPassenger -= removedPassengers;
                base.MilesPerGallon += removedPassengers * 0.2;

            }

        }
    }
}
