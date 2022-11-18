using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FluentAssertions;
using CodeLouisvilleUnitTestProject;
using Xunit;
using FluentAssertions.Execution;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTests
    {
        [Fact]
        public void CarConstructorWithNoParams()
        {
            var car = new Car();
            using (new AssertionScope())
            {
                car.Should().NotBeNull();
                car.NumberOfTires.Should().Be(4);
            }
        }

        [Fact]
        public void CarConstructorWithParams()
        {
            var car = new Car(10, "Honda", "Accord", 30);
            using (new AssertionScope())
            {
                car.Should().NotBeNull();
                car.NumberOfTires.Should().Be(4);
                car.Make.Should().Be("Honda");
                car.Model.Should().Be("Accord");
                car.MilesPerGallon.Should().Be(30);
            }
        }

        [Theory]
        [InlineData ("Honda", "Accord", true)]
        [InlineData("Honda", "Camry", false)]
        public async Task ModelValidator(string make, string model, bool expected)
        {
            var car = new Car(10, make, model, 30);
            bool result = await car.IsValidModelForMakeAsync();
            result.Should().Be(expected);
        }

        // if the model and make do not match regardless of year will return false
        [Theory]
        [InlineData("Mazda", "Corolla", 1995, false)]
        [InlineData("Mitsubishi", "Tundra", 2003, false)]
        [InlineData("Honda", "Camry", 1999, false)]
        [InlineData("Subaru", "WRX", 2020, true)]
        [InlineData("Subaru", "WRX", 2000, false)]

        public async Task IsModelMadeInYearAsync(string make, string model, int year, bool expected)
        {
            var car = new Car(10, make, model, 40);
            bool result = await car.WasModelMadeInYearAsync(year);
            result.Should().Be(expected);
        }


        // this next theory tests if each model is made in 1995
        // passes if the car is made in 1995
        // if it is made before 1995, then it raises a system exception message

        [Theory]
        [InlineData ("Honda", "Civic", 1996)]
        [InlineData ("Honda", "Civic", 1995)]
        [InlineData ("Honda", "Civic", 1994)]
        [InlineData ("Honda", "Civic", 1993)]
        public async Task IsModelMadeInOrBeforeYear1995(string make, string model, int year)
        {
            var car = new Car(20, make, model, 40);
            Func<Task> act = async () => { await car.WasModelMadeInYearAsync(year); };
            act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("No data available any models made prior to 1995.");

            //pardon the red squiggle marks, the test should run as intended
        }

        //This theory tests whenever passengers are added to the car model
        //then it should decrease fuel economy by .2 per passenger
        [Theory]
        [InlineData(5, 30, 29.0)]
        [InlineData(4, 30, 29.2)]
        [InlineData(3, 30, 29.4)]
        [InlineData(2, 30, 29.6)]
        [InlineData(1, 30, 29.8)]
        [InlineData(0, 30, 30)]
        public void GetPassengers(int passengers, double mpg, double result)
        {
            var car = new Car(15, "Toyota", "Camry", mpg);
            car.AddPassengers(passengers);
            car.MilesPerGallon.Should().Be(result);
        }

        [Theory]
        [InlineData(5, 30, 29.0)]
        [InlineData(4, 30, 29.2)]
        [InlineData(3, 30, 29.4)]
        [InlineData(2, 30, 29.6)]
        [InlineData(1, 30, 29.8)]
        [InlineData(0, 30, 30)]
        public void GetPassengersAndDropOff(int howMany, double mpg, double result)
        {
            var car = new Car(15, "Toyota", "Camry", mpg);
            car.AddPassengers(howMany);
            car.MilesPerGallon.Should().Be(result);

            //then drop them off at destination 
            //and the mpg should increase back to capacity
            car.RemovePassengers(howMany);
            car.MilesPerGallon.Should().Be(mpg);
        }

        //this theory tests the criteria of removing passengers
        // from each vehicle would increase mpg
        [Theory]
        [InlineData(5, 21, 3, 2, 20.6)]
        [InlineData(5, 21, 5, 0, 21)]
        [InlineData(5, 21, 25, 0, 21)]
        public void RemovePassengers(int passengerInCar, double mpg, int howMany, int passengerLeftOver, double mpgResult)
        {
            var car = new Car(15, "Chevolet", "Impala", mpg);
            car.AddPassengers(passengerInCar);
            car.RemovePassengers(howMany);
            using (new AssertionScope())
            {
                car.NumberOfPassenger.Should().Be(passengerLeftOver);
                car.MilesPerGallon.Should().Be(mpgResult);
            }
        }
    }
}
