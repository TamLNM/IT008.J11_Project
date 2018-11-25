using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15520756_15520470_DoAnLTTQ_CoCaro.Model
{
    public class ChessPiece
    {

        public int Row { get; set; }
        public int Column { get; set; }
        public Point Position { get; set; }
        public int Owner { get; set; }

        public ChessPiece(int row, int column, Point pos, int owner)
        {
            Row = row;
            Column = column;
            Position = pos;
            Owner = owner;
        }
    }
}

