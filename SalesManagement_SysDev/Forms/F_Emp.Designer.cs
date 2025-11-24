namespace SalesManagement_SysDev
{
    partial class F_Emp
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
            lbl_EmEmpID = new Label();
            lbl_EmEmpName = new Label();
            lbl_EmSalesOfficeID = new Label();
            lbl_EmPositionID = new Label();
            txb_EmEmpID = new TextBox();
            txb_EmEmpName = new TextBox();
            txb_EmPosition = new TextBox();
            txb_EmSalesOffice = new TextBox();
            lbl_EmHireDate = new Label();
            lbl_EmPswrd = new Label();
            txb_EmPassword = new TextBox();
            lbl_EmPhoneNum = new Label();
            txb_EmPhoneNum = new TextBox();
            btn_EmAdd = new Button();
            btn_EmUpdate = new Button();
            btn_EmSearch = new Button();
            btn_EmShowList = new Button();
            dataGrid_Em = new DataGridView();
            cmb_EmSelectForm = new ComboBox();
            btn_EmFormShow = new Button();
            lbl_EmSelectForm = new Label();
            btn_EmBack = new Button();
            dtp_EmHireDate = new DateTimePicker();
            CheckBox_EmHidden = new CheckBox();
            lbl_EmHidden = new Label();
            lbl_EmDate = new Label();
            lbl_Emkengenmei = new Label();
            lbl_EmLoginuser = new Label();
            btn_EmHiddenReason = new Button();
            lbl_EmPage = new Label();
            txb_EmPage = new TextBox();
            btn_EmLastPage = new Button();
            btn_EmPrevPage = new Button();
            btn_EmNextPage = new Button();
            btn_EmChangeSize = new Button();
            txb_EmPageSize = new TextBox();
            lbl_EmPageSize = new Label();
            btn_EmFirstPage = new Button();
            btn_EmInputClear = new Button();
            btn_EmShowSalesOffice = new Button();
            btn_EmShowPosition = new Button();
            lbl_EmSalesOfficeName = new Label();
            lbl_EmPositionName = new Label();
            txb_EmSalesOfficeName = new TextBox();
            txb_EmPositionName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Em).BeginInit();
            SuspendLayout();
            // 
            // lbl_EmEmpID
            // 
            lbl_EmEmpID.AutoSize = true;
            lbl_EmEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmEmpID.Location = new Point(401, 252);
            lbl_EmEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_EmEmpID.Name = "lbl_EmEmpID";
            lbl_EmEmpID.Size = new Size(85, 32);
            lbl_EmEmpID.TabIndex = 0;
            lbl_EmEmpID.Text = "社員ID";
            // 
            // lbl_EmEmpName
            // 
            lbl_EmEmpName.AutoSize = true;
            lbl_EmEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmEmpName.Location = new Point(768, 252);
            lbl_EmEmpName.Margin = new Padding(2, 0, 2, 0);
            lbl_EmEmpName.Name = "lbl_EmEmpName";
            lbl_EmEmpName.Size = new Size(86, 32);
            lbl_EmEmpName.TabIndex = 1;
            lbl_EmEmpName.Text = "社員名";
            // 
            // lbl_EmSalesOfficeID
            // 
            lbl_EmSalesOfficeID.AutoSize = true;
            lbl_EmSalesOfficeID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmSalesOfficeID.Location = new Point(401, 311);
            lbl_EmSalesOfficeID.Margin = new Padding(2, 0, 2, 0);
            lbl_EmSalesOfficeID.Name = "lbl_EmSalesOfficeID";
            lbl_EmSalesOfficeID.Size = new Size(109, 32);
            lbl_EmSalesOfficeID.TabIndex = 2;
            lbl_EmSalesOfficeID.Text = "営業所ID";
            // 
            // lbl_EmPositionID
            // 
            lbl_EmPositionID.AutoSize = true;
            lbl_EmPositionID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPositionID.Location = new Point(401, 369);
            lbl_EmPositionID.Margin = new Padding(2, 0, 2, 0);
            lbl_EmPositionID.Name = "lbl_EmPositionID";
            lbl_EmPositionID.Size = new Size(85, 32);
            lbl_EmPositionID.TabIndex = 3;
            lbl_EmPositionID.Text = "役職ID";
            // 
            // txb_EmEmpID
            // 
            txb_EmEmpID.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmEmpID.Location = new Point(530, 249);
            txb_EmEmpID.Margin = new Padding(2);
            txb_EmEmpID.Name = "txb_EmEmpID";
            txb_EmEmpID.Size = new Size(203, 39);
            txb_EmEmpID.TabIndex = 4;
            // 
            // txb_EmEmpName
            // 
            txb_EmEmpName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmEmpName.Location = new Point(896, 249);
            txb_EmEmpName.Margin = new Padding(2);
            txb_EmEmpName.Name = "txb_EmEmpName";
            txb_EmEmpName.Size = new Size(593, 39);
            txb_EmEmpName.TabIndex = 5;
            // 
            // txb_EmPosition
            // 
            txb_EmPosition.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmPosition.Location = new Point(530, 362);
            txb_EmPosition.Margin = new Padding(2);
            txb_EmPosition.Name = "txb_EmPosition";
            txb_EmPosition.Size = new Size(103, 39);
            txb_EmPosition.TabIndex = 6;
            txb_EmPosition.TextChanged += txb_EmPosition_TextChanged;
            // 
            // txb_EmSalesOffice
            // 
            txb_EmSalesOffice.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmSalesOffice.Location = new Point(530, 308);
            txb_EmSalesOffice.Margin = new Padding(2);
            txb_EmSalesOffice.Name = "txb_EmSalesOffice";
            txb_EmSalesOffice.Size = new Size(103, 39);
            txb_EmSalesOffice.TabIndex = 7;
            txb_EmSalesOffice.TextChanged += txb_EmSalesOffice_TextChanged;
            // 
            // lbl_EmHireDate
            // 
            lbl_EmHireDate.AutoSize = true;
            lbl_EmHireDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmHireDate.Location = new Point(1201, 417);
            lbl_EmHireDate.Margin = new Padding(2, 0, 2, 0);
            lbl_EmHireDate.Name = "lbl_EmHireDate";
            lbl_EmHireDate.Size = new Size(134, 32);
            lbl_EmHireDate.TabIndex = 8;
            lbl_EmHireDate.Text = "入社年月日";
            // 
            // lbl_EmPswrd
            // 
            lbl_EmPswrd.AutoSize = true;
            lbl_EmPswrd.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPswrd.Location = new Point(401, 417);
            lbl_EmPswrd.Margin = new Padding(2, 0, 2, 0);
            lbl_EmPswrd.Name = "lbl_EmPswrd";
            lbl_EmPswrd.Size = new Size(101, 32);
            lbl_EmPswrd.TabIndex = 9;
            lbl_EmPswrd.Text = "パスワード";
            // 
            // txb_EmPassword
            // 
            txb_EmPassword.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmPassword.Location = new Point(530, 410);
            txb_EmPassword.Margin = new Padding(2);
            txb_EmPassword.Name = "txb_EmPassword";
            txb_EmPassword.Size = new Size(203, 39);
            txb_EmPassword.TabIndex = 11;
            // 
            // lbl_EmPhoneNum
            // 
            lbl_EmPhoneNum.AutoSize = true;
            lbl_EmPhoneNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPhoneNum.Location = new Point(768, 417);
            lbl_EmPhoneNum.Margin = new Padding(2, 0, 2, 0);
            lbl_EmPhoneNum.Name = "lbl_EmPhoneNum";
            lbl_EmPhoneNum.Size = new Size(110, 32);
            lbl_EmPhoneNum.TabIndex = 12;
            lbl_EmPhoneNum.Text = "電話番号";
            // 
            // txb_EmPhoneNum
            // 
            txb_EmPhoneNum.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmPhoneNum.Location = new Point(896, 414);
            txb_EmPhoneNum.Margin = new Padding(2);
            txb_EmPhoneNum.Name = "txb_EmPhoneNum";
            txb_EmPhoneNum.Size = new Size(276, 39);
            txb_EmPhoneNum.TabIndex = 13;
            // 
            // btn_EmAdd
            // 
            btn_EmAdd.BackColor = Color.LightPink;
            btn_EmAdd.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmAdd.Location = new Point(474, 114);
            btn_EmAdd.Margin = new Padding(2);
            btn_EmAdd.Name = "btn_EmAdd";
            btn_EmAdd.Size = new Size(185, 100);
            btn_EmAdd.TabIndex = 33;
            btn_EmAdd.Text = "登録";
            btn_EmAdd.UseVisualStyleBackColor = false;
            btn_EmAdd.Click += btn_EmAdd_Click;
            // 
            // btn_EmUpdate
            // 
            btn_EmUpdate.BackColor = Color.LightPink;
            btn_EmUpdate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmUpdate.Location = new Point(731, 114);
            btn_EmUpdate.Margin = new Padding(2);
            btn_EmUpdate.Name = "btn_EmUpdate";
            btn_EmUpdate.Size = new Size(185, 100);
            btn_EmUpdate.TabIndex = 32;
            btn_EmUpdate.Text = "更新";
            btn_EmUpdate.UseVisualStyleBackColor = false;
            btn_EmUpdate.Click += btn_EmUpdate_Click;
            // 
            // btn_EmSearch
            // 
            btn_EmSearch.BackColor = Color.LightPink;
            btn_EmSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmSearch.Location = new Point(989, 114);
            btn_EmSearch.Margin = new Padding(2);
            btn_EmSearch.Name = "btn_EmSearch";
            btn_EmSearch.Size = new Size(185, 100);
            btn_EmSearch.TabIndex = 31;
            btn_EmSearch.Text = "検索";
            btn_EmSearch.UseVisualStyleBackColor = false;
            btn_EmSearch.Click += btn_EmSearch_Click;
            // 
            // btn_EmShowList
            // 
            btn_EmShowList.BackColor = Color.LightPink;
            btn_EmShowList.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmShowList.Location = new Point(1247, 114);
            btn_EmShowList.Margin = new Padding(2);
            btn_EmShowList.Name = "btn_EmShowList";
            btn_EmShowList.Size = new Size(185, 100);
            btn_EmShowList.TabIndex = 35;
            btn_EmShowList.Text = "一覧表示";
            btn_EmShowList.UseVisualStyleBackColor = false;
            btn_EmShowList.Click += btn_EmShowList_Click;
            // 
            // dataGrid_Em
            // 
            dataGrid_Em.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Em.Location = new Point(11, 473);
            dataGrid_Em.Margin = new Padding(2);
            dataGrid_Em.Name = "dataGrid_Em";
            dataGrid_Em.RowHeadersWidth = 62;
            dataGrid_Em.RowTemplate.Height = 33;
            dataGrid_Em.Size = new Size(1882, 520);
            dataGrid_Em.TabIndex = 41;
            dataGrid_Em.CellClick += dataGrid_Em_CellClick;
            // 
            // cmb_EmSelectForm
            // 
            cmb_EmSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cmb_EmSelectForm.FormattingEnabled = true;
            cmb_EmSelectForm.Location = new Point(33, 66);
            cmb_EmSelectForm.Name = "cmb_EmSelectForm";
            cmb_EmSelectForm.Size = new Size(227, 40);
            cmb_EmSelectForm.TabIndex = 47;
            // 
            // btn_EmFormShow
            // 
            btn_EmFormShow.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmFormShow.Location = new Point(49, 112);
            btn_EmFormShow.Name = "btn_EmFormShow";
            btn_EmFormShow.Size = new Size(192, 42);
            btn_EmFormShow.TabIndex = 48;
            btn_EmFormShow.Text = "表示";
            btn_EmFormShow.UseVisualStyleBackColor = true;
            btn_EmFormShow.Click += btn_EmpFormShow_Click;
            // 
            // lbl_EmSelectForm
            // 
            lbl_EmSelectForm.AutoSize = true;
            lbl_EmSelectForm.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmSelectForm.Location = new Point(33, 31);
            lbl_EmSelectForm.Name = "lbl_EmSelectForm";
            lbl_EmSelectForm.Size = new Size(227, 32);
            lbl_EmSelectForm.TabIndex = 49;
            lbl_EmSelectForm.Text = "利用可能な画面選択";
            // 
            // btn_EmBack
            // 
            btn_EmBack.BackColor = Color.DarkOrange;
            btn_EmBack.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_EmBack.Location = new Point(1686, 26);
            btn_EmBack.Name = "btn_EmBack";
            btn_EmBack.Size = new Size(192, 86);
            btn_EmBack.TabIndex = 52;
            btn_EmBack.Text = "戻る";
            btn_EmBack.UseVisualStyleBackColor = false;
            btn_EmBack.Click += btn_EmpBack_Click;
            // 
            // dtp_EmHireDate
            // 
            dtp_EmHireDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dtp_EmHireDate.Location = new Point(1349, 412);
            dtp_EmHireDate.Margin = new Padding(2);
            dtp_EmHireDate.Name = "dtp_EmHireDate";
            dtp_EmHireDate.Size = new Size(226, 39);
            dtp_EmHireDate.TabIndex = 53;
            // 
            // CheckBox_EmHidden
            // 
            CheckBox_EmHidden.AutoSize = true;
            CheckBox_EmHidden.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CheckBox_EmHidden.Location = new Point(98, 444);
            CheckBox_EmHidden.Margin = new Padding(2);
            CheckBox_EmHidden.Name = "CheckBox_EmHidden";
            CheckBox_EmHidden.Size = new Size(15, 14);
            CheckBox_EmHidden.TabIndex = 98;
            CheckBox_EmHidden.UseVisualStyleBackColor = true;
            // 
            // lbl_EmHidden
            // 
            lbl_EmHidden.AutoSize = true;
            lbl_EmHidden.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmHidden.Location = new Point(12, 433);
            lbl_EmHidden.Name = "lbl_EmHidden";
            lbl_EmHidden.Size = new Size(86, 32);
            lbl_EmHidden.TabIndex = 97;
            lbl_EmHidden.Text = "非表示";
            // 
            // lbl_EmDate
            // 
            lbl_EmDate.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_EmDate.Location = new Point(1121, 43);
            lbl_EmDate.Name = "lbl_EmDate";
            lbl_EmDate.Size = new Size(358, 33);
            lbl_EmDate.TabIndex = 102;
            lbl_EmDate.Text = "日付：";
            lbl_EmDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_Emkengenmei
            // 
            lbl_Emkengenmei.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Emkengenmei.Location = new Point(791, 43);
            lbl_Emkengenmei.Name = "lbl_Emkengenmei";
            lbl_Emkengenmei.Size = new Size(324, 33);
            lbl_Emkengenmei.TabIndex = 101;
            lbl_Emkengenmei.Text = "権限名：";
            lbl_Emkengenmei.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_EmLoginuser
            // 
            lbl_EmLoginuser.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_EmLoginuser.Location = new Point(401, 43);
            lbl_EmLoginuser.Name = "lbl_EmLoginuser";
            lbl_EmLoginuser.Size = new Size(384, 33);
            lbl_EmLoginuser.TabIndex = 103;
            lbl_EmLoginuser.Text = "ログインユーザー：";
            lbl_EmLoginuser.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_EmHiddenReason
            // 
            btn_EmHiddenReason.BackColor = Color.PeachPuff;
            btn_EmHiddenReason.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmHiddenReason.Location = new Point(127, 430);
            btn_EmHiddenReason.Name = "btn_EmHiddenReason";
            btn_EmHiddenReason.Size = new Size(153, 36);
            btn_EmHiddenReason.TabIndex = 148;
            btn_EmHiddenReason.Text = "非表示理由";
            btn_EmHiddenReason.UseVisualStyleBackColor = false;
            btn_EmHiddenReason.Click += btn_EmHiddenReason_Click;
            // 
            // lbl_EmPage
            // 
            lbl_EmPage.AutoSize = true;
            lbl_EmPage.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPage.Location = new Point(1666, 1003);
            lbl_EmPage.Name = "lbl_EmPage";
            lbl_EmPage.Size = new Size(46, 21);
            lbl_EmPage.TabIndex = 157;
            lbl_EmPage.Text = "ページ";
            // 
            // txb_EmPage
            // 
            txb_EmPage.Location = new Point(1609, 1003);
            txb_EmPage.Name = "txb_EmPage";
            txb_EmPage.Size = new Size(51, 23);
            txb_EmPage.TabIndex = 156;
            // 
            // btn_EmLastPage
            // 
            btn_EmLastPage.Location = new Point(1855, 998);
            btn_EmLastPage.Name = "btn_EmLastPage";
            btn_EmLastPage.Size = new Size(38, 31);
            btn_EmLastPage.TabIndex = 155;
            btn_EmLastPage.Text = "➜";
            btn_EmLastPage.UseVisualStyleBackColor = true;
            btn_EmLastPage.Click += btn_EmLastPage_Click;
            // 
            // btn_EmPrevPage
            // 
            btn_EmPrevPage.Location = new Point(1775, 998);
            btn_EmPrevPage.Name = "btn_EmPrevPage";
            btn_EmPrevPage.Size = new Size(38, 31);
            btn_EmPrevPage.TabIndex = 154;
            btn_EmPrevPage.Text = "◀️";
            btn_EmPrevPage.UseVisualStyleBackColor = true;
            btn_EmPrevPage.Click += btn_EmPrevPage_Click;
            // 
            // btn_EmNextPage
            // 
            btn_EmNextPage.Location = new Point(1815, 998);
            btn_EmNextPage.Name = "btn_EmNextPage";
            btn_EmNextPage.Size = new Size(38, 31);
            btn_EmNextPage.TabIndex = 153;
            btn_EmNextPage.Text = "▶️";
            btn_EmNextPage.UseVisualStyleBackColor = true;
            btn_EmNextPage.Click += btn_EmNextPage_Click;
            // 
            // btn_EmChangeSize
            // 
            btn_EmChangeSize.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmChangeSize.Location = new Point(171, 1006);
            btn_EmChangeSize.Name = "btn_EmChangeSize";
            btn_EmChangeSize.Size = new Size(99, 26);
            btn_EmChangeSize.TabIndex = 160;
            btn_EmChangeSize.Text = "行数変更";
            btn_EmChangeSize.UseVisualStyleBackColor = true;
            btn_EmChangeSize.Click += btn_EmChangeSize_Click;
            // 
            // txb_EmPageSize
            // 
            txb_EmPageSize.Location = new Point(105, 1008);
            txb_EmPageSize.Name = "txb_EmPageSize";
            txb_EmPageSize.Size = new Size(51, 23);
            txb_EmPageSize.TabIndex = 159;
            // 
            // lbl_EmPageSize
            // 
            lbl_EmPageSize.AutoSize = true;
            lbl_EmPageSize.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPageSize.Location = new Point(12, 1008);
            lbl_EmPageSize.Name = "lbl_EmPageSize";
            lbl_EmPageSize.Size = new Size(87, 21);
            lbl_EmPageSize.TabIndex = 158;
            lbl_EmPageSize.Text = "1ページ行数";
            // 
            // btn_EmFirstPage
            // 
            btn_EmFirstPage.Location = new Point(1734, 998);
            btn_EmFirstPage.Name = "btn_EmFirstPage";
            btn_EmFirstPage.Size = new Size(38, 31);
            btn_EmFirstPage.TabIndex = 161;
            btn_EmFirstPage.Text = "|";
            btn_EmFirstPage.UseVisualStyleBackColor = true;
            btn_EmFirstPage.Click += btn_EmFirstPage_Click;
            // 
            // btn_EmInputClear
            // 
            btn_EmInputClear.BackColor = Color.PeachPuff;
            btn_EmInputClear.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmInputClear.Location = new Point(1725, 393);
            btn_EmInputClear.Name = "btn_EmInputClear";
            btn_EmInputClear.Size = new Size(153, 60);
            btn_EmInputClear.TabIndex = 162;
            btn_EmInputClear.Text = "入力クリア";
            btn_EmInputClear.UseVisualStyleBackColor = false;
            btn_EmInputClear.Click += btn_EmInputClear_Click;
            // 
            // btn_EmShowSalesOffice
            // 
            btn_EmShowSalesOffice.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmShowSalesOffice.Location = new Point(653, 307);
            btn_EmShowSalesOffice.Name = "btn_EmShowSalesOffice";
            btn_EmShowSalesOffice.Size = new Size(80, 36);
            btn_EmShowSalesOffice.TabIndex = 163;
            btn_EmShowSalesOffice.Text = "営業所一覧";
            btn_EmShowSalesOffice.UseVisualStyleBackColor = true;
            btn_EmShowSalesOffice.Click += btn_EmShowSalesOffice_Click;
            // 
            // btn_EmShowPosition
            // 
            btn_EmShowPosition.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EmShowPosition.Location = new Point(653, 365);
            btn_EmShowPosition.Name = "btn_EmShowPosition";
            btn_EmShowPosition.Size = new Size(80, 36);
            btn_EmShowPosition.TabIndex = 164;
            btn_EmShowPosition.Text = "役職一覧";
            btn_EmShowPosition.UseVisualStyleBackColor = true;
            btn_EmShowPosition.Click += btn_EmShowPosition_Click;
            // 
            // lbl_EmSalesOfficeName
            // 
            lbl_EmSalesOfficeName.AutoSize = true;
            lbl_EmSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmSalesOfficeName.Location = new Point(768, 311);
            lbl_EmSalesOfficeName.Margin = new Padding(2, 0, 2, 0);
            lbl_EmSalesOfficeName.Name = "lbl_EmSalesOfficeName";
            lbl_EmSalesOfficeName.Size = new Size(110, 32);
            lbl_EmSalesOfficeName.TabIndex = 165;
            lbl_EmSalesOfficeName.Text = "営業所名";
            // 
            // lbl_EmPositionName
            // 
            lbl_EmPositionName.AutoSize = true;
            lbl_EmPositionName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EmPositionName.Location = new Point(768, 365);
            lbl_EmPositionName.Margin = new Padding(2, 0, 2, 0);
            lbl_EmPositionName.Name = "lbl_EmPositionName";
            lbl_EmPositionName.Size = new Size(86, 32);
            lbl_EmPositionName.TabIndex = 166;
            lbl_EmPositionName.Text = "役職名";
            // 
            // txb_EmSalesOfficeName
            // 
            txb_EmSalesOfficeName.Enabled = false;
            txb_EmSalesOfficeName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmSalesOfficeName.Location = new Point(896, 304);
            txb_EmSalesOfficeName.Margin = new Padding(3, 4, 3, 4);
            txb_EmSalesOfficeName.Name = "txb_EmSalesOfficeName";
            txb_EmSalesOfficeName.Size = new Size(359, 39);
            txb_EmSalesOfficeName.TabIndex = 167;
            // 
            // txb_EmPositionName
            // 
            txb_EmPositionName.Enabled = false;
            txb_EmPositionName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txb_EmPositionName.Location = new Point(896, 361);
            txb_EmPositionName.Margin = new Padding(3, 4, 3, 4);
            txb_EmPositionName.Name = "txb_EmPositionName";
            txb_EmPositionName.Size = new Size(359, 39);
            txb_EmPositionName.TabIndex = 168;
            // 
            // F_Emp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(1904, 1041);
            Controls.Add(txb_EmPositionName);
            Controls.Add(txb_EmSalesOfficeName);
            Controls.Add(lbl_EmPositionName);
            Controls.Add(lbl_EmSalesOfficeName);
            Controls.Add(btn_EmShowPosition);
            Controls.Add(btn_EmShowSalesOffice);
            Controls.Add(btn_EmInputClear);
            Controls.Add(btn_EmFirstPage);
            Controls.Add(btn_EmChangeSize);
            Controls.Add(txb_EmPageSize);
            Controls.Add(lbl_EmPageSize);
            Controls.Add(lbl_EmPage);
            Controls.Add(txb_EmPage);
            Controls.Add(btn_EmLastPage);
            Controls.Add(btn_EmPrevPage);
            Controls.Add(btn_EmNextPage);
            Controls.Add(btn_EmHiddenReason);
            Controls.Add(lbl_EmLoginuser);
            Controls.Add(lbl_EmDate);
            Controls.Add(lbl_Emkengenmei);
            Controls.Add(CheckBox_EmHidden);
            Controls.Add(lbl_EmHidden);
            Controls.Add(dtp_EmHireDate);
            Controls.Add(btn_EmBack);
            Controls.Add(lbl_EmSelectForm);
            Controls.Add(btn_EmFormShow);
            Controls.Add(cmb_EmSelectForm);
            Controls.Add(dataGrid_Em);
            Controls.Add(btn_EmShowList);
            Controls.Add(btn_EmAdd);
            Controls.Add(btn_EmUpdate);
            Controls.Add(btn_EmSearch);
            Controls.Add(txb_EmPhoneNum);
            Controls.Add(lbl_EmPhoneNum);
            Controls.Add(txb_EmPassword);
            Controls.Add(lbl_EmPswrd);
            Controls.Add(lbl_EmHireDate);
            Controls.Add(txb_EmSalesOffice);
            Controls.Add(txb_EmPosition);
            Controls.Add(txb_EmEmpName);
            Controls.Add(txb_EmEmpID);
            Controls.Add(lbl_EmPositionID);
            Controls.Add(lbl_EmSalesOfficeID);
            Controls.Add(lbl_EmEmpName);
            Controls.Add(lbl_EmEmpID);
            Margin = new Padding(2);
            Name = "F_Emp";
            Text = "販売管理システム社員画面";
            Load += F_Emp_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid_Em).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_EmEmpID;
        private Label lbl_EmEmpName;
        private Label lbl_EmSalesOfficeID;
        private Label lbl_EmPositionID;
        private TextBox txb_EmEmpID;
        private TextBox txb_EmEmpName;
        private TextBox txb_EmPosition;
        private TextBox txb_EmSalesOffice;
        private Label lbl_EmHireDate;
        private Label lbl_EmPswrd;
        private TextBox txb_EmPassword;
        private Label lbl_EmPhoneNum;
        private TextBox txb_EmPhoneNum;
        private Button btn_EmAdd;
        private Button btn_EmUpdate;
        private Button btn_EmSearch;
        private Button btn_EmShowList;
        private Button btn_MngSales;
        private Button btn_MngShipgoods;
        private Button btn_MngStoregoods;
        private Button btn_MngRequest;
        private Button btn_MngJOrder;
        private DataGridView dataGrid_Em;
        private ComboBox cmb_EmSelectForm;
        private Button btn_EmFormShow;
        private Label lbl_EmSelectForm;
        private Label Check_Hidden;
        private CheckBox CheckBox_Hidden;
        private Button btn_EmBack;
        private DateTimePicker dtp_EmHireDate;
        private CheckBox CheckBox_EmHidden;
        private Label lbl_EmHidden;
        private Label lbl_EmDate;
        private Label lbl_Emkengenmei;
        private Label lbl_EmLoginuser;
        private Button btn_EmHiddenReason;
        private Label lbl_EmPage;
        private TextBox txb_EmPage;
        private Button btn_EmLastPage;
        private Button btn_EmPrevPage;
        private Button btn_EmNextPage;
        private Button btn_EmChangeSize;
        private TextBox txb_EmPageSize;
        private Label lbl_EmPageSize;
        private Button btn_EmFirstPage;
        private Button btn_EmInputClear;
        private Button btn_EmShowSalesOffice;
        private Button btn_EmShowPosition;
        private Label lbl_EmSalesOfficeName;
        private Label lbl_EmPositionName;
        private TextBox txb_EmSalesOfficeName;
        private TextBox txb_EmPositionName;
    }
}