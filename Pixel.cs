using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Image
{
    class Pixel
    {
        private byte R;
        private byte G;
        private byte B;
        public Pixel (byte R, byte G, byte B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
        public byte r
        {
            get
            {
                return this.R;
            }
            set
            {
                this.R = value;
            }
        }
        public byte g
        {
            get { return this.G; }
            set
            {
                this.G = value;
            }
        }
        public byte b
        {
            get { return this.B; }
            set
            {
                this.B = value;
            }
        }
    }
}