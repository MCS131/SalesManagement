namespace SalesManagement_SysDev
{
    partial class F_Customer
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
            btn_CstmrBack = new Button();
            dataGrid_Cstmr = new DataGridView();
            txb_CstmrPhoneNum = new TextBox();
            lbl_CstmrName = new Label();
            btn_CstmrAdd = new Button();
            btn_CstmrShowList = new Button();
            lbl_CstmrFax = new Label();
            txb_CstmrPostNum = new TextBox();
            txb_CstmrAddr = new TextBox();
            lbl_CstmrPostNum = new Label();
            lbl_CstmrPhoneNum = new Label();
            lbl_CstmrAddr = new Label();
            txb_CstmrFax = new TextBox();
            lbl_CstmrSalesOfficeID = new Label();
            txb_CstmrID = new TextBox();
            lbl_CstmrID = new Label();
            btn_CstmrSearch = new Button();
            txb_CstmrSalesOfficeID = new TextBox();
            txb_CstmrName = new TextBox();
            cmb_CstmrSelectForm = new ComboBox();
            btn_CstmrFormShow = new Button();
            lbl_CstmrSelectForm = new Label();
            btn_CstmrAppdate = new Button();
            lbl_CstmrHidden = new Label();
            lbl_Cstmrkengenmei = new Label();
            lbl_CstmrLoginuser = new Label();
            lbl_CstmrDate = new Label();
            btn_CstmrHiddenReason = new Button();
            btn_CstmrNextPage = new Button();
            btn_CstmrPrevPage = new Button();
            btn_CstmrLastPage = new Button();
            txb_CstmrPage = new TextBox();
            lbl_CstmrPage = new Label();
            lbl_CstmrPageSize = new Label();
            txb_CstmrPageSize = new TextBox();
            btn_CstmrChangeSize = new Button();
            btn_CstmrFirstPage = new Button();
            CheckBox_CstmrHidden = new CheckBox();
            btn_CstmrShowSalesOffice = new Button();
            lbl_CstmrSalesOfficeName = new Label();
            txb_CstmrSalesOfficeName = new TextBox();
            btn_CstmrInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Cstmr).BeginInit();
            SuspendLayout();
            // 
            // btn_CstmrBack
            // 
            btn_CstmrBack.BackColor = Color.DarkOrange;
            btn_CstmrBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_CstmrBack.Location = new Point(1686, 26);
            btn_CstmrBack.Name = "btn_CstmrBack";
            btn_CstmrBack.Size = new Size(192, 86);
            btn_CstmrBack.TabIndex = 29;
            btn_CstmrBack.Text = "戻る";
            btn_CstmrBack.UseVisualStyleBackColor = false;
            btn_CstmrBack.Click += btn_CstmrBack_Click;
            // 
            // dataGrid_Cstmr
            // 
            dataGrid_Cstmr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Cstmr.Location = new Point(11, 473);
            dataGrid_Cstmr.Margin = new Padding(2);
            dataGrid_Cstmr.Name = "dataGrid_Cstmr";
            dataGrid_Cstmr.RowHeadersWidth = 62;
            dataGrid_Cstmr.RowTemplate.Height = 33;
            dataGrid_Cstmr.Size = new Size(1882, 520);
            dataGrid_Cstmr.TabIndex = 23;
            dataGrid_Cstmr.CellClick += dataGrid_Cstmr_CellClick;
            // 
            // txb_CstmrPhoneNum
            // 
            txb_CstmrPhoneNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrPhoneNum.Location = new Point(664, 419);
            txb_CstmrPhoneNum.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrPhoneNum.Name = "txb_CstmrPhoneNum";
            txb_CstmrPhoneNum.Size = new Size(251, 39);
            txb_CstmrPhoneNum.TabIndex = 2;
            // 
            // lbl_CstmrName
            // 
            lbl_CstmrName.AutoSize = true;
            lbl_CstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrName.Location = new Point(557, 259);
            lbl_CstmrName.Name = "lbl_CstmrName";
            lbl_CstmrName.Size = new Size(86, 32);
            lbl_CstmrName.TabIndex = 63;
            lbl_CstmrName.Text = "顧客名";
            // 
            // btn_CstmrAdd
            // 
            btn_CstmrAdd.BackColor = Color.LightPink;
            btn_CstmrAdd.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrAdd.Location = new Point(474, 114);
            btn_CstmrAdd.Margin = new Padding(3, 4, 3, 4);
            btn_CstmrAdd.Name = "btn_CstmrAdd";
            btn_CstmrAdd.Size = new Size(185, 100);
            btn_CstmrAdd.TabIndex = 9;
            btn_CstmrAdd.Text = "登録";
            btn_CstmrAdd.UseVisualStyleBackColor = false;
            btn_CstmrAdd.Click += btn_CstmrAdd_Click;
            // 
            // btn_CstmrShowList
            // 
            btn_CstmrShowList.BackColor = Color.LightPink;
            btn_CstmrShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrShowList.Location = new Point(1247, 114);
            btn_CstmrShowList.Margin = new Padding(3, 4, 3, 4);
            btn_CstmrShowList.Name = "btn_CstmrShowList";
            btn_CstmrShowList.Size = new Size(185, 100);
            btn_CstmrShowList.TabIndex = 12;
            btn_CstmrShowList.Text = "一覧表示";
            btn_CstmrShowList.UseVisualStyleBackColor = false;
            btn_CstmrShowList.Click += btn_CstmrShowList_Click;
            // 
            // lbl_CstmrFax
            // 
            lbl_CstmrFax.AutoSize = true;
            lbl_CstmrFax.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrFax.Location = new Point(947, 423);
            lbl_CstmrFax.Name = "lbl_CstmrFax";
            lbl_CstmrFax.Size = new Size(54, 32);
            lbl_CstmrFax.TabIndex = 71;
            lbl_CstmrFax.Text = "FAX";
            // 
            // txb_CstmrPostNum
            // 
            txb_CstmrPostNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrPostNum.Location = new Point(387, 370);
            txb_CstmrPostNum.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrPostNum.Name = "txb_CstmrPostNum";
            txb_CstmrPostNum.Size = new Size(161, 39);
            txb_CstmrPostNum.TabIndex = 6;
            // 
            // txb_CstmrAddr
            // 
            txb_CstmrAddr.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrAddr.Location = new Point(664, 366);
            txb_CstmrAddr.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrAddr.Name = "txb_CstmrAddr";
            txb_CstmrAddr.Size = new Size(1005, 39);
            txb_CstmrAddr.TabIndex = 7;
            // 
            // lbl_CstmrPostNum
            // 
            lbl_CstmrPostNum.AutoSize = true;
            lbl_CstmrPostNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrPostNum.Location = new Point(271, 377);
            lbl_CstmrPostNum.Name = "lbl_CstmrPostNum";
            lbl_CstmrPostNum.Size = new Size(110, 32);
            lbl_CstmrPostNum.TabIndex = 67;
            lbl_CstmrPostNum.Text = "郵便番号";
            // 
            // lbl_CstmrPhoneNum
            // 
            lbl_CstmrPhoneNum.AutoSize = true;
            lbl_CstmrPhoneNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrPhoneNum.Location = new Point(555, 423);
            lbl_CstmrPhoneNum.Name = "lbl_CstmrPhoneNum";
            lbl_CstmrPhoneNum.Size = new Size(110, 32);
            lbl_CstmrPhoneNum.TabIndex = 66;
            lbl_CstmrPhoneNum.Text = "電話番号";
            // 
            // lbl_CstmrAddr
            // 
            lbl_CstmrAddr.AutoSize = true;
            lbl_CstmrAddr.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrAddr.Location = new Point(560, 373);
            lbl_CstmrAddr.Name = "lbl_CstmrAddr";
            lbl_CstmrAddr.Size = new Size(62, 32);
            lbl_CstmrAddr.TabIndex = 65;
            lbl_CstmrAddr.Text = "住所";
            // 
            // txb_CstmrFax
            // 
            txb_CstmrFax.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrFax.Location = new Point(1023, 420);
            txb_CstmrFax.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrFax.Name = "txb_CstmrFax";
            txb_CstmrFax.Size = new Size(378, 39);
            txb_CstmrFax.TabIndex = 3;
            // 
            // lbl_CstmrSalesOfficeID
            // 
            lbl_CstmrSalesOfficeID.AutoSize = true;
            lbl_CstmrSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrSalesOfficeID.Location = new Point(274, 320);
            lbl_CstmrSalesOfficeID.Name = "lbl_CstmrSalesOfficeID";
            lbl_CstmrSalesOfficeID.Size = new Size(109, 32);
            lbl_CstmrSalesOfficeID.TabIndex = 88;
            lbl_CstmrSalesOfficeID.Text = "営業所ID";
            // 
            // txb_CstmrID
            // 
            txb_CstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrID.Location = new Point(387, 256);
            txb_CstmrID.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrID.Name = "txb_CstmrID";
            txb_CstmrID.Size = new Size(161, 39);
            txb_CstmrID.TabIndex = 1;
            txb_CstmrID.TextChanged += txb_CstmrID_TextChanged;
            // 
            // lbl_CstmrID
            // 
            lbl_CstmrID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrID.Location = new Point(271, 260);
            lbl_CstmrID.Name = "lbl_CstmrID";
            lbl_CstmrID.Size = new Size(92, 31);
            lbl_CstmrID.TabIndex = 59;
            lbl_CstmrID.Text = "顧客ID";
            lbl_CstmrID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_CstmrSearch
            // 
            btn_CstmrSearch.BackColor = Color.LightPink;
            btn_CstmrSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrSearch.Location = new Point(731, 114);
            btn_CstmrSearch.Margin = new Padding(3, 4, 3, 4);
            btn_CstmrSearch.Name = "btn_CstmrSearch";
            btn_CstmrSearch.Size = new Size(185, 100);
            btn_CstmrSearch.TabIndex = 10;
            btn_CstmrSearch.Text = "検索";
            btn_CstmrSearch.UseVisualStyleBackColor = false;
            btn_CstmrSearch.Click += btn_CstmrSearch_Click;
            // 
            // txb_CstmrSalesOfficeID
            // 
            txb_CstmrSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrSalesOfficeID.Location = new Point(387, 313);
            txb_CstmrSalesOfficeID.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrSalesOfficeID.Name = "txb_CstmrSalesOfficeID";
            txb_CstmrSalesOfficeID.Size = new Size(75, 39);
            txb_CstmrSalesOfficeID.TabIndex = 4;
            txb_CstmrSalesOfficeID.TextChanged += txb_CstmrSalesOfficeID_TextChanged;
            // 
            // txb_CstmrName
            // 
            txb_CstmrName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrName.Location = new Point(664, 256);
            txb_CstmrName.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrName.Name = "txb_CstmrName";
            txb_CstmrName.Size = new Size(1005, 39);
            txb_CstmrName.TabIndex = 5;
            // 
            // cmb_CstmrSelectForm
            // 
            cmb_CstmrSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_CstmrSelectForm.FormattingEnabled = true;
            cmb_CstmrSelectForm.ItemHeight = 32;
            cmb_CstmrSelectForm.Location = new Point(33, 66);
            cmb_CstmrSelectForm.Name = "cmb_CstmrSelectForm";
            cmb_CstmrSelectForm.Size = new Size(212, 40);
            cmb_CstmrSelectForm.TabIndex = 90;
            // 
            // btn_CstmrFormShow
            // 
            btn_CstmrFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrFormShow.Location = new Point(49, 112);
            btn_CstmrFormShow.Name = "btn_CstmrFormShow";
            btn_CstmrFormShow.Size = new Size(185, 42);
            btn_CstmrFormShow.TabIndex = 14;
            btn_CstmrFormShow.Text = "表示";
            btn_CstmrFormShow.UseVisualStyleBackColor = true;
            btn_CstmrFormShow.Click += btn_CstmrFormShow_Click;
            // 
            // lbl_CstmrSelectForm
            // 
            lbl_CstmrSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrSelectForm.Location = new Point(33, 31);
            lbl_CstmrSelectForm.Name = "lbl_CstmrSelectForm";
            lbl_CstmrSelectForm.Size = new Size(228, 29);
            lbl_CstmrSelectForm.TabIndex = 93;
            lbl_CstmrSelectForm.Text = "利用可能な画面選択";
            lbl_CstmrSelectForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_CstmrAppdate
            // 
            btn_CstmrAppdate.BackColor = Color.LightPink;
            btn_CstmrAppdate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrAppdate.Location = new Point(989, 114);
            btn_CstmrAppdate.Margin = new Padding(3, 4, 3, 4);
            btn_CstmrAppdate.Name = "btn_CstmrAppdate";
            btn_CstmrAppdate.Size = new Size(185, 100);
            btn_CstmrAppdate.TabIndex = 11;
            btn_CstmrAppdate.Text = "更新";
            btn_CstmrAppdate.UseVisualStyleBackColor = false;
            btn_CstmrAppdate.Click += btn_CstmrAppdate_Click;
            // 
            // lbl_CstmrHidden
            // 
            lbl_CstmrHidden.AutoSize = true;
            lbl_CstmrHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrHidden.Location = new Point(12, 433);
            lbl_CstmrHidden.Name = "lbl_CstmrHidden";
            lbl_CstmrHidden.Size = new Size(86, 32);
            lbl_CstmrHidden.TabIndex = 95;
            lbl_CstmrHidden.Text = "非表示";
            // 
            // lbl_Cstmrkengenmei
            // 
            lbl_Cstmrkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Cstmrkengenmei.Location = new Point(791, 43);
            lbl_Cstmrkengenmei.Name = "lbl_Cstmrkengenmei";
            lbl_Cstmrkengenmei.Size = new Size(324, 33);
            lbl_Cstmrkengenmei.TabIndex = 98;
            lbl_Cstmrkengenmei.Text = "権限名：";
            lbl_Cstmrkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_CstmrLoginuser
            // 
            lbl_CstmrLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_CstmrLoginuser.Location = new Point(401, 43);
            lbl_CstmrLoginuser.Name = "lbl_CstmrLoginuser";
            lbl_CstmrLoginuser.Size = new Size(384, 33);
            lbl_CstmrLoginuser.TabIndex = 99;
            lbl_CstmrLoginuser.Text = "ログインユーザー：";
            lbl_CstmrLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_CstmrDate
            // 
            lbl_CstmrDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_CstmrDate.Location = new Point(1121, 43);
            lbl_CstmrDate.Name = "lbl_CstmrDate";
            lbl_CstmrDate.Size = new Size(354, 33);
            lbl_CstmrDate.TabIndex = 100;
            lbl_CstmrDate.Text = "日付：";
            lbl_CstmrDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_CstmrHiddenReason
            // 
            btn_CstmrHiddenReason.BackColor = Color.PeachPuff;
            btn_CstmrHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrHiddenReason.Location = new Point(127, 430);
            btn_CstmrHiddenReason.Name = "btn_CstmrHiddenReason";
            btn_CstmrHiddenReason.Size = new Size(153, 36);
            btn_CstmrHiddenReason.TabIndex = 147;
            btn_CstmrHiddenReason.Text = "非表示理由";
            btn_CstmrHiddenReason.UseVisualStyleBackColor = false;
            btn_CstmrHiddenReason.Click += btn_CstmrHiddenReason_Click;
            // 
            // btn_CstmrNextPage
            // 
            btn_CstmrNextPage.Location = new Point(1815, 998);
            btn_CstmrNextPage.Name = "btn_CstmrNextPage";
            btn_CstmrNextPage.Size = new Size(38, 31);
            btn_CstmrNextPage.TabIndex = 148;
            btn_CstmrNextPage.Text = "▶️";
            btn_CstmrNextPage.UseVisualStyleBackColor = true;
            btn_CstmrNextPage.Click += btn_CstmrNextPage_Click;
            // 
            // btn_CstmrPrevPage
            // 
            btn_CstmrPrevPage.Location = new Point(1778, 998);
            btn_CstmrPrevPage.Name = "btn_CstmrPrevPage";
            btn_CstmrPrevPage.Size = new Size(38, 31);
            btn_CstmrPrevPage.TabIndex = 149;
            btn_CstmrPrevPage.Text = "◀️";
            btn_CstmrPrevPage.UseVisualStyleBackColor = true;
            btn_CstmrPrevPage.Click += btn_CstmrPrevPage_Click;
            // 
            // btn_CstmrLastPage
            // 
            btn_CstmrLastPage.Location = new Point(1855, 998);
            btn_CstmrLastPage.Name = "btn_CstmrLastPage";
            btn_CstmrLastPage.Size = new Size(38, 31);
            btn_CstmrLastPage.TabIndex = 150;
            btn_CstmrLastPage.Text = "➜";
            btn_CstmrLastPage.UseVisualStyleBackColor = true;
            btn_CstmrLastPage.Click += btn_CstmrLastPage_Click;
            // 
            // txb_CstmrPage
            // 
            txb_CstmrPage.Location = new Point(1609, 1003);
            txb_CstmrPage.Name = "txb_CstmrPage";
            txb_CstmrPage.Size = new Size(51, 23);
            txb_CstmrPage.TabIndex = 151;
            // 
            // lbl_CstmrPage
            // 
            lbl_CstmrPage.AutoSize = true;
            lbl_CstmrPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrPage.Location = new Point(1666, 1003);
            lbl_CstmrPage.Name = "lbl_CstmrPage";
            lbl_CstmrPage.Size = new Size(46, 21);
            lbl_CstmrPage.TabIndex = 152;
            lbl_CstmrPage.Text = "ページ";
            // 
            // lbl_CstmrPageSize
            // 
            lbl_CstmrPageSize.AutoSize = true;
            lbl_CstmrPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrPageSize.Location = new Point(12, 1008);
            lbl_CstmrPageSize.Name = "lbl_CstmrPageSize";
            lbl_CstmrPageSize.Size = new Size(87, 21);
            lbl_CstmrPageSize.TabIndex = 153;
            lbl_CstmrPageSize.Text = "1ページ行数";
            // 
            // txb_CstmrPageSize
            // 
            txb_CstmrPageSize.Location = new Point(105, 1008);
            txb_CstmrPageSize.Name = "txb_CstmrPageSize";
            txb_CstmrPageSize.Size = new Size(51, 23);
            txb_CstmrPageSize.TabIndex = 154;
            // 
            // btn_CstmrChangeSize
            // 
            btn_CstmrChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrChangeSize.Location = new Point(171, 1008);
            btn_CstmrChangeSize.Name = "btn_CstmrChangeSize";
            btn_CstmrChangeSize.Size = new Size(99, 26);
            btn_CstmrChangeSize.TabIndex = 155;
            btn_CstmrChangeSize.Text = "行数変更";
            btn_CstmrChangeSize.UseVisualStyleBackColor = true;
            btn_CstmrChangeSize.Click += btn_CstmrChangeSize_Click;
            // 
            // btn_CstmrFirstPage
            // 
            btn_CstmrFirstPage.Location = new Point(1734, 998);
            btn_CstmrFirstPage.Name = "btn_CstmrFirstPage";
            btn_CstmrFirstPage.Size = new Size(38, 31);
            btn_CstmrFirstPage.TabIndex = 156;
            btn_CstmrFirstPage.Text = "|";
            btn_CstmrFirstPage.UseVisualStyleBackColor = true;
            btn_CstmrFirstPage.Click += btn_CstmrFirstPage_Click;
            // 
            // CheckBox_CstmrHidden
            // 
            CheckBox_CstmrHidden.AutoSize = true;
            CheckBox_CstmrHidden.BackColor = Color.Transparent;
            CheckBox_CstmrHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_CstmrHidden.Location = new Point(98, 444);
            CheckBox_CstmrHidden.Name = "CheckBox_CstmrHidden";
            CheckBox_CstmrHidden.Size = new Size(15, 14);
            CheckBox_CstmrHidden.TabIndex = 8;
            CheckBox_CstmrHidden.UseVisualStyleBackColor = false;
            // 
            // btn_CstmrShowSalesOffice
            // 
            btn_CstmrShowSalesOffice.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrShowSalesOffice.Location = new Point(468, 316);
            btn_CstmrShowSalesOffice.Name = "btn_CstmrShowSalesOffice";
            btn_CstmrShowSalesOffice.Size = new Size(80, 36);
            btn_CstmrShowSalesOffice.TabIndex = 157;
            btn_CstmrShowSalesOffice.Text = "営業所一覧";
            btn_CstmrShowSalesOffice.UseVisualStyleBackColor = true;
            btn_CstmrShowSalesOffice.Click += btn_CstmrShowSalesOffice_Click;
            // 
            // lbl_CstmrSalesOfficeName
            // 
            lbl_CstmrSalesOfficeName.AutoSize = true;
            lbl_CstmrSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_CstmrSalesOfficeName.Location = new Point(557, 316);
            lbl_CstmrSalesOfficeName.Name = "lbl_CstmrSalesOfficeName";
            lbl_CstmrSalesOfficeName.Size = new Size(110, 32);
            lbl_CstmrSalesOfficeName.TabIndex = 158;
            lbl_CstmrSalesOfficeName.Text = "営業所名";
            // 
            // txb_CstmrSalesOfficeName
            // 
            txb_CstmrSalesOfficeName.Enabled = false;
            txb_CstmrSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_CstmrSalesOfficeName.Location = new Point(664, 311);
            txb_CstmrSalesOfficeName.Margin = new Padding(3, 4, 3, 4);
            txb_CstmrSalesOfficeName.Name = "txb_CstmrSalesOfficeName";
            txb_CstmrSalesOfficeName.Size = new Size(359, 39);
            txb_CstmrSalesOfficeName.TabIndex = 159;
            // 
            // btn_CstmrInputClear
            // 
            btn_CstmrInputClear.BackColor = Color.PeachPuff;
            btn_CstmrInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_CstmrInputClear.Location = new Point(1725, 398);
            btn_CstmrInputClear.Name = "btn_CstmrInputClear";
            btn_CstmrInputClear.Size = new Size(153, 60);
            btn_CstmrInputClear.TabIndex = 160;
            btn_CstmrInputClear.Text = "入力クリア";
            btn_CstmrInputClear.UseVisualStyleBackColor = false;
            btn_CstmrInputClear.Click += btn_CstmrInputClear_Click;
            // 
            // F_Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_CstmrInputClear);
            Controls.Add(txb_CstmrSalesOfficeName);
            Controls.Add(lbl_CstmrSalesOfficeName);
            Controls.Add(btn_CstmrShowSalesOffice);
            Controls.Add(CheckBox_CstmrHidden);
            Controls.Add(btn_CstmrFirstPage);
            Controls.Add(btn_CstmrChangeSize);
            Controls.Add(txb_CstmrPageSize);
            Controls.Add(lbl_CstmrPageSize);
            Controls.Add(lbl_CstmrPage);
            Controls.Add(txb_CstmrPage);
            Controls.Add(btn_CstmrLastPage);
            Controls.Add(btn_CstmrPrevPage);
            Controls.Add(btn_CstmrNextPage);
            Controls.Add(btn_CstmrHiddenReason);
            Controls.Add(lbl_CstmrDate);
            Controls.Add(lbl_CstmrLoginuser);
            Controls.Add(lbl_Cstmrkengenmei);
            Controls.Add(lbl_CstmrHidden);
            Controls.Add(btn_CstmrAppdate);
            Controls.Add(lbl_CstmrSelectForm);
            Controls.Add(btn_CstmrFormShow);
            Controls.Add(cmb_CstmrSelectForm);
            Controls.Add(txb_CstmrName);
            Controls.Add(txb_CstmrSalesOfficeID);
            Controls.Add(btn_CstmrBack);
            Controls.Add(dataGrid_Cstmr);
            Controls.Add(txb_CstmrPhoneNum);
            Controls.Add(btn_CstmrAdd);
            Controls.Add(btn_CstmrShowList);
            Controls.Add(lbl_CstmrFax);
            Controls.Add(txb_CstmrPostNum);
            Controls.Add(txb_CstmrAddr);
            Controls.Add(lbl_CstmrPostNum);
            Controls.Add(lbl_CstmrPhoneNum);
            Controls.Add(lbl_CstmrAddr);
            Controls.Add(txb_CstmrFax);
            Controls.Add(lbl_CstmrName);
            Controls.Add(lbl_CstmrSalesOfficeID);
            Controls.Add(txb_CstmrID);
            Controls.Add(lbl_CstmrID);
            Controls.Add(btn_CstmrSearch);
            Name = "F_Customer";
            Text = "販売管理システム顧客画面";
            Load += F_Customer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Cstmr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox Check_CstmrHidden;
        private Button btn_CstmrBack;
        private DataGridView dataGrid_Cstmr;
        private TextBox txb_CstmrPhoneNum;
        private TextBox textBox7;
        private Button btn_CstmrAdd;
        private Button btn_CstmrShowList;
        private Label lbl_CstmrFax;
        private TextBox txb_CstmrPostNum;
        private TextBox txb_CstmrAddr;
        private Label lbl_CstmrPostNum;
        private Label lbl_CstmrPhoneNum;
        private Label lbl_CstmrAddr;
        private TextBox txb_CstmrFax;
        private Label lbl_CstmrName;
        private TextBox textBox2;
        private TextBox txb_CstmrID;
        private Label lbl_CstmrID;
        private Button btn_CstmrSearch;
        private Label lbl_CstmrSalesOfficeID;
        private TextBox txb_CstmrSalesOfficeID;
        private TextBox txb_CstmrName;
        private ComboBox cmb_CstmrSelectForm;
        private Button btn_CstmrFormShow;
        private Label lbl_CstmrSelectForm;
        private Button btn_CstmrAppdate;
        private Label lbl_CstmrHidden;
        private Label lbl_Cstmrkengenmei;
        private Label lbl_CstmrLoginuser;
        private Label lbl_CstmrDate;
        private Button btn_CstmrHiddenReason;
        private Button btn_CstmrNextPage;
        private Button btn_CstmrPrevPage;
        private Button btn_CstmrLastPage;
        private TextBox txb_CstmrPage;
        private Label lbl_CstmrPage;
        private Label lbl_CstmrPageSize;
        private TextBox txb_CstmrPageSize;
        private Button btn_CstmrChangeSize;
        private Button btn_CstmrFirstPage;
        private CheckBox CheckBox_CstmrHidden;
        private Button btn_CstmrShowSalesOffice;
        private Label lbl_CstmrSalesOfficeName;
        private TextBox txb_CstmrSalesOfficeName;
        private Button btn_CstmrInputClear;
    }
}