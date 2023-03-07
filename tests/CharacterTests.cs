namespace RpgCombatStarter.Tests
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void Character_WhenCreated_HasStartingHealth()
        {
            var character = new Character();
            Assert.AreEqual(Character.StartingHealth, character.Health);
        }

        [TestMethod]
        public void Character_WhenCreated_HasStartingLevel()
        {
            var character = new Character();
            Assert.AreEqual(Character.StartingLevel, character.Level);
        }

        [TestMethod]
        public void Character_WhenCreated_IsAlive()
        {
            var character = new Character();
            Assert.IsTrue(character.IsAlive);
        }

        [TestMethod]
        public void Character_WhenAttacked_LosesHealth()
        {
            var attacker = new Character();
            var target = new Character();
            attacker.Attack(target);
            Assert.AreNotEqual(Character.StartingHealth, target.Health);
        }

        [TestMethod]
        public void Character_WhenHealed_GainsHealth()
        {
            var healer = new Character();
            var target = new Character();

            healer.Attack(target);
            var targetHealthAfterAttacked = target.Health;

            healer.Heal(target);
            var targetHealthAfterHealing = target.Health;

            Assert.AreNotEqual(targetHealthAfterAttacked, targetHealthAfterHealing);
        }

        [TestMethod]
        public void Character_WhenDead_CannotBeHealed()
        {
            var healer = new Character();
            var target = new Character();

            while (target.IsAlive)
            {
                healer.Attack(target);
            }

            Assert.ThrowsException<InvalidOperationException>(() => healer.Heal(target));
        }

        [TestMethod]
        public void Character_WhenHealder_HealthDoesNotExcceed1000()
        {
            var healer = new Character();
            var target = new Character();

            healer.Attack(target);
            healer.Heal(target);
            healer.Heal(target);

            Assert.AreEqual(1000, target.Health);
        }
    }
}