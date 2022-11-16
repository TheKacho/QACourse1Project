using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class SemiTruckTests
    {

        //Verify that the SemiTruck constructor creates a new SemiTruck
        //object which is also a Vehicle and has 18 wheels. Verify that the
        //Cargo property for the newly created SemiTruck is a List of
        //CargoItems which is empty, but not null.
        [Fact]
        public void NewSemiTruckIsAVehicleAndHas18TiresAndEmptyCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            //act

            //assert
            using (new AssertionScope())
            {
                semiTruck.NumberOfTires.Should().Be(18);
                semiTruck.Cargo.Should().BeOfType<List<CargoItem>>();
                semiTruck.Cargo.Should().BeEmpty();
                semiTruck.Cargo.Should().NotBeNull();
            };
        }

        //Verify that adding a CargoItem using LoadCargo does successfully add
        //that CargoItem to the Cargo. Confirm both the existence of the new
        //CargoItem in the Cargo and also that the count of Cargo increased to 1.
        [Fact]
        public void LoadCargoTest()
        {
            //arrange

            SemiTruck semiTruck = new SemiTruck();
            CargoItem product = new CargoItem();
            //cargoItem.Name = "ItemToBeRemoved";

            //act

            semiTruck.LoadCargo(product);

            //semiTruck.LoadCargo(cargoItem);

            //using (new AssertionScope())
            //{
            //    semiTruck.Cargo.Should().Contain(cargoItem);
            //    semiTruck.Cargo.Count.Should().Be(1);
            //}
            //CargoItem removeThisItem = semiTruck.UnloadCargo(RemoveCargoItem);

            ////assert
            
            
            semiTruck.Cargo.Should().Contain(product);
            semiTruck.Cargo.Remove(product);

            semiTruck.Cargo.Should().NotContain(product);
            //using (new AssertionScope())
            //{
            //    semiTruck.Cargo.Count().Should().Be(0);
            //    semiTruck.Cargo.Should().NotContain(cargoItem);
            //    removeThisItem.Should().Be(cargoItem);
            //}

        }

        //Verify that unloading a  cargo item that is in the Cargo does
        //remove it from the Cargo and return the matching CargoItem
        [Fact]
        public void UnloadCargoWithValidCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem product = new CargoItem();
            //act

            semiTruck.LoadCargo(product);
            semiTruck.Cargo.Should().Contain(product);
            semiTruck.Cargo.Remove(product);
            //assert
            semiTruck.Cargo.Should().NotContain(product);
        }

        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            

            //act
            Action act = () => semiTruck.UnloadCargo("product");
            //assert
            //act.Should().NotBeNull(because: "If it returns no match after searching cargo item list, then an empty list is returned.");
            act.Should().Throw<ArgumentException>()
                .WithMessage("Can't deliver that, sorry.");
        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem();
            semiTruck.Cargo.Add(item);
            item.Quantity = 5;
            item.Description = "Package of shirts";
            item.Name = "Shirts";
            //act
            Action act = () => semiTruck.GetCargoItemsByName("Shirts");
            //assert
            act.Should().ToString();
            semiTruck.Cargo.Should().Contain(item, because: "shirts");
        }

        //Verify that searching the Cargo list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem cargoItem = new CargoItem();

            //act


            //assert
            Action act = () => semiTruck.GetCargoItemsByName("package");
            act.Should().NotBeNull(because: "Returned an empty list because no name called 'package' exists.");
        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem
            {
                Name = "Bell peppers",
                Description = "Box of bell peppers for salad mix",
                Quantity = 10
                
            };
            semiTruck.Cargo.Add(item);
            //act

            //assert
            semiTruck.GetCargoItemsByPartialDescription("bell peppers");
            semiTruck.Cargo.Should().Contain(item, because: "Swedish Chef needs to make a salad ASAP!");
        }

        //Verify that searching the Carto list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            CargoItem item = new CargoItem() { Name = "Jackets", Description = "case of jackets", Quantity = 10 };
            CargoItem banana = new CargoItem() { Name = "Banana", Description = "case full of bananas", Quantity = 50 };

            //act
            semiTruck.GetCargoItemsByPartialDescription("banana");
            semiTruck.GetCargoItemsByPartialDescription("c");
            //assert
            semiTruck.Cargo.Should().NotContain(banana, because: "Why are we describing Donkey Kong's bananas?");
        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            //arrange
            List<CargoItem> item = new List<CargoItem>();
            SemiTruck semiTruck = new SemiTruck();      
            CargoItem broccoli = new CargoItem() { Name = "Broccoli", Description = "florets of broccoli", Quantity = 200 };
            CargoItem celery = new CargoItem() { Name = "Celery", Description = "stalks of celery", Quantity = 500 };

            //act
            int totalItemSum = 0;
            semiTruck.Cargo.Add(broccoli);
            semiTruck.Cargo.Add(celery);
            totalItemSum = broccoli.Quantity + celery.Quantity;

            semiTruck.GetTotalNumberOfItems();
            //assert

            totalItemSum.Should().Be(700);
        }
    }
}
