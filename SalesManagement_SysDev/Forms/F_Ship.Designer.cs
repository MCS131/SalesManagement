namespace SalesManagement_SysDev
{
    partial class F_Ship
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
            dataGrid_Ship = new DataGridView();
            btn_ShipSearch = new Button();
            btn_ShipShowList = new Button();
            txb_ShipEmpId = new TextBox();
            txb_ShipSalesOffice = new TextBox();
            lbl_ShipSalesOffice = new Label();
            txb_ShipJOrderID = new TextBox();
            txb_ShipCstmrID = new TextBox();
            lbl_ShipEmpId = new Label();
            lbl_ShipJOrderID = new Label();
            lbl_ShipShipDate = new Label();
            lbl_ShipCstmrID = new Label();
            btn_ShipConfirm = new Button();
            txb_ShipShipID = new TextBox();
            lbl_ShipShipID = new Label();
            dtp_ShipDate = new DateTimePicker();
            CheckBox_ShipHidden = new CheckBox();
            lbl_ShipHidden = new Label();
            lbl_ShipSelectForm = new Label();
            btn_ShipFormShow = new Button();
            cmb_ShipSelectForm = new ComboBox();
            btn_ShipBack = new Button();
            lbl_ShipDate = new Label();
            lbl_Shipkengenmei = new Label();
            lbl_ShipLoginuser = new Label();
            btn_ShipHiddenReason = new Button();
            lbl_ShipPage = new Label();
            txb_ShipPage = new TextBox();
            btn_ShipLastPage = new Button();
            btn_ShipPrevPage = new Button();
            btn_ShipNextPage = new Button();
            btn_ShipChangeSize = new Button();
            txb_ShipPageSize = new TextBox();
            lbl_ShipPageSize = new Label();
            btn_ShipPage = new Button();
            txb_ShipEmpName = new TextBox();
            lbl_ShipEmpName = new Label();
            txb_ShipCstmrName = new TextBox();
            lbl_ShipCstmrName = new Label();
            txb_ShipSalesOfficeName = new TextBox();
            lbl_ShipSalesOfficeName = new Label();
            btn_ShipInputClear = new Button();
            btn_ShipShowDetail = new Button();
            txb_ShipProductName = new TextBox();
            lbl_ShipProductName = new Label();
            lbl_ShipProductID = new Label();
            txb_ShipProductID = new TextBox();
            lbl_ShipDetailID = new Label();
            txb_ShipDetailID = new TextBox();
            lbl_ShipProductcnt = new Label();
            txb_ShipProductcnt = new TextBox();
            btn_ShipHidden = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Ship).BeginInit();
            SuspendLayout();
            // 
            // dataGrid_Ship
            // 
            dataGrid_Ship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Ship.Location = new Point(12, 472);
            dataGrid_Ship.Name = "dataGrid_Ship";
            dataGrid_Ship.RowHeadersWidth = 62;
            dataGrid_Ship.RowTemplate.Height = 33;
            dataGrid_Ship.Size = new Size(1882, 520);
            dataGrid_Ship.TabIndex = 53;
            dataGrid_Ship.CellClick += dataGrid_Ship_CellClick;
            // 
            // btn_ShipSearch
            // 
            btn_ShipSearch.BackColor = Color.Khaki;
            btn_ShipSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipSearch.Location = new Point(764, 110);
            btn_ShipSearch.Margin = new Padding(2);
            btn_ShipSearch.Name = "btn_ShipSearch";
            btn_ShipSearch.Size = new Size(185, 100);
            btn_ShipSearch.TabIndex = 55;
            btn_ShipSearch.Text = "検索";
            btn_ShipSearch.UseVisualStyleBackColor = false;
            btn_ShipSearch.Click += btn_ShipSearch_Click;
            // 
            // btn_ShipShowList
            // 
            btn_ShipShowList.BackColor = Color.Khaki;
            btn_ShipShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipShowList.Location = new Point(503, 110);
            btn_ShipShowList.Margin = new Padding(2);
            btn_ShipShowList.Name = "btn_ShipShowList";
            btn_ShipShowList.Size = new Size(185, 100);
            btn_ShipShowList.TabIndex = 54;
            btn_ShipShowList.Text = "一覧表示";
            btn_ShipShowList.UseVisualStyleBackColor = false;
            btn_ShipShowList.Click += btn_ShipShowList_Click;
            // 
            // txb_ShipEmpId
            // 
            txb_ShipEmpId.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipEmpId.Location = new Point(563, 270);
            txb_ShipEmpId.Margin = new Padding(2);
            txb_ShipEmpId.Name = "txb_ShipEmpId";
            txb_ShipEmpId.Size = new Size(75, 39);
            txb_ShipEmpId.TabIndex = 76;
            txb_ShipEmpId.TextChanged += txb_ShipEmpId_TextChanged;
            // 
            // txb_ShipSalesOffice
            // 
            txb_ShipSalesOffice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipSalesOffice.Location = new Point(563, 320);
            txb_ShipSalesOffice.Margin = new Padding(2);
            txb_ShipSalesOffice.Name = "txb_ShipSalesOffice";
            txb_ShipSalesOffice.Size = new Size(75, 39);
            txb_ShipSalesOffice.TabIndex = 75;
            txb_ShipSalesOffice.TextChanged += txb_ShipSalesOffice_TextChanged;
            // 
            // lbl_ShipSalesOffice
            // 
            lbl_ShipSalesOffice.AutoSize = true;
            lbl_ShipSalesOffice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipSalesOffice.Location = new Point(422, 327);
            lbl_ShipSalesOffice.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipSalesOffice.Name = "lbl_ShipSalesOffice";
            lbl_ShipSalesOffice.Size = new Size(109, 32);
            lbl_ShipSalesOffice.TabIndex = 73;
            lbl_ShipSalesOffice.Text = "営業所ID";
            // 
            // txb_ShipJOrderID
            // 
            txb_ShipJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipJOrderID.Location = new Point(854, 221);
            txb_ShipJOrderID.Margin = new Padding(2);
            txb_ShipJOrderID.Name = "txb_ShipJOrderID";
            txb_ShipJOrderID.Size = new Size(145, 39);
            txb_ShipJOrderID.TabIndex = 70;
            // 
            // txb_ShipCstmrID
            // 
            txb_ShipCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipCstmrID.Location = new Point(564, 367);
            txb_ShipCstmrID.Margin = new Padding(2);
            txb_ShipCstmrID.Name = "txb_ShipCstmrID";
            txb_ShipCstmrID.Size = new Size(75, 39);
            txb_ShipCstmrID.TabIndex = 69;
            txb_ShipCstmrID.TextChanged += txb_ShipCstmrID_TextChanged;
            // 
            // lbl_ShipEmpId
            // 
            lbl_ShipEmpId.AutoSize = true;
            lbl_ShipEmpId.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipEmpId.Location = new Point(446, 273);
            lbl_ShipEmpId.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipEmpId.Name = "lbl_ShipEmpId";
            lbl_ShipEmpId.Size = new Size(85, 32);
            lbl_ShipEmpId.TabIndex = 68;
            lbl_ShipEmpId.Text = "社員ID";
            // 
            // lbl_ShipJOrderID
            // 
            lbl_ShipJOrderID.AutoSize = true;
            lbl_ShipJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipJOrderID.Location = new Point(745, 224);
            lbl_ShipJOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipJOrderID.Name = "lbl_ShipJOrderID";
            lbl_ShipJOrderID.Size = new Size(85, 32);
            lbl_ShipJOrderID.TabIndex = 67;
            lbl_ShipJOrderID.Text = "受注ID";
            // 
            // lbl_ShipShipDate
            // 
            lbl_ShipShipDate.AutoSize = true;
            lbl_ShipShipDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipShipDate.Location = new Point(1066, 224);
            lbl_ShipShipDate.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipShipDate.Name = "lbl_ShipShipDate";
            lbl_ShipShipDate.Size = new Size(134, 32);
            lbl_ShipShipDate.TabIndex = 64;
            lbl_ShipShipDate.Text = "出庫年月日";
            // 
            // lbl_ShipCstmrID
            // 
            lbl_ShipCstmrID.AutoSize = true;
            lbl_ShipCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipCstmrID.Location = new Point(446, 374);
            lbl_ShipCstmrID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipCstmrID.Name = "lbl_ShipCstmrID";
            lbl_ShipCstmrID.Size = new Size(85, 32);
            lbl_ShipCstmrID.TabIndex = 63;
            lbl_ShipCstmrID.Text = "顧客ID";
            // 
            // btn_ShipConfirm
            // 
            btn_ShipConfirm.BackColor = Color.Khaki;
            btn_ShipConfirm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipConfirm.Location = new Point(1284, 109);
            btn_ShipConfirm.Margin = new Padding(2);
            btn_ShipConfirm.Name = "btn_ShipConfirm";
            btn_ShipConfirm.Size = new Size(185, 100);
            btn_ShipConfirm.TabIndex = 78;
            btn_ShipConfirm.Text = "確定";
            btn_ShipConfirm.UseVisualStyleBackColor = false;
            btn_ShipConfirm.Click += btn_ShipConfirm_Click;
            // 
            // txb_ShipShipID
            // 
            txb_ShipShipID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipShipID.Location = new Point(563, 224);
            txb_ShipShipID.Margin = new Padding(2);
            txb_ShipShipID.Name = "txb_ShipShipID";
            txb_ShipShipID.Size = new Size(159, 39);
            txb_ShipShipID.TabIndex = 80;
            // 
            // lbl_ShipShipID
            // 
            lbl_ShipShipID.AutoSize = true;
            lbl_ShipShipID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipShipID.Location = new Point(446, 224);
            lbl_ShipShipID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipShipID.Name = "lbl_ShipShipID";
            lbl_ShipShipID.Size = new Size(85, 32);
            lbl_ShipShipID.TabIndex = 79;
            lbl_ShipShipID.Text = "出庫ID";
            // 
            // dtp_ShipDate
            // 
            dtp_ShipDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_ShipDate.Location = new Point(1217, 222);
            dtp_ShipDate.Name = "dtp_ShipDate";
            dtp_ShipDate.Size = new Size(223, 39);
            dtp_ShipDate.TabIndex = 81;
            // 
            // CheckBox_ShipHidden
            // 
            CheckBox_ShipHidden.AutoSize = true;
            CheckBox_ShipHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_ShipHidden.Location = new Point(98, 444);
            CheckBox_ShipHidden.Name = "CheckBox_ShipHidden";
            CheckBox_ShipHidden.Size = new Size(15, 14);
            CheckBox_ShipHidden.TabIndex = 83;
            CheckBox_ShipHidden.UseVisualStyleBackColor = true;
            // 
            // lbl_ShipHidden
            // 
            lbl_ShipHidden.AutoSize = true;
            lbl_ShipHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipHidden.Location = new Point(12, 433);
            lbl_ShipHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipHidden.Name = "lbl_ShipHidden";
            lbl_ShipHidden.Size = new Size(86, 32);
            lbl_ShipHidden.TabIndex = 82;
            lbl_ShipHidden.Text = "非表示";
            // 
            // lbl_ShipSelectForm
            // 
            lbl_ShipSelectForm.AutoSize = true;
            lbl_ShipSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipSelectForm.Location = new Point(33, 31);
            lbl_ShipSelectForm.Name = "lbl_ShipSelectForm";
            lbl_ShipSelectForm.Size = new Size(227, 32);
            lbl_ShipSelectForm.TabIndex = 99;
            lbl_ShipSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_ShipFormShow
            // 
            btn_ShipFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipFormShow.Location = new Point(49, 112);
            btn_ShipFormShow.Name = "btn_ShipFormShow";
            btn_ShipFormShow.Size = new Size(192, 42);
            btn_ShipFormShow.TabIndex = 98;
            btn_ShipFormShow.Text = "表示";
            btn_ShipFormShow.UseVisualStyleBackColor = true;
            btn_ShipFormShow.Click += btn_ShipFormShow_Click;
            // 
            // cmb_ShipSelectForm
            // 
            cmb_ShipSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_ShipSelectForm.FormattingEnabled = true;
            cmb_ShipSelectForm.Location = new Point(33, 66);
            cmb_ShipSelectForm.Name = "cmb_ShipSelectForm";
            cmb_ShipSelectForm.Size = new Size(227, 40);
            cmb_ShipSelectForm.TabIndex = 97;
            // 
            // btn_ShipBack
            // 
            btn_ShipBack.BackColor = Color.Gold;
            btn_ShipBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ShipBack.Location = new Point(1686, 26);
            btn_ShipBack.Margin = new Padding(2);
            btn_ShipBack.Name = "btn_ShipBack";
            btn_ShipBack.Size = new Size(192, 86);
            btn_ShipBack.TabIndex = 100;
            btn_ShipBack.Text = "戻る";
            btn_ShipBack.UseVisualStyleBackColor = false;
            btn_ShipBack.Click += btn_ShipBack_Click;
            // 
            // lbl_ShipDate
            // 
            lbl_ShipDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShipDate.Location = new Point(1121, 43);
            lbl_ShipDate.Name = "lbl_ShipDate";
            lbl_ShipDate.Size = new Size(354, 33);
            lbl_ShipDate.TabIndex = 131;
            lbl_ShipDate.Text = "日付：";
            lbl_ShipDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Shipkengenmei
            // 
            lbl_Shipkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Shipkengenmei.Location = new Point(791, 43);
            lbl_Shipkengenmei.Name = "lbl_Shipkengenmei";
            lbl_Shipkengenmei.Size = new Size(324, 33);
            lbl_Shipkengenmei.TabIndex = 130;
            lbl_Shipkengenmei.Text = "権限名：";
            lbl_Shipkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ShipLoginuser
            // 
            lbl_ShipLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShipLoginuser.Location = new Point(401, 43);
            lbl_ShipLoginuser.Name = "lbl_ShipLoginuser";
            lbl_ShipLoginuser.Size = new Size(384, 33);
            lbl_ShipLoginuser.TabIndex = 129;
            lbl_ShipLoginuser.Text = "ログインユーザー：";
            lbl_ShipLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_ShipHiddenReason
            // 
            btn_ShipHiddenReason.BackColor = Color.PeachPuff;
            btn_ShipHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipHiddenReason.Location = new Point(127, 430);
            btn_ShipHiddenReason.Name = "btn_ShipHiddenReason";
            btn_ShipHiddenReason.Size = new Size(153, 36);
            btn_ShipHiddenReason.TabIndex = 148;
            btn_ShipHiddenReason.Text = "非表示理由";
            btn_ShipHiddenReason.UseVisualStyleBackColor = false;
            btn_ShipHiddenReason.Click += btn_ShipHiddenReason_Click;
            // 
            // lbl_ShipPage
            // 
            lbl_ShipPage.AutoSize = true;
            lbl_ShipPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipPage.Location = new Point(1666, 1003);
            lbl_ShipPage.Name = "lbl_ShipPage";
            lbl_ShipPage.Size = new Size(46, 21);
            lbl_ShipPage.TabIndex = 157;
            lbl_ShipPage.Text = "ページ";
            // 
            // txb_ShipPage
            // 
            txb_ShipPage.Location = new Point(1609, 1003);
            txb_ShipPage.Name = "txb_ShipPage";
            txb_ShipPage.Size = new Size(51, 23);
            txb_ShipPage.TabIndex = 156;
            // 
            // btn_ShipLastPage
            // 
            btn_ShipLastPage.Location = new Point(1856, 998);
            btn_ShipLastPage.Name = "btn_ShipLastPage";
            btn_ShipLastPage.Size = new Size(38, 31);
            btn_ShipLastPage.TabIndex = 155;
            btn_ShipLastPage.Text = "➜";
            btn_ShipLastPage.UseVisualStyleBackColor = true;
            btn_ShipLastPage.Click += btn_ShipLastPage_Click;
            // 
            // btn_ShipPrevPage
            // 
            btn_ShipPrevPage.Location = new Point(1776, 998);
            btn_ShipPrevPage.Name = "btn_ShipPrevPage";
            btn_ShipPrevPage.Size = new Size(38, 31);
            btn_ShipPrevPage.TabIndex = 154;
            btn_ShipPrevPage.Text = "◀️";
            btn_ShipPrevPage.UseVisualStyleBackColor = true;
            btn_ShipPrevPage.Click += btn_ShipPrevPage_Click;
            // 
            // btn_ShipNextPage
            // 
            btn_ShipNextPage.Location = new Point(1816, 998);
            btn_ShipNextPage.Name = "btn_ShipNextPage";
            btn_ShipNextPage.Size = new Size(38, 31);
            btn_ShipNextPage.TabIndex = 153;
            btn_ShipNextPage.Text = "▶️";
            btn_ShipNextPage.UseVisualStyleBackColor = true;
            btn_ShipNextPage.Click += btn_ShipNextPage_Click;
            // 
            // btn_ShipChangeSize
            // 
            btn_ShipChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipChangeSize.Location = new Point(171, 1008);
            btn_ShipChangeSize.Name = "btn_ShipChangeSize";
            btn_ShipChangeSize.Size = new Size(99, 26);
            btn_ShipChangeSize.TabIndex = 160;
            btn_ShipChangeSize.Text = "行数変更";
            btn_ShipChangeSize.UseVisualStyleBackColor = true;
            btn_ShipChangeSize.Click += btn_ShipChangeSize_Click;
            // 
            // txb_ShipPageSize
            // 
            txb_ShipPageSize.Location = new Point(105, 1008);
            txb_ShipPageSize.Name = "txb_ShipPageSize";
            txb_ShipPageSize.Size = new Size(51, 23);
            txb_ShipPageSize.TabIndex = 159;
            // 
            // lbl_ShipPageSize
            // 
            lbl_ShipPageSize.AutoSize = true;
            lbl_ShipPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipPageSize.Location = new Point(12, 1008);
            lbl_ShipPageSize.Name = "lbl_ShipPageSize";
            lbl_ShipPageSize.Size = new Size(87, 21);
            lbl_ShipPageSize.TabIndex = 158;
            lbl_ShipPageSize.Text = "1ページ行数";
            // 
            // btn_ShipPage
            // 
            btn_ShipPage.Location = new Point(1734, 998);
            btn_ShipPage.Name = "btn_ShipPage";
            btn_ShipPage.Size = new Size(38, 31);
            btn_ShipPage.TabIndex = 161;
            btn_ShipPage.Text = "|";
            btn_ShipPage.UseVisualStyleBackColor = true;
            btn_ShipPage.Click += btn_ShipPage_Click;
            // 
            // txb_ShipEmpName
            // 
            txb_ShipEmpName.Enabled = false;
            txb_ShipEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipEmpName.Location = new Point(780, 270);
            txb_ShipEmpName.Margin = new Padding(2);
            txb_ShipEmpName.Name = "txb_ShipEmpName";
            txb_ShipEmpName.Size = new Size(268, 39);
            txb_ShipEmpName.TabIndex = 174;
            // 
            // lbl_ShipEmpName
            // 
            lbl_ShipEmpName.AutoSize = true;
            lbl_ShipEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipEmpName.Location = new Point(677, 273);
            lbl_ShipEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipEmpName.Name = "lbl_ShipEmpName";
            lbl_ShipEmpName.Size = new Size(86, 32);
            lbl_ShipEmpName.TabIndex = 173;
            lbl_ShipEmpName.Text = "社員名";
            // 
            // txb_ShipCstmrName
            // 
            txb_ShipCstmrName.Enabled = false;
            txb_ShipCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipCstmrName.Location = new Point(780, 371);
            txb_ShipCstmrName.Margin = new Padding(2);
            txb_ShipCstmrName.Name = "txb_ShipCstmrName";
            txb_ShipCstmrName.Size = new Size(475, 39);
            txb_ShipCstmrName.TabIndex = 177;
            // 
            // lbl_ShipCstmrName
            // 
            lbl_ShipCstmrName.AutoSize = true;
            lbl_ShipCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipCstmrName.Location = new Point(677, 374);
            lbl_ShipCstmrName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipCstmrName.Name = "lbl_ShipCstmrName";
            lbl_ShipCstmrName.Size = new Size(86, 32);
            lbl_ShipCstmrName.TabIndex = 176;
            lbl_ShipCstmrName.Text = "顧客名";
            // 
            // txb_ShipSalesOfficeName
            // 
            txb_ShipSalesOfficeName.Enabled = false;
            txb_ShipSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipSalesOfficeName.Location = new Point(780, 319);
            txb_ShipSalesOfficeName.Margin = new Padding(2);
            txb_ShipSalesOfficeName.Name = "txb_ShipSalesOfficeName";
            txb_ShipSalesOfficeName.Size = new Size(268, 39);
            txb_ShipSalesOfficeName.TabIndex = 178;
            // 
            // lbl_ShipSalesOfficeName
            // 
            lbl_ShipSalesOfficeName.AutoSize = true;
            lbl_ShipSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipSalesOfficeName.Location = new Point(653, 326);
            lbl_ShipSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipSalesOfficeName.Name = "lbl_ShipSalesOfficeName";
            lbl_ShipSalesOfficeName.Size = new Size(110, 32);
            lbl_ShipSalesOfficeName.TabIndex = 179;
            lbl_ShipSalesOfficeName.Text = "営業所名";
            // 
            // btn_ShipInputClear
            // 
            btn_ShipInputClear.BackColor = Color.PeachPuff;
            btn_ShipInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipInputClear.Location = new Point(1725, 398);
            btn_ShipInputClear.Name = "btn_ShipInputClear";
            btn_ShipInputClear.Size = new Size(153, 60);
            btn_ShipInputClear.TabIndex = 184;
            btn_ShipInputClear.Text = "入力クリア";
            btn_ShipInputClear.UseVisualStyleBackColor = false;
            btn_ShipInputClear.Click += btn_ShipInputClear_Click;
            // 
            // btn_ShipShowDetail
            // 
            btn_ShipShowDetail.Location = new Point(636, 421);
            btn_ShipShowDetail.Name = "btn_ShipShowDetail";
            btn_ShipShowDetail.Size = new Size(97, 36);
            btn_ShipShowDetail.TabIndex = 191;
            btn_ShipShowDetail.Text = "出庫詳細一覧";
            btn_ShipShowDetail.UseVisualStyleBackColor = true;
            btn_ShipShowDetail.Click += btn_ShipShowDetail_Click;
            // 
            // txb_ShipProductName
            // 
            txb_ShipProductName.Enabled = false;
            txb_ShipProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipProductName.Location = new Point(1094, 419);
            txb_ShipProductName.Margin = new Padding(2);
            txb_ShipProductName.Name = "txb_ShipProductName";
            txb_ShipProductName.Size = new Size(178, 39);
            txb_ShipProductName.TabIndex = 190;
            // 
            // lbl_ShipProductName
            // 
            lbl_ShipProductName.AutoSize = true;
            lbl_ShipProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipProductName.Location = new Point(997, 422);
            lbl_ShipProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipProductName.Name = "lbl_ShipProductName";
            lbl_ShipProductName.Size = new Size(86, 32);
            lbl_ShipProductName.TabIndex = 189;
            lbl_ShipProductName.Text = "商品名";
            // 
            // lbl_ShipProductID
            // 
            lbl_ShipProductID.AutoSize = true;
            lbl_ShipProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipProductID.Location = new Point(745, 422);
            lbl_ShipProductID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipProductID.Name = "lbl_ShipProductID";
            lbl_ShipProductID.Size = new Size(85, 32);
            lbl_ShipProductID.TabIndex = 188;
            lbl_ShipProductID.Text = "商品ID";
            // 
            // txb_ShipProductID
            // 
            txb_ShipProductID.Enabled = false;
            txb_ShipProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipProductID.Location = new Point(835, 418);
            txb_ShipProductID.Margin = new Padding(2);
            txb_ShipProductID.Name = "txb_ShipProductID";
            txb_ShipProductID.Size = new Size(149, 39);
            txb_ShipProductID.TabIndex = 187;
            txb_ShipProductID.TextChanged += txb_ShipProductID_TextChanged;
            // 
            // lbl_ShipDetailID
            // 
            lbl_ShipDetailID.AutoSize = true;
            lbl_ShipDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipDetailID.Location = new Point(398, 422);
            lbl_ShipDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipDetailID.Name = "lbl_ShipDetailID";
            lbl_ShipDetailID.Size = new Size(133, 32);
            lbl_ShipDetailID.TabIndex = 186;
            lbl_ShipDetailID.Text = "出庫詳細ID";
            // 
            // txb_ShipDetailID
            // 
            txb_ShipDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipDetailID.Location = new Point(563, 418);
            txb_ShipDetailID.Margin = new Padding(2);
            txb_ShipDetailID.Name = "txb_ShipDetailID";
            txb_ShipDetailID.Size = new Size(68, 39);
            txb_ShipDetailID.TabIndex = 185;
            txb_ShipDetailID.TextChanged += txb_ShipDetailID_TextChanged;
            // 
            // lbl_ShipProductcnt
            // 
            lbl_ShipProductcnt.AutoSize = true;
            lbl_ShipProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShipProductcnt.Location = new Point(1299, 422);
            lbl_ShipProductcnt.Margin = new Padding(2, 0, 2, 0);
            lbl_ShipProductcnt.Name = "lbl_ShipProductcnt";
            lbl_ShipProductcnt.Size = new Size(62, 32);
            lbl_ShipProductcnt.TabIndex = 193;
            lbl_ShipProductcnt.Text = "数量";
            // 
            // txb_ShipProductcnt
            // 
            txb_ShipProductcnt.Enabled = false;
            txb_ShipProductcnt.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ShipProductcnt.Location = new Point(1368, 419);
            txb_ShipProductcnt.Margin = new Padding(2);
            txb_ShipProductcnt.Name = "txb_ShipProductcnt";
            txb_ShipProductcnt.Size = new Size(140, 39);
            txb_ShipProductcnt.TabIndex = 192;
            // 
            // btn_ShipHidden
            // 
            btn_ShipHidden.BackColor = Color.Khaki;
            btn_ShipHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ShipHidden.Location = new Point(1022, 110);
            btn_ShipHidden.Margin = new Padding(2);
            btn_ShipHidden.Name = "btn_ShipHidden";
            btn_ShipHidden.Size = new Size(185, 100);
            btn_ShipHidden.TabIndex = 194;
            btn_ShipHidden.Text = "非表示更新";
            btn_ShipHidden.UseVisualStyleBackColor = false;
            btn_ShipHidden.Click += btn_ShipHidden_Click;
            // 
            // F_Ship
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_ShipHidden);
            Controls.Add(lbl_ShipProductcnt);
            Controls.Add(txb_ShipProductcnt);
            Controls.Add(btn_ShipShowDetail);
            Controls.Add(txb_ShipProductName);
            Controls.Add(lbl_ShipProductName);
            Controls.Add(lbl_ShipProductID);
            Controls.Add(txb_ShipProductID);
            Controls.Add(lbl_ShipDetailID);
            Controls.Add(txb_ShipDetailID);
            Controls.Add(btn_ShipInputClear);
            Controls.Add(txb_ShipSalesOfficeName);
            Controls.Add(lbl_ShipSalesOfficeName);
            Controls.Add(txb_ShipCstmrName);
            Controls.Add(lbl_ShipCstmrName);
            Controls.Add(txb_ShipEmpName);
            Controls.Add(lbl_ShipEmpName);
            Controls.Add(btn_ShipPage);
            Controls.Add(btn_ShipChangeSize);
            Controls.Add(txb_ShipPageSize);
            Controls.Add(lbl_ShipPageSize);
            Controls.Add(lbl_ShipPage);
            Controls.Add(txb_ShipPage);
            Controls.Add(btn_ShipLastPage);
            Controls.Add(btn_ShipPrevPage);
            Controls.Add(btn_ShipNextPage);
            Controls.Add(btn_ShipHiddenReason);
            Controls.Add(lbl_ShipDate);
            Controls.Add(lbl_Shipkengenmei);
            Controls.Add(lbl_ShipLoginuser);
            Controls.Add(btn_ShipBack);
            Controls.Add(lbl_ShipSelectForm);
            Controls.Add(btn_ShipFormShow);
            Controls.Add(cmb_ShipSelectForm);
            Controls.Add(CheckBox_ShipHidden);
            Controls.Add(lbl_ShipHidden);
            Controls.Add(dtp_ShipDate);
            Controls.Add(txb_ShipShipID);
            Controls.Add(lbl_ShipShipID);
            Controls.Add(btn_ShipConfirm);
            Controls.Add(txb_ShipEmpId);
            Controls.Add(txb_ShipSalesOffice);
            Controls.Add(lbl_ShipSalesOffice);
            Controls.Add(txb_ShipJOrderID);
            Controls.Add(txb_ShipCstmrID);
            Controls.Add(lbl_ShipEmpId);
            Controls.Add(lbl_ShipJOrderID);
            Controls.Add(lbl_ShipShipDate);
            Controls.Add(lbl_ShipCstmrID);
            Controls.Add(btn_ShipSearch);
            Controls.Add(btn_ShipShowList);
            Controls.Add(dataGrid_Ship);
            Margin = new Padding(2);
            Name = "F_Ship";
            Text = "販売管理システム出庫画面";
            Load += F_Ship_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Ship).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid_Ship;
        private Button btn_ShipSearch;
        private Button btn_ShipShowList;
        private TextBox txb_ShipEmpId;
        private TextBox txb_ShipSalesOffice;
        private Label lbl_ShipSalesOffice;
        private TextBox txb_ShipJOrderID;
        private TextBox txb_ShipCstmrID;
        private Label lbl_ShipEmpId;
        private Label lbl_ShipJOrderID;
        private Label lbl_ShipShipDate;
        private Label lbl_ShipCstmrID;
        private Button btn_ShipConfirm;
        private TextBox txb_ShipShipID;
        private Label lbl_ShipShipID;
        private DateTimePicker dtp_ShipDate;
        private CheckBox CheckBox_ShipHidden;
        private Label lbl_ShipHidden;
        private Label lbl_ShipSelectForm;
        private Button btn_ShipFormShow;
        private ComboBox cmb_ShipSelectForm;
        private Button btn_ShipBack;
        private Label lbl_ShipDate;
        private Label lbl_Shipkengenmei;
        private Label lbl_ShipLoginuser;
        private Button btn_ShipHiddenReason;
        private Label lbl_ShipPage;
        private TextBox txb_ShipPage;
        private Button btn_ShipLastPage;
        private Button btn_ShipPrevPage;
        private Button btn_ShipNextPage;
        private Button btn_ShipChangeSize;
        private TextBox txb_ShipPageSize;
        private Label lbl_ShipPageSize;
        private Button btn_ShipPage;
        private TextBox txb_ShipEmpName;
        private Label lbl_ShipEmpName;
        private TextBox txb_ShipCstmrName;
        private Label lbl_ShipCstmrName;
        private TextBox txb_ShipSalesOfficeName;
        private Label lbl_ShipSalesOfficeName;
        private Button btn_ShipInputClear;
        private Button btn_ShipShowDetail;
        private TextBox txb_ShipProductName;
        private Label lbl_ShipProductName;
        private Label lbl_ShipProductID;
        private TextBox txb_ShipProductID;
        private Label lbl_ShipDetailID;
        private TextBox txb_ShipDetailID;
        private Label lbl_ShipProductcnt;
        private TextBox txb_ShipProductcnt;
        private Button btn_ShipHidden;
    }
}