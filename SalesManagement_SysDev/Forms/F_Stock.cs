using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
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
using static Azure.Core.HttpHeader;

namespace SalesManagement_SysDev
{
    public partial class F_Stock : Form
    {
        //データアクセスインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        StockDataAccess stockDataAccess = new StockDataAccess();

        //表示用データ
        private static List<TStockDsp> Stock;

        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Stock()
        {
            InitializeComponent();
        }
        private void F_Stock_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_StockLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Stockkengenmei.Text = "権限名：" + kengenmei;
            lbl_StockDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
            //ボタンEnable設定
            SetEnable(false);
            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);
            // データグリッドビューの表示
            SetFormDataGridView();
        }
        private void btn_StkUpdate_Click(object sender, EventArgs e)
        {
            // 5.1  在庫情報更新
            if (!GetValidDataUpdata())
            {
                return;
            }
            UpdataStock();
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
        private bool GetValidDataUpdata()
        {
            //在庫IDの適否
            if (!String.IsNullOrEmpty(txb_StkStockID.Text.Trim()))
            {
                //在庫IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_StkStockID.Text.Trim()))
                {
                    MessageBox.Show("在庫IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StkStockID.Focus();
                    return false;
                }
                //在庫IDの文字数チェック
                if (txb_StkStockID.Text.Length > 6)
                {
                    MessageBox.Show("在庫IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StkStockID.Focus();
                    return false;
                }
                // 受注IDの存在チェック
                if (!stockDataAccess.CheckStockCDExistence(int.Parse(txb_StkStockID.Text.Trim())))
                {
                    MessageBox.Show("入力された在庫IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StkStockID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("在庫IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StkStockID.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　 在庫情報更新
        //メソッド名：UpdateStock()
        //引　数   ：
        //戻り値   ：
        //機　能   ：在庫情報の更新
        ///////////////////////////////
        private void UpdataStock()
        {
            //更新確認メッセージ
            DialogResult result;
            result = MessageBox.Show("更新しますか？", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            int flg = 0;
            if (CheckBox_StkHidden.Checked)
            {
                flg = 2;
            }
            if (txb_StkStockNum.Text == "")
            {
                MessageBox.Show("在庫数を入力してください", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StkStockNum.Text.Trim()))
                {
                    MessageBox.Show("在庫数は数字で入力してください", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txb_StkStockNum.Text.Length > 4)
                {
                    MessageBox.Show("在庫数は4桁までです", "エラー",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //在庫情報の更新
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var stock = context.TStocks.SingleOrDefault(x => x.StId == int.Parse(txb_StkStockID.Text));

                    if (stock != null)
                    {
                        stock.StQuantity = int.Parse(txb_StkStockNum.Text);
                        stock.StFlag = flg;
                        context.SaveChanges();
                        context.Dispose();
                        MessageBox.Show("更新が成功しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("更新が失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_StkShow_Click(object sender, EventArgs e)
        {
            Stock = stockDataAccess.GetStockAllData();
            SetDataGridView();
        }
        private void btn_StkSearch_Click(object sender, EventArgs e)
        {
            // 5.3 在庫検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                StockSearch();
            }
        }
        ///////////////////////////////
        //         在庫情報検索
        //メソッド名：StockSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：在庫データの検索
        ///////////////////////////////
        private void StockSearch()
        {
            int flg = 0;
            if (CheckBox_StkHidden.Checked)
            {
                flg = 2;
            }

            string stockid = txb_StkStockID.Text.Trim();
            string productid = txb_StkPrdctID.Text.Trim();


            //在庫IDの適否
            int StockID = -1;
            if (!string.IsNullOrEmpty(stockid))
            {
                if (int.TryParse(stockid, out int parsedID))
                {
                    StockID = parsedID;
                }
                else
                {
                    MessageBox.Show("在庫IDは数値で入力してください");
                    return;
                }
            }

            //商品IDの適否
            int productID = -1;
            if (!string.IsNullOrEmpty(productid))
            {
                if (int.TryParse(productid, out int parsedID))
                {
                    productID = parsedID;
                }
                else
                {
                    MessageBox.Show("商品IDは数値で入力してください");
                    return;
                }
            }


            //検索条件に一致するデータ検索
            var filterStock = Stock
                .Where(c =>
                (StockID == -1 || c.StId == StockID) &&
                (productID == -1 || c.PrId == productID)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterStock.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_StkPage.Text = "1";
                int pageSize = int.Parse(txb_StkPageSize.Text);
                dataGrid_Stock.DataSource = filterStock;
                lbl_StkPage.Text = "/" + ((int)Math.Ceiling(filterStock.Count / (double)pageSize)) + "ページ";
                dataGrid_Stock.Refresh();

            }
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
                btn_StkUpdate.Enabled = flg;
            }
        }
        private void btn_StkFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_StkSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_StkSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_StkBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_StkSelectForm.Items.Clear();
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
                cmb_StkSelectForm.Items.Add("顧客管理画面");
                cmb_StkSelectForm.Items.Add("商品管理画面");
                cmb_StkSelectForm.Items.Add("社員管理画面");
                cmb_StkSelectForm.Items.Add("受注管理画面");
                cmb_StkSelectForm.Items.Add("注文管理画面");
                cmb_StkSelectForm.Items.Add("入庫管理画面");
                cmb_StkSelectForm.Items.Add("出庫管理画面");
                cmb_StkSelectForm.Items.Add("入荷管理画面");
                cmb_StkSelectForm.Items.Add("出荷管理画面");
                cmb_StkSelectForm.Items.Add("売上管理画面");
                cmb_StkSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_StkSelectForm.Items.Add("商品管理画面");
                cmb_StkSelectForm.Items.Add("入庫管理画面");
                cmb_StkSelectForm.Items.Add("出庫管理画面");
                cmb_StkSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_StkSelectForm.Items.Add("顧客管理画面");
                cmb_StkSelectForm.Items.Add("受注管理画面");
                cmb_StkSelectForm.Items.Add("注文管理画面");
                cmb_StkSelectForm.Items.Add("入荷管理画面");
                cmb_StkSelectForm.Items.Add("出荷管理画面");
                cmb_StkSelectForm.Items.Add("売上管理画面");
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
            txb_StkPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_StkPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Stock.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Stock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            // 在庫データの取得
            Stock = stockDataAccess.GetStockData();

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
            int pageSize = int.Parse(txb_StkPageSize.Text);
            int pageNo = int.Parse(txb_StkPage.Text) - 1;
            dataGrid_Stock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Stock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Stock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Stock.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stock.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stock.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stock.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stock.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //各列の文字の大きさを指定
            dataGrid_Stock.Columns[0].DefaultCellStyle.Font = new Font("Yu Gothic UI", 12);
            dataGrid_Stock.Columns[1].DefaultCellStyle.Font = new Font("Yu Gothic UI", 12);
            dataGrid_Stock.Columns[2].DefaultCellStyle.Font = new Font("Yu Gothic UI", 12);
            dataGrid_Stock.Columns[3].DefaultCellStyle.Font = new Font("Yu Gothic UI", 12);
            dataGrid_Stock.Columns[4].DefaultCellStyle.Font = new Font("Yu Gothic UI", 12);

            //dataGridViewの総ページ数
            lbl_StkPage.Text = "/" + ((int)Math.Ceiling(Stock.Count / (double)pageSize)) + "ページ";

            dataGrid_Stock.Refresh();

        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_StkChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_StkFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StkPageSize.Text);
            dataGrid_Stock.DataSource = Stock.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stock.Refresh();
            //ページ番号の設定
            txb_StkPage.Text = "1";
        }

        private void btn_StkPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StkPageSize.Text);
            int pageNo = int.Parse(txb_StkPage.Text) - 2;
            dataGrid_Stock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stock.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_StkPage.Text = (pageNo + 1).ToString();
            else
                txb_StkPage.Text = "1";
        }

        private void btn_StkNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StkPageSize.Text);
            int pageNo = int.Parse(txb_StkPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Stock.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Stock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stock.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Stock.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_StkPage.Text = lastPage.ToString();
            else
                txb_StkPage.Text = (pageNo + 1).ToString();
        }

        private void btn_StkLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StkPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Stock.Count / (double)pageSize) - 1;
            dataGrid_Stock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stock.Refresh();
            //ページ番号の設定
            txb_StkPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：CheckAllTextBoxesFiled()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：テクストボックス入力チェック
        ///////////////////////////////
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_StkStockID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StkPrdctID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StkPrdctName.Text) &&
                   string.IsNullOrWhiteSpace(txb_StkStockNum.Text);
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_StkStockID.Text = "";
            txb_StkPrdctID.Text = "";
            txb_StkPrdctName.Text = "";
            txb_StkStockNum.Text = "";
            CheckBox_StkHidden.Checked = false;
            GetDataGridView();
        }

        private void txb_StkStockID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StkStockID.Text))
            {
                if (int.TryParse(txb_StkStockID.Text, out int stockId))
                {
                    GetStockId(int.Parse(txb_StkStockID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StkStockID.Text = string.Empty;
                }
            }
            else
            {
                txb_StkStockID.Text = string.Empty;
                txb_StkPrdctID.Text = string.Empty;
                txb_StkStockNum.Text = string.Empty;
            }
        }
        private void GetStockId(int stockid)
        {
            using (var context = new SalesManagementContext())
            {
                var Stock = context.TStocks.FirstOrDefault(x => x.StId == stockid);
                if (Stock != null)
                {
                    txb_StkPrdctID.Text = Stock.PrId.ToString();
                    txb_StkStockNum.Text = Stock.StQuantity.ToString();
                }
                else
                {
                    txb_StkPrdctID.Text = string.Empty;
                }
            }
        }

        private void txb_StkPrdctID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StkPrdctID.Text))
            {
                if (int.TryParse(txb_StkPrdctID.Text, out int stockId))
                {
                    GetPrdctId(int.Parse(txb_StkPrdctID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StkPrdctID.Text = string.Empty;
                }
            }
            else
            {
                txb_StkPrdctID.Text = string.Empty;
                txb_StkPrdctName.Text = string.Empty;
            }
        }
        private void GetPrdctId(int prdctid)
        {
            using (var context = new SalesManagementContext())
            {
                var Product = context.MProducts.FirstOrDefault(x => x.PrId == prdctid);
                if (Product != null)
                {
                    txb_StkPrdctName.Text = Product.PrName;
                }
                else
                {
                    txb_StkPrdctID.Text = string.Empty;
                }
            }
        }

        private void dataGrid_Stock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_StkStockID.Text = dataGrid_Stock.Rows[dataGrid_Stock.CurrentRow.Index].Cells[0].Value.ToString();
            txb_StkPrdctID.Text = dataGrid_Stock.Rows[dataGrid_Stock.CurrentRow.Index].Cells[1].Value.ToString();
            txb_StkPrdctName.Text = dataGrid_Stock.Rows[dataGrid_Stock.CurrentRow.Index].Cells[2].Value.ToString();
            txb_StkStockNum.Text = dataGrid_Stock.Rows[dataGrid_Stock.CurrentRow.Index].Cells[3].Value.ToString();

            int flg = int.Parse(dataGrid_Stock.Rows[dataGrid_Stock.CurrentRow.Index].Cells[4].Value.ToString());
            if (flg == 0)
            {
                CheckBox_StkHidden.Checked = false;
            }
            else
            {
                CheckBox_StkHidden.Checked = true;
            }
        }

        private void btn_StkInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
