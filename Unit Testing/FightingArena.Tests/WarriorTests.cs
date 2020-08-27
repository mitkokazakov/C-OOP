//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIffConstructorWorksCorrectly()
        {
            string expName = "Mitko";
            int expDamage = 10;
            int expHP = 40;

            Warrior warrior = new Warrior(expName,expDamage,expHP);

            string actName = warrior.Name;
            int actDamage = warrior.Damage;
            int actHP = warrior.HP;

            Assert.AreEqual(expName,actName);
            Assert.AreEqual(expDamage,actDamage);
            Assert.AreEqual(expHP,actHP);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestIfNameIsValid(string expName)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Warrior warrior = new Warrior(expName, 10, 20);
           }
            );
        }

        [TestCase(0)]
        [TestCase(-1)]
        
        public void TestIfDamageIsValid(int expDamage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Mitko", expDamage, 20);
            }
            );
        }

        [Test]
        public void TestIfThrownExceptionIfHPIsNegative()
        {
            

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Mitko", 2, -3);
            }
            );
        }
        [TestCase(25)]
        [TestCase(30)]
        public void CheckIdExceptionWasThrownWhenAttackerHPIsLower(int expHP)
        {
            Warrior attacker = new Warrior("Mitko",5,expHP);
            Warrior defender = new Warrior("Nasko",5,35);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [TestCase(25)]
        [TestCase(30)]
        public void CheckIdExceptionWasThrownWhenDefenderHPIsLower(int expHP)
        {
            Warrior attacker = new Warrior("Mitko", 5, 32);
            Warrior defender = new Warrior("Nasko", 5, expHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void CheckIdExceptionWasThrownWhenAttackerHPIsLowerThanDefenderDamage()
        {
            Warrior attacker = new Warrior("Mitko", 5, 32);
            Warrior defender = new Warrior("Nasko", 35, 36);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void CheckIfAttackMethodWorksCorrectly()
        {
            Warrior attacker = new Warrior("Mitko", 50, 50);
            Warrior defender = new Warrior("Nasko", 40, 40);

            int expRes = 10;

            attacker.Attack(defender);

            int actHP = attacker.HP;
            Assert.AreEqual(expRes,actHP);
            
        }

        [Test]
        public void CheckIfAttackMethodWorksCorrectlyForDefenderHP()
        {
            Warrior attacker = new Warrior("Mitko", 50, 50);
            Warrior defender = new Warrior("Nasko", 40, 40);

            int expRes = 0;

            attacker.Attack(defender);

            int actHP = defender.HP;
            Assert.AreEqual(expRes, actHP);

        }

        [Test]
        public void CheckIfAttackMethodWorksCorrectlyForDefenderHPWithDifferentValues()
        {
            Warrior attacker = new Warrior("Mitko", 40, 50);
            Warrior defender = new Warrior("Nasko", 40, 40);

            int expRes = 0;

            attacker.Attack(defender);

            int actHP = defender.HP;
            Assert.AreEqual(expRes, actHP);

        }

        [Test]
        public void CheckIfAttackMethodWorksCorrectlyForDefenderHPWithDifferentValues1()
        {
            Warrior attacker = new Warrior("Mitko", 35, 50);
            Warrior defender = new Warrior("Nasko", 40, 40);

            int expRes = 5;

            attacker.Attack(defender);

            int actHP = defender.HP;
            Assert.AreEqual(expRes, actHP);

        }
    }
}