using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Animator
    {
        private Circle? c;
        private Rect? r;
        private Thread? t = null;
        public bool IsAlive => t == null || t.IsAlive;
        public Size ContainerSize { get; set; }

        public Animator(Size containerSize, int x, int y, bool IsCircle)
        {
            if (IsCircle)
            {
                c = new Circle(75, x, y);
            } else
            {
                r = new Rect(75, x, y);
            }
            ContainerSize = containerSize;
        }

        public void Start()
        {
            t = new Thread(() =>
            {
                if (c != null)
                {
                    Random rnd = new Random();
                    int dx = 0;
                    int dy = 0;
                    while (dx == 0 && dy == 0)
                    {
                        dx = rnd.Next(-2, 2);
                        dy = rnd.Next(-2, 2);
                    }
                    while ((c.X + c.Diam < ContainerSize.Width) && (c.Y + c.Diam < ContainerSize.Height))
                    {
                        Thread.Sleep(30);
                        c.Move(dx, dy);
                    }
                }
                if (r != null)
                {
                    while (true)
                    {
                        Thread.Sleep(30);
                    }
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        public void PaintCircle(Graphics g)
        {
            if (c != null)
            {
                c.Paint(g);
            }
            else if (r != null)
            {
                r.Paint(g);
            }
        }
    }
}
