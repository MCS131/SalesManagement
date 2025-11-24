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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;
using static Azure.Core.HttpHeader;

namespace SalesManagement_SysDev
{
    public partial class F_Storegoods : Form
    {
        ArrivalDataAccess arrivalDataAccess = new ArrivalDataAccess();
        ArrivalDetailDataAccess arrivaldetailDataAccess = new ArrivalDetailDataAccess();
        ShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用のデータ
        private static List<TArrivalDsp> Arrival;
        private static List<TArrivalDetailDsp> ArrivalDetail;

        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        internal static string HiddenReason = "";
        public F_Storegoods()
        {
            InitializeComponent();
        }
        private void F_Storegoods_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_StgLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Stgkengenmei.Text = "権限名：" + kengenmei;
            lbl_StgDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
            //ボタンEnable設定
            SetEnable(false);
            //コンボボックスにアイテム追加
            cmb_boxAddItem(kengenmei);
            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void btn_StgShowList_Click(object sender, EventArgs e)
        {
            //13.1 入荷一覧
            Arrival = arrivalDataAccess.GetArrivalAllData();
            SetDataGridView();
        }
        private void btn_SgFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_SgSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_SgSelectForm.Items.Clear();
            this.Hide();
        }
        private void btn_StgSearch_Click(object sender, EventArgs e)
        {
            // 13.2 入荷検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                ArrivalSearch();
            }
        }
        ///////////////////////////////
        //         入荷情報検索
        //メソッド名：ArrivalSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入荷データの検索
        ///////////////////////////////
        private void ArrivalSearch()
        {
            string storegoodsid = txb_StgStoregoodsID.Text.Trim();
            string officeid = txb_StgSalesOfficeID.Text.Trim();
            string emid = txb_StgEmpID.Text.Trim();
            string cstmrid = txb_StgCstmrID.Text.Trim();
            string jorderid = txb_StgJOrderID.Text.Trim();

            //入荷IDの適否
            int stgID = -1;
            if (!string.IsNullOrEmpty(storegoodsid))
            {
                if (int.TryParse(storegoodsid, out int parsedID))
                {
                    stgID = parsedID;
                }
                else
                {
                    MessageBox.Show("入荷IDは数値で入力してください");
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

            //受注IDの適否
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

            //検索条件に一致するデータ検索
            var filterArrival = Arrival
                .Where(c =>
                (stgID == -1 || c.ArId == stgID) &&
                (customerID == -1 || c.ClId == customerID) &&
                (soId == -1 || c.SoId == soId) &&
                (empID == -1 || c.EmId == empID) &&
                (jorderID == -1 || c.OrId == jorderID)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterArrival.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_StgPage.Text = "1";
                int pageSize = int.Parse(txb_StgPageSize.Text);
                dataGrid_Stg.DataSource = filterArrival;
                lbl_StgPage.Text = "/" + ((int)Math.Ceiling(filterArrival.Count / (double)pageSize)) + "ページ";
                dataGrid_Stg.Refresh();

            }
        }
        private void btn_StgHidden_Click(object sender, EventArgs e)
        {
            // 13.3  入荷非表示情報更新
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
            //入荷IDの適否
            if (!String.IsNullOrEmpty(txb_StgStoregoodsID.Text.Trim()))
            {
                //入荷IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_StgStoregoodsID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
                //入荷IDの文字数チェック
                if (txb_StgStoregoodsID.Text.Length > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDCDExistence(int.Parse(txb_StgStoregoodsID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入荷IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StgStoregoodsID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_StgHidden.Checked)
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
        //メソッド名：UpdateOrder()
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
            if (CheckBox_StgHidden.Checked)
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
                    var chumon = context.TArrivals.SingleOrDefault(x => x.ArId == int.Parse(txb_StgStoregoodsID.Text));
                    if (chumon != null)
                    {
                        chumon.ArFlag = flg;
                        chumon.ArHidden = HiddenReason;
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
        private void btn_StgtFix_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregChumonFix())
            {
                return;
            }
            //出荷テーブルに登録
            var regShip = GenerateDataAtRegTShip();
            RegistrationShip(regShip);
        }
        private bool GetValidDataAtregChumonFix()
        {
            if (!String.IsNullOrEmpty(txb_StgStoregoodsID.Text.Trim()))
            {
                if (!arrivalDataAccess.CheckArIDCDExistence(int.Parse(txb_StgStoregoodsID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入荷IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StgStoregoodsID.Focus();
                return false;
            }

            SalesManagementContext context = new SalesManagementContext();
            var arrival = context.TArrivals.SingleOrDefault(x => x.ArId == int.Parse(txb_StgStoregoodsID.Text.Trim()));
            int? flg = arrival.ArStateFlag;
            int hidden = arrival.ArFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された入荷IDはすでに受注確定されています", "エラー",
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
        ///////////////////////////////
        //          出荷情報作成
        //メソッド名：GenerateDataAtRegTShip()
        //引　数   ：なし
        //戻り値   ：出荷情報
        //機　能   ：出荷データのセット
        ///////////////////////////////
        private TShipment GenerateDataAtRegTShip()
        {
            SalesManagementContext context = new SalesManagementContext();
            var arrival = context.TArrivals.SingleOrDefault(x => x.ArId == int.Parse(txb_StgStoregoodsID.Text.Trim()));
            return new TShipment
            {
                ClId = arrival.ClId,
                EmId = null,
                SoId = arrival.SoId,
                OrId = arrival.OrId,
                ShStateFlag = 0,
                ShFinishDate = null,
                ShFlag = 0,
                ShHidden = ""
            };
        }
        ///////////////////////////////
        //         出荷情報登録
        //メソッド名：RegistrationShip()
        //引　数   ：出荷情報
        //戻り値   ：なし
        //機　能   ：出荷データの登録
        ///////////////////////////////
        private void RegistrationShip(TShipment regShip)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("入荷確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出荷情報の登録
            bool flg = shipmentDataAccess.AddShipData(regShip);


            if (flg == true)
            {
                MessageBox.Show("入荷情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var arrival = context.TArrivals.SingleOrDefault(x => x.ArId == int.Parse(txb_StgStoregoodsID.Text));
                    if (arrival != null)
                    {
                        arrival.ArStateFlag = 1;
                        arrival.ArDate = DateTime.Now;
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("入荷情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTShipmentDetail();
            GenerateDataAtRegEmpID(loginName);
            // 入力エリアのクリア
            ClearInput();
        }
        private void GenerateDataAtRegTShipmentDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var arid = int.Parse(txb_StgStoregoodsID.Text.Trim());
                var arrivalDetails = context.TArrivalDetails
                    .Where(x => x.ArId == arid)
                    .OrderBy(x => x.ArId)
                    .ToList();
                var confirmArrivalDetails = arrivalDetails.Select(x => new TShipmentDetail
                {
                    ShId = GenerateNewShId(context), // 新しいIDを生成
                    PrId = (int)x.PrId,
                    ShQuantity = (int)x.ArQuantity
                }).ToList();
                context.AddRange(confirmArrivalDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("出荷詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewShId(SalesManagementContext context)
        {
            // TShipmentDetailの現在の最大IDを取得して+1
            return (context.TShipmentDetails.Max(x => (int?)x.ShId) ?? 0) + 1;
        }
        private void GenerateDataAtRegEmpID(string user)
        {
            using (var context = new SalesManagementContext())
            {
                var arrival = context.TArrivals.SingleOrDefault(x => x.ArId == int.Parse(txb_StgStoregoodsID.Text));
                var emp = context.MEmployees.SingleOrDefault(x => x.EmName == user);
                arrival.EmId = emp.EmId;
                context.SaveChanges();
                context.Dispose();
            }

        }
        private void btn_SgBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_SgSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
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
                btn_StgHidden.Enabled = flg;
                btn_StgtFix.Enabled = flg;
                CheckBox_StgHidden.Enabled = flg;
            }
        }
        ///////////////////////////////
        //メソッド名：CheckAllTextBoxesFiled()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：テクストボックス入力チェック
        ///////////////////////////////
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_StgStoregoodsID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StgJOrderID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StgSalesOfficeID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StgEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StgCstmrID.Text) &&
                   string.IsNullOrWhiteSpace(txb_StgStoreDetailID.Text);
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            txb_StgStoregoodsID.Text = "";
            txb_StgJOrderID.Text = "";
            dtp_StgStoreDate.Text = "";
            txb_StgSalesOfficeID.Text = "";
            txb_StgSalesOfficeName.Text = "";
            txb_StgEmpID.Text = "";
            txb_StgEmpName.Text = "";
            txb_StgCstmrID.Text = "";
            txb_StgCstmrName.Text = "";
            txb_StgStoreDetailID.Text = "";
            txb_StgPrdctID.Text = "";
            txb_StgPrdctName.Text = "";
            txb_StgNum.Text = "";
            CheckBox_StgHidden.Checked = false;
            GetDataGridView();
        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_SgSelectForm.Items.Add("顧客管理画面");
                cmb_SgSelectForm.Items.Add("商品管理画面");
                cmb_SgSelectForm.Items.Add("在庫管理画面");
                cmb_SgSelectForm.Items.Add("社員管理画面");
                cmb_SgSelectForm.Items.Add("受注管理画面");
                cmb_SgSelectForm.Items.Add("注文管理画面");
                cmb_SgSelectForm.Items.Add("入庫管理画面");
                cmb_SgSelectForm.Items.Add("出庫管理画面");
                cmb_SgSelectForm.Items.Add("出荷管理画面");
                cmb_SgSelectForm.Items.Add("売上管理画面");
                cmb_SgSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_SgSelectForm.Items.Add("商品管理画面");
                cmb_SgSelectForm.Items.Add("在庫管理画面");
                cmb_SgSelectForm.Items.Add("入庫管理画面");
                cmb_SgSelectForm.Items.Add("出庫管理画面");
                cmb_SgSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_SgSelectForm.Items.Add("顧客管理画面");
                cmb_SgSelectForm.Items.Add("受注管理画面");
                cmb_SgSelectForm.Items.Add("注文管理画面");
                cmb_SgSelectForm.Items.Add("出荷管理画面");
                cmb_SgSelectForm.Items.Add("売上管理画面");
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
            txb_StgPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_StgPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Stg.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Stg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Stg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            //入荷データの取得
            Arrival = arrivalDataAccess.GetArrivalData();

            //DataGridViewに表示するデータを指定
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
            int pageSize = int.Parse(txb_StgPageSize.Text);
            int pageNo = int.Parse(txb_StgPage.Text) - 1;
            dataGrid_Stg.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Stg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Stg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Stg.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Stg.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGrid_Stg.Columns[8].DefaultCellStyle.Format = "yyyy/MM/dd";
            //dataGridViewの総ページ数
            lbl_StgPage.Text = "/" + ((int)Math.Ceiling(Arrival.Count / (double)pageSize)) + "ページ";

            dataGrid_Stg.Refresh();

        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_StgChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_StgFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StgPageSize.Text);
            dataGrid_Stg.DataSource = Arrival.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stg.Refresh();
            //ページ番号の設定
            txb_StgPage.Text = "1";
        }

        private void btn_StgPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StgPageSize.Text);
            int pageNo = int.Parse(txb_StgPage.Text) - 2;
            dataGrid_Stg.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stg.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_StgPage.Text = (pageNo + 1).ToString();
            else
                txb_StgPage.Text = "1";
        }

        private void btn_StgNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StgPageSize.Text);
            int pageNo = int.Parse(txb_StgPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Arrival.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Stg.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stg.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Arrival.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_StgPage.Text = lastPage.ToString();
            else
                txb_StgPage.Text = (pageNo + 1).ToString();
        }

        private void btn_StgLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_StgPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Arrival.Count / (double)pageSize) - 1;
            dataGrid_Stg.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Stg.Refresh();
            //ページ番号の設定
            txb_StgPage.Text = (pageNo + 1).ToString();
        }

        private void btn_StgInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btn_StgHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_StgHidden.Checked)
            {
                int stgid = int.Parse(txb_StgStoregoodsID.Text);
                HiddenReason = ShowHiddenReason(stgid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_StgHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int stgid)
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
                var arrival = context.TArrivals.Where(c => c.ArId == stgid).FirstOrDefault();
                if (arrival != null && !string.IsNullOrEmpty(arrival.ArHidden))
                {
                    HideReason = arrival.ArHidden;
                }
            }
            RichBox.Text = String.IsNullOrEmpty(HideReason) ? string.Empty : HideReason;
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();

            //結果を取得
            return result == DialogResult.OK ? RichBox.Text : null;
        }
        private bool GetValidData()
        {
            //入荷IDの適否
            if (!String.IsNullOrEmpty(txb_StgStoregoodsID.Text.Trim()))
            {
                //入荷IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_StgStoregoodsID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
                //入荷IDの文字数チェック
                if (txb_StgStoregoodsID.Text.Length > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDCDExistence(int.Parse(txb_StgStoregoodsID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_StgStoregoodsID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("入荷IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_StgStoregoodsID.Focus();
                return false;
            }
            return true;
        }

        private void txb_StgSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StgSalesOfficeID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StgSalesOfficeID.Text.Trim()))
                {
                    txb_StgSalesOfficeName.Text = string.Empty;
                }
                else
                {
                    GetSoId(int.Parse(txb_StgSalesOfficeID.Text));
                }
            }
            else
            {
                txb_StgSalesOfficeID.Text = string.Empty;
                txb_StgSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_StgSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_StgSalesOfficeName.Text = string.Empty;
                }
            }
        }

        private void txb_StgEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StgEmpID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StgEmpID.Text.Trim()))
                {
                    txb_StgEmpName.Text = string.Empty;
                }
                else
                {
                    GetEmId(int.Parse(txb_StgEmpID.Text));
                }
            }
            else
            {
                txb_StgEmpID.Text = string.Empty;
                txb_StgEmpName.Text = string.Empty;
            }
        }
        private void GetEmId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_StgEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_StgEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_StgCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StgCstmrID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StgCstmrID.Text.Trim()))
                {
                    txb_StgCstmrName.Text = string.Empty;
                }
                else
                {
                    GetCstmrId(int.Parse(txb_StgCstmrID.Text));
                }
            }
            else
            {
                txb_StgCstmrID.Text = string.Empty;
                txb_StgCstmrName.Text = string.Empty;
            }
        }
        private void GetCstmrId(int cstmrid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == cstmrid);
                if (Cstmr != null)
                {
                    txb_StgCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_StgCstmrName.Text = string.Empty;
                }
            }
        }

        private void txb_StgStoreDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StgStoreDetailID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_StgStoreDetailID.Text.Trim()))
                {
                    txb_StgPrdctID.Text = string.Empty;
                }
                else
                {
                    GetStgStoreDetailID(int.Parse(txb_StgStoreDetailID.Text));
                }
            }
            else
            {
                txb_StgStoreDetailID.Text = string.Empty;
            }
        }
        private void GetStgStoreDetailID(int stgdetailid)
        {
            using (var context = new SalesManagementContext())
            {
                var StgDetail = context.TArrivalDetails.FirstOrDefault(x => x.ArDetailId == stgdetailid);
                if (StgDetail != null)
                {
                    txb_StgPrdctID.Text = StgDetail.PrId.ToString();
                    txb_StgNum.Text = StgDetail.ArQuantity.ToString();
                }
                else
                {
                    txb_StgPrdctID.Text = string.Empty;
                }
            }
        }

        private void txb_StgPrdctID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_StgPrdctID.Text))
            {
                GetName(int.Parse(txb_StgPrdctID.Text));
            }
            else
            {
                txb_StgPrdctName.Text = string.Empty;
                txb_StgNum.Text = string.Empty;
            }
        }
        private void GetName(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_StgPrdctName.Text = product.PrName;
                }
                else
                {
                    txb_StgPrdctName.Text = string.Empty;
                }
            }
        }

        private void btn_StgShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "入荷詳細データ",
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
                txb_StgStoreDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_StgJOrderID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_StgPrdctID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_StgPrdctName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_StgNum.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_StgStoregoodsID.Text != "")
            {
                int arrivalid = int.Parse(txb_StgStoregoodsID.Text);
                ArrivalDetail = arrivaldetailDataAccess.GetArrivalDetailSelectData(arrivalid);
            }
            else
            {
                ArrivalDetail = arrivaldetailDataAccess.GetArrivalDetailDspData();
            }

            dataGridView.DataSource = ArrivalDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void dataGrid_Stg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_StgStoregoodsID.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[0].Value.ToString();
            txb_StgSalesOfficeID.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[1].Value.ToString();
            txb_StgEmpID.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[3].Value?.ToString() ?? string.Empty;
            txb_StgCstmrID.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[5].Value.ToString();
            txb_StgJOrderID.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[7].Value.ToString();
            dtp_StgStoreDate.Text = dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[8].Value?.ToString() ?? string.Empty;
            int flg = int.Parse(dataGrid_Stg.Rows[dataGrid_Stg.CurrentRow.Index].Cells[10].Value.ToString());
            if (flg == 0)
            {
                CheckBox_StgHidden.Checked = false;
            }
            else
            {
                CheckBox_StgHidden.Checked = true;
            }
        }

    }
}
