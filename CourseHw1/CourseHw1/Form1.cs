namespace CourseHw1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random r = new();

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics() ?? throw new NullReferenceException();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            const int NUM = 1000;
            const int WIDTH = 25;
            
            var totalW = panel1.Width;
            var totalH = panel1.Height;

            var penA = new Pen(Color.Blue);
            var penB = new Pen(Color.Red);

            g.Clear(Color.White);

            var currentLine = 0;
            while (currentLine < totalH)
            {
                g.DrawLine(penA, new Point(0, currentLine), new Point(totalW, currentLine));
                currentLine += 2 * WIDTH;
            }

            var crossed = 0;
            for (var i = 0; i < NUM; i++)
            {
                var start = new Point(r.Next(totalW), r.Next(totalH));
                var direction = r.NextDouble() * 2 * Math.PI;
                var end = new Point((int)(start.X + WIDTH * Math.Sin(direction)), (int)(start.Y + WIDTH * Math.Cos(direction)));
                g.DrawLine(penB, start, end);

                var secStart = Math.Floor(start.Y / (2.0 * WIDTH));
                var secEnd = Math.Floor(end.Y / (2.0 * WIDTH));
                if (secStart != secEnd)
                {
                    crossed++;
                }
            }
            label1.Text = $"¹² {NUM} Ã¶£¬ÃüÖÐ {crossed} Ã¶£¬Pi = {1.0 * NUM / crossed : 0.00000}";
        }
    }
}