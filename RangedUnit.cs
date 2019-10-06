using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Task_1
{
    class RangedUnit : Unit
    {


        public RangedUnit(int x, int y, int health, int speed, int attack, int attackRange, string team, string symbol) //constrcutor that passses the priv variables from the Unit class the this class
             : base(x, y, health, speed, attack, attackRange, team, symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
            this.symbol = symbol;

        }
        #region Override var
        public override int X
        {
            get; set;
        }

        public override int Y
        {
            get; set;
        }

        public override int Health
        {
            get; set;
        }

        public override int MaxHealth
        {
            get;
        }

        public override int Speed
        {
            get; set;
        }
        public override int Attack
        {
            get; set;
        }
        public override int AttackRange
        {
            get; set;
        }

        public override string Symbol
        {
            get; set;
        }
        public override string Team
        {
            get; set;
        }
        public override bool IsAttacking
        {
            get; set;
        }
        #endregion

        public override void Move(ref Unit closestUnit) // using the "override" keyword to make changes to the abstract methods
        {
            if (this == closestUnit)    //if this unit id the only one remaing
            {
                return; // we then use return to end the method here
            }

            //this code only applies to the enemy units
            if (closestUnit.Team != team)
            {
                //this then starts combat
                if (health > 10)
                {
                    Random rnd = new Random(); //obj inheritance from the Random class within the .NET framework
                    //this allows us to generate random numbers
                    //Random.Next() is the method used to generate numbers between 2 ints 0 and 2
                    switch (rnd.Next(0, 2))
                    {
                        case 0: x += (1 * speed); break;
                        case 1: x -= (1 * speed); break;
                    }
                    switch (rnd.Next(0, 2))
                    {
                        case 0: y += (1 * speed); break;
                        case 1: y -= (1 * speed); break;
                    }
                    //check bounds and resets char afterwards
                    if (x <= 0)
                    {
                        x = 0;  //if less than 0, the unit stays at 0 on the x
                    }
                    else if (x >= 20)
                    {
                        x = 20; //if greater than 0, the unit stays at 20 on the x
                    }
                    if (y <= 0)
                    {
                        y = 0;  //if less than 0, the unit stays at 0 on the y
                    }
                    else if (y >= 20)
                    {
                        y = 20; //if greater than 20, the unit stays at 20 on the y
                    }
                }
                //checks if the unit is in combat
                //the Math.Abs() method returns the absolute value of a number; same as Mathf.clamp in Unity framework
            }
            else if (Math.Abs(x - closestUnit.X) <= speed && Math.Abs(y - closestUnit.Y) <= speed)
            {
                Combat(ref closestUnit);
            }
            else //the unit then moves to the closest unit
            {
                if (x > closestUnit.X)
                {
                    x -= speed;
                }
                else if (x < closestUnit.X)
                {
                    x += speed;
                }
                if (y > closestUnit.Y)
                {
                    y -= speed;
                }
                else if (y < closestUnit.Y)
                {
                    y += speed;
                }
            }
        }


        public override void Combat(ref Unit attacker)
        {
            this.health = this.health - attacker.Attack;    //the melee units takes damage
            if (health <= 0)
            {
                IsDead();
            }

        }


        public override bool isInRange(ref Unit attacker)
        {
            if (DistanceTo(attacker) == attackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Unit unit)
        {
            int dx = Math.Abs(unit.X - x);//compares the postions of the 2 units
            int dy = Math.Abs(unit.Y - y);
            double part = Convert.ToDouble((dx ^ 2) + (dy ^ 2));
            return Convert.ToInt32(Math.Sqrt(part));
        }

        public override Unit ClosestUnit(List<Unit> list) //
        {
            Unit closest = this;
            int smallestRange = 100;
            foreach (Unit i in list)
            {
                if (i.Team != team) //if its not in the units team 
                {
                    if (smallestRange > DistanceTo(i) && i != this)
                    {
                        smallestRange = DistanceTo(i);  //
                        closest = i; //finds the closest unit is then i
                    }
                }
            }
            return closest; //returns the obj of the Unit from the Closest Unit
        }

        public class DeathException : System.Exception
        {
            public DeathException() : base() { }   //new instance/obj of the "exception" class
            public DeathException(string message) : base(message) { }
            //public DeathException(string messagE, System.Exception inner) : base(messagE, inner) { }

        }

        public override bool IsDead()
        {
            throw new DeathException(ToString()) + "IS DEAD";
        }
        public override string toString()
        {
            return symbol + ": [" + x + "," + y + "]" + health + "HP" + attack;
        }
    }
    public class DeathException : System.Exception
    {
        public DeathException() : base() { }   //new instance/obj of the "exception" class
        public DeathException(string message) : base(message) { }
        //public DeathException(string messagE, System.Exception inner) : base(messagE, inner) { }

    }
}


