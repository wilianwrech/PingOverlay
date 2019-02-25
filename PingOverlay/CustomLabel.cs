﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PingOverlay
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            OutlineForeColor = Color.Black;
            OutlineWidth = 2;
        }

        public Color OutlineForeColor { get; set; }
        public float OutlineWidth { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
            using (var gp = new GraphicsPath())
            using (var outline = new Pen(OutlineForeColor, OutlineWidth)
            { LineJoin = LineJoin.Round })
            using (var sf = new StringFormat())
            using (Brush foreBrush = new SolidBrush(ForeColor))
            {
                gp.AddString(Text, Font.FontFamily, (int)Font.Style,
                    Font.Size, ClientRectangle, sf);
                e.Graphics.ScaleTransform(1.3f, 1.35f);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawPath(outline, gp);
                e.Graphics.FillPath(foreBrush, gp);
            }
        }
    }
}