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
        
        public GameOfThrones()
        {
            InitializeComponent();
            BattleField.Instance((uint) BattleFieldView.Width / 4, (uint) BattleFieldView.Height / 4);               
        }

        private void buttonStart_OnClick(object sender, EventArgs e)
        {
                DrawBattleField();     
        }

        public void DrawBattleField()
        {
            BattleField.Instance().Draw(BattleFieldView.CreateGraphics());
        }
    }
}
