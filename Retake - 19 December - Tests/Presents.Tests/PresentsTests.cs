namespace Presents.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]

        public void CheckIfCreateMethodWorksCorrectly()
        {
            Present present = new Present("Dick", 20.0);
            Bag bag = new Bag();


            string expResult = $"Successfully added present Dick.";

            string actRes = bag.Create(present);

            Assert.AreEqual(expResult, actRes);


        }

        [Test]

        public void CheckIfCreateMethodThrowsExceptionsIfNull()
        {
            Present present = null;
            Bag bag = new Bag();


            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });


        }

        [Test]

        public void CheckIfCreateMethodThrowsExceptionsIfAlreadyExist()
        {
            Present present = new Present("Dick", 20.0);
            Bag bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });

        }

        [Test]

        public void CheckIfRemoveMethodReturnTrue()
        {
            bool expRes = true;

            Present present = new Present("Dick", 20.0);
            Bag bag = new Bag();

            bag.Create(present);

            bool actRes = bag.Remove(present);

            Assert.AreEqual(expRes, actRes);
        }

        [Test]

        public void CheckIfRemoveMethodReturnFalse()
        {
            bool expRes = false;

            Present present = new Present("Dick", 20.0);
            Bag bag = new Bag();

            //bag.Create(present);

            bool actRes = bag.Remove(present);

            Assert.AreEqual(expRes, actRes);
        }

        [Test]

        public void CheckIfGetpresentMethodReturnsCorrectResult()
        {
            

            Present present = new Present("Dick", 20.0);
            Present present1 = new Present("Dick1", 10.0);
            Bag bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            Present expRes = present1;
            Present actResult = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expRes, actResult);
        }


        [Test]

        public void CheckIfGetpPesentMethodReturnsCorrectResult()
        {


            Present present = new Present("Dick", 20.0);
            Present present1 = new Present("Dick1", 10.0);
            Bag bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            Present expRes = present1;
            Present actResult = bag.GetPresent("Dick1");

            Assert.AreEqual(expRes, actResult);
        }

        [Test]

        public void CheckIfGetpPesentsMethodReturnsCorrectResult()
        {


            Present present = new Present("Dick", 20.0);
            Present present1 = new Present("Dick1", 10.0);
            Bag bag = new Bag();

            bag.Create(present);
            bag.Create(present1);

            //Present expRes = present1;
            //Present actResult = bag.GetPresent("Dick1");

            int expCount = 2;

            var allPresents = bag.GetPresents();

            int actCount = allPresents.Count;

            Assert.AreEqual(expCount,actCount);
        }
    }
}
