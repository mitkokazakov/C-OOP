namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ChaeckIfConstructorWorksCorrectly()
        {
            string expName = "Mitaka";
            int expCount = 0;

            Computer computer = new Computer(expName);

            string actName = computer.Name;
            int actCount = computer.Parts.Count;

            Assert.AreEqual(expName, actName);
            Assert.AreEqual(expCount, actCount);
        }

        [Test]

        public void CheckIfAddMethodWorksCorrectly()
        {
            Computer computer = new Computer("Mitaka");

            Part part = new Part("Koko", 12.4m);

            computer.AddPart(part);

            int expCount = 1;

            int actCount = computer.Parts.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]

        public void CheckIfAddMethodWorksCorrectlyNull()
        {
            Computer computer = new Computer("Mitaka");

            Part part = null;


            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(part);

            });
        }

        [Test]

        public void CheckIfTotalPriceMethodWorksCorrectly()
        {
            Computer computer = new Computer("Mitaka");

            Part part = new Part("Koko", 10.0m);
            Part part1 = new Part("Koko1", 10.0m);

            computer.AddPart(part);
            computer.AddPart(part1);

            decimal expPrice = 20.0m;

            decimal actPrice = computer.TotalPrice;

            Assert.AreEqual(expPrice, actPrice);
        }

        [TestCase(null)]
        [TestCase("   ")]
        public void CheckIfExceptionWasThrwonWhenNameIsNullOrWhiteSpace(string expName)
        {


            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(expName);

            });
        }

        [Test]
        public void CheckIfRemoveMethodWoksCorrectly()
        {
            bool expRes = true;

            Computer computer = new Computer("Mitaka");

            Part part = new Part("Koko", 10.0m);

            computer.AddPart(part);

            bool actRes = computer.RemovePart(part);

            Assert.AreEqual(expRes, actRes);
        }

        [Test]
        public void CheckIfRemoveMethodWoksCorrectlyFalse()
        {
            bool expRes = false;

            Computer computer = new Computer("Mitaka");

            Part part = new Part("Koko", 10.0m);

            //computer.AddPart(part);

            bool actRes = computer.RemovePart(part);

            Assert.AreEqual(expRes, actRes);
        }

        //Possible one more test for that the method should return null if part does not exist
        [Test]
        public void CheckIfGetTyypeWorksCorrectly()
        {
            Computer computer = new Computer("Mitaka");

            Part part = new Part("Koko", 10.0m);

            computer.AddPart(part);

            Part expRes = part;

            Part actRes = computer.GetPart("Koko");

            Assert.AreEqual(expRes, actRes);
        }
    }
}