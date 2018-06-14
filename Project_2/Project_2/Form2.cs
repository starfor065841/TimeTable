using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class Form2 : Form
    {
        private Form1 f;
        String txt;
        string[] classroom;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f = f1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = comboBox1.SelectedItem.ToString();
            f.table[f.start_x, f.start_y].Text = txt;
            f.table[f.start_x, f.start_y].Text += "\r\n"+classroom[comboBox1.SelectedIndex];
            f.table[f.start_x, f.start_y].BackColor = label1.BackColor;
            //f.f2.Dispose();            
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label1.BackColor = colorDialog1.Color;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox1.SelectedIndex = 0;
            classroom = new string[9]{"65405","65405","65405","65203","65203","65304","65203","4263","65203" };
        }
    }
}
