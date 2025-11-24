using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Forms.DbAccess;
using SalesManagement_SysDev.Entity;
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
using SalesManagement_SysDev.Context;

namespace SalesManagement_SysDev
{
    public partial class F_Request : Form
    {
        //データアクセスインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        SyukkoDataAccess syukkoDataAccess = new SyukkoDataAccess();
        ChumonDetailDataAccess chumonDetailDataAccess = new ChumonDetailDataAccess();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //表示用データ
        private static List<TChumonDsp> Chumon;
        private static List<TChumonDetailDsp> ChumonDetail;
        private static List<MEmployeeDsp> Employee;

        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static string HiddenReason = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Request()
        {
            InitializeComponent();
        }
        private void F_Request_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_RequestLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Requestkengenmei.Text = "権限名：" + kengenmei;
            lbl_RequestDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

            //ボタンEnable設定
            SetEnable(false);
            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);
            // データグリッドビューの表示
            SetFormDataGridView();
        }
        private void btn_ReqShowList_Click(object sender, EventArgs e)
        {
            //9.1 注文一覧
            Chumon = chumonDataAccess.GetChumonAllData();
            SetDataGridView();
        }
        private void btn_ReqSearch_Click(object sender, EventArgs e)
        {
            // 9.2 注文検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                RequestSearch();
            }
        }
        ///////////////////////////////
        //         注文情報検索
        //メソッド名：RequestSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの検索
        ///////////////////////////////
        private void RequestSearch()
        {
            string requestid = txb_ReqRequestID.Text.Trim();
            string officeid = txb_ReqSalesOfficeID.Text.Trim();
            string emid = txb_ReqEmpID.Text.Trim();
            string cstmrid = txb_ReqCstmrID.Text.Trim();

            //注文IDの適否
            int chID = -1;
            if (!string.IsNullOrEmpty(requestid))
            {
                if (int.TryParse(requestid, out int parsedID))
                {
                    chID = parsedID;
                }
                else
                {
                    MessageBox.Show("注文IDは数値で入力してください");
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
            var filterChumon = Chumon
                .Where(c =>
                (chID == -1 || c.ChId == chID) &&
                (customerID == -1 || c.ClID == customerID) &&
                (soId == -1 || c.SoId == soId) &&
                (empID == -1 || c.EmpID == empID)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterChumon.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_ReqPage.Text = "1";
                int pageSize = int.Parse(txb_ReqPageSize.Text);
                dataGrid_Request.DataSource = filterChumon;
                lbl_ReqPage.Text = "/" + ((int)Math.Ceiling(filterChumon.Count / (double)pageSize)) + "ページ";
                dataGrid_Request.Refresh();

            }
        }
        private void btn_ReqHidden_Click(object sender, EventArgs e)
        {
            // 9.3 注文非表示情報更新
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
            //注文IDの適否
            if (!String.IsNullOrEmpty(txb_ReqRequestID.Text.Trim()))
            {
                //注文IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ReqRequestID.Text.Trim()))
                {
                    MessageBox.Show("注文IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
                //注文IDの文字数チェック
                if (txb_ReqRequestID.Text.Length > 6)
                {
                    MessageBox.Show("注文IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
                // 注文IDの存在チェック
                if (!chumonDataAccess.CheckChumonCDExistence(int.Parse(txb_ReqRequestID.Text.Trim())))
                {
                    MessageBox.Show("入力された注文IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("注文IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ReqRequestID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_ReqHidden.Checked)
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
        //　 注文非表示情報更新
        //メソッド名：UpdateHidden()
        //引　数   ：注文非表示情報
        //戻り値   ：
        //機　能   ：注文情報の更新
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
            if (CheckBox_ReqHidden.Checked)
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
                    var chumon = context.TChumons.SingleOrDefault(x => x.ChId == int.Parse(txb_ReqRequestID.Text));
                    if (chumon != null)
                    {
                        chumon.ChFlag = flg;
                        chumon.ChHidden = HiddenReason;
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
        private void btn_ReqConfirm_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregChumonFix())
            {
                return;
            }
            //出庫テーブルに登録
            var regSyukko = GenerateDataAtRegTSyukko();
            RegistrationSyukko(regSyukko);
        }
        private bool GetValidDataAtregChumonFix()
        {
            if (!String.IsNullOrEmpty(txb_ReqRequestID.Text.Trim()))
            {
                if (!chumonDataAccess.CheckChumonCDExistence(int.Parse(txb_ReqRequestID.Text.Trim())))
                {
                    MessageBox.Show("入力された注文IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("注文IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ReqRequestID.Focus();
                return false;
            }

            SalesManagementContext context = new SalesManagementContext();
            var chumon = context.TChumons.SingleOrDefault(x => x.ChId == int.Parse(txb_ReqRequestID.Text.Trim()));
            int? flg = chumon.ChStateFlag;
            int hidden = chumon.ChFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された注文IDはすでに受注確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された注文IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        ///////////////////////////////
        //          出庫情報作成
        //メソッド名：GenerateDataAtRegTSyukko()
        //引　数   ：なし
        //戻り値   ：出庫情報
        //機　能   ：出庫データのセット
        ///////////////////////////////
        private TSyukko GenerateDataAtRegTSyukko()
        {
            SalesManagementContext context = new SalesManagementContext();
            var chumon = context.TChumons.SingleOrDefault(x => x.ChId == int.Parse(txb_ReqRequestID.Text.Trim()));
            return new TSyukko
            {
                SoId = chumon.SoId,
                EmId = null,
                ClId = chumon.ClId,
                OrId = chumon.OrId,
                SyDate = null,
                SyStateFlag = 0,
                SyFlag = 0,
                SyHidden = ""
            };
        }
        ///////////////////////////////
        //         出庫情報登録
        //メソッド名：RegistrationSyukko()
        //引　数   ：出庫情報
        //戻り値   ：なし
        //機　能   ：出庫データの登録
        ///////////////////////////////
        private void RegistrationSyukko(TSyukko regSyukko)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("注文確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出庫情報の登録
            bool flg = syukkoDataAccess.AddSyukkoData(regSyukko);


            if (flg == true)
            {
                MessageBox.Show("注文情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var chumon = context.TChumons.SingleOrDefault(x => x.ChId == int.Parse(txb_ReqRequestID.Text));
                    if (chumon != null)
                    {
                        chumon.ChStateFlag = 1;
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("注文情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTSyukkoDetail();
            GenerateDataAtRegTStock(int.Parse(txb_ReqRequestID.Text.Trim()));
            GenerateDataAtRegEmpID(loginName);
            // 入力エリアのクリア
            ClearInput();


        }
        private void GenerateDataAtRegTSyukkoDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var chumonid = int.Parse(txb_ReqRequestID.Text.Trim());
                var chumonDetails = context.TChumonDetails
                    .Where(x => x.ChId == chumonid)
                    .OrderBy(x => x.ChId)
                    .ToList();
                var confirmChumonDetails = chumonDetails.Select(x => new TSyukkoDetail
                {
                    SyId = GenerateNewSyId(context), // 新しいIDを生成
                    PrId = x.PrId,
                    SyQuantity = x.ChQuantity
                }).ToList();
                context.AddRange(confirmChumonDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("出庫詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewSyId(SalesManagementContext context)
        {
            // TSyukkoDetailの現在の最大IDを取得して+1
            return (context.TSyukkoDetails.Max(x => (int?)x.SyId) ?? 0) + 1;
        }
        private void GenerateDataAtRegTStock(int chId)
        {
            using (var context = new SalesManagementContext())
            {
                //注文詳細情報を取得
                var chumondetails = context.TChumonDetails.Where(x => x.ChId == chId).ToList();


                //注文情報の各商品の在庫を減らす
                foreach (var orderdetail in chumondetails)
                {
                    var stock = context.TStocks.FirstOrDefault(x => x.PrId == orderdetail.PrId);
                    if (stock != null)
                    {
                        stock.StQuantity -= orderdetail.ChQuantity;
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
        private void GenerateDataAtRegEmpID(string user)
        {
            using (var context = new SalesManagementContext())
            {
                var chumon = context.TChumons.SingleOrDefault(x => x.ChId == int.Parse(txb_ReqRequestID.Text));
                var emp = context.MEmployees.SingleOrDefault(x => x.EmName == user);
                chumon.EmId = emp.EmId;
                context.SaveChanges();
                context.Dispose();
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
            if (kengenmei == "物流")
            {
                btn_ReqHidden.Enabled = flg;
                btn_ReqConfirm.Enabled = flg;
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
            txb_ReqPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_ReqPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Request.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Request.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Request.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            // 注文データの取得
            Chumon = chumonDataAccess.GetChumonData();

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
            int pageSize = int.Parse(txb_ReqPageSize.Text);
            int pageNo = int.Parse(txb_ReqPage.Text) - 1;
            dataGrid_Request.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Request.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Request.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Request.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Request.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGrid_Request.Columns[8].DefaultCellStyle.Format = "yyyy/MM/dd";
            //dataGridViewの総ページ数
            lbl_ReqPage.Text = "/" + ((int)Math.Ceiling(Chumon.Count / (double)pageSize)) + "ページ";

            dataGrid_Request.Refresh();

        }
        private void btn_ReqFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_ReqSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_ReqSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_ReqBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_ReqSelectForm.Items.Clear();
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
                cmb_ReqSelectForm.Items.Add("顧客管理画面");
                cmb_ReqSelectForm.Items.Add("商品管理画面");
                cmb_ReqSelectForm.Items.Add("在庫管理画面");
                cmb_ReqSelectForm.Items.Add("社員管理画面");
                cmb_ReqSelectForm.Items.Add("受注管理画面");
                cmb_ReqSelectForm.Items.Add("入庫管理画面");
                cmb_ReqSelectForm.Items.Add("出庫管理画面");
                cmb_ReqSelectForm.Items.Add("入荷管理画面");
                cmb_ReqSelectForm.Items.Add("出荷管理画面");
                cmb_ReqSelectForm.Items.Add("売上管理画面");
                cmb_ReqSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_ReqSelectForm.Items.Add("商品管理画面");
                cmb_ReqSelectForm.Items.Add("在庫管理画面");
                cmb_ReqSelectForm.Items.Add("入庫管理画面");
                cmb_ReqSelectForm.Items.Add("出庫管理画面");
                cmb_ReqSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_ReqSelectForm.Items.Add("顧客管理画面");
                cmb_ReqSelectForm.Items.Add("受注管理画面");
                cmb_ReqSelectForm.Items.Add("入荷管理画面");
                cmb_ReqSelectForm.Items.Add("出荷管理画面");
                cmb_ReqSelectForm.Items.Add("売上管理画面");
            }
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_ReqChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_ReqFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ReqPageSize.Text);
            dataGrid_Request.DataSource = Chumon.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Request.Refresh();
            //ページ番号の設定
            txb_ReqPage.Text = "1";
        }

        private void btn_ReqPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ReqPageSize.Text);
            int pageNo = int.Parse(txb_ReqPage.Text) - 2;
            dataGrid_Request.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Request.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_ReqPage.Text = (pageNo + 1).ToString();
            else
                txb_ReqPage.Text = "1";
        }

        private void btn_ReqNextPage_Click(object sender, EventArgs e)
        {

            int pageSize = int.Parse(txb_ReqPageSize.Text);
            int pageNo = int.Parse(txb_ReqPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Request.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Request.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Chumon.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_ReqPage.Text = lastPage.ToString();
            else
                txb_ReqPage.Text = (pageNo + 1).ToString();
        }

        private void btn_ReqLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ReqPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            dataGrid_Request.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Request.Refresh();
            //ページ番号の設定
            txb_ReqPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：CheckAllTextBoxesFiled()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：テクストボックス入力チェック
        ///////////////////////////////
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_ReqRequestID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqJOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqSalesOfficeID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqCstmrID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqProductID.Text) &&
                   string.IsNullOrWhiteSpace(txb_ReqDetailID.Text);
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_ReqRequestID.Text = "";
            txb_ReqJOrderID.Text = "";
            dtp_ReqDate.Text = "";
            txb_ReqSalesOfficeID.Text = "";
            txb_ReqSalesOfficeName.Text = "";
            txb_ReqEmpID.Text = "";
            txb_ReqEmpName.Text = "";
            txb_ReqCstmrID.Text = "";
            txb_ReqCstmrName.Text = "";
            txb_ReqDetailID.Text = "";
            txb_ReqProductID.Text = "";
            txb_ReqProductName.Text = "";
            txb_ReqPrice.Text = "";
            txb_ReqProductcnt.Text = "";
            txb_ReqTotalPrice.Text = "";
            CheckBox_ReqHidden.Checked = false;
            GetDataGridView();
        }

        private void btn_ReqHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_ReqHidden.Checked)
            {
                int orderid = int.Parse(txb_ReqRequestID.Text);
                HiddenReason = ShowHiddenReason(orderid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_ReqHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int chumonid)
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
                var Chumon = context.TChumons.Where(c => c.ChId == chumonid).FirstOrDefault();
                if (Chumon != null && !string.IsNullOrEmpty(Chumon.ChHidden))
                {
                    HideReason = Chumon.ChHidden;
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
        //機　能   ：注文IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_ReqRequestID.Text.Trim()))
            {
                // 注文IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ReqRequestID.Text.Trim()))
                {
                    MessageBox.Show("注文IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
                // 注文IDの文字数チェック
                if (txb_ReqRequestID.TextLength > 2)
                {
                    MessageBox.Show("注文IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
                if (!chumonDataAccess.CheckChumonCDExistence(int.Parse(txb_ReqRequestID.Text.Trim())))
                {
                    MessageBox.Show("入力された注文IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ReqRequestID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("注文IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ReqRequestID.Focus();
                return false;
            }
            return true;
        }
        private void btn_ReqInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btn_ReqShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "注文詳細データ",
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
                txb_ReqDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_ReqRequestID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_ReqProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_ReqProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_ReqProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_ReqRequestID.Text != "")
            {
                int chumonid = int.Parse(txb_ReqRequestID.Text);
                ChumonDetail = chumonDetailDataAccess.GetChumonDetailSelectData(chumonid);
            }
            else
            {
                ChumonDetail = chumonDetailDataAccess.GetChumonDetailDspData();
            }
            dataGridView.DataSource = ChumonDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void txb_ReqDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ReqDetailID.Text))
            {
                if(!dataInputFormCheck.CheckNumeric(txb_ReqDetailID.Text.Trim()))
                {
                    txb_ReqDetailID.Text = string.Empty;
                }
                else
                {
                    GetReqDetailID(int.Parse(txb_ReqDetailID.Text));
                }
            }
            else
            {
                txb_ReqDetailID.Text = string.Empty;
            }
        }
        private void GetReqDetailID(int reqdetailid)
        {
            using (var context = new SalesManagementContext())
            {
                var ReqDetail = context.TChumonDetails.FirstOrDefault(x => x.ChDetailId == reqdetailid);
                if (ReqDetail != null)
                {
                    txb_ReqProductID.Text = ReqDetail.PrId.ToString();
                    txb_ReqProductcnt.Text = ReqDetail.ChQuantity.ToString();
                }
                else
                {
                    txb_ReqProductID.Text = string.Empty;
                }
            }
        }

        private void txb_ReqProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ReqProductID.Text))
            {
                GetPrice(int.Parse(txb_ReqProductID.Text));
            }
            else
            {
                txb_ReqProductName.Text = string.Empty;
                txb_ReqPrice.Text = string.Empty;
                txb_ReqTotalPrice.Text = string.Empty;
            }
        }
        private void GetPrice(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_ReqProductName.Text = product.PrName;
                    txb_ReqPrice.Text = product.Price.ToString();
                    TotalPrice();
                }
                else
                {
                    txb_ReqPrice.Text = "0";
                    txb_ReqTotalPrice.Text = string.Empty;
                }
            }
        }
        private void txb_ReqProductcnt_TextChanged(object sender, EventArgs e)
        {
            TotalPrice();
        }
        private void TotalPrice()
        {
            if (decimal.TryParse(txb_ReqPrice.Text, out decimal price)
                && int.TryParse(txb_ReqProductcnt.Text, out int productcnt))
            {
                decimal total = price * productcnt;
                txb_ReqTotalPrice.Text = total.ToString();
            }
            else
            {
                txb_ReqTotalPrice.Text = string.Empty;
            }
        }

        private void txb_ReqEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ReqEmpID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ReqEmpID.Text.Trim()))
                {
                    txb_ReqEmpName.Text = string.Empty;
                }
                else
                {
                    GetEmId(int.Parse(txb_ReqEmpID.Text));
                }
            }
            else
            {
                txb_ReqEmpID.Text = string.Empty;
                txb_ReqEmpName.Text = string.Empty;
            }
        }
        private void GetEmId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_ReqEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_ReqEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_ReqSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ReqSalesOfficeID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ReqSalesOfficeID.Text.Trim()))
                {
                    txb_ReqSalesOfficeName.Text = string.Empty;
                }
                else  
                {
                    GetSoId(int.Parse(txb_ReqSalesOfficeID.Text));
                }
            }
            else
            {
                txb_ReqSalesOfficeID.Text = string.Empty;
                txb_ReqSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_ReqSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_ReqSalesOfficeName.Text = string.Empty;
                }
            }
        }

        private void txb_ReqCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ReqCstmrID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ReqCstmrID.Text.Trim()))
                {
                    txb_ReqCstmrID.Text = string.Empty;
                }
                else
                {
                    GetCstmrId(int.Parse(txb_ReqCstmrID.Text));
                }
            }
            else
            {
                txb_ReqCstmrID.Text = string.Empty;
                txb_ReqCstmrName.Text = string.Empty;
            }
        }
        private void GetCstmrId(int cstmrid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == cstmrid);
                if (Cstmr != null)
                {
                    txb_ReqCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_ReqCstmrName.Text = string.Empty;
                }
            }
        }

        private void dataGrid_Request_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_ReqRequestID.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[0].Value.ToString();
            txb_ReqJOrderID.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[1].Value.ToString();
            txb_ReqSalesOfficeID.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[2].Value.ToString();
            txb_ReqEmpID.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[4].Value?.ToString() ?? string.Empty;
            txb_ReqCstmrID.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[6].Value.ToString();
            dtp_ReqDate.Text = dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[8].Value?.ToString() ?? string.Empty;

            int flg = int.Parse(dataGrid_Request.Rows[dataGrid_Request.CurrentRow.Index].Cells[10].Value.ToString());
            if (flg == 0)
            {
                CheckBox_ReqHidden.Checked = false;
            }
            else
            {
                CheckBox_ReqHidden.Checked = true;
            }
        }
    }
}
