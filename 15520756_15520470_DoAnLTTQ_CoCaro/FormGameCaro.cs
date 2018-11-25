using _15520756_15520470_DoAnLTTQ_CoCaro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15520756_15520470_DoAnLTTQ_CoCaro
{
    public partial class FormGameCaro : Form
    {
        #region properties
        #endregion
        private Graphics grs;
        public GameCaro Caro;
        public FormGameCaro()
        {
            InitializeComponent();
            grs = pnlChessBoard.CreateGraphics();
            Caro = new GameCaro();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void FormGameCaro_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(58, 58, 60);
            btnComputer.BackColor = this.BackColor;
            btnNewGame.BackColor = this.BackColor;
            btnLAN.BackColor = this.BackColor;
            txbIP.BackColor = this.BackColor;
            undo.BackColor = this.BackColor;
            redo.BackColor = this.BackColor;


            btn2Player.BackColor = this.BackColor;
            btnExit.BackColor = this.BackColor;
            pnlChessBoard.BackColor = Color.White;
        }

        private void pnlChessBoard_Paint(object sender, PaintEventArgs e)
        {
            this.Caro.DrawBroadChess(grs);
        }

        private void pnlChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            this.Caro.PlayChess(e.X, e.Y, grs);

        }
    }
}
