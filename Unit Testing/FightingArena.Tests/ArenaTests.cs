//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior firstWarr;
        private Warrior secondWarr;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.firstWarr = new Warrior("Koko", 5, 40);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void CheckIfEnrollMethodAddSuccesfulyWarrior()
        {
            this.arena.Enroll(firstWarr);

            Assert.That(this.arena.Warriors, Has.Member(firstWarr));
        }

        [Test]
        public void CheckIfExceptionIsThrownIfTwoSameWarriorsTryingToAdd()
        {
            this.arena.Enroll(firstWarr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(firstWarr);
            });
        }
        [Test]
        public void CheckIfExceptionIsThrownIfAttackerNameMissing()
        {
            string attackerName = "Ceco";
            string defenderName = "misho";

            this.arena.Enroll(firstWarr);

            

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attackerName, defenderName);
            });

        }
        [Test]
        public void CheckIfExceptionIsThrownIfDefenderNameMissing()
        {
            this.secondWarr = new Warrior("Bojko", 40, 50);

            string attackerName = "Koko";
            string defenderName = "Petko";

            this.arena.Enroll(firstWarr);
            this.arena.Enroll(secondWarr);


            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attackerName, defenderName);
            });
        }
    }
}
