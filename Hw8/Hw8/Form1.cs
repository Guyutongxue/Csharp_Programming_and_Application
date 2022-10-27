using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hw8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var x = new Color();
        }

        const int MARGIN = 10;
        const int SIZE = 200;
        const int FONT_SIZE = 15;

        const int R = SIZE / 2 - 10;

        void DrawInCurve(Graphics g, float angle, char text)
        {
            using var font = new Font("ËÎÌו", 16);
            using var brush = new SolidBrush(Color.Red);
            g.TranslateTransform(MARGIN + 10 + R, MARGIN + 10 + R);
            g.RotateTransform(angle - 90.0f);
            g.TranslateTransform(-FONT_SIZE, -R + FONT_SIZE / 2);
            g.DrawString(new string(text, 1), font, brush, new PointF(0, 0));
            g.ResetTransform();
        }

        void DrawStar(Graphics g)
        {
            double theta = Math.PI;
            double delta = 4 * Math.PI / 5;
            var points = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                points[i] = new PointF(25 * (float)Math.Sin(theta), 25 * (float)Math.Cos(theta));
                theta += delta;
            }
            var gp = new GraphicsPath(points,new byte[5]{ 1, 1, 1, 1, 1}, FillMode.Winding);
            g.TranslateTransform(MARGIN + 10 + R, MARGIN + 10 + R);
            g.FillPath(new SolidBrush(Color.Red), gp);
            g.ResetTransform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var g = panel1.CreateGraphics();
            g.Clear(DefaultBackColor);

            g.DrawEllipse(new Pen(Color.Red, 5.0f), new Rectangle(new Point(MARGIN, MARGIN), new Size(SIZE, SIZE)));
            g.DrawEllipse(new Pen(Color.Red), new Rectangle(new Point(MARGIN + 5, MARGIN + 5), new Size(SIZE - 10, SIZE - 10)));

            string text = textBox1.Text;

            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (text.Length == 1)
            {
                text = $" {text} ";
            }

            float th = 0.0f;
            float delta = 180.0f / (text.Length - 1);
            DrawInCurve(g, th, text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                th += delta;
                DrawInCurve(g, th, text[i]);
            }
            DrawStar(g);
        }
    }
}