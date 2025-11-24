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

namespace SalesManagement_SysDev
{
    public partial class F_Shipgoods : Form
    {
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベースアクセス用クラスのインスタンス化
        ShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();
        SaleDataAccess saleDataAccess = new SaleDataAccess();
        ShipmentDetailDataAccess shipmentDetailDataAccess = new ShipmentDetailDataAccess();

        //データグリッドビュー用のデータ
        private static List<TShipmentDsp> Shipment;
        private static List<TSaleDsp> Sale;
        private static List<TShipmentDetailDsp> ShipmentDetail;

        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Shipgoods()
        {
            InitializeComponent();
        }
        private void F_Shipgoods_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_ShgLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Shgkengenmei.Text = "権限名：" + kengenmei;
            lbl_ShgDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");
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
                btn_ShgHidden.Enabled = flg;
                btn_ShgConfirm.Enabled = flg;
            }
        }
        private void btn_ShgShowList_Click(object sender, EventArgs e)
        {
            //14.1 出荷一覧
            Shipment = shipmentDataAccess.GetShipmentAllData();
            SetDataGridView();
        }
        private void btn_ShgSearch_Click(object sender, EventArgs e)
        {
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                ShgSearch();
            }
        }
        ///////////////////////////////
        //         出荷情報検索
        //メソッド名：ShipSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：出荷データの検索
        ///////////////////////////////
        private void ShgSearch()
        {
            int flg = 0;
            if (CheckBox_ShgHidden.Checked)
            {
                flg = 2;
            }
            string shgid = txb_ShgShipID.Text.Trim();
            string shgjor = txb_ShgJOrderID.Text.Trim();
            string shgEmp = txb_ShgEmpID.Text.Trim();
            string shgSale = txb_ShgSalesOfficeID.Text.Trim();
            string shgCstmr = txb_ShgCstmrID.Text.Trim();
            string shgDate = dtp_ShgDate.Text.Trim();

            int Shgid = -1;
            if (!string.IsNullOrEmpty(shgid))
            {
                if (int.TryParse(shgid, out int parsedid))
                {
                    Shgid = parsedid;
                }
                else
                {
                    MessageBox.Show("出荷IDは数字で入力してください");
                    return;
                }
            }
            int jorid = -1;
            if (!string.IsNullOrEmpty(shgjor))
            {
                if (int.TryParse(shgjor, out int parsedjor))
                {
                    jorid = parsedjor;
                }
                else
                {
                    MessageBox.Show("受注IDは数字で入力してください");
                    return;
                }
            }
            int empid = -1;
            if (!String.IsNullOrEmpty(shgEmp))
            {
                if (int.TryParse(shgEmp, out int parsedemp))
                {
                    empid = parsedemp;
                }

                else
                {
                    MessageBox.Show("社員IDは数字で入力してください");
                    return;
                }
            }
            int soid = -1;
            if (!String.IsNullOrEmpty(shgSale))
            {
                if (int.TryParse(shgSale, out int parsedsale))
                {
                    soid = parsedsale;
                }
                else
                {
                    MessageBox.Show("営業所IDは数字で入力してください");
                    return;
                }
            }
            int Cstmrid = -1;
            if (!String.IsNullOrEmpty(shgCstmr))
            {
                if (int.TryParse(shgCstmr, out int parsedCstmr))
                {
                    Cstmrid = parsedCstmr;
                }
                else
                {
                    MessageBox.Show("顧客IDは数字で入力してください");
                    return;
                }
            }
            //検索条件に一致するデータ検索
            var filterShipment = Shipment
                .Where(c =>
                (Shgid == -1 || c.ShId == Shgid) &&
                (Cstmrid == -1 || c.ClId == Cstmrid) &&
                (soid == -1 || c.SoId == soid) &&
                (empid == -1 || c.EmId == soid) &&
                (jorid == -1 || c.OrId == jorid)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterShipment.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_ShgPage.Text = "1";
                int pageSize = int.Parse(txb_ShgPageSize.Text);
                dataGrid_Shg.DataSource = filterShipment;
                lbl_ShgPage.Text = "/" + ((int)Math.Ceiling(filterShipment.Count / (double)pageSize)) + "ページ";
                dataGrid_Shg.Refresh();

            }
        }
        private void btn_ShgHidden_Click(object sender, EventArgs e)
        {
            // 14.3 出荷非表示情報更新
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
            //出荷IDの適否
            if (!String.IsNullOrEmpty(txb_ShgShipID.Text.Trim()))
            {
                //出荷IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ShgShipID.Text.Trim()))
                {
                    MessageBox.Show("出荷IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
                //出荷IDの文字数チェック
                if (txb_ShgShipID.Text.Length > 6)
                {
                    MessageBox.Show("出荷IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
                // 出荷IDの存在チェック
                if (!shipmentDataAccess.CheckShIdCDExistence(int.Parse(txb_ShgShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出荷IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShgShipID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_ShgHidden.Checked)
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
        //　 出荷非表示情報更新
        //メソッド名：UpdateHidden()
        //引　数   ：出荷非表示情報
        //戻り値   ：
        //機　能   ：出荷情報の更新
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
            if (CheckBox_ShgHidden.Checked)
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
                    var shipment = context.TShipments.SingleOrDefault(x => x.ShId == int.Parse(txb_ShgShipID.Text));
                    if (shipment != null)
                    {
                        shipment.ShFlag = flg;
                        shipment.ShHidden = HiddenReason;
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
        private void btn_ShgConfirm_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregShipmentFix())
            {
                return;
            }
            GenerateDataAtRegEmpID(loginName);
            //売上テーブルに登録
            var regSales = GenerateDataAtRegTSales();
            RegistrationSales(regSales);
        }
        private bool GetValidDataAtregShipmentFix()
        {
            if (!String.IsNullOrEmpty(txb_ShgShipID.Text.Trim()))
            {
                if (!shipmentDataAccess.CheckShIdCDExistence(int.Parse(txb_ShgShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出荷IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShgShipID.Focus();
                return false;
            }

            SalesManagementContext context = new SalesManagementContext();
            var shipment = context.TShipments.SingleOrDefault(x => x.ShId == int.Parse(txb_ShgShipID.Text.Trim()));
            int? flg = shipment.ShStateFlag;
            int hidden = shipment.ShFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された出荷IDはすでに受注確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された出荷IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        ///////////////////////////////
        //          売上情報作成
        //メソッド名：GenerateDataAtRegTShipment()
        //引　数   ：なし
        //戻り値   ：売上情報
        //機　能   ：売上データのセット
        ///////////////////////////////
        private TSale GenerateDataAtRegTSales()
        {
            SalesManagementContext context = new SalesManagementContext();
            var shipment = context.TShipments.SingleOrDefault(x => x.ShId == int.Parse(txb_ShgShipID.Text.Trim()));
            int empid = (int)shipment.EmId;
            return new TSale
            {
                SoId = shipment.SoId,
                EmId = empid,
                ClId = shipment.ClId,
                OrId = shipment.OrId,
                SaDate = DateTime.Now,
                SaFlag = 0,
                SaHidden = ""
            };
        }
        ///////////////////////////////
        //         売上情報登録
        //メソッド名：RegistrationSales()
        //引　数   ：売上情報
        //戻り値   ：なし
        //機　能   ：売上データの登録
        ///////////////////////////////
        private void RegistrationSales(TSale regSales)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("出荷確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;
            // 売上情報の登録
            bool flg = saleDataAccess.AddSaleData(regSales);


            if (flg == true)
            {
                MessageBox.Show("出荷情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var syukka = context.TShipments.SingleOrDefault(x => x.ShId == int.Parse(txb_ShgShipID.Text));
                    if (syukka != null)
                    {
                        syukka.ShStateFlag = 1;
                        syukka.ShFinishDate = DateTime.Now;
                        context.SaveChanges();
                        context.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("出荷情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTSaleDetail();
            // 入力エリアのクリア
            ClearInput();
        }
        private void GenerateDataAtRegEmpID(string user)
        {
            using (var context = new SalesManagementContext())
            {
                var syukka = context.TShipments.SingleOrDefault(x => x.ShId == int.Parse(txb_ShgShipID.Text));
                var emp = context.MEmployees.SingleOrDefault(x => x.EmName == user);
                syukka.EmId = emp.EmId;
                context.SaveChanges();
                context.Dispose();
            }
        }
        private void GenerateDataAtRegTSaleDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var Shid = int.Parse(txb_ShgShipID.Text.Trim());
                var ShipmentDetails = context.TShipmentDetails
                    .Where(x => x.ShId == Shid)
                    .OrderBy(x => x.ShId)
                    .ToList();
                var prid = ShipmentDetails.Select(x => x.PrId).ToList();
                var prprice = context.MProducts
                    .Where(x => prid.Contains(x.PrId))
                    .ToDictionary(x => x.PrId, x => x.Price);

                var confirmChumonDetails = ShipmentDetails.Select(x => new TSaleDetail
                {
                    SaId = GenerateNewSaId(context), // 新しいIDを生成
                    PrId = x.PrId,
                    SaQuantity = x.ShQuantity,
                    SaPrTotalPrice = x.ShQuantity * (prprice.ContainsKey(x.PrId) ? prprice[x.PrId] : 0)
                }).ToList();
                context.AddRange(confirmChumonDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("売上詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewSaId(SalesManagementContext context)
        {
            // TSaleDetailの現在の最大IDを取得して+1
            return (context.TSaleDetails.Max(x => (int?)x.SaId) ?? 0) + 1;
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
            txb_ShgPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_ShgPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Shg.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Shg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Shg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 出荷データの取得
            Shipment = shipmentDataAccess.GetShipmentDspData();

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
            int pageSize = int.Parse(txb_ShgPageSize.Text);
            int pageNo = int.Parse(txb_ShgPage.Text) - 1;
            dataGrid_Shg.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            dataGrid_Shg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Shg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGrid_Shg.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Shg.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            lbl_ShgPage.Text = "/" + ((int)Math.Ceiling(Shipment.Count / (double)pageSize)) + "ページ";
            dataGrid_Shg.Refresh();
        }
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_ShgShipID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShgJOrderID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShgEmpID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShgSalesOfficeID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShgCstmrID.Text) &&
                string.IsNullOrWhiteSpace(dtp_ShgDate.Text);
        }
        private void btn_ShipgoodsFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_ShgSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_ShgSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_ShipgoodsBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_ShgSelectForm.Items.Clear();
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
                cmb_ShgSelectForm.Items.Add("顧客管理画面");
                cmb_ShgSelectForm.Items.Add("商品管理画面");
                cmb_ShgSelectForm.Items.Add("在庫管理画面");
                cmb_ShgSelectForm.Items.Add("社員管理画面");
                cmb_ShgSelectForm.Items.Add("受注管理画面");
                cmb_ShgSelectForm.Items.Add("注文管理画面");
                cmb_ShgSelectForm.Items.Add("入庫管理画面");
                cmb_ShgSelectForm.Items.Add("出庫管理画面");
                cmb_ShgSelectForm.Items.Add("入荷管理画面");
                cmb_ShgSelectForm.Items.Add("売上管理画面");
                cmb_ShgSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_ShgSelectForm.Items.Add("商品管理画面");
                cmb_ShgSelectForm.Items.Add("在庫管理画面");
                cmb_ShgSelectForm.Items.Add("入庫管理画面");
                cmb_ShgSelectForm.Items.Add("出庫管理画面");
                cmb_ShgSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_ShgSelectForm.Items.Add("顧客管理画面");
                cmb_ShgSelectForm.Items.Add("受注管理画面");
                cmb_ShgSelectForm.Items.Add("注文管理画面");
                cmb_ShgSelectForm.Items.Add("入荷管理画面");
                cmb_ShgSelectForm.Items.Add("売上管理画面");
            }
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_ShgChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_ShgFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShgPageSize.Text);
            dataGrid_Shg.DataSource = Shipment.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Shg.Refresh();
            //ページ番号の設定
            txb_ShgPage.Text = "1";
        }

        private void btn_ShgPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShgPageSize.Text);
            int pageNo = int.Parse(txb_ShgPage.Text) - 2;
            dataGrid_Shg.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Shg.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_ShgPage.Text = (pageNo + 1).ToString();
            else
                txb_ShgPage.Text = "1";
        }

        private void btn_ShgNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShgPageSize.Text);
            int pageNo = int.Parse(txb_ShgPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Shg.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Shg.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Shipment.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_ShgPage.Text = lastPage.ToString();
            else
                txb_ShgPage.Text = (pageNo + 1).ToString();
        }

        private void btn_ShgLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShgPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            dataGrid_Shg.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Shg.Refresh();
            //ページ番号の設定
            txb_ShgPage.Text = (pageNo + 1).ToString();
        }
        private void ClearInput()
        {
            txb_ShgShipID.Text = "";
            txb_ShgCstmrID.Text = "";
            txb_ShgCstmrName.Text = "";
            txb_ShgEmpID.Text = "";
            txb_ShgEmpName.Text = "";
            txb_ShgJOrderID.Text = "";
            txb_ShgSalesOfficeID.Text = "";
            txb_ShgSalesOfficeName.Text = "";
            dtp_ShgDate.Text = "";
            txb_ShgDetailID.Text = "";
            txb_ShgProductID.Text = "";
            txb_ShgProductName.Text = "";
            txb_ShgProductcnt.Text = "";
            CheckBox_ShgHidden.Checked = false;
            GetDataGridView();
        }

        private void btn_ShgInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btn_ShgHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_ShgHidden.Checked)
            {
                int syid = int.Parse(txb_ShgShipID.Text);
                HiddenReason = ShowHiddenReason(syid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_ShgHidden.Focus();
            }
        }
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_ShgShipID.Text.Trim()))
            {
                // 出荷IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ShgShipID.Text.Trim()))
                {
                    MessageBox.Show("出荷IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
                // 出荷IDの文字数チェック
                if (txb_ShgShipID.TextLength > 6)
                {
                    MessageBox.Show("出荷IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
                if (!shipmentDataAccess.CheckShIdCDExistence(int.Parse(txb_ShgShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出荷IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShgShipID.Focus();
                return false;
            }
            return true;
        }
        private static string ShowHiddenReason(int syid)
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
                var syukka = context.TShipments.Where(c => c.ShId == syid).FirstOrDefault();
                if (syukka != null && !string.IsNullOrEmpty(syukka.ShHidden))
                {
                    HideReason = syukka.ShHidden;
                }
            }
            RichBox.Text = String.IsNullOrEmpty(HideReason) ? string.Empty : HideReason;
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();

            //結果を取得
            return result == DialogResult.OK ? RichBox.Text : null;
        }

        private void dataGrid_Shg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_ShgShipID.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[0].Value.ToString();
            txb_ShgSalesOfficeID.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[1].Value.ToString();
            txb_ShgEmpID.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[3].Value?.ToString() ?? string.Empty;
            txb_ShgCstmrID.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[5].Value.ToString();
            txb_ShgJOrderID.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[7].Value.ToString();
            dtp_ShgDate.Text = dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[8].Value?.ToString() ?? string.Empty;
            int flg = int.Parse(dataGrid_Shg.Rows[dataGrid_Shg.CurrentRow.Index].Cells[10].Value.ToString());
            if (flg == 0)
            {
                CheckBox_ShgHidden.Checked = false;
            }
            else
            {
                CheckBox_ShgHidden.Checked = true;
            }
        }

        private void btn_ShgShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "出荷詳細データ",
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
                txb_ShgDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_ShgShipID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_ShgProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_ShgProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_ShgProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_ShgShipID.Text != "")
            {
                int shgid = int.Parse(txb_ShgShipID.Text);
                ShipmentDetail = shipmentDetailDataAccess.GetShgDetailSelectData(shgid);
            }
            else
            {
                ShipmentDetail = shipmentDetailDataAccess.GetShgDetailData();
            }
            dataGridView.DataSource = ShipmentDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void txb_ShgEmpID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShgEmpID.Text))
            {
                if (int.TryParse(txb_ShgEmpID.Text, out int empId))
                {
                    GetEmpId(int.Parse(txb_ShgEmpID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgEmpID.Text = string.Empty;
                }
            }
            else
            {
                txb_ShgEmpID.Text = string.Empty;
                txb_ShgEmpName.Text = string.Empty;
            }
        }
        private void GetEmpId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_ShgEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_ShgEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_ShgSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShgSalesOfficeID.Text))
            {
                if (int.TryParse(txb_ShgSalesOfficeID.Text, out int soId))
                {
                    GetSoId(int.Parse(txb_ShgSalesOfficeID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgSalesOfficeID.Text = string.Empty;
                }
            }
            else
            {
                txb_ShgSalesOfficeID.Text = string.Empty;
                txb_ShgSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_ShgSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_ShgSalesOfficeName.Text = string.Empty;
                }
            }
        }

        private void txb_ShgCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShgCstmrID.Text))
            {
                if (int.TryParse(txb_ShgCstmrID.Text, out int cstmrId))
                {
                    GetCstmrId(int.Parse(txb_ShgCstmrID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShgCstmrID.Text = string.Empty;
                }
            }
            else
            {
                txb_ShgCstmrID.Text = string.Empty;
                txb_ShgCstmrName.Text = string.Empty;
            }
        }
        private void GetCstmrId(int cstmrid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == cstmrid);
                if (Cstmr != null)
                {
                    txb_ShgCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_ShgCstmrName.Text = string.Empty;
                }
            }
        }

        private void txb_ShgDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShgDetailID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShgDetailID.Text.Trim()))
                {
                    txb_ShgDetailID.Text = string.Empty;
                }
                else
                {
                    GetShgDetailID(int.Parse(txb_ShgDetailID.Text));
                }
            }
            else
            {
                txb_ShgDetailID.Text = string.Empty;
            }
        }
        private void GetShgDetailID(int detailid)
        {
            using (var context = new SalesManagementContext())
            {
                var Detail = context.TShipmentDetails.FirstOrDefault(x => x.ShDetailId == detailid);
                if (Detail != null)
                {
                    txb_ShgProductID.Text = Detail.PrId.ToString();
                    txb_ShgProductcnt.Text = Detail.ShQuantity.ToString();
                }
                else
                {
                    txb_ShgProductID.Text = string.Empty;
                }
            }
        }
    }
}
