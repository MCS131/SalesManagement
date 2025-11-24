using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using SalesManagement_SysDev.Forms.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;

namespace SalesManagement_SysDev
{
    public partial class F_HOrder : Form
    {
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        HattyuDataAccess hattyuDataAccess = new HattyuDataAccess();
        HattyuDetailDataAccess hattyuDetailDataAccess = new HattyuDetailDataAccess();
        WarehousingDataAccess warehousingDataAccess = new WarehousingDataAccess();
        WarehousingDetailDataAccess warehousingDetailDataAccess = new WarehousingDetailDataAccess();
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        ProductDataAccess productDataAccess = new ProductDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の顧客データ
        private static List<THattyuDsp> Hattyu;
        private static List<MMakerDsp> Maker;
        private static List<MEmployeeDsp> Employee;
        private static List<THattyuDetailDsp> HattyuDetail;
        private static List<MProductDsp> Product;

        //名前・権限・日付・非表示理由設定
        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_HOrder()
        {
            InitializeComponent();
        }
        private void F_HOrder_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_HOrderLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_HOrderkengenmei.Text = "権限名：" + kengenmei;
            lbl_HODate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
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
            if (kengenmei == "営業")
            {
                btn_HOrderAdd.Enabled = flg;
                btn_HOrderHidden.Enabled = flg;
                btn_HOrderFix.Enabled = flg;
                CheckBox_HOrderHidden.Enabled = flg;
            }

        }
        private void btn_HOrderAdd_Click(object sender, EventArgs e)
        {
            //10.1発注登録・発注詳細登録
            if (String.IsNullOrEmpty(txb_HOrderID.Text.Trim()))
            {
                if (!GetValidDataAtRegistration())
                {
                    return;
                }
                //発注テーブルに登録
                var regHOrder = GenerateDataAtRegHOrder();
                RegistrationHOrder(regHOrder);
            }
            else if (!String.IsNullOrEmpty(txb_HOrderID.Text.Trim()))
            {
                if (!GetValidDetailDataAtRegistration())
                {
                    return;
                }
                //発注詳細テーブルに登録
                var regHOrderDetail = GenerateDataAtRegHOrderDetail();
                RegistrationDetail(regHOrderDetail);
            }
        }
        ///////////////////////////////
        //          発注情報を得る
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            // メーカーIDの適否
            if (!String.IsNullOrEmpty(txb_HOrderMakerID.Text.Trim()))
            {
                // メーカIDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderMakerID.Text.Trim()))
                {
                    MessageBox.Show("メーカーIDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderMakerID.Focus();
                    return false;
                }
                // メーカIDの文字数チェック
                if (txb_HOrderMakerID.TextLength > 4)
                {
                    MessageBox.Show("メーカーIDは4文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderMakerID.Focus();
                    return false;
                }
                //メーカIDの存在チェック
                if (!hattyuDataAccess.CheckMaIdCDExistence(int.Parse(txb_HOrderMakerID.Text.Trim())))
                {
                    MessageBox.Show("入力されたメーカーIDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderMakerID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("メーカーIDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderMakerID.Focus();
                return false;
            }

            // 社員IDの適否
            if (!String.IsNullOrEmpty(txb_HOrderEmpID.Text.Trim()))
            {
                // 社員IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderEmpID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderEmpID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (txb_HOrderEmpID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderEmpID.Focus();
                    return false;
                }
                //社員IDの存在チェック
                if (!hattyuDataAccess.CheckEmIdCDExistence(int.Parse(txb_HOrderEmpID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderEmpID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderEmpID.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          発注情報作成
        //メソッド名：GenerateDataAtRegHOrder()
        //引　数   ：なし
        //戻り値   ：発注登録情報
        //機　能   ：発注データのセット
        ///////////////////////////////
        private THattyu GenerateDataAtRegHOrder()
        {
            int flg = 0;
            if (CheckBox_HOrderHidden.Checked)
            {
                flg = 2;
            }
            return new THattyu
            {
                MaId = int.Parse(txb_HOrderMakerID.Text.Trim()),
                EmId = int.Parse(txb_HOrderEmpID.Text.Trim()),
                HaDate = dtp_HOrderdate.Value,
                HaFlag = flg,
                WaWarehouseFlag = 0,
            };
        }
        ///////////////////////////////
        //         発注情報登録
        //メソッド名：RegistrationHOrder()
        //引　数   ：発注情報
        //戻り値   ：なし
        //機　能   ：発注データの登録
        ///////////////////////////////
        private void RegistrationHOrder(THattyu regHOrder)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("発注登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 発注情報の登録
            bool flg = hattyuDataAccess.AddHOrderData(regHOrder);
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
            txb_HOrderID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }
        ///////////////////////////////
        //          発注詳細情報を得る
        //メソッド名：GetValidDetailDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDetailDataAtRegistration()
        {
            if (!dataInputFormCheck.CheckNumeric(txb_HOrderID.Text.Trim()))
            {
                MessageBox.Show("発注IDはすべて数字です", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txb_HOrderID.Text.Length > 6)
            {
                MessageBox.Show("発注IDは6桁までです", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderID.Focus();
                return false;
            }
            if (!hattyuDataAccess.CheckHaIdCDExistence(int.Parse(txb_HOrderID.Text.Trim())))
            {
                MessageBox.Show("発注IDが存在しません", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderID.Focus();
                return false;
            }
            // 商品IDの適否
            if (!String.IsNullOrEmpty(txb_HOrderProductID.Text.Trim()))
            {
                // 商品IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderProductID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductID.Focus();
                    return false;
                }
                // 商品IDの文字数チェック
                if (txb_HOrderProductID.TextLength > 4)
                {
                    MessageBox.Show("商品IDは4文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductID.Focus();
                    return false;
                }
                //商品IDの存在チェック
                if (!hattyuDataAccess.CheckPrIdCDExistence(int.Parse(txb_HOrderProductID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("商品IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderProductID.Focus();
                return false;
            }
            //数量の適否
            if (!String.IsNullOrEmpty(txb_HOrderProductcnt.Text.Trim()))
            {
                //数量の入力形式のチェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderProductcnt.Text.Trim()))
                {
                    MessageBox.Show("数量は全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductcnt.Focus();
                    return false;
                }
                //数量の文字数チェック
                if (txb_HOrderProductcnt.Text.Length > 4)
                {
                    MessageBox.Show("数量は4桁までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductcnt.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("数量が入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderProductcnt.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          発注詳細情報作成
        //メソッド名：GenerateDataAtRegHOrderDetail()
        //引　数   ：なし
        //戻り値   ：発注詳細登録情報
        //機　能   ：発注詳細データのセット
        ///////////////////////////////
        private THattyuDetail GenerateDataAtRegHOrderDetail()
        {
            return new THattyuDetail
            {
                HaId = int.Parse(txb_HOrderID.Text.Trim()),
                PrId = int.Parse(txb_HOrderProductID.Text.Trim()),
                HaQuantity = int.Parse(txb_HOrderProductcnt.Text.Trim()),
            };
        }
        private void RegistrationDetail(THattyuDetail regDetail)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("発注詳細登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 発注詳細情報の登録
            bool flg = hattyuDetailDataAccess.AddDetailData(regDetail);
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
            txb_HOrderProductID.Focus();
        }
        private void btn_HOrderShowList_Click(object sender, EventArgs e)
        {
            //10.2 発注済未入庫一覧表示
            Hattyu = hattyuDataAccess.GetHattyuNotStockData();
            SetDataGridView();
        }
        private void btn_HOrderSearch_Click(object sender, EventArgs e)
        {
            // 10.3 受注検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                HOrderSearch();
            }
        }
        ///////////////////////////////
        //         発注情報検索
        //メソッド名：HOrderSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：発注データの検索
        ///////////////////////////////
        private void HOrderSearch()
        {
            int flg = 0;
            if (CheckBox_HOrderHidden.Checked)
            {
                flg = 2;
            }

            string horderid = txb_HOrderID.Text.Trim();
            string emid = txb_HOrderEmpID.Text.Trim();
            string makerid = txb_HOrderMakerID.Text.Trim();

            //発注IDの適否
            int horderID = -1;
            if (!string.IsNullOrEmpty(horderid))
            {
                if (int.TryParse(horderid, out int parsedID))
                {
                    horderID = parsedID;
                }
                else
                {
                    MessageBox.Show("発注IDは数値で入力してください");
                    return;
                }
            }

            //メーカIDの適否
            int makerID = -1;
            if (!string.IsNullOrEmpty(makerid))
            {
                if (int.TryParse(makerid, out int parsedID))
                {
                    makerID = parsedID;
                }
                else
                {
                    MessageBox.Show("メーカIDは数値で入力してください");
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

            //検索条件に一致するデータ検索
            var filterHOrder = Hattyu
                .Where(c =>
                (horderID == -1 || c.HaId == horderID) &&
                (makerID == -1 || c.MaId == makerID) &&
                (empID == -1 || c.EmId == empID)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterHOrder.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_HOrderPage.Text = "1";
                int pageSize = int.Parse(txb_HOrderPageSize.Text);
                dataGrid_HOrder.DataSource = filterHOrder;
                lbl_HOrderPage.Text = "/" + ((int)Math.Ceiling(filterHOrder.Count / (double)pageSize)) + "ページ";
                dataGrid_HOrder.Refresh();

            }
        }
        private void btn_HOrderHidden_Click(object sender, EventArgs e)
        {
            //10,4 発注非表示情報更新
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
            //発注IDの適否
            if (!String.IsNullOrEmpty(txb_HOrderID.Text.Trim()))
            {
                //発注IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderID.Text.Trim()))
                {
                    MessageBox.Show("発注IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
                //発注IDの文字数チェック
                if (txb_HOrderID.Text.Length > 6)
                {
                    MessageBox.Show("発注IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
                // 発注IDの存在チェック
                if (!hattyuDataAccess.CheckHaIdCDExistence(int.Parse(txb_HOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された発注IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("発注IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_HOrderHidden.Checked)
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
            if (CheckBox_HOrderHidden.Checked)
            {
                flg = 2;
            }
            if (flg == 0)
            {
                HiddenReason = "";
            }
            //発注情報の更新
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var horder = context.THattyus.SingleOrDefault(x => x.HaId == int.Parse(txb_HOrderID.Text));
                    if (horder != null)
                    {
                        horder.HaFlag = flg;
                        horder.HaHidden = HiddenReason;
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
        private void btn_HOrderFix_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregHOrderFix())
            {
                return;
            }
            //入庫テーブルに登録
            var regTWarehousing = GenerateDataAtRegTWarehousing();
            RegistrationWarehousing(regTWarehousing);
        }
        ///////////////////////////////
        //         入庫情報登録
        //メソッド名：RegistrationWarehousing()
        //引　数   ：入庫情報
        //戻り値   ：なし
        //機　能   ：入庫データの登録
        ///////////////////////////////
        private void RegistrationWarehousing(TWarehousing regWarehousing)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("発注確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 入庫情報の登録
            bool flg = warehousingDataAccess.AddWarehousingData(regWarehousing);


            if (flg == true)
            {
                MessageBox.Show("発注情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var hattyu = context.THattyus.SingleOrDefault(x => x.HaId == int.Parse(txb_HOrderID.Text));
                    if (hattyu != null)
                    {
                        hattyu.WaWarehouseFlag = 1;
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("発注情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTWarehousingDetail();
            // 入力エリアのクリア
            ClearInput();
        }
        private bool GetValidDataAtregHOrderFix()
        {
            if (!String.IsNullOrEmpty(txb_HOrderID.Text.Trim()))
            {
                if (!hattyuDataAccess.CheckHaIdCDExistence(int.Parse(txb_HOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された発注IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("発注IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderID.Focus();
                return false;
            }
            SalesManagementContext context = new SalesManagementContext();
            var hattyu = context.THattyus.SingleOrDefault(x => x.HaId == int.Parse(txb_HOrderID.Text.Trim()));
            int? flg = hattyu.WaWarehouseFlag;
            int hidden = hattyu.HaFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された発注IDはすでに発注確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された発注IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          入庫情報作成
        //メソッド名：GenerateDataAtRegTWarehousing()
        //引　数   ：なし
        //戻り値   ：入庫情報
        //機　能   ：入庫データのセット
        ///////////////////////////////
        private TWarehousing GenerateDataAtRegTWarehousing()
        {
            SalesManagementContext context = new SalesManagementContext();
            var Horder = context.THattyus.SingleOrDefault(x => x.HaId == int.Parse(txb_HOrderID.Text.Trim()));
            return new TWarehousing
            {
                HaId = Horder.HaId,
                EmId = Horder.EmId,
                WaDate = DateTime.Now,
                WaShelfFlag = 0,
                WaFlag = 0,
                WaHidden = ""
            };
        }
        private void GenerateDataAtRegTWarehousingDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var horderid = int.Parse(txb_HOrderID.Text.Trim());
                var horderDetails = context.THattyuDetails
                    .Where(x => x.HaId == horderid)
                    .OrderBy(x => x.HaId)
                    .ToList();
                var confirmOrderDetails = horderDetails.Select(x => new TWarehousingDetail
                {
                    WaId = GenerateNewWaId(context), // 新しいIDを生成
                    PrId = x.PrId,
                    WaQuantity = x.HaQuantity
                }).ToList();
                context.AddRange(confirmOrderDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("入庫詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewWaId(SalesManagementContext context)
        {
            // TWarehousingDetailの現在の最大IDを取得して+1
            return (context.TWarehousingDetails.Max(x => (int?)x.WaId) ?? 0) + 1;
        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_HOrderSelectForm.Items.Add("顧客管理画面");
                cmb_HOrderSelectForm.Items.Add("商品管理画面");
                cmb_HOrderSelectForm.Items.Add("在庫管理画面");
                cmb_HOrderSelectForm.Items.Add("社員管理画面");
                cmb_HOrderSelectForm.Items.Add("受注管理画面");
                cmb_HOrderSelectForm.Items.Add("注文管理画面");
                cmb_HOrderSelectForm.Items.Add("入庫管理画面");
                cmb_HOrderSelectForm.Items.Add("出庫管理画面");
                cmb_HOrderSelectForm.Items.Add("入荷管理画面");
                cmb_HOrderSelectForm.Items.Add("出荷管理画面");
                cmb_HOrderSelectForm.Items.Add("売上管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_HOrderSelectForm.Items.Add("商品管理画面");
                cmb_HOrderSelectForm.Items.Add("在庫管理画面");
                cmb_HOrderSelectForm.Items.Add("入庫管理画面");
                cmb_HOrderSelectForm.Items.Add("出庫管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_HOrderSelectForm.Items.Add("受注管理画面");
                cmb_HOrderSelectForm.Items.Add("注文管理画面");
                cmb_HOrderSelectForm.Items.Add("入荷管理画面");
                cmb_HOrderSelectForm.Items.Add("出荷管理画面");
                cmb_HOrderSelectForm.Items.Add("売上管理画面");
            }
        }

        private void btn_HOrderFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_HOrderSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_HOrderSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_HOrderBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_HOrderSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_HOrderChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_HOrderFirstPage_Click(object sender, EventArgs e)
        {

            int pageSize = int.Parse(txb_HOrderPageSize.Text);
            dataGrid_HOrder.DataSource = Hattyu.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_HOrder.Refresh();
            //ページ番号の設定
            txb_HOrderPage.Text = "1";
        }

        private void btn_HOrderPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_HOrderPageSize.Text);
            int pageNo = int.Parse(txb_HOrderPage.Text) - 2;
            dataGrid_HOrder.DataSource = Hattyu.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_HOrder.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_HOrderPage.Text = (pageNo + 1).ToString();
            else
                txb_HOrderPage.Text = "1";
        }

        private void btn_HOrderNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_HOrderPageSize.Text);
            int pageNo = int.Parse(txb_HOrderPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Hattyu.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_HOrder.DataSource = Hattyu.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_HOrder.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Hattyu.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_HOrderPage.Text = lastPage.ToString();
            else
                txb_HOrderPage.Text = (pageNo + 1).ToString();
        }

        private void btn_HOrderLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_HOrderPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Hattyu.Count / (double)pageSize) - 1;
            dataGrid_HOrder.DataSource = Hattyu.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_HOrder.Refresh();
            //ページ番号の設定
            txb_HOrderPage.Text = (pageNo + 1).ToString();
        }

        ///////////////////////////////
        //メソッド名：btn_HOrderChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_HOrderChangeSize_Click_1(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void dgv_HOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_HOrderID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[0].Value.ToString();
            txb_HOrderMakerID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[1].Value.ToString();
            txb_HOrderProductID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[2].Value.ToString();
            txb_HOrderProductcnt.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[3].Value.ToString();
            txb_HOrderDatailID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[4].Value.ToString();
            txb_HOrderEmpID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[5].Value.ToString();
            dtp_HOrderdate.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[6].Value.ToString();

            int flg = int.Parse(dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[7].Value.ToString());
            if (flg == 0)
            {
                CheckBox_HOrderHidden.Checked = false;
            }
            else
            {
                CheckBox_HOrderHidden.Checked = true;
            }
        }
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_HOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_HOrderMakerID.Text) &&
                   string.IsNullOrWhiteSpace(txb_HOrderProductID.Text) &&
                   string.IsNullOrWhiteSpace(txb_HOrderProductcnt.Text) &&
                   string.IsNullOrWhiteSpace(txb_HOrderDatailID.Text) &&
                   string.IsNullOrWhiteSpace(txb_HOrderEmpID.Text) &&
                   string.IsNullOrWhiteSpace(dtp_HOrderdate.Text);
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
            txb_HOrderPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_HOrderPage.Text = "1";
            //読み取り専用に指定
            dataGrid_HOrder.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_HOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_HOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            //発注データの取得
            Hattyu = hattyuDataAccess.GetHattyuDspData();

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
            int pageSize = int.Parse(txb_HOrderPageSize.Text);
            int pageNo = int.Parse(txb_HOrderPage.Text) - 1;
            dataGrid_HOrder.DataSource = Hattyu.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_HOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_HOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_HOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_HOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            lbl_HOrderPage.Text = "/" + ((int)Math.Ceiling(Hattyu.Count / (double)pageSize)) + "ページ";

            dataGrid_HOrder.Refresh();

        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_HOrderID.Text = "";
            txb_HOrderDatailID.Text = "";
            dtp_HOrderdate.Text = "";
            txb_HOrderEmpID.Text = "";
            txb_HOrderEmpName.Text = "";
            txb_HOrderMakerID.Text = "";
            txb_HOrderMakerName.Text = "";
            txb_HOrderProductID.Text = "";
            txb_HOrderProductName.Text = "";
            txb_HOrderPrice.Text = "";
            txb_HOrderProductcnt.Text = "";
            CheckBox_HOrderHidden.Checked = false;
            GetDataGridView();
        }

        private void btn_HOrderShowMaker_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form dialog = new Form
            {
                Text = "メーカーデータ",
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
                txb_HOrderMakerID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_HOrderMakerName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            dialog.Controls.Add(dataGridView);

            Maker = makerDataAccess.GetMakerDspData();
            dataGridView.DataSource = Maker;

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

            dialog.ShowDialog();
        }

        private void btn_HOrderShowEmp_Click(object sender, EventArgs e)
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
                txb_HOrderEmpID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_HOrderEmpName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            Employee = empDataAccess.GetEmployeeDspData();
            dataGridView.DataSource = Employee;
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

        private void btn_HOrderShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "発注詳細データ",
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
                txb_HOrderDatailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_HOrderID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_HOrderProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_HOrderProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_HOrderProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            if (txb_HOrderID.Text != "")
            {
                int horderid = int.Parse(txb_HOrderID.Text);
                HattyuDetail = hattyuDetailDataAccess.GetHattyuDetailSelectData(horderid);
            }
            else
            {
                HattyuDetail = hattyuDetailDataAccess.GetHattyuDetailDspData();
            }
            dataGridView.DataSource = HattyuDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void btn_HOrderHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_HOrderHidden.Checked)
            {
                int horderid = int.Parse(txb_HOrderID.Text);
                HiddenReason = ShowHiddenReason(horderid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_HOrderHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int Horderid)
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
                var HOrder = context.THattyus.Where(c => c.HaId == Horderid).FirstOrDefault();
                if (HOrder != null && !string.IsNullOrEmpty(HOrder.HaHidden))
                {
                    HideReason = HOrder.HaHidden;
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
        //機　能   ：発注IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_HOrderID.Text.Trim()))
            {
                // 発注IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_HOrderID.Text.Trim()))
                {
                    MessageBox.Show("発注IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
                // 発注IDの文字数チェック
                if (txb_HOrderID.TextLength > 6)
                {
                    MessageBox.Show("発注IDは6桁までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
                if (!hattyuDataAccess.CheckHaIdCDExistence(int.Parse(txb_HOrderID.Text.Trim())))
                {
                    MessageBox.Show("入力された発注IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("受注IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_HOrderID.Focus();
                return false;
            }
            return true;
        }

        private void txb_HOrderProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_HOrderProductID.Text))
            {
                if (int.TryParse(txb_HOrderProductID.Text, out int Id))
                {
                    GetPrice(int.Parse(txb_HOrderProductID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderProductID.Text = string.Empty;
                }
            }
            else
            {
                txb_HOrderProductName.Text = string.Empty;
                txb_HOrderPrice.Text = string.Empty;
            }
        }
        private void GetPrice(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_HOrderProductName.Text = product.PrName;
                    txb_HOrderPrice.Text = product.Price.ToString();
                    TotalPrice();
                }
                else
                {
                    txb_HOrderPrice.Text = "0";
                }
            }
        }
        private void txb_HOrderProductcnt_TextChanged(object sender, EventArgs e)
        {
            TotalPrice();
        }
        private void TotalPrice()
        {
            if (decimal.TryParse(txb_HOrderPrice.Text, out decimal price)
                && int.TryParse(txb_HOrderProductcnt.Text, out int productcnt))
            {
                decimal total = price * productcnt;
                txb_HOrderTotalPrice.Text = total.ToString();
            }
            else
            {
                txb_HOrderTotalPrice.Text = string.Empty;
            }
        }
        private void txb_HOrderMakerID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_HOrderMakerID.Text))
            {
                if (int.TryParse(txb_HOrderMakerID.Text, out int Id))
                {
                    GetMakerId(int.Parse(txb_HOrderMakerID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderMakerID.Text = string.Empty;
                }
            }
            else
            {
                txb_HOrderMakerID.Text = string.Empty;
                txb_HOrderMakerName.Text = string.Empty;
            }
        }
        private void GetMakerId(int makerID)
        {
            using (var context = new SalesManagementContext())
            {
                var maker = context.MMakers.FirstOrDefault(x => x.MaId == makerID);
                if (maker != null)
                {
                    txb_HOrderMakerName.Text = maker.MaName;
                }
                else
                {
                    txb_HOrderMakerName.Text = string.Empty;
                }
            }
        }

        private void txb_HOrderEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_HOrderEmpID.Text))
            {
                if (int.TryParse(txb_HOrderEmpID.Text, out int stockId))
                {
                    GetEmpId(int.Parse(txb_HOrderEmpID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_HOrderEmpID.Text = string.Empty;
                }
            }
            else
            {
                txb_HOrderEmpID.Text = string.Empty;
                txb_HOrderEmpName.Text = string.Empty;
            }
        }
        private void GetEmpId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_HOrderEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_HOrderEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_HOrderShowProduct_Click(object sender, EventArgs e)
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
                txb_HOrderProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_HOrderProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
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

        private void btn_JOrderInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void dataGrid_HOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_HOrderID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[0].Value.ToString();
            txb_HOrderMakerID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[1].Value.ToString();
            txb_HOrderEmpID.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[3].Value?.ToString() ?? string.Empty;
            dtp_HOrderdate.Text = dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[5].Value?.ToString() ?? string.Empty;

            int flg = int.Parse(dataGrid_HOrder.Rows[dataGrid_HOrder.CurrentRow.Index].Cells[7].Value.ToString());
            if (flg == 0)
            {
                CheckBox_HOrderHidden.Checked = false;
            }
            else
            {
                CheckBox_HOrderHidden.Checked = true;
            }
        }
    }
}
