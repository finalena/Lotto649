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
    public partial class History : Form
    {
        DataTable dtHistory = null;

        public History(DataTable dt)
        {
            InitializeComponent();

            dtHistory = dt;
            this.dgvHistory.DataSource = new BindingSource(dtHistory, null);
            this.dgvHistory.Columns["兌獎截止(註6)"].HeaderText = "兌獎截止";
            this.dgvHistory.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   
            
        }
    }
}
