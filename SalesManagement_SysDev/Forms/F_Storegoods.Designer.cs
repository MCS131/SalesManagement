namespace SalesManagement_SysDev
{
    partial class F_Storegoods
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
            dtp_StgStoreDate = new DateTimePicker();
            btn_StgtFix = new Button();
            btn_StgHidden = new Button();
            btn_StgBack = new Button();
            lbl_SgSelectForm = new Label();
            btn_SgFormShow = new Button();
            cmb_SgSelectForm = new ComboBox();
            lbl_StgHidden = new Label();
            lbl_StgStoreDate = new Label();
            CheckBox_StgHidden = new CheckBox();
            dataGrid_Stg = new DataGridView();
            btn_StgSearch = new Button();
            btn_StgShowList = new Button();
            txb_StgStoregoodsID = new TextBox();
            lbl_StgStoregoodsID = new Label();
            txb_StgPrdctID = new TextBox();
            txb_StgJOrderID = new TextBox();
            lbl_StgJOrderID = new Label();
            lbl_StgEmpID = new Label();
            lbl_StgStoreDetailID = new Label();
            lbl_StgPrdctID = new Label();
            lbl_StgNum = new Label();
            txb_StgEmpID = new TextBox();
            txb_StgStoreDetailID = new TextBox();
            txb_StgNum = new TextBox();
            lbl_StgDate = new Label();
            lbl_Stgkengenmei = new Label();
            lbl_StgLoginuser = new Label();
            lbl_StgPage = new Label();
            txb_StgPage = new TextBox();
            btn_StgLastPage = new Button();
            btn_StgPrevPage = new Button();
            btn_StgNextPage = new Button();
            btn_StgHiddenReason = new Button();
            label1 = new Label();
            txb_StgSalesOfficeID = new TextBox();
            btn_StgChangeSize = new Button();
            txb_StgPageSize = new TextBox();
            lbl_StgPageSize = new Label();
            btn_StgFirstPage = new Button();
            txb_StgSalesOfficeName = new TextBox();
            lbl_StgSalesOfficeName = new Label();
            txb_StgEmpName = new TextBox();
            lbl_StgEmpName = new Label();
            txb_StgCstmrName = new TextBox();
            lbl_StgCstmrName = new Label();
            txb_StgCstmrID = new TextBox();
            lbl_StgCstmrID = new Label();
            btn_StgShowDetail = new Button();
            txb_StgPrdctName = new TextBox();
            lbl_StgProductName = new Label();
            btn_StgInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Stg).BeginInit();
            SuspendLayout();
            // 
            // dtp_StgStoreDate
            // 
            dtp_StgStoreDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_StgStoreDate.Location = new Point(1167, 233);
            dtp_StgStoreDate.Margin = new Padding(2);
            dtp_StgStoreDate.Name = "dtp_StgStoreDate";
            dtp_StgStoreDate.Size = new Size(223, 39);
            dtp_StgStoreDate.TabIndex = 3;
            // 
            // btn_StgtFix
            // 
            btn_StgtFix.BackColor = Color.Khaki;
            btn_StgtFix.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgtFix.Location = new Point(1274, 112);
            btn_StgtFix.Margin = new Padding(2);
            btn_StgtFix.Name = "btn_StgtFix";
            btn_StgtFix.Size = new Size(185, 100);
            btn_StgtFix.TabIndex = 13;
            btn_StgtFix.Text = "入荷確定";
            btn_StgtFix.UseVisualStyleBackColor = false;
            btn_StgtFix.Click += btn_StgtFix_Click;
            // 
            // btn_StgHidden
            // 
            btn_StgHidden.BackColor = Color.Khaki;
            btn_StgHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgHidden.Location = new Point(1024, 112);
            btn_StgHidden.Margin = new Padding(2);
            btn_StgHidden.Name = "btn_StgHidden";
            btn_StgHidden.Size = new Size(185, 100);
            btn_StgHidden.TabIndex = 12;
            btn_StgHidden.Text = "非表示更新";
            btn_StgHidden.UseVisualStyleBackColor = false;
            btn_StgHidden.Click += btn_StgHidden_Click;
            // 
            // btn_StgBack
            // 
            btn_StgBack.BackColor = Color.Gold;
            btn_StgBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_StgBack.Location = new Point(1686, 26);
            btn_StgBack.Margin = new Padding(2);
            btn_StgBack.Name = "btn_StgBack";
            btn_StgBack.Size = new Size(192, 86);
            btn_StgBack.TabIndex = 132;
            btn_StgBack.Text = "戻る";
            btn_StgBack.UseVisualStyleBackColor = false;
            btn_StgBack.Click += btn_SgBack_Click;
            // 
            // lbl_SgSelectForm
            // 
            lbl_SgSelectForm.AutoSize = true;
            lbl_SgSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SgSelectForm.Location = new Point(33, 31);
            lbl_SgSelectForm.Name = "lbl_SgSelectForm";
            lbl_SgSelectForm.Size = new Size(227, 32);
            lbl_SgSelectForm.TabIndex = 131;
            lbl_SgSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_SgFormShow
            // 
            btn_SgFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SgFormShow.Location = new Point(49, 112);
            btn_SgFormShow.Name = "btn_SgFormShow";
            btn_SgFormShow.Size = new Size(192, 42);
            btn_SgFormShow.TabIndex = 130;
            btn_SgFormShow.Text = "表示";
            btn_SgFormShow.UseVisualStyleBackColor = true;
            btn_SgFormShow.Click += btn_SgFormShow_Click;
            // 
            // cmb_SgSelectForm
            // 
            cmb_SgSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_SgSelectForm.FormattingEnabled = true;
            cmb_SgSelectForm.Location = new Point(33, 66);
            cmb_SgSelectForm.Name = "cmb_SgSelectForm";
            cmb_SgSelectForm.Size = new Size(227, 40);
            cmb_SgSelectForm.TabIndex = 129;
            // 
            // lbl_StgHidden
            // 
            lbl_StgHidden.AutoSize = true;
            lbl_StgHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgHidden.Location = new Point(12, 433);
            lbl_StgHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_StgHidden.Name = "lbl_StgHidden";
            lbl_StgHidden.Size = new Size(86, 32);
            lbl_StgHidden.TabIndex = 128;
            lbl_StgHidden.Text = "非表示";
            // 
            // lbl_StgStoreDate
            // 
            lbl_StgStoreDate.AutoSize = true;
            lbl_StgStoreDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgStoreDate.Location = new Point(1024, 236);
            lbl_StgStoreDate.Margin = new Padding(2, 0, 2, 0);
            lbl_StgStoreDate.Name = "lbl_StgStoreDate";
            lbl_StgStoreDate.Size = new Size(134, 32);
            lbl_StgStoreDate.TabIndex = 124;
            lbl_StgStoreDate.Text = "入庫年月日";
            // 
            // CheckBox_StgHidden
            // 
            CheckBox_StgHidden.AutoSize = true;
            CheckBox_StgHidden.BackColor = Color.Transparent;
            CheckBox_StgHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_StgHidden.Location = new Point(98, 444);
            CheckBox_StgHidden.Name = "CheckBox_StgHidden";
            CheckBox_StgHidden.Size = new Size(15, 14);
            CheckBox_StgHidden.TabIndex = 8;
            CheckBox_StgHidden.UseVisualStyleBackColor = false;
            // 
            // dataGrid_Stg
            // 
            dataGrid_Stg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Stg.Location = new Point(11, 473);
            dataGrid_Stg.Margin = new Padding(2);
            dataGrid_Stg.Name = "dataGrid_Stg";
            dataGrid_Stg.RowHeadersWidth = 62;
            dataGrid_Stg.RowTemplate.Height = 33;
            dataGrid_Stg.Size = new Size(1882, 520);
            dataGrid_Stg.TabIndex = 121;
            dataGrid_Stg.CellClick += dataGrid_Stg_CellClick;
            // 
            // btn_StgSearch
            // 
            btn_StgSearch.BackColor = Color.Khaki;
            btn_StgSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgSearch.Location = new Point(764, 112);
            btn_StgSearch.Margin = new Padding(2);
            btn_StgSearch.Name = "btn_StgSearch";
            btn_StgSearch.Size = new Size(185, 100);
            btn_StgSearch.TabIndex = 11;
            btn_StgSearch.Text = "検索";
            btn_StgSearch.UseVisualStyleBackColor = false;
            btn_StgSearch.Click += btn_StgSearch_Click;
            // 
            // btn_StgShowList
            // 
            btn_StgShowList.BackColor = Color.Khaki;
            btn_StgShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgShowList.Location = new Point(501, 112);
            btn_StgShowList.Margin = new Padding(2);
            btn_StgShowList.Name = "btn_StgShowList";
            btn_StgShowList.Size = new Size(185, 100);
            btn_StgShowList.TabIndex = 10;
            btn_StgShowList.Text = "一覧表示";
            btn_StgShowList.UseVisualStyleBackColor = false;
            btn_StgShowList.Click += btn_StgShowList_Click;
            // 
            // txb_StgStoregoodsID
            // 
            txb_StgStoregoodsID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgStoregoodsID.Location = new Point(573, 234);
            txb_StgStoregoodsID.Margin = new Padding(2);
            txb_StgStoregoodsID.Name = "txb_StgStoregoodsID";
            txb_StgStoregoodsID.Size = new Size(149, 39);
            txb_StgStoregoodsID.TabIndex = 1;
            // 
            // lbl_StgStoregoodsID
            // 
            lbl_StgStoregoodsID.AutoSize = true;
            lbl_StgStoregoodsID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgStoregoodsID.Location = new Point(451, 237);
            lbl_StgStoregoodsID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgStoregoodsID.Name = "lbl_StgStoregoodsID";
            lbl_StgStoregoodsID.Size = new Size(85, 32);
            lbl_StgStoregoodsID.TabIndex = 115;
            lbl_StgStoregoodsID.Text = "入荷ID";
            // 
            // txb_StgPrdctID
            // 
            txb_StgPrdctID.Enabled = false;
            txb_StgPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgPrdctID.Location = new Point(838, 427);
            txb_StgPrdctID.Margin = new Padding(2);
            txb_StgPrdctID.Name = "txb_StgPrdctID";
            txb_StgPrdctID.Size = new Size(109, 39);
            txb_StgPrdctID.TabIndex = 113;
            txb_StgPrdctID.TextChanged += txb_StgPrdctID_TextChanged;
            // 
            // txb_StgJOrderID
            // 
            txb_StgJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgJOrderID.Location = new Point(862, 233);
            txb_StgJOrderID.Margin = new Padding(2);
            txb_StgJOrderID.Name = "txb_StgJOrderID";
            txb_StgJOrderID.Size = new Size(99, 39);
            txb_StgJOrderID.TabIndex = 2;
            // 
            // lbl_StgJOrderID
            // 
            lbl_StgJOrderID.AutoSize = true;
            lbl_StgJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgJOrderID.Location = new Point(773, 236);
            lbl_StgJOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgJOrderID.Name = "lbl_StgJOrderID";
            lbl_StgJOrderID.Size = new Size(85, 32);
            lbl_StgJOrderID.TabIndex = 111;
            lbl_StgJOrderID.Text = "受注ID";
            // 
            // lbl_StgEmpID
            // 
            lbl_StgEmpID.AutoSize = true;
            lbl_StgEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgEmpID.Location = new Point(451, 338);
            lbl_StgEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgEmpID.Name = "lbl_StgEmpID";
            lbl_StgEmpID.Size = new Size(85, 32);
            lbl_StgEmpID.TabIndex = 110;
            lbl_StgEmpID.Text = "社員ID";
            // 
            // lbl_StgStoreDetailID
            // 
            lbl_StgStoreDetailID.AutoSize = true;
            lbl_StgStoreDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgStoreDetailID.Location = new Point(427, 432);
            lbl_StgStoreDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgStoreDetailID.Name = "lbl_StgStoreDetailID";
            lbl_StgStoreDetailID.Size = new Size(133, 32);
            lbl_StgStoreDetailID.TabIndex = 142;
            lbl_StgStoreDetailID.Text = "入庫詳細ID";
            // 
            // lbl_StgPrdctID
            // 
            lbl_StgPrdctID.AutoSize = true;
            lbl_StgPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgPrdctID.Location = new Point(749, 428);
            lbl_StgPrdctID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgPrdctID.Name = "lbl_StgPrdctID";
            lbl_StgPrdctID.Size = new Size(85, 32);
            lbl_StgPrdctID.TabIndex = 143;
            lbl_StgPrdctID.Text = "商品ID";
            // 
            // lbl_StgNum
            // 
            lbl_StgNum.AutoSize = true;
            lbl_StgNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgNum.Location = new Point(1250, 432);
            lbl_StgNum.Margin = new Padding(2, 0, 2, 0);
            lbl_StgNum.Name = "lbl_StgNum";
            lbl_StgNum.Size = new Size(62, 32);
            lbl_StgNum.TabIndex = 144;
            lbl_StgNum.Text = "数量";
            // 
            // txb_StgEmpID
            // 
            txb_StgEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgEmpID.Location = new Point(573, 331);
            txb_StgEmpID.Margin = new Padding(2);
            txb_StgEmpID.Name = "txb_StgEmpID";
            txb_StgEmpID.Size = new Size(68, 39);
            txb_StgEmpID.TabIndex = 5;
            txb_StgEmpID.TextChanged += txb_StgEmpID_TextChanged;
            // 
            // txb_StgStoreDetailID
            // 
            txb_StgStoreDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgStoreDetailID.Location = new Point(573, 425);
            txb_StgStoreDetailID.Margin = new Padding(2);
            txb_StgStoreDetailID.Name = "txb_StgStoreDetailID";
            txb_StgStoreDetailID.Size = new Size(68, 39);
            txb_StgStoreDetailID.TabIndex = 7;
            txb_StgStoreDetailID.TextChanged += txb_StgStoreDetailID_TextChanged;
            // 
            // txb_StgNum
            // 
            txb_StgNum.Enabled = false;
            txb_StgNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgNum.Location = new Point(1316, 425);
            txb_StgNum.Margin = new Padding(2);
            txb_StgNum.Name = "txb_StgNum";
            txb_StgNum.Size = new Size(108, 39);
            txb_StgNum.TabIndex = 147;
            // 
            // lbl_StgDate
            // 
            lbl_StgDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StgDate.Location = new Point(1121, 43);
            lbl_StgDate.Name = "lbl_StgDate";
            lbl_StgDate.Size = new Size(354, 33);
            lbl_StgDate.TabIndex = 150;
            lbl_StgDate.Text = "日付：";
            lbl_StgDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Stgkengenmei
            // 
            lbl_Stgkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Stgkengenmei.Location = new Point(791, 43);
            lbl_Stgkengenmei.Name = "lbl_Stgkengenmei";
            lbl_Stgkengenmei.Size = new Size(324, 33);
            lbl_Stgkengenmei.TabIndex = 149;
            lbl_Stgkengenmei.Text = "権限名：";
            lbl_Stgkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StgLoginuser
            // 
            lbl_StgLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StgLoginuser.Location = new Point(401, 43);
            lbl_StgLoginuser.Name = "lbl_StgLoginuser";
            lbl_StgLoginuser.Size = new Size(384, 33);
            lbl_StgLoginuser.TabIndex = 148;
            lbl_StgLoginuser.Text = "ログインユーザー：";
            lbl_StgLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StgPage
            // 
            lbl_StgPage.AutoSize = true;
            lbl_StgPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgPage.Location = new Point(1666, 1003);
            lbl_StgPage.Name = "lbl_StgPage";
            lbl_StgPage.Size = new Size(46, 21);
            lbl_StgPage.TabIndex = 157;
            lbl_StgPage.Text = "ページ";
            // 
            // txb_StgPage
            // 
            txb_StgPage.Location = new Point(1609, 1003);
            txb_StgPage.Name = "txb_StgPage";
            txb_StgPage.Size = new Size(51, 23);
            txb_StgPage.TabIndex = 156;
            // 
            // btn_StgLastPage
            // 
            btn_StgLastPage.Location = new Point(1855, 998);
            btn_StgLastPage.Name = "btn_StgLastPage";
            btn_StgLastPage.Size = new Size(38, 31);
            btn_StgLastPage.TabIndex = 155;
            btn_StgLastPage.Text = "➜";
            btn_StgLastPage.UseVisualStyleBackColor = true;
            btn_StgLastPage.Click += btn_StgLastPage_Click;
            // 
            // btn_StgPrevPage
            // 
            btn_StgPrevPage.Location = new Point(1775, 998);
            btn_StgPrevPage.Name = "btn_StgPrevPage";
            btn_StgPrevPage.Size = new Size(38, 31);
            btn_StgPrevPage.TabIndex = 154;
            btn_StgPrevPage.Text = "◀️";
            btn_StgPrevPage.UseVisualStyleBackColor = true;
            btn_StgPrevPage.Click += btn_StgPrevPage_Click;
            // 
            // btn_StgNextPage
            // 
            btn_StgNextPage.Location = new Point(1815, 998);
            btn_StgNextPage.Name = "btn_StgNextPage";
            btn_StgNextPage.Size = new Size(38, 31);
            btn_StgNextPage.TabIndex = 153;
            btn_StgNextPage.Text = "▶️";
            btn_StgNextPage.UseVisualStyleBackColor = true;
            btn_StgNextPage.Click += btn_StgNextPage_Click;
            // 
            // btn_StgHiddenReason
            // 
            btn_StgHiddenReason.BackColor = Color.PeachPuff;
            btn_StgHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgHiddenReason.Location = new Point(127, 430);
            btn_StgHiddenReason.Name = "btn_StgHiddenReason";
            btn_StgHiddenReason.Size = new Size(153, 36);
            btn_StgHiddenReason.TabIndex = 9;
            btn_StgHiddenReason.Text = "非表示理由";
            btn_StgHiddenReason.UseVisualStyleBackColor = false;
            btn_StgHiddenReason.Click += btn_StgHiddenReason_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(451, 290);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 32);
            label1.TabIndex = 159;
            label1.Text = "営業所ID";
            // 
            // txb_StgSalesOfficeID
            // 
            txb_StgSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgSalesOfficeID.Location = new Point(573, 283);
            txb_StgSalesOfficeID.Margin = new Padding(2);
            txb_StgSalesOfficeID.Name = "txb_StgSalesOfficeID";
            txb_StgSalesOfficeID.Size = new Size(68, 39);
            txb_StgSalesOfficeID.TabIndex = 4;
            txb_StgSalesOfficeID.TextChanged += txb_StgSalesOfficeID_TextChanged;
            // 
            // btn_StgChangeSize
            // 
            btn_StgChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgChangeSize.Location = new Point(171, 1008);
            btn_StgChangeSize.Name = "btn_StgChangeSize";
            btn_StgChangeSize.Size = new Size(99, 26);
            btn_StgChangeSize.TabIndex = 163;
            btn_StgChangeSize.Text = "行数変更";
            btn_StgChangeSize.UseVisualStyleBackColor = true;
            btn_StgChangeSize.Click += btn_StgChangeSize_Click;
            // 
            // txb_StgPageSize
            // 
            txb_StgPageSize.Location = new Point(105, 1008);
            txb_StgPageSize.Name = "txb_StgPageSize";
            txb_StgPageSize.Size = new Size(51, 23);
            txb_StgPageSize.TabIndex = 162;
            // 
            // lbl_StgPageSize
            // 
            lbl_StgPageSize.AutoSize = true;
            lbl_StgPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgPageSize.Location = new Point(12, 1008);
            lbl_StgPageSize.Name = "lbl_StgPageSize";
            lbl_StgPageSize.Size = new Size(87, 21);
            lbl_StgPageSize.TabIndex = 161;
            lbl_StgPageSize.Text = "1ページ行数";
            // 
            // btn_StgFirstPage
            // 
            btn_StgFirstPage.Location = new Point(1734, 998);
            btn_StgFirstPage.Name = "btn_StgFirstPage";
            btn_StgFirstPage.Size = new Size(38, 31);
            btn_StgFirstPage.TabIndex = 164;
            btn_StgFirstPage.Text = "|";
            btn_StgFirstPage.UseVisualStyleBackColor = true;
            btn_StgFirstPage.Click += btn_StgFirstPage_Click;
            // 
            // txb_StgSalesOfficeName
            // 
            txb_StgSalesOfficeName.Enabled = false;
            txb_StgSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgSalesOfficeName.Location = new Point(791, 283);
            txb_StgSalesOfficeName.Margin = new Padding(2);
            txb_StgSalesOfficeName.Name = "txb_StgSalesOfficeName";
            txb_StgSalesOfficeName.Size = new Size(268, 39);
            txb_StgSalesOfficeName.TabIndex = 169;
            // 
            // lbl_StgSalesOfficeName
            // 
            lbl_StgSalesOfficeName.AutoSize = true;
            lbl_StgSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgSalesOfficeName.Location = new Point(668, 282);
            lbl_StgSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_StgSalesOfficeName.Name = "lbl_StgSalesOfficeName";
            lbl_StgSalesOfficeName.Size = new Size(110, 32);
            lbl_StgSalesOfficeName.TabIndex = 170;
            lbl_StgSalesOfficeName.Text = "営業所名";
            // 
            // txb_StgEmpName
            // 
            txb_StgEmpName.Enabled = false;
            txb_StgEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgEmpName.Location = new Point(791, 331);
            txb_StgEmpName.Margin = new Padding(2);
            txb_StgEmpName.Name = "txb_StgEmpName";
            txb_StgEmpName.Size = new Size(268, 39);
            txb_StgEmpName.TabIndex = 174;
            // 
            // lbl_StgEmpName
            // 
            lbl_StgEmpName.AutoSize = true;
            lbl_StgEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgEmpName.Location = new Point(668, 331);
            lbl_StgEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_StgEmpName.Name = "lbl_StgEmpName";
            lbl_StgEmpName.Size = new Size(86, 32);
            lbl_StgEmpName.TabIndex = 173;
            lbl_StgEmpName.Text = "社員名";
            // 
            // txb_StgCstmrName
            // 
            txb_StgCstmrName.Enabled = false;
            txb_StgCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgCstmrName.Location = new Point(791, 378);
            txb_StgCstmrName.Margin = new Padding(2);
            txb_StgCstmrName.Name = "txb_StgCstmrName";
            txb_StgCstmrName.Size = new Size(475, 39);
            txb_StgCstmrName.TabIndex = 179;
            // 
            // lbl_StgCstmrName
            // 
            lbl_StgCstmrName.AutoSize = true;
            lbl_StgCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgCstmrName.Location = new Point(668, 381);
            lbl_StgCstmrName.Margin = new Padding(2, 0, 2, 0);
            lbl_StgCstmrName.Name = "lbl_StgCstmrName";
            lbl_StgCstmrName.Size = new Size(86, 32);
            lbl_StgCstmrName.TabIndex = 178;
            lbl_StgCstmrName.Text = "顧客名";
            // 
            // txb_StgCstmrID
            // 
            txb_StgCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgCstmrID.Location = new Point(573, 378);
            txb_StgCstmrID.Margin = new Padding(2);
            txb_StgCstmrID.Name = "txb_StgCstmrID";
            txb_StgCstmrID.Size = new Size(68, 39);
            txb_StgCstmrID.TabIndex = 6;
            txb_StgCstmrID.TextChanged += txb_StgCstmrID_TextChanged;
            // 
            // lbl_StgCstmrID
            // 
            lbl_StgCstmrID.AutoSize = true;
            lbl_StgCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgCstmrID.Location = new Point(451, 381);
            lbl_StgCstmrID.Margin = new Padding(2, 0, 2, 0);
            lbl_StgCstmrID.Name = "lbl_StgCstmrID";
            lbl_StgCstmrID.Size = new Size(85, 32);
            lbl_StgCstmrID.TabIndex = 175;
            lbl_StgCstmrID.Text = "顧客ID";
            // 
            // btn_StgShowDetail
            // 
            btn_StgShowDetail.Location = new Point(646, 428);
            btn_StgShowDetail.Name = "btn_StgShowDetail";
            btn_StgShowDetail.Size = new Size(88, 36);
            btn_StgShowDetail.TabIndex = 180;
            btn_StgShowDetail.Text = "入荷詳細一覧";
            btn_StgShowDetail.UseVisualStyleBackColor = true;
            btn_StgShowDetail.Click += btn_StgShowDetail_Click;
            // 
            // txb_StgPrdctName
            // 
            txb_StgPrdctName.Enabled = false;
            txb_StgPrdctName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StgPrdctName.Location = new Point(1053, 426);
            txb_StgPrdctName.Margin = new Padding(2);
            txb_StgPrdctName.Name = "txb_StgPrdctName";
            txb_StgPrdctName.Size = new Size(178, 39);
            txb_StgPrdctName.TabIndex = 182;
            // 
            // lbl_StgProductName
            // 
            lbl_StgProductName.AutoSize = true;
            lbl_StgProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StgProductName.Location = new Point(963, 428);
            lbl_StgProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_StgProductName.Name = "lbl_StgProductName";
            lbl_StgProductName.Size = new Size(86, 32);
            lbl_StgProductName.TabIndex = 181;
            lbl_StgProductName.Text = "商品名";
            // 
            // btn_StgInputClear
            // 
            btn_StgInputClear.BackColor = Color.PeachPuff;
            btn_StgInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StgInputClear.Location = new Point(1725, 398);
            btn_StgInputClear.Name = "btn_StgInputClear";
            btn_StgInputClear.Size = new Size(153, 60);
            btn_StgInputClear.TabIndex = 183;
            btn_StgInputClear.Text = "入力クリア";
            btn_StgInputClear.UseVisualStyleBackColor = false;
            btn_StgInputClear.Click += btn_StgInputClear_Click;
            // 
            // F_Storegoods
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_StgInputClear);
            Controls.Add(txb_StgPrdctName);
            Controls.Add(lbl_StgProductName);
            Controls.Add(btn_StgShowDetail);
            Controls.Add(txb_StgCstmrName);
            Controls.Add(lbl_StgCstmrName);
            Controls.Add(txb_StgCstmrID);
            Controls.Add(lbl_StgCstmrID);
            Controls.Add(txb_StgEmpName);
            Controls.Add(lbl_StgEmpName);
            Controls.Add(txb_StgSalesOfficeName);
            Controls.Add(lbl_StgSalesOfficeName);
            Controls.Add(btn_StgFirstPage);
            Controls.Add(btn_StgChangeSize);
            Controls.Add(txb_StgPageSize);
            Controls.Add(lbl_StgPageSize);
            Controls.Add(txb_StgSalesOfficeID);
            Controls.Add(label1);
            Controls.Add(btn_StgHiddenReason);
            Controls.Add(lbl_StgPage);
            Controls.Add(txb_StgPage);
            Controls.Add(btn_StgLastPage);
            Controls.Add(btn_StgPrevPage);
            Controls.Add(btn_StgNextPage);
            Controls.Add(lbl_StgDate);
            Controls.Add(lbl_Stgkengenmei);
            Controls.Add(lbl_StgLoginuser);
            Controls.Add(txb_StgNum);
            Controls.Add(txb_StgStoreDetailID);
            Controls.Add(txb_StgEmpID);
            Controls.Add(lbl_StgNum);
            Controls.Add(lbl_StgPrdctID);
            Controls.Add(lbl_StgStoreDetailID);
            Controls.Add(dtp_StgStoreDate);
            Controls.Add(btn_StgtFix);
            Controls.Add(btn_StgHidden);
            Controls.Add(btn_StgBack);
            Controls.Add(lbl_SgSelectForm);
            Controls.Add(btn_SgFormShow);
            Controls.Add(cmb_SgSelectForm);
            Controls.Add(lbl_StgHidden);
            Controls.Add(lbl_StgStoreDate);
            Controls.Add(CheckBox_StgHidden);
            Controls.Add(dataGrid_Stg);
            Controls.Add(btn_StgSearch);
            Controls.Add(btn_StgShowList);
            Controls.Add(txb_StgStoregoodsID);
            Controls.Add(lbl_StgStoregoodsID);
            Controls.Add(txb_StgPrdctID);
            Controls.Add(txb_StgJOrderID);
            Controls.Add(lbl_StgJOrderID);
            Controls.Add(lbl_StgEmpID);
            Name = "F_Storegoods";
            Text = "販売管理システム入荷管理画面";
            Load += F_Storegoods_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Stg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_StgStoreDate;
        private Button btn_StgtFix;
        private Button btn_StgHidden;
        private Button btn_StgBack;
        private Label lbl_SgSelectForm;
        private Button btn_SgFormShow;
        private ComboBox cmb_SgSelectForm;
        private Label lbl_StgHidden;
        private Label lbl_StgStoreDate;
        private CheckBox CheckBox_StgHidden;
        private DataGridView dataGrid_Stg;
        private Button btn_StgSearch;
        private Button btn_StgShowList;
        private TextBox txb_StgStoregoodsID;
        private Label lbl_StgStoregoodsID;
        private TextBox txb_StgPrdctID;
        private TextBox txb_StgJOrderID;
        private Label lbl_StgJOrderID;
        private Label lbl_StgEmpID;
        private Label lbl_StgStoreDetailID;
        private Label lbl_StgPrdctID;
        private Label lbl_StgNum;
        private TextBox txb_StgEmpID;
        private TextBox txb_StgStoreDetailID;
        private TextBox txb_StgNum;
        private Label lbl_StgDate;
        private Label lbl_Stgkengenmei;
        private Label lbl_StgLoginuser;
        private Label lbl_StgPage;
        private TextBox txb_StgPage;
        private Button btn_StgLastPage;
        private Button btn_StgPrevPage;
        private Button btn_StgNextPage;
        private Button btn_StgHiddenReason;
        private Label label1;
        private TextBox txb_StgSalesOfficeID;
        private Button btn_StgChangeSize;
        private TextBox txb_StgPageSize;
        private Label lbl_StgPageSize;
        private Button btn_StgFirstPage;
        private TextBox txb_StgSalesOfficeName;
        private Label lbl_StgSalesOfficeName;
        private TextBox txb_StgEmpName;
        private Label lbl_StgEmpName;
        private TextBox txb_StgCstmrName;
        private Label lbl_StgCstmrName;
        private TextBox txb_StgCstmrID;
        private Label lbl_StgCstmrID;
        private Button btn_StgShowDetail;
        private TextBox txb_StgPrdctName;
        private Label lbl_StgProductName;
        private Button btn_StgInputClear;
    }
}