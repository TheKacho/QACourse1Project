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

        
    }
}
