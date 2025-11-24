namespace SalesManagement_SysDev
{
    partial class F_Sales
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
            btn_SalBack = new Button();
            btn_SalSearch = new Button();
            btn_SalShow = new Button();
            txb_SalEmpID = new TextBox();
            txb_SalSalesOfficeID = new TextBox();
            lbl_SalSalesID = new Label();
            lbl_SalSalesOfficeID = new Label();
            txb_SalSalesID = new TextBox();
            txb_SalJOrderID = new TextBox();
            txb_SalCstmrID = new TextBox();
            lbl_SalEmpID = new Label();
            lbl_SalJOrderID = new Label();
            lbl_SalSalesDate = new Label();
            lbl_SalCstmrID = new Label();
            dataGrid_Sales = new DataGridView();
            btn_SalHidden = new Button();
            lbl_SalSelectForm = new Label();
            btn_SalFormShow = new Button();
            cmb_SalSelectForm = new ComboBox();
            lbl_SalHidden = new Label();
            CheckBox_SalHidden = new CheckBox();
            dtp_SalDate = new DateTimePicker();
            lbl_SalesDate = new Label();
            lbl_Saleskengenmei = new Label();
            lbl_SalesLoginuser = new Label();
            btn_SalHiddenReason = new Button();
            lbl_SalPage = new Label();
            txb_SalPage = new TextBox();
            btn_SalLastPage = new Button();
            btn_SalPrevPage = new Button();
            btn_SalNextPage = new Button();
            btn_SalChangeSize = new Button();
            txb_SalPageSize = new TextBox();
            lbl_SalPageSize = new Label();
            btn_SalFirstPage = new Button();
            txb_SalSalesDetailID = new TextBox();
            lbl_SalSalesDetailID = new Label();
            txb_SalQuantity = new TextBox();
            lbl_SalQuantity = new Label();
            txb_SalTotalPrice = new TextBox();
            lbl_SalTotalPrice = new Label();
            txb_SalSalesOfficeName = new TextBox();
            lbl_SalSalesOfficeName = new Label();
            txb_SalEmpName = new TextBox();
            lbl_EmpName = new Label();
            txb_SalCstmrName = new TextBox();
            lbl_SalCstmrName = new Label();
            btn_SalShowDetail = new Button();
            txb_SalProductName = new TextBox();
            lbl_SalProductName = new Label();
            lbl_SalProductID = new Label();
            txb_SalProductID = new TextBox();
            btn_SalInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Sales).BeginInit();
            SuspendLayout();
            // 
            // btn_SalBack
            // 
            btn_SalBack.BackColor = Color.Gold;
            btn_SalBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SalBack.Location = new Point(1686, 26);
            btn_SalBack.Margin = new Padding(2);
            btn_SalBack.Name = "btn_SalBack";
            btn_SalBack.Size = new Size(192, 86);
            btn_SalBack.TabIndex = 51;
            btn_SalBack.Text = "戻る";
            btn_SalBack.UseVisualStyleBackColor = false;
            btn_SalBack.Click += btn_SalBack_Click;
            // 
            // btn_SalSearch
            // 
            btn_SalSearch.BackColor = Color.Khaki;
            btn_SalSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalSearch.Location = new Point(863, 114);
            btn_SalSearch.Margin = new Padding(2);
            btn_SalSearch.Name = "btn_SalSearch";
            btn_SalSearch.Size = new Size(185, 100);
            btn_SalSearch.TabIndex = 43;
            btn_SalSearch.Text = "検索";
            btn_SalSearch.UseVisualStyleBackColor = false;
            btn_SalSearch.Click += btn_SalSearch_Click;
            // 
            // btn_SalShow
            // 
            btn_SalShow.BackColor = Color.Khaki;
            btn_SalShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalShow.Location = new Point(602, 114);
            btn_SalShow.Margin = new Padding(2);
            btn_SalShow.Name = "btn_SalShow";
            btn_SalShow.Size = new Size(185, 100);
            btn_SalShow.TabIndex = 41;
            btn_SalShow.Text = "一覧表示";
            btn_SalShow.UseVisualStyleBackColor = false;
            btn_SalShow.Click += btn_SalShow_Click;
            // 
            // txb_SalEmpID
            // 
            txb_SalEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalEmpID.Location = new Point(515, 371);
            txb_SalEmpID.Margin = new Padding(2);
            txb_SalEmpID.Name = "txb_SalEmpID";
            txb_SalEmpID.Size = new Size(109, 39);
            txb_SalEmpID.TabIndex = 40;
            txb_SalEmpID.TextChanged += txb_SalEmpID_TextChanged;
            // 
            // txb_SalSalesOfficeID
            // 
            txb_SalSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalSalesOfficeID.Location = new Point(514, 323);
            txb_SalSalesOfficeID.Margin = new Padding(2);
            txb_SalSalesOfficeID.Name = "txb_SalSalesOfficeID";
            txb_SalSalesOfficeID.Size = new Size(110, 39);
            txb_SalSalesOfficeID.TabIndex = 39;
            txb_SalSalesOfficeID.TextChanged += txb_SalSalesOfficeID_TextChanged;
            // 
            // lbl_SalSalesID
            // 
            lbl_SalSalesID.AutoSize = true;
            lbl_SalSalesID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSalesID.Location = new Point(414, 230);
            lbl_SalSalesID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalSalesID.Name = "lbl_SalSalesID";
            lbl_SalSalesID.Size = new Size(85, 32);
            lbl_SalSalesID.TabIndex = 38;
            lbl_SalSalesID.Text = "売上ID";
            // 
            // lbl_SalSalesOfficeID
            // 
            lbl_SalSalesOfficeID.AutoSize = true;
            lbl_SalSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSalesOfficeID.Location = new Point(390, 326);
            lbl_SalSalesOfficeID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalSalesOfficeID.Name = "lbl_SalSalesOfficeID";
            lbl_SalSalesOfficeID.Size = new Size(109, 32);
            lbl_SalSalesOfficeID.TabIndex = 37;
            lbl_SalSalesOfficeID.Text = "営業所ID";
            // 
            // txb_SalSalesID
            // 
            txb_SalSalesID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalSalesID.Location = new Point(515, 227);
            txb_SalSalesID.Margin = new Padding(2);
            txb_SalSalesID.Name = "txb_SalSalesID";
            txb_SalSalesID.Size = new Size(109, 39);
            txb_SalSalesID.TabIndex = 36;
            // 
            // txb_SalJOrderID
            // 
            txb_SalJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalJOrderID.Location = new Point(782, 222);
            txb_SalJOrderID.Margin = new Padding(2);
            txb_SalJOrderID.Name = "txb_SalJOrderID";
            txb_SalJOrderID.Size = new Size(177, 39);
            txb_SalJOrderID.TabIndex = 34;
            // 
            // txb_SalCstmrID
            // 
            txb_SalCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalCstmrID.Location = new Point(513, 277);
            txb_SalCstmrID.Margin = new Padding(2);
            txb_SalCstmrID.Name = "txb_SalCstmrID";
            txb_SalCstmrID.Size = new Size(111, 39);
            txb_SalCstmrID.TabIndex = 33;
            txb_SalCstmrID.TextChanged += txb_SalCstmrID_TextChanged;
            // 
            // lbl_SalEmpID
            // 
            lbl_SalEmpID.AutoSize = true;
            lbl_SalEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalEmpID.Location = new Point(414, 374);
            lbl_SalEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalEmpID.Name = "lbl_SalEmpID";
            lbl_SalEmpID.Size = new Size(85, 32);
            lbl_SalEmpID.TabIndex = 32;
            lbl_SalEmpID.Text = "社員ID";
            // 
            // lbl_SalJOrderID
            // 
            lbl_SalJOrderID.AutoSize = true;
            lbl_SalJOrderID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalJOrderID.Location = new Point(681, 229);
            lbl_SalJOrderID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalJOrderID.Name = "lbl_SalJOrderID";
            lbl_SalJOrderID.Size = new Size(85, 32);
            lbl_SalJOrderID.TabIndex = 31;
            lbl_SalJOrderID.Text = "受注ID";
            // 
            // lbl_SalSalesDate
            // 
            lbl_SalSalesDate.AutoSize = true;
            lbl_SalSalesDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSalesDate.Location = new Point(991, 229);
            lbl_SalSalesDate.Margin = new Padding(2, 0, 2, 0);
            lbl_SalSalesDate.Name = "lbl_SalSalesDate";
            lbl_SalSalesDate.Size = new Size(110, 32);
            lbl_SalSalesDate.TabIndex = 30;
            lbl_SalSalesDate.Text = "売上日時";
            // 
            // lbl_SalCstmrID
            // 
            lbl_SalCstmrID.AutoSize = true;
            lbl_SalCstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalCstmrID.Location = new Point(414, 280);
            lbl_SalCstmrID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalCstmrID.Name = "lbl_SalCstmrID";
            lbl_SalCstmrID.Size = new Size(85, 32);
            lbl_SalCstmrID.TabIndex = 27;
            lbl_SalCstmrID.Text = "顧客ID";
            // 
            // dataGrid_Sales
            // 
            dataGrid_Sales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Sales.Location = new Point(12, 472);
            dataGrid_Sales.Name = "dataGrid_Sales";
            dataGrid_Sales.RowHeadersWidth = 62;
            dataGrid_Sales.RowTemplate.Height = 33;
            dataGrid_Sales.Size = new Size(1882, 520);
            dataGrid_Sales.TabIndex = 52;
            dataGrid_Sales.CellClick += dataGrid_Sales_CellClick_1;
            // 
            // btn_SalHidden
            // 
            btn_SalHidden.BackColor = Color.Khaki;
            btn_SalHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalHidden.Location = new Point(1121, 114);
            btn_SalHidden.Margin = new Padding(2);
            btn_SalHidden.Name = "btn_SalHidden";
            btn_SalHidden.Size = new Size(185, 100);
            btn_SalHidden.TabIndex = 55;
            btn_SalHidden.Text = "非表示更新";
            btn_SalHidden.UseVisualStyleBackColor = false;
            btn_SalHidden.Click += btn_SalHidden_Click;
            // 
            // lbl_SalSelectForm
            // 
            lbl_SalSelectForm.AutoSize = true;
            lbl_SalSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSelectForm.Location = new Point(33, 31);
            lbl_SalSelectForm.Name = "lbl_SalSelectForm";
            lbl_SalSelectForm.Size = new Size(227, 32);
            lbl_SalSelectForm.TabIndex = 58;
            lbl_SalSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_SalFormShow
            // 
            btn_SalFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalFormShow.Location = new Point(49, 112);
            btn_SalFormShow.Name = "btn_SalFormShow";
            btn_SalFormShow.Size = new Size(192, 42);
            btn_SalFormShow.TabIndex = 57;
            btn_SalFormShow.Text = "表示";
            btn_SalFormShow.UseVisualStyleBackColor = true;
            btn_SalFormShow.Click += btn_SalFormShow_Click;
            // 
            // cmb_SalSelectForm
            // 
            cmb_SalSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_SalSelectForm.FormattingEnabled = true;
            cmb_SalSelectForm.Location = new Point(33, 66);
            cmb_SalSelectForm.Name = "cmb_SalSelectForm";
            cmb_SalSelectForm.Size = new Size(227, 40);
            cmb_SalSelectForm.TabIndex = 56;
            // 
            // lbl_SalHidden
            // 
            lbl_SalHidden.AutoSize = true;
            lbl_SalHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalHidden.Location = new Point(12, 433);
            lbl_SalHidden.Margin = new Padding(2, 0, 2, 0);
            lbl_SalHidden.Name = "lbl_SalHidden";
            lbl_SalHidden.Size = new Size(86, 32);
            lbl_SalHidden.TabIndex = 127;
            lbl_SalHidden.Text = "非表示";
            // 
            // CheckBox_SalHidden
            // 
            CheckBox_SalHidden.AutoSize = true;
            CheckBox_SalHidden.BackColor = Color.Transparent;
            CheckBox_SalHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_SalHidden.Location = new Point(98, 444);
            CheckBox_SalHidden.Name = "CheckBox_SalHidden";
            CheckBox_SalHidden.Size = new Size(15, 14);
            CheckBox_SalHidden.TabIndex = 126;
            CheckBox_SalHidden.UseVisualStyleBackColor = false;
            // 
            // dtp_SalDate
            // 
            dtp_SalDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_SalDate.Location = new Point(1119, 224);
            dtp_SalDate.Name = "dtp_SalDate";
            dtp_SalDate.Size = new Size(217, 39);
            dtp_SalDate.TabIndex = 128;
            // 
            // lbl_SalesDate
            // 
            lbl_SalesDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_SalesDate.Location = new Point(1121, 43);
            lbl_SalesDate.Name = "lbl_SalesDate";
            lbl_SalesDate.Size = new Size(354, 33);
            lbl_SalesDate.TabIndex = 131;
            lbl_SalesDate.Text = "日付：";
            lbl_SalesDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Saleskengenmei
            // 
            lbl_Saleskengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Saleskengenmei.Location = new Point(791, 43);
            lbl_Saleskengenmei.Name = "lbl_Saleskengenmei";
            lbl_Saleskengenmei.Size = new Size(324, 33);
            lbl_Saleskengenmei.TabIndex = 130;
            lbl_Saleskengenmei.Text = "権限名：";
            lbl_Saleskengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_SalesLoginuser
            // 
            lbl_SalesLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_SalesLoginuser.Location = new Point(401, 43);
            lbl_SalesLoginuser.Name = "lbl_SalesLoginuser";
            lbl_SalesLoginuser.Size = new Size(384, 33);
            lbl_SalesLoginuser.TabIndex = 129;
            lbl_SalesLoginuser.Text = "ログインユーザー：";
            lbl_SalesLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_SalHiddenReason
            // 
            btn_SalHiddenReason.BackColor = Color.PeachPuff;
            btn_SalHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalHiddenReason.Location = new Point(127, 430);
            btn_SalHiddenReason.Name = "btn_SalHiddenReason";
            btn_SalHiddenReason.Size = new Size(153, 36);
            btn_SalHiddenReason.TabIndex = 148;
            btn_SalHiddenReason.Text = "非表示理由";
            btn_SalHiddenReason.UseVisualStyleBackColor = false;
            btn_SalHiddenReason.Click += btn_SalHiddenReason_Click;
            // 
            // lbl_SalPage
            // 
            lbl_SalPage.AutoSize = true;
            lbl_SalPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalPage.Location = new Point(1666, 1003);
            lbl_SalPage.Name = "lbl_SalPage";
            lbl_SalPage.Size = new Size(46, 21);
            lbl_SalPage.TabIndex = 157;
            lbl_SalPage.Text = "ページ";
            // 
            // txb_SalPage
            // 
            txb_SalPage.Location = new Point(1609, 1003);
            txb_SalPage.Name = "txb_SalPage";
            txb_SalPage.Size = new Size(51, 23);
            txb_SalPage.TabIndex = 156;
            // 
            // btn_SalLastPage
            // 
            btn_SalLastPage.Location = new Point(1855, 997);
            btn_SalLastPage.Name = "btn_SalLastPage";
            btn_SalLastPage.Size = new Size(38, 31);
            btn_SalLastPage.TabIndex = 155;
            btn_SalLastPage.Text = "➜";
            btn_SalLastPage.UseVisualStyleBackColor = true;
            btn_SalLastPage.Click += btn_SalLastPage_Click;
            // 
            // btn_SalPrevPage
            // 
            btn_SalPrevPage.Location = new Point(1775, 997);
            btn_SalPrevPage.Name = "btn_SalPrevPage";
            btn_SalPrevPage.Size = new Size(38, 31);
            btn_SalPrevPage.TabIndex = 154;
            btn_SalPrevPage.Text = "◀️";
            btn_SalPrevPage.UseVisualStyleBackColor = true;
            btn_SalPrevPage.Click += btn_SalPrevPage_Click;
            // 
            // btn_SalNextPage
            // 
            btn_SalNextPage.Location = new Point(1815, 997);
            btn_SalNextPage.Name = "btn_SalNextPage";
            btn_SalNextPage.Size = new Size(38, 31);
            btn_SalNextPage.TabIndex = 153;
            btn_SalNextPage.Text = "▶️";
            btn_SalNextPage.UseVisualStyleBackColor = true;
            btn_SalNextPage.Click += btn_SalNextPage_Click;
            // 
            // btn_SalChangeSize
            // 
            btn_SalChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalChangeSize.Location = new Point(171, 1008);
            btn_SalChangeSize.Name = "btn_SalChangeSize";
            btn_SalChangeSize.Size = new Size(99, 26);
            btn_SalChangeSize.TabIndex = 160;
            btn_SalChangeSize.Text = "行数変更";
            btn_SalChangeSize.UseVisualStyleBackColor = true;
            btn_SalChangeSize.Click += btn_SalChangeSize_Click;
            // 
            // txb_SalPageSize
            // 
            txb_SalPageSize.Location = new Point(105, 1008);
            txb_SalPageSize.Name = "txb_SalPageSize";
            txb_SalPageSize.Size = new Size(51, 23);
            txb_SalPageSize.TabIndex = 159;
            // 
            // lbl_SalPageSize
            // 
            lbl_SalPageSize.AutoSize = true;
            lbl_SalPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalPageSize.Location = new Point(12, 1008);
            lbl_SalPageSize.Name = "lbl_SalPageSize";
            lbl_SalPageSize.Size = new Size(87, 21);
            lbl_SalPageSize.TabIndex = 158;
            lbl_SalPageSize.Text = "1ページ行数";
            // 
            // btn_SalFirstPage
            // 
            btn_SalFirstPage.Location = new Point(1734, 998);
            btn_SalFirstPage.Name = "btn_SalFirstPage";
            btn_SalFirstPage.Size = new Size(38, 31);
            btn_SalFirstPage.TabIndex = 161;
            btn_SalFirstPage.Text = "|";
            btn_SalFirstPage.UseVisualStyleBackColor = true;
            btn_SalFirstPage.Click += btn_SalFirstPage_Click;
            // 
            // txb_SalSalesDetailID
            // 
            txb_SalSalesDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalSalesDetailID.Location = new Point(458, 422);
            txb_SalSalesDetailID.Margin = new Padding(2);
            txb_SalSalesDetailID.Name = "txb_SalSalesDetailID";
            txb_SalSalesDetailID.Size = new Size(65, 39);
            txb_SalSalesDetailID.TabIndex = 163;
            txb_SalSalesDetailID.TextChanged += txb_SalSalesDetailID_TextChanged;
            // 
            // lbl_SalSalesDetailID
            // 
            lbl_SalSalesDetailID.AutoSize = true;
            lbl_SalSalesDetailID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSalesDetailID.Location = new Point(307, 425);
            lbl_SalSalesDetailID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalSalesDetailID.Name = "lbl_SalSalesDetailID";
            lbl_SalSalesDetailID.Size = new Size(133, 32);
            lbl_SalSalesDetailID.TabIndex = 162;
            lbl_SalSalesDetailID.Text = "売上詳細ID";
            // 
            // txb_SalQuantity
            // 
            txb_SalQuantity.Enabled = false;
            txb_SalQuantity.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalQuantity.Location = new Point(1203, 418);
            txb_SalQuantity.Margin = new Padding(2);
            txb_SalQuantity.Name = "txb_SalQuantity";
            txb_SalQuantity.Size = new Size(88, 39);
            txb_SalQuantity.TabIndex = 165;
            // 
            // lbl_SalQuantity
            // 
            lbl_SalQuantity.AutoSize = true;
            lbl_SalQuantity.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalQuantity.Location = new Point(1137, 425);
            lbl_SalQuantity.Margin = new Padding(2, 0, 2, 0);
            lbl_SalQuantity.Name = "lbl_SalQuantity";
            lbl_SalQuantity.Size = new Size(62, 32);
            lbl_SalQuantity.TabIndex = 164;
            lbl_SalQuantity.Text = "個数";
            // 
            // txb_SalTotalPrice
            // 
            txb_SalTotalPrice.Enabled = false;
            txb_SalTotalPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalTotalPrice.Location = new Point(1429, 417);
            txb_SalTotalPrice.Margin = new Padding(2);
            txb_SalTotalPrice.Name = "txb_SalTotalPrice";
            txb_SalTotalPrice.Size = new Size(156, 39);
            txb_SalTotalPrice.TabIndex = 167;
            // 
            // lbl_SalTotalPrice
            // 
            lbl_SalTotalPrice.AutoSize = true;
            lbl_SalTotalPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalTotalPrice.Location = new Point(1315, 424);
            lbl_SalTotalPrice.Margin = new Padding(2, 0, 2, 0);
            lbl_SalTotalPrice.Name = "lbl_SalTotalPrice";
            lbl_SalTotalPrice.Size = new Size(110, 32);
            lbl_SalTotalPrice.TabIndex = 166;
            lbl_SalTotalPrice.Text = "合計金額";
            // 
            // txb_SalSalesOfficeName
            // 
            txb_SalSalesOfficeName.Enabled = false;
            txb_SalSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalSalesOfficeName.Location = new Point(782, 323);
            txb_SalSalesOfficeName.Margin = new Padding(2);
            txb_SalSalesOfficeName.Name = "txb_SalSalesOfficeName";
            txb_SalSalesOfficeName.Size = new Size(177, 39);
            txb_SalSalesOfficeName.TabIndex = 171;
            // 
            // lbl_SalSalesOfficeName
            // 
            lbl_SalSalesOfficeName.AutoSize = true;
            lbl_SalSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalSalesOfficeName.Location = new Point(657, 326);
            lbl_SalSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_SalSalesOfficeName.Name = "lbl_SalSalesOfficeName";
            lbl_SalSalesOfficeName.Size = new Size(110, 32);
            lbl_SalSalesOfficeName.TabIndex = 170;
            lbl_SalSalesOfficeName.Text = "営業所名";
            // 
            // txb_SalEmpName
            // 
            txb_SalEmpName.Enabled = false;
            txb_SalEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalEmpName.Location = new Point(782, 371);
            txb_SalEmpName.Margin = new Padding(2);
            txb_SalEmpName.Name = "txb_SalEmpName";
            txb_SalEmpName.Size = new Size(177, 39);
            txb_SalEmpName.TabIndex = 169;
            // 
            // lbl_EmpName
            // 
            lbl_EmpName.AutoSize = true;
            lbl_EmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmpName.Location = new Point(680, 371);
            lbl_EmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_EmpName.Name = "lbl_EmpName";
            lbl_EmpName.Size = new Size(86, 32);
            lbl_EmpName.TabIndex = 168;
            lbl_EmpName.Text = "社員名";
            // 
            // txb_SalCstmrName
            // 
            txb_SalCstmrName.Enabled = false;
            txb_SalCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalCstmrName.Location = new Point(782, 273);
            txb_SalCstmrName.Margin = new Padding(2);
            txb_SalCstmrName.Name = "txb_SalCstmrName";
            txb_SalCstmrName.Size = new Size(319, 39);
            txb_SalCstmrName.TabIndex = 179;
            // 
            // lbl_SalCstmrName
            // 
            lbl_SalCstmrName.AutoSize = true;
            lbl_SalCstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalCstmrName.Location = new Point(680, 280);
            lbl_SalCstmrName.Margin = new Padding(2, 0, 2, 0);
            lbl_SalCstmrName.Name = "lbl_SalCstmrName";
            lbl_SalCstmrName.Size = new Size(86, 32);
            lbl_SalCstmrName.TabIndex = 178;
            lbl_SalCstmrName.Text = "顧客名";
            // 
            // btn_SalShowDetail
            // 
            btn_SalShowDetail.Location = new Point(528, 422);
            btn_SalShowDetail.Name = "btn_SalShowDetail";
            btn_SalShowDetail.Size = new Size(96, 39);
            btn_SalShowDetail.TabIndex = 180;
            btn_SalShowDetail.Text = "売上詳細一覧";
            btn_SalShowDetail.UseVisualStyleBackColor = true;
            btn_SalShowDetail.Click += btn_SalShowDetail_Click;
            // 
            // txb_SalProductName
            // 
            txb_SalProductName.Enabled = false;
            txb_SalProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalProductName.Location = new Point(939, 422);
            txb_SalProductName.Margin = new Padding(2);
            txb_SalProductName.Name = "txb_SalProductName";
            txb_SalProductName.Size = new Size(178, 39);
            txb_SalProductName.TabIndex = 194;
            // 
            // lbl_SalProductName
            // 
            lbl_SalProductName.AutoSize = true;
            lbl_SalProductName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalProductName.Location = new Point(842, 425);
            lbl_SalProductName.Margin = new Padding(2, 0, 2, 0);
            lbl_SalProductName.Name = "lbl_SalProductName";
            lbl_SalProductName.Size = new Size(86, 32);
            lbl_SalProductName.TabIndex = 193;
            lbl_SalProductName.Text = "商品名";
            // 
            // lbl_SalProductID
            // 
            lbl_SalProductID.AutoSize = true;
            lbl_SalProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_SalProductID.Location = new Point(638, 425);
            lbl_SalProductID.Margin = new Padding(2, 0, 2, 0);
            lbl_SalProductID.Name = "lbl_SalProductID";
            lbl_SalProductID.Size = new Size(85, 32);
            lbl_SalProductID.TabIndex = 192;
            lbl_SalProductID.Text = "商品ID";
            // 
            // txb_SalProductID
            // 
            txb_SalProductID.Enabled = false;
            txb_SalProductID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_SalProductID.Location = new Point(728, 421);
            txb_SalProductID.Margin = new Padding(2);
            txb_SalProductID.Name = "txb_SalProductID";
            txb_SalProductID.Size = new Size(97, 39);
            txb_SalProductID.TabIndex = 191;
            // 
            // btn_SalInputClear
            // 
            btn_SalInputClear.BackColor = Color.PeachPuff;
            btn_SalInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SalInputClear.Location = new Point(1725, 398);
            btn_SalInputClear.Name = "btn_SalInputClear";
            btn_SalInputClear.Size = new Size(153, 60);
            btn_SalInputClear.TabIndex = 195;
            btn_SalInputClear.Text = "入力クリア";
            btn_SalInputClear.UseVisualStyleBackColor = false;
            // 
            // F_Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_SalInputClear);
            Controls.Add(txb_SalProductName);
            Controls.Add(lbl_SalProductName);
            Controls.Add(lbl_SalProductID);
            Controls.Add(txb_SalProductID);
            Controls.Add(btn_SalShowDetail);
            Controls.Add(txb_SalCstmrName);
            Controls.Add(lbl_SalCstmrName);
            Controls.Add(txb_SalSalesOfficeName);
            Controls.Add(lbl_SalSalesOfficeName);
            Controls.Add(txb_SalEmpName);
            Controls.Add(lbl_EmpName);
            Controls.Add(txb_SalTotalPrice);
            Controls.Add(lbl_SalTotalPrice);
            Controls.Add(txb_SalQuantity);
            Controls.Add(lbl_SalQuantity);
            Controls.Add(txb_SalSalesDetailID);
            Controls.Add(lbl_SalSalesDetailID);
            Controls.Add(btn_SalFirstPage);
            Controls.Add(btn_SalChangeSize);
            Controls.Add(txb_SalPageSize);
            Controls.Add(lbl_SalPageSize);
            Controls.Add(lbl_SalPage);
            Controls.Add(txb_SalPage);
            Controls.Add(btn_SalLastPage);
            Controls.Add(btn_SalPrevPage);
            Controls.Add(btn_SalNextPage);
            Controls.Add(btn_SalHiddenReason);
            Controls.Add(lbl_SalesDate);
            Controls.Add(lbl_Saleskengenmei);
            Controls.Add(lbl_SalesLoginuser);
            Controls.Add(dtp_SalDate);
            Controls.Add(lbl_SalHidden);
            Controls.Add(CheckBox_SalHidden);
            Controls.Add(lbl_SalSelectForm);
            Controls.Add(btn_SalFormShow);
            Controls.Add(cmb_SalSelectForm);
            Controls.Add(btn_SalHidden);
            Controls.Add(dataGrid_Sales);
            Controls.Add(btn_SalBack);
            Controls.Add(btn_SalSearch);
            Controls.Add(btn_SalShow);
            Controls.Add(txb_SalEmpID);
            Controls.Add(txb_SalSalesOfficeID);
            Controls.Add(lbl_SalSalesID);
            Controls.Add(lbl_SalSalesOfficeID);
            Controls.Add(txb_SalSalesID);
            Controls.Add(txb_SalJOrderID);
            Controls.Add(txb_SalCstmrID);
            Controls.Add(lbl_SalEmpID);
            Controls.Add(lbl_SalJOrderID);
            Controls.Add(lbl_SalSalesDate);
            Controls.Add(lbl_SalCstmrID);
            Margin = new Padding(2);
            Name = "F_Sales";
            Text = "販売管理システム売上画面";
            Load += F_Sales_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Sales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_SalBack;
        private Button btn_SalSearch;
        private Button btn_SalShow;
        private TextBox txb_SalEmpID;
        private TextBox txb_SalSalesOfficeID;
        private Label lbl_SalSalesID;
        private Label lbl_SalSalesOfficeID;
        private TextBox txb_SalSalesID;
        private TextBox txb_SalJOrderID;
        private TextBox txb_SalCstmrID;
        private Label lbl_SalEmpID;
        private Label lbl_SalJOrderID;
        private Label lbl_SalSalesDate;
        private Label lbl_SalCstmrID;
        private DataGridView dataGrid_Sales;
        private Button btn_SalHidden;
        private Label lbl_SalSelectForm;
        private Button btn_SalFormShow;
        private ComboBox cmb_SalSelectForm;
        private Label lbl_SalHidden;
        private CheckBox CheckBox_SalHidden;
        private DateTimePicker dtp_SalDate;
        private Label lbl_SalesDate;
        private Label lbl_Saleskengenmei;
        private Label lbl_SalesLoginuser;
        private Button btn_SalHiddenReason;
        private Label lbl_SalPage;
        private TextBox txb_SalPage;
        private Button btn_SalLastPage;
        private Button btn_SalPrevPage;
        private Button btn_SalNextPage;
        private Button btn_SalChangeSize;
        private TextBox txb_SalPageSize;
        private Label lbl_SalPageSize;
        private Button btn_SalFirstPage;
        private TextBox txb_SalSalesDetailID;
        private Label lbl_SalSalesDetailID;
        private TextBox txb_SalQuantity;
        private Label lbl_SalQuantity;
        private TextBox txb_SalTotalPrice;
        private Label lbl_SalTotalPrice;
        private TextBox txb_SalSalesOfficeName;
        private Label lbl_SalSalesOfficeName;
        private TextBox txb_SalEmpName;
        private Label lbl_EmpName;
        private TextBox txb_SalCstmrName;
        private Label lbl_SalCstmrName;
        private Button btn_SalShowDetail;
        private TextBox txb_SalProductName;
        private Label lbl_SalProductName;
        private Label lbl_SalProductID;
        private TextBox txb_SalProductID;
        private Button btn_SalInputClear;
    }
}