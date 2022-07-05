using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day22_02
{
    public partial class Form1 : Form
    {
        int cntnum1 = 0, cntnum2 = 0, cntnum3 = 0;
        int cntgood = 0, cntbad = 0;
        int cntnum = 0;

        public Form1()
        {
            InitializeComponent();
            Width = 400;
            Height = 300;
            ShowGoodBad();
        }

        //check button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CntAndShowAns();
                ShowGoodBad();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("과일을 선택하지 않으셨습니다.");
            }
            finally
            {
            ReSet();
            
            Invalidate();
            }          
        }

        public void CntAndShowAns()
        {
            Queue<string> q = new Queue<string>();
            string ans = "당신이 선호한 상품: ";
            if (checkBox1.Checked) { q.Enqueue("사과"); cntnum1++; }
            else if (checkBox2.Checked) { q.Enqueue("배"); cntnum2++; }
            else if (checkBox3.Checked) { q.Enqueue("수박"); cntnum2++; }
            else throw new IndexOutOfRangeException();
            int cnt = q.Count;

            for (int i = 0; i < cnt; i++)
            {
                if (i != 0) ans += ", ";
                ans += q.Dequeue();
            }
            MessageBox.Show(ans + "입니다.");

            if (radioButton1.Checked) cntgood += 1;
            if (radioButton2.Checked) cntbad += 1;
            cntnum++;
        }

        public void ShowGoodBad()
        {         
            string gdbd = "만족: " + cntgood + "\t불만족: " + cntbad + "\t참여인원: " + cntnum;
            ans_out.Text = gdbd;
        }
        
        void ReSet()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Width = 400;
            Height = 300;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("설문을 종료하시겠습니까", "설문", MessageBoxButtons.YesNo) == DialogResult.No) e.Cancel = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"사과: {cntnum1}\n 배: {cntnum2}\n수박: {cntnum3}\n\t참여인원: {cntnum}","설문 결과");
        }
    }
}
    
