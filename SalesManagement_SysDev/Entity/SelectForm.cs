using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;

namespace SalesManagement_SysDev.Entity
{
    internal class SelectForm
    {
        ////////////////////////////////
        //メソッド名：OpenForm()
        //引　数   ：フォーム名称を示す値
        //戻り値   ：なし
        //機　能   ：メニューを透明化しフォームを開く
        ///////////////////////////////
        internal void OpenForm(string frmName)
        {
            Form frm = new Form();
            switch (frmName)
            {
                case "顧客管理画面":
                    frm = new F_Customer();
                    break;
                case "商品管理画面":
                    frm = new F_Product();
                    break;
                case "在庫管理画面":
                    frm = new F_Stock();
                    break;
                case "社員管理画面":
                    frm = new F_Emp();
                    break;
                case "売上管理画面":
                    frm = new F_Sales();
                    break;
                case "受注管理画面":
                    frm = new F_JOrder();
                    break;
                case "注文管理画面":
                    frm = new F_Request();
                    break;
                case "発注管理画面":
                    frm = new F_HOrder();
                    break;
                case "入庫管理画面":
                    frm = new F_Storing();
                    break;
                case "出庫管理画面":
                    frm = new F_Ship();
                    break;
                case "入荷管理画面":
                    frm = new F_Storegoods();
                    break;
                case "出荷管理画面":
                    frm = new F_Shipgoods();
                    break;
            }
            frm.Show();
        }
    }
}
