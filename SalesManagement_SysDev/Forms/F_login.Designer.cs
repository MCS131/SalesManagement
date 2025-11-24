namespace SalesManagement_SysDev
{
    partial class F_login
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
            lbl_LoginDaimei = new Label();
            btn_ChPass = new Button();
            btn_Login = new Button();
            txb_LoginPass = new TextBox();
            txb_LoginEmpID = new TextBox();
            lbl_LoginPass = new Label();
            lbl_LoginEmpID = new Label();
            SuspendLayout();
            // 
            // lbl_LoginDaimei
            // 
            lbl_LoginDaimei.Font = new Font("游ゴシック", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_LoginDaimei.ForeColor = Color.Navy;
            lbl_LoginDaimei.Location = new Point(394, 213);
            lbl_LoginDaimei.Margin = new Padding(2, 0, 2, 0);
            lbl_LoginDaimei.Name = "lbl_LoginDaimei";
            lbl_LoginDaimei.Size = new Size(1078, 158);
            lbl_LoginDaimei.TabIndex = 25;
            lbl_LoginDaimei.Text = "販売在庫管理システム";
            lbl_LoginDaimei.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_ChPass
            // 
            btn_ChPass.BackColor = Color.Wheat;
            btn_ChPass.Cursor = Cursors.Hand;
            btn_ChPass.Font = new Font("Yu Gothic UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ChPass.Location = new Point(1306, 717);
            btn_ChPass.Margin = new Padding(2);
            btn_ChPass.Name = "btn_ChPass";
            btn_ChPass.Size = new Size(220, 85);
            btn_ChPass.TabIndex = 24;
            btn_ChPass.Text = "パスワード変更";
            btn_ChPass.UseVisualStyleBackColor = false;
            btn_ChPass.Click += btn_ChPass_Click;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.LightSteelBlue;
            btn_Login.Cursor = Cursors.Hand;
            btn_Login.Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Login.Location = new Point(822, 707);
            btn_Login.Margin = new Padding(2);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(293, 93);
            btn_Login.TabIndex = 23;
            btn_Login.Text = "ログイン";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_login_Click;
            // 
            // txb_LoginPass
            // 
            txb_LoginPass.Font = new Font("Yu Gothic UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            txb_LoginPass.Location = new Point(764, 573);
            txb_LoginPass.Margin = new Padding(2);
            txb_LoginPass.Name = "txb_LoginPass";
            txb_LoginPass.PasswordChar = '*';
            txb_LoginPass.Size = new Size(410, 57);
            txb_LoginPass.TabIndex = 21;
            // 
            // txb_LoginEmpID
            // 
            txb_LoginEmpID.Font = new Font("Yu Gothic UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            txb_LoginEmpID.Location = new Point(764, 456);
            txb_LoginEmpID.Margin = new Padding(2);
            txb_LoginEmpID.Name = "txb_LoginEmpID";
            txb_LoginEmpID.Size = new Size(410, 57);
            txb_LoginEmpID.TabIndex = 20;
            // 
            // lbl_LoginPass
            // 
            lbl_LoginPass.AutoSize = true;
            lbl_LoginPass.Font = new Font("Yu Gothic UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_LoginPass.Location = new Point(572, 573);
            lbl_LoginPass.Margin = new Padding(2, 0, 2, 0);
            lbl_LoginPass.Name = "lbl_LoginPass";
            lbl_LoginPass.Size = new Size(161, 50);
            lbl_LoginPass.TabIndex = 19;
            lbl_LoginPass.Text = "パスワード";
            lbl_LoginPass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_LoginEmpID
            // 
            lbl_LoginEmpID.AutoSize = true;
            lbl_LoginEmpID.Font = new Font("Yu Gothic UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_LoginEmpID.Location = new Point(572, 459);
            lbl_LoginEmpID.Margin = new Padding(2, 0, 2, 0);
            lbl_LoginEmpID.Name = "lbl_LoginEmpID";
            lbl_LoginEmpID.Size = new Size(134, 50);
            lbl_LoginEmpID.TabIndex = 18;
            lbl_LoginEmpID.Text = "社員ID";
            lbl_LoginEmpID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // F_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1904, 1041);
            Controls.Add(lbl_LoginDaimei);
            Controls.Add(btn_ChPass);
            Controls.Add(btn_Login);
            Controls.Add(txb_LoginPass);
            Controls.Add(txb_LoginEmpID);
            Controls.Add(lbl_LoginPass);
            Controls.Add(lbl_LoginEmpID);
            Margin = new Padding(4);
            Name = "F_login";
            Text = "販売管理システムログイン画面";
            Load += F_login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_LoginDaimei;
        private Button btn_ChPass;
        private Button btn_Login;
        private TextBox txb_LoginPass;
        private TextBox txb_LoginEmpID;
        private Label lbl_LoginPass;
        private Label lbl_LoginEmpID;
    }
}
