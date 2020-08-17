namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            string expName = "Test";
            int expCapacity = 5;
            int expCount = 0;

            Aquarium aquarium = new Aquarium(expName,expCapacity);

            string actName = aquarium.Name;
            int actCapacity = aquarium.Capacity;
            int actCount = aquarium.Count;

            Assert.AreEqual(expName, actName);
            Assert.AreEqual(expCapacity, actCapacity);
            Assert.AreEqual(expCount, actCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfExceptionWasThrownWhenNameIsNullOrEmpty(string expName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(expName,5);
            });
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Mitko", -8);
            });
        }

        [Test]

        public void CheckIfAddMethodWorksCorrectly()
        {
            Fish fish = new Fish("test");

            Aquarium aquarium = new Aquarium("Test",2);

            aquarium.Add(fish);

            int expCount = 1;
            int actCount = aquarium.Count;
            Assert.AreEqual(expCount,actCount);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenCapacityIsLess()
        {
            Fish fish = new Fish("test");
            Aquarium aquarium = new Aquarium("Test", 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void CheckIfRemoveMethodWorksCorrectly()
        {
            Fish fish = new Fish("test");
            Fish fish1 = new Fish("test1");

            Aquarium aquarium = new Aquarium("Test", 4);

            aquarium.Add(fish);
            aquarium.Add(fish1);

            int expCount = 1;

            aquarium.RemoveFish("test1");

            int actCount = aquarium.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenNameNotFound()
        {
            Fish fish = new Fish("test");

            Aquarium aquarium = new Aquarium("Test", 8);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Mitko");
            });
        }

        [Test]
        public void CheckIfSelleMethodWorksCorrectly()
        {
            Fish fish = new Fish("test");
            

            Aquarium aquarium = new Aquarium("Test", 4);

            aquarium.Add(fish);

            Fish expectedFish = aquarium.SellFish("test");

            bool expRes = false;

            Assert.AreEqual(expRes,expectedFish.Available);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenNameNotFoundInSellMethod()
        {
            Fish fish = new Fish("test");

            Aquarium aquarium = new Aquarium("Test", 8);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Mitko");
            });
        }


        [Test]
        public void CheckIfreportMethodWorksCorrectly()
        {
            Fish fish = new Fish("test");
            Fish fish1 = new Fish("test1");

            Aquarium aquarium = new Aquarium("Test", 8);

            aquarium.Add(fish);
            aquarium.Add(fish1);

            string expReport = $"Fish available at Test: test, test1";

            Assert.AreEqual(expReport,aquarium.Report());
        }




    }
}
