namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CheckIfConstruuctorInitializeCorrectly()
        {
            int expCapacity = 5;
            int expCount = 0;

            RobotManager robotManager = new RobotManager(5);

            int actCapacity = robotManager.Capacity;
            int actCount = robotManager.Count;

            Assert.AreEqual(expCapacity,actCapacity);
            Assert.AreEqual(expCount,actCount);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenCapacityValueIsBelowZero()
        {
          
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-2);
            });
        }

        [Test]
        public void CheckIfAddMethodWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);

            int expCount = 1;

            robotManager.Add(robot);

            int actCount = robotManager.Count;

            Assert.AreEqual(expCount,actCount);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenExistRobotIsTryingToAdd()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenCapacityIsNotEnough()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Test", 20);
            Robot robot1 = new Robot("Test1", 20);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot1);
            });
        }

        [Test]
        public void CheckIfRemoveMethodWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);
            Robot robot1 = new Robot("Test1", 20);

            int expCount = 1;

            robotManager.Add(robot);
            robotManager.Add(robot1);

            robotManager.Remove("Test");

            int actCount = robotManager.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenNameDoesntExist()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Test", 20);
            

            robotManager.Add(robot);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Mitko");
            });
        }

        [Test]
        public void CheckIfWorkMethodWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);
            

            int expBattery = 10;

            robotManager.Add(robot);
            robotManager.Work("Test","M",10);
        
            int actBattery = robot.Battery;

            Assert.AreEqual(expBattery, actBattery);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenRobotNameDoesNotExistInWorkMethod()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Test1", "M", 10);
            });

        }

        [Test]
        public void CheckIfExceptionWasThrownWhenBatteryLevelIsLessThanBatteryusage()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Test1", "M", 30);
            });

        }

        [Test]
        public void CheckIfChargeMethodWorksCorrectly()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);


            int expBattery = 20;

            robotManager.Add(robot);
            robotManager.Work("Test", "M", 10);
            robotManager.Charge("Test");

            int actBattery = robot.Battery;

            Assert.AreEqual(expBattery, actBattery);
        }

        [Test]
        public void CheckIfExceptionWasThrownWhenRobotNameDoesNotExistInChargeMethod()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot = new Robot("Test", 20);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("MM");
            });

        }
    }
}
