using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        List<Button> myDButtonList = new List<Button>();
        List<string> myList = new List<string>(); //存放威力彩人工選號號碼
        List<string> myList2 = new List<string>(); //存放Bingo_Bingo人工選號號碼

        int[] rndArray = new int[6];      //存放威力彩電腦選號
        int[] rndArray2 = new int[6];     //複製一份威力彩電腦選號
        int[] rndArray3 = new int[6];     //威力彩開獎號碼 
        int[] rndArray4 = new int[6];     //複製一份威力彩開獎號碼

        int[] bingoArray = new int[20];   //存放Bingo_Bingo開獎號碼
        int[] bingoArray2 = new int[20];  //複製一份BingoBingo開獎號碼


        
        int amount1 = 0; //威力彩人工選號第一區選號數
        int amount2 = 0; //威力彩人工選號第二區選號數
        string strMsg;
        string strMsg2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            產生Bingo選號按鈕(8, 10);
            產生威力彩選號按鈕(4, 10);
            產生威力彩選號按鈕2(8);
            rdb單.Enabled = false;
            rdb小單.Enabled = false;
            rdb雙.Enabled = false;
            rdb小雙.Enabled = false;
            rdb和.Enabled = false;
            rdb大.Enabled = false;
            rdb小.Enabled = false;
            rdb一.Enabled = false;
            rdb1星.Enabled = false;
            rdb2星.Enabled = false;
            rdb3星.Enabled = false;
            rdb4星.Enabled = false;
            rdb5星.Enabled = false;
            rdb6星.Enabled = false;
            rdb7星.Enabled = false;
            rdb8星.Enabled = false;
            rdb9星.Enabled = false;
            rdb10星.Enabled = false;
            timer1.Enabled = false;
            webBrowser1.Navigate("http://www.taiwanlottery.com.tw/SuperLotto638/index.asp");
        }


        //動態產生按鈕:人工選號第一區
        void 產生威力彩選號按鈕(int intCount, int intCount2)
        {
            for (int i = 0; i < intCount; i += 1)
            {
                for (int j = 0; j < intCount2; j += 1)
                {
                    if (i == intCount - 1 && (j == intCount2 - 1 || j == intCount2 - 2)) continue;
                    Button dButton = new Button();
                    dButton.BackColor = Color.Blue;
                    dButton.ForeColor = Color.White;
                    dButton.Location = new Point(10 + 42 * j, 35 + 42 * i);
                    dButton.Size = new Size(40, 40);
                    dButton.Text = string.Format("{0:D2}", (10 * i + 1 + j));
                    dButton.Name = (10 * i + 1 + j).ToString();
                    dButton.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    dButton.Click += new EventHandler(dButton2_Click);
                    tab人工選號.Controls.Add(dButton);
                    myDButtonList.Add(dButton);
                }
            }
        }

        void dButton2_Click(object sender, EventArgs e)
        {

            Button myButton = (Button)sender;
            if (amount1 == 6 && myButton.BackColor == Color.Red)
            {
                strMsg = "";
                myButton.BackColor = Color.Blue;
                myList.Remove(myButton.Name);
                foreach (string lst in myList)
                {
                    strMsg += lst + " ";
                }
                amount1 -= 1;
                lbl人工選號第一區.Text = strMsg;
            }
            else if (amount1 >= 6)
            {
                if (MessageBox.Show("第一區最多只能選6個號碼", "", MessageBoxButtons.OK) == DialogResult.Yes)
                {
                    myList.Remove(myButton.Name);
                }
            }

            else
            {
                if (myButton.BackColor == Color.Red)
                {
                    strMsg = "";
                    myButton.BackColor = Color.Blue;
                    myList.Remove(myButton.Name);
                    foreach (string lst in myList)
                    {
                        strMsg += lst + " ";
                    }
                    amount1 -= 1;
                    lbl人工選號第一區.Text = strMsg;
                }
                else
                {
                    strMsg = "";
                    myButton.BackColor = Color.Red;
                    myList.Add(myButton.Name);
                    foreach (string str in myList)
                    {
                        strMsg += str + " ";
                    }
                    amount1 += 1;
                    lbl人工選號第一區.Text = strMsg;
                }
            }
        }

        //動態產生按鈕:人工選號第二區
        void 產生威力彩選號按鈕2(int intCount)
        {

            for (int i = 0; i < intCount; i += 1)
            {
                Button dButton = new Button();
                dButton.BackColor = Color.Blue;
                dButton.ForeColor = Color.White;
                dButton.Location = new Point(440 + 42 * i, 35);
                dButton.Size = new Size(40, 40);
                dButton.Text = string.Format("{0:D2}", i + 1);
                dButton.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                dButton.Name = (i+1).ToString();
                dButton.Click += new EventHandler(dButton3_Click);
                tab人工選號.Controls.Add(dButton);
                myDButtonList.Add(dButton);
            }
        }

        void dButton3_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            if (myButton.BackColor == Color.Red)
                {
                    myButton.BackColor = Color.Blue;
                    lbl人工選號第二區.Text = "";
                    amount2 -= 1;
                }
            else
                {
                if (amount2 >= 1)  myButton.BackColor = Color.Blue;                
                else
                {
                    lbl人工選號第二區.Text = myButton.Name;
                    myButton.BackColor = Color.Red;
                    amount2 += 1;
                }
                    
                }
            
        }

        void 威力彩選號()
        {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                rndArray[i] = rnd.Next(1, 39);

                for (int j = 0; j < i; j++)
                {
                    while (rndArray[j] == rndArray[i])
                    {
                        j = 0; rndArray[i] = rnd.Next(1, 39);
                    }
                }
            }
            Array.Copy(rndArray, rndArray2, rndArray.Length);
            Array.Sort(rndArray2);
            lb1num8.Text = rndArray[0].ToString();
            lb1num9.Text = rndArray[1].ToString();
            lb1num10.Text = rndArray[2].ToString();
            lb1num11.Text = rndArray[3].ToString();
            lb1num12.Text = rndArray[4].ToString();
            lb1num13.Text = rndArray[5].ToString();
            lb1num14.Text = rnd.Next(1, 9).ToString();
        }


        //威力彩UI介面操作按鈕
        private void btn開始選號_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btn確認.Enabled = false;
            lbl電腦選號.Text = "";
            威力彩選號();
        }

        private void btn暫停_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false) timer1.Enabled = true;
            else timer1.Enabled = false;            
            btn確認.Enabled = true;
        }
        
        private void btn確認_Click(object sender, EventArgs e)
        {
            
            lbl電腦選號.Text += "第一區:";
            for (int i = 0; i < rndArray2.Length; i += 1)
            {
                if (i == rndArray2.Length - 1)
                {
                    lbl電腦選號.Text += rndArray2[i].ToString();
                    continue;
                }
                lbl電腦選號.Text += rndArray2[i].ToString() + " ";
            }
            lbl電腦選號.Text += "\n第二區:" + lb1num14.Text + "\n";
            if (rndArray.Sum() == 0) lbl電腦選號.Text = "";
            btn確認.Enabled = false;
        }

        private void btn清除_Click(object sender, EventArgs e)
        {
            btn確認.Enabled = true;
            lb1num8.Text = ""; lb1num9.Text = ""; lb1num10.Text = "";
            lb1num11.Text = ""; lb1num12.Text = ""; lb1num13.Text = ""; lb1num14.Text = "";
            for (int i = 0; i < rndArray.Length; i += 1)
            {
                rndArray[i] = 0;
            }
            lbl電腦選號.Text = "";
        }


        private void btn威力彩開獎_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                rndArray3[i] = rnd.Next(1, 39);

                for (int j = 0; j < i; j++)
                {
                    while (rndArray3[j] == rndArray3[i])
                    {
                        j = 0;
                        rndArray3[i] = rnd.Next(1, 39);
                    }
                }
            }
            Array.Copy(rndArray3, rndArray4, rndArray3.Length);
            Array.Sort(rndArray4);
            lb1num1.Text = rndArray3[0].ToString();
            lb1num2.Text = rndArray3[1].ToString();
            lb1num3.Text = rndArray3[2].ToString();
            lb1num4.Text = rndArray3[3].ToString();
            lb1num5.Text = rndArray3[4].ToString();
            lb1num6.Text = rndArray3[5].ToString();
            lb1num7.Text = rnd.Next(1, 9).ToString();
        }


        private void btn威力彩對獎_Click(object sender, EventArgs e)
        {
            int num1 = 0, num2 = 0, num3 = 0, num4 = 0;

            for (int i = 0; i < rndArray3.Length; i++)
            {
                for (int j = 0; j < rndArray3.Length; j++)
                {
                    if (rndArray2[i] == rndArray3[j]) num1 += 1;
                }
            }
            if (lb1num7.Text == lb1num14.Text) num2 += 1;

            if (num1 == 6 && num2 == 1) lbl威力彩對獎.Text = "頭獎";
            else if (num1 == 6 && num2 == 0) lbl威力彩對獎.Text = "貳獎";
            else if (num1 == 5 && num2 == 1) lbl威力彩對獎.Text = "參獎";
            else if (num1 == 5 && num2 == 0) lbl威力彩對獎.Text = "肆獎";
            else if (num1 == 4 && num2 == 1) lbl威力彩對獎.Text = "伍獎";
            else if (num1 == 4 && num2 == 0) lbl威力彩對獎.Text = "陸獎";
            else if (num1 == 3 && num2 == 1) lbl威力彩對獎.Text = "柒獎";
            else if (num1 == 2 && num2 == 1) lbl威力彩對獎.Text = "捌獎";
            else if (num1 == 3 && num2 == 0) lbl威力彩對獎.Text = "玖獎";
            else if (num1 == 1 && num2 == 1) lbl威力彩對獎.Text = "普獎";
            else lbl威力彩對獎.Text = "您有沒中獎,再接再厲!";


            for (int i = 0; i < myList.Count; i++)
            {
                for (int j = 0; j < rndArray3.Length; j++)
                {
                    if (myList[i] == rndArray3[j].ToString()) num3 += 1;
                }
            }
            if (lb1num7.Text == lbl人工選號第二區.Text) num4 += 1;
            if (num3 == 6 && num4 == 1) lbl威力彩對獎.Text = "頭獎";
            else if (num3 == 6 && num4 == 0) lbl威力彩對獎.Text = "貳獎";
            else if (num3 == 5 && num4 == 1) lbl威力彩對獎.Text = "參獎";
            else if (num3 == 5 && num4 == 0) lbl威力彩對獎.Text = "肆獎";
            else if (num3 == 4 && num4 == 1) lbl威力彩對獎.Text = "伍獎";
            else if (num3 == 4 && num4 == 0) lbl威力彩對獎.Text = "陸獎";
            else if (num3 == 3 && num4 == 1) lbl威力彩對獎.Text = "柒獎";
            else if (num3 == 2 && num4 == 1) lbl威力彩對獎.Text = "捌獎";
            else if (num3 == 3 && num4 == 0) lbl威力彩對獎.Text = "玖獎";
            else if (num3 == 1 && num4 == 1) lbl威力彩對獎.Text = "普獎";
            else lbl威力彩對獎.Text = "您有沒中獎,再接再厲!";
        }



        //動態產生按鈕:賓果賓果
        void 產生Bingo選號按鈕(int intCount, int intCount2)
        {
            for (int i = 0; i < intCount; i += 1)
            {
                for (int j = 0; j < intCount2; j += 1)
                {
                    Button dButton = new Button();
                    dButton.BackColor = Color.Pink;
                    dButton.ForeColor = Color.Blue;
                    dButton.Location = new Point(400 + 42 * j, 40 + 42 * i);
                    dButton.Size = new Size(42, 42);
                    dButton.Text = string.Format("{0:D2}", (10 * i + 1 + j));
                    dButton.Name = dButton.Text; 
                    dButton.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                    dButton.Click += new EventHandler(dButton1_Click);
                    tcBingo.Controls.Add(dButton);
                    myDButtonList.Add(dButton);
                }
            }
        }


        void dButton1_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            if (myButton.BackColor == Color.Red)
            {
                strMsg2 = "";
                myButton.BackColor = Color.Pink;
                myList2.Remove(myButton.Name);
                foreach (string lst in myList2)
                {
                    strMsg2 += lst + " ";
                }
                lbl選擇結果3.Text = strMsg2;
            }
            else
            {
                strMsg2 = "";
                myButton.BackColor = Color.Red;
                myList2.Add(myButton.Name);
                foreach (string str in myList2)
                {
                    strMsg2 += str + " ";
                }
                lbl選擇結果3.Text = strMsg2;
            }
            if (rdb1星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 1)
                {
                    MessageBox.Show("玩1星最多只能選1個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb2星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 2)
                {
                    MessageBox.Show("玩2星最多只能選2個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb3星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 3)
                {
                    MessageBox.Show("玩3星最多只能選3個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb4星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 4)
                {
                    MessageBox.Show("玩4星最多只能選4個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb5星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 5)
                {
                    MessageBox.Show("玩5星最多只能選5個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb6星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 6)
                {
                    MessageBox.Show("玩6星最多只能選6個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb7星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 7)
                {
                    MessageBox.Show("玩7星最多只能選7個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb8星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 8)
                {
                    MessageBox.Show("玩8星最多只能選8個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb9星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 9)
                {
                    MessageBox.Show("玩9星最多只能選9個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
            if (rdb10星.Checked == true)
            {
                strMsg2 = "";
                if (myList2.Count > 10)
                {
                    MessageBox.Show("玩10星最多只能選10個號碼");
                    myButton.BackColor = Color.Pink;
                    myList2.Remove(myButton.Name);
                    foreach (string lst in myList2)
                    {
                        strMsg2 += lst + " ";
                    }
                    lbl選擇結果3.Text = strMsg2;
                }
            }
        }

        //賓果賓果UI介面操作按鈕
        private void btn賓果開獎_Click(object sender, EventArgs e)
            {
                //產生開獎號碼
                Random rnd = new Random();
                for (int i = 0; i < 20; i += 1)
                {
                    bingoArray[i] = rnd.Next(1, 81);

                    for (int j = 0; j < i; j += 1)
                    {
                        while (bingoArray[j] == bingoArray[i])
                        {
                            j = 0; bingoArray[i] = rnd.Next(1, 81);
                        }
                    }
                }
                Array.Copy(bingoArray, bingoArray2, bingoArray.Length); Array.Sort(bingoArray2);
                lbl開獎1.Text = string.Format("{0:D2}",bingoArray2[0]);
                lbl開獎2.Text = string.Format("{0:D2}",bingoArray2[1]);
                lbl開獎3.Text = string.Format("{0:D2}",bingoArray2[2]);
                lbl開獎4.Text = string.Format("{0:D2}",bingoArray2[3]);
                lbl開獎5.Text = string.Format("{0:D2}", bingoArray2[4]);
                lbl開獎6.Text = string.Format("{0:D2}", bingoArray2[5]);
                lbl開獎7.Text = string.Format("{0:D2}", bingoArray2[6]);
                lbl開獎8.Text = string.Format("{0:D2}", bingoArray2[7]);
                lbl開獎9.Text = string.Format("{0:D2}", bingoArray2[8]);
                lbl開獎10.Text = string.Format("{0:D2}", bingoArray2[9]);
                lbl開獎11.Text = string.Format("{0:D2}", bingoArray2[10]);
                lbl開獎12.Text = string.Format("{0:D2}", bingoArray2[11]);
                lbl開獎13.Text = string.Format("{0:D2}", bingoArray2[12]);
                lbl開獎14.Text = string.Format("{0:D2}", bingoArray2[13]);
                lbl開獎15.Text = string.Format("{0:D2}", bingoArray2[14]);
                lbl開獎16.Text = string.Format("{0:D2}", bingoArray2[15]);
                lbl開獎17.Text = string.Format("{0:D2}", bingoArray2[16]);
                lbl開獎18.Text = string.Format("{0:D2}", bingoArray2[17]);
                lbl開獎19.Text = string.Format("{0:D2}", bingoArray2[18]);
                lbl開獎20.Text = string.Format("{0:D2}", bingoArray2[19]);
                lbl超級獎號.Text = string.Format("{0:D2}", bingoArray[19]);
                int num1 = 0, num2 = 0, num3 = 0, num4 = 0;

                //猜大小
                for (int i = 0; i < 20; i++)
                {
                    if (bingoArray[i] <= 40)
                    {
                        num1 += 1;
                    }
                    else num2 += 1;
                }
                if (num1 >= 13) lbl猜大小.Text = "小";
                else if (num2 >= 13) lbl猜大小.Text = "大";
                else lbl猜大小.Text = "一";

                //猜單雙
                for (int i = 0; i < 20; i++)
                {
                    if (bingoArray[i] % 2 == 0)
                    {
                        num3 += 1;
                    }
                    else num4 += 1;
                }

                if (num3 >= 13) lbl猜單雙.Text = "雙";
                else if (num4 >= 13) lbl猜單雙.Text = "單";
                else if (num3 == 11 || num3 == 12) lbl猜單雙.Text = "小單";
                else if (num4 == 11 || num4 == 12) lbl猜單雙.Text = "小雙";
                else lbl猜單雙.Text = "和";
            }
           
            private void timer1_Tick(object sender, EventArgs e)
            {
                威力彩選號();
            }
        
        private void btn賓果對獎_Click(object sender, EventArgs e)
        {
            int num1 = 0,num2=0;
            lbl賓果對獎.Text = "獎號對中情形:\n";
            
            if (rdb1星.Checked == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 1; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "1星中1";                
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb2星.Checked == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "2星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "2星中2";                
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb3星.Checked == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "3星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "3星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "3星中3";                
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb4星.Checked == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "4星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "4星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "4星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "4星中4";               
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb5星.Checked == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "5星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "5星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "5星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "5星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "5星中5";
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb6星.Checked == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "6星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "6星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "6星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "6星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "6星中5";                
                else if (num1 == 6) lbl賓果對獎.Text += "6星中6";
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb7星.Checked == true)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "7星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "7星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "7星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "7星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "7星中5";
                else if (num1 == 6) lbl賓果對獎.Text += "7星中6";
                else if (num1 == 7) lbl賓果對獎.Text += "7星中7";               
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb8星.Checked == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "8星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "8星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "8星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "8星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "8星中5";
                else if (num1 == 6) lbl賓果對獎.Text += "8星中6";
                else if (num1 == 7) lbl賓果對獎.Text += "8星中7";
                else if (num1 == 8) lbl賓果對獎.Text += "8星中8";               
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else if (rdb9星.Checked == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "9星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "9星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "9星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "9星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "9星中5";
                else if (num1 == 6) lbl賓果對獎.Text += "9星中6";
                else if (num1 == 7) lbl賓果對獎.Text += "9星中7";
                else if (num1 == 8) lbl賓果對獎.Text += "9星中8";
                else if (num1 == 9) lbl賓果對獎.Text += "9星中9";                
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }
            else 
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (myList2[i] == string.Format("{0:D2}", bingoArray[j])) num1 += 1;
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (myList2[i] == string.Format("{0:D2}", bingoArray[19])) num2 += 1;
                }
                if (num1 == 1) lbl賓果對獎.Text += "10星中1";
                else if (num1 == 2) lbl賓果對獎.Text += "10星中2";
                else if (num1 == 3) lbl賓果對獎.Text += "10星中3";
                else if (num1 == 4) lbl賓果對獎.Text += "10星中4";
                else if (num1 == 5) lbl賓果對獎.Text += "10星中5";
                else if (num1 == 6) lbl賓果對獎.Text += "10星中6";
                else if (num1 == 7) lbl賓果對獎.Text += "10星中7";
                else if (num1 == 8) lbl賓果對獎.Text += "10星中8";
                else if (num1 == 9) lbl賓果對獎.Text += "10星中9";
                else if (num1 == 10) lbl賓果對獎.Text += "10星中10";               
                else lbl賓果對獎.Text += "您沒中";
                if (chk含超級獎號.Checked == true && num2 == 1) lbl賓果對獎.Text += "(抽中超級獎號)";
            }

            if (chk猜大小.Checked == true)
            {
                if (rdb大.Checked == true && lbl猜大小.Text == "大") lbl賓果對獎.Text += "\n猜大小:您中了!\n";
                else if (rdb小.Checked == true && lbl猜大小.Text == "小") lbl賓果對獎.Text += "\n猜大小:您中了!\n";
                else if (rdb一.Checked == true && lbl猜大小.Text == "一") lbl賓果對獎.Text += "\n猜大小:您中了!\n";
                else lbl賓果對獎.Text += "\n猜大小:您沒中!\n";
            }

            if (chk猜單雙.Checked == true)
            {
                if (rdb單.Checked == true && lbl猜單雙.Text == "單") lbl賓果對獎.Text += "猜單雙:您中了!\n";
                else if (rdb小單.Checked == true && lbl猜單雙.Text == "小單") lbl賓果對獎.Text += "猜單雙:您中了!\n";
                else if (rdb雙.Checked == true && lbl猜單雙.Text == "雙") lbl賓果對獎.Text += "猜單雙:您中了!\n";
                else if (rdb小雙.Checked == true && lbl猜單雙.Text == "小雙") lbl賓果對獎.Text += "猜單雙:您中了!\n";
                else if (rdb和.Checked == true && lbl猜單雙.Text == "和") lbl賓果對獎.Text += "猜單雙:您中了!\n";
                else lbl賓果對獎.Text += "猜單雙:您沒中!\n";
            }
        }

        private void btn清空_Click(object sender, EventArgs e)
        {
            lbl選擇結果1.Text = "";
            lbl選擇結果2.Text = "";
            lbl選擇結果3.Text = "";
            lbl選擇結果4.Text = "";
            lbl選擇結果5.Text = "";
            lbl選擇結果6.Text = "";
            lbl選擇結果7.Text = "";
            chk猜單雙.Checked = false;
            chk猜大小.Checked = false;
            chk不含超級獎號.Checked = false;
            chk含超級獎號.Checked = false;
        }

        private void chk不含超級獎號_CheckedChanged(object sender, EventArgs e)
        {
            if (chk不含超級獎號.Checked == false)
            {
                rdb1星.Enabled = false;
                rdb2星.Enabled = false;
                rdb3星.Enabled = false;
                rdb4星.Enabled = false;
                rdb5星.Enabled = false;
                rdb6星.Enabled = false;
                rdb7星.Enabled = false;
                rdb8星.Enabled = false;
                rdb9星.Enabled = false;
                rdb10星.Enabled = false;
                chk含超級獎號.Enabled = true;
            }
            else chk含超級獎號.Enabled = false;
            if (chk不含超級獎號.Checked == true)
            {
                rdb1星.Enabled = true;
                rdb2星.Enabled = true;
                rdb3星.Enabled = true;
                rdb4星.Enabled = true;
                rdb5星.Enabled = true;
                rdb6星.Enabled = true;
                rdb7星.Enabled = true;
                rdb8星.Enabled = true;
                rdb9星.Enabled = true;
                rdb10星.Enabled = true;
                lbl選擇結果1.Text += "基本玩法(不含超級獎號)\n";
            } 
            else lbl選擇結果1.Text = "";
        }

        private void chk含超級獎號_CheckedChanged(object sender, EventArgs e)
        {
            if (chk含超級獎號.Checked == false)
            {
                rdb1星.Enabled = false;
                rdb2星.Enabled = false;
                rdb3星.Enabled = false;
                rdb4星.Enabled = false;
                rdb5星.Enabled = false;
                rdb6星.Enabled = false;
                rdb7星.Enabled = false;
                rdb8星.Enabled = false;
                rdb9星.Enabled = false;
                rdb10星.Enabled = false;
                chk不含超級獎號.Enabled = true;
            }
            else chk不含超級獎號.Enabled = false;

            if (chk含超級獎號.Checked == true)
            {
                rdb1星.Enabled = true;
                rdb2星.Enabled = true;
                rdb3星.Enabled = true;
                rdb4星.Enabled = true;
                rdb5星.Enabled = true;
                rdb6星.Enabled = true;
                rdb7星.Enabled = true;
                rdb8星.Enabled = true;
                rdb9星.Enabled = true;
                rdb10星.Enabled = true;
                lbl選擇結果1.Text += "基本玩法(含超級獎號)\n";
            }
                
            else lbl選擇結果1.Text = "";
        }


        private void rdb1星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1星.Checked == true) lbl選擇結果2.Text = "1星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb2星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2星.Checked == true) lbl選擇結果2.Text = "2星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb3星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3星.Checked == true) lbl選擇結果2.Text = "3星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb4星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb4星.Checked == true) lbl選擇結果2.Text = "4星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb5星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb5星.Checked == true) lbl選擇結果2.Text = "5星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb6星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb6星.Checked == true) lbl選擇結果2.Text = "6星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb7星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb7星.Checked == true) lbl選擇結果2.Text = "7星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb8星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb8星.Checked == true) lbl選擇結果2.Text = "8星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb9星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb9星.Checked == true) lbl選擇結果2.Text = "9星";
            else lbl選擇結果2.Text = "";
        }

        private void rdb10星_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb10星.Checked == true) lbl選擇結果2.Text = "10星";
            else lbl選擇結果2.Text = "";
        }

        private void chk猜大小_CheckedChanged(object sender, EventArgs e)
        {
            if (chk猜大小.Checked == false)
            {
                rdb大.Enabled = false;
                rdb小.Enabled = false;
                rdb一.Enabled = false;
                lbl選擇結果4.Text = "";
                lbl選擇結果5.Text = "";

            }
            else
            {
                rdb大.Enabled = true;
                rdb小.Enabled = true;
                rdb一.Enabled = true;
                lbl選擇結果4.Text = "猜大小:";
            }
        }

        private void rdb大_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb大.Checked == true)
            {
                lbl選擇結果5.Text = "大";
                chk猜大小.Checked = true;
            } 
            else
            {
                lbl選擇結果5.Text = "";
            }
            
        }

        private void rdb小_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb小.Checked == true)
            {
                lbl選擇結果5.Text = "小";
                chk猜大小.Checked = true;
            } 
            else lbl選擇結果5.Text = "";
        }

        private void rdb一_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb一.Checked == true)
            {
                chk猜大小.Checked = true;
                lbl選擇結果5.Text = "一";
            } 
            else lbl選擇結果5.Text = "";
        }

        private void chk猜單雙_CheckedChanged(object sender, EventArgs e)
        {
            if (chk猜單雙.Checked == false)
            {
                rdb單.Enabled = false;
                rdb小單.Enabled = false;
                rdb雙.Enabled = false;
                rdb小雙.Enabled = false;
                rdb和.Enabled = false;
                lbl選擇結果6.Text = "";
                lbl選擇結果7.Text = "";
            }
            else
            {
                rdb單.Enabled = true;
                rdb小單.Enabled = true;
                rdb雙.Enabled = true;
                rdb小雙.Enabled = true;
                rdb和.Enabled = true;
                lbl選擇結果6.Text = "猜單雙:";
            }
        }

        private void rdb單_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb單.Checked == true) lbl選擇結果7.Text += "單";
            else lbl選擇結果7.Text = "";
        }

        private void rdb小單_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb小單.Checked == true) lbl選擇結果7.Text += "小單";
            else lbl選擇結果7.Text = "";
        }

        private void rdb雙_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb雙.Checked == true) lbl選擇結果7.Text += "雙";
            else lbl選擇結果7.Text = "";
        }

        private void rdb小雙_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb小雙.Checked == true) lbl選擇結果7.Text += "小雙";
            else lbl選擇結果7.Text = "";
        }

        private void rdb和_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb和.Checked == true) lbl選擇結果7.Text += "和";
            else lbl選擇結果7.Text = "";
        }
    }       
    
}

