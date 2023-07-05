namespace ConsoleGame.Engine.Entities.Components
{
    public class HealthComponent : Component
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public bool Invincible { get; private set; } = false;
        public bool Dead { get; private set; } = false;

        
        // event delegates
        public delegate void DeathTrigger();
        public delegate void DamageTrigger();
        public delegate void HealTrigger();
        public delegate void OverHealTrigger();
        
        // events
        public event DeathTrigger OnDeath;
        public event DamageTrigger OnDamage;
        public event HealTrigger OnHeal;
        public event OverHealTrigger OnOverHeal;
        
        
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
            OnDamage?.Invoke();

            if (Health <= 0)
            {
                Health = 0;
                Dead = true;
                OnDeath?.Invoke();
            }
        }

        public void Heal(int amount, bool overHeal)
        {
            if (Health == MaxHealth && !overHeal) return;
            
            OnHeal?.Invoke();
            
            if (Health + amount > MaxHealth && !overHeal)
            {
                Health = MaxHealth;
                return;
            }

            if (Health + amount > MaxHealth && overHeal)
            {
                Health += amount;
                OnOverHeal?.Invoke();
            }
            
            Health += amount;
        }
    }
}