using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    internal class Rect
    {
        private Random r = new();
        private int diam;
        private int x, y;

        public int X => x;
        public int Y => y;
        public int Diam => diam;
        public Color Color { get; set; }
        public Rect(int diam, int x, int y)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }



        public void Paint(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Diam, Diam);
        }
    }
}
