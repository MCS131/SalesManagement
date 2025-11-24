
using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Forms.DbAccess;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;
using static Azure.Core.HttpHeader;

namespace SalesManagement_SysDev
{
    public partial class F_Storing : Form
    {
        //データアクセスインスタンス化
        WarehousingDataAccess warehousingDataAccess = new WarehousingDataAccess();
        WarehousingDetailDataAccess strDetailDataAccess = new WarehousingDetailDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //表示用データ
        private static List<TWarehousingDsp> Warehousing;
        private static List<TWarehousingDetailDsp> StrDetail;

        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;


        public F_Storing()
        {
            InitializeComponent();
        }
        private void F_Storing_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_StrLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Strkengenmei.Text = "権限名：" + kengenmei;
            lbl_StrDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);
            //ボタンEnable設定
            SetEnable(false);
            // データグリッドビューの表示
            SetFormDataGridView();
        }
        private void btn_StrShowList_Click(object sender, EventArgs e)
        {
            //11.1 入庫一覧
            Warehousing = warehousingDataAccess.GetWarehousingAllData();
            SetDataGridView();
        }
        private void btn_StrSearch_Click(object sender, EventArgs e)
        {
            // 11.2 入庫検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                StrSearch();
            }
        }
        ///////////////////////////////
        //         入庫情報検索
        //メソッド名：StrSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入庫データの検索
        ///////////////////////////////
        private void StrSearch()
        {
            string strid = txb_StrStoringID.Text.Trim();
            string emid = txb_StrEmpID.Text.Trim();

            //入庫IDの適否
            int strID = -1;
            if (!string.IsNullOrEmpty(strid))
            {
                if (int.TryParse(strid, out int parsedID))
                {
                    strID = parsedID;
                }
                else
                {
                    MessageBox.Show("入庫IDは数値で入力してください");
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
            var filterStoring = Warehousing
                .Where(c =>
                (strID == -1 || c.WaId == strID) &&
                (empID == -1 || c.EmId == empID)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterStoring.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_StrPage.Text = "1";
                int pageSize = int.Parse(txb_StrPageSize.Text);
                dataGrid_Str.DataSource = filterStoring;
                lbl_StrPage.Text = "/" + ((int)Math.Ceiling(filterStoring.Count / (double)pageSize)) + "ページ";
                dataGrid_Str.Refresh();

            }
        }
        private void btn_StrAppdate_Click(object sender, EventArgs e)
        {
            // 11.3 入庫非表示情報更新
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
            //入庫IDの適否
            if (!String.IsNullOrEmpty(txb_StrStoringID.Text.Trim()))
            {
                //入庫IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_StrStoringID.Text.Trim()))
                {
                    MessageBox.Show("入庫IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
                //入庫IDの文字数チェック
                if (txb_StrStoringID.Text.Length > 6)
                {
                    MessageBox.Show("入庫IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
                // 入庫IDの存在チェック
                if (!warehousingDataAccess.CheckWaIdCDExistence(int.Parse(txb_StrStoringID.Text.Trim())))
                {
                    MessageBox.Show("入力された入庫IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入庫IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StrStoringID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_StrHidden.Checked)
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
        //　 入庫非表示情報更新
        //メソッド名：UpdateHidden()
        //引　数   ：入庫非表示情報
        //戻り値   ：
        //機　能   ：入庫情報の更新
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
            if (CheckBox_StrHidden.Checked)
            {
                flg = 2;
            }
            if (flg == 0)
            {
                HiddenReason = "";
            }
            //非表示情報の更新
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var str = context.TWarehousings.SingleOrDefault(x => x.WaId == int.Parse(txb_StrStoringID.Text));
                    if (str != null)
                    {
                        str.WaFlag = flg;
                        str.WaHidden = HiddenReason;
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
        private void btn_StrConfirm_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregStrFix())
            {
                return;
            }
            DialogResult result = MessageBox.Show("入庫確定しますか？", "確定確認"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                GenerateDataAtRegTStock(int.Parse(txb_StrStoringID.Text.Trim()));
                GenerateDataAtRegUpdata(loginName);
            }
            else
            {
                return;
            }
        }
        private bool GetValidDataAtregStrFix()
        {
            if (!String.IsNullOrEmpty(txb_StrStoringID.Text.Trim()))
            {
                if (!warehousingDataAccess.CheckWaIdCDExistence(int.Parse(txb_StrStoringID.Text.Trim())))
                {
                    MessageBox.Show("入力された入庫IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入庫IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StrStoringID.Focus();
                return false;
            }

            SalesManagementContext context = new SalesManagementContext();
            var str = context.TWarehousings.SingleOrDefault(x => x.WaId == int.Parse(txb_StrStoringID.Text.Trim()));
            int? flg = str.WaShelfFlag;
            int hidden = str.WaFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された入庫IDはすでに入荷確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された入荷IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        private void GenerateDataAtRegTStock(int strId)
        {
            using (var context = new SalesManagementContext())
            {
                //入庫詳細情報を取得
                var strdetails = context.TWarehousingDetails.Where(x => x.WaId == strId).ToList();


                //入庫情報の各商品の在庫を減らす
                foreach (var strdetail in strdetails)
                {
                    var stock = context.TStocks.FirstOrDefault(x => x.PrId == strdetail.PrId);
                    if (stock != null)
                    {
                        stock.StQuantity += strdetail.WaQuantity;
                    }
                    else
                    {
                        MessageBox.Show("商品が在庫に存在しません", "エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                context.SaveChanges();
            }
        }
        private void GenerateDataAtRegUpdata(string user)
        {
            using (var context = new SalesManagementContext())
            {
                var warehousing = context.TWarehousings.SingleOrDefault(x => x.WaId == int.Parse(txb_StrStoringID.Text));
                var emp = context.MEmployees.SingleOrDefault(x => x.EmName == user);
                warehousing.EmId = emp.EmId;
                warehousing.WaDate = DateTime.Now;
                warehousing.WaShelfFlag = 1;
                context.SaveChanges();
                context.Dispose();

                MessageBox.Show("入庫確定しました", "確定完了"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btn_StrAppdate.Enabled = flg;
                btn_StrConfirm.Enabled = flg;
            }
        }
        private void btn_StoringFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_StrSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_StrSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_StoringBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_StrSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
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
            txb_StrPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_StrPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Str.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Str.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Str.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            // 入庫データの取得
            Warehousing = warehousingDataAccess.GetWarehousingData();

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
            int pageSize = int.Parse(txb_StrPageSize.Text);
            int pageNo = int.Parse(txb_StrPage.Text) - 1;
            dataGrid_Str.DataSource = Warehousing.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Str.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Str.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Str.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Str.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            lbl_StrPage.Text = "/" + ((int)Math.Ceiling(Warehousing.Count / (double)pageSize)) + "ページ";

            dataGrid_Str.Refresh();

        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_StrSelectForm.Items.Add("顧客管理画面");
                cmb_StrSelectForm.Items.Add("商品管理画面");
                cmb_StrSelectForm.Items.Add("在庫管理画面");
                cmb_StrSelectForm.Items.Add("社員管理画面");
                cmb_StrSelectForm.Items.Add("受注管理画面");
                cmb_StrSelectForm.Items.Add("注文管理画面");
                cmb_StrSelectForm.Items.Add("出庫管理画面");
                cmb_StrSelectForm.Items.Add("入荷管理画面");
                cmb_StrSelectForm.Items.Add("出荷管理画面");
                cmb_StrSelectForm.Items.Add("売上管理画面");
                cmb_StrSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_StrSelectForm.Items.Add("商品管理画面");
                cmb_StrSelectForm.Items.Add("在庫管理画面");
                cmb_StrSelectForm.Items.Add("出庫管理画面");
                cmb_StrSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_StrSelectForm.Items.Add("受注管理画面");
                cmb_StrSelectForm.Items.Add("注文管理画面");
                cmb_StrSelectForm.Items.Add("入荷管理画面");
                cmb_StrSelectForm.Items.Add("出荷管理画面");
                cmb_StrSelectForm.Items.Add("売上管理画面");
            }
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_StrChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_StrFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StrPageSize.Text);
            //dataGrid_Cstmr.DataSource = Client.Take(pageSize).ToList();

            //// DataGridViewを更新
            //dataGrid_Cstmr.Refresh();
            ////ページ番号の設定
            //txb_CstmrPage.Text = "1";
        }

        private void btn_StrPrevPage_Click(object sender, EventArgs e)
        {
            //int pageSize = int.Parse(txb_CstmrPageSize.Text);
            //int pageNo = int.Parse(txb_CstmrPage.Text) - 2;
            //dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            //// DataGridViewを更新
            //dataGrid_Cstmr.Refresh();
            ////ページ番号の設定
            //if (pageNo + 1 > 1)
            //    txb_CstmrPage.Text = (pageNo + 1).ToString();
            //else
            //    txb_CstmrPage.Text = "1";
        }

        private void btn_StrNextPage_Click(object sender, EventArgs e)
        {
            //int pageSize = int.Parse(txb_CstmrPageSize.Text);
            //int pageNo = int.Parse(txb_CstmrPage.Text);
            ////最終ページの計算
            //int lastNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            ////最終ページでなければ
            //if (pageNo <= lastNo)
            //    dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            //// DataGridViewを更新
            //dataGrid_Cstmr.Refresh();
            ////ページ番号の設定
            //int lastPage = (int)Math.Ceiling(Client.Count / (double)pageSize);
            //if (pageNo >= lastPage)
            //    txb_CstmrPage.Text = lastPage.ToString();
            //else
            //    txb_CstmrPage.Text = (pageNo + 1).ToString();
        }

        private void btn_StrLastPage_Click(object sender, EventArgs e)
        {
            //int pageSize = int.Parse(txb_CstmrPageSize.Text);
            ////最終ページの計算
            //int pageNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            //dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            //// DataGridViewを更新
            //dataGrid_Cstmr.Refresh();
            ////ページ番号の設定
            //txb_CstmrPage.Text = (pageNo + 1).ToString();
        }

        private void txb_StrStoringID_TextChanged(object sender, EventArgs e)
        {

        }

        ///////////////////////////////
        //メソッド名：CheckAllTextBoxesFiled()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：テクストボックス入力チェック
        ///////////////////////////////
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_StrStoringID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StrHOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StrEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StrDetailID.Text);
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_StrStoringID.Text = "";
            txb_StrHOrderID.Text = "";
            dtp_StrDate.Text = "";
            txb_StrEmpID.Text = "";
            txb_StrEmpName.Text = "";
            txb_StrDetailID.Text = "";
            txb_StrProductID.Text = "";
            txb_StrProductName.Text = "";
            txb_StrPrice.Text = "";
            txb_StrProductcnt.Text = "";
            txb_StrTotalPrice.Text = "";
            CheckBox_StrHidden.Checked = false;
            GetDataGridView();
        }

        private void btn_StrInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btn_StrHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_StrHidden.Checked)
            {
                int strid = int.Parse(txb_StrStoringID.Text);
                HiddenReason = ShowHiddenReason(strid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_StrHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int strid)
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
                var Storing = context.TWarehousings.Where(c => c.WaId == strid).FirstOrDefault();
                if (Storing != null && !string.IsNullOrEmpty(Storing.WaHidden))
                {
                    HideReason = Storing.WaHidden;
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
        //機　能   ：入庫IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_StrStoringID.Text.Trim()))
            {
                // 入庫IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_StrStoringID.Text.Trim()))
                {
                    MessageBox.Show("入庫IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
                // 入庫IDの文字数チェック
                if (txb_StrStoringID.TextLength > 6)
                {
                    MessageBox.Show("入庫IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
                if (!warehousingDataAccess.CheckWaIdCDExistence(int.Parse(txb_StrStoringID.Text.Trim())))
                {
                    MessageBox.Show("入力された入庫IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StrStoringID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入庫IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StrStoringID.Focus();
                return false;
            }
            return true;
        }

        private void btn_StrShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "入庫詳細データ",
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
                txb_StrDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_StrStoringID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_StrProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_StrProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_StrProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_StrStoringID.Text != "")
            {
                int strid = int.Parse(txb_StrStoringID.Text);
                StrDetail = strDetailDataAccess.GetWarehousingDetailSelectData(strid);
            }
            else
            {
                StrDetail = strDetailDataAccess.GetWarehousingDetailDspData();
            }
            dataGridView.DataSource = StrDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void txb_StrEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StrEmpID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StrEmpID.Text.Trim()))
                {
                    txb_StrEmpName.Text = string.Empty;
                }
                else
                {
                    GetEmId(int.Parse(txb_StrEmpID.Text));
                }
            }
            else
            {
                txb_StrEmpID.Text = string.Empty;
                txb_StrEmpName.Text = string.Empty;
            }
        }
        private void GetEmId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_StrEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_StrEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_StrDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StrDetailID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StrDetailID.Text.Trim()))
                {
                    txb_StrDetailID.Text = string.Empty;
                }
                else
                {
                    GetStrDetailID(int.Parse(txb_StrDetailID.Text));
                }
            }
            else
            {
                txb_StrDetailID.Text = string.Empty;
            }
        }
        private void GetStrDetailID(int strdetailid)
        {
            using (var context = new SalesManagementContext())
            {
                var StrDetail = context.TWarehousingDetails.FirstOrDefault(x => x.WaDetailId == strdetailid);
                if (StrDetail != null)
                {
                    txb_StrProductID.Text = StrDetail.PrId.ToString();
                    txb_StrProductcnt.Text = StrDetail.WaQuantity.ToString();
                }
                else
                {
                    txb_StrProductID.Text = string.Empty;
                }
            }
        }

        private void txb_StrProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StrProductID.Text))
            {
                GetPrice(int.Parse(txb_StrProductID.Text));
            }
            else
            {
                txb_StrProductName.Text = string.Empty;
                txb_StrPrice.Text = string.Empty;
                txb_StrTotalPrice.Text = string.Empty;
            }
        }
        private void GetPrice(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_StrProductName.Text = product.PrName;
                    txb_StrPrice.Text = product.Price.ToString();
                    TotalPrice();
                }
                else
                {
                    txb_StrPrice.Text = "0";
                    txb_StrTotalPrice.Text = string.Empty;
                }
            }
        }

        private void txb_StrProductcnt_TextChanged(object sender, EventArgs e)
        {
            TotalPrice();
        }
        private void TotalPrice()
        {
            if (decimal.TryParse(txb_StrPrice.Text, out decimal price)
                && int.TryParse(txb_StrProductcnt.Text, out int productcnt))
            {
                decimal total = price * productcnt;
                txb_StrTotalPrice.Text = total.ToString();
            }
            else
            {
                txb_StrTotalPrice.Text = string.Empty;
            }
        }

        private void dataGrid_Str_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_StrStoringID.Text = dataGrid_Str.Rows[dataGrid_Str.CurrentRow.Index].Cells[0].Value.ToString();
            txb_StrHOrderID.Text = dataGrid_Str.Rows[dataGrid_Str.CurrentRow.Index].Cells[1].Value.ToString();
            txb_StrEmpID.Text = dataGrid_Str.Rows[dataGrid_Str.CurrentRow.Index].Cells[2].Value?.ToString() ?? string.Empty;
            dtp_StrDate.Text = dataGrid_Str.Rows[dataGrid_Str.CurrentRow.Index].Cells[4].Value?.ToString() ?? string.Empty;

            int flg = int.Parse(dataGrid_Str.Rows[dataGrid_Str.CurrentRow.Index].Cells[7].Value.ToString());
            if (flg == 0)
            {
                CheckBox_StrHidden.Checked = false;
            }
            else
            {
                CheckBox_StrHidden.Checked = true;
            }
        }
    }
}
