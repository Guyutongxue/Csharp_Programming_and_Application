using static System.Net.Mime.MediaTypeNames;

namespace Hw2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBarTimer.Maximum = MAX_TICKS;
        }

        Question q;
        int ticks = 0;
        int correctNum = 0;
        readonly int MAX_TICKS = 50;

        private void Form1_Load(object sender, EventArgs e)
        {
            next();
            timer1.Start();
        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {
            if (check(textBoxAnswer.Text))
            {
                textBoxAnswer.BackColor = Color.LightGreen;
                showResult();
            }
            else
            {
                textBoxAnswer.BackColor = Color.LightPink;
            }
        }

        void next()
        {
            q = new();
            labelQuestion.Text = q.GetText();
            textBoxAnswer.Text = "";
        }

        void showResult()
        {
            timer1.Stop();
            ticks = progressBarTimer.Value = 0;
            correctNum++;
            labelStat.Text = $"Score: {correctNum}";
            System.Windows.Forms.Application.DoEvents();
            Thread.Sleep(500);
            next();
            timer1.Start();
        }

        bool check(string text)
        {
            int num;
            if (!int.TryParse(text, out num)) return false;
            return num == q.Expected;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks == MAX_TICKS)
            {
                ticks = 0;
                next();
            }
            progressBarTimer.Value = ticks;
        }
    }

    class Question
    {
        int lhs;
        int rhs;
        public int Expected { get; }
        enum Op { Add, Sub, Mul };
        Op op;

        Random rand = new();

        public Question()
        {
            op = (Op)rand.Next(3);
            switch (op)
            {
                case Op.Add:
                    lhs = rand.Next(0, 100);
                    rhs = rand.Next(1, 100 - lhs);
                    Expected = lhs + rhs;
                    break;
                case Op.Sub:
                    lhs = rand.Next(0, 100);
                    rhs = rand.Next(0, lhs);
                    Expected = lhs - rhs;
                    break;
                case Op.Mul:
                    lhs = rand.Next(0, 10);
                    rhs = rand.Next(0, 10);
                    Expected = lhs * rhs;
                    break;
                default:
                    throw new InvalidDataException();
            }
        }

        string GetOpText()
        {
            switch (op)
            {
                case Op.Add: return "+";
                case Op.Sub: return "-";
                case Op.Mul: return "*";
                default: throw new InvalidDataException();
            }
        }

        public string GetText()
        {
            return $"{lhs}{GetOpText()}{rhs}=";
        }
    }
}