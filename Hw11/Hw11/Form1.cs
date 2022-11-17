using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Hw11
{
    struct Item
    {
        public string Name;
        public string Link;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Item[] items = new Item[1];
        HttpClient client = new();

        private async void Form1_Load(object sender, EventArgs e)
        {
            var index = await client.GetStringAsync("https://cdn.jsdelivr.net/npm/@gytx/cppreference-index/dist/generated.json");
            var rootArr = JsonNode.Parse(index)?.AsArray();
            var words = from n in rootArr
                        where (string?)n["type"] == "symbol"
                        let name = (string?)n["name"] + (n["note"] is null ? "" : ($" ({n["note"]})"))
                        let link = (string?)n["link"]
                        orderby name.Length
                        select new Item
                        {
                            Name = name,
                            Link = link,
                        };
            items = words.ToArray();
            RefreshList();
        }

        void RefreshList()
        {
            listBox1.Items.Clear();
            foreach (var i in items)
            {
                if (i.Name.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(i.Name);
                }
            }
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private async void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string selected;
            if (listBox1.Items.Count == 1)
            {
                selected = (string)listBox1.Items[0];
            } else
            {
                selected = (string)listBox1.SelectedItem;
                if (selected is null) return;
            }
            var chosen = from i in items
            where i.Name == selected
            select i;
            var link = chosen.First().Link;
            var url = $"https://en.cppreference.com/w/{link}";
            var html = await client.GetStringAsync(url);

            var matches = Regex.Matches(html, @"Defined in header .*&lt;(\w+)&gt;");

            textBox2.Text = string.Join(Environment.NewLine, new HashSet<string>(matches.Select(m => $"#include <{m.Groups[1].Value}>")));
        }
    }
}