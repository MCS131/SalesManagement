namespace SalesManagement_SysDev
{
    partial class F_Stock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_StkUpdate = new Button();
            txb_StkStockNum = new TextBox();
            lbl_StkStockNum = new Label();
            txb_StkPrdctID = new TextBox();
            txb_StkStockID = new TextBox();
            lbl_StkStockID = new Label();
            btn_StkSearch = new Button();
            dataGrid_Stock = new DataGridView();
            btn_StkBack = new Button();
            btn_StkShow = new Button();
            lbl_StkPrdctID = new Label();
            button2 = new Button();
            lbl_StkSelectForm = new Label();
            btn_StkFormShow = new Button();
            cmb_StkSelectForm = new ComboBox();
            lbl_StockDate = new Label();
            lbl_Stockkengenmei = new Label();
            lbl_StockLoginuser = new Label();
            lbl_StkPage = new Label();
            txb_StkPage = new TextBox();
            btn_StkLastPage = new Button();
            btn_StkPrevPage = new Button();
            btn_StkNextPage = new Button();
            btn_StkChangeSize = new Button();
            txb_StkPageSize = new TextBox();
            lbl_StkPageSize = new Label();
            btn_StkFirstPage = new Button();
            lbl_StkPrdctName = new Label();
            txb_StkPrdctName = new TextBox();
            lbl_StkHidden = new Label();
            CheckBox_StkHidden = new CheckBox();
            btn_StkInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Stock).BeginInit();
            SuspendLayout();
            // 
            // btn_StkUpdate
            // 
            btn_StkUpdate.BackColor = Color.LightPink;
            btn_StkUpdate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkUpdate.Location = new Point(585, 114);
            btn_StkUpdate.Margin = new Padding(2);
            btn_StkUpdate.Name = "btn_StkUpdate";
            btn_StkUpdate.Size = new Size(185, 100);
            btn_StkUpdate.TabIndex = 4;
            btn_StkUpdate.Text = "更新";
            btn_StkUpdate.UseVisualStyleBackColor = false;
            btn_StkUpdate.Click += btn_StkUpdate_Click;
            // 
            // txb_StkStockNum
            // 
            txb_StkStockNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StkStockNum.Location = new Point(1311, 327);
            txb_StkStockNum.Margin = new Padding(2);
            txb_StkStockNum.Name = "txb_StkStockNum";
            txb_StkStockNum.Size = new Size(150, 39);
            txb_StkStockNum.TabIndex = 2;
            // 
            // lbl_StkStockNum
            // 
            lbl_StkStockNum.AutoSize = true;
            lbl_StkStockNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkStockNum.Location = new Point(1219, 330);
            lbl_StkStockNum.Margin = new Padding(2, 0, 2, 0);
            lbl_StkStockNum.Name = "lbl_StkStockNum";
            lbl_StkStockNum.Size = new Size(86, 32);
            lbl_StkStockNum.TabIndex = 38;
            lbl_StkStockNum.Text = "在庫数";
            // 
            // txb_StkPrdctID
            // 
            txb_StkPrdctID.Enabled = false;
            txb_StkPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StkPrdctID.Location = new Point(718, 327);
            txb_StkPrdctID.Margin = new Padding(2);
            txb_StkPrdctID.Name = "txb_StkPrdctID";
            txb_StkPrdctID.Size = new Size(150, 39);
            txb_StkPrdctID.TabIndex = 2;
            txb_StkPrdctID.TextChanged += txb_StkPrdctID_TextChanged;
            // 
            // txb_StkStockID
            // 
            txb_StkStockID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StkStockID.Location = new Point(439, 327);
            txb_StkStockID.Margin = new Padding(2);
            txb_StkStockID.Name = "txb_StkStockID";
            txb_StkStockID.Size = new Size(150, 39);
            txb_StkStockID.TabIndex = 1;
            txb_StkStockID.TextChanged += txb_StkStockID_TextChanged;
            // 
            // lbl_StkStockID
            // 
            lbl_StkStockID.AutoSize = true;
            lbl_StkStockID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkStockID.Location = new Point(347, 330);
            lbl_StkStockID.Margin = new Padding(2, 0, 2, 0);
            lbl_StkStockID.Name = "lbl_StkStockID";
            lbl_StkStockID.Size = new Size(85, 32);
            lbl_StkStockID.TabIndex = 32;
            lbl_StkStockID.Text = "在庫ID";
            // 
            // btn_StkSearch
            // 
            btn_StkSearch.BackColor = Color.LightPink;
            btn_StkSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkSearch.Location = new Point(1145, 114);
            btn_StkSearch.Margin = new Padding(2);
            btn_StkSearch.Name = "btn_StkSearch";
            btn_StkSearch.Size = new Size(185, 100);
            btn_StkSearch.TabIndex = 6;
            btn_StkSearch.Text = "検索";
            btn_StkSearch.UseVisualStyleBackColor = false;
            btn_StkSearch.Click += btn_StkSearch_Click;
            // 
            // dataGrid_Stock
            // 
            dataGrid_Stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Stock.Location = new Point(11, 475);
            dataGrid_Stock.Margin = new Padding(2);
            dataGrid_Stock.Name = "dataGrid_Stock";
            dataGrid_Stock.RowHeadersWidth = 62;
            dataGrid_Stock.RowTemplate.Height = 33;
            dataGrid_Stock.Size = new Size(1882, 520);
            dataGrid_Stock.TabIndex = 56;
            dataGrid_Stock.CellClick += dataGrid_Stock_CellClick;
            // 
            // btn_StkBack
            // 
            btn_StkBack.BackColor = Color.DarkOrange;
            btn_StkBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_StkBack.Location = new Point(1686, 26);
            btn_StkBack.Margin = new Padding(2);
            btn_StkBack.Name = "btn_StkBack";
            btn_StkBack.Size = new Size(192, 86);
            btn_StkBack.TabIndex = 57;
            btn_StkBack.Text = "戻る";
            btn_StkBack.UseVisualStyleBackColor = false;
            btn_StkBack.Click += btn_StkBack_Click;
            // 
            // btn_StkShow
            // 
            btn_StkShow.BackColor = Color.LightPink;
            btn_StkShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkShow.Location = new Point(864, 114);
            btn_StkShow.Margin = new Padding(2);
            btn_StkShow.Name = "btn_StkShow";
            btn_StkShow.Size = new Size(185, 100);
            btn_StkShow.TabIndex = 5;
            btn_StkShow.Text = "一覧表示";
            btn_StkShow.UseVisualStyleBackColor = false;
            btn_StkShow.Click += btn_StkShow_Click;
            // 
            // lbl_StkPrdctID
            // 
            lbl_StkPrdctID.AutoSize = true;
            lbl_StkPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkPrdctID.Location = new Point(626, 330);
            lbl_StkPrdctID.Margin = new Padding(2, 0, 2, 0);
            lbl_StkPrdctID.Name = "lbl_StkPrdctID";
            lbl_StkPrdctID.Size = new Size(85, 32);
            lbl_StkPrdctID.TabIndex = 59;
            lbl_StkPrdctID.Text = "商品ID";
            // 
            // button2
            // 
            button2.BackColor = Color.LightPink;
            button2.Location = new Point(838, 213);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(111, 44);
            button2.TabIndex = 60;
            button2.Text = "非表示";
            button2.UseVisualStyleBackColor = false;
            // 
            // lbl_StkSelectForm
            // 
            lbl_StkSelectForm.AutoSize = true;
            lbl_StkSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkSelectForm.Location = new Point(33, 31);
            lbl_StkSelectForm.Name = "lbl_StkSelectForm";
            lbl_StkSelectForm.Size = new Size(227, 32);
            lbl_StkSelectForm.TabIndex = 102;
            lbl_StkSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_StkFormShow
            // 
            btn_StkFormShow.BackColor = Color.Transparent;
            btn_StkFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkFormShow.Location = new Point(49, 112);
            btn_StkFormShow.Name = "btn_StkFormShow";
            btn_StkFormShow.Size = new Size(192, 42);
            btn_StkFormShow.TabIndex = 101;
            btn_StkFormShow.Text = "表示";
            btn_StkFormShow.UseVisualStyleBackColor = false;
            btn_StkFormShow.Click += btn_StkFormShow_Click;
            // 
            // cmb_StkSelectForm
            // 
            cmb_StkSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_StkSelectForm.FormattingEnabled = true;
            cmb_StkSelectForm.Location = new Point(33, 66);
            cmb_StkSelectForm.Name = "cmb_StkSelectForm";
            cmb_StkSelectForm.Size = new Size(227, 40);
            cmb_StkSelectForm.TabIndex = 100;
            // 
            // lbl_StockDate
            // 
            lbl_StockDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StockDate.Location = new Point(1121, 43);
            lbl_StockDate.Name = "lbl_StockDate";
            lbl_StockDate.Size = new Size(354, 33);
            lbl_StockDate.TabIndex = 131;
            lbl_StockDate.Text = "日付：";
            lbl_StockDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Stockkengenmei
            // 
            lbl_Stockkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Stockkengenmei.Location = new Point(791, 43);
            lbl_Stockkengenmei.Name = "lbl_Stockkengenmei";
            lbl_Stockkengenmei.Size = new Size(324, 33);
            lbl_Stockkengenmei.TabIndex = 130;
            lbl_Stockkengenmei.Text = "権限名：";
            lbl_Stockkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StockLoginuser
            // 
            lbl_StockLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StockLoginuser.Location = new Point(401, 43);
            lbl_StockLoginuser.Name = "lbl_StockLoginuser";
            lbl_StockLoginuser.Size = new Size(384, 33);
            lbl_StockLoginuser.TabIndex = 129;
            lbl_StockLoginuser.Text = "ログインユーザー：";
            lbl_StockLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StkPage
            // 
            lbl_StkPage.AutoSize = true;
            lbl_StkPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkPage.Location = new Point(1666, 1003);
            lbl_StkPage.Name = "lbl_StkPage";
            lbl_StkPage.Size = new Size(46, 21);
            lbl_StkPage.TabIndex = 157;
            lbl_StkPage.Text = "ページ";
            // 
            // txb_StkPage
            // 
            txb_StkPage.Location = new Point(1609, 1003);
            txb_StkPage.Name = "txb_StkPage";
            txb_StkPage.Size = new Size(51, 23);
            txb_StkPage.TabIndex = 156;
            // 
            // btn_StkLastPage
            // 
            btn_StkLastPage.Location = new Point(1854, 998);
            btn_StkLastPage.Name = "btn_StkLastPage";
            btn_StkLastPage.Size = new Size(38, 31);
            btn_StkLastPage.TabIndex = 155;
            btn_StkLastPage.Text = "➜";
            btn_StkLastPage.UseVisualStyleBackColor = true;
            btn_StkLastPage.Click += btn_StkLastPage_Click;
            // 
            // btn_StkPrevPage
            // 
            btn_StkPrevPage.Location = new Point(1774, 998);
            btn_StkPrevPage.Name = "btn_StkPrevPage";
            btn_StkPrevPage.Size = new Size(38, 31);
            btn_StkPrevPage.TabIndex = 154;
            btn_StkPrevPage.Text = "◀️";
            btn_StkPrevPage.UseVisualStyleBackColor = true;
            btn_StkPrevPage.Click += btn_StkPrevPage_Click;
            // 
            // btn_StkNextPage
            // 
            btn_StkNextPage.Location = new Point(1814, 998);
            btn_StkNextPage.Name = "btn_StkNextPage";
            btn_StkNextPage.Size = new Size(38, 31);
            btn_StkNextPage.TabIndex = 153;
            btn_StkNextPage.Text = "▶️";
            btn_StkNextPage.UseVisualStyleBackColor = true;
            btn_StkNextPage.Click += btn_StkNextPage_Click;
            // 
            // btn_StkChangeSize
            // 
            btn_StkChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkChangeSize.Location = new Point(171, 1008);
            btn_StkChangeSize.Name = "btn_StkChangeSize";
            btn_StkChangeSize.Size = new Size(99, 26);
            btn_StkChangeSize.TabIndex = 160;
            btn_StkChangeSize.Text = "行数変更";
            btn_StkChangeSize.UseVisualStyleBackColor = true;
            btn_StkChangeSize.Click += btn_StkChangeSize_Click;
            // 
            // txb_StkPageSize
            // 
            txb_StkPageSize.Location = new Point(105, 1008);
            txb_StkPageSize.Name = "txb_StkPageSize";
            txb_StkPageSize.Size = new Size(51, 23);
            txb_StkPageSize.TabIndex = 159;
            // 
            // lbl_StkPageSize
            // 
            lbl_StkPageSize.AutoSize = true;
            lbl_StkPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkPageSize.Location = new Point(12, 1008);
            lbl_StkPageSize.Name = "lbl_StkPageSize";
            lbl_StkPageSize.Size = new Size(87, 21);
            lbl_StkPageSize.TabIndex = 158;
            lbl_StkPageSize.Text = "1ページ行数";
            // 
            // btn_StkFirstPage
            // 
            btn_StkFirstPage.Location = new Point(1734, 998);
            btn_StkFirstPage.Name = "btn_StkFirstPage";
            btn_StkFirstPage.Size = new Size(38, 31);
            btn_StkFirstPage.TabIndex = 164;
            btn_StkFirstPage.Text = "|";
            btn_StkFirstPage.UseVisualStyleBackColor = true;
            btn_StkFirstPage.Click += btn_StkFirstPage_Click;
            // 
            // lbl_StkPrdctName
            // 
            lbl_StkPrdctName.AutoSize = true;
            lbl_StkPrdctName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkPrdctName.Location = new Point(917, 330);
            lbl_StkPrdctName.Margin = new Padding(2, 0, 2, 0);
            lbl_StkPrdctName.Name = "lbl_StkPrdctName";
            lbl_StkPrdctName.Size = new Size(86, 32);
            lbl_StkPrdctName.TabIndex = 166;
            lbl_StkPrdctName.Text = "商品名";
            // 
            // txb_StkPrdctName
            // 
            txb_StkPrdctName.Enabled = false;
            txb_StkPrdctName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StkPrdctName.Location = new Point(1009, 327);
            txb_StkPrdctName.Margin = new Padding(2);
            txb_StkPrdctName.Name = "txb_StkPrdctName";
            txb_StkPrdctName.Size = new Size(150, 39);
            txb_StkPrdctName.TabIndex = 165;
            // 
            // lbl_StkHidden
            // 
            lbl_StkHidden.AutoSize = true;
            lbl_StkHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StkHidden.Location = new Point(1515, 327);
            lbl_StkHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_StkHidden.Name = "lbl_StkHidden";
            lbl_StkHidden.Size = new Size(86, 32);
            lbl_StkHidden.TabIndex = 168;
            lbl_StkHidden.Text = "非表示";
            // 
            // CheckBox_StkHidden
            // 
            CheckBox_StkHidden.AutoSize = true;
            CheckBox_StkHidden.BackColor = Color.Transparent;
            CheckBox_StkHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_StkHidden.Location = new Point(1495, 340);
            CheckBox_StkHidden.Name = "CheckBox_StkHidden";
            CheckBox_StkHidden.Size = new Size(15, 14);
            CheckBox_StkHidden.TabIndex = 3;
            CheckBox_StkHidden.UseVisualStyleBackColor = false;
            // 
            // btn_StkInputClear
            // 
            btn_StkInputClear.BackColor = Color.PeachPuff;
            btn_StkInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StkInputClear.Location = new Point(1725, 398);
            btn_StkInputClear.Name = "btn_StkInputClear";
            btn_StkInputClear.Size = new Size(153, 60);
            btn_StkInputClear.TabIndex = 184;
            btn_StkInputClear.Text = "入力クリア";
            btn_StkInputClear.UseVisualStyleBackColor = false;
            btn_StkInputClear.Click += btn_StkInputClear_Click;
            // 
            // F_Stock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_StkInputClear);
            Controls.Add(lbl_StkHidden);
            Controls.Add(CheckBox_StkHidden);
            Controls.Add(lbl_StkPrdctName);
            Controls.Add(txb_StkPrdctName);
            Controls.Add(btn_StkFirstPage);
            Controls.Add(btn_StkChangeSize);
            Controls.Add(txb_StkPageSize);
            Controls.Add(lbl_StkPageSize);
            Controls.Add(lbl_StkPage);
            Controls.Add(txb_StkPage);
            Controls.Add(btn_StkLastPage);
            Controls.Add(btn_StkPrevPage);
            Controls.Add(btn_StkNextPage);
            Controls.Add(lbl_StockDate);
            Controls.Add(lbl_Stockkengenmei);
            Controls.Add(lbl_StockLoginuser);
            Controls.Add(lbl_StkSelectForm);
            Controls.Add(btn_StkFormShow);
            Controls.Add(cmb_StkSelectForm);
            Controls.Add(lbl_StkPrdctID);
            Controls.Add(btn_StkShow);
            Controls.Add(btn_StkBack);
            Controls.Add(dataGrid_Stock);
            Controls.Add(btn_StkUpdate);
            Controls.Add(txb_StkStockNum);
            Controls.Add(lbl_StkStockNum);
            Controls.Add(txb_StkPrdctID);
            Controls.Add(txb_StkStockID);
            Controls.Add(lbl_StkStockID);
            Controls.Add(btn_StkSearch);
            Margin = new Padding(2);
            Name = "F_Stock";
            Text = "販売管理システム在庫画面";
            Load += F_Stock_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Stock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button UpdateCustomerdate;
        private TextBox txb_StkStockNum;
        private Label lbl_StkStockNum;
        private Label lbl_StkStockID;
        private TextBox txb_StkPrdctID;
        private TextBox txb_StkStockID;
        private Button SerchCustomerdate;
        private Button btn_StkSearch;
        private Button btn_StkUpdate;
        private Button btn_StkShow;
        private Button btn_StkFormShow;
        private Button Manage_stock;
        private DataGridView dataGrid_Stock;
        private Button button10;
        private Label lbl_StkPrdctID;
        private Button button2;
        private Label lbl_StkSelectForm;
        private Button btn_JOrderFormShow;
        private ComboBox cmb_StkSelectForm;
        private Label lbl_StockDate;
        private Label lbl_Stockkengenmei;
        private Label lbl_StockLoginuser;
        private Label lbl_StkPage;
        private TextBox txb_StkPage;
        private Button btn_StkLastPage;
        private Button btn_StkPrevPage;
        private Button btn_StkNextPage;
        private Button btn_StkChangeSize;
        private TextBox txb_StkPageSize;
        private Label lbl_StkPageSize;
        private Button btn_StkFirstPage;
        internal protected Button btn_StkBack;
        private Label lbl_StkPrdctName;
        private TextBox txb_StkPrdctName;
        private Label lbl_StkHidden;
        private CheckBox CheckBox_StkHidden;
        private Button btn_StkInputClear;
    }
}