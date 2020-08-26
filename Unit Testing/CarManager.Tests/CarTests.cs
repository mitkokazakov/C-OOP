using NUnit.Framework;
//using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
            //CarManager.Car car = new Car("BMW","E50",7.8,70.0);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfExceptionIsThrownIfMakeIsNullOrEmpty(string expectedRes)
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(expectedRes, "E50", 7.8, 70.0);
            }
            );
        }

        [Test]
        public void CheckIfMakeReturnsRightValue()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            string expectedRes = "BMW";

            string actualRes = car.Make;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfExceptionIsThrownIfModelIsNullOrEmpty(string expectedRes)
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", expectedRes, 7.8, 70.0);
            }
            );
        }

        [Test]
        public void CheckIfModelReturnsRightValue()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            string expectedRes = "E50";

            string actualRes = car.Model;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [Test]
        public void CheckIfExceptionIsThrownIfFuelConsIsNegative()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "E50", -9, 70.0);
            }
            );
        }

        [Test]
        public void CheckIfFuelConsReturnsRightValue()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            double expectedRes = 7.8;

            double actualRes = car.FuelConsumption;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [Test]
        public void CheckIfExceptionIsThrownIfFuelCapacityIsNegative()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "E50", 7.8, -1);
            }
            );
        }

        [Test]
        public void CheckIfExceptionIsThrownIfFuelCapacityIsZero()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "E50", 7.8, 0.0);
            }
            );
        }

        [Test]
        public void CheckIfFuelCapacityReturnsRightValue()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            double expectedRes = 70.0;

            double actualRes = car.FuelCapacity;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [Test]
        public void CheckIfExceptionIsThrownIfFuelToRefuelIsNegative()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-8.9);
            }
            );
        }

        [Test]
        public void CheckIfExceptionIsThrownIfFuelToRefuelIsZero()
        {
            Car car = new Car("BMW", "E50", 7.8, 70.0);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0.0);
            }
            );
        }

        [Test]
        public void CheckIfExceptionIsThrownIfYouDoNotHaveEnoughFuel()
        {
            Car car = new Car("BMW", "E50", 7.8, 5.0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(100.00);
            }
            );
        }

        [Test]
        public void CheckIfFuelAmountReturnsRightValue()
        {
            Car car = new Car("BMW", "E50", 5.0, 70.0);
            car.Refuel(5.0);

            double expectedRes = 5.0;

            double actualRes = car.FuelAmount;

            Assert.AreEqual(expectedRes, actualRes);
        }

        [Test]
        public void CheckIfDriveMethodWorkCorrectly()
        {
            Car car = new Car("BMW", "E50", 15.0, 50.0);

            car.Refuel(10);
            car.Drive(10);

            double exp = 8.5;

            Assert.AreEqual(exp,car.FuelAmount);

            
        }
    }
}