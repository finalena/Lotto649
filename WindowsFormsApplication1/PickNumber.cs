using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PickNumber : Form
    {
        int iSelectedCnt = 0;

        public PickNumber()
        {
            InitializeComponent();

            IniControl();

            this.btnSubmit.Click += new EventHandler(Button_Click);
        }

        private void IniControl() 
        {
           
            int iCnt = 0;
            for (int intA = 0; intA < 7; intA++)
            {
                for (int intB = 0; intB < 7; intB++)
                {
                    Button button = new Button();
                    iCnt++;
                    button.Name = "btn" + iCnt.ToString().PadLeft(2, '0');
                    button.Text = iCnt.ToString().PadLeft(2, '0');
                    button.Size = new Size(30, 30);
                    button.Margin = new Padding(3, 3, 3, 3);
                    button.Location = new Point((9 * (intB * 4 + 1)), (9 * (intA * 4 + 1)));
                    button.BackColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Click += (sender, e) => BtnNumber_Click(sender, e); 

                    this.panel1.Controls.Add(button);
                   
                }
            }
        
            this.lblWarm.Text = string.Format("還有{0}個數字", iSelectedCnt);
        
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnSubmit))
            {
                Main frm1 = (Main)this.Owner;   //将本窗体的拥有者强制设为Main类的实例frm1
                Random rnd = new Random();
                int iRnd = 0;
                int index = iSelectedCnt;
                string sSelectedText = this.lblSelected.Text;
                
                for (int intA = 0; intA < this.nudAmount.Value; intA++)
                {
                    while (index < 6)
                    {
                        iRnd = rnd.Next(1, 50);
                        if (!sSelectedText.Contains(iRnd.ToString()))
                        {
                            sSelectedText = sSelectedText + iRnd.ToString().PadLeft(2, '0') + "　";
                            index++;
                        }
                    }

                    frm1.AddPickNumber(sSelectedText.Trim());
                    index = iSelectedCnt;
                    sSelectedText = this.lblSelected.Text;
                }

                this.Close();
            }
        }

        private void BtnNumber_Click(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;

            if (btn.BackColor == Color.White)
            {
                iSelectedCnt++;
                if (!CheckNumber()) return;
                
                btn.BackColor = Color.DarkGray;
                this.lblSelected.Text = this.lblSelected.Text + btn.Text + "　";
                
            }
            else if (btn.BackColor == Color.DarkGray)
            {
                iSelectedCnt--;
                if (!CheckNumber()) return;

                btn.BackColor = Color.White;
                this.lblSelected.Text = this.lblSelected.Text.Replace(btn.Text + "　", "");
                
            }
        }

        private bool CheckNumber() 
        {
            if (iSelectedCnt > 6 || iSelectedCnt < 0)
            {
                MessageBox.Show("最多只能選6個號碼", this.Text);
                iSelectedCnt = 6;
                return false;
            }

            this.lblWarm.Text = string.Format("還有{0}個數字", 6 - iSelectedCnt);

            return true;
        }
    }
}
