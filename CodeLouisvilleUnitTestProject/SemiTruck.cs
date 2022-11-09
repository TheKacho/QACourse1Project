﻿using System.Runtime.CompilerServices;
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
        public CargoItem UnloadCargo(string name)
        {
            //YOUR CODE HERE
            if(name != null)
            {
                Cargo[0].Name = name;
                Cargo.RemoveAt(0);
                return Cargo[0];
            }
            else
            {
                throw new ArgumentException();
            }
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
            int cargoSum = Cargo.Count;
            return cargoSum;
        }
    }
}