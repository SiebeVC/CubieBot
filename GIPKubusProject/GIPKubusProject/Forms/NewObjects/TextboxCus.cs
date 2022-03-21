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
    class TextboxCus : TextBox
    {
        public TextboxCus()
        {
            BackColor = Color.Orange;
            Height = 100;
            Width = 50;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {




            GraphicsPath g = new GraphicsPath();

            this.Region = new Region(g);

            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, this.Width, this.Height);




            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(this.Width + 3, this.Height / 2), this.ForeColor, flags);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}