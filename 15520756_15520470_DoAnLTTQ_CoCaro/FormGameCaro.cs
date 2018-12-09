using _15520756_15520470_DoAnLTTQ_CoCaro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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

        public static int stepTime = 100;
        public static int playTime = 15000;
        public FormGameCaro()
        {
            InitializeComponent();
            grs = pnlChessBoard.CreateGraphics();
            Caro = new GameCaro();

            // Set icon status
            btnNewGame.Enabled = false;         
            btnRedo.Enabled = false;
            btnUndo.Enabled = false;

            // Set progress bar
            prbCountDown.Step = stepTime;
            prbCountDown.Maximum = playTime;
            prbCountDown.Value = 0;

            // Get IP Address
            IPHostEntry ip = new IPHostEntry();
            ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress listip in ip.AddressList)
            {
                txbIP.Text = listip.ToString();
            }
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
            btnUndo.BackColor = this.BackColor;
            btnRedo.BackColor = this.BackColor;


            btn2Player.BackColor = this.BackColor;
            btnExit.BackColor = this.BackColor;
            pnlChessBoard.BackColor = Color.White;
        }

        private void pnlChessBoard_Paint(object sender, PaintEventArgs e)
        {
            this.Caro.DrawBroadChess(grs);
            this.Caro.RepaintChess(grs);
        }

        private void pnlChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if(!this.Caro.end)
            {
                this.Caro.PlayChess(e.X, e.Y, grs);
                if (this.Caro.typlePlay == 2)
                {
                    this.Caro.StartComputer(grs);
                }
            }
            btnUndo.Enabled = true;
        }

        private void btn2Player_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlChessBoard.BackColor);
            this.Caro.Start2Player(grs);

            // Set button status
            btnNewGame.Enabled = true;
            btn2Player.Enabled = false;
            btnComputer.Enabled = true;
            btnUndo.Enabled = false;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlChessBoard.BackColor);
            this.Caro.NewGame(grs);

            // Set button status
            btnUndo.Enabled = false;
        }

        private void btnComputer_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlChessBoard.BackColor);
            this.Caro.StartVsComp(grs);

            // Set image and status of button icon
            btnComputer.Enabled = false;
            btnNewGame.Enabled = true;
            btn2Player.Enabled = true;
            btnUndo.Enabled = false;

            // Set time for process bar
            prbCountDown.Value = 0;
        }

        private void undo_Click(object sender, EventArgs e)
        {
            this.Caro.Undo(grs);
            this.btnRedo.Enabled = true;
        }

        private void redo_Click(object sender, EventArgs e)
        {
            this.Caro.Redo(grs);
            if (this.Caro.stkChessUndo.Count == 0) this.btnRedo.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to exit!", "Exit", MessageBoxButtons.YesNo); ;
            if (Caro.typlePlay != 3)
            {
                if (dlr == DialogResult.Yes)
                {

                    Application.Exit();
                }
            }

            else
            {
                //if (dlr == DialogResult.Yes)
                //{
                //    try
                //    {
                //        socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                //    }
                //    catch { }

                //    Application.Exit();
                //}
            }
        }

        private void txbIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
