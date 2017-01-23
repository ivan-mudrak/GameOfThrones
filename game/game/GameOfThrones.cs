using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class GameOfThrones : Form
    {
        private bool isStarted = false;

        public GameOfThrones()
        {
            InitializeComponent();
            BattleField.Instance((uint)BattleFieldView.Width / 4, (uint)BattleFieldView.Height / 4);
        }

        private void buttonStart_OnClick(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                DrawBattleField();
                buttonStart.Text = "Stop";
                timer.Interval = 10;
                timer.Start();
                isStarted = true;
            }
            else
            {
                buttonStart.Text = "Start";
                timer.Stop();
                isStarted = false;
            }
        }
 
        public void DrawBattleField()
        {
            BattleField.Instance().Draw(BattleFieldView.CreateGraphics());
        }

        private void timer_OnTick(object sender, EventArgs e)
        {
            BattleField.Instance().Battle();
            DrawBattleField();
        }
    }
}
