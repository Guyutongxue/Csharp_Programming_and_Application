using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace 打地鼠游戏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictures = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25 };
            imgDefault = imageList.Images[0];
            imgShow = imageList.Images[1];
            imgKnocked = imageList.Images[2];

            foreach (var (p, idx) in pictures.Select((value, i) => (value, i)))
            {
                p.MouseDown += (o, e) =>
                {
                    p.Cursor = downCursor;
                    if (target == idx)
                    {
                        pictures[target].Image = imgKnocked;
                        score++;
                        labelScore.Text = score.ToString();
                        labelLevel.Text = "第" + score / 10 + "关";
                    }
                };
                p.MouseUp += (_, _) => p.Cursor = upCursor;
                p.Image = imgDefault;
            }
        }

        readonly PictureBox[] pictures;
        readonly Image imgDefault;
        readonly Image imgShow;
        readonly Image imgKnocked;

        int target = 0;
        int score = 0;
        static readonly Cursor downCursor = new(((Bitmap)Image.FromFile("c1.gif")).GetHicon());
        static readonly Cursor upCursor = new(((Bitmap)Image.FromFile("c2.gif")).GetHicon());

        private void StartGame(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (score < 10)
            {
                timer.Interval = 1000;
            }
            else if (score < 20)
            {
                timer.Interval = 500;
            }
            else if (score < 30)
            {
                timer.Interval = 250;
            }
            else
            {
                timer.Interval = 125;
            }

            target = new Random().Next(25);
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].Cursor = upCursor;
                if (i == target) pictures[i].Image = imgShow;
                else pictures[i].Image = imgDefault;
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}