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
        private Stack<ChessPiece> stkChessUsed;


        private int typlePlay { get; set; } // = 1 Play by 2 player; =2 play with computer ; = 0 hasn't chose type


        private Image ImageO = new Bitmap(Properties.Resources.o);
        private Image ImageX = new Bitmap(Properties.Resources.x);

        public GameCaro()
        {
            ChessBoardManagement = new ChessBoard(Cons.CHESS_BOARD_HEIGHT, Cons.CHESS_BOARD_WIDTH);
            listChessPieces = new ChessPiece[ChessBoardManagement.NumbRows, ChessBoardManagement.NumbColumns];
            typlePlay = 0;

        }

        // Vẽ bàn cờ
        public void DrawBroadChess(Graphics g)
        {
            ChessBoardManagement.DrawBroadChess(g);

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

        //repaint chess when load
        public void RepaintChess(Graphics g)
        {
            if(stkChessUsed != null)
            {
                foreach (ChessPiece cp in stkChessUsed)
                {
                    if (cp.Owner == 1)
                        ChessBoardManagement.DrawChess(g, cp.Position, ImageX);
                    else if (cp.Owner == 2)
                        ChessBoardManagement.DrawChess(g, cp.Position, ImageO);

                }
            }

        }
        public bool PlayChess(int mouseX, int mouseY, Graphics g)
        {
            if (this.typlePlay == 0)
            {
                MessageBox.Show("You have not selected the game mode yet!!");
                return false;
            } else
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
                ChessPiece tmp = listChessPieces[row, column];
                ChessPiece cp = new ChessPiece(tmp.Row, tmp.Column, tmp.Position, tmp.Owner);
                stkChessUsed.Push(cp);
                if (check_win())
                {
                    MessageBox.Show("End Game");
                    return false;
                }
                else
                    return true;
            }

        }

        public void Start2Player(Graphics g)
        {
            this.typlePlay = 1;
            this.turn = 1;
            stkChessUsed = new Stack<ChessPiece>();
            this.CreateChessPieces();
            ChessBoardManagement.DrawBroadChess(g);


        }

        public void NewGame(Graphics g)
        {
            this.CreateChessPieces();
            this.turn = 1;
            stkChessUsed = new Stack<ChessPiece>();
            ChessBoardManagement.DrawBroadChess(g);
        }


        public bool check_win()
        {
            foreach (var item in stkChessUsed)
            {
                if (CheckHorizontal(item) || CheckVertical(item) || CheckCross(item) || CheckCrossBackwards(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckHorizontal(ChessPiece currPiese)
        {
            if (currPiese.Column > ChessBoardManagement.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Column == 0 || currPiese.Column + count == ChessBoardManagement.NumbColumns)
                return true;
            if (listChessPieces[currPiese.Row, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }

        private bool CheckVertical(ChessPiece currPiese)
        {
            if (currPiese.Row > ChessBoardManagement.NumbRows - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row + count, currPiese.Column].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Row == 0 || currPiese.Row + count == ChessBoardManagement.NumbRows)
                return true;
            if (listChessPieces[currPiese.Row - 1, currPiese.Column ].Owner == 0 || listChessPieces[currPiese.Row + count, currPiese.Column ].Owner == 0)
                return true;
            return false;
        }
        private bool CheckCross(ChessPiece currPiese)
        {
            if (currPiese.Row > ChessBoardManagement.NumbRows - 5 || currPiese.Column > ChessBoardManagement.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row + count, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Column == 0 || currPiese.Column + count == ChessBoardManagement.NumbColumns || currPiese.Row == 0 || currPiese.Row + count == ChessBoardManagement.NumbRows)
                return true;
            if (listChessPieces[currPiese.Row - 1, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row + count, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }

        private bool CheckCrossBackwards(ChessPiece currPiese)
        {
            if (currPiese.Row < 4 || currPiese.Column > ChessBoardManagement.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row - count, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Row == 4 || currPiese.Row == ChessBoardManagement.NumbRows - 1 || currPiese.Column == 0 || currPiese.Column + count == ChessBoardManagement.NumbColumns)
                return true;
            if (listChessPieces[currPiese.Row + 1, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row - count, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }
    }
}
