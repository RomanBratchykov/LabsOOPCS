using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King4
{
    public delegate void KingAttackedEventHandler();
    public class Unit
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; } = true;
        public Unit(string name)
        {
            Name = name;
        }
        public virtual void Die()
        {
                IsAlive = false;

        }
        public virtual void RespondToAttack() { }

    }
    internal class King : Unit
    {
        public event KingAttackedEventHandler KingAttacked;

        public King(string name) : base(name)
        {
            Name = name;
        }
        public void BeAttacked()
        {
            Console.WriteLine("The king is being attacked!");
            OnKingAttacked();
        }
        protected virtual void OnKingAttacked()
        {
            KingAttacked?.Invoke();
        }
        public override void RespondToAttack() { }
    }
    internal class RoyalGuard : Unit
    {
        private int health = 3;
        public RoyalGuard(string name) : base(name)
        {
            Name = name;
        }
        public override void RespondToAttack()
        {
            if (IsAlive)
            {
                Console.WriteLine($"Royal Guard {Name} is defending the king!");
            }
        }
        public override void Die()
        {
            if (!IsAlive)
            {
                return;
            }
            health--;
            if (health == 0)
            {
                IsAlive = false;
                Console.WriteLine($"Royal guard {Name} has died!");
            }
            else
            {
                Console.WriteLine($"Royal guard {Name} got hit!");
            }
        }
    }
    internal class Footman : Unit
    {
        private int health = 2;
        public Footman(string name) : base(name)
        {
            Name = name;
        }
        public override void RespondToAttack()
        {
            if (IsAlive)
            {
                Console.WriteLine($"Footman {Name} is in panic!");
            }
        }
        public override void Die()
        {
            if (IsAlive)
            {
                health--;
                if (health <= 0)
                {
                    IsAlive = false;
                    Console.WriteLine($"Footman {Name} has died!");
                }
                else
                {
                    Console.WriteLine($"Footman {Name} got hit!");
                }
            }
        }
    }
}
