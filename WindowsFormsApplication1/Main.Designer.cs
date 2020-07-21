namespace WindowsFormsApplication1
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPickNumber = new System.Windows.Forms.DataGridView();
            this.btnPickNumber = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.lblBetStatus = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBetDelAll = new System.Windows.Forms.Button();
            this.btnBetDel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDrawingSpcl = new System.Windows.Forms.Label();
            this.lblDrawing = new System.Windows.Forms.Label();
            this.dgvBetArea = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPickNumDelAll = new System.Windows.Forms.Button();
            this.btnPickNumDel = new System.Windows.Forms.Button();
            this.btnToBettingArea = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBetArea)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPickNumber
            // 
            this.dgvPickNumber.AllowUserToAddRows = false;
            this.dgvPickNumber.AllowUserToDeleteRows = false;
            this.dgvPickNumber.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPickNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPickNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPickNumber.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvPickNumber.Location = new System.Drawing.Point(6, 14);
            this.dgvPickNumber.Name = "dgvPickNumber";
            this.dgvPickNumber.ReadOnly = true;
            this.dgvPickNumber.RowHeadersVisible = false;
            this.dgvPickNumber.RowTemplate.Height = 24;
            this.dgvPickNumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPickNumber.Size = new System.Drawing.Size(454, 301);
            this.dgvPickNumber.TabIndex = 0;
            // 
            // btnPickNumber
            // 
            this.btnPickNumber.Location = new System.Drawing.Point(488, 21);
            this.btnPickNumber.Name = "btnPickNumber";
            this.btnPickNumber.Size = new System.Drawing.Size(91, 38);
            this.btnPickNumber.TabIndex = 1;
            this.btnPickNumber.Text = "選號";
            this.btnPickNumber.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHistory);
            this.groupBox2.Controls.Add(this.btnRedeem);
            this.groupBox2.Controls.Add(this.lblBetStatus);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.dgvBetArea);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 321);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(492, 212);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(90, 38);
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "各期開獎結果";
            this.btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnRedeem
            // 
            this.btnRedeem.Location = new System.Drawing.Point(492, 168);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(90, 38);
            this.btnRedeem.TabIndex = 4;
            this.btnRedeem.Text = "載入開獎號碼";
            this.btnRedeem.UseVisualStyleBackColor = true;
            // 
            // lblBetStatus
            // 
            this.lblBetStatus.AutoSize = true;
            this.lblBetStatus.Location = new System.Drawing.Point(328, 290);
            this.lblBetStatus.Name = "lblBetStatus";
            this.lblBetStatus.Size = new System.Drawing.Size(119, 12);
            this.lblBetStatus.TabIndex = 3;
            this.lblBetStatus.Text = "每注50 共0注 金額0元";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnBetDelAll);
            this.groupBox5.Controls.Add(this.btnBetDel);
            this.groupBox5.Location = new System.Drawing.Point(476, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(122, 128);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "將勾選的號碼";
            // 
            // btnBetDelAll
            // 
            this.btnBetDelAll.Location = new System.Drawing.Point(16, 72);
            this.btnBetDelAll.Name = "btnBetDelAll";
            this.btnBetDelAll.Size = new System.Drawing.Size(90, 38);
            this.btnBetDelAll.TabIndex = 3;
            this.btnBetDelAll.Text = "全部清空";
            this.btnBetDelAll.UseVisualStyleBackColor = true;
            // 
            // btnBetDel
            // 
            this.btnBetDel.Location = new System.Drawing.Point(16, 28);
            this.btnBetDel.Name = "btnBetDel";
            this.btnBetDel.Size = new System.Drawing.Size(90, 38);
            this.btnBetDel.TabIndex = 3;
            this.btnBetDel.Text = "刪除";
            this.btnBetDel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDrawingSpcl);
            this.groupBox4.Controls.Add(this.lblDrawing);
            this.groupBox4.Location = new System.Drawing.Point(6, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 47);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "開獎號碼";
            // 
            // lblDrawingSpcl
            // 
            this.lblDrawingSpcl.AutoSize = true;
            this.lblDrawingSpcl.ForeColor = System.Drawing.Color.Red;
            this.lblDrawingSpcl.Location = new System.Drawing.Point(155, 22);
            this.lblDrawingSpcl.Name = "lblDrawingSpcl";
            this.lblDrawingSpcl.Size = new System.Drawing.Size(49, 12);
            this.lblDrawingSpcl.TabIndex = 1;
            this.lblDrawingSpcl.Text = "[特別號]";
            // 
            // lblDrawing
            // 
            this.lblDrawing.AutoSize = true;
            this.lblDrawing.Location = new System.Drawing.Point(11, 22);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(61, 12);
            this.lblDrawing.TabIndex = 0;
            this.lblDrawing.Text = "[開獎號碼]";
            // 
            // dgvBetArea
            // 
            this.dgvBetArea.AllowUserToAddRows = false;
            this.dgvBetArea.AllowUserToDeleteRows = false;
            this.dgvBetArea.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBetArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBetArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBetArea.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBetArea.Location = new System.Drawing.Point(6, 14);
            this.dgvBetArea.Name = "dgvBetArea";
            this.dgvBetArea.ReadOnly = true;
            this.dgvBetArea.RowHeadersVisible = false;
            this.dgvBetArea.RowTemplate.Height = 24;
            this.dgvBetArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBetArea.Size = new System.Drawing.Size(464, 244);
            this.dgvBetArea.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPickNumDelAll);
            this.groupBox3.Controls.Add(this.btnPickNumDel);
            this.groupBox3.Controls.Add(this.btnToBettingArea);
            this.groupBox3.Location = new System.Drawing.Point(472, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 171);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "將勾選的號碼";
            // 
            // btnPickNumDelAll
            // 
            this.btnPickNumDelAll.Location = new System.Drawing.Point(17, 124);
            this.btnPickNumDelAll.Name = "btnPickNumDelAll";
            this.btnPickNumDelAll.Size = new System.Drawing.Size(90, 38);
            this.btnPickNumDelAll.TabIndex = 2;
            this.btnPickNumDelAll.Text = "全部清空";
            this.btnPickNumDelAll.UseVisualStyleBackColor = true;
            // 
            // btnPickNumDel
            // 
            this.btnPickNumDel.Location = new System.Drawing.Point(17, 81);
            this.btnPickNumDel.Name = "btnPickNumDel";
            this.btnPickNumDel.Size = new System.Drawing.Size(90, 38);
            this.btnPickNumDel.TabIndex = 1;
            this.btnPickNumDel.Text = "刪除";
            this.btnPickNumDel.UseVisualStyleBackColor = true;
            // 
            // btnToBettingArea
            // 
            this.btnToBettingArea.Location = new System.Drawing.Point(17, 20);
            this.btnToBettingArea.Name = "btnToBettingArea";
            this.btnToBettingArea.Size = new System.Drawing.Size(90, 38);
            this.btnToBettingArea.TabIndex = 0;
            this.btnToBettingArea.Text = "儲存至下注區";
            this.btnToBettingArea.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 356);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "樂透選號";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dgvPickNumber);
            this.groupBox1.Controls.Add(this.btnPickNumber);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 321);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下注區";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 377);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大樂透";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBetArea)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPickNumber;
        private System.Windows.Forms.Button btnPickNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBetArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPickNumDelAll;
        private System.Windows.Forms.Button btnPickNumDel;
        private System.Windows.Forms.Button btnToBettingArea;
        private System.Windows.Forms.Label lblBetStatus;
        private System.Windows.Forms.Button btnBetDelAll;
        private System.Windows.Forms.Button btnBetDel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRedeem;
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Label lblDrawingSpcl;
        private System.Windows.Forms.Button btnHistory;
    }
}

