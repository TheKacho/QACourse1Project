using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace CodeLouisvilleUnitTestProject
{
    public class SemiTruck : Vehicle
    {
        public List<CargoItem> Cargo { get; private set; }

        /// <summary>
        /// Creates a new SemiTruck that always has 18 Tires
        /// </summary>
        public SemiTruck()
        {
            NumberOfTires = 18;
            Cargo = new List<CargoItem>();
        }
        public SemiTruck(int numberOfTires)
        {
            Cargo = new List<CargoItem>();
            NumberOfTires = numberOfTires;
        }

        /// <summary>
        /// Adds the passed CargoItem to the Cargo
        /// </summary>
        /// <param name="item">The CargoItem to add</param>
        public void LoadCargo(CargoItem item)
        {
            Cargo.Add(item);
        }

        /// <summary>
        /// Attempts to remove the first item with the passed name from the Cargo and return it
        /// </summary>
        /// <param name="name">The name of the CargoItem to attempt to remove</param>
        /// <returns>The removed CargoItem</returns>
        /// <exception cref="ArgumentException">Thrown if no CargoItem in the Cargo matches the passed name</exception>
        public List<CargoItem> UnloadCargo(string name)
        {
            //YOUR CODE HERE
            var RemoveCargoItem = Cargo.FirstOrDefault(CargoItem => CargoItem.Name == name);
            if(name != null)
            {
                Cargo.Remove(RemoveCargoItem);
            }
            else
            {
                throw new ArgumentException();
            }
            return Cargo;
        }

        /// <summary>
        /// Returns all CargoItems with the exact name passed. If no CargoItems have that name, returns an empty List.
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns>A List of CargoItems with the exact name passed</returns>
        public List<CargoItem> GetCargoItemsByName(string name)
        {
            //YOUR CODE HERE
            List<CargoItem> cargoItems = new List<CargoItem>();
            foreach (CargoItem cargoItem in cargoItems)
            {
                cargoItem.Name = name;
            }
            return cargoItems;
        }

        /// <summary>
        ///  Returns all CargoItems who have a description containing the passed description. If no CargoItems have that name, returns an empty list.
        /// </summary>
        /// <param name="description">The partial description to match</param>
        /// <returns>A List of CargoItems with a description containing the passed description</returns>
        public List<CargoItem> GetCargoItemsByPartialDescription(string description)
        {
            //YOUR CODE HERE
            List<CargoItem> cargoItems = new List<CargoItem>();
            foreach(CargoItem cargoItem in cargoItems)
            {
                cargoItem.Description = description;
            }
            return cargoItems;
        }

        /// <summary>
        /// Get the number of total items in the Cargo.
        /// </summary>
        /// <returns>An integer representing the sum of all Quantity properties on all CargoItems</returns>
        public int GetTotalNumberOfItems()
        {
            //YOUR CODE HERE
            //create new list 
            List<CargoItem> cargoItems = new List<CargoItem>();

            //form quantity values to 0 by default
            int quantity = 0;
            int total = 0;
            int subTotal = 0;

            //form the solution in order to add up total sum
            foreach(CargoItem item in cargoItems)
            {
                item.Quantity = quantity;
                subTotal += quantity;
            }
            total = quantity + subTotal;
            return total;
        }
    }
}