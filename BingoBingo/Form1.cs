using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoBingo
{
    public partial class Form1 : Form
    {
        int total = 0;//總價
        int count = 0;//類別變數期數+1
        List<Label> listNums = new List<Label>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listNums.Add(lbl1);
            listNums.Add(lbl2);
            listNums.Add(lbl3);
            listNums.Add(lbl4);
            listNums.Add(lbl5);
            listNums.Add(lbl6);
            listNums.Add(lbl7);
            listNums.Add(lbl8);
            listNums.Add(lbl9);
            listNums.Add(lbl10);
            listNums.Add(lbl11);
            listNums.Add(lbl12);
            listNums.Add(lbl13);
            listNums.Add(lbl14);
            listNums.Add(lbl15);
            listNums.Add(lbl16);
            listNums.Add(lbl17);
            listNums.Add(lbl18);
            listNums.Add(lbl19);
            listNums.Add(lbl20);
        }

        int TotalCost()//總價
        {
            return total += 25;
        }
        string RandNum()
        {
            Random random = new Random();
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                int Num = random.Next(1, 81);
                if (!numbers.Contains(Num))
                {
                    numbers.Add(Num);
                }
            }

            List<string> formatNum = new List<string>();
            foreach(int num in numbers)
            {
                formatNum.Add(num.ToString("D2"));
            }

            return string.Join(", ", formatNum);
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            string strNum = RandNum();
            txtNum.Text = strNum;
        }

        private void btnAddNum_Click(object sender, EventArgs e)
        {
            if (txtNum.Text != "")
            {
                int newTotal = TotalCost();
                lblTotalCost.Text = newTotal.ToString("C");
                選號紀錄.Items.Add(txtNum.Text);
                txtNum.Text = "";
            }
            else
            {
                MessageBox.Show("尚未選號", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblTotalCost.Text = "NT$ 0";
            選號紀錄.Items.Clear();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblDatetime.Text = DateTime.Now.ToString();
            //開獎
            List<int> numbers = new List<int>();
            Random random = new Random();
            while(numbers.Count < 20)
            {
                int Num = random.Next(1, 81);
                if (!numbers.Contains(Num))
                {
                    numbers.Add(Num);
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                listNums[i].Text = numbers[i].ToString("D2");
                lbl20.BackColor = Color.Gold;
            }
            count++;
            lbl期數.Text = $"第{count:D9}期";

            //Super Number
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 19)
                {
                    lblSuper.Text = Convert.ToString(numbers[i]);
                }
            }
            //猜大小
            List<int> numbers1 = new List<int>();
            List<int> numbers2 = new List<int>();
            foreach (int num in numbers)
            {
                if (num <= 40)
                {
                    numbers1.Add(num);//Small
                }
                else
                {
                    numbers2.Add(num);//Big
                }
            }
            if (numbers1.Count >= 13)
            {
                lblBigSmall.Text = "小";
            }
            else if (numbers2.Count >= 13)
            {
                lblBigSmall.Text = "大";
            }
            else
            {
                lblBigSmall.Text = "一";
            }
            //猜單雙
            List<int> numbers3 = new List<int>();
            List<int> numbers4 = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers3.Add(numbers[i]);//even
                }
                else
                {
                    numbers4.Add(numbers[i]);//odd
                }
            }
            if(numbers3.Count >= 13)
            {
                lblOddEven.Text = "雙";
            }
            else if (numbers4.Count >= 13)
            {
                lblOddEven.Text = "單";
            }
            else
            {
                lblOddEven.Text = "一";
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            lblTotalCost.Text = "NT$ 0";
            選號紀錄.Items.Clear();
            lblSuper.Text = "";
            lblOddEven.Text = "";
            lblBigSmall.Text = "";
            for (int i = 0; i < 20; i++)
            {
                listNums[i].Text = "";
            }
            lbl20.BackColor = Color.LightBlue;
        }

        private void btnBig_Click(object sender, EventArgs e)
        {
            if (大小單雙.Items.Contains('小'))
            {
                MessageBox.Show("已下注 \'小\' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newTotal = TotalCost();
                lblTotalCost.Text = newTotal.ToString("C");
                大小單雙.Items.Add('大');
            }
        }

        private void btnSmall_Click(object sender, EventArgs e)
        {
            if (大小單雙.Items.Contains('大'))
            {
                MessageBox.Show("已下注 \'大\' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newTotal = TotalCost();
                lblTotalCost.Text = newTotal.ToString("C");
                大小單雙.Items.Add('小');
            }
        }

        private void btnOdd_Click(object sender, EventArgs e)
        {
            if (大小單雙.Items.Contains('雙'))
            {
                MessageBox.Show("已下注 \'雙\' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newTotal = TotalCost();
                lblTotalCost.Text = newTotal.ToString("C");
                大小單雙.Items.Add('單');
            }
        }

        private void btnEven_Click(object sender, EventArgs e)
        {
            if (大小單雙.Items.Contains('單'))
            {
                MessageBox.Show("已下注 \'單\' ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newTotal = TotalCost();
                lblTotalCost.Text = newTotal.ToString("C");
                大小單雙.Items.Add('雙');
            }
        }

        private void btnDetele3_Click(object sender, EventArgs e)
        {
            大小單雙.Items.Clear();
        }

        private void btnSelectNum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                txtNum.Text = "";
            }
            if (txtNum.Text.Length > 36 && !string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("超過投注上限號碼", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Random random = new Random();
                int num = random.Next(1, 81);
                string newNum = num.ToString("D2");
                txtNum.Text += $"{newNum}, ";
            }
        }
    }
}
