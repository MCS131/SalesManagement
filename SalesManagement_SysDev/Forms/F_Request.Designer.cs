namespace SalesManagement_SysDev
{
    partial class F_Request
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
            dataGrid_Request = new DataGridView();
            lbl_ReqSelectForm = new Label();
            btn_ReqFormShow = new Button();
            cmb_ReqSelectForm = new ComboBox();
            btn_ReqBack = new Button();
            btn_ReqConfirm = new Button();
            btn_ReqHidden = new Button();
            btn_ReqSearch = new Button();
            btn_ReqShowList = new Button();
            lbl_ReqRequestID = new Label();
            txb_ReqRequestID = new TextBox();
            lbl_ReqSalesOfficeID = new Label();
            txb_ReqSalesOfficeID = new TextBox();
            lbl_ReqEmpID = new Label();
            txb_ReqEmpID = new TextBox();
            lbl_ReqCstmrID = new Label();
            txb_ReqCstmrID = new TextBox();
            lbl_ReqDate = new Label();
            lbl_ReqJOrderID = new Label();
            txb_ReqJOrderID = new TextBox();
            dtp_ReqDate = new DateTimePicker();
            lbl_ReqHidden = new Label();
            CheckBox_ReqHidden = new CheckBox();
            lbl_ReqProductID = new Label();
            txb_ReqProductID = new TextBox();
            lbl_ReqDetailID = new Label();
            txb_ReqDetailID = new TextBox();
            lbl_ReqProductcnt = new Label();
            txb_ReqProductcnt = new TextBox();
            lbl_RequestDate = new Label();
            lbl_Requestkengenmei = new Label();
            lbl_RequestLoginuser = new Label();
            lbl_ReqPage = new Label();
            txb_ReqPage = new TextBox();
            btn_ReqLastPage = new Button();
            btn_ReqPrevPage = new Button();
            btn_ReqNextPage = new Button();
            btn_ReqHiddenReason = new Button();
            btn_ReqChangeSize = new Button();
            txb_ReqPageSize = new TextBox();
            lbl_ReqPageSize = new Label();
            btn_ReqFirstPage = new Button();
            txb_ReqSalesOfficeName = new TextBox();
            lbl_ReqSalesOfficeName = new Label();
            txb_ReqEmpName = new TextBox();
            lbl_ReqEmpName = new Label();
            txb_ReqCstmrName = new TextBox();
            lbl_ReqCstmrName = new Label();
            txb_ReqProductName = new TextBox();
            lbl_ReqProductName = new Label();
            txb_ReqTotalPrice = new TextBox();
            lbl_ReqTotalaPrice = new Label();
            txb_ReqPrice = new TextBox();
            lbl_ReqPrice = new Label();
            btn_ReqInputClear = new Button();
            btn_ReqShowDetail = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Request).BeginInit();
            SuspendLayout();
            // 
            // dataGrid_Request
            // 
            dataGrid_Request.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Request.Location = new Point(11, 473);
            dataGrid_Request.Margin = new Padding(2);
            dataGrid_Request.Name = "dataGrid_Request";
            dataGrid_Request.RowHeadersWidth = 62;
            dataGrid_Request.RowTemplate.Height = 33;
            dataGrid_Request.Size = new Size(1882, 520);
            dataGrid_Request.TabIndex = 46;
            dataGrid_Request.CellClick += dataGrid_Request_CellClick;
            // 
            // lbl_ReqSelectForm
            // 
            lbl_ReqSelectForm.AutoSize = true;
            lbl_ReqSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqSelectForm.Location = new Point(33, 31);
            lbl_ReqSelectForm.Name = "lbl_ReqSelectForm";
            lbl_ReqSelectForm.Size = new Size(227, 32);
            lbl_ReqSelectForm.TabIndex = 99;
            lbl_ReqSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_ReqFormShow
            // 
            btn_ReqFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqFormShow.Location = new Point(49, 112);
            btn_ReqFormShow.Name = "btn_ReqFormShow";
            btn_ReqFormShow.Size = new Size(192, 42);
            btn_ReqFormShow.TabIndex = 98;
            btn_ReqFormShow.Text = "表示";
            btn_ReqFormShow.UseVisualStyleBackColor = true;
            btn_ReqFormShow.Click += btn_ReqFormShow_Click;
            // 
            // cmb_ReqSelectForm
            // 
            cmb_ReqSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_ReqSelectForm.FormattingEnabled = true;
            cmb_ReqSelectForm.Location = new Point(33, 66);
            cmb_ReqSelectForm.Name = "cmb_ReqSelectForm";
            cmb_ReqSelectForm.Size = new Size(227, 40);
            cmb_ReqSelectForm.TabIndex = 97;
            // 
            // btn_ReqBack
            // 
            btn_ReqBack.BackColor = Color.Gold;
            btn_ReqBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ReqBack.Location = new Point(1686, 26);
            btn_ReqBack.Margin = new Padding(2);
            btn_ReqBack.Name = "btn_ReqBack";
            btn_ReqBack.Size = new Size(192, 86);
            btn_ReqBack.TabIndex = 101;
            btn_ReqBack.Text = "戻る";
            btn_ReqBack.UseVisualStyleBackColor = false;
            btn_ReqBack.Click += btn_ReqBack_Click;
            // 
            // btn_ReqConfirm
            // 
            btn_ReqConfirm.BackColor = Color.Khaki;
            btn_ReqConfirm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqConfirm.Location = new Point(1247, 114);
            btn_ReqConfirm.Margin = new Padding(2);
            btn_ReqConfirm.Name = "btn_ReqConfirm";
            btn_ReqConfirm.Size = new Size(185, 100);
            btn_ReqConfirm.TabIndex = 106;
            btn_ReqConfirm.Text = "注文確定";
            btn_ReqConfirm.UseVisualStyleBackColor = false;
            btn_ReqConfirm.Click += btn_ReqConfirm_Click;
            // 
            // btn_ReqHidden
            // 
            btn_ReqHidden.BackColor = Color.Khaki;
            btn_ReqHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqHidden.Location = new Point(989, 114);
            btn_ReqHidden.Margin = new Padding(2);
            btn_ReqHidden.Name = "btn_ReqHidden";
            btn_ReqHidden.Size = new Size(185, 100);
            btn_ReqHidden.TabIndex = 105;
            btn_ReqHidden.Text = "非表示更新";
            btn_ReqHidden.UseVisualStyleBackColor = false;
            btn_ReqHidden.Click += btn_ReqHidden_Click;
            // 
            // btn_ReqSearch
            // 
            btn_ReqSearch.BackColor = Color.Khaki;
            btn_ReqSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqSearch.Location = new Point(731, 114);
            btn_ReqSearch.Margin = new Padding(2);
            btn_ReqSearch.Name = "btn_ReqSearch";
            btn_ReqSearch.Size = new Size(185, 100);
            btn_ReqSearch.TabIndex = 104;
            btn_ReqSearch.Text = "検索";
            btn_ReqSearch.UseVisualStyleBackColor = false;
            btn_ReqSearch.Click += btn_ReqSearch_Click;
            // 
            // btn_ReqShowList
            // 
            btn_ReqShowList.BackColor = Color.Khaki;
            btn_ReqShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqShowList.Location = new Point(474, 114);
            btn_ReqShowList.Margin = new Padding(2);
            btn_ReqShowList.Name = "btn_ReqShowList";
            btn_ReqShowList.Size = new Size(185, 100);
            btn_ReqShowList.TabIndex = 103;
            btn_ReqShowList.Text = "一覧表示";
            btn_ReqShowList.UseVisualStyleBackColor = false;
            btn_ReqShowList.Click += btn_ReqShowList_Click;
            // 
            // lbl_ReqRequestID
            // 
            lbl_ReqRequestID.AutoSize = true;
            lbl_ReqRequestID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqRequestID.Location = new Point(185, 244);
            lbl_ReqRequestID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqRequestID.Name = "lbl_ReqRequestID";
            lbl_ReqRequestID.Size = new Size(85, 32);
            lbl_ReqRequestID.TabIndex = 108;
            lbl_ReqRequestID.Text = "注文ID";
            // 
            // txb_ReqRequestID
            // 
            txb_ReqRequestID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqRequestID.Location = new Point(322, 239);
            txb_ReqRequestID.Margin = new Padding(2);
            txb_ReqRequestID.Name = "txb_ReqRequestID";
            txb_ReqRequestID.Size = new Size(149, 39);
            txb_ReqRequestID.TabIndex = 107;
            // 
            // lbl_ReqSalesOfficeID
            // 
            lbl_ReqSalesOfficeID.AutoSize = true;
            lbl_ReqSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqSalesOfficeID.Location = new Point(881, 292);
            lbl_ReqSalesOfficeID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqSalesOfficeID.Name = "lbl_ReqSalesOfficeID";
            lbl_ReqSalesOfficeID.Size = new Size(109, 32);
            lbl_ReqSalesOfficeID.TabIndex = 110;
            lbl_ReqSalesOfficeID.Text = "営業所ID";
            // 
            // txb_ReqSalesOfficeID
            // 
            txb_ReqSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqSalesOfficeID.Location = new Point(994, 288);
            txb_ReqSalesOfficeID.Margin = new Padding(2);
            txb_ReqSalesOfficeID.Name = "txb_ReqSalesOfficeID";
            txb_ReqSalesOfficeID.Size = new Size(163, 39);
            txb_ReqSalesOfficeID.TabIndex = 109;
            txb_ReqSalesOfficeID.TextChanged += txb_ReqSalesOfficeID_TextChanged;
            // 
            // lbl_ReqEmpID
            // 
            lbl_ReqEmpID.AutoSize = true;
            lbl_ReqEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqEmpID.Location = new Point(185, 295);
            lbl_ReqEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqEmpID.Name = "lbl_ReqEmpID";
            lbl_ReqEmpID.Size = new Size(85, 32);
            lbl_ReqEmpID.TabIndex = 112;
            lbl_ReqEmpID.Text = "社員ID";
            // 
            // txb_ReqEmpID
            // 
            txb_ReqEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqEmpID.Location = new Point(322, 290);
            txb_ReqEmpID.Margin = new Padding(2);
            txb_ReqEmpID.Name = "txb_ReqEmpID";
            txb_ReqEmpID.Size = new Size(149, 39);
            txb_ReqEmpID.TabIndex = 111;
            txb_ReqEmpID.TextChanged += txb_ReqEmpID_TextChanged;
            // 
            // lbl_ReqCstmrID
            // 
            lbl_ReqCstmrID.AutoSize = true;
            lbl_ReqCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqCstmrID.Location = new Point(185, 343);
            lbl_ReqCstmrID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqCstmrID.Name = "lbl_ReqCstmrID";
            lbl_ReqCstmrID.Size = new Size(85, 32);
            lbl_ReqCstmrID.TabIndex = 114;
            lbl_ReqCstmrID.Text = "顧客ID";
            // 
            // txb_ReqCstmrID
            // 
            txb_ReqCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqCstmrID.Location = new Point(322, 339);
            txb_ReqCstmrID.Margin = new Padding(2);
            txb_ReqCstmrID.Name = "txb_ReqCstmrID";
            txb_ReqCstmrID.Size = new Size(149, 39);
            txb_ReqCstmrID.TabIndex = 113;
            txb_ReqCstmrID.TextChanged += txb_ReqCstmrID_TextChanged;
            // 
            // lbl_ReqDate
            // 
            lbl_ReqDate.AutoSize = true;
            lbl_ReqDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqDate.Location = new Point(874, 240);
            lbl_ReqDate.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqDate.Name = "lbl_ReqDate";
            lbl_ReqDate.Size = new Size(134, 32);
            lbl_ReqDate.TabIndex = 118;
            lbl_ReqDate.Text = "注文年月日";
            // 
            // lbl_ReqJOrderID
            // 
            lbl_ReqJOrderID.AutoSize = true;
            lbl_ReqJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqJOrderID.Location = new Point(498, 244);
            lbl_ReqJOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqJOrderID.Name = "lbl_ReqJOrderID";
            lbl_ReqJOrderID.Size = new Size(85, 32);
            lbl_ReqJOrderID.TabIndex = 116;
            lbl_ReqJOrderID.Text = "受注ID";
            // 
            // txb_ReqJOrderID
            // 
            txb_ReqJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqJOrderID.Location = new Point(594, 241);
            txb_ReqJOrderID.Margin = new Padding(2);
            txb_ReqJOrderID.Name = "txb_ReqJOrderID";
            txb_ReqJOrderID.Size = new Size(149, 39);
            txb_ReqJOrderID.TabIndex = 115;
            // 
            // dtp_ReqDate
            // 
            dtp_ReqDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_ReqDate.Location = new Point(1032, 237);
            dtp_ReqDate.Margin = new Padding(2);
            dtp_ReqDate.Name = "dtp_ReqDate";
            dtp_ReqDate.Size = new Size(225, 39);
            dtp_ReqDate.TabIndex = 123;
            // 
            // lbl_ReqHidden
            // 
            lbl_ReqHidden.AutoSize = true;
            lbl_ReqHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqHidden.Location = new Point(12, 433);
            lbl_ReqHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqHidden.Name = "lbl_ReqHidden";
            lbl_ReqHidden.Size = new Size(86, 32);
            lbl_ReqHidden.TabIndex = 125;
            lbl_ReqHidden.Text = "非表示";
            // 
            // CheckBox_ReqHidden
            // 
            CheckBox_ReqHidden.AutoSize = true;
            CheckBox_ReqHidden.BackColor = Color.Transparent;
            CheckBox_ReqHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_ReqHidden.Location = new Point(98, 444);
            CheckBox_ReqHidden.Name = "CheckBox_ReqHidden";
            CheckBox_ReqHidden.Size = new Size(15, 14);
            CheckBox_ReqHidden.TabIndex = 124;
            CheckBox_ReqHidden.UseVisualStyleBackColor = false;
            // 
            // lbl_ReqProductID
            // 
            lbl_ReqProductID.AutoSize = true;
            lbl_ReqProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqProductID.Location = new Point(497, 385);
            lbl_ReqProductID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqProductID.Name = "lbl_ReqProductID";
            lbl_ReqProductID.Size = new Size(85, 32);
            lbl_ReqProductID.TabIndex = 129;
            lbl_ReqProductID.Text = "商品ID";
            // 
            // txb_ReqProductID
            // 
            txb_ReqProductID.Enabled = false;
            txb_ReqProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqProductID.Location = new Point(594, 385);
            txb_ReqProductID.Margin = new Padding(2);
            txb_ReqProductID.Name = "txb_ReqProductID";
            txb_ReqProductID.Size = new Size(149, 39);
            txb_ReqProductID.TabIndex = 128;
            txb_ReqProductID.TextChanged += txb_ReqProductID_TextChanged;
            // 
            // lbl_ReqDetailID
            // 
            lbl_ReqDetailID.AutoSize = true;
            lbl_ReqDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqDetailID.Location = new Point(185, 389);
            lbl_ReqDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqDetailID.Name = "lbl_ReqDetailID";
            lbl_ReqDetailID.Size = new Size(133, 32);
            lbl_ReqDetailID.TabIndex = 127;
            lbl_ReqDetailID.Text = "注文詳細ID";
            // 
            // txb_ReqDetailID
            // 
            txb_ReqDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqDetailID.Location = new Point(322, 385);
            txb_ReqDetailID.Margin = new Padding(2);
            txb_ReqDetailID.Name = "txb_ReqDetailID";
            txb_ReqDetailID.Size = new Size(68, 39);
            txb_ReqDetailID.TabIndex = 126;
            txb_ReqDetailID.TextChanged += txb_ReqDetailID_TextChanged;
            // 
            // lbl_ReqProductcnt
            // 
            lbl_ReqProductcnt.AutoSize = true;
            lbl_ReqProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqProductcnt.Location = new Point(1228, 387);
            lbl_ReqProductcnt.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqProductcnt.Name = "lbl_ReqProductcnt";
            lbl_ReqProductcnt.Size = new Size(62, 32);
            lbl_ReqProductcnt.TabIndex = 131;
            lbl_ReqProductcnt.Text = "数量";
            // 
            // txb_ReqProductcnt
            // 
            txb_ReqProductcnt.Enabled = false;
            txb_ReqProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqProductcnt.Location = new Point(1297, 384);
            txb_ReqProductcnt.Margin = new Padding(2);
            txb_ReqProductcnt.Name = "txb_ReqProductcnt";
            txb_ReqProductcnt.Size = new Size(140, 39);
            txb_ReqProductcnt.TabIndex = 130;
            txb_ReqProductcnt.TextChanged += txb_ReqProductcnt_TextChanged;
            // 
            // lbl_RequestDate
            // 
            lbl_RequestDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_RequestDate.Location = new Point(1121, 43);
            lbl_RequestDate.Name = "lbl_RequestDate";
            lbl_RequestDate.Size = new Size(354, 33);
            lbl_RequestDate.TabIndex = 134;
            lbl_RequestDate.Text = "日付：";
            lbl_RequestDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Requestkengenmei
            // 
            lbl_Requestkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Requestkengenmei.Location = new Point(791, 43);
            lbl_Requestkengenmei.Name = "lbl_Requestkengenmei";
            lbl_Requestkengenmei.Size = new Size(324, 33);
            lbl_Requestkengenmei.TabIndex = 133;
            lbl_Requestkengenmei.Text = "権限名：";
            lbl_Requestkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_RequestLoginuser
            // 
            lbl_RequestLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_RequestLoginuser.Location = new Point(401, 43);
            lbl_RequestLoginuser.Name = "lbl_RequestLoginuser";
            lbl_RequestLoginuser.Size = new Size(384, 33);
            lbl_RequestLoginuser.TabIndex = 132;
            lbl_RequestLoginuser.Text = "ログインユーザー：";
            lbl_RequestLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ReqPage
            // 
            lbl_ReqPage.AutoSize = true;
            lbl_ReqPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqPage.Location = new Point(1666, 1003);
            lbl_ReqPage.Name = "lbl_ReqPage";
            lbl_ReqPage.Size = new Size(46, 21);
            lbl_ReqPage.TabIndex = 157;
            lbl_ReqPage.Text = "ページ";
            // 
            // txb_ReqPage
            // 
            txb_ReqPage.Location = new Point(1609, 1003);
            txb_ReqPage.Name = "txb_ReqPage";
            txb_ReqPage.Size = new Size(51, 23);
            txb_ReqPage.TabIndex = 156;
            // 
            // btn_ReqLastPage
            // 
            btn_ReqLastPage.Location = new Point(1855, 998);
            btn_ReqLastPage.Name = "btn_ReqLastPage";
            btn_ReqLastPage.Size = new Size(38, 31);
            btn_ReqLastPage.TabIndex = 155;
            btn_ReqLastPage.Text = "➜";
            btn_ReqLastPage.UseVisualStyleBackColor = true;
            btn_ReqLastPage.Click += btn_ReqLastPage_Click;
            // 
            // btn_ReqPrevPage
            // 
            btn_ReqPrevPage.Location = new Point(1775, 998);
            btn_ReqPrevPage.Name = "btn_ReqPrevPage";
            btn_ReqPrevPage.Size = new Size(38, 31);
            btn_ReqPrevPage.TabIndex = 154;
            btn_ReqPrevPage.Text = "◀️";
            btn_ReqPrevPage.UseVisualStyleBackColor = true;
            btn_ReqPrevPage.Click += btn_ReqPrevPage_Click;
            // 
            // btn_ReqNextPage
            // 
            btn_ReqNextPage.Location = new Point(1815, 998);
            btn_ReqNextPage.Name = "btn_ReqNextPage";
            btn_ReqNextPage.Size = new Size(38, 31);
            btn_ReqNextPage.TabIndex = 153;
            btn_ReqNextPage.Text = "▶️";
            btn_ReqNextPage.UseVisualStyleBackColor = true;
            btn_ReqNextPage.Click += btn_ReqNextPage_Click;
            // 
            // btn_ReqHiddenReason
            // 
            btn_ReqHiddenReason.BackColor = Color.PeachPuff;
            btn_ReqHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqHiddenReason.Location = new Point(127, 430);
            btn_ReqHiddenReason.Name = "btn_ReqHiddenReason";
            btn_ReqHiddenReason.Size = new Size(153, 36);
            btn_ReqHiddenReason.TabIndex = 158;
            btn_ReqHiddenReason.Text = "非表示理由";
            btn_ReqHiddenReason.UseVisualStyleBackColor = false;
            btn_ReqHiddenReason.Click += btn_ReqHiddenReason_Click;
            // 
            // btn_ReqChangeSize
            // 
            btn_ReqChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqChangeSize.Location = new Point(171, 1008);
            btn_ReqChangeSize.Name = "btn_ReqChangeSize";
            btn_ReqChangeSize.Size = new Size(99, 26);
            btn_ReqChangeSize.TabIndex = 161;
            btn_ReqChangeSize.Text = "行数変更";
            btn_ReqChangeSize.UseVisualStyleBackColor = true;
            btn_ReqChangeSize.Click += btn_ReqChangeSize_Click;
            // 
            // txb_ReqPageSize
            // 
            txb_ReqPageSize.Location = new Point(105, 1008);
            txb_ReqPageSize.Name = "txb_ReqPageSize";
            txb_ReqPageSize.Size = new Size(51, 23);
            txb_ReqPageSize.TabIndex = 160;
            // 
            // lbl_ReqPageSize
            // 
            lbl_ReqPageSize.AutoSize = true;
            lbl_ReqPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqPageSize.Location = new Point(12, 1008);
            lbl_ReqPageSize.Name = "lbl_ReqPageSize";
            lbl_ReqPageSize.Size = new Size(87, 21);
            lbl_ReqPageSize.TabIndex = 159;
            lbl_ReqPageSize.Text = "1ページ行数";
            // 
            // btn_ReqFirstPage
            // 
            btn_ReqFirstPage.Location = new Point(1734, 998);
            btn_ReqFirstPage.Name = "btn_ReqFirstPage";
            btn_ReqFirstPage.Size = new Size(38, 31);
            btn_ReqFirstPage.TabIndex = 162;
            btn_ReqFirstPage.Text = "|";
            btn_ReqFirstPage.UseVisualStyleBackColor = true;
            btn_ReqFirstPage.Click += btn_ReqFirstPage_Click;
            // 
            // txb_ReqSalesOfficeName
            // 
            txb_ReqSalesOfficeName.Enabled = false;
            txb_ReqSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqSalesOfficeName.Location = new Point(1305, 288);
            txb_ReqSalesOfficeName.Margin = new Padding(2);
            txb_ReqSalesOfficeName.Name = "txb_ReqSalesOfficeName";
            txb_ReqSalesOfficeName.Size = new Size(268, 39);
            txb_ReqSalesOfficeName.TabIndex = 169;
            // 
            // lbl_ReqSalesOfficeName
            // 
            lbl_ReqSalesOfficeName.AutoSize = true;
            lbl_ReqSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqSalesOfficeName.Location = new Point(1169, 291);
            lbl_ReqSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqSalesOfficeName.Name = "lbl_ReqSalesOfficeName";
            lbl_ReqSalesOfficeName.Size = new Size(110, 32);
            lbl_ReqSalesOfficeName.TabIndex = 170;
            lbl_ReqSalesOfficeName.Text = "営業所名";
            // 
            // txb_ReqEmpName
            // 
            txb_ReqEmpName.Enabled = false;
            txb_ReqEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqEmpName.Location = new Point(594, 288);
            txb_ReqEmpName.Margin = new Padding(2);
            txb_ReqEmpName.Name = "txb_ReqEmpName";
            txb_ReqEmpName.Size = new Size(268, 39);
            txb_ReqEmpName.TabIndex = 172;
            // 
            // lbl_ReqEmpName
            // 
            lbl_ReqEmpName.AutoSize = true;
            lbl_ReqEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqEmpName.Location = new Point(498, 295);
            lbl_ReqEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqEmpName.Name = "lbl_ReqEmpName";
            lbl_ReqEmpName.Size = new Size(86, 32);
            lbl_ReqEmpName.TabIndex = 171;
            lbl_ReqEmpName.Text = "社員名";
            // 
            // txb_ReqCstmrName
            // 
            txb_ReqCstmrName.Enabled = false;
            txb_ReqCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqCstmrName.Location = new Point(594, 336);
            txb_ReqCstmrName.Margin = new Padding(2);
            txb_ReqCstmrName.Name = "txb_ReqCstmrName";
            txb_ReqCstmrName.Size = new Size(475, 39);
            txb_ReqCstmrName.TabIndex = 175;
            // 
            // lbl_ReqCstmrName
            // 
            lbl_ReqCstmrName.AutoSize = true;
            lbl_ReqCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqCstmrName.Location = new Point(498, 339);
            lbl_ReqCstmrName.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqCstmrName.Name = "lbl_ReqCstmrName";
            lbl_ReqCstmrName.Size = new Size(86, 32);
            lbl_ReqCstmrName.TabIndex = 174;
            lbl_ReqCstmrName.Text = "顧客名";
            // 
            // txb_ReqProductName
            // 
            txb_ReqProductName.Enabled = false;
            txb_ReqProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqProductName.Location = new Point(853, 386);
            txb_ReqProductName.Margin = new Padding(2);
            txb_ReqProductName.Name = "txb_ReqProductName";
            txb_ReqProductName.Size = new Size(178, 39);
            txb_ReqProductName.TabIndex = 180;
            // 
            // lbl_ReqProductName
            // 
            lbl_ReqProductName.AutoSize = true;
            lbl_ReqProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqProductName.Location = new Point(756, 389);
            lbl_ReqProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqProductName.Name = "lbl_ReqProductName";
            lbl_ReqProductName.Size = new Size(86, 32);
            lbl_ReqProductName.TabIndex = 179;
            lbl_ReqProductName.Text = "商品名";
            // 
            // txb_ReqTotalPrice
            // 
            txb_ReqTotalPrice.Enabled = false;
            txb_ReqTotalPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqTotalPrice.Location = new Point(1568, 380);
            txb_ReqTotalPrice.Margin = new Padding(2);
            txb_ReqTotalPrice.Name = "txb_ReqTotalPrice";
            txb_ReqTotalPrice.Size = new Size(150, 39);
            txb_ReqTotalPrice.TabIndex = 178;
            // 
            // lbl_ReqTotalaPrice
            // 
            lbl_ReqTotalaPrice.AutoSize = true;
            lbl_ReqTotalaPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqTotalaPrice.Location = new Point(1453, 383);
            lbl_ReqTotalaPrice.Name = "lbl_ReqTotalaPrice";
            lbl_ReqTotalaPrice.Size = new Size(110, 32);
            lbl_ReqTotalaPrice.TabIndex = 177;
            lbl_ReqTotalaPrice.Text = "合計金額";
            // 
            // txb_ReqPrice
            // 
            txb_ReqPrice.Enabled = false;
            txb_ReqPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ReqPrice.Location = new Point(1105, 386);
            txb_ReqPrice.Margin = new Padding(2);
            txb_ReqPrice.Name = "txb_ReqPrice";
            txb_ReqPrice.Size = new Size(110, 39);
            txb_ReqPrice.TabIndex = 182;
            // 
            // lbl_ReqPrice
            // 
            lbl_ReqPrice.AutoSize = true;
            lbl_ReqPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ReqPrice.Location = new Point(1039, 390);
            lbl_ReqPrice.Margin = new Padding(2, 0, 2, 0);
            lbl_ReqPrice.Name = "lbl_ReqPrice";
            lbl_ReqPrice.Size = new Size(62, 32);
            lbl_ReqPrice.TabIndex = 181;
            lbl_ReqPrice.Text = "単価";
            // 
            // btn_ReqInputClear
            // 
            btn_ReqInputClear.BackColor = Color.PeachPuff;
            btn_ReqInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ReqInputClear.Location = new Point(1725, 398);
            btn_ReqInputClear.Name = "btn_ReqInputClear";
            btn_ReqInputClear.Size = new Size(153, 60);
            btn_ReqInputClear.TabIndex = 183;
            btn_ReqInputClear.Text = "入力クリア";
            btn_ReqInputClear.UseVisualStyleBackColor = false;
            btn_ReqInputClear.Click += btn_ReqInputClear_Click;
            // 
            // btn_ReqShowDetail
            // 
            btn_ReqShowDetail.Location = new Point(395, 389);
            btn_ReqShowDetail.Name = "btn_ReqShowDetail";
            btn_ReqShowDetail.Size = new Size(97, 36);
            btn_ReqShowDetail.TabIndex = 184;
            btn_ReqShowDetail.Text = "注文詳細一覧";
            btn_ReqShowDetail.UseVisualStyleBackColor = true;
            btn_ReqShowDetail.Click += btn_ReqShowDetail_Click;
            // 
            // F_Request
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_ReqShowDetail);
            Controls.Add(btn_ReqInputClear);
            Controls.Add(txb_ReqPrice);
            Controls.Add(lbl_ReqPrice);
            Controls.Add(txb_ReqProductName);
            Controls.Add(lbl_ReqProductName);
            Controls.Add(txb_ReqTotalPrice);
            Controls.Add(lbl_ReqTotalaPrice);
            Controls.Add(txb_ReqCstmrName);
            Controls.Add(lbl_ReqCstmrName);
            Controls.Add(txb_ReqEmpName);
            Controls.Add(lbl_ReqEmpName);
            Controls.Add(txb_ReqSalesOfficeName);
            Controls.Add(lbl_ReqSalesOfficeName);
            Controls.Add(btn_ReqFirstPage);
            Controls.Add(btn_ReqChangeSize);
            Controls.Add(txb_ReqPageSize);
            Controls.Add(lbl_ReqPageSize);
            Controls.Add(btn_ReqHiddenReason);
            Controls.Add(lbl_ReqPage);
            Controls.Add(txb_ReqPage);
            Controls.Add(btn_ReqLastPage);
            Controls.Add(btn_ReqPrevPage);
            Controls.Add(btn_ReqNextPage);
            Controls.Add(lbl_RequestDate);
            Controls.Add(lbl_Requestkengenmei);
            Controls.Add(lbl_RequestLoginuser);
            Controls.Add(lbl_ReqProductcnt);
            Controls.Add(txb_ReqProductcnt);
            Controls.Add(lbl_ReqProductID);
            Controls.Add(txb_ReqProductID);
            Controls.Add(lbl_ReqDetailID);
            Controls.Add(txb_ReqDetailID);
            Controls.Add(lbl_ReqHidden);
            Controls.Add(CheckBox_ReqHidden);
            Controls.Add(dtp_ReqDate);
            Controls.Add(lbl_ReqDate);
            Controls.Add(lbl_ReqJOrderID);
            Controls.Add(txb_ReqJOrderID);
            Controls.Add(lbl_ReqCstmrID);
            Controls.Add(txb_ReqCstmrID);
            Controls.Add(lbl_ReqEmpID);
            Controls.Add(txb_ReqEmpID);
            Controls.Add(lbl_ReqSalesOfficeID);
            Controls.Add(txb_ReqSalesOfficeID);
            Controls.Add(lbl_ReqRequestID);
            Controls.Add(txb_ReqRequestID);
            Controls.Add(btn_ReqConfirm);
            Controls.Add(btn_ReqHidden);
            Controls.Add(btn_ReqSearch);
            Controls.Add(btn_ReqShowList);
            Controls.Add(btn_ReqBack);
            Controls.Add(lbl_ReqSelectForm);
            Controls.Add(btn_ReqFormShow);
            Controls.Add(cmb_ReqSelectForm);
            Controls.Add(dataGrid_Request);
            Name = "F_Request";
            Text = "販売管理システム注文画面";
            Load += F_Request_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Request).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGrid_Request;
        private Label lbl_ReqSelectForm;
        private Button btn_ReqFormShow;
        private ComboBox cmb_ReqSelectForm;
        private Button btn_ReqBack;
        private Button btn_ReqConfirm;
        private Button btn_ReqHidden;
        private Button btn_ReqSearch;
        private Button btn_ReqShowList;
        private Label lbl_ReqRequestID;
        private TextBox txb_ReqRequestID;
        private Label lbl_ReqSalesOfficeID;
        private TextBox txb_ReqSalesOfficeID;
        private Label lbl_ReqEmpID;
        private TextBox txb_ReqEmpID;
        private Label lbl_ReqCstmrID;
        private TextBox txb_ReqCstmrID;
        private Label lbl_ReqDate;
        private Label lbl_ReqJOrderID;
        private TextBox txb_ReqJOrderID;
        private DateTimePicker dtp_ReqDate;
        private Label lbl_ReqHidden;
        private CheckBox CheckBox_ReqHidden;
        private Label lbl_ReqProductID;
        private TextBox txb_ReqProductID;
        private Label lbl_ReqDetailID;
        private TextBox txb_ReqDetailID;
        private Label lbl_ReqProductcnt;
        private TextBox txb_ReqProductcnt;
        private Label lbl_RequestDate;
        private Label lbl_Requestkengenmei;
        private Label lbl_RequestLoginuser;
        private Label lbl_ReqPage;
        private TextBox txb_ReqPage;
        private Button btn_ReqLastPage;
        private Button btn_ReqPrevPage;
        private Button btn_ReqNextPage;
        private Button btn_ReqHiddenReason;
        private Button btn_ReqChangeSize;
        private TextBox txb_ReqPageSize;
        private Label lbl_ReqPageSize;
        private Button btn_ReqFirstPage;
        private TextBox txb_ReqSalesOfficeName;
        private Label lbl_ReqSalesOfficeName;
        private TextBox txb_ReqEmpName;
        private Label lbl_ReqEmpName;
        private TextBox txb_ReqCstmrName;
        private Label lbl_ReqCstmrName;
        private TextBox txb_ReqProductName;
        private Label lbl_ReqProductName;
        private TextBox txb_ReqTotalPrice;
        private Label lbl_ReqTotalaPrice;
        private TextBox txb_ReqPrice;
        private Label lbl_ReqPrice;
        private Button btn_ReqInputClear;
        private Button btn_ReqShowDetail;
    }
}