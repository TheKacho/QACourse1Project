using Newtonsoft.Json;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        string baseUrl = "https://vpic.nhtsa.dot.gov/api/";
        private HttpClient client;
        public string CarMake => Make;
        public string CarModel => Model;

        public new int NumberOfTires = 4;
        public Car()
            : this(0, "", "", 0)
        {

        }

        public Car(double gasTankCap, string make, string model, double milesPerGallon)
        {
            GasTankCapacity = gasTankCap;
            make = Make;
            model = Model;
            MilesPerGallon = milesPerGallon;
        }

        //this pings the api to get list of valid car models
        //and lists them to a json format file
        public async Task<bool> IsValidModelForMakeAsync()
        {
            bool isValidForMake = false;
            try
            {
                var getUrl = $"{client.BaseAddress}/vehicles/GetModelsForMake/{this.Make}?format=json";
                var response = await client.GetAsync(getUrl);
                var responseMessage = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

                CarModelMakeRoot CarApiInfo = JsonConvert.DeserializeObject<CarModelMakeRoot>(responseMessage);

                for (int i = 0; i < CarApiInfo.Status.Count; i++)
                {
                    if (CarApiInfo.Status[i].ModelName == this.Model)
                    {
                        isValidForMake = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API response failed to get Model and Make specs", ex);
                return false;
            }
            return isValidForMake;
        }

        // this pings the api to get info on make/model after 1995
        public async Task<bool> IsModelMadePost1995Async(int year)
        {
            bool isModelMadePost1995 = false;
            if (year < 1995)
            {
                throw new ArgumentException("Cannot find any cars made before 1995.");
            }
            try
            {
                var getUrl = $"{client.BaseAddress}/vehicles/GetModelsForMakeYear/make/{this.Make}/modelyear/{year}/format=json";
                var response = await client.GetAsync(getUrl);
                var responseMessage = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                List<CarApiInfo> carApiInfo = JsonConvert.DeserializeObject<List<CarApiInfo>>(responseMessage);
                for (int i = 0; i < carApiInfo.Count; i++)
                {
                    if (carApiInfo[i].ModelName == this.Model)
                    {
                        isModelMadePost1995 = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API call fail: There is no info of model's make or year.", ex);
            }
            return isModelMadePost1995;
        }
            //passengers to add
            //more passengers means more fuel is spent by 0.2 MPG
            public void AddPassengers(int numOfPassengersToAdd)
            {
                NumberOfPassengers += numOfPassengersToAdd;
                MilesPerGallon -= (NumberOfPassengers * 0.2);
                if (MilesPerGallon < 0)
                {
                    MilesPerGallon = 0;
                }
            }
        
            //passengers to remove
            //less passengers means less fuel spent by 0.2 MPG
            public void RemovePassengers(int numOfPasssengersToRemove)
            {
                if (NumberOfPassengers > numOfPasssengersToRemove)
                {
                    numOfPasssengersToRemove = NumberOfPassengers;
                }
                NumberOfPassengers -= numOfPasssengersToRemove;
                MilesPerGallon -= (numOfPasssengersToRemove * 0.2);
            }
    } 
}

