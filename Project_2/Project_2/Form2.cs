using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HtmlAgilityPack;
using System.Collections;


namespace Project_2
{
    public partial class Form2 : Form
    {
        private Form1 f;
        String txt;
        ArrayList date = new ArrayList();
        List<string> classroom = new List<string>();
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f = f1;

           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = comboBox1.SelectedItem.ToString();
            //f.table[f.start_x, f.start_y].Text = ""  + date[comboBox1.SelectedIndex];
           // f.table[f.start_x, f.start_y].Text += "\r\n" + date[comboBox1.SelectedIndex].ToString().Substring(1,1);
            //f.table[f.start_x, f.start_y].Text += "\r\n";
            f.table[f.start_x, f.start_y].Text += "\r\n" + txt;
            f.table[f.start_x, f.start_y].Text += "\r\n";
            f.table[f.start_x, f.start_y].Text += "\r\n" + classroom[comboBox1.SelectedIndex];
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
            HtmlWeb client = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = client.Load("http://course-query.acad.ncku.edu.tw/qry/qry001.php?dept_no=F7");

            if (f.start_x != 6 && f.start_x != 7)
            {
                for (int i = 1; i < 63; ++i)
                {
                    if ((i % 11) != 0)
                    {
                        string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[17]").InnerText;
                        if (dateString.Substring(1, 1) == f.start_x.ToString())
                        {
                            date.Add(dateString);
                            string title = doc.DocumentNode.SelectSingleNode("//html / body / table / tbody / tr[" + i + "] / td[11]").InnerText;
                            dateString += title;
                            comboBox1.Items.Add(dateString);
                            string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                            classroom.Add(classroomString);
                        }
                    }
                }
            }
            else
            {
                comboBox1.Items.Add("");
            }
            comboBox1.SelectedIndex = 0;
            /*
            for (int i = 1; i < 63; ++i)
            {
                if ((i % 11) != 0)
                {
                    string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i +"]/td[17]").InnerText;
                    date.Add(dateString);
                }
            }
            for (int i = 1; i < 63; ++i)
            {
                if ((i % 11) != 0)
                {
                    string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                    classroom.Add(classroomString);
                }
            }
            */
            //comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            //textBox1.Enabled = false;
            //comboBox1.SelectedIndex = 0;
            //classroom = new string[9]{"65405","65405","65405","65203","65203","65304","65203","4263","65203" };
        }
    }
}
