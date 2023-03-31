using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7лаба_Андреева
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Control_NullTexBox(new TextBox[4] { textBox1, textBox2, textBox3, textBox4 });
                if (Program.rectangles.Count == 2)
                {
                    Program.rectangles.Clear(); 
                }
                Program.rectangles.Add(new Rectangle(int.Parse(textBox2.Text), int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
                MessageBox.Show("Прямоугольник задан!");
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.rectangles.Count != 2)
                throw new Exception($"Должно быть два прямоугольника!\nВ списке: {Program.rectangles.Count}");
            textBox5.Text = "Заданные прямоугольники: " + Program.rectangles[0].ToString() + "\t" + Program.rectangles[1].ToString();
            textBox5.Text += "\tВычисленные прямоугольники: " + "Общая часть: " + Rectangle.Cross(Program.rectangles[0], Program.rectangles[1]).ToString() + "\t" + "Наименьший прямоугольник включающий их: " + Rectangle.Unite(Program.rectangles[0], Program.rectangles[1]);
            textBox5.ScrollBars = ScrollBars.Vertical;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.rectangles.Count == 2)
            {
                Form2 selectedForm = new Form2();
                if (selectedForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Transfer(Program.rectangles[selectedForm.GetSelectedIndex()]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (Program.rectangles.Count == 1)
            {
                try
                {
                    Transfer(Program.rectangles[0]);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ни один прямоугольник не задан!");
            }

            void Transfer(Rectangle rectangle)
            {
                Control_NullTexBox(new TextBox[2] { textBox3, textBox4 });
                int x = rectangle.position_X;
                int y = rectangle.position_Y;
                rectangle.Transfer(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                textBox5.Text = $"До: позиция X: {x} позиция Y: {y}\tПосле: позиция X: {rectangle.position_X} позиция Y: {rectangle.position_Y}";
            }
        }

        private string Control_IsNumberOfString(string line, NumberTemplate numberTemplate)
        {
            string chars = (numberTemplate == NumberTemplate.Positive ? "1234567890" : "1234567890-");
            for(int i = 0, j = line.Length; i < j; i++)
            {
                if (!chars.Contains(line[i]) || (i > 0 && line[i] == '-'))
                {
                    line = line.Remove(i, 1);
                    j--;
                    i--;
                }
            }

            return line;
        }
        private void Control_NullTexBox(TextBox[] textBoxes)
        {
            for(int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].Text == "")
                {
                    throw new FormatException("Введите данные!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Control_IsNumberOfString(textBox1.Text, NumberTemplate.Positive);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = Control_IsNumberOfString(textBox2.Text, NumberTemplate.Positive);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Control_IsNumberOfString(textBox3.Text, NumberTemplate.Negative);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Control_IsNumberOfString(textBox4.Text, NumberTemplate.Negative);
        }

        enum NumberTemplate
        {
            Positive,
            Negative
        }
    }
}
