using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Task_1
{
    abstract class Unit
    {
        #region Decl
        protected int x;
        protected int y;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected string team;
        protected string symbol;
        protected bool isAttacking;
        #endregion

        #region Constr
        public Unit(int x, int y, int health, int speed, int attack, int attackRange, string team, string symbol)
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
        #endregion

        #region Getting_Setting
        public abstract int X
        {
            get; set;
        }

        public abstract int Y
        {
            get; set;
        }

        public abstract int Health
        {
            get; set;
        }

        public abstract int MaxHealth
        {
            get;
        }

        public abstract int Speed
        {
            get; set;
        }
        public abstract int Attack
        {
            get; set;
        }
        public abstract int AttackRange
        {
            get; set;
        }

        public abstract string Symbol
        {
            get; set;
        }
        public abstract string Team
        {
            get; set;
        }
        public abstract bool IsAttacking
        {
            get; set;
        }
        #endregion

        abstract public void Combat(ref Unit attacker);


        abstract public void Move(ref Unit closestUnit);



        abstract public Unit ClosestUnit(List<Unit> list);


        abstract public bool isInRange(ref Unit attacker);


        abstract public bool IsDead();

        /*we can use toString() to output the 
         value of a class/substructure/enum
         return this as a value*/

        public virtual string toString()
        {
            return " ";
        }

    }
}

