using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class GameOfThrones : Form
    {
        private bool _isStarted = false;        

        public GameOfThrones()
        {
            InitializeComponent();
            BattleField.Instance(BattleFieldView.Width, BattleFieldView.Height);           
        }

        private void buttonStart_OnClick(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                DrawBattleField();
                buttonStart.Text = "Stop";
                timer.Interval = 1;
                timer.Start();
                _isStarted = true;
            }
            else
            {
                buttonStart.Text = "Start";
                timer.Stop();
                _isStarted = false;
            }
        }

        private void DrawBattleField()
        {
            if (!BattleFieldView.IsDisposed)
            {
                BattleField.Instance().Draw(BattleFieldView.CreateGraphics());
            }
        }

        private void timer_OnTick(object sender, EventArgs e)
        {
            BattleField.Instance().Battle();
            DrawBattleField();
        }   
    }
}
