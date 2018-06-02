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
    public partial class Form1 : Form
    {
        int start_x;
        int start_y;
        int end_x;
        int end_y;
        int number;
        public Form1()
        {
            InitializeComponent();
            
        }

        Label[,] table;

       
        private void table_MouseHover(object sender, EventArgs e)
        {

        }
        private void table_MouseMove(object sender, MouseEventArgs e)
        {
            Label tb = (Label)sender;
            Control control1 = (Control)sender;
            
            if (e.Button == MouseButtons.Left)
            {       
                for (int i = 0; i < 7; ++i)
                {
                    for (int j = 0; j < 12; ++j)
                    {
                        int x = tb.Location.X + e.X;
                        int y = tb.Location.Y + e.Y;
                        if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                        {
                            
                            //table[i, j].Text = control1.Name + "capture" + i + " " + j + " " + number;
                            table[i, j].BackColor = Color.Blue;
                        }
                       
                    }
                }

            }

        }
        private void table_MouseDown(object sender, MouseEventArgs e)
        {
            Label tb = (Label)sender;
            tb.BackColor = Color.AliceBlue;
            number = 0;
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    int x = tb.Location.X + e.X;
                    int y = tb.Location.Y + e.Y;
                    if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                    {
                        table[i, j].Text = "capture" + i + " " + j;
                        start_x = i;
                        start_y = j;
                    }
                }
            }

        }
        private void table_MouseUp(object sender, MouseEventArgs e)
        {
            Label tb = (Label)sender;
            tb.BackColor = Color.AliceBlue;
            number = 0;
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    int x = tb.Location.X + e.X;
                    int y = tb.Location.Y + e.Y;
                    if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                    {
                        
                        end_x = i;
                        end_y = j;
                        table[i, j].Text = "capture" + i + " " + j;
                    }
                }
            }

            for(int i = start_y + 1; i <= end_y; i++)
            {
                table[start_x, i].Size = new Size(0, 0);
            }
            table[start_x, start_y].Size = new Size(50, (end_y - start_y + 1) * 40);

        }
        private void table_Capture(object sender, MouseEventArgs e)
        {

        }
        private void table_MouseClick(object sender, EventArgs e)
        {



            //if(tb.BackColor == Color.AliceBlue)
            //tb.BackColor = Color.AliceBlue;
        }

        bool click;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            click = false;
            table = new Label[7, 12];
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    table[i, j] = new Label();
                 
                    table[i, j].Size = new Size(50, 40);
                  
                    table[i, j].Location = new Point(50 * i, 40 * j);
                    table[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Controls.Add(table[i, j]);

                    table[i, j].MouseDown += new MouseEventHandler(table_MouseDown);
                    table[i, j].MouseMove += new MouseEventHandler(table_MouseMove);
                    table[i, j].MouseUp += new MouseEventHandler(table_MouseUp);

                }
            }
            table[1, 0].Text = "星期一";
            table[2, 0].Text = "星期二";
            table[3, 0].Text = "星期三";
            table[4, 0].Text = "星期四";
            table[5, 0].Text = "星期五";
            table[0, 1].Text = "   0810" + "\r\n" + "     ~" + "\r\n" + "   0900";
            table[0, 2].Text = "   0910" + "\r\n" + "     ~" + "\r\n" + "   1000";
            table[0, 3].Text = "   1010" + "\r\n" + "     ~" + "\r\n" + "   1100";
            table[0, 4].Text = "   1110" + "\r\n" + "     ~" + "\r\n" + "   1200";
            table[0, 5].Text = "   1210" + "\r\n" + "     ~" + "\r\n" + "   1300";
            table[0, 6].Text = "   1310" + "\r\n" + "     ~" + "\r\n" + "   1400";
            table[0, 7].Text = "   1410" + "\r\n" + "     ~" + "\r\n" + "   1500";
            table[0, 8].Text = "   1510" + "\r\n" + "     ~" + "\r\n" + "   1600";
            table[0, 9].Text = "   1610" + "\r\n" + "     ~" + "\r\n" + "   1700";
            table[0, 10].Text = "   1710" + "\r\n" + "     ~" + "\r\n" + "   1800";
            table[0, 11].Text = "   1810" + "\r\n" + "     ~" + "\r\n" + "   1900";
        }
    }
}
