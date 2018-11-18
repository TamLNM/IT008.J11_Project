using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15520756_15520470_DoAnLTTQ_CoCaro
{
    public class ChessBoardManagement
    {
        #region properties
        private Panel ChessBoard;

        public Panel ChessBoard1 { get => ChessBoard; set => ChessBoard = value; }
        #endregion

        #region initialize
        public ChessBoardManagement(Panel chessBoard)
        {
            this.ChessBoard = chessBoard;
        }
        #endregion

        #region method
        public void chestInit()
        {
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Button befButton = new Button() { Location = new Point(0, 0 + Cons.CHEST_HEIGHT * i) };
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button currentButton = new Button()
                    {
                        Width = Cons.CHEST_WIDTH,
                        Height = Cons.CHEST_HEIGHT,
                        Location = new Point(befButton.Location.X + Cons.CHEST_WIDTH, befButton.Location.Y),
                    };

                    ChessBoard.Controls.Add(currentButton);
                    befButton = currentButton;
                }
            }
        }
        #endregion
    }
}
