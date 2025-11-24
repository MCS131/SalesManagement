using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using SalesManagement_SysDev.Forms;
using SalesManagement_SysDev.Forms.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;

namespace SalesManagement_SysDev
{
    public partial class F_Product : Form
    {
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        SmallClassificationDataAccess smallDataAccess = new SmallClassificationDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の商品データ
        private static List<MProductDsp> Product;
        private static List<MMakerDsp> maker;
        private static List<MSmallDsp> small;

        internal static string HiddenReason = "";
        //名前・権限・日付設定
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Product()
        {
            InitializeComponent();
        }
        private void F_Product_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_ProdLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Prodkengenmei.Text = "権限名：" + kengenmei;
            lbl_ProdDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

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
                btn_ProdAdd.Enabled = flg;
                btn_ProdHidden.Enabled = flg;
                CheckBox_ProdHidden.Enabled = flg;
                btn_ProdHiddenReason.Enabled = flg;
            }

        }
        private void btn_ProdAdd_Click(object sender, EventArgs e)
        {
            //4.1 商品情報を登録
            if (!GetValidDataAtRegistration())
                return;
            var regProduct = GenerateDataAtRegistration();
            RegistrationProduct(regProduct);
        }
        ///////////////////////////////
        //          商品情報を得る
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
            if (!String.IsNullOrEmpty(txb_ProdMakerID.Text.Trim()))
            {
                // メーカーIDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdMakerID.Text.Trim()))
                {
                    MessageBox.Show("メーカーIDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMakerID.Focus();
                    return false;
                }
                // メーカーIDの文字数チェック
                if (txb_ProdMakerID.TextLength > 4)
                {
                    MessageBox.Show("メーカーIDは4文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMakerID.Focus();
                    return false;
                }
                // メーカーIDの存在チェック
                if (!productDataAccess.CheckMaIdCDExistence(int.Parse(txb_ProdMakerID.Text.Trim())))
                {
                    MessageBox.Show("入力されたメーカーIDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMakerID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("メーカーIDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdMakerID.Focus();
                return false;
            }

            // 商品名の適否
            if (!String.IsNullOrEmpty(txb_ProdPrdctName.Text.Trim()))
            {
                // 商品名の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_ProdPrdctName.Text.Trim()))
                {
                    MessageBox.Show("商品名は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctName.Focus();
                    return false;
                }
                // 商品名の文字数チェック
                if (txb_ProdPrdctName.TextLength > 50)
                {
                    MessageBox.Show("商品名は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("商品名が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdPrdctName.Focus();
                return false;
            }

            // 小分類IDの適否
            if (!String.IsNullOrEmpty(txb_ProdSmallDivID.Text.Trim()))
            {
                // 小分類IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdSmallDivID.Text.Trim()))
                {
                    MessageBox.Show("小分類IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdSmallDivID.Focus();
                    return false;
                }
                // 小分類IDの文字数チェック
                if (txb_ProdSmallDivID.TextLength > 2)
                {
                    MessageBox.Show("小分類IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdSmallDivID.Focus();
                    return false;
                }
                // 小分類IDの存在チェック
                if (!productDataAccess.CheckScIdCDExistence(int.Parse(txb_ProdSmallDivID.Text.Trim())))
                {
                    MessageBox.Show("入力された小分類IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdSmallDivID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("小分類IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdSmallDivID.Focus();
                return false;
            }

            // 発売日の適否
            if (dtp_ProdDate.Value != null)
            {
                DateTime releaseDate = dtp_ProdDate.Value;

                // 発売日の未来日チェック
                if (releaseDate > DateTime.Now)
                {
                    MessageBox.Show("発売日は未来の日付を入力できません", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtp_ProdDate.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("発売日が選択されていません", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_ProdDate.Focus();
                return false;
            }

            // 価格の適否
            if (!String.IsNullOrEmpty(txb_ProdPrice.Text.Trim()))
            {
                // 価格の数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdPrice.Text.Trim()))
                {
                    MessageBox.Show("価格は全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrice.Focus();
                    return false;
                }
                // 価格の文字数チェック
                if (txb_ProdPrice.TextLength > 9)
                {
                    MessageBox.Show("価格は9桁までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrice.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("価格が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdPrice.Focus();
                return false;
            }

            // 安全在庫数の適否
            if (!String.IsNullOrEmpty(txb_ProdMinNum.Text.Trim()))
            {
                // 安全在庫数の数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdMinNum.Text.Trim()))
                {
                    MessageBox.Show("安全在庫数は全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMinNum.Focus();
                    return false;
                }
                // 安全在庫数の文字数チェック
                if (txb_ProdMinNum.TextLength > 4)
                {
                    MessageBox.Show("安全在庫数は4桁までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMinNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("安全在庫数が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdMinNum.Focus();
                return false;
            }

            // 色の適否
            if (!String.IsNullOrEmpty(txb_ProdColor.Text.Trim()))
            {
                // 色の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_ProdColor.Text.Trim()))
                {
                    MessageBox.Show("色は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdColor.Focus();
                    return false;
                }
                // 色の文字数チェック
                if (txb_ProdColor.TextLength > 20)
                {
                    MessageBox.Show("色は20文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdColor.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("色が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdColor.Focus();
                return false;
            }

            // 型番の適否
            if (!String.IsNullOrEmpty(txb_ProdSerialNum.Text.Trim()))
            {
                // 型番の文字数チェック
                if (txb_ProdSerialNum.TextLength > 20)
                {
                    MessageBox.Show("型番は20文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdSerialNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("型番が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdSerialNum.Focus();
                return false;
            }
            return true;

        }

        ///////////////////////////////
        //          商品情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：商品登録情報........
        //機　能   ：登録データのセット
        ///////////////////////////////
        private MProduct GenerateDataAtRegistration()
        {
            int flg = 0;
            if (CheckBox_ProdHidden.Checked)
            {
                flg = 2;
            }
            return new MProduct
            {
                MaId = int.Parse(txb_ProdMakerID.Text.Trim()),
                PrName = txb_ProdPrdctName.Text.Trim(),
                Price = int.Parse(txb_ProdPrice.Text.Trim()),
                PrSafetyStock = int.Parse(txb_ProdMinNum.Text.Trim()),
                ScId = int.Parse(txb_ProdSmallDivID.Text.Trim()),
                PrModelNumber = txb_ProdSerialNum.Text.Trim(),
                PrReleaseDate = dtp_ProdDate.Value,
                PrColor = txb_ProdColor.Text.Trim(),
                PrFlag = flg
            };
        }
        ///////////////////////////////
        //         商品情報登録
        //メソッド名：RegistrationDivision()
        //引　数   ：商品情報
        //戻り値   ：なし
        //機　能   ：顧客データの登録
        ///////////////////////////////
        private void RegistrationProduct(MProduct regProduct)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 商品情報の登録
            int? prid = productDataAccess.AddProductData(regProduct);
            if (prid.HasValue)
            {
                MessageBox.Show("データを登録しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool stockflg = GenerateDataAtRegTStock(prid.Value);
                if (stockflg)
                {
                    MessageBox.Show("在庫情報を登録しました。", "在庫登録完了",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("在庫情報の登録に失敗しました。", "在庫登録失敗",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("データの登録に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txb_ProdPrdctID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private bool GenerateDataAtRegTStock(int prid)
        {
            using (var context = new SalesManagementContext())
            {
                try
                {
                    var newstock = new TStock
                    {
                        PrId = prid,
                        StFlag = 0,
                        StQuantity = 0,
                    };
                    context.TStocks.Add(newstock);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("在庫テーブルにデータを追加できませんでした", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        }
        private void btn_ProdHidden_Click(object sender, EventArgs e)
        {
            // 4.3 商品情報更新
            if (!GetValidDataAtHidden())
            {
                return;
            }
            UpdateHidden();
            ClearInput();
            GetDataGridView();
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
            //商品IDの適否
            if (!String.IsNullOrEmpty(txb_ProdPrdctID.Text.Trim()))
            {
                //商品IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdPrdctID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
                //商品IDの文字数チェック
                if (txb_ProdPrdctID.Text.Length > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
                // 商品IDの存在チェック
                if (!productDataAccess.CheckPrIdCDExistence(int.Parse(txb_ProdPrdctID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("商品IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdPrdctID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_ProdHidden.Checked)
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
        //　 商品非表示情報更新
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
            if (CheckBox_ProdHidden.Checked)
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
                    var product = context.MProducts.SingleOrDefault(x => x.PrId == int.Parse(txb_ProdPrdctID.Text));
                    if (product != null)
                    {
                        product.PrFlag = flg;
                        product.PrHidden = HiddenReason;
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
        private void btn_ProdShow_Click(object sender, EventArgs e)
        {
            //3.3 商品一覧
            Product = productDataAccess.GetProductAllData();
            SetDataGridView();
        }

        private void btn_ProdSearch_Click(object sender, EventArgs e)
        {
            // 3.4 商品検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                ProdSearch();
            }
        }

        ///////////////////////////////
        //         商品情報検索
        //メソッド名：ProdSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品データの検索
        ///////////////////////////////
        private void ProdSearch()
        {
            string prdctid = txb_ProdPrdctID.Text.Trim();
            string makerid = txb_ProdMakerID.Text.Trim();
            string prdctname = txb_ProdPrdctName.Text.Trim();
            string smalldivid = txb_ProdSmallDivID.Text.Trim();
            string minnum = txb_ProdMinNum.Text.Trim();
            string price = txb_ProdPrice.Text.Trim();
            string dtp = dtp_ProdDate.Value.ToString();
            string color = txb_ProdColor.Text.Trim();
            string serialnum = txb_ProdSerialNum.Text.Trim();

            int prdctID = -1;
            if (!string.IsNullOrEmpty(prdctid))
            {
                if (int.TryParse(prdctid, out int parsedID))
                {
                    prdctID = parsedID;
                }
                else
                {
                    MessageBox.Show("社員IDは数値で入力してください");
                    return;
                }
            }
            int makerID = -1;
            if (!string.IsNullOrEmpty(makerid))
            {
                if (int.TryParse(makerid, out int parsedID))
                {
                    makerID = parsedID;
                }
                else
                {
                    MessageBox.Show("営業所IDは数値で入力してください");
                    return;
                }
            }

            //検索条件に一致するデータ検索
            var filterProd = Product
                .Where(c =>
                    (prdctID == -1 || c.ProductID == prdctID) &&
                    (makerID == -1 || (c.MakerID == makerID)) &&
                    (string.IsNullOrEmpty(prdctname) || c.ProductName.Contains(prdctname)) &&
                    (string.IsNullOrEmpty(smalldivid) || c.ScID == int.Parse(smalldivid)) &&
                    (string.IsNullOrEmpty(color) || c.PrColor.Contains(color)) &&
                    (string.IsNullOrEmpty(serialnum) || c.PrModelNum.Contains(serialnum))).ToList();

            //画面に表示
            txb_ProdPage.Text = "1";
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            dataGrid_Prod.DataSource = filterProd;
            lbl_ProdPage.Text = "/" + ((int)Math.Ceiling((double)filterProd.Count / pageSize)) + "ページ";
            dataGrid_Prod.Refresh();
        }
        private void btn_PrdctFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_ProdSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_ProdSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_ProdBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_ProdSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            Dispose();
        }

        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_ProdPrdctID.Text = "";
            txb_ProdMakerID.Text = "";
            txb_ProdMaName.Text = "";
            txb_ProdPrdctName.Text = "";
            txb_ProdSmallDivID.Text = "";
            txb_ProdSmallDivName.Text = "";
            txb_ProdMinNum.Text = "";
            txb_ProdPrice.Text = "";
            dtp_ProdDate.Text = "";
            txb_ProdColor.Text = "";
            txb_ProdSerialNum.Text = "";
            CheckBox_ProdHidden.Checked = false;
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
            txb_ProdPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_ProdPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Prod.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Prod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Prod.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 顧客データの取得
            Product = productDataAccess.GetProductDspData();

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
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            int pageNo = int.Parse(txb_ProdPage.Text) - 1;
            dataGrid_Prod.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Prod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Prod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Prod.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Prod.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            lbl_ProdPage.Text = "/" + ((int)Math.Ceiling(Product.Count / (double)pageSize)) + "ページ";

            dataGrid_Prod.Refresh();

        }
        private void btn_PrdctBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_ProdSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }


        ///////////////////////////////
        //メソッド名：btn_ProdFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void btn_ProdFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            dataGrid_Prod.DataSource = Product.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Prod.Refresh();
            //ページ番号の設定
            txb_ProdPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：btn_ProdPrevPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void btn_ProdPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            int pageNo = int.Parse(txb_ProdPage.Text) - 2;
            dataGrid_Prod.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Prod.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_ProdPage.Text = (pageNo + 1).ToString();
            else
                txb_ProdPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：btn_ProdNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void btn_ProdNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            int pageNo = int.Parse(txb_ProdPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Product.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Prod.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Prod.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Product.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_ProdPage.Text = lastPage.ToString();
            else
                txb_ProdPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：btn_ProdLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void btn_ProdLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ProdPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Product.Count / (double)pageSize) - 1;
            dataGrid_Prod.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Prod.Refresh();
            //ページ番号の設定
            txb_ProdPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：btn_ProdChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_ProdChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_ProdPrdctID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdMakerID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdPrdctName.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdSmallDivID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdMinNum.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdPrice.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdColor.Text) &&
                   string.IsNullOrWhiteSpace(txb_ProdSerialNum.Text);
        }


        private void btn_ProdHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_ProdHidden.Checked)
            {
                int prodid = int.Parse(txb_ProdPrdctID.Text);
                HiddenReason = ShowHiddenReason(prodid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_ProdHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int prodid)
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
                var product = context.MProducts.Where(c => c.PrId == prodid).FirstOrDefault();
                if (product != null && !string.IsNullOrEmpty(product.PrHidden))
                {
                    HideReason = product.PrHidden;
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
        //機　能   ：顧客IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            // 商品IDの適否
            if (!String.IsNullOrEmpty(txb_ProdPrdctID.Text.Trim()))
            {
                // 商品IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ProdPrdctID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
                // 商品IDの文字数チェック
                if (txb_ProdPrdctID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
                // 商品IDの存在チェック
                if (!productDataAccess.CheckPrIdCDExistence(int.Parse(txb_ProdPrdctID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdPrdctID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("商品IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ProdPrdctID.Focus();
                return false;
            }
            return true;
        }
        private void btn_ProdFormShow_Click(object sender, EventArgs e)
        {
            //フォームの表示
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_ProdSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_ProdSelectForm.Items.Clear();
            this.Hide();
        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_ProdSelectForm.Items.Add("顧客管理画面");
                cmb_ProdSelectForm.Items.Add("在庫管理画面");
                cmb_ProdSelectForm.Items.Add("社員管理画面");
                cmb_ProdSelectForm.Items.Add("受注管理画面");
                cmb_ProdSelectForm.Items.Add("注文管理画面");
                cmb_ProdSelectForm.Items.Add("入庫管理画面");
                cmb_ProdSelectForm.Items.Add("出庫管理画面");
                cmb_ProdSelectForm.Items.Add("入荷管理画面");
                cmb_ProdSelectForm.Items.Add("出荷管理画面");
                cmb_ProdSelectForm.Items.Add("売上管理画面");
                cmb_ProdSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_ProdSelectForm.Items.Add("在庫管理画面");
                cmb_ProdSelectForm.Items.Add("入庫管理画面");
                cmb_ProdSelectForm.Items.Add("出庫管理画面");
                cmb_ProdSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_ProdSelectForm.Items.Add("受注管理画面");
                cmb_ProdSelectForm.Items.Add("注文管理画面");
                cmb_ProdSelectForm.Items.Add("入荷管理画面");
                cmb_ProdSelectForm.Items.Add("出荷管理画面");
                cmb_ProdSelectForm.Items.Add("売上管理画面");
            }
        }

        private void btn_ProdShowMakerID_Click(object sender, EventArgs e)
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
                txb_ProdMakerID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_ProdMaName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            dialog.Controls.Add(dataGridView);

            maker = makerDataAccess.GetMakerDspData();
            dataGridView.DataSource = maker;

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

        private void btn_ProdShowSmallDivID_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form dialog = new Form
            {
                Text = "分類データ",
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
                ReadOnly = true
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_ProdSmallDivID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_ProdSmallDivName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            dialog.Controls.Add(dataGridView);

            small = smallDataAccess.GetSmallClassificationDspData();
            dataGridView.DataSource = small;

            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            dialog.ShowDialog();
        }

        private void dataGrid_Prod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_ProdPrdctID.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[0].Value.ToString();
            txb_ProdPrdctName.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[1].Value.ToString();
            txb_ProdMakerID.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[2].Value.ToString();
            txb_ProdMaName.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[3].Value.ToString();
            txb_ProdPrice.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[4].Value.ToString();
            txb_ProdMinNum.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[5].Value.ToString();
            txb_ProdSmallDivID.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[6].Value.ToString();
            txb_ProdSmallDivName.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[7].Value.ToString();
            txb_ProdSerialNum.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[8].Value.ToString();
            txb_ProdColor.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[9].Value.ToString();
            dtp_ProdDate.Text = dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[10].Value.ToString();


            int flg = int.Parse(dataGrid_Prod.Rows[dataGrid_Prod.CurrentRow.Index].Cells[11].Value.ToString());
            if (flg == 0)
            {
                CheckBox_ProdHidden.Checked = false;
            }
            else
            {
                CheckBox_ProdHidden.Checked = true;
            }
        }

        private void btn_ReqInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void txb_ProdMakerID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ProdMakerID.Text))
            {
                if (int.TryParse(txb_ProdMakerID.Text, out int Id))
                {
                    GetMaId(int.Parse(txb_ProdMakerID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdMakerID.Text = string.Empty;
                }
            }
            else
            {
                txb_ProdMakerID.Text = string.Empty;
                txb_ProdMaName.Text = string.Empty;
            }
        }
        private void GetMaId(int maid)
        {
            using (var context = new SalesManagementContext())
            {
                var Maker = context.MMakers.FirstOrDefault(x => x.MaId == maid);
                if (Maker != null)
                {
                    txb_ProdMaName.Text = Maker.MaName;
                }
                else
                {
                    txb_ProdMaName.Text = string.Empty;
                }
            }
        }

        private void txb_ProdSmallDivID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ProdSmallDivID.Text))
            {
                if (int.TryParse(txb_ProdSmallDivID.Text, out int Id))
                {
                    GetSDId(int.Parse(txb_ProdSmallDivID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ProdSmallDivID.Text = string.Empty;
                }
            }
            else
            {
                txb_ProdSmallDivID.Text = string.Empty;
                txb_ProdSmallDivName.Text = string.Empty;
            }
        }
        private void GetSDId(int scid)
        {
            using (var context = new SalesManagementContext())
            {
                var SmallDiv = context.MSmallClassifications.FirstOrDefault(x => x.ScId == scid);
                if (SmallDiv != null)
                {
                    txb_ProdSmallDivName.Text = SmallDiv.ScName;
                }
                else
                {
                    txb_ProdSmallDivName.Text = string.Empty;
                }
            }
        }
    }
}
