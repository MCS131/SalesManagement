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
    public partial class F_Sales : Form
    {
        //データベースアクセス用クラスのインスタンス化
        SaleDataAccess salDataAccess = new SaleDataAccess();
        SaleDetailDataAccess saledetailDataAccess = new SaleDetailDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の売上データ
        private static List<MClientDsp> Client;
        private static List<TSaleDsp> Sales;
        private static List<TSaleDetailDsp> SalesDetail;

        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Sales()
        {
            InitializeComponent();
        }
        private void F_Sales_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_SalesLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Saleskengenmei.Text = "権限名：" + kengenmei;
            lbl_SalesDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

            //ボタンEnable設定
            SetEnable(false);

            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);

            //データグリッドビューの表示
            SetFormDataGridView();
        }
        private void btn_SalFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_SalSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_SalSelectForm.Items.Clear();
            this.Hide();
        }

        private void SetEnable(bool flg)
        {
            if (kengenmei == "物流")
            {
                btn_SalSearch.Enabled = flg;
                btn_SalShow.Enabled = flg;
                CheckBox_SalHidden.Enabled = flg;
            }
        }
        private void btn_SalShow_Click(object sender, EventArgs e)
        {
            //7.1 売上一覧
            Sales = salDataAccess.GetSaleAllData();
            SetDataGridView();
        }

        private void btn_SalSearch_Click(object sender, EventArgs e)
        {
            // 7.2 売上検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                SalesSearch();
            }
        }

        ///////////////////////////////
        //         売上情報検索
        //メソッド名：ProdSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：売上データの検索
        ///////////////////////////////
        private void SalesSearch()
        {
            string salesid = txb_SalSalesID.Text.Trim();
            string cstmrid = txb_SalCstmrID.Text.Trim();
            string jorderid = txb_SalJOrderID.Text.Trim();
            string empid = txb_SalEmpID.Text.Trim();
            string salesofficeid = txb_SalSalesOfficeID.Text.Trim();

            int salID = -1;
            if (!string.IsNullOrEmpty(salesid))
            {
                if (int.TryParse(salesid, out int parsedID))
                {
                    salID = parsedID;
                }
                else
                {
                    MessageBox.Show("売上IDは数値で入力してください");
                    return;
                }
            }

            int cstmrID = -1;
            if (!string.IsNullOrEmpty(cstmrid))
            {
                if (int.TryParse(cstmrid, out int parsedID))
                {
                    cstmrID = parsedID;
                }
                else
                {
                    MessageBox.Show("顧客IDは数値で入力してください");
                    return;
                }
            }

            int empID = -1;
            if (!string.IsNullOrEmpty(empid))
            {
                if (int.TryParse(empid, out int parsedID))
                {
                    empID = parsedID;
                }
                else
                {
                    MessageBox.Show("社員IDは数値で入力してください");
                    return;
                }
            }

            int jorderID = -1;
            if (!string.IsNullOrEmpty(jorderid))
            {
                if (int.TryParse(jorderid, out int parsedID))
                {
                    jorderID = parsedID;
                }
                else
                {
                    MessageBox.Show("受注IDは数値で入力してください");
                    return;
                }
            }

            int salesofficeID = -1;
            if (!string.IsNullOrEmpty(salesofficeid))
            {
                if (int.TryParse(salesofficeid, out int parsedID))
                {
                    salesofficeID = parsedID;
                }
                else
                {
                    MessageBox.Show("営業所IDは数値で入力してください");
                    return;
                }
            }

            //検索条件に一致するデータ検索
            var filterSal = Sales
                .Where(c =>
                    (salID == -1 || c.SalesID == salID) &&
                    (cstmrID == -1 || (c.ClientID == cstmrID)) &&
                    (empID == -1 || (c.EmpID == empID)) &&
                    (jorderID == -1 || (c.JOrderID == jorderID)) &&
                    (salesofficeID == -1 || (c.SalesOfficeID == salesofficeID))).ToList();

            //画面に表示
            txb_SalPage.Text = "1";
            int pageSize = int.Parse(txb_SalPageSize.Text);
            dataGrid_Sales.DataSource = filterSal;
            lbl_SalPage.Text = "/" + ((int)Math.Ceiling((double)filterSal.Count / pageSize)) + "ページ";
            dataGrid_Sales.Refresh();
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
            txb_SalPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_SalPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Sales.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Sales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Sales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 売上データの取得
            Sales = salDataAccess.GetSaleDspData();

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
            int pageSize = int.Parse(txb_SalPageSize.Text);
            int pageNo = int.Parse(txb_SalPage.Text) - 1;
            dataGrid_Sales.DataSource = Sales.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Sales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Sales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Sales.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Sales.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGrid_Sales.Columns[8].DefaultCellStyle.Format = "yyyy/MM/dd";
            //dataGridViewの総ページ数
            lbl_SalPage.Text = "/" + ((int)Math.Ceiling(Sales.Count / (double)pageSize)) + "ページ";

            dataGrid_Sales.Refresh();
        }

        private void btn_SalBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_SalSelectForm.Items.Clear();
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
                cmb_SalSelectForm.Items.Add("顧客管理画面");
                cmb_SalSelectForm.Items.Add("商品管理画面");
                cmb_SalSelectForm.Items.Add("在庫管理画面");
                cmb_SalSelectForm.Items.Add("社員管理画面");
                cmb_SalSelectForm.Items.Add("受注管理画面");
                cmb_SalSelectForm.Items.Add("注文管理画面");
                cmb_SalSelectForm.Items.Add("入庫管理画面");
                cmb_SalSelectForm.Items.Add("出庫管理画面");
                cmb_SalSelectForm.Items.Add("入荷管理画面");
                cmb_SalSelectForm.Items.Add("出荷管理画面");
                cmb_SalSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_SalSelectForm.Items.Add("商品管理画面");
                cmb_SalSelectForm.Items.Add("在庫管理画面");
                cmb_SalSelectForm.Items.Add("入庫管理画面");
                cmb_SalSelectForm.Items.Add("出庫管理画面");
                cmb_SalSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_SalSelectForm.Items.Add("売上管理画面");
                cmb_SalSelectForm.Items.Add("受注管理画面");
                cmb_SalSelectForm.Items.Add("注文管理画面");
                cmb_SalSelectForm.Items.Add("入荷管理画面");
                cmb_SalSelectForm.Items.Add("出荷管理画面");
            }
        }

        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_SalCstmrID.Text) &&
                   string.IsNullOrWhiteSpace(txb_SalEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_SalJOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_SalSalesID.Text) &&
                   string.IsNullOrWhiteSpace(txb_SalSalesOfficeID.Text);
        }

        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_SalChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_SalFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_SalPageSize.Text);
            dataGrid_Sales.DataSource = Client.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Sales.Refresh();
            //ページ番号の設定
            txb_SalPage.Text = "1";
        }

        private void btn_SalPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_SalPageSize.Text);
            int pageNo = int.Parse(txb_SalPage.Text) - 2;
            dataGrid_Sales.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Sales.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_SalPage.Text = (pageNo + 1).ToString();
            else
                txb_SalPage.Text = "1";
        }

        private void btn_SalNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_SalPageSize.Text);
            int pageNo = int.Parse(txb_SalPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Sales.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Sales.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Client.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_SalPage.Text = lastPage.ToString();
            else
                txb_SalPage.Text = (pageNo + 1).ToString();
        }

        private void btn_SalLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_SalPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            dataGrid_Sales.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Sales.Refresh();
            //ページ番号の設定
            txb_SalPage.Text = (pageNo + 1).ToString();
        }
        private void dataGrid_Sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ            
            txb_SalCstmrID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[0].Value.ToString();
            txb_SalEmpID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[1].Value.ToString();
            txb_SalSalesID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[2].Value.ToString();
            txb_SalJOrderID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[3].Value.ToString();
            txb_SalSalesOfficeID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[4].Value.ToString();

            int flg = int.Parse(dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[8].Value.ToString());
            if (flg == 0)
            {
                CheckBox_SalHidden.Checked = false;
            }
            else
            {
                CheckBox_SalHidden.Checked = true;
            }
        }

        private void btn_SalHidden_Click(object sender, EventArgs e)
        {
            // 7.3 売上非表示情報更新
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
            //売上IDの適否
            if (!String.IsNullOrEmpty(txb_SalSalesID.Text.Trim()))
            {
                //売上IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_SalSalesID.Text.Trim()))
                {
                    MessageBox.Show("売上IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
                //売上IDの文字数チェック
                if (txb_SalSalesID.Text.Length > 6)
                {
                    MessageBox.Show("売上IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
                //売上IDの存在チェック
                if (!salDataAccess.CheckSaIdCDExistence(int.Parse(txb_SalSalesID.Text.Trim())))
                {
                    MessageBox.Show("入力された売上IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("売上IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_SalSalesID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_SalHidden.Checked)
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
        //　 売上非表示情報更新
        //メソッド名：UpdateHidden()
        //引　数   ：売上非表示情報
        //戻り値   ：
        //機　能   ：売上情報の更新
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
            if (CheckBox_SalHidden.Checked)
            {
                flg = 2;
            }
            if (flg == 0)
            {
                HiddenReason = "";
            }
            //売上情報の更新
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var product = context.TSales.SingleOrDefault(x => x.SaId == int.Parse(txb_SalSalesID.Text));
                    if (product != null)
                    {
                        product.SaFlag = flg;
                        product.SaHidden = HiddenReason;
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
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_SalSalesID.Text = "";
            txb_SalCstmrID.Text = "";
            txb_SalEmpID.Text = "";
            txb_SalJOrderID.Text = "";
            txb_SalSalesOfficeID.Text = "";
            dtp_SalDate.Text = "";
            CheckBox_SalHidden.Checked = false;
        }

        private void btn_SalHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_SalHidden.Checked)
            {
                int prodid = int.Parse(txb_SalSalesID.Text);
                HiddenReason = ShowHiddenReason(prodid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_SalHidden.Focus();
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
                var sale = context.TSales.Where(c => c.SaId == prodid).FirstOrDefault();
                if (sale != null && !string.IsNullOrEmpty(sale.SaHidden))
                {
                    HideReason = sale.SaHidden;
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
        //機　能   ：売上IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            // 売上IDの適否
            if (!String.IsNullOrEmpty(txb_SalSalesID.Text.Trim()))
            {
                // 売上IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_SalSalesID.Text.Trim()))
                {
                    MessageBox.Show("売上IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
                // 売上IDの文字数チェック
                if (txb_SalSalesID.TextLength > 6)
                {
                    MessageBox.Show("売上IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
                // 商品IDの存在チェック
                if (!salDataAccess.CheckSaIdCDExistence(int.Parse(txb_SalSalesID.Text.Trim())))
                {
                    MessageBox.Show("入力された売上IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("売上IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_SalSalesID.Focus();
                return false;
            }
            return true;
        }

        private void btn_SalShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "売上詳細データ",
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
                txb_SalSalesDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_SalSalesID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_SalProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_SalProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_SalQuantity.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();
                txb_SalTotalPrice.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[5].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            if (txb_SalSalesID.Text != "")
            {
                int salid = int.Parse(txb_SalSalesID.Text);
                SalesDetail = saledetailDataAccess.GetSaleDetailSelectData(salid);
            }
            else
            {
                SalesDetail = saledetailDataAccess.GetSaleDetailDspData();
            }
            dataGridView.DataSource = SalesDetail;
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

        private void dataGrid_Sales_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txb_SalSalesID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[0].Value.ToString();
            txb_SalCstmrID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[1].Value.ToString();
            txb_SalCstmrName.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[2].Value.ToString();
            txb_SalSalesOfficeID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[3].Value.ToString();
            txb_SalSalesOfficeName.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[4].Value.ToString();
            txb_SalEmpID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[5].Value.ToString();
            txb_SalEmpName.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[6].Value.ToString();
            txb_SalJOrderID.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[7].Value.ToString();
            dtp_SalDate.Text = dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[8].Value.ToString();

            int flg = int.Parse(dataGrid_Sales.Rows[dataGrid_Sales.CurrentRow.Index].Cells[9].Value.ToString());
            if (flg == 0)
            {
                CheckBox_SalHidden.Checked = false;
            }
            else
            {
                CheckBox_SalHidden.Checked = true;
            }
        }

        private void txb_SalCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_SalCstmrID.Text))
            {
                if (int.TryParse(txb_SalCstmrID.Text, out int Id))
                {
                    GetCsId(int.Parse(txb_SalCstmrID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalCstmrID.Text = string.Empty;
                }
            }
            else
            {
                txb_SalCstmrID.Text = string.Empty;
                txb_SalCstmrName.Text = string.Empty;
            }
        }
        private void GetCsId(int csid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == csid);
                if (Cstmr != null)
                {
                    txb_SalCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_SalCstmrID.Text = string.Empty;
                }
            }
        }

        private void txb_SalSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_SalSalesOfficeID.Text))
            {
                if (int.TryParse(txb_SalSalesOfficeID.Text, out int Id))
                {
                    GetSoId(int.Parse(txb_SalSalesOfficeID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesOfficeID.Text = string.Empty;
                }
            }
            else
            {
                txb_SalSalesOfficeID.Text = string.Empty;
                txb_SalSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_SalSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_SalSalesOfficeID.Text = string.Empty;
                }
            }
        }

        private void txb_SalEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_SalEmpID.Text))
            {
                if (int.TryParse(txb_SalEmpID.Text, out int Id))
                {
                    GetEmId(int.Parse(txb_SalEmpID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalEmpID.Text = string.Empty;
                }
            }
            else
            {
                txb_SalEmpID.Text = string.Empty;
                txb_SalEmpName.Text = string.Empty;
            }
        }
        private void GetEmId(int emid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == emid);
                if (Emp != null)
                {
                    txb_SalEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_SalEmpID.Text = string.Empty;
                }
            }
        }
        private void txb_SalSalesDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_SalSalesDetailID.Text))
            {
                if (int.TryParse(txb_SalSalesDetailID.Text, out int Id))
                {
                    GetScId(int.Parse(txb_SalSalesDetailID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_SalSalesDetailID.Text = string.Empty;
                }
            }
            else
            {
                txb_SalSalesDetailID.Text = string.Empty;
            }
        }
        private void GetEcId(int scid)
        {
            using (var context = new SalesManagementContext())
            {
                var Detail = context.TSaleDetails.FirstOrDefault(x => x.SaId == scid);
                if (Detail != null)
                {
                    txb_SalProductID.Text = Detail.PrId.ToString();
                    txb_SalQuantity.Text = Detail.SaQuantity.ToString();
                    txb_SalTotalPrice.Text = Detail.SaPrTotalPrice.ToString();
                    GetPrName();
                }
                else
                {
                    txb_SalProductID.Text = string.Empty;
                    txb_SalTotalPrice.Text = string.Empty;
                }
            }
        }
        private void GetPrName()
        {
            using(var context = new SalesManagementContext())
            {
                int prid = int.Parse(txb_SalProductID.Text);
                var Product = context.MProducts.FirstOrDefault(x => x.PrId == prid);
                if (Product != null)
                {
                    txb_SalProductName.Text = Product.PrName;
                }
                else
                {
                    txb_SalProductID.Text = string.Empty;
                    txb_SalProductName.Text = string.Empty;
                }
            }
        }
    }
}
