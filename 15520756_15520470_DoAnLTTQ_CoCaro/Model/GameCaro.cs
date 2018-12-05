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
        private ChessBoard chessBoard;
        public Stack<ChessPiece> stkChessUsed;
        public Stack<ChessPiece> stkChessUndo;
        public static SolidBrush sbPnl;

        public int typlePlay { get; set; } // = 1 Play by 2 player; =2 play with computer ; = 0 hasn't chose type


        private Image ImageO = new Bitmap(Properties.Resources.o);
        private Image ImageX = new Bitmap(Properties.Resources.x);

        public GameCaro()
        {
            chessBoard = new ChessBoard(Cons.CHESS_BOARD_HEIGHT, Cons.CHESS_BOARD_WIDTH);
            listChessPieces = new ChessPiece[chessBoard.NumbRows, chessBoard.NumbColumns];
            sbPnl = new SolidBrush(Color.White);
            typlePlay = 0;

        }

        // Draw board chess
        public void DrawBroadChess(Graphics g)
        {
            chessBoard.DrawBroadChess(g);

        }

        // Init Board Chess
        public void CreateChessPieces()
        {
            for (int i = 0; i < chessBoard.NumbRows; i++)
            {
                for (int j = 0; j < chessBoard.NumbColumns; j++)
                {
                    listChessPieces[i, j] = new ChessPiece(i, j, new Point(j * Cons.CHEST_WIDTH, i * Cons.CHEST_HEIGHT), 0);
                }
            }
        }

        //repaint chess when load
        public void RepaintChess(Graphics g)
        {
            if (stkChessUsed != null)
            {
                foreach (ChessPiece cp in stkChessUsed)
                {
                    if (cp.Owner == 1)
                        chessBoard.DrawChess(g, cp.Position, ImageX);
                    else if (cp.Owner == 2)
                        chessBoard.DrawChess(g, cp.Position, ImageO);

                }
            }

        }

        //Draw chess when with X, Y and Graphics
        public bool PlayChess(int mouseX, int mouseY, Graphics g)
        {
            if (this.typlePlay == 0)
            {
                MessageBox.Show("You have not selected the game mode yet!!");
                return false;
            }
            else
            {
                int column = mouseX / Cons.CHEST_WIDTH;
                int row = mouseY / Cons.CHEST_HEIGHT;

                if (listChessPieces[row, column].Owner != 0)
                    return false;
                switch (turn)
                {
                    case 1:
                        listChessPieces[row, column].Owner = 1;
                        chessBoard.DrawChess(g, listChessPieces[row, column].Position, ImageX);
                        turn = 2;
                        break;
                    case 2:
                        listChessPieces[row, column].Owner = 2;
                        chessBoard.DrawChess(g, listChessPieces[row, column].Position, ImageO);
                        turn = 1;
                        break;

                    default:
                        MessageBox.Show("Error!!");
                        break;
                }
                stkChessUndo = new Stack<ChessPiece>();
                ChessPiece tmp = listChessPieces[row, column];
                ChessPiece cp = new ChessPiece(tmp.Row, tmp.Column, tmp.Position, tmp.Owner);
                stkChessUsed.Push(cp);

                if (this.check_win())
                {
                    if (typlePlay == 1)
                    {
                        if (turn == 1)
                            MessageBox.Show("Player 2 win this game");
                        else
                            MessageBox.Show("Player 1 win this game");

                    }
                    else if (typlePlay == 2)
                    {
                        if (turn == 1)
                            MessageBox.Show("You win this game");
                        else
                            MessageBox.Show("Computer win this game");
                    }
                }
                return true;
            }

        }

        public void Start2Player(Graphics g)
        {
            this.end = false;
            this.typlePlay = 1;
            this.CreateChessPieces();
            this.turn = 1;
            stkChessUsed = new Stack<ChessPiece>();
            stkChessUndo = new Stack<ChessPiece>();
            chessBoard.DrawBroadChess(g);


        }

        public void NewGame(Graphics g)
        {
            this.end = false;
            this.CreateChessPieces();
            this.turn = 1;
            stkChessUsed = new Stack<ChessPiece>();
            stkChessUndo = new Stack<ChessPiece>();
            chessBoard.DrawBroadChess(g);
            if (this.typlePlay == 2)
            {
                StartComputer(g);
            }
        }

        public void StartVsComp(Graphics g)
        {

            this.end = false;
            this.typlePlay = 2;
            this.turn = 1;
            stkChessUsed = new Stack<ChessPiece>();
            stkChessUndo = new Stack<ChessPiece>();
            this.CreateChessPieces();
            chessBoard.DrawBroadChess(g);
            StartComputer(g);
        }


        #region Check Win
        public bool check_win()
        {
            foreach (var item in stkChessUsed)
            {
                if (CheckHorizontal(item) || CheckVertical(item) || CheckCross(item) || CheckCrossBackwards(item))
                {
                    this.end = true;
                    return true;
                }
            }
            return false;
        }

        public bool CheckHorizontal(ChessPiece currPiese)
        {
            if (currPiese.Column > chessBoard.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Column == 0 || currPiese.Column + count == chessBoard.NumbColumns)
                return true;
            if (listChessPieces[currPiese.Row, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }

        private bool CheckVertical(ChessPiece currPiese)
        {
            if (currPiese.Row > chessBoard.NumbRows - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row + count, currPiese.Column].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Row == 0 || currPiese.Row + count == chessBoard.NumbRows)
                return true;
            if (listChessPieces[currPiese.Row - 1, currPiese.Column].Owner == 0 || listChessPieces[currPiese.Row + count, currPiese.Column].Owner == 0)
                return true;
            return false;
        }
        private bool CheckCross(ChessPiece currPiese)
        {
            if (currPiese.Row > chessBoard.NumbRows - 5 || currPiese.Column > chessBoard.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row + count, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Column == 0 || currPiese.Column + count == chessBoard.NumbColumns || currPiese.Row == 0 || currPiese.Row + count == chessBoard.NumbRows)
                return true;
            if (listChessPieces[currPiese.Row - 1, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row + count, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }

        private bool CheckCrossBackwards(ChessPiece currPiese)
        {
            if (currPiese.Row < 4 || currPiese.Column > chessBoard.NumbColumns - 5)
                return false;
            int count;
            for (count = 1; count < 5; count++)
            {
                if (listChessPieces[currPiese.Row - count, currPiese.Column + count].Owner != currPiese.Owner)
                    return false;
            }
            if (currPiese.Row == 4 || currPiese.Row == chessBoard.NumbRows - 1 || currPiese.Column == 0 || currPiese.Column + count == chessBoard.NumbColumns)
                return true;
            if (listChessPieces[currPiese.Row + 1, currPiese.Column - 1].Owner == 0 || listChessPieces[currPiese.Row - count, currPiese.Column + count].Owner == 0)
                return true;
            return false;
        }
        #endregion

        #region Ai
        private long[] AttackPoint = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private long[] DefensePoint = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        public void StartComputer(Graphics g)
        {
            if (this.turn == 1)
            {
                if (stkChessUsed.Count == 0)
                {
                    PlayChess(chessBoard.NumbColumns / 2 * Cons.CHEST_HEIGHT + 1, chessBoard.NumbRows / 2 * Cons.CHEST_WIDTH + 1, g);
                }
                else
                {

                    ChessPiece cp = FindMove();
                    PlayChess(cp.Position.X + 1, cp.Position.Y + 1, g);
                }
            }

        }
        private ChessPiece FindMove()
        {
            ChessPiece cpResult = new ChessPiece();
            long maxPoint = 0;
            for (int i = 0; i < chessBoard.NumbRows; i++)
            {
                for (int j = 0; j < chessBoard.NumbColumns; j++)
                {
                    if (listChessPieces[i, j].Owner == 0)
                    {
                        long attackkPoint = AtkPoint_CheckHorizontal(i, j) + AtkPoint_CheckVertical(i, j) + AtkPoint_CheckCross(i, j) + AtkPoint_CheckCrossBackward(i, j);
                        long defensePoint = DefPoint_CheckHorizontal(i, j) + DefPoint_CheckVertical(i, j) + DefPoint_CheckCross(i, j) + DefPoint_CheckCrossBackward(i, j);
                        long tmpPoint = attackkPoint > defensePoint ? attackkPoint : defensePoint;
                        if (maxPoint < tmpPoint)
                        {
                            maxPoint = tmpPoint;
                            cpResult = new ChessPiece(listChessPieces[i, j].Row, listChessPieces[i, j].Column, listChessPieces[i, j].Position, listChessPieces[i, j].Owner);

                        }
                    }
                }
            }

            return cpResult;
        }

        #region Attack
        private long AtkPoint_CheckVertical(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows; count++)
            {
                if (listChessPieces[currRow + count, currColumn].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow + count, currColumn].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow - count >= 0; count++)
            {
                if (listChessPieces[currRow - count, currColumn].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow - count, currColumn].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (enemy == 2) return 0;
            total -= DefensePoint[enemy + 1];
            total += AttackPoint[ally];
            return total;
        }
        private long AtkPoint_CheckHorizontal(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow, currColumn + count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow, currColumn + count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow, currColumn - count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow, currColumn - count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (enemy == 2) return 0;
            total -= DefensePoint[enemy + 1];
            total += AttackPoint[ally];
            return total;
        }
        private long AtkPoint_CheckCross(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow + count, currColumn + count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow + count, currColumn + count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow - count >= 0 && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow - count, currColumn - count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow - count, currColumn - count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (enemy == 2) return 0;
            total -= DefensePoint[enemy + 1];
            total += AttackPoint[ally];
            return total;
        }

        private long AtkPoint_CheckCrossBackward(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow - count >= 0 && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow - count, currColumn + count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow - count, currColumn + count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow + count, currColumn - count].Owner == 1)
                    ally++;
                else if (listChessPieces[currRow + count, currColumn - count].Owner == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }
            if (enemy == 2) return 0;
            total -= DefensePoint[enemy + 1];
            total += AttackPoint[ally];
            return total;
        }
        #endregion

        #region Defense
        private long DefPoint_CheckVertical(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows; count++)
            {
                if (listChessPieces[currRow + count, currColumn].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow + count, currColumn].Owner == 2)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow - count >= 0; count++)
            {
                if (listChessPieces[currRow - count, currColumn].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow - count, currColumn].Owner == 2)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }
            if (ally == 2) return 0;
            total += DefensePoint[enemy];

            return total;
        }
        private long DefPoint_CheckHorizontal(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow, currColumn + count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow, currColumn + count].Owner == 2)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow, currColumn - count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow, currColumn - count].Owner == 2)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }
            if (ally == 2) return 0;
            total += DefensePoint[enemy];


            return total;
        }
        private long DefPoint_CheckCross(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow + count, currColumn + count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow + count, currColumn + count].Owner == 2)
                {
                    enemy++;

                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow - count >= 0 && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow - count, currColumn - count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow - count, currColumn - count].Owner == 2)
                {
                    enemy++;

                }
                else
                {
                    break;
                }
            }
            if (ally == 2) return 0;
            total += DefensePoint[enemy];


            return total;
        }
        private long DefPoint_CheckCrossBackward(int currRow, int currColumn)
        {
            long total = 0;
            int ally = 0;
            int enemy = 0;
            for (int count = 1; count < 6 && currRow - count >= 0 && currColumn + count < chessBoard.NumbColumns; count++)
            {
                if (listChessPieces[currRow - count, currColumn + count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow - count, currColumn + count].Owner == 2)
                {
                    enemy++;

                }
                else
                {
                    break;
                }
            }
            for (int count = 1; count < 6 && currRow + count < chessBoard.NumbRows && currColumn - count >= 0; count++)
            {
                if (listChessPieces[currRow + count, currColumn - count].Owner == 1)
                {
                    ally++;
                    break;
                }
                else if (listChessPieces[currRow + count, currColumn - count].Owner == 2)
                {
                    enemy++;

                }
                else
                {
                    break;
                }
            }
            if (ally == 2) return 0;
            total += DefensePoint[enemy];


            return total;
        }

        #endregion
        #endregion

        #region UnDo Redo
        #region Undo
        public void Undo(Graphics g)
        {
            if (typlePlay == 1)
            {
                if (stkChessUsed.Count != 0)
                {
                    if (turn == 1)
                        turn = 2;
                    else if (turn == 2)
                        turn = 1;
                    ChessPiece cp = stkChessUsed.Pop();
                    stkChessUndo.Push(new ChessPiece(cp.Row, cp.Column, cp.Position, cp.Owner));
                    listChessPieces[cp.Row, cp.Column].Owner = 0;
                    chessBoard.RemoveChess(g, cp.Position, sbPnl);
                }
                else
                    MessageBox.Show("there aren't any chess on board chess!");
            }
            else if (typlePlay == 2)
            {
                if (stkChessUsed.Count != 0)
                {
                    ChessPiece cpC = stkChessUsed.Pop();
                    ChessPiece cpP = stkChessUsed.Pop();
                    stkChessUndo.Push(new ChessPiece(cpP.Row, cpP.Column, cpP.Position, cpP.Owner));
                    stkChessUndo.Push(new ChessPiece(cpC.Row, cpC.Column, cpC.Position, cpC.Owner));
                    listChessPieces[cpP.Row, cpP.Column].Owner = 0;
                    listChessPieces[cpC.Row, cpC.Column].Owner = 0;
                    chessBoard.RemoveChess(g, cpP.Position, sbPnl);
                    chessBoard.RemoveChess(g, cpC.Position, sbPnl);
                }
                else
                    MessageBox.Show("there aren't any chess on board chess!");
            }
        }
        #endregion

        #region Redo
        public void Redo(Graphics g)
        {
            if (typlePlay == 1)
            {
                if (stkChessUndo.Count != 0)
                {
                    if (turn == 1)
                        turn = 2;
                    else if (turn == 2)
                        turn = 1;
                    ChessPiece cp = stkChessUndo.Pop();
                    stkChessUsed.Push(new ChessPiece(cp.Row, cp.Column, cp.Position, cp.Owner));
                    listChessPieces[cp.Row, cp.Column].Owner = cp.Owner;
                    chessBoard.DrawChess(g, cp.Position, cp.Owner == 1 ? ImageX : ImageO);
                }
            }
            else if (typlePlay == 2)
            {
                if (stkChessUndo.Count != 0)
                {
                    ChessPiece cpC = stkChessUndo.Pop();
                    ChessPiece cpP = stkChessUndo.Pop();
                    stkChessUsed.Push(new ChessPiece(cpP.Row, cpP.Column, cpP.Position, cpP.Owner));
                    stkChessUsed.Push(new ChessPiece(cpC.Row, cpC.Column, cpC.Position, cpC.Owner));
                    listChessPieces[cpC.Row, cpC.Column].Owner = cpC.Owner;
                    listChessPieces[cpP.Row, cpP.Column].Owner = cpP.Owner;
                    chessBoard.DrawChess(g, cpP.Position, cpP.Owner == 1 ? ImageX : ImageO);
                    chessBoard.DrawChess(g, cpC.Position, cpC.Owner == 1 ? ImageX : ImageO);
                }
            }
        }

        #endregion
        #endregion
    }
}
