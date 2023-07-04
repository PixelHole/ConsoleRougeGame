namespace ConsoleGame.Engine.Entities.Components
{
    public class HealthComponent
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public bool Invincible { get; private set; } = false;
        public bool Dead { get; private set; } = false;

        public delegate void death();

        public event death OnDeath;

        
        
        public HealthComponent(int health)
        {
            Health = health;
            MaxHealth = health;
        }
        public HealthComponent(int maxHealth, int health)
        {
            Health = health;
            MaxHealth = maxHealth;
        }
        public HealthComponent(int maxHealth, int health, bool invincible)
        {
            Health = health;
            MaxHealth = maxHealth;
            Invincible = invincible;
        }
        
        

        public void TakeDamage(int damage)
        {
            if(Invincible || Dead) return;
            
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                Dead = true;
                OnDeath.Invoke();
            }
        }

        public void Heal(int amount, bool overHeal)
        {
            if (Health + amount > MaxHealth && !overHeal)
            {
                Health = MaxHealth;
                return;
            }

            Health += amount;
        }
    }
}