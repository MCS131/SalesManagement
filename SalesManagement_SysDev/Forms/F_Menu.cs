using Microsoft.IdentityModel.Protocols;
using SalesManagement_SysDev;
using System.Security.Cryptography;

namespace システム開発メニュー
{
    public partial class F_Menu : Form
    {
        //他のフォームから変数の内容を共有できるように宣言
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;

        public F_Menu()
        {
            InitializeComponent();
        }
        private void F_menu_Activated(object sender, EventArgs e)
        {
            lbl_MenuLoginuser.Text = "ユーザー：" + loginName;
            lbl_Menukengenmei.Text = "権限：" + kengenmei;
            lbl_MenuDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
            //メニュー、ボタンEnable設定
            if (kengenmei != "管理者")
            {
                SetEnable(false);
            }
            else
            {
                SetEnable(true);
            }
            if (Opacity == 0)
            {
                Opacity = 1;
            }
        }
        private void SetEnable(bool flg)
        {
            btn_MenuMngEmp.Enabled = flg;
        }

        ////////////////////////////////
        //メソッド名：OpenForm()
        //引　数   ：フォーム名称を示す値
        //戻り値   ：なし
        //機　能   ：メニューを透明化しフォームを開く
        ///////////////////////////////
        private void OpenForm(string formName)
        {
            Form frm = new Form();
            //引数より、開くフォームを設定
            switch (formName)
            {
                case "ログイン":
                    frm = new F_login();
                    break;
                case "顧客管理":
                    frm = new F_Customer();
                    break;
                case "商品管理":
                    frm = new F_Product();
                    break;
                case "在庫管理":
                    frm = new F_Stock();
                    break;
                case "社員管理":
                    frm = new F_Emp();
                    break;
                case "売上管理":
                    frm = new F_Sales();
                    break;
                case "受注管理":
                    frm = new F_JOrder();
                    break;
                case "注文管理":
                    frm = new F_Request();
                    break;
                case "発注管理":
                    frm = new F_HOrder();
                    break;
                case "入庫管理":
                    frm = new F_Storing();
                    break;
                case "出庫管理":
                    frm = new F_Ship();
                    break;
                case "入荷管理":
                    frm = new F_Storegoods();
                    break;
                case "出荷管理":
                    frm = new F_Shipgoods();
                    break;
            }
            frm.Show();
            Opacity = 0;
        }

        private void btn_MngEmp_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngProduct_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngStock_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngCustomer_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngJOrder_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngStoregoods_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngRequest_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngShipgoods_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngSales_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngShip_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngHOrder_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_MngStoring_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ログアウトしますか？","ログアウト"
                ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void F_Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
