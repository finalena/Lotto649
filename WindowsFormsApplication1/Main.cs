using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;       //使用System.IO.MemoryStream
using System.Net;      //使用System.Net.WebClient

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        private WebClient webClient = new WebClient();
        private MemoryStream memoryStream = null;

        DataTable dtHistroy = null;
        DataTable dtPickNum = null;
        DataTable dtBettingArea = null;
        CheckBox chkAll = new CheckBox();
        CheckBox chkAll2 = new CheckBox();
        
        public Main()
        {
            InitializeComponent();

            IniData();
            GetLottoData();
            
            chkAll.MouseClick += new MouseEventHandler(chkAll_MouseClick);
            chkAll2.MouseClick += new MouseEventHandler(chkAll_MouseClick);
            this.dgvPickNumber.CellPainting += new DataGridViewCellPaintingEventHandler(dgvPickNumber_CellPainting);
            this.dgvBetArea.CellPainting += new DataGridViewCellPaintingEventHandler(dgvPickNumber_CellPainting);
            this.dgvPickNumber.CellContentClick += new DataGridViewCellEventHandler(dgvPickNumber_CellContentClick);
            this.dgvBetArea.CellContentClick += new DataGridViewCellEventHandler(dgvPickNumber_CellContentClick);
            this.btnToBettingArea.Click += new EventHandler(Button_Click);
            this.btnPickNumber.Click += new EventHandler(Button_Click);
            this.btnPickNumDel.Click += new EventHandler(Button_Click);
            this.btnPickNumDelAll.Click += new EventHandler(Button_Click);
            this.btnBetDel.Click += new EventHandler(Button_Click);
            this.btnBetDelAll.Click += new EventHandler(Button_Click);
            this.btnRedeem.Click += new EventHandler(Button_Click);
            this.btnHistory.Click +=new EventHandler(Button_Click);
        }

        private void IniData() 
        {
            this.lblDrawing.Text = "";
            this.lblDrawingSpcl.Text = "";

            //1.樂透選號
            dtPickNum = new DataTable();
            dtPickNum.Columns.Add("no");
            dtPickNum.Columns.Add("item");
            this.dgvPickNumber.DataSource = dtPickNum;
            //建立DGV列首CheckBox欄
            DataGridViewCheckBoxColumn cbCol = new DataGridViewCheckBoxColumn();
            cbCol.ReadOnly = false;
            cbCol.Width = 50;
            cbCol.Name = "chkBxSelect";
            cbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    

            this.dgvPickNumber.Columns.Insert(0, cbCol);
            this.dgvPickNumber.Columns[0].HeaderText = "";
            this.dgvPickNumber.Columns[1].HeaderText = "No";
            this.dgvPickNumber.Columns[2].HeaderText = "號碼";
            this.dgvPickNumber.Columns[1].Width = 50;
            this.dgvPickNumber.Columns[2].Width = 350;

            chkAll.Tag = "chkPickNumber";
            chkAll.Size = new Size(15, 15);
            chkAll.Padding = new Padding(0);
            chkAll.Margin = new Padding(0);
            this.dgvPickNumber.Controls.Add(chkAll);

            //取消排序功能
            foreach (DataGridViewColumn col in this.dgvPickNumber.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //2,下注區
            dtBettingArea = dtPickNum.Copy();
            dtBettingArea.Columns.Add("status");
            dtBettingArea.Columns.Add("prize_number");
            this.dgvBetArea.DataSource = dtBettingArea;

            //建立DGV列首CheckBox欄
            DataGridViewCheckBoxColumn cbCol2 = new DataGridViewCheckBoxColumn();
            cbCol2.Width = 50;
            cbCol2.Name = "chkBxSelect";
            cbCol2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   
           
            this.dgvBetArea.Columns.Insert(0, cbCol2);
            this.dgvBetArea.Columns[0].HeaderText = "";
            this.dgvBetArea.Columns[1].HeaderText = "No";
            this.dgvBetArea.Columns[2].HeaderText = "號碼";
            this.dgvBetArea.Columns[3].HeaderText = "狀態";
            this.dgvBetArea.Columns[4].HeaderText = "中獎號碼";
            this.dgvBetArea.Columns[1].Width = 25;
            this.dgvBetArea.Columns[1].Width = 30;
            this.dgvBetArea.Columns[2].Width = 160;
            this.dgvBetArea.Columns[3].Width = 60;
            this.dgvBetArea.Columns[4].Width = 160;

            chkAll2.Tag = "chkBet";
            chkAll2.Size = new Size(15, 15);
            chkAll2.Padding = new Padding(0);
            chkAll2.Margin = new Padding(0);
            this.dgvBetArea.Controls.Add(chkAll2);
            UpdateBetStatus();

            //取消排序功能
            foreach (DataGridViewColumn col in this.dgvBetArea.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgvPickNumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.ColumnIndex != 0) return;

            DataGridViewCheckBoxCell CellCheck = ((DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells["chkBxSelect"]);
            CellCheck.Value = !(bool)CellCheck.FormattedValue;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPickNumber))
            {
                PickNumber frm1 = new PickNumber();
                frm1.ShowDialog(this);  //这个this必不可少（将窗体显示为具有指定所有者：窗体frm1的所有者是PickNumber类当前的对象）
                this.dgvPickNumber.DataSource = dtPickNum;
            }
            else if (sender.Equals(this.btnToBettingArea))
            {
                List<int> SelectedRows = GetSelectedDataRows(this.dgvPickNumber);

                for (int intA = 0; intA < SelectedRows.Count; intA++)
                {
                    dtBettingArea.Rows.Add(dtBettingArea.Rows.Count + 1, dtPickNum.Rows[SelectedRows[intA]]["item"].ToString());
                }

                DgvRowDel(SelectedRows, ref dtPickNum);
                this.dgvBetArea.DataSource = dtBettingArea;
                UpdateBetStatus();
            }
            else if (sender.Equals(this.btnRedeem))
            {
                #region 隨機開獎
                //Random rnd = new Random();
                //string sDrawing = ""; 
                //int index = 1;
                //int iRnd = 0;

                //while (index <= 7)
                //{
                //    iRnd = rnd.Next(1, 50);
                //    if (!sDrawing.Contains(iRnd.ToString()))
                //    {
                //        if (index == 6)
                //        {//特別號
                //            this.lblDrawingSpcl.Text = iRnd.ToString().PadLeft(2, '0');
                //        }
                //        else
                //        {
                //            sDrawing = sDrawing + iRnd.ToString().PadLeft(2, '0') + "　";
                //        }
                //        index++;
                //    }
                //}
                //this.lblDrawing.Text = sDrawing;
                #endregion

                if (dtHistroy.Rows[0]["獎號"].ToString().Trim() == "")
                {
                    MessageBox.Show("無法讀取到兌獎資訊，請稍後再嘗試");
                    return;
                }

                this.lblDrawing.Text = dtHistroy.Rows[0]["獎號"].ToString().Trim();
                this.lblDrawingSpcl.Text = dtHistroy.Rows[0]["特別號"].ToString().Trim();

                Redeem();
            }
            else if (sender.Equals(this.btnHistory))
            {
                if (dtHistroy.Rows.Count < 1)
                {
                    MessageBox.Show("無法讀取到兌獎資訊，請稍後再嘗試");
                    return;
                }

                History frm1 = new History(dtHistroy);
                frm1.ShowDialog();
            }
            else if (sender.Equals(this.btnPickNumDel))
            {
                DgvRowDel(GetSelectedDataRows(this.dgvPickNumber), ref dtPickNum);
                this.dgvPickNumber.DataSource = dtPickNum;
            }
            else if (sender.Equals(this.btnBetDel))
            {
                DgvRowDel(GetSelectedDataRows(this.dgvBetArea), ref dtBettingArea);
                UpdateBetStatus();
            }
            else if (sender.Equals(this.btnPickNumDelAll))
            {
                dtPickNum.Clear();
                this.dgvPickNumber.DataSource = dtPickNum;
            }
            
            else if (sender.Equals(this.btnBetDelAll))
            {
                dtBettingArea.Clear();
                this.dgvBetArea.DataSource = dtBettingArea;
                UpdateBetStatus();
            }
        }

        /// <summary>抓取大樂透網頁的開獎資料</summary>
        private void GetLottoData()
        {
            dtHistroy = new DataTable();

            memoryStream = new MemoryStream(webClient.DownloadData(@"https://www.taiwanlottery.com.tw/Lotto/Lotto649/history.aspx"));
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(memoryStream, Encoding.UTF8);

            HtmlAgilityPack.HtmlDocument docData = new HtmlAgilityPack.HtmlDocument();
            docData.LoadHtml(doc.DocumentNode.SelectSingleNode(@"//table[@id='Lotto649Control_history_dlQuery']").InnerHtml);

            //新增欄位
            HtmlAgilityPack.HtmlDocument docTalbeCol = new HtmlAgilityPack.HtmlDocument();
            docTalbeCol.LoadHtml(docData.DocumentNode.SelectSingleNode(@"//table[@class='table_org td_hm']").InnerHtml);

            foreach (HtmlNode col in docTalbeCol.DocumentNode.SelectNodes(@"//tr[1]/td[@class='td_org1']"))
            {
                dtHistroy.Columns.Add(col.InnerText.Trim());
            }

            dtHistroy.Columns.Add("獎號");
            dtHistroy.Columns.Add("特別號");

            //新增每期開獎資料
            foreach (HtmlNode tr in docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[2]"))
            {
                dtHistroy.Rows.Add(tr.SelectNodes(@"td[@class='td_w']").Select(aa => aa.InnerText.Trim()).ToArray());
            }

            HtmlNodeCollection Data = docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[5]");
            for (int intA = 0; intA < Data.Count; intA++)
            {
                string[] sPara = Data[intA].SelectNodes(@"td[@class='td_w font_black14b_center']").Select(aa => aa.InnerText.Trim()).ToArray();
                dtHistroy.Rows[intA]["獎號"] =  string.Join("　", sPara);
                dtHistroy.Rows[intA]["特別號"] =  Data[intA].SelectSingleNode(@"td[@class='td_w font_red14b_center']").InnerText.Trim();
            }
        }

        /// <summary>兌獎</summary>
        private bool Redeem() 
        {
            string[] sArrDrawing = this.lblDrawing.Text.Split('　');//開獎號碼
            for (int intA = 0; intA < dtBettingArea.Rows.Count; intA++)
            {
                string[] Items = dtBettingArea.Rows[intA]["item"].ToString().Split('　');
                string sWinningNumbers = "";//中獎號碼
                bool IsWinningSpclNumber = false;//是否中特別號
                int iWinningCnt = 0;

                foreach (string item in Items)
	            {
                    if (sArrDrawing.Contains(item))
                    {
                        sWinningNumbers += item + "　";   
                        iWinningCnt++;
                    }   
	            }
                
                if (dtBettingArea.Rows[intA]["item"].ToString().Contains(this.lblDrawingSpcl.Text))
                {
                    IsWinningSpclNumber = true;
                }

                string result = "";
                switch (iWinningCnt)
                {
                    case 6:
                        result = "頭獎";
                        break;
                    case 5:
                        result = "参獎";
                        if (IsWinningSpclNumber) result = "貳獎";
                        break;
                    case 4:
                        result = "伍獎";
                        if (IsWinningSpclNumber) result = "肆獎";
                        break;
                    case 3:
                        result = "普獎";
                        if (IsWinningSpclNumber) result = "陸獎";
                        break;
                    case 2:
                        if (IsWinningSpclNumber) result = "柒獎";
                        break;
                    default:
                        result = "未中";
                        break;
                }

                if (IsWinningSpclNumber) sWinningNumbers += this.lblDrawingSpcl.Text;
                dtBettingArea.Rows[intA]["prize_number"] = sWinningNumbers;
                dtBettingArea.Rows[intA]["status"] = result;
            }
            
            this.dgvBetArea.DataSource = dtBettingArea;

            return true;
        }

        private void DgvRowDel(List<int> SelectedRows, ref DataTable refDt) 
        {
            for (int intA = SelectedRows.Count - 1; intA >= 0; intA--)
            {
                refDt.Rows.RemoveAt(SelectedRows[intA]);
            }

            //對序號列填充，從1遞增
            for (int intA = 0; intA < refDt.Rows.Count; intA++)
            {
                refDt.Rows[intA]["No"] = intA + 1;
            }
        }

        private List<int> GetSelectedDataRows(DataGridView dgv) 
        {
            List<int> SelectedRows = new List<int>();

            for (int intA = 0; intA < dgv.Rows.Count; intA++)
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dgv.Rows[intA].Cells["chkBxSelect"];
                if (Convert.ToBoolean(chkCell.FormattedValue))
                {
                    SelectedRows.Add(intA);
                }
            }
            
            return SelectedRows;
        }

        private void UpdateBetStatus() 
        {
            this.lblBetStatus.Text = string.Format("每注50 共{0}注 金額{1}元", this.dgvBetArea.Rows.Count, 50 * this.dgvBetArea.Rows.Count);
        }

        public void AddPickNumber(string sSelectedText)
        {
            dtPickNum.Rows.Add(dtPickNum.Rows.Count + 1, sSelectedText);
        }

        private void dgvPickNumber_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {//繪製全選CheckBox
            DataGridView dgv = (DataGridView)sender;
            CheckBox chk = new CheckBox();
            if (dgv.Name.Contains("Pick"))
            {
                chk = chkAll;
            }
            else
            {
                chk = chkAll2;
            }

            Rectangle oRectangle = dgv.GetCellDisplayRectangle(0, -1, true);
            Point oPoint = new Point();
            
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - chk.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - chk.Height) / 2 + 1;
            chk.Location = oPoint;   
        }

        private void chkAll_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            DataGridView dgv;
            if (checkbox.Tag.ToString().Contains("Pick"))
            {
                dgv = this.dgvPickNumber;
            }
            else
            {
                dgv = this.dgvBetArea;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = checkbox.Checked;
            }

            dgv.RefreshEdit();
        }
    }
}
