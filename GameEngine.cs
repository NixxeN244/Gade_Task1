using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GADE_Task_1
{
    class GameEngine
    {
        public Map themap = new Map();
        private Form1 form;
        private GroupBox messageGroup;


        public GameEngine(Form1 form, GroupBox messageGroup) //constrcut  that takes in the info from the form and groupbox classes
        {
            this.form = form;
            this.messageGroup = messageGroup;
            foreach (Unit i in themap.units)
            {
                Button btn = new Button();  
                btn.Location = new Point(i.X * 35, i.Y * 35);
                btn.Size = new Size(30, 30);
                btn.Text = i.Symbol;

                if (Convert.ToInt32(i.Team) == 0)   //checks which team the unit is assigned to and sets it's colour
                {
                    btn.BackColor = Color.Purple;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
                if (i.GetType() == typeof(MeleeUnit))   //checks to see which unit class the unit is assigned to
                {
                    btn.ForeColor = Color.Turquoise;
                }
                else
                {
                    btn.ForeColor = Color.Violet;
                }

                form.Controls.Add(btn);
            }
        }

        public void UpdateDisplay()
        {
            form.Controls.Clear();
            form.Controls.Add(messageGroup);
            foreach (Unit item in themap.units) //updates the display to show the units on the game board
            {
                Button a = new Button();
                a.Location = new Point(item.X * 35, item.Y * 35);
                a.Size = new Size(30, 30);
                a.Text = item.Symbol;

                if (Convert.ToInt32(item.Team) == 0) //checks to assign colour 
                {
                    a.BackColor = Color.Purple;
                }
                else
                {
                    a.BackColor = Color.Red;
                }
                if (item.GetType() == typeof(MeleeUnit)) //check to see what unit class it is from 
                {
                    a.ForeColor = Color.Turquoise;  //for the MeleeUnit 
                }
                else
                {
                    a.ForeColor = Color.Violet; //for the RangedUnit
                }

                form.Controls.Add(a);
            }
        }

        public void UpdateMap() 
        {
            foreach (Unit a in themap.units)
            {
                Unit closestUnit = a.ClosestUnit(ref List<Unit> themap );

                try
                {
                    a.Move(ref closestUnit);
                }
                catch (DeathException d)
                {
                    form.DisplayRectangle();
                    Unit[] temp = new Unit[themap.units.Count() - 1];
                    int j = 0;
                    for (int i = 0; i < themap.units.Count(); i++)
                    {
                        if (a != themap.units[i])
                        {
                            temp[j++] = themap.units[i];
                        }
                    }
                    themap.units = temp;
                }
            }
        }

        public void buttonClick(object sender, EventArgs args)
        {
            foreach (Unit u in themap.units)
            {
                if (((Button)sender).Text == u.Symbol)
                {
                    form.DisplayInfo(u.ToString);
                    break;
                }
            }
        }
    }
}
