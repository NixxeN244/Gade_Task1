using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_Task_1
{
    class Map
    {
        public Unit[] units = new Unit[10];

        public Map()
        {
            Random r = new Random();    
            for (int i = 0; i < 10; i++)    //loop to generate the units on the board 
            {
                int newX = r.Next(0, 20);
                int newY = r.Next(0, 20);
                int team = i % 2;



                switch (r.Next(0, 2))   //random number generates a number that is assigned to the unit
                {
                    case 0: units[i] = new MeleeUnit(newX, newY, 10, 3, 6, 3, team.ToString(), i.ToString()); break;
                    case 1: units[i] = new RangedUnit(newX, newY, 6, 5, 3, 9, team.ToString(), i.ToString()); break;

                }
            }
        }
    }
}
