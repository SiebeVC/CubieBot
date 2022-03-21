using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Layout
{
    class CircButton : Button
    {

        public CircButton()
        {
            BackColor = Color.Orange;
            Height = 50;
            Width = 50;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {




            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(g);

            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, this.Width, this.Height);




            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(this.Width + 3, this.Height / 2), this.ForeColor, flags);

        }
    }
}