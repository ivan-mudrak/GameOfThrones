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
        }

        private void buttonStart_OnClick(object sender, EventArgs e)
        {
            System.Drawing.Graphics graphis = this.BattleField.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, 5, 5);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            graphis.FillRectangle(redBrush, rectangle);          
        }

        public void DrawBattleField()
        {

        }
    }
}
