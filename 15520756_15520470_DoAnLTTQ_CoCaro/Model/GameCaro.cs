using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15520756_15520470_DoAnLTTQ_CoCaro.Model
{
    public class GameCaro
    {
        public bool end { get; set; }
        private int turn { get; set; }
        private ChessPiece[,] listChessPieces;
        private ChessBoard ChessBoardManagement;

        private Image ImageO = new Bitmap(Properties.Resources.o);
        private Image ImageX = new Bitmap(Properties.Resources.x);

        public GameCaro()
        {
            this.turn = 1;
            ChessBoardManagement = new ChessBoard(Cons.CHESS_BOARD_WIDTH, Cons.CHESS_BOARD_HEIGHT);
            listChessPieces = new ChessPiece[ChessBoardManagement.NumbRows, ChessBoardManagement.NumbColumns];
        }

        // Vẽ bàn cờ
        public void DrawBroadChess(Graphics g)
        {
            ChessBoardManagement.DrawBroadChess(g);
            this.CreateChessPieces();
        }

        // Tạo bàn cờ bằng mảng 2 chiều
        public void CreateChessPieces()
        {
            for (int i = 0; i < ChessBoardManagement.NumbRows; i++)
            {
                for (int j = 0; j < ChessBoardManagement.NumbColumns; j++)
                {
                    listChessPieces[i, j] = new ChessPiece(i, j, new Point(j * Cons.CHEST_WIDTH, i * Cons.CHEST_HEIGHT), 0);
                }
            }
        }
        public bool PlayChess(int mouseX, int mouseY, Graphics g)
        {
            int column = mouseX / Cons.CHEST_WIDTH;
            int row = mouseY / Cons.CHEST_HEIGHT;

            if (listChessPieces[row, column].Owner != 0)
                return false;
            switch (turn)
            {
                case 1:
                    listChessPieces[row, column].Owner = 1;
                    ChessBoardManagement.DrawChess(g, listChessPieces[row, column].Position, ImageX);
                    turn = 2;
                    break;
                case 2:
                    listChessPieces[row, column].Owner = 2;
                    ChessBoardManagement.DrawChess(g, listChessPieces[row, column].Position, ImageO);
                    turn = 1;
                    break;
                default:
                    MessageBox.Show("Error!!");
                    break;
            }
            return true;
        }
    }
}
