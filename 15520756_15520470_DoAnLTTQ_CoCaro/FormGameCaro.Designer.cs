namespace _15520756_15520470_DoAnLTTQ_CoCaro
{
    partial class FormGameCaro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.redo = new System.Windows.Forms.Button();
            this.undo = new System.Windows.Forms.Button();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.btnLAN = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.ptbIcon = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnComputer = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btn2Player = new System.Windows.Forms.Button();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlChessBoard.Location = new System.Drawing.Point(16, 13);
            this.pnlChessBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(702, 672);
            this.pnlChessBoard.TabIndex = 1;
            this.pnlChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChessBoard_Paint);
            this.pnlChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlChessBoard_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.redo);
            this.panel1.Controls.Add(this.undo);
            this.panel1.Controls.Add(this.prcbCoolDown);
            this.panel1.Controls.Add(this.btnLAN);
            this.panel1.Controls.Add(this.txbIP);
            this.panel1.Controls.Add(this.ptbIcon);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnComputer);
            this.panel1.Controls.Add(this.btnNewGame);
            this.panel1.Controls.Add(this.btn2Player);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(718, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 717);
            this.panel1.TabIndex = 9;
            // 
            // redo
            // 
            this.redo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.redo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.redo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.redo.FlatAppearance.BorderSize = 0;
            this.redo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redo.ForeColor = System.Drawing.SystemColors.Control;
            this.redo.Location = new System.Drawing.Point(161, 350);
            this.redo.Margin = new System.Windows.Forms.Padding(4);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(133, 102);
            this.redo.TabIndex = 12;
            this.redo.Text = "Redo";
            this.redo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.redo.UseVisualStyleBackColor = false;
            // 
            // undo
            // 
            this.undo.AutoSize = true;
            this.undo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.undo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.undo.FlatAppearance.BorderSize = 0;
            this.undo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undo.ForeColor = System.Drawing.SystemColors.Control;
            this.undo.Location = new System.Drawing.Point(20, 350);
            this.undo.Margin = new System.Windows.Forms.Padding(4);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(133, 102);
            this.undo.TabIndex = 11;
            this.undo.Text = "Undo";
            this.undo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.undo.UseVisualStyleBackColor = false;
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(20, 314);
            this.prcbCoolDown.Margin = new System.Windows.Forms.Padding(4);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(275, 28);
            this.prcbCoolDown.TabIndex = 10;
            // 
            // btnLAN
            // 
            this.btnLAN.BackColor = System.Drawing.Color.Black;
            this.btnLAN.FlatAppearance.BorderSize = 0;
            this.btnLAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLAN.ForeColor = System.Drawing.Color.White;
            this.btnLAN.Location = new System.Drawing.Point(20, 192);
            this.btnLAN.Margin = new System.Windows.Forms.Padding(4);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(133, 114);
            this.btnLAN.TabIndex = 9;
            this.btnLAN.Text = "LAN";
            this.btnLAN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLAN.UseVisualStyleBackColor = false;
            // 
            // txbIP
            // 
            this.txbIP.BackColor = System.Drawing.Color.Black;
            this.txbIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIP.ForeColor = System.Drawing.Color.White;
            this.txbIP.Location = new System.Drawing.Point(160, 236);
            this.txbIP.Margin = new System.Windows.Forms.Padding(4);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(133, 22);
            this.txbIP.TabIndex = 8;
            this.txbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ptbIcon
            // 
            this.ptbIcon.BackColor = System.Drawing.SystemColors.Control;
            this.ptbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbIcon.InitialImage = null;
            this.ptbIcon.Location = new System.Drawing.Point(77, 13);
            this.ptbIcon.Margin = new System.Windows.Forms.Padding(4);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(210, 171);
            this.ptbIcon.TabIndex = 0;
            this.ptbIcon.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(162, 576);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 109);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnComputer
            // 
            this.btnComputer.AutoSize = true;
            this.btnComputer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnComputer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnComputer.FlatAppearance.BorderSize = 0;
            this.btnComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComputer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnComputer.Location = new System.Drawing.Point(19, 460);
            this.btnComputer.Margin = new System.Windows.Forms.Padding(4);
            this.btnComputer.Name = "btnComputer";
            this.btnComputer.Size = new System.Drawing.Size(133, 108);
            this.btnComputer.TabIndex = 5;
            this.btnComputer.Text = "Computer";
            this.btnComputer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComputer.UseVisualStyleBackColor = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNewGame.Location = new System.Drawing.Point(20, 576);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(133, 109);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewGame.UseVisualStyleBackColor = false;
            // 
            // btn2Player
            // 
            this.btn2Player.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn2Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn2Player.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn2Player.FlatAppearance.BorderSize = 0;
            this.btn2Player.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2Player.ForeColor = System.Drawing.SystemColors.Control;
            this.btn2Player.Location = new System.Drawing.Point(162, 460);
            this.btn2Player.Margin = new System.Windows.Forms.Padding(4);
            this.btn2Player.Name = "btn2Player";
            this.btn2Player.Size = new System.Drawing.Size(133, 108);
            this.btn2Player.TabIndex = 6;
            this.btn2Player.Text = "2 Player";
            this.btn2Player.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn2Player.UseVisualStyleBackColor = false;
            // 
            // FormGameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 717);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlChessBoard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGameCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.Load += new System.EventHandler(this.FormGameCaro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.PictureBox ptbIcon;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btn2Player;
        private System.Windows.Forms.Button btnComputer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.ImageList imageList1;
    }
}

