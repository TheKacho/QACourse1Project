using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTests
    {

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle();
            //act

            //assert
            using (new AssertionScope())
            {
                vehicle.Model.Should().Be("");
                vehicle.Make.Should().Be("");
                vehicle.NumberOfTires.Should().Be(0);
                vehicle.GasTankCapacity.Should().Be(0);
                vehicle.MilesPerGallon.Should().Be(0);
                vehicle.Should().NotBeNull();
            }        
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Yaris", 30);
            //act

            //assert
            Assert.True(true, "This car does have a maker.");
            vehicle.Should().Be(vehicle);

        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 15, "Dodge", "Stratus", 30);
            //act
            vehicle.Drive(30);
            vehicle.AddGas();
            //assert
            vehicle.GasLevel.Should().Be("100%");
        }

        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
            Vehicle vehicle = new Vehicle(4, 15, "Audi", "Quattro", 30);
          
            vehicle.AddGas();
            vehicle.Drive(90);

            vehicle.GasLevel.Should().Be("80%");
            
        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Tundra", 30);
            //act
            vehicle.GasLevel.Should().Be("0%");
            
            Action gasTest = () => vehicle.AddGas(40);
            //assert
            //act.Should().Throw<GasOverfillException>();
            //vehicle.GasLevel.Should().Be("100%");
            gasTest.Should().Throw<GasOverfillException>();
        }

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("0%", 0)]
        [InlineData("25%", 2.5)]
        [InlineData("50%", 5)]
        [InlineData("75%", 7.5)]
        [InlineData("100%", 10)]
        public void GasLevelPercentageIsCorrectForAmountOfGas(string gasTankPercent, float gasBeAdd)
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Subaru", "Outback", 30);
            //act
            vehicle.AddGas(gasBeAdd);
            //assert
            vehicle.GasLevel.Should().Be(gasTankPercent);
        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string “Cannot drive, out of gas.”.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string “Cannot drive due to flat tire.”.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */
        //[Theory]
        //[InlineData(1, 0, "Gas tank empty, cannot drive.", false)]
        //[InlineData(1, 5, "One of the tires is flat, cannot drive.", true)]
        [Fact]
        public void DriveWithEmptyGasTank()
        {
            //arrange
            Vehicle vehicle = new Vehicle();

            using (new AssertionScope())
            {
                vehicle.Drive(0);
                vehicle.MilesRemaining.Should().Be(0, because: "Gas tank is empty, cannot drive.");
            }
        }

        [Fact]
        public void DriveWithFlatTire()
        {
            Vehicle vehicle = new Vehicle();

            //act
            vehicle.AddGas();
            vehicle.Drive(100);
            vehicle.flatTire = true;

            //assert
            vehicle.flatTire.Should().Be(true, "Cannot drive due to flat tire");
        }


        //[Fact]
        //public void DriveNegativeTests()
        //{
        //    //arrange
        //    Vehicle vehicle = new Vehicle();
        //    //act

        //    //assert
        //    using (new AssertionScope())
        //    {
        //        vehicle.Drive(0);
        //        vehicle.MilesRemaining.Should().Be(0, because: "Gas tank is empty, cannot drive.");
        //    }

        //}

        //[Theory]
        //[InlineData("MysteryParamValue")]
        //public void DrivePositiveTests(params object[] yourParamsHere)
        //{
        //    //arrange
        //    throw new NotImplementedException();
        //    //act

        //    //assert

        //}

        [Theory]
        [InlineData(0, 0)]
        [InlineData(.333, 10)]
        [InlineData(3.333, 100)]
        public void DrivePositiveTests(double gasUsed, double milesDrove)
        {
            //arrange
            using (new AssertionScope())
            {
                Vehicle vehicle = new Vehicle(4, 10, "Volkswagon", "Beetle", 30);
                double startMiles = vehicle.Mileage;
                double endMiles = vehicle.Mileage;

                Action act = () => vehicle.Drive(milesDrove);

                milesDrove.Should().BeApproximately(gasUsed * vehicle.MilesPerGallon, .01);
                vehicle.GasLevel.Should().Be($"{vehicle.leftoverGas / vehicle.GasTankCapacity}%");
                vehicle.MilesRemaining.Should().BeApproximately(vehicle.leftoverGas * vehicle.MilesPerGallon, .01);
                endMiles.Should().Be(startMiles + milesDrove);

            }
        }
       


        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10 ,"Honda", "Accord", 30);

            //act
            Func<Task> tireReplace = async () => { await vehicle.TestingChangeTireAsync(); };
            
            //assert
            await tireReplace.Should().ThrowAsync<NoTireToChangeException>();
        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 100, "Volkswagon", "Golf", 30);


            //act
            vehicle.testingFlatTire();
            vehicle.flatTire = true;
            await vehicle.TestingChangeTireAsync();

            //assert
            vehicle.flatTire.Should().Be(true);
            
        }

        //BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}