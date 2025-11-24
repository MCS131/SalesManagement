namespace SalesManagement_SysDev
{
    partial class F_Shipgoods
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
            btn_ShgBack = new Button();
            btn_ShgSearch = new Button();
            btn_ShgHidden = new Button();
            btn_ShgShowList = new Button();
            txb_ShgSalesOfficeID = new TextBox();
            txb_ShgCstmrID = new TextBox();
            lbl_ShgJOrderID = new Label();
            lbl_ShgSalesOffice = new Label();
            txb_ShgJOrderID = new TextBox();
            txb_ShgEmpID = new TextBox();
            txb_ShgShipID = new TextBox();
            lbl_ShgEmpID = new Label();
            lbl_ShgCstmrID = new Label();
            lbl_ShgShipDate = new Label();
            lbl_ShgShipID = new Label();
            dataGrid_Shg = new DataGridView();
            lbl_ShgDate = new Label();
            lbl_Shgkengenmei = new Label();
            lbl_ShgLoginuser = new Label();
            btn_ShgConfirm = new Button();
            dtp_ShgDate = new DateTimePicker();
            lbl_ShgSelectForm = new Label();
            btn_ShgFormShow = new Button();
            cmb_ShgSelectForm = new ComboBox();
            lbl_ShgHidden = new Label();
            CheckBox_ShgHidden = new CheckBox();
            lbl_ShgPage = new Label();
            btn_ShgLastPage = new Button();
            btn_ShgPrevPage = new Button();
            btn_ShgNextPage = new Button();
            btn_ShgHiddenReason = new Button();
            btn_ShgChangeSize = new Button();
            txb_ShgPageSize = new TextBox();
            lbl_ShgPageSize = new Label();
            btn_ShgFirstPage = new Button();
            txb_ShgPage = new TextBox();
            lbl_ShgProductcnt = new Label();
            txb_ShgProductcnt = new TextBox();
            btn_ShgShowDetail = new Button();
            txb_ShgProductName = new TextBox();
            lbl_ShgProductName = new Label();
            lbl_ShgProductID = new Label();
            txb_ShgProductID = new TextBox();
            lbl_ShipDetailID = new Label();
            txb_ShgDetailID = new TextBox();
            txb_ShgSalesOfficeName = new TextBox();
            lbl_ShgSalesOfficeName = new Label();
            txb_ShgCstmrName = new TextBox();
            lbl_ShgCstmrName = new Label();
            txb_ShgEmpName = new TextBox();
            lbl_ShgEmpName = new Label();
            btn_ShgInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Shg).BeginInit();
            SuspendLayout();
            // 
            // btn_ShgBack
            // 
            btn_ShgBack.BackColor = Color.Gold;
            btn_ShgBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ShgBack.Location = new Point(1686, 26);
            btn_ShgBack.Margin = new Padding(2);
            btn_ShgBack.Name = "btn_ShgBack";
            btn_ShgBack.Size = new Size(192, 86);
            btn_ShgBack.TabIndex = 51;
            btn_ShgBack.Text = "戻る";
            btn_ShgBack.UseVisualStyleBackColor = false;
            btn_ShgBack.Click += btn_ShipgoodsBack_Click;
            // 
            // btn_ShgSearch
            // 
            btn_ShgSearch.BackColor = Color.Khaki;
            btn_ShgSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgSearch.Location = new Point(731, 114);
            btn_ShgSearch.Margin = new Padding(2);
            btn_ShgSearch.Name = "btn_ShgSearch";
            btn_ShgSearch.Size = new Size(185, 100);
            btn_ShgSearch.TabIndex = 45;
            btn_ShgSearch.Text = "検索";
            btn_ShgSearch.UseVisualStyleBackColor = false;
            btn_ShgSearch.Click += btn_ShgSearch_Click;
            // 
            // btn_ShgHidden
            // 
            btn_ShgHidden.BackColor = Color.Khaki;
            btn_ShgHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgHidden.Location = new Point(989, 114);
            btn_ShgHidden.Margin = new Padding(2);
            btn_ShgHidden.Name = "btn_ShgHidden";
            btn_ShgHidden.Size = new Size(185, 100);
            btn_ShgHidden.TabIndex = 133;
            btn_ShgHidden.Text = "非表示更新";
            btn_ShgHidden.UseVisualStyleBackColor = false;
            btn_ShgHidden.Click += btn_ShgHidden_Click;
            // 
            // btn_ShgShowList
            // 
            btn_ShgShowList.BackColor = Color.Khaki;
            btn_ShgShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgShowList.Location = new Point(474, 114);
            btn_ShgShowList.Margin = new Padding(2);
            btn_ShgShowList.Name = "btn_ShgShowList";
            btn_ShgShowList.Size = new Size(185, 100);
            btn_ShgShowList.TabIndex = 43;
            btn_ShgShowList.Text = "一覧表示";
            btn_ShgShowList.UseVisualStyleBackColor = false;
            btn_ShgShowList.Click += btn_ShgShowList_Click;
            // 
            // txb_ShgSalesOfficeID
            // 
            txb_ShgSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgSalesOfficeID.Location = new Point(503, 329);
            txb_ShgSalesOfficeID.Margin = new Padding(2);
            txb_ShgSalesOfficeID.Name = "txb_ShgSalesOfficeID";
            txb_ShgSalesOfficeID.Size = new Size(91, 39);
            txb_ShgSalesOfficeID.TabIndex = 42;
            txb_ShgSalesOfficeID.TextChanged += txb_ShgSalesOfficeID_TextChanged;
            // 
            // txb_ShgCstmrID
            // 
            txb_ShgCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgCstmrID.Location = new Point(502, 377);
            txb_ShgCstmrID.Margin = new Padding(2);
            txb_ShgCstmrID.Name = "txb_ShgCstmrID";
            txb_ShgCstmrID.Size = new Size(92, 39);
            txb_ShgCstmrID.TabIndex = 41;
            txb_ShgCstmrID.TextChanged += txb_ShgCstmrID_TextChanged;
            // 
            // lbl_ShgJOrderID
            // 
            lbl_ShgJOrderID.AutoSize = true;
            lbl_ShgJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgJOrderID.Location = new Point(635, 236);
            lbl_ShgJOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgJOrderID.Name = "lbl_ShgJOrderID";
            lbl_ShgJOrderID.Size = new Size(85, 32);
            lbl_ShgJOrderID.TabIndex = 40;
            lbl_ShgJOrderID.Text = "受注ID";
            // 
            // lbl_ShgSalesOffice
            // 
            lbl_ShgSalesOffice.AutoSize = true;
            lbl_ShgSalesOffice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgSalesOffice.Location = new Point(377, 331);
            lbl_ShgSalesOffice.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgSalesOffice.Name = "lbl_ShgSalesOffice";
            lbl_ShgSalesOffice.Size = new Size(109, 32);
            lbl_ShgSalesOffice.TabIndex = 39;
            lbl_ShgSalesOffice.Text = "営業所ID";
            // 
            // txb_ShgJOrderID
            // 
            txb_ShgJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgJOrderID.Location = new Point(731, 233);
            txb_ShgJOrderID.Margin = new Padding(2);
            txb_ShgJOrderID.Name = "txb_ShgJOrderID";
            txb_ShgJOrderID.Size = new Size(91, 39);
            txb_ShgJOrderID.TabIndex = 38;
            // 
            // txb_ShgEmpID
            // 
            txb_ShgEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgEmpID.Location = new Point(503, 282);
            txb_ShgEmpID.Margin = new Padding(2);
            txb_ShgEmpID.Name = "txb_ShgEmpID";
            txb_ShgEmpID.Size = new Size(91, 39);
            txb_ShgEmpID.TabIndex = 36;
            txb_ShgEmpID.TextChanged += txb_ShgEmpID_TextChanged;
            // 
            // txb_ShgShipID
            // 
            txb_ShgShipID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgShipID.Location = new Point(503, 235);
            txb_ShgShipID.Margin = new Padding(2);
            txb_ShgShipID.Name = "txb_ShgShipID";
            txb_ShgShipID.Size = new Size(91, 39);
            txb_ShgShipID.TabIndex = 35;
            // 
            // lbl_ShgEmpID
            // 
            lbl_ShgEmpID.AutoSize = true;
            lbl_ShgEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgEmpID.Location = new Point(401, 282);
            lbl_ShgEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgEmpID.Name = "lbl_ShgEmpID";
            lbl_ShgEmpID.Size = new Size(85, 32);
            lbl_ShgEmpID.TabIndex = 34;
            lbl_ShgEmpID.Text = "社員ID";
            // 
            // lbl_ShgCstmrID
            // 
            lbl_ShgCstmrID.AutoSize = true;
            lbl_ShgCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgCstmrID.Location = new Point(401, 383);
            lbl_ShgCstmrID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgCstmrID.Name = "lbl_ShgCstmrID";
            lbl_ShgCstmrID.Size = new Size(85, 32);
            lbl_ShgCstmrID.TabIndex = 33;
            lbl_ShgCstmrID.Text = "顧客ID";
            // 
            // lbl_ShgShipDate
            // 
            lbl_ShgShipDate.AutoSize = true;
            lbl_ShgShipDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgShipDate.Location = new Point(877, 236);
            lbl_ShgShipDate.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgShipDate.Name = "lbl_ShgShipDate";
            lbl_ShgShipDate.Size = new Size(182, 32);
            lbl_ShgShipDate.TabIndex = 31;
            lbl_ShgShipDate.Text = "出荷完了年月日";
            // 
            // lbl_ShgShipID
            // 
            lbl_ShgShipID.AutoSize = true;
            lbl_ShgShipID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgShipID.Location = new Point(401, 238);
            lbl_ShgShipID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgShipID.Name = "lbl_ShgShipID";
            lbl_ShgShipID.Size = new Size(85, 32);
            lbl_ShgShipID.TabIndex = 29;
            lbl_ShgShipID.Text = "出荷ID";
            // 
            // dataGrid_Shg
            // 
            dataGrid_Shg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Shg.Location = new Point(11, 473);
            dataGrid_Shg.Margin = new Padding(2);
            dataGrid_Shg.Name = "dataGrid_Shg";
            dataGrid_Shg.RowHeadersWidth = 62;
            dataGrid_Shg.RowTemplate.Height = 33;
            dataGrid_Shg.Size = new Size(1882, 520);
            dataGrid_Shg.TabIndex = 54;
            dataGrid_Shg.CellClick += dataGrid_Shg_CellClick;
            // 
            // lbl_ShgDate
            // 
            lbl_ShgDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShgDate.Location = new Point(1121, 43);
            lbl_ShgDate.Name = "lbl_ShgDate";
            lbl_ShgDate.Size = new Size(354, 33);
            lbl_ShgDate.TabIndex = 131;
            lbl_ShgDate.Text = "日付：";
            lbl_ShgDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Shgkengenmei
            // 
            lbl_Shgkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Shgkengenmei.Location = new Point(791, 43);
            lbl_Shgkengenmei.Name = "lbl_Shgkengenmei";
            lbl_Shgkengenmei.Size = new Size(324, 33);
            lbl_Shgkengenmei.TabIndex = 130;
            lbl_Shgkengenmei.Text = "権限名：";
            lbl_Shgkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ShgLoginuser
            // 
            lbl_ShgLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShgLoginuser.Location = new Point(401, 43);
            lbl_ShgLoginuser.Name = "lbl_ShgLoginuser";
            lbl_ShgLoginuser.Size = new Size(384, 33);
            lbl_ShgLoginuser.TabIndex = 129;
            lbl_ShgLoginuser.Text = "ログインユーザー：";
            lbl_ShgLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_ShgConfirm
            // 
            btn_ShgConfirm.BackColor = Color.Khaki;
            btn_ShgConfirm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgConfirm.Location = new Point(1247, 114);
            btn_ShgConfirm.Margin = new Padding(2);
            btn_ShgConfirm.Name = "btn_ShgConfirm";
            btn_ShgConfirm.Size = new Size(185, 100);
            btn_ShgConfirm.TabIndex = 132;
            btn_ShgConfirm.Text = "出荷確定";
            btn_ShgConfirm.UseVisualStyleBackColor = false;
            btn_ShgConfirm.Click += btn_ShgConfirm_Click;
            // 
            // dtp_ShgDate
            // 
            dtp_ShgDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_ShgDate.Location = new Point(1063, 233);
            dtp_ShgDate.Margin = new Padding(2);
            dtp_ShgDate.Name = "dtp_ShgDate";
            dtp_ShgDate.Size = new Size(247, 39);
            dtp_ShgDate.TabIndex = 134;
            // 
            // lbl_ShgSelectForm
            // 
            lbl_ShgSelectForm.AutoSize = true;
            lbl_ShgSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgSelectForm.Location = new Point(33, 31);
            lbl_ShgSelectForm.Name = "lbl_ShgSelectForm";
            lbl_ShgSelectForm.Size = new Size(227, 32);
            lbl_ShgSelectForm.TabIndex = 137;
            lbl_ShgSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_ShgFormShow
            // 
            btn_ShgFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgFormShow.Location = new Point(49, 112);
            btn_ShgFormShow.Name = "btn_ShgFormShow";
            btn_ShgFormShow.Size = new Size(192, 42);
            btn_ShgFormShow.TabIndex = 136;
            btn_ShgFormShow.Text = "表示";
            btn_ShgFormShow.UseVisualStyleBackColor = true;
            btn_ShgFormShow.Click += btn_ShipgoodsFormShow_Click;
            // 
            // cmb_ShgSelectForm
            // 
            cmb_ShgSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_ShgSelectForm.FormattingEnabled = true;
            cmb_ShgSelectForm.Items.AddRange(new object[] { "顧客管理画面", "注文管理画面", "入荷管理画面", "出荷管理画面", "売上管理画面" });
            cmb_ShgSelectForm.Location = new Point(33, 66);
            cmb_ShgSelectForm.Name = "cmb_ShgSelectForm";
            cmb_ShgSelectForm.Size = new Size(227, 40);
            cmb_ShgSelectForm.TabIndex = 135;
            // 
            // lbl_ShgHidden
            // 
            lbl_ShgHidden.AutoSize = true;
            lbl_ShgHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgHidden.Location = new Point(12, 433);
            lbl_ShgHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgHidden.Name = "lbl_ShgHidden";
            lbl_ShgHidden.Size = new Size(86, 32);
            lbl_ShgHidden.TabIndex = 138;
            lbl_ShgHidden.Text = "非表示";
            // 
            // CheckBox_ShgHidden
            // 
            CheckBox_ShgHidden.AutoSize = true;
            CheckBox_ShgHidden.BackColor = Color.Transparent;
            CheckBox_ShgHidden.Location = new Point(98, 444);
            CheckBox_ShgHidden.Name = "CheckBox_ShgHidden";
            CheckBox_ShgHidden.Size = new Size(15, 14);
            CheckBox_ShgHidden.TabIndex = 140;
            CheckBox_ShgHidden.UseVisualStyleBackColor = false;
            // 
            // lbl_ShgPage
            // 
            lbl_ShgPage.AutoSize = true;
            lbl_ShgPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgPage.Location = new Point(1666, 1003);
            lbl_ShgPage.Name = "lbl_ShgPage";
            lbl_ShgPage.Size = new Size(46, 21);
            lbl_ShgPage.TabIndex = 157;
            lbl_ShgPage.Text = "ページ";
            // 
            // btn_ShgLastPage
            // 
            btn_ShgLastPage.Location = new Point(1855, 998);
            btn_ShgLastPage.Name = "btn_ShgLastPage";
            btn_ShgLastPage.Size = new Size(38, 31);
            btn_ShgLastPage.TabIndex = 155;
            btn_ShgLastPage.Text = "➜";
            btn_ShgLastPage.UseVisualStyleBackColor = true;
            btn_ShgLastPage.Click += btn_ShgLastPage_Click;
            // 
            // btn_ShgPrevPage
            // 
            btn_ShgPrevPage.Location = new Point(1775, 998);
            btn_ShgPrevPage.Name = "btn_ShgPrevPage";
            btn_ShgPrevPage.Size = new Size(38, 31);
            btn_ShgPrevPage.TabIndex = 154;
            btn_ShgPrevPage.Text = "◀️";
            btn_ShgPrevPage.UseVisualStyleBackColor = true;
            btn_ShgPrevPage.Click += btn_ShgPrevPage_Click;
            // 
            // btn_ShgNextPage
            // 
            btn_ShgNextPage.Location = new Point(1815, 998);
            btn_ShgNextPage.Name = "btn_ShgNextPage";
            btn_ShgNextPage.Size = new Size(38, 31);
            btn_ShgNextPage.TabIndex = 153;
            btn_ShgNextPage.Text = "▶️";
            btn_ShgNextPage.UseVisualStyleBackColor = true;
            btn_ShgNextPage.Click += btn_ShgNextPage_Click;
            // 
            // btn_ShgHiddenReason
            // 
            btn_ShgHiddenReason.BackColor = Color.PeachPuff;
            btn_ShgHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgHiddenReason.Location = new Point(127, 430);
            btn_ShgHiddenReason.Name = "btn_ShgHiddenReason";
            btn_ShgHiddenReason.Size = new Size(153, 36);
            btn_ShgHiddenReason.TabIndex = 158;
            btn_ShgHiddenReason.Text = "非表示理由";
            btn_ShgHiddenReason.UseVisualStyleBackColor = false;
            btn_ShgHiddenReason.Click += btn_ShgHiddenReason_Click;
            // 
            // btn_ShgChangeSize
            // 
            btn_ShgChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgChangeSize.Location = new Point(171, 1008);
            btn_ShgChangeSize.Name = "btn_ShgChangeSize";
            btn_ShgChangeSize.Size = new Size(99, 26);
            btn_ShgChangeSize.TabIndex = 162;
            btn_ShgChangeSize.Text = "行数変更";
            btn_ShgChangeSize.UseVisualStyleBackColor = true;
            btn_ShgChangeSize.Click += btn_ShgChangeSize_Click;
            // 
            // txb_ShgPageSize
            // 
            txb_ShgPageSize.Location = new Point(105, 1008);
            txb_ShgPageSize.Name = "txb_ShgPageSize";
            txb_ShgPageSize.Size = new Size(51, 23);
            txb_ShgPageSize.TabIndex = 161;
            // 
            // lbl_ShgPageSize
            // 
            lbl_ShgPageSize.AutoSize = true;
            lbl_ShgPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgPageSize.Location = new Point(12, 1008);
            lbl_ShgPageSize.Name = "lbl_ShgPageSize";
            lbl_ShgPageSize.Size = new Size(87, 21);
            lbl_ShgPageSize.TabIndex = 160;
            lbl_ShgPageSize.Text = "1ページ行数";
            // 
            // btn_ShgFirstPage
            // 
            btn_ShgFirstPage.Location = new Point(1734, 998);
            btn_ShgFirstPage.Name = "btn_ShgFirstPage";
            btn_ShgFirstPage.Size = new Size(38, 31);
            btn_ShgFirstPage.TabIndex = 163;
            btn_ShgFirstPage.Text = "|";
            btn_ShgFirstPage.UseVisualStyleBackColor = true;
            btn_ShgFirstPage.Click += btn_ShgFirstPage_Click;
            // 
            // txb_ShgPage
            // 
            txb_ShgPage.Location = new Point(1609, 1003);
            txb_ShgPage.Name = "txb_ShgPage";
            txb_ShgPage.Size = new Size(51, 23);
            txb_ShgPage.TabIndex = 164;
            // 
            // lbl_ShgProductcnt
            // 
            lbl_ShgProductcnt.AutoSize = true;
            lbl_ShgProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgProductcnt.Location = new Point(1227, 428);
            lbl_ShgProductcnt.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgProductcnt.Name = "lbl_ShgProductcnt";
            lbl_ShgProductcnt.Size = new Size(62, 32);
            lbl_ShgProductcnt.TabIndex = 202;
            lbl_ShgProductcnt.Text = "数量";
            // 
            // txb_ShgProductcnt
            // 
            txb_ShgProductcnt.Enabled = false;
            txb_ShgProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgProductcnt.Location = new Point(1293, 423);
            txb_ShgProductcnt.Margin = new Padding(2);
            txb_ShgProductcnt.Name = "txb_ShgProductcnt";
            txb_ShgProductcnt.Size = new Size(140, 39);
            txb_ShgProductcnt.TabIndex = 201;
            // 
            // btn_ShgShowDetail
            // 
            btn_ShgShowDetail.Location = new Point(575, 428);
            btn_ShgShowDetail.Name = "btn_ShgShowDetail";
            btn_ShgShowDetail.Size = new Size(97, 36);
            btn_ShgShowDetail.TabIndex = 200;
            btn_ShgShowDetail.Text = "出庫詳細一覧";
            btn_ShgShowDetail.UseVisualStyleBackColor = true;
            btn_ShgShowDetail.Click += btn_ShgShowDetail_Click;
            // 
            // txb_ShgProductName
            // 
            txb_ShgProductName.Enabled = false;
            txb_ShgProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgProductName.Location = new Point(1024, 423);
            txb_ShgProductName.Margin = new Padding(2);
            txb_ShgProductName.Name = "txb_ShgProductName";
            txb_ShgProductName.Size = new Size(178, 39);
            txb_ShgProductName.TabIndex = 199;
            // 
            // lbl_ShgProductName
            // 
            lbl_ShgProductName.AutoSize = true;
            lbl_ShgProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgProductName.Location = new Point(934, 428);
            lbl_ShgProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgProductName.Name = "lbl_ShgProductName";
            lbl_ShgProductName.Size = new Size(86, 32);
            lbl_ShgProductName.TabIndex = 198;
            lbl_ShgProductName.Text = "商品名";
            // 
            // lbl_ShgProductID
            // 
            lbl_ShgProductID.AutoSize = true;
            lbl_ShgProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgProductID.Location = new Point(677, 428);
            lbl_ShgProductID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgProductID.Name = "lbl_ShgProductID";
            lbl_ShgProductID.Size = new Size(85, 32);
            lbl_ShgProductID.TabIndex = 197;
            lbl_ShgProductID.Text = "商品ID";
            // 
            // txb_ShgProductID
            // 
            txb_ShgProductID.Enabled = false;
            txb_ShgProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgProductID.Location = new Point(767, 424);
            txb_ShgProductID.Margin = new Padding(2);
            txb_ShgProductID.Name = "txb_ShgProductID";
            txb_ShgProductID.Size = new Size(149, 39);
            txb_ShgProductID.TabIndex = 196;
            // 
            // lbl_ShipDetailID
            // 
            lbl_ShipDetailID.AutoSize = true;
            lbl_ShipDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipDetailID.Location = new Point(353, 430);
            lbl_ShipDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipDetailID.Name = "lbl_ShipDetailID";
            lbl_ShipDetailID.Size = new Size(133, 32);
            lbl_ShipDetailID.TabIndex = 195;
            lbl_ShipDetailID.Text = "出荷詳細ID";
            // 
            // txb_ShgDetailID
            // 
            txb_ShgDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgDetailID.Location = new Point(502, 425);
            txb_ShgDetailID.Margin = new Padding(2);
            txb_ShgDetailID.Name = "txb_ShgDetailID";
            txb_ShgDetailID.Size = new Size(68, 39);
            txb_ShgDetailID.TabIndex = 194;
            txb_ShgDetailID.TextChanged += txb_ShgDetailID_TextChanged;
            // 
            // txb_ShgSalesOfficeName
            // 
            txb_ShgSalesOfficeName.Enabled = false;
            txb_ShgSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgSalesOfficeName.Location = new Point(733, 328);
            txb_ShgSalesOfficeName.Margin = new Padding(2);
            txb_ShgSalesOfficeName.Name = "txb_ShgSalesOfficeName";
            txb_ShgSalesOfficeName.Size = new Size(268, 39);
            txb_ShgSalesOfficeName.TabIndex = 207;
            // 
            // lbl_ShgSalesOfficeName
            // 
            lbl_ShgSalesOfficeName.AutoSize = true;
            lbl_ShgSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgSalesOfficeName.Location = new Point(606, 335);
            lbl_ShgSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgSalesOfficeName.Name = "lbl_ShgSalesOfficeName";
            lbl_ShgSalesOfficeName.Size = new Size(110, 32);
            lbl_ShgSalesOfficeName.TabIndex = 208;
            lbl_ShgSalesOfficeName.Text = "営業所名";
            // 
            // txb_ShgCstmrName
            // 
            txb_ShgCstmrName.Enabled = false;
            txb_ShgCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgCstmrName.Location = new Point(733, 378);
            txb_ShgCstmrName.Margin = new Padding(2);
            txb_ShgCstmrName.Name = "txb_ShgCstmrName";
            txb_ShgCstmrName.Size = new Size(475, 39);
            txb_ShgCstmrName.TabIndex = 206;
            // 
            // lbl_ShgCstmrName
            // 
            lbl_ShgCstmrName.AutoSize = true;
            lbl_ShgCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgCstmrName.Location = new Point(630, 383);
            lbl_ShgCstmrName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgCstmrName.Name = "lbl_ShgCstmrName";
            lbl_ShgCstmrName.Size = new Size(86, 32);
            lbl_ShgCstmrName.TabIndex = 205;
            lbl_ShgCstmrName.Text = "顧客名";
            // 
            // txb_ShgEmpName
            // 
            txb_ShgEmpName.Enabled = false;
            txb_ShgEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShgEmpName.Location = new Point(733, 279);
            txb_ShgEmpName.Margin = new Padding(2);
            txb_ShgEmpName.Name = "txb_ShgEmpName";
            txb_ShgEmpName.Size = new Size(268, 39);
            txb_ShgEmpName.TabIndex = 204;
            // 
            // lbl_ShgEmpName
            // 
            lbl_ShgEmpName.AutoSize = true;
            lbl_ShgEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShgEmpName.Location = new Point(630, 282);
            lbl_ShgEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShgEmpName.Name = "lbl_ShgEmpName";
            lbl_ShgEmpName.Size = new Size(86, 32);
            lbl_ShgEmpName.TabIndex = 203;
            lbl_ShgEmpName.Text = "社員名";
            // 
            // btn_ShgInputClear
            // 
            btn_ShgInputClear.BackColor = Color.PeachPuff;
            btn_ShgInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShgInputClear.Location = new Point(1725, 398);
            btn_ShgInputClear.Name = "btn_ShgInputClear";
            btn_ShgInputClear.Size = new Size(153, 60);
            btn_ShgInputClear.TabIndex = 209;
            btn_ShgInputClear.Text = "入力クリア";
            btn_ShgInputClear.UseVisualStyleBackColor = false;
            btn_ShgInputClear.Click += btn_ShgInputClear_Click;
            // 
            // F_Shipgoods
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_ShgInputClear);
            Controls.Add(txb_ShgSalesOfficeName);
            Controls.Add(lbl_ShgSalesOfficeName);
            Controls.Add(txb_ShgCstmrName);
            Controls.Add(lbl_ShgCstmrName);
            Controls.Add(txb_ShgEmpName);
            Controls.Add(lbl_ShgEmpName);
            Controls.Add(lbl_ShgProductcnt);
            Controls.Add(txb_ShgProductcnt);
            Controls.Add(btn_ShgShowDetail);
            Controls.Add(txb_ShgProductName);
            Controls.Add(lbl_ShgProductName);
            Controls.Add(lbl_ShgProductID);
            Controls.Add(txb_ShgProductID);
            Controls.Add(lbl_ShipDetailID);
            Controls.Add(txb_ShgDetailID);
            Controls.Add(txb_ShgPage);
            Controls.Add(btn_ShgFirstPage);
            Controls.Add(btn_ShgChangeSize);
            Controls.Add(txb_ShgPageSize);
            Controls.Add(lbl_ShgPageSize);
            Controls.Add(btn_ShgHiddenReason);
            Controls.Add(lbl_ShgPage);
            Controls.Add(btn_ShgLastPage);
            Controls.Add(btn_ShgPrevPage);
            Controls.Add(btn_ShgNextPage);
            Controls.Add(CheckBox_ShgHidden);
            Controls.Add(lbl_ShgHidden);
            Controls.Add(lbl_ShgSelectForm);
            Controls.Add(btn_ShgFormShow);
            Controls.Add(cmb_ShgSelectForm);
            Controls.Add(dtp_ShgDate);
            Controls.Add(btn_ShgConfirm);
            Controls.Add(btn_ShgHidden);
            Controls.Add(lbl_ShgDate);
            Controls.Add(lbl_Shgkengenmei);
            Controls.Add(lbl_ShgLoginuser);
            Controls.Add(dataGrid_Shg);
            Controls.Add(btn_ShgBack);
            Controls.Add(btn_ShgSearch);
            Controls.Add(btn_ShgShowList);
            Controls.Add(txb_ShgSalesOfficeID);
            Controls.Add(txb_ShgCstmrID);
            Controls.Add(lbl_ShgJOrderID);
            Controls.Add(lbl_ShgSalesOffice);
            Controls.Add(txb_ShgJOrderID);
            Controls.Add(txb_ShgEmpID);
            Controls.Add(txb_ShgShipID);
            Controls.Add(lbl_ShgEmpID);
            Controls.Add(lbl_ShgCstmrID);
            Controls.Add(lbl_ShgShipDate);
            Controls.Add(lbl_ShgShipID);
            Margin = new Padding(2);
            Name = "F_Shipgoods";
            Text = "販売管理システム出荷画面";
            Load += F_Shipgoods_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Shg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_ShgBack;
        private Button btn_ShgSearch;
        private Button btn_ShgHidden;
        private Button btn_ShgShowList;
        private TextBox txb_ShgSalesOfficeID;
        private TextBox txb_ShgCstmrID;
        private Label lbl_ShgJOrderID;
        private Label lbl_ShgSalesOffice;
        private TextBox txb_ShgJOrderID;
        private TextBox txb_ShgEmpID;
        private TextBox txb_ShgShipID;
        private Label lbl_ShgEmpID;
        private Label lbl_ShgCstmrID;
        private Label lbl_ShgShipDate;
        private Label lbl_ShgShipID;
        private DataGridView dataGrid_Shg;
        private Label lbl_ShgDate;
        private Label lbl_Shgkengenmei;
        private Label lbl_ShgLoginuser;
        private Button btn_ShgConfirm;
        private DateTimePicker dtp_ShgDate;
        private Label lbl_ShgSelectForm;
        private Button btn_ShgFormShow;
        private ComboBox cmb_ShgSelectForm;
        private Label lbl_ShgHidden;
        private CheckBox CheckBox_ShgHidden;
        private Label lbl_ShgPage;
        private Button btn_ShgLastPage;
        private Button btn_ShgPrevPage;
        private Button btn_ShgNextPage;
        private Button btn_ShgHiddenReason;
        private Button btn_ShgChangeSize;
        private TextBox txb_ShgPageSize;
        private Label lbl_ShgPageSize;
        private Button btn_ShgFirstPage;
        private TextBox txb_ShgPage;
        private Label lbl_ShgProductcnt;
        private TextBox txb_ShgProductcnt;
        private Button btn_ShgShowDetail;
        private TextBox txb_ShgProductName;
        private Label lbl_ShgProductName;
        private Label lbl_ShgProductID;
        private TextBox txb_ShgProductID;
        private Label lbl_ShipDetailID;
        private TextBox txb_ShgDetailID;
        private TextBox txb_ShgSalesOfficeName;
        private Label lbl_ShgSalesOfficeName;
        private TextBox txb_ShgCstmrName;
        private Label lbl_ShgCstmrName;
        private TextBox txb_ShgEmpName;
        private Label lbl_ShgEmpName;
        private Button btn_ShgInputClear;
    }
}