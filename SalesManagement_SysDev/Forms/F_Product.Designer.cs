namespace SalesManagement_SysDev
{
    partial class F_Product
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
            btn_ProdBack = new Button();
            dataGrid_Prod = new DataGridView();
            txb_ProdMinNum = new TextBox();
            lbl_ProdMinNum = new Label();
            btn_ProdAdd = new Button();
            btn_ProdShow = new Button();
            txb_ProdSmallDivID = new TextBox();
            txb_ProdPrice = new TextBox();
            txb_ProdMakerID = new TextBox();
            lbl_ProdSmallDivID = new Label();
            lbl_ProdPrice = new Label();
            lbl_ProdMakerID = new Label();
            txb_ProdSerialNum = new TextBox();
            lbl_ProdSerialNum = new Label();
            lbl_ProdPrdctName = new Label();
            txb_ProdPrdctName = new TextBox();
            txb_ProdPrdctID = new TextBox();
            lbl_ProdPrdctID = new Label();
            btn_ProdSearch = new Button();
            lbl_ProdColor = new Label();
            lbl_ProdReleaseDate = new Label();
            txb_ProdColor = new TextBox();
            btn_ProdHidden = new Button();
            cmb_ProdSelectForm = new ComboBox();
            lbl_ProdSelectForm = new Label();
            btn_ProdFormShow = new Button();
            lbl_ProdLoginuser = new Label();
            lbl_Prodkengenmei = new Label();
            lbl_ProdDate = new Label();
            dtp_ProdDate = new DateTimePicker();
            CheckBox_ProdHidden = new CheckBox();
            lbl_ProdHidden = new Label();
            btn_ProdHiddenReason = new Button();
            lbl_ProdPage = new Label();
            txb_ProdPage = new TextBox();
            btn_ProdLastPage = new Button();
            btn_ProdPrevPage = new Button();
            btn_ProdNextPage = new Button();
            btn_ProdChangeSize = new Button();
            txb_ProdPageSize = new TextBox();
            lbl_ProdPageSize = new Label();
            btn_ProdFirstPage = new Button();
            btn_ProdShowMakerID = new Button();
            btn_ProdShowSmallDivID = new Button();
            lbl_ProdMaName = new Label();
            txb_ProdMaName = new TextBox();
            lbl_ProdSmallDivName = new Label();
            txb_ProdSmallDivName = new TextBox();
            btn_ProdInputClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Prod).BeginInit();
            SuspendLayout();
            // 
            // btn_ProdBack
            // 
            btn_ProdBack.BackColor = Color.DarkOrange;
            btn_ProdBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ProdBack.Location = new Point(1686, 26);
            btn_ProdBack.Margin = new Padding(2);
            btn_ProdBack.Name = "btn_ProdBack";
            btn_ProdBack.Size = new Size(192, 86);
            btn_ProdBack.TabIndex = 110;
            btn_ProdBack.Text = "戻る";
            btn_ProdBack.UseVisualStyleBackColor = false;
            btn_ProdBack.Click += btn_ProdBack_Click;
            // 
            // dataGrid_Prod
            // 
            dataGrid_Prod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Prod.Location = new Point(10, 473);
            dataGrid_Prod.Margin = new Padding(2);
            dataGrid_Prod.Name = "dataGrid_Prod";
            dataGrid_Prod.RowHeadersWidth = 62;
            dataGrid_Prod.RowTemplate.Height = 33;
            dataGrid_Prod.Size = new Size(1882, 520);
            dataGrid_Prod.TabIndex = 104;
            dataGrid_Prod.CellClick += dataGrid_Prod_CellClick;
            // 
            // txb_ProdMinNum
            // 
            txb_ProdMinNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdMinNum.Location = new Point(1011, 313);
            txb_ProdMinNum.Margin = new Padding(2);
            txb_ProdMinNum.Name = "txb_ProdMinNum";
            txb_ProdMinNum.Size = new Size(150, 39);
            txb_ProdMinNum.TabIndex = 7;
            // 
            // lbl_ProdMinNum
            // 
            lbl_ProdMinNum.AutoSize = true;
            lbl_ProdMinNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdMinNum.Location = new Point(856, 316);
            lbl_ProdMinNum.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdMinNum.Name = "lbl_ProdMinNum";
            lbl_ProdMinNum.Size = new Size(134, 32);
            lbl_ProdMinNum.TabIndex = 101;
            lbl_ProdMinNum.Text = "安全在庫数";
            // 
            // btn_ProdAdd
            // 
            btn_ProdAdd.BackColor = Color.LightPink;
            btn_ProdAdd.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdAdd.Location = new Point(474, 114);
            btn_ProdAdd.Margin = new Padding(2);
            btn_ProdAdd.Name = "btn_ProdAdd";
            btn_ProdAdd.Size = new Size(185, 100);
            btn_ProdAdd.TabIndex = 14;
            btn_ProdAdd.Text = "登録";
            btn_ProdAdd.UseVisualStyleBackColor = false;
            btn_ProdAdd.Click += btn_ProdAdd_Click;
            // 
            // btn_ProdShow
            // 
            btn_ProdShow.BackColor = Color.LightPink;
            btn_ProdShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdShow.Location = new Point(1247, 114);
            btn_ProdShow.Margin = new Padding(2);
            btn_ProdShow.Name = "btn_ProdShow";
            btn_ProdShow.Size = new Size(185, 100);
            btn_ProdShow.TabIndex = 17;
            btn_ProdShow.Text = "一覧表示";
            btn_ProdShow.UseVisualStyleBackColor = false;
            btn_ProdShow.Click += btn_ProdShow_Click;
            // 
            // txb_ProdSmallDivID
            // 
            txb_ProdSmallDivID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdSmallDivID.Location = new Point(301, 375);
            txb_ProdSmallDivID.Margin = new Padding(2);
            txb_ProdSmallDivID.Name = "txb_ProdSmallDivID";
            txb_ProdSmallDivID.Size = new Size(86, 39);
            txb_ProdSmallDivID.TabIndex = 8;
            txb_ProdSmallDivID.TextChanged += txb_ProdSmallDivID_TextChanged;
            // 
            // txb_ProdPrice
            // 
            txb_ProdPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdPrice.Location = new Point(681, 313);
            txb_ProdPrice.Margin = new Padding(2);
            txb_ProdPrice.Name = "txb_ProdPrice";
            txb_ProdPrice.Size = new Size(150, 39);
            txb_ProdPrice.TabIndex = 6;
            // 
            // txb_ProdMakerID
            // 
            txb_ProdMakerID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdMakerID.Location = new Point(601, 239);
            txb_ProdMakerID.Margin = new Padding(2);
            txb_ProdMakerID.Name = "txb_ProdMakerID";
            txb_ProdMakerID.Size = new Size(139, 39);
            txb_ProdMakerID.TabIndex = 2;
            txb_ProdMakerID.TextChanged += txb_ProdMakerID_TextChanged;
            // 
            // lbl_ProdSmallDivID
            // 
            lbl_ProdSmallDivID.AutoSize = true;
            lbl_ProdSmallDivID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdSmallDivID.Location = new Point(161, 378);
            lbl_ProdSmallDivID.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdSmallDivID.Name = "lbl_ProdSmallDivID";
            lbl_ProdSmallDivID.Size = new Size(109, 32);
            lbl_ProdSmallDivID.TabIndex = 94;
            lbl_ProdSmallDivID.Text = "小分類ID";
            // 
            // lbl_ProdPrice
            // 
            lbl_ProdPrice.AutoSize = true;
            lbl_ProdPrice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdPrice.Location = new Point(573, 316);
            lbl_ProdPrice.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdPrice.Name = "lbl_ProdPrice";
            lbl_ProdPrice.Size = new Size(62, 32);
            lbl_ProdPrice.TabIndex = 93;
            lbl_ProdPrice.Text = "価格";
            // 
            // lbl_ProdMakerID
            // 
            lbl_ProdMakerID.AutoSize = true;
            lbl_ProdMakerID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdMakerID.Location = new Point(479, 242);
            lbl_ProdMakerID.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdMakerID.Name = "lbl_ProdMakerID";
            lbl_ProdMakerID.Size = new Size(102, 32);
            lbl_ProdMakerID.TabIndex = 92;
            lbl_ProdMakerID.Text = "メーカーID";
            // 
            // txb_ProdSerialNum
            // 
            txb_ProdSerialNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdSerialNum.Location = new Point(1231, 379);
            txb_ProdSerialNum.Margin = new Padding(2);
            txb_ProdSerialNum.Name = "txb_ProdSerialNum";
            txb_ProdSerialNum.Size = new Size(309, 39);
            txb_ProdSerialNum.TabIndex = 11;
            // 
            // lbl_ProdSerialNum
            // 
            lbl_ProdSerialNum.AutoSize = true;
            lbl_ProdSerialNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdSerialNum.Location = new Point(1158, 382);
            lbl_ProdSerialNum.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdSerialNum.Name = "lbl_ProdSerialNum";
            lbl_ProdSerialNum.Size = new Size(62, 32);
            lbl_ProdSerialNum.TabIndex = 90;
            lbl_ProdSerialNum.Text = "型番";
            // 
            // lbl_ProdPrdctName
            // 
            lbl_ProdPrdctName.AutoSize = true;
            lbl_ProdPrdctName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdPrdctName.Location = new Point(1141, 242);
            lbl_ProdPrdctName.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdPrdctName.Name = "lbl_ProdPrdctName";
            lbl_ProdPrdctName.Size = new Size(86, 32);
            lbl_ProdPrdctName.TabIndex = 89;
            lbl_ProdPrdctName.Text = "商品名";
            // 
            // txb_ProdPrdctName
            // 
            txb_ProdPrdctName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdPrdctName.Location = new Point(1231, 239);
            txb_ProdPrdctName.Margin = new Padding(2);
            txb_ProdPrdctName.Name = "txb_ProdPrdctName";
            txb_ProdPrdctName.Size = new Size(400, 39);
            txb_ProdPrdctName.TabIndex = 4;
            // 
            // txb_ProdPrdctID
            // 
            txb_ProdPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdPrdctID.Location = new Point(301, 239);
            txb_ProdPrdctID.Margin = new Padding(2);
            txb_ProdPrdctID.Name = "txb_ProdPrdctID";
            txb_ProdPrdctID.Size = new Size(166, 39);
            txb_ProdPrdctID.TabIndex = 1;
            // 
            // lbl_ProdPrdctID
            // 
            lbl_ProdPrdctID.AutoSize = true;
            lbl_ProdPrdctID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdPrdctID.Location = new Point(185, 242);
            lbl_ProdPrdctID.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdPrdctID.Name = "lbl_ProdPrdctID";
            lbl_ProdPrdctID.Size = new Size(85, 32);
            lbl_ProdPrdctID.TabIndex = 86;
            lbl_ProdPrdctID.Text = "商品ID";
            // 
            // btn_ProdSearch
            // 
            btn_ProdSearch.BackColor = Color.LightPink;
            btn_ProdSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdSearch.Location = new Point(731, 114);
            btn_ProdSearch.Margin = new Padding(2);
            btn_ProdSearch.Name = "btn_ProdSearch";
            btn_ProdSearch.Size = new Size(185, 100);
            btn_ProdSearch.TabIndex = 15;
            btn_ProdSearch.Text = "検索";
            btn_ProdSearch.UseVisualStyleBackColor = false;
            btn_ProdSearch.Click += btn_ProdSearch_Click;
            // 
            // lbl_ProdColor
            // 
            lbl_ProdColor.AutoSize = true;
            lbl_ProdColor.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdColor.Location = new Point(729, 382);
            lbl_ProdColor.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdColor.Name = "lbl_ProdColor";
            lbl_ProdColor.Size = new Size(38, 32);
            lbl_ProdColor.TabIndex = 112;
            lbl_ProdColor.Text = "色";
            // 
            // lbl_ProdReleaseDate
            // 
            lbl_ProdReleaseDate.AutoSize = true;
            lbl_ProdReleaseDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdReleaseDate.Location = new Point(194, 316);
            lbl_ProdReleaseDate.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdReleaseDate.Name = "lbl_ProdReleaseDate";
            lbl_ProdReleaseDate.Size = new Size(86, 32);
            lbl_ProdReleaseDate.TabIndex = 113;
            lbl_ProdReleaseDate.Text = "発売日";
            // 
            // txb_ProdColor
            // 
            txb_ProdColor.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdColor.Location = new Point(779, 379);
            txb_ProdColor.Margin = new Padding(2);
            txb_ProdColor.Name = "txb_ProdColor";
            txb_ProdColor.Size = new Size(348, 39);
            txb_ProdColor.TabIndex = 10;
            // 
            // btn_ProdHidden
            // 
            btn_ProdHidden.BackColor = Color.LightPink;
            btn_ProdHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdHidden.Location = new Point(989, 114);
            btn_ProdHidden.Margin = new Padding(2);
            btn_ProdHidden.Name = "btn_ProdHidden";
            btn_ProdHidden.Size = new Size(185, 100);
            btn_ProdHidden.TabIndex = 16;
            btn_ProdHidden.Text = "非表示更新";
            btn_ProdHidden.UseVisualStyleBackColor = false;
            btn_ProdHidden.Click += btn_ProdHidden_Click;
            // 
            // cmb_ProdSelectForm
            // 
            cmb_ProdSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_ProdSelectForm.FormattingEnabled = true;
            cmb_ProdSelectForm.Location = new Point(33, 66);
            cmb_ProdSelectForm.Name = "cmb_ProdSelectForm";
            cmb_ProdSelectForm.Size = new Size(227, 40);
            cmb_ProdSelectForm.TabIndex = 123;
            // 
            // lbl_ProdSelectForm
            // 
            lbl_ProdSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdSelectForm.Location = new Point(33, 31);
            lbl_ProdSelectForm.Name = "lbl_ProdSelectForm";
            lbl_ProdSelectForm.Size = new Size(237, 33);
            lbl_ProdSelectForm.TabIndex = 125;
            lbl_ProdSelectForm.Text = "利用可能な画面選択";
            lbl_ProdSelectForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_ProdFormShow
            // 
            btn_ProdFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdFormShow.Location = new Point(49, 112);
            btn_ProdFormShow.Name = "btn_ProdFormShow";
            btn_ProdFormShow.Size = new Size(192, 42);
            btn_ProdFormShow.TabIndex = 124;
            btn_ProdFormShow.Text = "表示";
            btn_ProdFormShow.UseVisualStyleBackColor = true;
            btn_ProdFormShow.Click += btn_ProdFormShow_Click;
            // 
            // lbl_ProdLoginuser
            // 
            lbl_ProdLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProdLoginuser.Location = new Point(401, 43);
            lbl_ProdLoginuser.Name = "lbl_ProdLoginuser";
            lbl_ProdLoginuser.Size = new Size(384, 33);
            lbl_ProdLoginuser.TabIndex = 126;
            lbl_ProdLoginuser.Text = "ログインユーザー：";
            lbl_ProdLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Prodkengenmei
            // 
            lbl_Prodkengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Prodkengenmei.Location = new Point(791, 43);
            lbl_Prodkengenmei.Name = "lbl_Prodkengenmei";
            lbl_Prodkengenmei.Size = new Size(324, 33);
            lbl_Prodkengenmei.TabIndex = 127;
            lbl_Prodkengenmei.Text = "権限名：";
            lbl_Prodkengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ProdDate
            // 
            lbl_ProdDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProdDate.Location = new Point(1121, 43);
            lbl_ProdDate.Name = "lbl_ProdDate";
            lbl_ProdDate.Size = new Size(354, 33);
            lbl_ProdDate.TabIndex = 128;
            lbl_ProdDate.Text = "日付：";
            lbl_ProdDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtp_ProdDate
            // 
            dtp_ProdDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_ProdDate.Location = new Point(301, 311);
            dtp_ProdDate.Margin = new Padding(2);
            dtp_ProdDate.Name = "dtp_ProdDate";
            dtp_ProdDate.Size = new Size(226, 39);
            dtp_ProdDate.TabIndex = 5;
            // 
            // CheckBox_ProdHidden
            // 
            CheckBox_ProdHidden.AutoSize = true;
            CheckBox_ProdHidden.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_ProdHidden.Location = new Point(98, 444);
            CheckBox_ProdHidden.Margin = new Padding(2);
            CheckBox_ProdHidden.Name = "CheckBox_ProdHidden";
            CheckBox_ProdHidden.Size = new Size(15, 14);
            CheckBox_ProdHidden.TabIndex = 12;
            CheckBox_ProdHidden.UseVisualStyleBackColor = true;
            // 
            // lbl_ProdHidden
            // 
            lbl_ProdHidden.AutoSize = true;
            lbl_ProdHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdHidden.Location = new Point(12, 433);
            lbl_ProdHidden.Name = "lbl_ProdHidden";
            lbl_ProdHidden.Size = new Size(86, 32);
            lbl_ProdHidden.TabIndex = 130;
            lbl_ProdHidden.Text = "非表示";
            // 
            // btn_ProdHiddenReason
            // 
            btn_ProdHiddenReason.BackColor = Color.PeachPuff;
            btn_ProdHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdHiddenReason.Location = new Point(127, 430);
            btn_ProdHiddenReason.Name = "btn_ProdHiddenReason";
            btn_ProdHiddenReason.Size = new Size(153, 36);
            btn_ProdHiddenReason.TabIndex = 13;
            btn_ProdHiddenReason.Text = "非表示理由";
            btn_ProdHiddenReason.UseVisualStyleBackColor = false;
            btn_ProdHiddenReason.Click += btn_ProdHiddenReason_Click;
            // 
            // lbl_ProdPage
            // 
            lbl_ProdPage.AutoSize = true;
            lbl_ProdPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdPage.Location = new Point(1666, 1003);
            lbl_ProdPage.Name = "lbl_ProdPage";
            lbl_ProdPage.Size = new Size(46, 21);
            lbl_ProdPage.TabIndex = 157;
            lbl_ProdPage.Text = "ページ";
            // 
            // txb_ProdPage
            // 
            txb_ProdPage.Location = new Point(1609, 1003);
            txb_ProdPage.Name = "txb_ProdPage";
            txb_ProdPage.Size = new Size(51, 23);
            txb_ProdPage.TabIndex = 156;
            // 
            // btn_ProdLastPage
            // 
            btn_ProdLastPage.Location = new Point(1854, 998);
            btn_ProdLastPage.Name = "btn_ProdLastPage";
            btn_ProdLastPage.Size = new Size(38, 31);
            btn_ProdLastPage.TabIndex = 155;
            btn_ProdLastPage.Text = "➜";
            btn_ProdLastPage.UseVisualStyleBackColor = true;
            btn_ProdLastPage.Click += btn_ProdLastPage_Click;
            // 
            // btn_ProdPrevPage
            // 
            btn_ProdPrevPage.Location = new Point(1774, 998);
            btn_ProdPrevPage.Name = "btn_ProdPrevPage";
            btn_ProdPrevPage.Size = new Size(38, 31);
            btn_ProdPrevPage.TabIndex = 154;
            btn_ProdPrevPage.Text = "◀️";
            btn_ProdPrevPage.UseVisualStyleBackColor = true;
            btn_ProdPrevPage.Click += btn_ProdPrevPage_Click;
            // 
            // btn_ProdNextPage
            // 
            btn_ProdNextPage.Location = new Point(1814, 998);
            btn_ProdNextPage.Name = "btn_ProdNextPage";
            btn_ProdNextPage.Size = new Size(38, 31);
            btn_ProdNextPage.TabIndex = 153;
            btn_ProdNextPage.Text = "▶️";
            btn_ProdNextPage.UseVisualStyleBackColor = true;
            btn_ProdNextPage.Click += btn_ProdNextPage_Click;
            // 
            // btn_ProdChangeSize
            // 
            btn_ProdChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdChangeSize.Location = new Point(171, 1008);
            btn_ProdChangeSize.Name = "btn_ProdChangeSize";
            btn_ProdChangeSize.Size = new Size(99, 26);
            btn_ProdChangeSize.TabIndex = 160;
            btn_ProdChangeSize.Text = "行数変更";
            btn_ProdChangeSize.UseVisualStyleBackColor = true;
            btn_ProdChangeSize.Click += btn_ProdChangeSize_Click;
            // 
            // txb_ProdPageSize
            // 
            txb_ProdPageSize.Location = new Point(105, 1008);
            txb_ProdPageSize.Name = "txb_ProdPageSize";
            txb_ProdPageSize.Size = new Size(51, 23);
            txb_ProdPageSize.TabIndex = 159;
            // 
            // lbl_ProdPageSize
            // 
            lbl_ProdPageSize.AutoSize = true;
            lbl_ProdPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdPageSize.Location = new Point(12, 1008);
            lbl_ProdPageSize.Name = "lbl_ProdPageSize";
            lbl_ProdPageSize.Size = new Size(87, 21);
            lbl_ProdPageSize.TabIndex = 158;
            lbl_ProdPageSize.Text = "1ページ行数";
            // 
            // btn_ProdFirstPage
            // 
            btn_ProdFirstPage.Location = new Point(1734, 998);
            btn_ProdFirstPage.Name = "btn_ProdFirstPage";
            btn_ProdFirstPage.Size = new Size(38, 31);
            btn_ProdFirstPage.TabIndex = 161;
            btn_ProdFirstPage.Text = "|";
            btn_ProdFirstPage.UseVisualStyleBackColor = true;
            btn_ProdFirstPage.Click += btn_ProdFirstPage_Click;
            // 
            // btn_ProdShowMakerID
            // 
            btn_ProdShowMakerID.Location = new Point(752, 239);
            btn_ProdShowMakerID.Name = "btn_ProdShowMakerID";
            btn_ProdShowMakerID.Size = new Size(75, 39);
            btn_ProdShowMakerID.TabIndex = 162;
            btn_ProdShowMakerID.Text = "メーカー一覧";
            btn_ProdShowMakerID.UseVisualStyleBackColor = true;
            btn_ProdShowMakerID.Click += btn_ProdShowMakerID_Click;
            // 
            // btn_ProdShowSmallDivID
            // 
            btn_ProdShowSmallDivID.Location = new Point(392, 375);
            btn_ProdShowSmallDivID.Name = "btn_ProdShowSmallDivID";
            btn_ProdShowSmallDivID.Size = new Size(75, 39);
            btn_ProdShowSmallDivID.TabIndex = 163;
            btn_ProdShowSmallDivID.Text = "分類一覧";
            btn_ProdShowSmallDivID.UseVisualStyleBackColor = true;
            btn_ProdShowSmallDivID.Click += btn_ProdShowSmallDivID_Click;
            // 
            // lbl_ProdMaName
            // 
            lbl_ProdMaName.AutoSize = true;
            lbl_ProdMaName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdMaName.Location = new Point(858, 242);
            lbl_ProdMaName.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdMaName.Name = "lbl_ProdMaName";
            lbl_ProdMaName.Size = new Size(103, 32);
            lbl_ProdMaName.TabIndex = 164;
            lbl_ProdMaName.Text = "メーカー名";
            // 
            // txb_ProdMaName
            // 
            txb_ProdMaName.Enabled = false;
            txb_ProdMaName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdMaName.Location = new Point(966, 239);
            txb_ProdMaName.Margin = new Padding(2);
            txb_ProdMaName.Name = "txb_ProdMaName";
            txb_ProdMaName.Size = new Size(150, 39);
            txb_ProdMaName.TabIndex = 3;
            // 
            // lbl_ProdSmallDivName
            // 
            lbl_ProdSmallDivName.AutoSize = true;
            lbl_ProdSmallDivName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProdSmallDivName.Location = new Point(481, 382);
            lbl_ProdSmallDivName.Margin = new Padding(2, 0, 2, 0);
            lbl_ProdSmallDivName.Name = "lbl_ProdSmallDivName";
            lbl_ProdSmallDivName.Size = new Size(110, 32);
            lbl_ProdSmallDivName.TabIndex = 166;
            lbl_ProdSmallDivName.Text = "小分類名";
            // 
            // txb_ProdSmallDivName
            // 
            txb_ProdSmallDivName.Enabled = false;
            txb_ProdSmallDivName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_ProdSmallDivName.Location = new Point(601, 379);
            txb_ProdSmallDivName.Margin = new Padding(2);
            txb_ProdSmallDivName.Name = "txb_ProdSmallDivName";
            txb_ProdSmallDivName.Size = new Size(124, 39);
            txb_ProdSmallDivName.TabIndex = 9;
            // 
            // btn_ProdInputClear
            // 
            btn_ProdInputClear.BackColor = Color.PeachPuff;
            btn_ProdInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProdInputClear.Location = new Point(1725, 398);
            btn_ProdInputClear.Name = "btn_ProdInputClear";
            btn_ProdInputClear.Size = new Size(153, 60);
            btn_ProdInputClear.TabIndex = 184;
            btn_ProdInputClear.Text = "入力クリア";
            btn_ProdInputClear.UseVisualStyleBackColor = false;
            btn_ProdInputClear.Click += btn_ReqInputClear_Click;
            // 
            // F_Product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btn_ProdInputClear);
            Controls.Add(txb_ProdSmallDivName);
            Controls.Add(lbl_ProdSmallDivName);
            Controls.Add(txb_ProdMaName);
            Controls.Add(lbl_ProdMaName);
            Controls.Add(btn_ProdShowSmallDivID);
            Controls.Add(btn_ProdShowMakerID);
            Controls.Add(btn_ProdFirstPage);
            Controls.Add(btn_ProdChangeSize);
            Controls.Add(txb_ProdPageSize);
            Controls.Add(lbl_ProdPageSize);
            Controls.Add(lbl_ProdPage);
            Controls.Add(txb_ProdPage);
            Controls.Add(btn_ProdLastPage);
            Controls.Add(btn_ProdPrevPage);
            Controls.Add(btn_ProdNextPage);
            Controls.Add(btn_ProdHiddenReason);
            Controls.Add(CheckBox_ProdHidden);
            Controls.Add(lbl_ProdHidden);
            Controls.Add(dtp_ProdDate);
            Controls.Add(lbl_ProdDate);
            Controls.Add(lbl_Prodkengenmei);
            Controls.Add(lbl_ProdLoginuser);
            Controls.Add(lbl_ProdSelectForm);
            Controls.Add(btn_ProdFormShow);
            Controls.Add(cmb_ProdSelectForm);
            Controls.Add(btn_ProdHidden);
            Controls.Add(txb_ProdColor);
            Controls.Add(lbl_ProdReleaseDate);
            Controls.Add(lbl_ProdColor);
            Controls.Add(btn_ProdBack);
            Controls.Add(dataGrid_Prod);
            Controls.Add(txb_ProdMinNum);
            Controls.Add(lbl_ProdMinNum);
            Controls.Add(btn_ProdAdd);
            Controls.Add(btn_ProdShow);
            Controls.Add(txb_ProdSmallDivID);
            Controls.Add(txb_ProdPrice);
            Controls.Add(txb_ProdMakerID);
            Controls.Add(lbl_ProdSmallDivID);
            Controls.Add(lbl_ProdPrice);
            Controls.Add(lbl_ProdMakerID);
            Controls.Add(txb_ProdSerialNum);
            Controls.Add(lbl_ProdSerialNum);
            Controls.Add(lbl_ProdPrdctName);
            Controls.Add(txb_ProdPrdctName);
            Controls.Add(txb_ProdPrdctID);
            Controls.Add(lbl_ProdPrdctID);
            Controls.Add(btn_ProdSearch);
            Margin = new Padding(2);
            Name = "F_Product";
            Text = "販売管理システム商品画面";
            Load += F_Product_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Prod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_ProdBack;
        private DataGridView dataGrid_Prod;
        private TextBox txb_ProdMinNum;
        private Label lbl_ProdMinNum;
        private Button btn_ProdAdd;
        private Button btn_ProdShow;
        private TextBox txb_ProdSmallDivID;
        private TextBox txb_ProdPrice;
        private TextBox txb_ProdMakerID;
        private Label lbl_ProdSmallDivID;
        private Label lbl_ProdPrice;
        private Label lbl_ProdMakerID;
        private TextBox txb_ProdSerialNum;
        private Label lbl_ProdSerialNum;
        private Label lbl_ProdPrdctName;
        private TextBox txb_ProdPrdctName;
        private TextBox txb_ProdPrdctID;
        private Label lbl_ProdPrdctID;
        private Button btn_ProdSearch;
        private Label lbl_ProdColor;
        private Label lbl_ProdReleaseDate;
        private TextBox txb_ProdColor;
        private Button btn_ProdHidden;
        private ComboBox cmb_ProdSelectForm;
        private Label lbl_ProdSelectForm;
        private Button btn_ProdFormShow;
        private Label lbl_ProdLoginuser;
        private Label lbl_Prodkengenmei;
        private Label lbl_ProdDate;
        private DateTimePicker dtp_ProdDate;
        private CheckBox CheckBox_ProdHidden;
        private Label lbl_ProdHidden;
        private Button btn_ProdHiddenReason;
        private Label lbl_ProdPage;
        private TextBox txb_ProdPage;
        private Button btn_ProdLastPage;
        private Button btn_ProdPrevPage;
        private Button btn_ProdNextPage;
        private Button btn_ProdChangeSize;
        private TextBox txb_ProdPageSize;
        private Label lbl_ProdPageSize;
        private Button btn_ProdFirstPage;
        private Button btn_ProdShowMakerID;
        private Button btn_ProdShowSmallDivID;
        private Label lbl_ProdMaName;
        private TextBox txb_ProdMaName;
        private Label lbl_ProdSmallDivName;
        private TextBox txb_ProdSmallDivName;
        private Button btn_ProdInputClear;
    }

}