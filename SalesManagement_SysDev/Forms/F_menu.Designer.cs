namespace システム開発メニュー
{
    partial class F_Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_MenuMngEmp = new Button();
            btn_MenuMngProduct = new Button();
            btn_MenuMngStock = new Button();
            btn_MenuMngCustomer = new Button();
            lbl_MenuCategory1 = new Label();
            lbl_MenuCategory3 = new Label();
            lbl_MenuCategory2 = new Label();
            btn_MenuMngStoring = new Button();
            btn_MenuMngHOrder = new Button();
            btn_MenuMngSales = new Button();
            btn_MenuMngShipgoods = new Button();
            btn_MenuMngStoregoods = new Button();
            btn_MenuMngShip = new Button();
            btn_MenuMngRequest = new Button();
            btn_MenuMngJOrder = new Button();
            btn_MenuLogout = new Button();
            lbl_MenuDate = new Label();
            lbl_MenuLoginuser = new Label();
            lbl_Menukengenmei = new Label();
            SuspendLayout();
            // 
            // btn_MenuMngEmp
            // 
            btn_MenuMngEmp.BackColor = Color.Moccasin;
            btn_MenuMngEmp.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngEmp.Location = new Point(88, 205);
            btn_MenuMngEmp.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngEmp.Name = "btn_MenuMngEmp";
            btn_MenuMngEmp.Size = new Size(350, 200);
            btn_MenuMngEmp.TabIndex = 1;
            btn_MenuMngEmp.Text = "社員管理";
            btn_MenuMngEmp.UseVisualStyleBackColor = false;
            btn_MenuMngEmp.Click += btn_MngEmp_Click;
            // 
            // btn_MenuMngProduct
            // 
            btn_MenuMngProduct.BackColor = Color.Moccasin;
            btn_MenuMngProduct.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngProduct.Location = new Point(541, 205);
            btn_MenuMngProduct.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngProduct.Name = "btn_MenuMngProduct";
            btn_MenuMngProduct.Size = new Size(350, 200);
            btn_MenuMngProduct.TabIndex = 2;
            btn_MenuMngProduct.Text = "商品管理";
            btn_MenuMngProduct.UseVisualStyleBackColor = false;
            btn_MenuMngProduct.Click += btn_MngProduct_Click;
            // 
            // btn_MenuMngStock
            // 
            btn_MenuMngStock.BackColor = Color.Moccasin;
            btn_MenuMngStock.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngStock.Location = new Point(997, 205);
            btn_MenuMngStock.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngStock.Name = "btn_MenuMngStock";
            btn_MenuMngStock.Size = new Size(350, 200);
            btn_MenuMngStock.TabIndex = 3;
            btn_MenuMngStock.Text = "在庫管理";
            btn_MenuMngStock.UseVisualStyleBackColor = false;
            btn_MenuMngStock.Click += btn_MngStock_Click;
            // 
            // btn_MenuMngCustomer
            // 
            btn_MenuMngCustomer.BackColor = Color.Moccasin;
            btn_MenuMngCustomer.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngCustomer.Location = new Point(1449, 205);
            btn_MenuMngCustomer.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngCustomer.Name = "btn_MenuMngCustomer";
            btn_MenuMngCustomer.Size = new Size(350, 200);
            btn_MenuMngCustomer.TabIndex = 4;
            btn_MenuMngCustomer.Text = "顧客管理";
            btn_MenuMngCustomer.UseVisualStyleBackColor = false;
            btn_MenuMngCustomer.Click += btn_MngCustomer_Click;
            // 
            // lbl_MenuCategory1
            // 
            lbl_MenuCategory1.AutoSize = true;
            lbl_MenuCategory1.Font = new Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MenuCategory1.Location = new Point(88, 152);
            lbl_MenuCategory1.Margin = new Padding(2, 0, 2, 0);
            lbl_MenuCategory1.Name = "lbl_MenuCategory1";
            lbl_MenuCategory1.Size = new Size(108, 30);
            lbl_MenuCategory1.TabIndex = 14;
            lbl_MenuCategory1.Text = "マスタ管理";
            // 
            // lbl_MenuCategory3
            // 
            lbl_MenuCategory3.AutoSize = true;
            lbl_MenuCategory3.Font = new Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MenuCategory3.Location = new Point(1449, 499);
            lbl_MenuCategory3.Margin = new Padding(2, 0, 2, 0);
            lbl_MenuCategory3.Name = "lbl_MenuCategory3";
            lbl_MenuCategory3.Size = new Size(123, 30);
            lbl_MenuCategory3.TabIndex = 28;
            lbl_MenuCategory3.Text = "発注～入庫";
            // 
            // lbl_MenuCategory2
            // 
            lbl_MenuCategory2.AutoSize = true;
            lbl_MenuCategory2.Font = new Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MenuCategory2.ImageAlign = ContentAlignment.BottomLeft;
            lbl_MenuCategory2.Location = new Point(88, 499);
            lbl_MenuCategory2.Margin = new Padding(2, 0, 2, 0);
            lbl_MenuCategory2.Name = "lbl_MenuCategory2";
            lbl_MenuCategory2.Size = new Size(123, 30);
            lbl_MenuCategory2.TabIndex = 27;
            lbl_MenuCategory2.Text = "受注～売上";
            // 
            // btn_MenuMngStoring
            // 
            btn_MenuMngStoring.BackColor = Color.Beige;
            btn_MenuMngStoring.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngStoring.Location = new Point(1449, 767);
            btn_MenuMngStoring.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngStoring.Name = "btn_MenuMngStoring";
            btn_MenuMngStoring.Size = new Size(350, 200);
            btn_MenuMngStoring.TabIndex = 12;
            btn_MenuMngStoring.Text = "入庫管理";
            btn_MenuMngStoring.UseVisualStyleBackColor = false;
            btn_MenuMngStoring.Click += btn_MngStoring_Click;
            // 
            // btn_MenuMngHOrder
            // 
            btn_MenuMngHOrder.BackColor = Color.Beige;
            btn_MenuMngHOrder.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngHOrder.Location = new Point(1449, 546);
            btn_MenuMngHOrder.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngHOrder.Name = "btn_MenuMngHOrder";
            btn_MenuMngHOrder.Size = new Size(350, 200);
            btn_MenuMngHOrder.TabIndex = 11;
            btn_MenuMngHOrder.Text = "発注管理";
            btn_MenuMngHOrder.UseVisualStyleBackColor = false;
            btn_MenuMngHOrder.Click += btn_MngHOrder_Click;
            // 
            // btn_MenuMngSales
            // 
            btn_MenuMngSales.BackColor = Color.Khaki;
            btn_MenuMngSales.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngSales.Location = new Point(829, 767);
            btn_MenuMngSales.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngSales.Name = "btn_MenuMngSales";
            btn_MenuMngSales.Size = new Size(350, 200);
            btn_MenuMngSales.TabIndex = 7;
            btn_MenuMngSales.Text = "売上管理";
            btn_MenuMngSales.UseVisualStyleBackColor = false;
            btn_MenuMngSales.Click += btn_MngSales_Click;
            // 
            // btn_MenuMngShipgoods
            // 
            btn_MenuMngShipgoods.BackColor = Color.Khaki;
            btn_MenuMngShipgoods.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngShipgoods.Location = new Point(457, 767);
            btn_MenuMngShipgoods.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngShipgoods.Name = "btn_MenuMngShipgoods";
            btn_MenuMngShipgoods.Size = new Size(350, 200);
            btn_MenuMngShipgoods.TabIndex = 9;
            btn_MenuMngShipgoods.Text = "出荷管理";
            btn_MenuMngShipgoods.UseVisualStyleBackColor = false;
            btn_MenuMngShipgoods.Click += btn_MngShipgoods_Click;
            // 
            // btn_MenuMngStoregoods
            // 
            btn_MenuMngStoregoods.BackColor = Color.Khaki;
            btn_MenuMngStoregoods.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngStoregoods.Location = new Point(88, 767);
            btn_MenuMngStoregoods.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngStoregoods.Name = "btn_MenuMngStoregoods";
            btn_MenuMngStoregoods.Size = new Size(350, 200);
            btn_MenuMngStoregoods.TabIndex = 8;
            btn_MenuMngStoregoods.Text = "入荷管理";
            btn_MenuMngStoregoods.UseVisualStyleBackColor = false;
            btn_MenuMngStoregoods.Click += btn_MngStoregoods_Click;
            // 
            // btn_MenuMngShip
            // 
            btn_MenuMngShip.BackColor = Color.Khaki;
            btn_MenuMngShip.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngShip.Location = new Point(829, 546);
            btn_MenuMngShip.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngShip.Name = "btn_MenuMngShip";
            btn_MenuMngShip.Size = new Size(350, 200);
            btn_MenuMngShip.TabIndex = 10;
            btn_MenuMngShip.Text = "出庫管理";
            btn_MenuMngShip.UseVisualStyleBackColor = false;
            btn_MenuMngShip.Click += btn_MngShip_Click;
            // 
            // btn_MenuMngRequest
            // 
            btn_MenuMngRequest.BackColor = Color.Khaki;
            btn_MenuMngRequest.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngRequest.Location = new Point(457, 546);
            btn_MenuMngRequest.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngRequest.Name = "btn_MenuMngRequest";
            btn_MenuMngRequest.Size = new Size(350, 200);
            btn_MenuMngRequest.TabIndex = 6;
            btn_MenuMngRequest.Text = "注文管理";
            btn_MenuMngRequest.UseVisualStyleBackColor = false;
            btn_MenuMngRequest.Click += btn_MngRequest_Click;
            // 
            // btn_MenuMngJOrder
            // 
            btn_MenuMngJOrder.BackColor = Color.Khaki;
            btn_MenuMngJOrder.Font = new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            btn_MenuMngJOrder.Location = new Point(88, 546);
            btn_MenuMngJOrder.Margin = new Padding(2, 4, 2, 4);
            btn_MenuMngJOrder.Name = "btn_MenuMngJOrder";
            btn_MenuMngJOrder.Size = new Size(350, 200);
            btn_MenuMngJOrder.TabIndex = 5;
            btn_MenuMngJOrder.Text = "受注管理";
            btn_MenuMngJOrder.UseVisualStyleBackColor = false;
            btn_MenuMngJOrder.Click += btn_MngJOrder_Click;
            // 
            // btn_MenuLogout
            // 
            btn_MenuLogout.BackColor = Color.Gold;
            btn_MenuLogout.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_MenuLogout.Location = new Point(1672, 31);
            btn_MenuLogout.Margin = new Padding(2, 4, 2, 4);
            btn_MenuLogout.Name = "btn_MenuLogout";
            btn_MenuLogout.Size = new Size(200, 100);
            btn_MenuLogout.TabIndex = 13;
            btn_MenuLogout.Text = "ログアウト";
            btn_MenuLogout.UseVisualStyleBackColor = false;
            btn_MenuLogout.Click += btn_Logout_Click;
            // 
            // lbl_MenuDate
            // 
            lbl_MenuDate.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_MenuDate.Location = new Point(1129, 65);
            lbl_MenuDate.Name = "lbl_MenuDate";
            lbl_MenuDate.Size = new Size(354, 33);
            lbl_MenuDate.TabIndex = 103;
            lbl_MenuDate.Text = "日付：";
            lbl_MenuDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_MenuLoginuser
            // 
            lbl_MenuLoginuser.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_MenuLoginuser.Location = new Point(372, 65);
            lbl_MenuLoginuser.Name = "lbl_MenuLoginuser";
            lbl_MenuLoginuser.Size = new Size(384, 33);
            lbl_MenuLoginuser.TabIndex = 102;
            lbl_MenuLoginuser.Text = "ログインユーザー：";
            lbl_MenuLoginuser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Menukengenmei
            // 
            lbl_Menukengenmei.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Menukengenmei.Location = new Point(782, 65);
            lbl_Menukengenmei.Name = "lbl_Menukengenmei";
            lbl_Menukengenmei.Size = new Size(324, 33);
            lbl_Menukengenmei.TabIndex = 101;
            lbl_Menukengenmei.Text = "権限名：";
            lbl_Menukengenmei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // F_Menu
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1904, 1041);
            Controls.Add(lbl_MenuDate);
            Controls.Add(lbl_MenuLoginuser);
            Controls.Add(lbl_Menukengenmei);
            Controls.Add(btn_MenuLogout);
            Controls.Add(lbl_MenuCategory3);
            Controls.Add(lbl_MenuCategory2);
            Controls.Add(btn_MenuMngStoring);
            Controls.Add(btn_MenuMngHOrder);
            Controls.Add(btn_MenuMngSales);
            Controls.Add(btn_MenuMngShipgoods);
            Controls.Add(btn_MenuMngStoregoods);
            Controls.Add(btn_MenuMngShip);
            Controls.Add(btn_MenuMngRequest);
            Controls.Add(btn_MenuMngJOrder);
            Controls.Add(lbl_MenuCategory1);
            Controls.Add(btn_MenuMngCustomer);
            Controls.Add(btn_MenuMngStock);
            Controls.Add(btn_MenuMngProduct);
            Controls.Add(btn_MenuMngEmp);
            Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(2, 4, 2, 4);
            Name = "F_Menu";
            Text = "販売管理システムメニュー画面";
            Activated += F_menu_Activated;
            Load += F_Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_MenuMngEmp;
        private Button btn_MenuMngProduct;
        private Button btn_MenuMngStock;
        private Button btn_MenuMngCustomer;
        private Label lbl_MenuCategory1;
        private Label lbl_MenuCategory3;
        private Label lbl_MenuCategory2;
        private Button btn_MenuMngStoring;
        private Button btn_MenuMngHOrder;
        private Button btn_MenuMngSales;
        private Button btn_MenuMngShipgoods;
        private Button btn_MenuMngStoregoods;
        private Button btn_MenuMngShip;
        private Button btn_MenuMngRequest;
        private Button btn_MenuMngJOrder;
        private Button btn_MenuLogout;
        private Label lbl_MenuDate;
        private Label lbl_MenuLoginuser;
        private Label lbl_Menukengenmei;
    }
}