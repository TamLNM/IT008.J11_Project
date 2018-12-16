using _15520756_15520470_DoAnLTTQ_CoCaro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _15520756_15520470_DoAnLTTQ_CoCaro.SocketData;

namespace _15520756_15520470_DoAnLTTQ_CoCaro
{
    public partial class FormGameCaro : Form
    {
        #region properties
        private Graphics grs;
        public GameCaro Caro;

        SocketManager socket;
        bool isLANConnected;
        #endregion

        public FormGameCaro()
        {
            InitializeComponent();
            grs = pnlChessBoard.CreateGraphics();
            Caro = new GameCaro();

            // Set icon status
            btnNewGame.Enabled = false;         
            btnRedo.Enabled = false;
            btnUndo.Enabled = false;

            // Initial progress bar
            prbCountDown.Step = Cons.stepTime;
            prbCountDown.Maximum = Cons.playTime;
            prbCountDown.Value = 0;

            // Initial socket
            socket = new SocketManager();
            isLANConnected = false;
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
            if (!this.Caro.end)
            {
                if (this.Caro.PlayChess(e.X, e.Y, grs))
                {
                    // Set progress bar
                    tmCountDown.Start();
                    prbCountDown.Value = 0;

                    if (isLANConnected)
                    {
                        // Send chess-play info to other-player 
                        socket.Send(new SocketData((int)SocketCommand.SEND_POINT, e.X, e.Y, ""));
                        Listen();
                        pnlChessBoard.Enabled = false;

                        if (this.Caro.end)
                        {
                            tmCountDown.Stop();
                            prbCountDown.Value = 0;
                        }
                    }


                    if (this.Caro.typlePlay == 2)
                    {
                        this.Caro.StartComputer(grs);
                    }
                    btnUndo.Enabled = true;
                }
            }
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

            // Reset progress bar
            prbCountDown.Value = 0;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlChessBoard.BackColor);
            this.Caro.NewGame(grs);

            // Set button status
            btnUndo.Enabled = false;

            // Reset progress bar
            tmCountDown.Start();
            prbCountDown.Value = 0;

            if (isLANConnected)
            {
                socket.Send(new SocketData((int)SocketCommand.NEW_GAME));
                Listen();
            }

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

            // Reset progress bar
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

        private void tmCountDown_Tick(object sender, EventArgs e)
        {
            prbCountDown.PerformStep();

            if (prbCountDown.Value >= prbCountDown.Maximum)
            {
                tmCountDown.Stop();

                if (this.Caro.getTurn() == 1)
                {
                    MessageBox.Show("O win");
                    this.Caro.end = true;
                }
                else
                {
                    MessageBox.Show("X win");
                    this.Caro.end = true;
                }
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            isLANConnected = true;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            btnNewGame.Enabled = true;

            // Reset the progress bar
            prbCountDown.Value = 0;
            tmCountDown.Stop();

            // Get and show IP address
            socket.IP = txbIP.Text;
            if (!socket.ConnectServer()) // 
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }

            // Initial chessBoard
            grs.Clear(pnlChessBoard.BackColor);
            this.Caro.StartLAN(grs);
        }

        // Create function Listen()
        void Listen()
        {

            // De vao try catch de khi khong con ai lang nghe, chuong trinh khong bi loi
            try
            {
                Thread listenThread = new Thread(() =>
                {
                    SocketData data = (SocketData) socket.Receive();
                    ProcessData(data);
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch{}
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int) SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int) SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        tmCountDown.Start();
                        prbCountDown.Value = 0;
                        Caro.OthersPlayChess(data.MouseX, data.MouseY, grs);
                        pnlChessBoard.Enabled = true;
                        if (Caro.end)
                        {
                            tmCountDown.Stop();
                            prbCountDown.Value = 0;
                        }
                    }));
                    break;
                case (int)SocketCommand.NEW_GAME:
                    MessageBox.Show("NEW GAME!!!");
                    break;
                default:
                    break;
            }
        }

        // Set IP Address
        private void FormGameCaro_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void ptbIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
