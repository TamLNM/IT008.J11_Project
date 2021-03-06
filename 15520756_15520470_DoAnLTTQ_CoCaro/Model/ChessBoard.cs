﻿using System.Drawing;

namespace _15520756_15520470_DoAnLTTQ_CoCaro.Model
{
    public class ChessBoard
    {
        public int NumbRows { get; set; }
        public int NumbColumns { get; set; }
        public ChessBoard()
        {
            this.NumbColumns = this.NumbRows = 0;
        }

        public ChessBoard(int _numbRows, int _numbColumns)
        {
            this.NumbColumns = _numbColumns;
            this.NumbRows = _numbRows;
        }

        //Draw Broad
        public void DrawBroadChess(Graphics g)
        {
            for (int i = 0; i <= NumbColumns; i++)
            {
                g.DrawLine(new Pen(Color.Black), i * Cons.CHEST_WIDTH , 0, i * Cons.CHEST_WIDTH, Cons.CHEST_HEIGHT * NumbRows);
            }
            for (int j = 0; j <= NumbRows; j++)
            {
                g.DrawLine(new Pen(Color.Black), 0, j * Cons.CHEST_HEIGHT, Cons.CHEST_WIDTH * NumbColumns, j * Cons.CHEST_HEIGHT);

            }
        }
        // Vẽ quân cờ
        public void DrawChess(Graphics g, Point point, Image img)
        {
            g.DrawImage(img, point.X + 1, point.Y + 1, Cons.CHEST_WIDTH - 2, Cons.CHEST_HEIGHT - 2);
        }

        // Xóa quân cờ
        public void RemoveChess(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, Cons.CHEST_WIDTH - 2, Cons.CHEST_HEIGHT - 2);
        }
    }
}