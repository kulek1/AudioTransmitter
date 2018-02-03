using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioTransmitter_Client
{
    class WindowResizer
    {
        private const int MAX_WINDOW_SIZE = 1764;
        private const int MIN_WINDOW_SIZE = 819;
        private static Form1 self;

        public WindowResizer(Form1 context)
        {
            self = context;
        }

        public void fire()
        {

            if (self.Width == MIN_WINDOW_SIZE)
            {
                open();
            } else
            {
                close();
            }
        }

        private void open()
        {
            int a = 1;
            for (int i = self.Width; i <= MAX_WINDOW_SIZE; i += (1) * a)
            {
                self.Width = i;
                a++;
            }
            maxMoveBar();
        }
        private void close()
        {
            int a = 1;
            for (int i = self.Width; i >= MIN_WINDOW_SIZE; i -= (1) * a)
            {
                self.Width = i;
                a++;
            }
            minMoveBar();
        }
        private void maxMoveBar()
        {
            self.moveBarRef.Size = new System.Drawing.Size(MAX_WINDOW_SIZE - 240, 55);
        }
        private void minMoveBar()
        {
            self.moveBarRef.Size = new System.Drawing.Size(560, 55);
        }
    }
}
