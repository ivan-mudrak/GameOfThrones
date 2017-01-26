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
        private readonly Graphics _graphics;
        private readonly BattleField _battleField;
        private readonly Dictionary<string, Color> kingdomsNameColorDictionary;


        public GameOfThrones()
        {
            InitializeComponent();
            _graphics = BattleFieldView.CreateGraphics();
            kingdomsNameColorDictionary = new Dictionary<string, Color>();
            kingdomsNameColorDictionary.Add("Targaryens", Color.Black);
            kingdomsNameColorDictionary.Add("Baratheons", Color.Yellow);
            kingdomsNameColorDictionary.Add("Starks", Color.DarkGray);
            kingdomsNameColorDictionary.Add("Lannisters", Color.Red);
            _battleField = new BattleField(BattleFieldView.Width, BattleFieldView.Height, kingdomsNameColorDictionary);          
        }

        private void buttonStart_OnClick(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                _battleField.DrawOnGraphics(_graphics);              
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

        private void timer_OnTick(object sender, EventArgs e)
        {
            _battleField.Battle();
            _battleField.DrawOnGraphics(_graphics);
            labelTargaryens.Text = String.Format("Targaryens - {0}", _battleField.GetKingdomScore("Targaryens"));
            labelBaratheons.Text = String.Format("Baratheons - {0}", _battleField.GetKingdomScore("Baratheons"));
            labelStarks.Text = String.Format("Starks - {0}", _battleField.GetKingdomScore("Starks"));
            labelLannisters.Text = String.Format("Lannisters - {0}", _battleField.GetKingdomScore("Lannisters"));                                    
        }
    }
}
