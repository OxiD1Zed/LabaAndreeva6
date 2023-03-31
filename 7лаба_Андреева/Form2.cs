using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7лаба_Андреева
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] lines = new string[Program.rectangles.Count];
            for(int i = 0; i < lines.Length; i++)
                lines[i] = Program.rectangles[i].ToString();
            listBox1.Items.AddRange(lines);
        }

        public int GetSelectedIndex()
        {
            return listBox1.SelectedIndex;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
