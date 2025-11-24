using Microsoft.Identity.Client;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using SalesManagement_SysDev.Forms.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace システム開発メニュー
{
    public partial class F_JOrder : Form
    {
        //データベースアクセス用クラスのインスタンス化
        OrderDataAccess orderDataAccess = new OrderDataAccess();
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();
        OrderDetailDataAccess orderDetailDataAccess = new OrderDetailDataAccess();
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        ChumonDetailDataAccess chDetailDataAccess = new ChumonDetailDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の顧客データ
        private static List<TOrderDsp> JOrder;
        private static List<MSalesOfficeDsp> SalesOffice;
        private static List<MEmployeeDsp> Emloyee;
        private static List<MClientDsp> Client;
        private static List<MProductDsp> Product;
        private static List<TOrderDetailDsp> OrderDetail;

        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_JOrder()
        {
            InitializeComponent();
        }
        private void F_JOrder_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_JOrderLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_JOrderkengenmei.Text = "権限名：" + kengenmei;
            lbl_JODate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

            //ボタンEnable設定
            SetEnable(false);

            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);

            // データグリッドビューの表示
            SetFormDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetEnable()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：権限でボタンのEnable設定
        ///////////////////////////////
        private void SetEnable(bool flg)
        {
            if (kengenmei == "物流")
            {
                btn_JOrderAdd.Enabled = flg;
                btn_JOrderHidden.Enabled = flg;
                btn_JOrderFix.Enabled = flg;
                CheckBox_JOrderHidden.Enabled = flg;
            }

        }
        private void btn_JOrderAdd_Click(object sender, EventArgs e)
        {
            //8.1受注登録・受注詳細登録
            if (String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                if (!GetValidDataAtregJOrder())
                {
                    return;
                }
                //受注テーブルに登録
                var regJOrder = GenerateDataAtRegJOrder();
                RegistrationJOrder(regJOrder);
            }
            else if (!String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                if (!GetValidDataAtregDetail())
                {
                    return;
                }
                //受注詳細テーブルに登録
                var regJOrderDetail = GenerateDataAtregDetail();
                RegistrationDetail(regJOrderDetail);
            }

        }
        ///////////////////////////////
        //          受注情報を得る
        //メソッド名：GetValidDataAtregJOrder()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtregJOrder()
        {
            // 営業所IDの適否
            if (!String.IsNullOrEmpty(txb_JOrderSalesOfficeID.Text.Trim()))
            {
                // 営業所IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderSalesOfficeID.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (txb_JOrderSalesOfficeID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!orderDataAccess.CheckSoIdCDExistence(int.Parse(txb_JOrderSalesOfficeID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderSalesOfficeID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderSalesOfficeID.Focus();
                return false;
            }
            if (!String.IsNullOrEmpty(txb_JOrderEmpID.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderEmpID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは数字入力です", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txb_JOrderEmpID.Text.Length > 6)
                {
                    MessageBox.Show("社員IDは6文字までです", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!chumonDataAccess.CheckEmpIDCDExistence(int.Parse(txb_JOrderEmpID.Text.Trim())))
                {
                    MessageBox.Show("社員IDは存在しません", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDを入力してください", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // 顧客IDの適否
            if (!String.IsNullOrEmpty(txb_JOrderCstmrID.Text.Trim()))
            {
                // 顧客IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderCstmrID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrID.Focus();
                    return false;
                }
                // 顧客IDの文字数チェック
                if (txb_JOrderCstmrID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrID.Focus();
                    return false;
                }
                // 顧客IDの存在チェック
                if (!orderDataAccess.CheckCstmrCDExistence(int.Parse(txb_JOrderCstmrID.Text.Trim())))
                {
                    MessageBox.Show("入力された顧客IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderCstmrID.Focus();
                return false;
            }
            //顧客担当者名の適否
            if (!String.IsNullOrEmpty(txb_JOrderCstmrEq.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckFullWidth(txb_JOrderCstmrEq.Text.Trim()))
                {
                    MessageBox.Show("顧客担当者は全て全角入力です", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrEq.Focus();
                    return false;
                }
                if (txb_JOrderCstmrEq.Text.Length > 50)
                {
                    MessageBox.Show("顧客担当者は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrEq.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客担当者が入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderCstmrEq.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          受注情報作成
        //メソッド名：GenerateDataAtRegJOrder()
        //引　数   ：なし
        //戻り値   ：受注登録情報
        //機　能   ：受注データのセット
        ///////////////////////////////
        private TOrder GenerateDataAtRegJOrder()
        {
            int flg = 0;
            int stateflg = 0;
            string empid;
            if (CheckBox_JOrderHidden.Checked)
            {
                flg = 2;
            }
            return new TOrder
            {
                SoId = int.Parse(txb_JOrderSalesOfficeID.Text.Trim()),
                EmId = int.Parse(txb_JOrderEmpID.Text.Trim()),
                ClId = int.Parse(txb_JOrderCstmrID.Text.Trim()),
                ClCharge = txb_JOrderCstmrEq.Text.Trim(),
                OrDate = dtp_JOrderDate.Value,
                OrStateFlag = stateflg,
                OrFlag = flg,
            };
        }

        ///////////////////////////////
        //         受注情報登録
        //メソッド名：RegistrationJOrder()
        //引　数   ：受注情報
        //戻り値   ：なし
        //機　能   ：受注データの登録
        ///////////////////////////////
        private void RegistrationJOrder(TOrder regJOrder)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("受注登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 受注情報の登録
            bool flg = orderDataAccess.AddJOrderData(regJOrder);
            if (flg == true)
            {
                MessageBox.Show("データを登録しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("データの登録に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txb_JOrderID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }
        ///////////////////////////////
        //          受注詳細情報を得る
        //メソッド名：GetValidDataAtregDetail()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtregDetail()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                //受注IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                //受注IDの文字数チェック
                if (txb_JOrderID.Text.Length > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                // 受注IDの存在チェック
                if (!orderDataAccess.CheckJOrderCDExistence(int.Parse(txb_JOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("受注IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderID.Focus();
                return false;
            }
            //商品IDの適否
            if (!String.IsNullOrEmpty(txb_JOrderProductID.Text.Trim()))
            {
                //商品IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderProductID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductID.Focus();
                    return false;
                }
                //商品IDの文字数チェック
                if (txb_JOrderProductID.Text.Length > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductID.Focus();
                    return false;
                }
                // 商品IDの存在チェック
                if (!orderDataAccess.CheckProductIDCDExistence(int.Parse(txb_JOrderProductID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("商品IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderProductID.Focus();
                return false;
            }
            //数量の適否
            if (!String.IsNullOrEmpty(txb_JOrderProductcnt.Text.Trim()))
            {
                //数量の入力形式のチェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderProductcnt.Text.Trim()))
                {
                    MessageBox.Show("数量は全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductcnt.Focus();
                    return false;
                }
                //数量の文字数チェック
                if (txb_JOrderProductcnt.Text.Length > 4)
                {
                    MessageBox.Show("数量は4桁までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductcnt.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("数量が入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderProductcnt.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          受注詳細情報作成
        //メソッド名：GenerateDataAtregDetail()
        //引　数   ：なし
        //戻り値   ：受注詳細登録情報
        //機　能   ：受注詳細データのセット
        ///////////////////////////////
        private TOrderDetail GenerateDataAtregDetail()
        {
            return new TOrderDetail
            {
                OrId = int.Parse(txb_JOrderID.Text),
                PrId = int.Parse(txb_JOrderProductID.Text),
                OrQuantity = int.Parse(txb_JOrderProductcnt.Text),
                OrTotalPrice = int.Parse(txb_JOrderTotalPrice.Text)
            };
        }
        ///////////////////////////////
        //         受注詳細情報登録
        //メソッド名：RegistrationDetail()
        //引　数   ：受注詳細情報
        //戻り値   ：なし
        //機　能   ：受注詳細データの登録
        ///////////////////////////////
        private void RegistrationDetail(TOrderDetail regDetail)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("受注詳細登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 受注情報の登録
            bool flg = orderDetailDataAccess.AddDetailData(regDetail);
            if (flg == true)
            {
                MessageBox.Show("データを登録しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("データの登録に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txb_JOrderDetail.Focus();
        }
        private void btn_JOrderShowList_Click(object sender, EventArgs e)
        {
            JOrder = orderDataAccess.GetOrderAllData();
            SetDataGridView();
        }
        private void btn_JOrderSearch_Click(object sender, EventArgs e)
        {
            // 8.3 受注検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                JOrderSearch();
            }
        }
        ///////////////////////////////
        //         受注情報検索
        //メソッド名：JOrderSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注データの検索
        ///////////////////////////////
        private void JOrderSearch()
        {
            int flg = 0;
            if (CheckBox_JOrderHidden.Checked)
            {
                flg = 2;
            }

            string orderid = txb_JOrderID.Text.Trim();
            string officeid = txb_JOrderSalesOfficeID.Text.Trim();
            string emid = txb_JOrderEmpID.Text.Trim();
            string cstmrid = txb_JOrderCstmrID.Text.Trim();
            string cstmrcharge = txb_JOrderCstmrEq.Text.Trim();

            //受注IDの適否
            int jorderID = -1;
            if (!string.IsNullOrEmpty(orderid))
            {
                if (int.TryParse(orderid, out int parsedID))
                {
                    jorderID = parsedID;
                }
                else
                {
                    MessageBox.Show("受注IDは数値で入力してください");
                    return;
                }
            }

            //顧客IDの適否
            int customerID = -1;
            if (!string.IsNullOrEmpty(cstmrid))
            {
                if (int.TryParse(cstmrid, out int parsedID))
                {
                    customerID = parsedID;
                }
                else
                {
                    MessageBox.Show("顧客IDは数値で入力してください");
                    return;
                }
            }
            //社員IDの適否
            int empID = -1;
            if (!string.IsNullOrEmpty(emid))
            {
                if (int.TryParse(emid, out int parsedID))
                {
                    empID = parsedID;
                }
                else
                {
                    MessageBox.Show("社員IDは数値で入力してください");
                    return;
                }
            }
            //営業所IDの適否
            int soId = -1;
            if (!string.IsNullOrEmpty(officeid))
            {
                if (int.TryParse(officeid, out int parsedID))
                {
                    soId = parsedID;
                }
                else
                {
                    MessageBox.Show("営業所IDは数値で入力してください");
                    return;
                }
            }

            //検索条件に一致するデータ検索
            var filterJOrder = JOrder
                .Where(c =>
                (jorderID == -1 || c.OrderId == jorderID) &&
                (customerID == -1 || c.ClID == customerID) &&
                (soId == -1 || c.SalesOfficeID == soId) &&
                (empID == -1 || c.EmpId == empID) &&
                (string.IsNullOrEmpty(cstmrcharge) || c.ClCharge.Contains(cstmrcharge))).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterJOrder.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_JOrderPage.Text = "1";
                int pageSize = int.Parse(txb_JOrderPageSize.Text);
                dataGrid_JOrder.DataSource = filterJOrder;
                lbl_JOrderPage.Text = "/" + ((int)Math.Ceiling(filterJOrder.Count / (double)pageSize)) + "ページ";
                dataGrid_JOrder.Refresh();

            }
        }
        private void btn_JOrderHidden_Click(object sender, EventArgs e)
        {
            // 8.4  受注非表示情報更新
            if (!GetValidDataAtHidden())
            {
                return;
            }
            UpdateHidden();
            ClearInput();
            SetDataGridView();
        }
        ///////////////////////////////
        //　妥当な非表示理由データ取得
        //メソッド名：GetValidDataAtHidden()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtHidden()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                //受注IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                //受注IDの文字数チェック
                if (txb_JOrderID.Text.Length > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                // 受注IDの存在チェック
                if (!orderDataAccess.CheckJOrderCDExistence(int.Parse(txb_JOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("受注IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_JOrderHidden.Checked)
            {
                if (HiddenReason == "")
                {
                    DialogResult result = MessageBox.Show("非表示理由を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                HiddenReason = string.Empty;
            }
            return true;
        }
        ///////////////////////////////
        //　 受注非表示情報更新
        //メソッド名：UpdateOrder()
        //引　数   ：受注非表示情報
        //戻り値   ：
        //機　能   ：受注情報の更新
        ///////////////////////////////
        private void UpdateHidden()
        {
            //更新確認メッセージ
            DialogResult result;
            result = MessageBox.Show("非表示更新しますか？", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            int flg = 0;
            if (CheckBox_JOrderHidden.Checked)
            {
                flg = 2;
            }
            if (flg == 0)
            {
                HiddenReason = "";
            }
            //受注情報の更新
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var order = context.TOrders.SingleOrDefault(x => x.OrId == int.Parse(txb_JOrderID.Text));
                    if (order != null)
                    {
                        order.OrFlag = flg;
                        order.OrHidden = HiddenReason;
                        context.SaveChanges();
                        context.Dispose();
                        MessageBox.Show("非表示更新が成功しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("非表示更新が失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_JOrderFix_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregJOrderFix())
            {
                return;
            }
            //注文テーブルに登録
            var regTChumon = GenerateDataAtRegTChumon();
            RegistrationChumon(regTChumon);
        }
        private bool GetValidDataAtregJOrderFix()
        {
            if (!String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                if (!orderDataAccess.CheckJOrderCDExistence(int.Parse(txb_JOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("受注IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderID.Focus();
                return false;
            }
            SalesManagementContext context = new SalesManagementContext();
            var order = context.TOrders.SingleOrDefault(x => x.OrId == int.Parse(txb_JOrderID.Text.Trim()));
            int? flg = order.OrStateFlag;
            int hidden = order.OrFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された受注IDはすでに受注確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された受注IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          注文情報作成
        //メソッド名：GenerateDataAtRegTChumon()
        //引　数   ：なし
        //戻り値   ：注文情報
        //機　能   ：注文データのセット
        ///////////////////////////////
        private TChumon GenerateDataAtRegTChumon()
        {
            SalesManagementContext context = new SalesManagementContext();
            var order = context.TOrders.SingleOrDefault(x => x.OrId == int.Parse(txb_JOrderID.Text.Trim()));
            return new TChumon
            {
                SoId = order.SoId,
                EmId = null,
                ClId = order.ClId,
                OrId = order.OrId,
                ChDate = DateTime.Now,
                ChStateFlag = 0,
                ChFlag = 0,
                ChHidden = ""
            };
        }
        ///////////////////////////////
        //         注文情報登録
        //メソッド名：RegistrationChumon()
        //引　数   ：注文情報
        //戻り値   ：なし
        //機　能   ：注文データの登録
        ///////////////////////////////
        private void RegistrationChumon(TChumon regChumon)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("受注確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 注文情報の登録
            bool flg = chumonDataAccess.AddChumonData(regChumon);


            if (flg == true)
            {
                MessageBox.Show("受注情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var order = context.TOrders.SingleOrDefault(x => x.OrId == int.Parse(txb_JOrderID.Text));
                    if (order != null)
                    {
                        order.OrStateFlag = 1;
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("受注情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTChumonDetail();
            // 入力エリアのクリア
            ClearInput();
        }
        private void GenerateDataAtRegTChumonDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var orderid = int.Parse(txb_JOrderID.Text.Trim());
                var orderDetails = context.TOrderDetails
                    .Where(x => x.OrId == orderid)
                    .OrderBy(x => x.OrId)
                    .ToList();
                var confirmOrderDetails = orderDetails.Select(x => new TChumonDetail
                {
                    ChId = GenerateNewChId(context), // 新しいIDを生成
                    PrId = x.PrId,
                    ChQuantity = x.OrQuantity
                }).ToList();
                context.AddRange(confirmOrderDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("注文詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewChId(SalesManagementContext context)
        {
            // TChumonDetailの現在の最大IDを取得して+1
            return (context.TChumonDetails.Max(x => (int?)x.ChId) ?? 0) + 1;
        }
        private void btn_JOrderFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_JOrderSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_JOrderSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_JOrderBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_JOrderSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_JOrderSelectForm.Items.Add("顧客管理画面");
                cmb_JOrderSelectForm.Items.Add("商品管理画面");
                cmb_JOrderSelectForm.Items.Add("在庫管理画面");
                cmb_JOrderSelectForm.Items.Add("社員管理画面");
                cmb_JOrderSelectForm.Items.Add("注文管理画面");
                cmb_JOrderSelectForm.Items.Add("入庫管理画面");
                cmb_JOrderSelectForm.Items.Add("出庫管理画面");
                cmb_JOrderSelectForm.Items.Add("入荷管理画面");
                cmb_JOrderSelectForm.Items.Add("出荷管理画面");
                cmb_JOrderSelectForm.Items.Add("売上管理画面");
                cmb_JOrderSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_JOrderSelectForm.Items.Add("商品管理画面");
                cmb_JOrderSelectForm.Items.Add("在庫管理画面");
                cmb_JOrderSelectForm.Items.Add("入庫管理画面");
                cmb_JOrderSelectForm.Items.Add("出庫管理画面");
                cmb_JOrderSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_JOrderSelectForm.Items.Add("顧客管理画面");
                cmb_JOrderSelectForm.Items.Add("注文管理画面");
                cmb_JOrderSelectForm.Items.Add("入荷管理画面");
                cmb_JOrderSelectForm.Items.Add("出荷管理画面");
                cmb_JOrderSelectForm.Items.Add("売上管理画面");
            }
        }
        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            txb_JOrderPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_JOrderPage.Text = "1";
            //読み取り専用に指定
            dataGrid_JOrder.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_JOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_JOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {

            // 受注データの取得
            JOrder = orderDataAccess.GetOrderData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            int pageSize = int.Parse(txb_JOrderPageSize.Text);
            int pageNo = int.Parse(txb_JOrderPage.Text) - 1;
            dataGrid_JOrder.DataSource = JOrder.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_JOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_JOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_JOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_JOrder.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            lbl_JOrderPage.Text = "/" + ((int)Math.Ceiling(JOrder.Count / (double)pageSize)) + "ページ";

            dataGrid_JOrder.Refresh();

        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_JOrderChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_JOrderFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_JOrderPageSize.Text);
            dataGrid_JOrder.DataSource = JOrder.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_JOrder.Refresh();
            //ページ番号の設定
            txb_JOrderPage.Text = "1";
        }

        private void btn_JOrderPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_JOrderPageSize.Text);
            int pageNo = int.Parse(txb_JOrderPage.Text) - 2;
            dataGrid_JOrder.DataSource = JOrder.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_JOrder.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_JOrderPage.Text = (pageNo + 1).ToString();
            else
                txb_JOrderPage.Text = "1";
        }

        private void btn_JOrderNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_JOrderPageSize.Text);
            int pageNo = int.Parse(txb_JOrderPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(JOrder.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_JOrder.DataSource = JOrder.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_JOrder.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(JOrder.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_JOrderPage.Text = lastPage.ToString();
            else
                txb_JOrderPage.Text = (pageNo + 1).ToString();
        }

        private void btn_JOrderLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_JOrderPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(JOrder.Count / (double)pageSize) - 1;
            dataGrid_JOrder.DataSource = JOrder.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_JOrder.Refresh();
            //ページ番号の設定
            txb_JOrderPage.Text = (pageNo + 1).ToString();
        }
        private void txb_JOrderSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_JOrderSalesOfficeID.Text))
            {
                if (int.TryParse(txb_JOrderSalesOfficeID.Text, out int soId))
                {
                    GetSoId(int.Parse(txb_JOrderSalesOfficeID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderSalesOfficeID.Text = string.Empty;
                }
            }
            else
            {
                txb_JOrderSalesOfficeID.Text = string.Empty;
                txb_JOrderSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_JOrderSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_JOrderSalesOfficeName.Text = string.Empty;
                }
            }
        }
        private void txb_JOrderEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_JOrderEmpID.Text))
            {
                if (int.TryParse(txb_JOrderEmpID.Text, out int empId))
                {
                    GetEmpId(int.Parse(txb_JOrderEmpID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderEmpID.Text = string.Empty;
                }
            }
            else
            {
                txb_JOrderEmpID.Text = string.Empty;
                txb_JOrderEmpName.Text = string.Empty;
            }
        }
        private void GetEmpId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_JOrderEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_JOrderEmpName.Text = string.Empty;
                }
            }
        }
        private void txb_JOrderCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_JOrderCstmrID.Text))
            {
                if (int.TryParse(txb_JOrderCstmrID.Text, out int cstmrId))
                {
                    GetCstmrId(int.Parse(txb_JOrderCstmrID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderCstmrID.Text = string.Empty;
                }
            }
            else
            {
                txb_JOrderCstmrID.Text = string.Empty;
                txb_JOrderCstmrName.Text = string.Empty;
            }
        }
        private void GetCstmrId(int cstmrid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == cstmrid);
                if (Cstmr != null)
                {
                    txb_JOrderCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_JOrderCstmrName.Text = string.Empty;
                }
            }
        }
        private void tbx_JOrderProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_JOrderProductID.Text))
            {
                if (int.TryParse(txb_JOrderProductID.Text, out int empId))
                {
                    GetPrice(int.Parse(txb_JOrderProductID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderProductID.Text = string.Empty;
                }
            }
            else
            {
                txb_JOrderProductName.Text = string.Empty;
                txb_JOrderPrice.Text = string.Empty;
                txb_JOrderTotalPrice.Text = string.Empty;
            }
        }
        private void GetPrice(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_JOrderProductName.Text = product.PrName;
                    txb_JOrderPrice.Text = product.Price.ToString();
                    TotalPrice();
                }
                else
                {
                    txb_JOrderPrice.Text = "0";
                    txb_JOrderTotalPrice.Text = string.Empty;
                }
            }
        }

        private void txb_JOrderProductcnt_TextChanged(object sender, EventArgs e)
        {
            TotalPrice();
        }

        private void TotalPrice()
        {
            if (decimal.TryParse(txb_JOrderPrice.Text, out decimal price)
                && int.TryParse(txb_JOrderProductcnt.Text, out int productcnt))
            {
                decimal total = price * productcnt;
                txb_JOrderTotalPrice.Text = total.ToString();
            }
            else
            {
                txb_JOrderTotalPrice.Text = string.Empty;
            }
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_JOrderID.Text = "";
            txb_JOrderDetail.Text = "";
            dtp_JOrderDate.Text = "";
            txb_JOrderSalesOfficeID.Text = "";
            txb_JOrderSalesOfficeName.Text = "";
            txb_JOrderEmpID.Text = "";
            txb_JOrderEmpName.Text = "";
            txb_JOrderCstmrID.Text = "";
            txb_JOrderCstmrName.Text = "";
            txb_JOrderCstmrEq.Text = "";
            txb_JOrderProductID.Text = "";
            txb_JOrderProductName.Text = "";
            txb_JOrderPrice.Text = "";
            txb_JOrderProductcnt.Text = "";
            txb_JOrderTotalPrice.Text = "";
            CheckBox_JOrderHidden.Checked = false;
            GetDataGridView();
        }
        private void btn_JOrderShowSalesOffice_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "営業所データ",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(800, 600),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            //表示したフォームにデータグリッドを表示
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_JOrderSalesOfficeID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_JOrderSalesOfficeName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeDspData();
            dataGridView.DataSource = SalesOffice;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void btn_JOrderShowEmp_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "社員データ",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(800, 600),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            //表示したフォームにデータグリッドを表示
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_JOrderEmpID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_JOrderEmpName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            Emloyee = empDataAccess.GetEmployeeDspData();
            dataGridView.DataSource = Emloyee;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void btn_JOrderShowCustomer_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "顧客データ",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(800, 600),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            //表示したフォームにデータグリッドを表示
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_JOrderCstmrID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_JOrderCstmrName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            Client = clientDataAccess.GetClientData();
            dataGridView.DataSource = Client;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void txb_JOrderShowProduct_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "商品データ",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(1200, 800),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            //表示したフォームにデータグリッドを表示
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_JOrderProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_JOrderProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            Product = productDataAccess.GetProductDspData();
            dataGridView.DataSource = Product;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void btn_JOrderShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "受注詳細データ",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(800, 600),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
            };
            //表示したフォームにデータグリッドを表示
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_JOrderDetail.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_JOrderID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_JOrderProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_JOrderProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_JOrderProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_JOrderID.Text != "")
            {
                int orderid = int.Parse(txb_JOrderID.Text);
                OrderDetail = orderDetailDataAccess.GetOrderDetailSelectData(orderid);
            }
            else
            {
                OrderDetail = orderDetailDataAccess.GetOrderDetailDspData();
            }
            dataGridView.DataSource = OrderDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }
        ///////////////////////////////
        //メソッド名：CheckAllTextBoxesFiled()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：テクストボックス入力チェック
        ///////////////////////////////
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_JOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderDetail.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderSalesOfficeID.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderCstmrID.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderCstmrEq.Text) &&
                   string.IsNullOrWhiteSpace(txb_JOrderProductcnt.Text);
        }

        private void btn_JOrderHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_JOrderHidden.Checked)
            {
                int orderid = int.Parse(txb_JOrderID.Text);
                HiddenReason = ShowHiddenReason(orderid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_JOrderHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int orderid)
        {

            Form dialog = new Form()
            {
                Width = 530,
                Height = 427,
                Text = "非表示理由入力",
                StartPosition = FormStartPosition.CenterScreen,
            };
            Label label = new Label
            {
                Location = new Point(12, 22),
                Text = "非表示理由を入力してください",
                Size = new Size(158, 32)
            };
            RichTextBox RichBox = new RichTextBox
            {
                Location = new Point(12, 76),
                Size = new Size(490, 300),
                Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
            };
            Button backButton = new Button
            {
                Location = new Point(437, 12),
                Size = new Size(65, 35),
                Text = "戻る",
                DialogResult = DialogResult.OK,
            };

            //ダイアログコントロールを追加
            dialog.Controls.Add(label);
            dialog.Controls.Add(RichBox);
            dialog.Controls.Add(backButton);

            //ボタンの動作を追加
            dialog.AcceptButton = backButton;

            string HideReason = string.Empty;
            using (var context = new SalesManagementContext())
            {
                var Order = context.TOrders.Where(c => c.OrId == orderid).FirstOrDefault();
                if (Order != null && !string.IsNullOrEmpty(Order.OrHidden))
                {
                    HideReason = Order.OrHidden;
                }
            }
            RichBox.Text = String.IsNullOrEmpty(HideReason) ? string.Empty : HideReason;
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();

            //結果を取得
            return result == DialogResult.OK ? RichBox.Text : null;
        }
        ///////////////////////////////
        //メソッド名：GetValidData()
        //引　数   ：なし
        //戻り値   ：True or False
        //機　能   ：受注IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_JOrderID.Text.Trim()))
            {
                // 受注IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_JOrderID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                // 受注IDの文字数チェック
                if (txb_JOrderID.TextLength > 2)
                {
                    MessageBox.Show("受注IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
                if (!orderDataAccess.CheckJOrderCDExistence(int.Parse(txb_JOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_JOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("受注IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_JOrderID.Focus();
                return false;
            }
            return true;
        }

        private void dataGrid_JOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_JOrderID.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[0].Value.ToString();
            txb_JOrderSalesOfficeID.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[1].Value.ToString();
            txb_JOrderSalesOfficeName.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[2].Value.ToString();
            txb_JOrderEmpID.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[3].Value.ToString();
            txb_JOrderEmpName.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[4].Value.ToString();
            txb_JOrderCstmrID.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[5].Value.ToString();
            txb_JOrderCstmrName.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[6].Value.ToString();
            txb_JOrderCstmrEq.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[7].Value.ToString();
            dtp_JOrderDate.Text = dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[8].Value.ToString();

            int flg = int.Parse(dataGrid_JOrder.Rows[dataGrid_JOrder.CurrentRow.Index].Cells[10].Value.ToString());
            if (flg == 0)
            {
                CheckBox_JOrderHidden.Checked = false;
            }
            else
            {
                CheckBox_JOrderHidden.Checked = true;
            }
        }

        private void btn_JOrderInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
