using System.Text.RegularExpressions;

namespace Hw9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        readonly int[] WEIGHT = new int[17] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        const string MAP = "10X98765432";
        readonly Regex REGEX = new(@"^[1-9]\d{5}(18|19|20)\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (REGEX.IsMatch(textBox1.Text))
            {
                int total = 0;
                for (int i = 0; i < 17; i++)
                {
                    total += WEIGHT[i] * (textBox1.Text[i] - '0');
                }
                if (MAP[total % 11] == textBox1.Text.ToUpper()[17])
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "符合格式；校验通过";
                } else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "校验失败";

                }
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "不符合身份证格式";
            }
        }
    }
}