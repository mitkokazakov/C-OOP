using NUnit.Framework;

using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(new int[] { 1, 2, 3 });
        }

        [Test]
        public void TestIfConstructorWorksCorrectl()
        {
            int[] dataArr = new int[] { 1, 4, 6 };

            this.database = new Database(dataArr);

            int expectedOutput = dataArr.Length;
            int actualResult = this.database.Count;

            Assert.AreEqual(expectedOutput, actualResult);

        }
        [Test]
        public void TestIfThereIsAnyFreeCellsLeft()
        {
            for (int i = 4; i <= 16; i++)
            {
                this.database.Add(i);
            }

            

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            }
                );

        }
        [Test]
        public void TestIfDecreaseCountWhenElementIsRemoved()
        {
            this.database.Remove();

            int expectedResult = 2;

            int actualResult = this.database.Count;

            Assert.AreEqual(expectedResult,actualResult);
        }
        [Test]
        public void TestIfDatabesIsEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                this.database.Remove();
            }

            

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.database.Remove();
           });
        }
        [Test]
        public void TestIfAllElementsAreReturned()
        {
            int[] expected = this.database.Fetch();

            int actual = this.database.Count;

            Assert.AreEqual(expected.Length,actual);
        }
    }
}