using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace Project_2
{
    public partial class Form1 : Form
    {
        public Form2 f2;
        public int start_x;
        public int start_y;
        int end_x;
        int end_y;
        public bool dis;
        int number;
        public Form1()
        {
            InitializeComponent();
           
            
        }

        public Label[,] table;
        

       
        
        private void table_MouseMove(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked)
            {//normal
                Label tb = (Label)sender;
                Control control1 = (Control)sender;

                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 1; i < 8; ++i)
                    {
                        for (int j = 1; j < 12; ++j)
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
        }
        private void table_MouseDown(object sender, MouseEventArgs e)
        {
            Label tb = (Label)sender;
            int x = tb.Location.X + e.X;
            int y = tb.Location.Y + e.Y;
            if (radioButton2.Checked)//normal
            {
                //tb.BackColor = Color.AliceBlue;
                number = 0;
                for (int i = 1; i < 8; ++i)
                {
                    for (int j = 1; j < 12; ++j)
                    {
                        //if (i == 5) continue;

                        if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                        {
                            //table[i, j].Text = "capture" + i + " " + j;
                            start_x = i;
                            start_y = j;
                        }
                    }
                }
            }
            else if (radioButton1.Checked)//delete
            {
                for (int i = 1; i < 8; ++i)
                {
                    for (int j = 1; j < 12; ++j)
                    {
                        if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                        {
                            int count = tb.Height / 40;
                            //table[i, j].Text = "";
                            for (int k = j; k < j + count; ++k)
                            {
                                table[i, k].Size = new Size(50, 40);
                                if(j==5)
                                    table[i, k].BackColor = Color.Orange;//noon
                                else
                                    table[i, k].BackColor = SystemColors.Control;
                                table[i, k].Text = "";
                            }
                            //table[i, j].Size = new Size(50, 40);
                        }
                    }
                }
            }

        }
        private void table_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (radioButton2.Checked)//normal
            {
                Label tb = (Label)sender;
                if (tb.Bottom == 40 || tb.Left == 0)
                    return;
                //tb.BackColor = Color.AliceBlue;
                //tb.Text = tb.Left.ToString();
                number = 0;
                for (int i = 1; i < 8; ++i)
                {
                    for (int j = 1; j < 12; ++j)
                    {
                        //if (i == 5) continue;

                        int x = tb.Location.X + e.X;
                        int y = tb.Location.Y + e.Y;
                        if (table[i, j].Left <= x && table[i, j].Right >= x && table[i, j].Top <= y && table[i, j].Bottom >= y)
                        {
                            end_x = i;
                            if (end_x != start_x)
                            {
                                if (end_x < start_x)
                                {
                                    int xxx = end_x;
                                    end_x = start_x;
                                    start_x = xxx;
                                }
                                for (int k = start_x; k <= end_x; ++k)
                                    table[k, start_y].BackColor = SystemColors.Control;

                                return;
                            }




                            end_y = j;
                            //table[i, j].Text = "capture" + i + " " + j;
                        }
                    }
                }
                if (start_y != end_y)
                {

                    if (start_y > end_y)
                    {
                        int sss = start_y;
                        start_y = end_y;
                        end_y = sss;
                    }

                    for (int i = start_y + 1; i <= end_y; i++)
                    {
                        table[start_x, i].Size = new Size(0, 0);
                    }


                    table[start_x, start_y].Size = new Size(50, (end_y - start_y + 1) * 40);
                }
                f2 = new Form2(this);
                f2.Show();
            }
        }
     
  
        bool click;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            click = false;
            table = new Label[8, 12];
            //radioButton1.Checked = false;
            //radioButton2.Checked = true;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    table[i, j] = new Label();
                    //DrawRoundRect(table[i, j]);

                    table[i, j].Size = new Size(50, 40);
                  
                    table[i, j].Location = new Point(50 * i, 40 * (j+1));
                    table[i, j].BorderStyle = BorderStyle.Fixed3D;
                    //table[i,j].BackColor = 
                    Controls.Add(table[i, j]);

                    table[i, j].MouseDown += new MouseEventHandler(table_MouseDown);
                    table[i, j].MouseMove += new MouseEventHandler(table_MouseMove);
                    table[i, j].MouseUp += new MouseEventHandler(table_MouseUp);

                }
            }
            table[1, 0].Text = "Mon";
            table[2, 0].Text = "Tue";
            table[3, 0].Text = "Wed";
            table[4, 0].Text = "Thu";
            table[5, 0].Text = "Fri";
            table[6, 0].Text = "Sat";
            table[7, 0].Text = "Sun";
            table[0, 1].Text = "   0810" + "\r\n      一" + "\r\n" + "   0900";
            table[0, 2].Text = "   0910" + "\r\n      二" + "\r\n" + "   1000";
            table[0, 3].Text = "   1010" + "\r\n      三" + "\r\n" + "   1100";
            table[0, 4].Text = "   1110" + "\r\n      四" + "\r\n" + "   1200";
            table[0, 5].Text = "   1210" + "\r\n      五" + "\r\n" + "   1300";
            table[0, 6].Text = "   1310" + "\r\n      六" + "\r\n" + "   1400";
            table[0, 7].Text = "   1410" + "\r\n      七" + "\r\n" + "   1500";
            table[0, 8].Text = "   1510" + "\r\n      八" + "\r\n" + "   1600";
            table[0, 9].Text = "   1610" + "\r\n      九" + "\r\n" + "   1700";
            table[0, 10].Text = "   1710" + "\r\n      十" + "\r\n" + "   1800";
            table[0, 11].Text = "   1810" + "\r\n      土" + "\r\n" + "   1900";

            for (int i = 1; i < 8; ++i)
                table[i, 5].BackColor = Color.Orange;//noon
            table[0, 0].BackColor = Color.Black;
            for (int i = 1; i <8; ++i)
                table[i, 0].BackColor = Color.White;
            for (int i = 1; i < 12; ++i)
                table[0, i].BackColor = Color.White;
            DateTime time = DateTime.Today;
            label1.Text = time.ToString("D");
            label1.Text += time.DayOfWeek.ToString();
            //table[0,0].Text = time.DayOfWeek.ToString();
            if(time.DayOfWeek == DayOfWeek.Monday)
                for (int i = 0; i < 12; ++i)
                    table[1, i].BorderStyle = BorderStyle.FixedSingle;
            else if (time.DayOfWeek == DayOfWeek.Tuesday)
                for (int i = 0; i < 12; ++i)
                    table[2, i].BorderStyle = BorderStyle.FixedSingle;
            else if (time.DayOfWeek == DayOfWeek.Wednesday)
                for (int i = 0; i < 12; ++i)
                    table[3, i].BorderStyle = BorderStyle.FixedSingle;
            else if(time.DayOfWeek == DayOfWeek.Thursday)
                for (int i = 0; i < 12; ++i)
                    table[4, i].BorderStyle = BorderStyle.FixedSingle;
            else if (time.DayOfWeek == DayOfWeek.Friday)
                for (int i = 0; i < 12; ++i)
                    table[5, i].BorderStyle = BorderStyle.FixedSingle;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //圓角邊框
        private void DrawRoundRect(Label label)
        {
            float X = (float)(label.Width);
            float Y = (float)(label.Height);
            PointF[] points =
            {
               new PointF(2,0),
               new PointF(X-2,0),
               new PointF(X,2),
               new PointF(X,Y-2),
               new PointF(X-2,Y),
               new PointF(2,Y),
               new PointF(0,Y-2),
               new PointF(0,2),
           };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            label.Region = new Region(path);
        }

    }
}
