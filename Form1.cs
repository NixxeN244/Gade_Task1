using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Task_1
{
    public partial class Form1 : Form
    {
        GameEngine engine;
        int count = 0;

        public Form1()
        {    
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(this, this.gameDisplay); //obj of "engine" is assigned to the game display. Meaing the GameEngine class controls the board
        }

        private void timer1_Tick(object sender, EventArgs e) //These methods are called each frame of the program
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            label1.Text = (++count).ToString(); //this var keeps track of the round

        }

        private void btnPlay_Click(object sender, EventArgs e) // Play button enables the timer, starting the game
        {
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e) // this pauses the game, all methods called from the timer is stopped 
        {
            timer1.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e) //button ends the program
        {
            Application.Exit();
        }
    }
}
