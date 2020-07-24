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
        WebClient webClient = new WebClient();
        MemoryStream memoryStream = null;
        DataTable dtLottoHistroy = null;
        
        public Main()
        {
            InitializeComponent();

            IniData();
            GetLottoData();
        }

        private void IniData() 
        {
            List<Control> ctrList = GetAllControls(this.tabControl1);
            foreach (Control ctr in ctrList)
            {
                if (ctr is ListView)
                {
                    ListView lv = (ListView)ctr;

                    lv.GridLines = true;
                    lv.FullRowSelect = true;
                    lv.View = View.Details;
                    lv.Scrollable = true;
                    lv.MultiSelect = false;
                    lv.CheckBoxes = true;
                    lv.OwnerDraw = true;

                    lv.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView_DrawColumnHeader);
                    lv.DrawItem += new DrawListViewItemEventHandler(ListView_DrawItem);
                    lv.DrawSubItem += new DrawListViewSubItemEventHandler(ListView_DrawSubItem);
                    lv.ColumnClick += new ColumnClickEventHandler(ListView_ColumnClick);
                }
            }
            this.btnToBettingArea.Click += new EventHandler(Button_Click);
            this.btnPickNumber.Click += new EventHandler(Button_Click);
            this.btnPickNumDel.Click += new EventHandler(Button_Click);
            this.btnPickNumDelAll.Click += new EventHandler(Button_Click);
            this.btnBetDel.Click += new EventHandler(Button_Click);
            this.btnBetDelAll.Click += new EventHandler(Button_Click);
            this.btnRedeem.Click += new EventHandler(Button_Click);
            this.btnLottoHistory.Click += new EventHandler(Button_Click);

            this.lblDrawing.Text = "";
            this.lblDrawingSpcl.Text = "";

            //1.樂透選號
            this.lvPickNumber.Columns.Add("CheckAll", "");
            this.lvPickNumber.Columns.Add("No", "No");
            this.lvPickNumber.Columns.Add("Number", "號碼");
            
            this.lvPickNumber.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.lvPickNumber.Columns[1].Width = 50;
            this.lvPickNumber.Columns[2].Width = 350;

            //2,下注區
            this.lvBetArea.Columns.Add("CheckAll", "");
            this.lvBetArea.Columns.Add("No", "No"); ;
            this.lvBetArea.Columns.Add("Number", "號碼");
            this.lvBetArea.Columns.Add("result", "兌獎結果");
            this.lvBetArea.Columns.Add("PrizeNumber", "中獎號碼");

            this.lvBetArea.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.lvBetArea.Columns[1].Width = 50;
            this.lvBetArea.Columns[2].Width = 160;
            this.lvBetArea.Columns[3].Width = 60;
            this.lvBetArea.Columns[4].Width = 160;

            UpdateBetStatus();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnToBettingArea))
            {
                for (int intA = this.lvPickNumber.CheckedItems.Count - 1; intA >= 0; intA--)
                {
                    ListViewItem objItem = new ListViewItem();
                    objItem.SubItems.Add((this.lvBetArea.Items.Count + 1).ToString());
                    objItem.SubItems.Add(this.lvPickNumber.CheckedItems[intA].SubItems[2].Text);
                    this.lvBetArea.Items.Add(objItem);

                    this.lvPickNumber.Items.Remove(this.lvPickNumber.CheckedItems[intA]);
                }

                UpdateListViewNo(ref this.lvPickNumber);
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

                if (dtLottoHistroy.Rows[0]["獎號"].ToString().Trim() == "")
                {
                    MessageBox.Show("無法讀取到兌獎資訊，請稍後再嘗試");
                    return;
                }

                this.lblDrawing.Text = dtLottoHistroy.Rows[0]["獎號"].ToString().Trim();
                this.lblDrawingSpcl.Text = dtLottoHistroy.Rows[0]["特別號"].ToString().Trim();

                Redeem();
            }
            else if (sender.Equals(this.btnPickNumber))
            {
                PickNumber frm1 = new PickNumber();
                frm1.ShowDialog(this);  //這個this必不可少（將視窗顯示為具有指定所有者：視窗frm1的所有者是PickNumber類當前的對象）
            }
            else if (sender.Equals(this.btnLottoHistory))
            {
                if (dtLottoHistroy.Rows.Count < 1)
                {
                    MessageBox.Show("無法讀取到兌獎資訊，請稍後再嘗試");
                    return;
                }

                History frm1 = new History(dtLottoHistroy);
                frm1.ShowDialog();
            }
            else if (sender.Equals(this.btnPickNumDel))
            {
                for (int intA = this.lvPickNumber.CheckedItems.Count - 1; intA >= 0; intA--)
                {
                    this.lvPickNumber.Items.Remove(this.lvPickNumber.CheckedItems[intA]);
                }

                UpdateListViewNo(ref this.lvPickNumber);
            }
            else if (sender.Equals(this.btnBetDel))
            {
                for (int intA = this.lvBetArea.CheckedItems.Count - 1; intA >= 0; intA--)
                {
                    this.lvBetArea.Items.Remove(this.lvBetArea.CheckedItems[intA]);
                }

                UpdateListViewNo(ref this.lvBetArea);
                UpdateBetStatus();
            }
            else if (sender.Equals(this.btnPickNumDelAll))
            {
                this.lvPickNumber.Items.Clear();
            }
            else if (sender.Equals(this.btnBetDelAll))
            {
                this.lvBetArea.Items.Clear();
                UpdateBetStatus();
            }
        }

        /// <summary>抓取大樂透網頁的開獎資料</summary>
        private void GetLottoData()
        {
            dtLottoHistroy = new DataTable();

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
                dtLottoHistroy.Columns.Add(col.InnerText.Trim());
            }

            dtLottoHistroy.Columns.Add("獎號");
            dtLottoHistroy.Columns.Add("特別號");

            //新增每期開獎資料
            foreach (HtmlNode tr in docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[2]"))
            {
                dtLottoHistroy.Rows.Add(tr.SelectNodes(@"td[@class='td_w']").Select(aa => aa.InnerText.Trim()).ToArray());
            }

            HtmlNodeCollection Data = docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[5]");
            for (int intA = 0; intA < Data.Count; intA++)
            {
                string[] sPara = Data[intA].SelectNodes(@"td[@class='td_w font_black14b_center']").Select(aa => aa.InnerText.Trim()).ToArray();
                dtLottoHistroy.Rows[intA]["獎號"] =  string.Join("　", sPara);
                dtLottoHistroy.Rows[intA]["特別號"] =  Data[intA].SelectSingleNode(@"td[@class='td_w font_red14b_center']").InnerText.Trim();
            }
        }

        /// <summary>兌獎</summary>
        private bool Redeem() 
        {
            string[] sArrDrawing = this.lblDrawing.Text.Split('　');//開獎號碼
            for (int intA = 0; intA < this.lvBetArea.Items.Count; intA++)
            {
                ListViewItem objItem = this.lvBetArea.Items[intA]; 

                string[] Items = objItem.SubItems[1].ToString().Split('　');
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

                if (objItem.SubItems[2].Text.Contains(this.lblDrawingSpcl.Text))
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
                objItem.SubItems.Add(result);
                objItem.SubItems.Add(sWinningNumbers);
            }
          
            return true;
        }
       
        private void UpdateListViewNo(ref ListView objLv)
        {
            for (int intA = 0; intA < objLv.Items.Count; intA++)
            {
                objLv.Items[intA].SubItems[1].Text = (intA + 1).ToString();
            }
        } 

        private void UpdateBetStatus() 
        {
            this.lblBetStatus.Text = string.Format("每注50 共{0}注 金額{1}元", this.lvBetArea.Items.Count, 50 * this.lvBetArea.Items.Count);
        }

        public void AddPickNumber(string sSelectedText)
        {
            ListViewItem objItem = new ListViewItem();
            objItem.SubItems.Add((this.lvPickNumber.Items.Count + 1).ToString());
            objItem.SubItems.Add(sSelectedText);
        
            this.lvPickNumber.Items.Add(objItem);
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                ListView objListView = ((ListView)sender);
                bool value = false;
                value = Convert.ToBoolean(objListView.Columns[e.Column].Tag);

                objListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in objListView.Items)
                {
                    item.Checked = !value;
                }
            }
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                value = Convert.ToBoolean(e.Header.Tag);

                CheckBoxRenderer.DrawCheckBox(e.Graphics, 
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        
        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        # region GetCtrArray 列舉控制項
        /// <summary>
        /// 遞迴取得Form中控制項
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private List<Control> GetAllControls(object obj)
        {
            List<Control> CtrList = new List<Control>();

            ToCtrList(obj, ref CtrList);

            return CtrList;
        }

        private void ToCtrList(object obj, ref List<Control> CtrList)
        {
            if (obj is Form)
            {
                foreach (Control ctr in ((Form)obj).Controls)
                {
                    CtrList.Add(ctr);
                    if (ctr.HasChildren) ToCtrList(ctr, ref CtrList);
                }
            }
            else
            {
                foreach (Control ctr in ((Control)obj).Controls)
                {
                    CtrList.Add(ctr);
                    if (ctr.HasChildren) ToCtrList(ctr, ref CtrList);
                }
            }
        }
        #endregion
    }
}
