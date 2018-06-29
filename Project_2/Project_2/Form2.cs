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
        String choose;
        List<string> date = new List<string>();
        List<string> classroom = new List<string>();
        char[] delimiter = { '[', ']' };
        String[] subdate;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f = f1;
            init();
           
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                txt = comboBox2.SelectedItem.ToString();
                //f.table[f.start_x, f.start_y].Text = ""  + date[comboBox1.SelectedIndex];
                // f.table[f.start_x, f.start_y].Text += "\r\n" + date[comboBox1.SelectedIndex].ToString().Substring(1,1);
                //f.table[f.start_x, f.start_y].Text += "\r\n";
                //f.table[f.start_x, f.start_y].Text += "\r\n" + txt;
                //f.table[f.start_x, f.start_y].Text += "\r\n";
                //f.table[f.start_x, f.start_y].Text += "\r\n" + classroom[comboBox2.SelectedIndex];
                //f.table[f.start_x, f.start_y].BackColor = label1.BackColor;

                //不同日期
                subdate = date[comboBox2.SelectedIndex].Split(delimiter);
                for(int i = 1; i < subdate.Length; i = i + 2)
                {
                    int start = 0;
                    int end = 0;
                    if (subdate[i + 1].Length > 1)
                    {
                        if (subdate[i + 1].Substring(0,1) == "N")
                        {
                            start = 5;
                        }
                        else if (subdate[i + 1].Substring(0, 1) == "A")
                        {
                            start = 11;
                        }
                        else if (subdate[i + 1].Substring(0, 1) == "B")
                        {
                            start = 12;
                        }
                        else if (subdate[i + 1].Substring(0, 1) == "C")
                        {
                            start = 13;
                        }
                        else if (subdate[i + 1].Substring(0, 1) == "D")
                        {
                            start = 14;
                        }
                        else if (subdate[i + 1].Substring(0, 1) == "E")
                        {
                            start = 15;
                        }
                        else
                        {
                            start = int.Parse(subdate[i + 1].Substring(0, 1));
                            //第五節往下一節
                            if (start >= 5)
                            {
                                start++;
                            }
                        }

                        if (subdate[i + 1].Substring(2) == "N")
                        {
                            end = 5;
                        }
                        else if (subdate[i + 1].Substring(2) == "A")
                        {
                            end = 11;
                        }
                        else if (subdate[i + 1].Substring(2) == "B")
                        {
                            end = 12;
                        }
                        else if (subdate[i + 1].Substring(2) == "C")
                        {
                            end = 13;
                        }
                        else if (subdate[i + 1].Substring(2) == "D")
                        {
                            end = 14;
                        }
                        else if (subdate[i + 1].Substring(2) == "E")
                        {
                            end = 15;
                        }
                        else
                        {
                            end = int.Parse(subdate[i + 1].Substring(2));
                            //第五節往下一節
                            if (end >= 5)
                            {
                                end++;
                            }
                        }

                    }
                    else
                    {
                        if(subdate[i + 1].Substring(0) == "N")
                        {
                            start = 5;
                            end = 5;
                        }
                        else if (subdate[i + 1].Substring(0) == "A")
                        {
                            start = 11;
                            end = 11;
                        }
                        else if (subdate[i + 1].Substring(0) == "B")
                        {
                            start = 12;
                            end = 12;
                        }
                        else if (subdate[i + 1].Substring(0) == "C")
                        {
                            start = 13;
                            end = 13;
                        }
                        else if (subdate[i + 1].Substring(0) == "D")
                        {
                            start = 14;
                            end = 14;
                        }
                        else if (subdate[i + 1].Substring(0) == "E")
                        {
                            start = 15;
                            end = 15;
                        }
                        else
                        {
                            start = int.Parse(subdate[i + 1].Substring(0));
                            end = int.Parse(subdate[i + 1].Substring(0));
                            //第五節往下一節
                            if(start >= 5)
                            {
                                start++;
                            }
                            if (end >= 5)
                            {
                                end++;
                            }
                        }
                    }
                    if (start != end)
                    {

                        if (start > end)
                        {
                            int sss = start;
                            start = end;
                            end = sss;
                        }

                        for (int j = start + 1; j <= end; j++)
                        {
                            f.table[int.Parse(subdate[i]), j].Size = new Size(0, 0);
                        }

                        f.table[int.Parse(subdate[i]), start].Size = new Size(50, (end - start + 1) * 40);
                    }
                    f.table[int.Parse(subdate[i]), start].Text += "\r\n" + txt;
                    f.table[int.Parse(subdate[i]), start].Text += "\r\n";
                    f.table[int.Parse(subdate[i]), start].Text += "\r\n" + classroom[comboBox2.SelectedIndex];
                    f.table[int.Parse(subdate[i]), start].BackColor = label1.BackColor;

                }

                /*
                if (date[comboBox2.SelectedIndex].Length >= 6)
                {
                   foreach(var substring in subdate)
                    {
                        Console.WriteLine(substring);
                    }

                }

                */
            }
            else
            {
                txt = "";
                f.table[f.start_x, f.start_y].Text += txt;
            }
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

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedItem = 0;
            choose = comboBox1.SelectedItem.ToString().Substring(1, 2);

            //初始爬資料
            HtmlWeb client = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = client.Load("http://course-query.acad.ncku.edu.tw/qry/qry001.php?dept_no=" + choose);

            var table2 = doc.GetElementbyId("roomInfo");

            int k = 0;
            HtmlNodeCollection tables = doc.DocumentNode.SelectNodes(".//tr");

            foreach (HtmlNode table in tables)
            {
                //count row
                k++;
            }

            //if (f.start_x != 6 && f.start_x != 7)
            //{
                for (int i = 1; i < k; ++i)
                {
                    if ((i % 11) != 0)
                    {
                        string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[17]").InnerText;
                        if (dateString.Substring(1, 1) == f.start_x.ToString())
                        {
                            date.Add(dateString);
                            string title = doc.DocumentNode.SelectSingleNode("//html / body / table / tbody / tr[" + i + "] / td[11]").InnerText;
                            dateString += title;
                            comboBox2.Items.Add(dateString);
                            string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                            classroom.Add(classroomString);
                        }
                    }
                }
            //}
            /*
            else
            {
                comboBox2.Items.Add("");
            }
            */

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            for (int i = 1; i < k; ++i)
            {
                if ((i % 11) != 0)
                {
                    string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[17]").InnerText;
                    date.Add(dateString);
                }
            }
            for (int i = 1; i < k; ++i)
            {
                if ((i % 11) != 0)
                {
                    string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                    classroom.Add(classroomString);
                }
            }

        }

        public void init()
        {
            //其他
            comboBox1.Items.Add("(A2) 體育室 OPE");
            comboBox1.Items.Add("(A3) 軍訓室 MT");
            comboBox1.Items.Add("(A4) 師培中心 CTE");
            comboBox1.Items.Add("(A5) 計網中心 CN");
            comboBox1.Items.Add("(A6) 服務學習 SS");
            comboBox1.Items.Add("(AA) 共同英授");
            comboBox1.Items.Add("(AH) 華語中心 CLC");
            //不分學院
            comboBox1.Items.Add("(AN) 不分系學程 CCEP");
            comboBox1.Items.Add("(C0) 科學班");
            //通識課程
            comboBox1.Items.Add("(A1) 外國語言 FLL");
            comboBox1.Items.Add("(A9) 通識中心 GE");
            comboBox1.Items.Add("(AG) 公民歷史");
            comboBox1.Items.Add("(A7) 基礎國文 CL");
            //文學院
            comboBox1.Items.Add("(B0) 文學院學士班 CLA");
            comboBox1.Items.Add("(B1) 中文系 CL");
            comboBox1.Items.Add("(K1) 中文所 CL");
            comboBox1.Items.Add("(B2) 外文系 FLL");
            comboBox1.Items.Add("(K2) 外文所 FLL");
            comboBox1.Items.Add("(B3) 歷史系 HIS");
            comboBox1.Items.Add("(K3) 歷史所 HIS");
            comboBox1.Items.Add("(B5) 台文系 TWL");
            comboBox1.Items.Add("(K5) 台文所 TWL");
            comboBox1.Items.Add("(K4) 藝術所 AS");
            comboBox1.Items.Add("(K8) 戲劇碩士學程 AD");
            comboBox1.Items.Add("(K7) 考古所 Arxe");
            //理學院
            comboBox1.Items.Add("(C1) 數學系 MATH");
            comboBox1.Items.Add("(L1) 應數所 MATH");
            comboBox1.Items.Add("(C2) 物理系 PHYS");
            comboBox1.Items.Add("(L2) 物理所 PHYS");
            comboBox1.Items.Add("(C3) 化學系 CHEM");
            comboBox1.Items.Add("(L3) 化學所 CHEM");
            comboBox1.Items.Add("(C4) 地科系 EARS");
            comboBox1.Items.Add("(L4) 地科所 EARS");
            comboBox1.Items.Add("(CZ) 理學院學士班 COS");
            comboBox1.Items.Add("(LZ) 理學院研究所 COS");
            comboBox1.Items.Add("(F8) 光電系 DPS");
            comboBox1.Items.Add("(L7) 光電所 DPS");
            comboBox1.Items.Add("(LA) 電漿所 SAPS");
            comboBox1.Items.Add("(VF) 發光二極");
            //工學院
            comboBox1.Items.Add("(E0) 工學院 COE");
            comboBox1.Items.Add("(E1) 機械系 ME");
            comboBox1.Items.Add("(N1) 機械所 ME");
            comboBox1.Items.Add("(E3) 化工系 CHE");
            comboBox1.Items.Add("(N3) 化工所 CHE");
            comboBox1.Items.Add("(E4) 資源系 RE");
            comboBox1.Items.Add("(N4) 資源所 RE");
            comboBox1.Items.Add("(E5) 材料系 MSE");
            comboBox1.Items.Add("(N5) 材料所 MSE");
            comboBox1.Items.Add("(E6) 土木系 CE");
            comboBox1.Items.Add("(N6) 土木所 CE");
            comboBox1.Items.Add("(E8) 水利系 HOE");
            comboBox1.Items.Add("(N8) 水利所 HOE");
            comboBox1.Items.Add("(NC) 自災所 iNHM");
            comboBox1.Items.Add("(E9) 工科系 ES");
            comboBox1.Items.Add("(N9) 工科所 ES");
            comboBox1.Items.Add("(F0) 能源學程 IBPE");
            comboBox1.Items.Add("(F1) 系統系 SNHE");
            comboBox1.Items.Add("(P1) 系統所 SYS");
            comboBox1.Items.Add("(F4) 航太系 AA");
            comboBox1.Items.Add("(P4) 航太所 AA");
            comboBox1.Items.Add("(Q4) 民航所 CA");
            comboBox1.Items.Add("(F5) 環工系 EV");
            comboBox1.Items.Add("(P5) 環工所 EV");
            comboBox1.Items.Add("(F6) 測量系 GM");
            comboBox1.Items.Add("(P6) 測量所 GM");
            comboBox1.Items.Add("(F9) 醫工系 BME");
            comboBox1.Items.Add("(P8) 醫工所 BME");
            comboBox1.Items.Add("(N0) 工程管理 EM");
            comboBox1.Items.Add("(NA) 海事所 OTMA");
            comboBox1.Items.Add("(NB) 尖端所 icam");
            comboBox1.Items.Add("(P0) 能源學程 IBPE");
            //管理學院
            comboBox1.Items.Add("(H1) 會計系 ACC");
            comboBox1.Items.Add("(R1) 會計所 ACC");
            comboBox1.Items.Add("(H2) 統計系 STAT");
            comboBox1.Items.Add("(R2) 統計所 STAT");
            comboBox1.Items.Add("(H3) 工資系 IIM");
            comboBox1.Items.Add("(R3) 工資所 IIM");
            comboBox1.Items.Add("(R7) 資管系 IM");
            comboBox1.Items.Add("(H4) 企管系 BA");
            comboBox1.Items.Add("(R4) 企管所 BA");
            comboBox1.Items.Add("(H5) 交管系 TCM");
            comboBox1.Items.Add("(R5) 交管所 TCM");
            comboBox1.Items.Add("(R9) 電管所 TM");
            comboBox1.Items.Add("(R0) E M B A EMBA");
            comboBox1.Items.Add("(R6) 國企所 IB");
            comboBox1.Items.Add("(R8) 財金所 FIN");
            comboBox1.Items.Add("(RA) IIMBA IMBA");
            comboBox1.Items.Add("(RB) 體健所 PEHL");
            comboBox1.Items.Add("(RD) AMBA AMBA");
            comboBox1.Items.Add("(RE) 數據所 DS");
            comboBox1.Items.Add("(RZ) 管理學院 COM");
            //醫學院
            comboBox1.Items.Add("(I2) 護理系 NURS");
            comboBox1.Items.Add("(T2) 護理所 NURS");
            comboBox1.Items.Add("(I3) 醫技系 MLSB");
            comboBox1.Items.Add("(T3) 醫技所 MLSB");
            comboBox1.Items.Add("(I5) 醫學系 MED");
            comboBox1.Items.Add("(I6) 物治系 PT");
            comboBox1.Items.Add("(T6) 物治所 PT");
            comboBox1.Items.Add("(I7) 職治系 OT");
            comboBox1.Items.Add("(T7) 職治所 OT");
            comboBox1.Items.Add("(I8) 藥學系 DOPA");
            comboBox1.Items.Add("(S0) 藥學院");
            comboBox1.Items.Add("(S1) 生化所 BIMB");
            comboBox1.Items.Add("(S2) 藥理所 PHAR");
            comboBox1.Items.Add("(S3) 生理所 PHSL");
            comboBox1.Items.Add("(S4) 微免所 MI");
            comboBox1.Items.Add("(S5) 基醫所 BMS");
            comboBox1.Items.Add("(S6) 臨藥科技 CPPS");
            comboBox1.Items.Add("(S7) 環醫所 EOH");
            comboBox1.Items.Add("(SC) 食安所 FSRM");
            comboBox1.Items.Add("(S8) 行醫所 BM");
            comboBox1.Items.Add("(S9) 臨醫所 CM");
            comboBox1.Items.Add("(SA) 神經學程 TIGP");
            comboBox1.Items.Add("(T1) 分醫所 IMM");
            comboBox1.Items.Add("(T4) 口醫所 IOM");
            comboBox1.Items.Add("(SB) 公衛在職 MPH");
            comboBox1.Items.Add("(T8) 公衛所 PH");
            comboBox1.Items.Add("(T9) 細胞所 CBA");
            comboBox1.Items.Add("(TA) 健照所 AHS");
            comboBox1.Items.Add("(TC) 老年所 GERO");
            //社會科學院
            comboBox1.Items.Add("(D0) 社會科學院 CSS");
            comboBox1.Items.Add("(D2) 法律系 LAW");
            comboBox1.Items.Add("(U2) 法律所 LAW");
            comboBox1.Items.Add("(D4) 政治系 PS");
            comboBox1.Items.Add("(U1) 政經所 PE");
            comboBox1.Items.Add("(D5) 經濟系 ECON");
            comboBox1.Items.Add("(U5) 經濟所 ECON");
            comboBox1.Items.Add("(D8) 心理系 PSY");
            comboBox1.Items.Add("(U7) 心理所 CS");
            comboBox1.Items.Add("(U3) 教育所 EDU");
            comboBox1.Items.Add("(U8) 心智應用所 PIMS");
            //電機資訊學院
            comboBox1.Items.Add("(E2) 電機系 EE");
            comboBox1.Items.Add("(N2) 電機所 EE");
            comboBox1.Items.Add("(Q1) 微電所 IME");
            comboBox1.Items.Add("(Q3) 電通所 CCE");
            comboBox1.Items.Add("(Q6) 南科專");
            comboBox1.Items.Add("(Q7) 奈基學程 NICE");
            comboBox1.Items.Add("(F7) 資訊系 CSIE");
            comboBox1.Items.Add("(ND) 多媒學程");
            comboBox1.Items.Add("(P7) 資訊所 CSIE");
            comboBox1.Items.Add("(Q5) 醫資系 IMI");
            comboBox1.Items.Add("(P9) 製造所 IMIS");
            comboBox1.Items.Add("(V6) 電力產專 MPPE");
            comboBox1.Items.Add("(V8) 微波材料");
            comboBox1.Items.Add("(V9) 電子材料");
            comboBox1.Items.Add("(VA) 電機產業");
            comboBox1.Items.Add("(VB) 光材產專");
            comboBox1.Items.Add("(VC) 光產產專");
            comboBox1.Items.Add("(VD) 微波材料元件");
            comboBox1.Items.Add("(VE) 電子產專 MPPE");
            comboBox1.Items.Add("(VG) 靜電保護");
            comboBox1.Items.Add("(VH) 磁性材料");
            comboBox1.Items.Add("(VK) 電機驅動");
            comboBox1.Items.Add("(VM) 積體製程");
            comboBox1.Items.Add("(VN) 微波元件");
            comboBox1.Items.Add("(VO) 先進RF產專");
            //規劃與設計學院
            comboBox1.Items.Add("(E7) 建築系 ARCH");
            comboBox1.Items.Add("(N7) 建築所 ARCH");
            comboBox1.Items.Add("(F2) 都計系 UP");
            comboBox1.Items.Add("(P2) 都計所 UP");
            comboBox1.Items.Add("(F3) 工設系 ID");
            comboBox1.Items.Add("(P3) 工設所 ID");
            comboBox1.Items.Add("(FZ) 規劃設計學院學士");
            comboBox1.Items.Add("(PA) 創意所 ICID");
            comboBox1.Items.Add("(PB) 科藝學程 TART");
            //生物科學與科技學院
            comboBox1.Items.Add("(C5) 生科系 LS");
            comboBox1.Items.Add("(L5) 生命科學 LS");
            comboBox1.Items.Add("(C6) 生技系 BBS");
            comboBox1.Items.Add("(L6) 生技所 BIOT");
            comboBox1.Items.Add("(Z2) 生訊所 BIOT");
            comboBox1.Items.Add("(Z0) 生科學院 BB");
            comboBox1.Items.Add("(Z3) 熱植所 TPS");
            comboBox1.Items.Add("(Z5) 譯農所 TAS");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = comboBox1.SelectedItem.ToString().Substring(1, 2);
            Console.WriteLine(choose);

            //改變時update資料

            //清空資料
            comboBox2.Items.Clear(); 
            HtmlWeb client = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = client.Load("http://course-query.acad.ncku.edu.tw/qry/qry001.php?dept_no=" + choose);

            var table2 = doc.GetElementbyId("roomInfo");

            int k = 0;
            HtmlNodeCollection tables = doc.DocumentNode.SelectNodes(".//tr");

            foreach (HtmlNode table in tables)
            {
                //count row
                k++;
            }

            //清空資料
            date.Clear();
            classroom.Clear();

            //if (f.start_x != 6 && f.start_x != 7)
            //{
                for (int i = 1; i < k; ++i)
                {
                    if ((i % 11) != 0)
                    {
                        string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[17]").InnerText;
                        if (dateString.Substring(1, 1) == f.start_x.ToString())
                        {
                            date.Add(dateString);
                            string title = doc.DocumentNode.SelectSingleNode("//html / body / table / tbody / tr[" + i + "] / td[11]").InnerText;
                            dateString += title;
                            comboBox2.Items.Add(dateString);
                            string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                            classroom.Add(classroomString);
                        }
                    }
                }
            //}
            /*
            else
            {
                comboBox2.Items.Add("");
            }
            */
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (f.start_x != 6 && f.start_x != 7)
            {
                for (int i = 1; i < k; ++i)
                {
                    if ((i % 11) != 0)
                    {
                        string dateString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[17]").InnerText;
                        date.Add(dateString);
                    }
                }
                for (int i = 1; i < k; ++i)
                {
                    if ((i % 11) != 0)
                    {
                        string classroomString = doc.DocumentNode.SelectSingleNode("//html/body/table/tbody/tr[" + i + "]/td[18]").InnerText;
                        classroom.Add(classroomString);
                    }
                }
            }
        }
    }
}
