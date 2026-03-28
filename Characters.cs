namespace Progra2261
{
    public class Character
    {
        protected string name;
        protected int health;
        protected int damage;

        
        public string GetName() => name;
        public int GetHealth() => health;
        public int GetDamage() => damage;
        public bool IsAlive() => health > 0;

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health < 0) health = 0;
        }

        public void Heal(int amount)
        {
            health += amount;
        }
    }

    public class Player : Character
    {
        public Player(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }

    public class Enemy : Character
    {
        public Enemy(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
}