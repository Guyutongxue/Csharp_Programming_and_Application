namespace Hw1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new();

        private void button1_Click(object sender, EventArgs e)
        {
            var x = (Width - 150) * random.NextDouble();
            var y = (Height - 150) * random.NextDouble();
            button1.Location = new Point((int)x, (int)y);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Exit(e.KeyChar);
        }

        private void Exit(char key)
        {
            if (key == (char)0x1b)
            {
                Application.Exit();
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Exit(e.KeyChar);
        }
    }
}