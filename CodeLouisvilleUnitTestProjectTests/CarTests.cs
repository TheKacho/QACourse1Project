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
    }
}
