namespace SalesManagement_SysDev
{
    partial class F_Storing
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
            btn_StrBack = new Button();
            btn_StrSearch = new Button();
            btn_StrShowList = new Button();
            txb_StrEmpID = new TextBox();
            lbl_StrHOrderID = new Label();
            txb_StrStoringID = new TextBox();
            lbl_StrEmpID = new Label();
            lbl_StrStoringID = new Label();
            CheckBox_StrHidden = new CheckBox();
            dataGrid_Str = new DataGridView();
            btn_StrConfirm = new Button();
            lbl_StoringDate = new Label();
            txb_StrHOrderID = new TextBox();
            lbl_StrHidden = new Label();
            lbl_StrSelectForm = new Label();
            btn_StrFormShow = new Button();
            cmb_StrSelectForm = new ComboBox();
            dtp_StrDate = new DateTimePicker();
            lbl_StrDate = new Label();
            lbl_Strkengenmei = new Label();
            lbl_StrLoginuser = new Label();
            btn_StrHiddenReason = new Button();
            btn_StrAppdate = new Button();
            lbl_StrPage = new Label();
            txb_StrPage = new TextBox();
            btn_StrLastPage = new Button();
            btn_StrPrevPage = new Button();
            btn_StrNextPage = new Button();
            btn_StrChangeSize = new Button();
            txb_StrPageSize = new TextBox();
            lbl_StrPageSize = new Label();
            btn_StrFirstPage = new Button();
            txb_StrEmpName = new TextBox();
            lbl_StrEmpName = new Label();
            btn_StrShowDetail = new Button();
            txb_StrProductName = new TextBox();
            lbl_StrProductName = new Label();
            lbl_StrProductcnt = new Label();
            txb_StrProductcnt = new TextBox();
            lbl_StrProductID = new Label();
            txb_StrProductID = new TextBox();
            lbl_StrDetailID = new Label();
            txb_StrDetailID = new TextBox();
            txb_StrPrice = new TextBox();
            lbl_StrPrice = new Label();
            txb_StrTotalPrice = new TextBox();
            lbl_StrTotalaPrice = new Label();
            btn_StrInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Str).BeginInit();
            SuspendLayout();
            // 
            // btn_StrBack
            // 
            btn_StrBack.BackColor = Color.Gold;
            btn_StrBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_StrBack.Location = new Point(1686, 26);
            btn_StrBack.Margin = new Padding(2);
            btn_StrBack.Name = "btn_StrBack";
            btn_StrBack.Size = new Size(192, 86);
            btn_StrBack.TabIndex = 51;
            btn_StrBack.Text = "戻る";
            btn_StrBack.UseVisualStyleBackColor = false;
            btn_StrBack.Click += btn_StoringBack_Click;
            // 
            // btn_StrSearch
            // 
            btn_StrSearch.BackColor = Color.Khaki;
            btn_StrSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrSearch.Location = new Point(734, 114);
            btn_StrSearch.Margin = new Padding(2);
            btn_StrSearch.Name = "btn_StrSearch";
            btn_StrSearch.Size = new Size(185, 100);
            btn_StrSearch.TabIndex = 43;
            btn_StrSearch.Text = "検索";
            btn_StrSearch.UseVisualStyleBackColor = false;
            btn_StrSearch.Click += btn_StrSearch_Click;
            // 
            // btn_StrShowList
            // 
            btn_StrShowList.BackColor = Color.Khaki;
            btn_StrShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrShowList.Location = new Point(475, 114);
            btn_StrShowList.Margin = new Padding(2);
            btn_StrShowList.Name = "btn_StrShowList";
            btn_StrShowList.Size = new Size(185, 100);
            btn_StrShowList.TabIndex = 41;
            btn_StrShowList.Text = "一覧表示";
            btn_StrShowList.UseVisualStyleBackColor = false;
            btn_StrShowList.Click += btn_StrShowList_Click;
            // 
            // txb_StrEmpID
            // 
            txb_StrEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrEmpID.Location = new Point(537, 362);
            txb_StrEmpID.Margin = new Padding(2);
            txb_StrEmpID.Name = "txb_StrEmpID";
            txb_StrEmpID.Size = new Size(96, 39);
            txb_StrEmpID.TabIndex = 4;
            txb_StrEmpID.TextChanged += txb_StrEmpID_TextChanged;
            // 
            // lbl_StrHOrderID
            // 
            lbl_StrHOrderID.AutoSize = true;
            lbl_StrHOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrHOrderID.Location = new Point(645, 312);
            lbl_StrHOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_StrHOrderID.Name = "lbl_StrHOrderID";
            lbl_StrHOrderID.Size = new Size(85, 32);
            lbl_StrHOrderID.TabIndex = 38;
            lbl_StrHOrderID.Text = "発注ID";
            // 
            // txb_StrStoringID
            // 
            txb_StrStoringID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrStoringID.Location = new Point(537, 308);
            txb_StrStoringID.Margin = new Padding(2);
            txb_StrStoringID.Name = "txb_StrStoringID";
            txb_StrStoringID.Size = new Size(96, 39);
            txb_StrStoringID.TabIndex = 1;
            txb_StrStoringID.TextChanged += txb_StrStoringID_TextChanged;
            // 
            // lbl_StrEmpID
            // 
            lbl_StrEmpID.AutoSize = true;
            lbl_StrEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrEmpID.Location = new Point(423, 365);
            lbl_StrEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_StrEmpID.Name = "lbl_StrEmpID";
            lbl_StrEmpID.Size = new Size(85, 32);
            lbl_StrEmpID.TabIndex = 32;
            lbl_StrEmpID.Text = "社員ID";
            // 
            // lbl_StrStoringID
            // 
            lbl_StrStoringID.AutoSize = true;
            lbl_StrStoringID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrStoringID.Location = new Point(423, 311);
            lbl_StrStoringID.Margin = new Padding(2, 0, 2, 0);
            lbl_StrStoringID.Name = "lbl_StrStoringID";
            lbl_StrStoringID.Size = new Size(85, 32);
            lbl_StrStoringID.TabIndex = 27;
            lbl_StrStoringID.Text = "入庫ID";
            // 
            // CheckBox_StrHidden
            // 
            CheckBox_StrHidden.AutoSize = true;
            CheckBox_StrHidden.BackColor = Color.Transparent;
            CheckBox_StrHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_StrHidden.Location = new Point(98, 444);
            CheckBox_StrHidden.Name = "CheckBox_StrHidden";
            CheckBox_StrHidden.Size = new Size(15, 14);
            CheckBox_StrHidden.TabIndex = 53;
            CheckBox_StrHidden.UseVisualStyleBackColor = false;
            // 
            // dataGrid_Str
            // 
            dataGrid_Str.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Str.Location = new Point(11, 473);
            dataGrid_Str.Margin = new Padding(2);
            dataGrid_Str.Name = "dataGrid_Str";
            dataGrid_Str.RowHeadersWidth = 62;
            dataGrid_Str.RowTemplate.Height = 33;
            dataGrid_Str.Size = new Size(1882, 520);
            dataGrid_Str.TabIndex = 55;
            dataGrid_Str.CellClick += dataGrid_Str_CellClick;
            // 
            // btn_StrConfirm
            // 
            btn_StrConfirm.BackColor = Color.Khaki;
            btn_StrConfirm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrConfirm.Location = new Point(1247, 114);
            btn_StrConfirm.Margin = new Padding(2);
            btn_StrConfirm.Name = "btn_StrConfirm";
            btn_StrConfirm.Size = new Size(185, 100);
            btn_StrConfirm.TabIndex = 56;
            btn_StrConfirm.Text = "確定";
            btn_StrConfirm.UseVisualStyleBackColor = false;
            btn_StrConfirm.Click += btn_StrConfirm_Click;
            // 
            // lbl_StoringDate
            // 
            lbl_StoringDate.AutoSize = true;
            lbl_StoringDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StoringDate.Location = new Point(899, 308);
            lbl_StoringDate.Margin = new Padding(2, 0, 2, 0);
            lbl_StoringDate.Name = "lbl_StoringDate";
            lbl_StoringDate.Size = new Size(134, 32);
            lbl_StoringDate.TabIndex = 57;
            lbl_StoringDate.Text = "入庫年月日";
            // 
            // txb_StrHOrderID
            // 
            txb_StrHOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrHOrderID.Location = new Point(734, 305);
            txb_StrHOrderID.Margin = new Padding(2);
            txb_StrHOrderID.Name = "txb_StrHOrderID";
            txb_StrHOrderID.Size = new Size(126, 39);
            txb_StrHOrderID.TabIndex = 2;
            // 
            // lbl_StrHidden
            // 
            lbl_StrHidden.AutoSize = true;
            lbl_StrHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrHidden.Location = new Point(12, 433);
            lbl_StrHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_StrHidden.Name = "lbl_StrHidden";
            lbl_StrHidden.Size = new Size(86, 32);
            lbl_StrHidden.TabIndex = 60;
            lbl_StrHidden.Text = "非表示";
            // 
            // lbl_StrSelectForm
            // 
            lbl_StrSelectForm.AutoSize = true;
            lbl_StrSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrSelectForm.Location = new Point(33, 31);
            lbl_StrSelectForm.Name = "lbl_StrSelectForm";
            lbl_StrSelectForm.Size = new Size(227, 32);
            lbl_StrSelectForm.TabIndex = 134;
            lbl_StrSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_StrFormShow
            // 
            btn_StrFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrFormShow.Location = new Point(49, 112);
            btn_StrFormShow.Name = "btn_StrFormShow";
            btn_StrFormShow.Size = new Size(185, 42);
            btn_StrFormShow.TabIndex = 133;
            btn_StrFormShow.Text = "表示";
            btn_StrFormShow.UseVisualStyleBackColor = true;
            btn_StrFormShow.Click += btn_StoringFormShow_Click;
            // 
            // cmb_StrSelectForm
            // 
            cmb_StrSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_StrSelectForm.FormattingEnabled = true;
            cmb_StrSelectForm.Location = new Point(33, 66);
            cmb_StrSelectForm.Name = "cmb_StrSelectForm";
            cmb_StrSelectForm.Size = new Size(213, 40);
            cmb_StrSelectForm.TabIndex = 132;
            // 
            // dtp_StrDate
            // 
            dtp_StrDate.CalendarFont = new Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_StrDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_StrDate.Location = new Point(1049, 304);
            dtp_StrDate.Margin = new Padding(2);
            dtp_StrDate.Name = "dtp_StrDate";
            dtp_StrDate.Size = new Size(234, 39);
            dtp_StrDate.TabIndex = 3;
            // 
            // lbl_StrDate
            // 
            lbl_StrDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StrDate.Location = new Point(1121, 43);
            lbl_StrDate.Name = "lbl_StrDate";
            lbl_StrDate.Size = new Size(354, 33);
            lbl_StrDate.TabIndex = 145;
            lbl_StrDate.Text = "日付：";
            lbl_StrDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Strkengenmei
            // 
            lbl_Strkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Strkengenmei.Location = new Point(791, 43);
            lbl_Strkengenmei.Name = "lbl_Strkengenmei";
            lbl_Strkengenmei.Size = new Size(324, 33);
            lbl_Strkengenmei.TabIndex = 144;
            lbl_Strkengenmei.Text = "権限名：";
            lbl_Strkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StrLoginuser
            // 
            lbl_StrLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StrLoginuser.Location = new Point(401, 43);
            lbl_StrLoginuser.Name = "lbl_StrLoginuser";
            lbl_StrLoginuser.Size = new Size(384, 33);
            lbl_StrLoginuser.TabIndex = 143;
            lbl_StrLoginuser.Text = "ログインユーザー：";
            lbl_StrLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_StrHiddenReason
            // 
            btn_StrHiddenReason.BackColor = Color.PeachPuff;
            btn_StrHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrHiddenReason.Location = new Point(127, 430);
            btn_StrHiddenReason.Name = "btn_StrHiddenReason";
            btn_StrHiddenReason.Size = new Size(153, 36);
            btn_StrHiddenReason.TabIndex = 146;
            btn_StrHiddenReason.Text = "非表示理由";
            btn_StrHiddenReason.UseVisualStyleBackColor = false;
            btn_StrHiddenReason.Click += btn_StrHiddenReason_Click;
            // 
            // btn_StrAppdate
            // 
            btn_StrAppdate.BackColor = Color.Khaki;
            btn_StrAppdate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrAppdate.Location = new Point(992, 114);
            btn_StrAppdate.Margin = new Padding(2);
            btn_StrAppdate.Name = "btn_StrAppdate";
            btn_StrAppdate.Size = new Size(185, 100);
            btn_StrAppdate.TabIndex = 147;
            btn_StrAppdate.Text = "非表示更新";
            btn_StrAppdate.UseVisualStyleBackColor = false;
            btn_StrAppdate.Click += btn_StrAppdate_Click;
            // 
            // lbl_StrPage
            // 
            lbl_StrPage.AutoSize = true;
            lbl_StrPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrPage.Location = new Point(1666, 1003);
            lbl_StrPage.Name = "lbl_StrPage";
            lbl_StrPage.Size = new Size(46, 21);
            lbl_StrPage.TabIndex = 157;
            lbl_StrPage.Text = "ページ";
            // 
            // txb_StrPage
            // 
            txb_StrPage.Location = new Point(1609, 1003);
            txb_StrPage.Name = "txb_StrPage";
            txb_StrPage.Size = new Size(51, 23);
            txb_StrPage.TabIndex = 156;
            // 
            // btn_StrLastPage
            // 
            btn_StrLastPage.Location = new Point(1855, 998);
            btn_StrLastPage.Name = "btn_StrLastPage";
            btn_StrLastPage.Size = new Size(38, 31);
            btn_StrLastPage.TabIndex = 155;
            btn_StrLastPage.Text = "➜";
            btn_StrLastPage.UseVisualStyleBackColor = true;
            btn_StrLastPage.Click += btn_StrLastPage_Click;
            // 
            // btn_StrPrevPage
            // 
            btn_StrPrevPage.Location = new Point(1775, 998);
            btn_StrPrevPage.Name = "btn_StrPrevPage";
            btn_StrPrevPage.Size = new Size(38, 31);
            btn_StrPrevPage.TabIndex = 154;
            btn_StrPrevPage.Text = "◀️";
            btn_StrPrevPage.UseVisualStyleBackColor = true;
            btn_StrPrevPage.Click += btn_StrPrevPage_Click;
            // 
            // btn_StrNextPage
            // 
            btn_StrNextPage.Location = new Point(1815, 998);
            btn_StrNextPage.Name = "btn_StrNextPage";
            btn_StrNextPage.Size = new Size(38, 31);
            btn_StrNextPage.TabIndex = 153;
            btn_StrNextPage.Text = "▶️";
            btn_StrNextPage.UseVisualStyleBackColor = true;
            btn_StrNextPage.Click += btn_StrNextPage_Click;
            // 
            // btn_StrChangeSize
            // 
            btn_StrChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrChangeSize.Location = new Point(171, 1008);
            btn_StrChangeSize.Name = "btn_StrChangeSize";
            btn_StrChangeSize.Size = new Size(99, 26);
            btn_StrChangeSize.TabIndex = 160;
            btn_StrChangeSize.Text = "行数変更";
            btn_StrChangeSize.UseVisualStyleBackColor = true;
            btn_StrChangeSize.Click += btn_StrChangeSize_Click;
            // 
            // txb_StrPageSize
            // 
            txb_StrPageSize.Location = new Point(105, 1008);
            txb_StrPageSize.Name = "txb_StrPageSize";
            txb_StrPageSize.Size = new Size(51, 23);
            txb_StrPageSize.TabIndex = 159;
            // 
            // lbl_StrPageSize
            // 
            lbl_StrPageSize.AutoSize = true;
            lbl_StrPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrPageSize.Location = new Point(12, 1008);
            lbl_StrPageSize.Name = "lbl_StrPageSize";
            lbl_StrPageSize.Size = new Size(87, 21);
            lbl_StrPageSize.TabIndex = 158;
            lbl_StrPageSize.Text = "1ページ行数";
            // 
            // btn_StrFirstPage
            // 
            btn_StrFirstPage.Location = new Point(1734, 998);
            btn_StrFirstPage.Name = "btn_StrFirstPage";
            btn_StrFirstPage.Size = new Size(38, 31);
            btn_StrFirstPage.TabIndex = 161;
            btn_StrFirstPage.Text = "|";
            btn_StrFirstPage.UseVisualStyleBackColor = true;
            btn_StrFirstPage.Click += btn_StrFirstPage_Click;
            // 
            // txb_StrEmpName
            // 
            txb_StrEmpName.Enabled = false;
            txb_StrEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrEmpName.Location = new Point(735, 362);
            txb_StrEmpName.Margin = new Padding(2);
            txb_StrEmpName.Name = "txb_StrEmpName";
            txb_StrEmpName.Size = new Size(268, 39);
            txb_StrEmpName.TabIndex = 174;
            // 
            // lbl_StrEmpName
            // 
            lbl_StrEmpName.AutoSize = true;
            lbl_StrEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrEmpName.Location = new Point(645, 365);
            lbl_StrEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_StrEmpName.Name = "lbl_StrEmpName";
            lbl_StrEmpName.Size = new Size(86, 32);
            lbl_StrEmpName.TabIndex = 173;
            lbl_StrEmpName.Text = "社員名";
            // 
            // btn_StrShowDetail
            // 
            btn_StrShowDetail.Location = new Point(536, 422);
            btn_StrShowDetail.Name = "btn_StrShowDetail";
            btn_StrShowDetail.Size = new Size(97, 36);
            btn_StrShowDetail.TabIndex = 193;
            btn_StrShowDetail.Text = "入庫詳細一覧";
            btn_StrShowDetail.UseVisualStyleBackColor = true;
            btn_StrShowDetail.Click += btn_StrShowDetail_Click;
            // 
            // txb_StrProductName
            // 
            txb_StrProductName.Enabled = false;
            txb_StrProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrProductName.Location = new Point(920, 419);
            txb_StrProductName.Margin = new Padding(2);
            txb_StrProductName.Name = "txb_StrProductName";
            txb_StrProductName.Size = new Size(178, 39);
            txb_StrProductName.TabIndex = 192;
            // 
            // lbl_StrProductName
            // 
            lbl_StrProductName.AutoSize = true;
            lbl_StrProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrProductName.Location = new Point(830, 422);
            lbl_StrProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_StrProductName.Name = "lbl_StrProductName";
            lbl_StrProductName.Size = new Size(86, 32);
            lbl_StrProductName.TabIndex = 191;
            lbl_StrProductName.Text = "商品名";
            // 
            // lbl_StrProductcnt
            // 
            lbl_StrProductcnt.AutoSize = true;
            lbl_StrProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrProductcnt.Location = new Point(1282, 422);
            lbl_StrProductcnt.Margin = new Padding(2, 0, 2, 0);
            lbl_StrProductcnt.Name = "lbl_StrProductcnt";
            lbl_StrProductcnt.Size = new Size(62, 32);
            lbl_StrProductcnt.TabIndex = 190;
            lbl_StrProductcnt.Text = "数量";
            // 
            // txb_StrProductcnt
            // 
            txb_StrProductcnt.Enabled = false;
            txb_StrProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrProductcnt.Location = new Point(1348, 419);
            txb_StrProductcnt.Margin = new Padding(2);
            txb_StrProductcnt.Name = "txb_StrProductcnt";
            txb_StrProductcnt.Size = new Size(96, 39);
            txb_StrProductcnt.TabIndex = 189;
            txb_StrProductcnt.TextChanged += txb_StrProductcnt_TextChanged;
            // 
            // lbl_StrProductID
            // 
            lbl_StrProductID.AutoSize = true;
            lbl_StrProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrProductID.Location = new Point(646, 422);
            lbl_StrProductID.Margin = new Padding(2, 0, 2, 0);
            lbl_StrProductID.Name = "lbl_StrProductID";
            lbl_StrProductID.Size = new Size(85, 32);
            lbl_StrProductID.TabIndex = 188;
            lbl_StrProductID.Text = "商品ID";
            // 
            // txb_StrProductID
            // 
            txb_StrProductID.Enabled = false;
            txb_StrProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrProductID.Location = new Point(735, 418);
            txb_StrProductID.Margin = new Padding(2);
            txb_StrProductID.Name = "txb_StrProductID";
            txb_StrProductID.Size = new Size(85, 39);
            txb_StrProductID.TabIndex = 100;
            txb_StrProductID.TextChanged += txb_StrProductID_TextChanged;
            // 
            // lbl_StrDetailID
            // 
            lbl_StrDetailID.AutoSize = true;
            lbl_StrDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrDetailID.Location = new Point(329, 422);
            lbl_StrDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_StrDetailID.Name = "lbl_StrDetailID";
            lbl_StrDetailID.Size = new Size(133, 32);
            lbl_StrDetailID.TabIndex = 186;
            lbl_StrDetailID.Text = "入庫詳細ID";
            // 
            // txb_StrDetailID
            // 
            txb_StrDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrDetailID.Location = new Point(463, 418);
            txb_StrDetailID.Margin = new Padding(2);
            txb_StrDetailID.Name = "txb_StrDetailID";
            txb_StrDetailID.Size = new Size(68, 39);
            txb_StrDetailID.TabIndex = 5;
            txb_StrDetailID.TextChanged += txb_StrDetailID_TextChanged;
            // 
            // txb_StrPrice
            // 
            txb_StrPrice.Enabled = false;
            txb_StrPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrPrice.Location = new Point(1168, 418);
            txb_StrPrice.Margin = new Padding(2);
            txb_StrPrice.Name = "txb_StrPrice";
            txb_StrPrice.Size = new Size(110, 39);
            txb_StrPrice.TabIndex = 197;
            // 
            // lbl_StrPrice
            // 
            lbl_StrPrice.AutoSize = true;
            lbl_StrPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrPrice.Location = new Point(1102, 422);
            lbl_StrPrice.Margin = new Padding(2, 0, 2, 0);
            lbl_StrPrice.Name = "lbl_StrPrice";
            lbl_StrPrice.Size = new Size(62, 32);
            lbl_StrPrice.TabIndex = 196;
            lbl_StrPrice.Text = "単価";
            // 
            // txb_StrTotalPrice
            // 
            txb_StrTotalPrice.Enabled = false;
            txb_StrTotalPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_StrTotalPrice.Location = new Point(1556, 416);
            txb_StrTotalPrice.Margin = new Padding(2);
            txb_StrTotalPrice.Name = "txb_StrTotalPrice";
            txb_StrTotalPrice.Size = new Size(150, 39);
            txb_StrTotalPrice.TabIndex = 195;
            // 
            // lbl_StrTotalaPrice
            // 
            lbl_StrTotalaPrice.AutoSize = true;
            lbl_StrTotalaPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StrTotalaPrice.Location = new Point(1449, 422);
            lbl_StrTotalaPrice.Name = "lbl_StrTotalaPrice";
            lbl_StrTotalaPrice.Size = new Size(110, 32);
            lbl_StrTotalaPrice.TabIndex = 194;
            lbl_StrTotalaPrice.Text = "合計金額";
            // 
            // btn_StrInputClear
            // 
            btn_StrInputClear.BackColor = Color.PeachPuff;
            btn_StrInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StrInputClear.Location = new Point(1725, 398);
            btn_StrInputClear.Name = "btn_StrInputClear";
            btn_StrInputClear.Size = new Size(153, 60);
            btn_StrInputClear.TabIndex = 198;
            btn_StrInputClear.Text = "入力クリア";
            btn_StrInputClear.UseVisualStyleBackColor = false;
            btn_StrInputClear.Click += btn_StrInputClear_Click;
            // 
            // F_Storing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_StrInputClear);
            Controls.Add(txb_StrPrice);
            Controls.Add(lbl_StrPrice);
            Controls.Add(txb_StrTotalPrice);
            Controls.Add(lbl_StrTotalaPrice);
            Controls.Add(btn_StrShowDetail);
            Controls.Add(txb_StrProductName);
            Controls.Add(lbl_StrProductName);
            Controls.Add(lbl_StrProductcnt);
            Controls.Add(txb_StrProductcnt);
            Controls.Add(lbl_StrProductID);
            Controls.Add(txb_StrProductID);
            Controls.Add(lbl_StrDetailID);
            Controls.Add(txb_StrDetailID);
            Controls.Add(txb_StrEmpName);
            Controls.Add(lbl_StrEmpName);
            Controls.Add(btn_StrFirstPage);
            Controls.Add(btn_StrChangeSize);
            Controls.Add(txb_StrPageSize);
            Controls.Add(lbl_StrPageSize);
            Controls.Add(lbl_StrPage);
            Controls.Add(txb_StrPage);
            Controls.Add(btn_StrLastPage);
            Controls.Add(btn_StrPrevPage);
            Controls.Add(btn_StrNextPage);
            Controls.Add(btn_StrAppdate);
            Controls.Add(btn_StrHiddenReason);
            Controls.Add(lbl_StrDate);
            Controls.Add(lbl_Strkengenmei);
            Controls.Add(lbl_StrLoginuser);
            Controls.Add(dtp_StrDate);
            Controls.Add(lbl_StrSelectForm);
            Controls.Add(btn_StrFormShow);
            Controls.Add(cmb_StrSelectForm);
            Controls.Add(lbl_StrHidden);
            Controls.Add(txb_StrHOrderID);
            Controls.Add(lbl_StoringDate);
            Controls.Add(btn_StrConfirm);
            Controls.Add(dataGrid_Str);
            Controls.Add(CheckBox_StrHidden);
            Controls.Add(btn_StrBack);
            Controls.Add(btn_StrSearch);
            Controls.Add(btn_StrShowList);
            Controls.Add(txb_StrEmpID);
            Controls.Add(lbl_StrHOrderID);
            Controls.Add(txb_StrStoringID);
            Controls.Add(lbl_StrEmpID);
            Controls.Add(lbl_StrStoringID);
            Margin = new Padding(2);
            Name = "F_Storing";
            Text = "販売管理システム入庫画面";
            Load += F_Storing_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Str).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_StrBack;
        private Button btn_StrSearch;
        private Button btn_StrShowList;
        private TextBox txb_StrEmpID;
        private Label lbl_StrHOrderID;
        private TextBox txb_StrStoringID;
        private Label lbl_StrEmpID;
        private Label lbl_StrStoringID;
        private CheckBox CheckBox_StrHidden;
        private DataGridView dataGrid_Str;
        private Button btn_StrConfirm;
        private Label lbl_StoringDate;
        private TextBox txb_StrHOrderID;
        private Label lbl_StrHidden;
        private Label lbl_StrSelectForm;
        private Button btn_StrFormShow;
        private ComboBox cmb_StrSelectForm;
        private DateTimePicker dtp_StrDate;
        private Label lbl_StrDate;
        private Label lbl_Strkengenmei;
        private Label lbl_StrLoginuser;
        private Button btn_StrHiddenReason;
        private Button btn_StrAppdate;
        private Label lbl_StrPage;
        private TextBox txb_StrPage;
        private Button btn_StrLastPage;
        private Button btn_StrPrevPage;
        private Button btn_StrNextPage;
        private Button btn_StrChangeSize;
        private TextBox txb_StrPageSize;
        private Label lbl_StrPageSize;
        private Button btn_StrFirstPage;
        private TextBox txb_StrEmpName;
        private Label lbl_StrEmpName;
        private Button btn_StrShowDetail;
        private TextBox txb_StrProductName;
        private Label lbl_StrProductName;
        private Label lbl_StrProductcnt;
        private TextBox txb_StrProductcnt;
        private Label lbl_StrProductID;
        private TextBox txb_StrProductID;
        private Label lbl_StrDetailID;
        private TextBox txb_StrDetailID;
        private TextBox txb_StrPrice;
        private Label lbl_StrPrice;
        private TextBox txb_StrTotalPrice;
        private Label lbl_StrTotalaPrice;
        private Button btn_StrInputClear;
    }
}