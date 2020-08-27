//using ExtendedDatabase;
using NUnit.Framework;
using System;
//using System.Runtime.CompilerServices;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedData;
        private Person person = new Person(5,"Mitaka");
        
        
        [SetUp]
        public void Setup()
        {
            
            //this.extendedData = new ExtendedDatabase.ExtendedDatabase(new Person[] { person});
        }

        [Test]
        public void CheckIfConstruuctorWorksCorrectly()
        {
            Person[] persons = new Person[] { person };

            this.extendedData = new ExtendedDatabase(new Person[] {person});

            int expectedRes = persons.Length;
            int actualRes = this.extendedData.Count;

            Assert.AreEqual(expectedRes,actualRes);
        }
        [Test]
        public void CheckIfExceptionWasTrownWhenNoSpace()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(5,"Viktor");
            }

            

            Assert.Throws<ArgumentException>(() =>
            {
                this.extendedData = new ExtendedDatabase(persons);
            });
        }
        [Test]
        public void CheckIfExceptionWasTrownWhenAddPeople()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, "Viktor"+i);
            }

            this.extendedData = new ExtendedDatabase(persons);


            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedData.Add(new Person(6,"nasko"));
            });
        }
        [Test]
        public void CheckIfExceptionWasThrownWhenAddSamePerson()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person});

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedData.Add(person);
            }
            );
        }
        [Test]
        public void CheckIfExceptionsWasThrownWhenCollectionNull()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person });

            this.extendedData.Remove();

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.extendedData.Remove();
           }
            );
        }

        [Test]
        public void CheckIfExceptionsWasThrownWhenTheNameNull()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person });

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedData.FindByUsername(null);
            }
            );
        }

        [Test]
        public void CheckIfExceptionsWasThrownWhenTheNameMiss()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person });

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedData.FindByUsername("Vanko");
            }
            );
        }

        [Test]
        public void CheckIfExceptionsWasThrownWhenTheIdNegative()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.extendedData.FindById(-9);
            }
            );
        }

        [Test]
        public void CheckIfExceptionsWasThrownWhenTheIdMiss()
        {
            this.extendedData = new ExtendedDatabase(new Person[] { person });

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedData.FindById(7);
            }
            );
        }

    }
}