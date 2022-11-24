using System.Runtime.InteropServices;
using System.Text;
using System.Data.SQLite;

namespace Hw12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        readonly string DEFAULT_FILENAME = "words.sqlite";

        List<(string, string)> words = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            var filename = DEFAULT_FILENAME;
            if (!File.Exists(filename))
            {
                var dr = openFileDialog1.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
                filename = openFileDialog1.FileName;
            }

            using (var connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT en, zh FROM words ORDER BY en ASC", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    words.Add(((string)reader["en"], (string)reader["zh"]));
                }
            }
            Show();
            timer1.Enabled = true;
        }

        int next = 0;

        new void Show()
        {
            if (next == words.Count) return;
            lblEnglish.Text = words[next].Item1;
            lblChinese.Text = words[next].Item2;
            next++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Show();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            button1.Text = timer1.Enabled ? "Lock" : "Go";
        }
    }
}