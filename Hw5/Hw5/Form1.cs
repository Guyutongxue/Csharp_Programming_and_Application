using System.Security.Cryptography.X509Certificates;

namespace Hw5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        void Draw()
        {
            graphics.Clear(Color.White);
            DrawTree(DEPTH, 200, 310, 100, -PI / 2);
        }

        private Graphics graphics;
        const double PI = Math.PI;
        const int DEPTH = 10;
        double th1 = 40 * PI / 180;
        double th2 = 30 * PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        Color start = Color.FromArgb(255, 0, 0);
        Color end = Color.FromArgb(0, 255, 0);

        Color GetColor(int n)
        {
            int r = end.R - (end.R - start.R) * n / DEPTH;
            int g = end.G - (end.G - start.G) * n / DEPTH;
            int b = end.B - (end.B - start.B) * n / DEPTH;
            return Color.FromArgb(r, g, b);
        }

        void DrawTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * 0.6 * Math.Cos(th);
            double y2 = y0 + leng * 0.6 * Math.Sin(th);

            graphics.DrawLine(new Pen(GetColor(n), n / 2), (int)x0, (int)y0, (int)x1, (int)y1);

            DrawTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        private void textBoxTh1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxTh1.Text, out var x))
            {
                th1 = x * PI / 180;
            }
        }

        private void textBoxTh2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxTh2.Text, out var x))
            {
                th2 = x * PI / 180;
            }
        }

        private void textBoxL1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxL1.Text, out var x))
            {
                per1 = x;
            }
        }

        private void textBoxL2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxL1.Text, out var x))
            {
                per2 = x;
            }
        }

        private void buttonStColor_Click(object sender, EventArgs e)
        {
            var r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                start = colorDialog1.Color;
                buttonStColor.BackColor = start;
            }
        }

        private void buttonEdColor_Click(object sender, EventArgs e)
        {
            var r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                end = colorDialog1.Color;
                buttonEdColor.BackColor = end;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }
    }
}