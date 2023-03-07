namespace RpgCombatStarter
{
    public class Character
    {
        public const int StartingHealth = 1000;
        public const int StartingLevel = 1;

        public int Health { get; private set; } = StartingHealth;
        public int Level { get; private set; } = StartingLevel;
        public bool IsAlive => Health > 0;

        public void Attack(Character other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (!other.IsAlive)
                throw new InvalidOperationException("Cannot attack a dead character");

            var damage = GetPower();
            other.TakeDamage(damage);
        }

        public void Heal(Character other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (!other.IsAlive)
                throw new InvalidOperationException("Cannot heal a dead character");

            var healingPoints = GetPower();
            other.ReceiveHealing(healingPoints);
        }

        private void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be positive");

            Health = Math.Max(0, Health - damage);
        }

        private void ReceiveHealing(int healing)
        {
            if (healing < 0)
                throw new ArgumentOutOfRangeException(nameof(healing), "Healing must be positive");

            Health = Math.Min(StartingHealth, Health + healing);
        }

        private int GetPower() => Level * 100;
    }
}
