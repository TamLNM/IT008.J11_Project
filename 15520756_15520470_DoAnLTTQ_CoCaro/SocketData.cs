using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15520756_15520470_DoAnLTTQ_CoCaro
{
    [Serializable]
    public class SocketData
    {
        // Type of message
        private int command;

        private int mouseX, mouseY;

        private String message;


        public int Command { get => command; set => command = value; }
        public string Message { get => message; set => message = value; }
        public int MouseX { get => mouseX; set => mouseX = value; }
        public int MouseY { get => mouseY; set => mouseY = value; }

        public SocketData(int command, int mouseX, int mouseY, String message = null)
        {
            this.Command    = command;
            this.MouseX     = mouseX;
            this.MouseY     = mouseY;
            this.Message    = message;
        }
        public SocketData(int command)
        {
            this.Command = command;
        }


        public enum SocketCommand
        {
            SEND_POINT,
            NOTIFY,
            NEW_GAME,
            UNDO,
            REDO,
            QUIT,
            NOTHING
        }
    }
}
