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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using システム開発メニュー;
using static Azure.Core.HttpHeader;

namespace SalesManagement_SysDev
{
    public partial class F_Ship : Form
    {

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データベースアクセス用クラスのインスタンス化
        SyukkoDataAccess syukkoDataAccess = new SyukkoDataAccess();
        SalesOfficeDataAccess salesofficeDataAccess = new SalesOfficeDataAccess();
        SyukkoDetailDataAccess syukkoDetailDataAccess = new SyukkoDetailDataAccess();
        ArrivalDataAccess arrivalDataAccess = new ArrivalDataAccess();

        //データグリッドビュー用のデータ
        private static List<TSyukkoDsp> Syukko;
        private static List<MSalesOfficeDsp> SalesOffice;
        private static List<TSyukkoDetailDsp> SyukkoDetail;

        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Ship()
        {
            InitializeComponent();
        }
        private void F_Ship_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_ShipLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Shipkengenmei.Text = "権限名：" + kengenmei;
            lbl_ShipDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

            //ボタンEnable設定
            SetEnable(false);
            //コンボボックスにアイテム追加
            cmb_boxAddItems(kengenmei);
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
                btn_ShipHidden.Enabled = flg;
                btn_ShipConfirm.Enabled = flg;
            }
        }

        private void btn_ShipShowList_Click(object sender, EventArgs e)
        {
            //12.1 出庫一覧
            Syukko = syukkoDataAccess.GetSyukkoAllData();
            SetDataGridView();
        }
        private void btn_ShipSearch_Click(object sender, EventArgs e)
        {
            if (CheckAllTextBoxesFilled() == true)
            {
                InitializeComponent();
            }
            else
            {
                ShipSearch();
            }
        }
        ///////////////////////////////
        //         出庫情報検索
        //メソッド名：ShipSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客データの検索
        ///////////////////////////////
        private void ShipSearch()
        {
            int flg = 0;
            if (CheckBox_ShipHidden.Checked)
            {
                flg = 2;
            }
            string shipid = txb_ShipShipID.Text.Trim();
            string shipjor = txb_ShipJOrderID.Text.Trim();
            string shipEmp = txb_ShipEmpId.Text.Trim();
            string shipSale = txb_ShipSalesOffice.Text.Trim();
            string shipCstmr = txb_ShipCstmrID.Text.Trim();
            string shipDate = dtp_ShipDate.Text.Trim();

            int syid = -1;
            if (!string.IsNullOrEmpty(shipid))
            {
                if (int.TryParse(shipid, out int parsedid))
                {
                    syid = parsedid;
                }
                else
                {
                    MessageBox.Show("出庫IDは数字で入力してください");
                    return;
                }
            }
            int jorid = -1;
            if (!string.IsNullOrEmpty(shipjor))
            {
                if (int.TryParse(shipjor, out int parsedjor))
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
            if (!String.IsNullOrEmpty(shipEmp))
            {
                if (int.TryParse(shipEmp, out int parsedemp))
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
            if (!String.IsNullOrEmpty(shipSale))
            {
                if (int.TryParse(shipSale, out int parsedsale))
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
            if (!String.IsNullOrEmpty(shipCstmr))
            {
                if (int.TryParse(shipCstmr, out int parsedCstmr))
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
            var filterShip = Syukko
                .Where(c =>
                (syid == -1 || c.SyId == syid) &&
                (Cstmrid == -1 || c.ClId == Cstmrid) &&
                (soid == -1 || c.SoId == soid) &&
                (empid == -1 || c.EmId == soid) &&
                (jorid == -1 || c.OrID == jorid)).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterShip.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_ShipPage.Text = "1";
                int pageSize = int.Parse(txb_ShipPageSize.Text);
                dataGrid_Ship.DataSource = filterShip;
                lbl_ShipPage.Text = "/" + ((int)Math.Ceiling(filterShip.Count / (double)pageSize)) + "ページ";
                dataGrid_Ship.Refresh();

            }
        }
        private void btn_ShipHidden_Click(object sender, EventArgs e)
        {
            // 13.3 出庫非表示情報更新
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
            //出庫IDの適否
            if (!String.IsNullOrEmpty(txb_ShipShipID.Text.Trim()))
            {
                //出庫IDの入力形式チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ShipShipID.Text.Trim()))
                {
                    MessageBox.Show("出庫IDは全て数値入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
                //出庫IDの文字数チェック
                if (txb_ShipShipID.Text.Length > 6)
                {
                    MessageBox.Show("出庫IDは6文字以下です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
                // 出庫IDの存在チェック
                if (!syukkoDataAccess.CheckSyIdCDExistence(int.Parse(txb_ShipShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出庫IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出庫IDが入力されていません", "エラー"
                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShipShipID.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_ShipHidden.Checked)
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
            if (CheckBox_ShipHidden.Checked)
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
                    var syukko = context.TSyukkos.SingleOrDefault(x => x.SyId == int.Parse(txb_ShipShipID.Text));
                    if (syukko != null)
                    {
                        syukko.SyFlag = flg;
                        syukko.SyHidden = HiddenReason;
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
        private void btn_ShipConfirm_Click(object sender, EventArgs e)
        {
            if (!GetValidDataAtregShipFix())
            {
                return;
            }
            //入荷テーブルに登録
            var regArrival = GenerateDataAtRegTArrival();
            RegistrationArrival(regArrival);
        }

        private bool GetValidDataAtregShipFix()
        {
            if (!String.IsNullOrEmpty(txb_ShipShipID.Text.Trim()))
            {
                if (!syukkoDataAccess.CheckSyIdCDExistence(int.Parse(txb_ShipShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出庫IDは存在していません", "エラー"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出庫IDを入力してください。", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShipShipID.Focus();
                return false;
            }

            SalesManagementContext context = new SalesManagementContext();
            var syukko = context.TSyukkos.SingleOrDefault(x => x.SyId == int.Parse(txb_ShipShipID.Text.Trim()));
            int? flg = syukko.SyStateFlag;
            int hidden = syukko.SyFlag;
            if (flg == 1)
            {
                MessageBox.Show("入力された出庫IDはすでに受注確定されています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hidden == 2)
            {
                MessageBox.Show("入力された出庫IDは非表示になっています", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        ///////////////////////////////
        //          入荷情報作成
        //メソッド名：GenerateDataAtRegTArrival()
        //引　数   ：なし
        //戻り値   ：入荷情報
        //機　能   ：入荷データのセット
        ///////////////////////////////
        private TArrival GenerateDataAtRegTArrival()
        {
            SalesManagementContext context = new SalesManagementContext();
            var syukko = context.TSyukkos.SingleOrDefault(x => x.SyId == int.Parse(txb_ShipShipID.Text.Trim()));
            return new TArrival
            {
                SoId = syukko.SoId,
                EmId = null,
                ClId = syukko.ClId,
                OrId = syukko.OrId,
                ArDate = null,
                ArStateFlag = 0,
                ArFlag = 0,
                ArHidden = ""
            };
        }
        ///////////////////////////////
        //         入荷情報登録
        //メソッド名：RegistrationArrival()
        //引　数   ：入荷情報
        //戻り値   ：なし
        //機　能   ：入荷データの登録
        ///////////////////////////////
        private void RegistrationArrival(TArrival regArrival)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("出庫確定しますか？", "確定確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 入荷情報の登録
            bool flg = arrivalDataAccess.AddArrivalData(regArrival);


            if (flg == true)
            {
                MessageBox.Show("出庫情報を確定しました。", "登録完了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var context = new SalesManagementContext())
                {
                    var syukko = context.TSyukkos.SingleOrDefault(x => x.SyId == int.Parse(txb_ShipShipID.Text));
                    if (syukko != null)
                    {
                        syukko.SyStateFlag = 1;
                        syukko.SyDate = DateTime.Now;
                        context.SaveChanges();
                        context.Dispose();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("出庫情報の確定に失敗しました。", "登録失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GenerateDataAtRegTArrivalDetail();
            GenerateDataAtRegEmpID(loginName);
            // 入力エリアのクリア
            ClearInput();
        }
        private void GenerateDataAtRegTArrivalDetail()
        {
            SalesManagementContext context = new SalesManagementContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var Syid = int.Parse(txb_ShipShipID.Text.Trim());
                var SyukkoDetails = context.TSyukkoDetails
                    .Where(x => x.SyId == Syid)
                    .OrderBy(x => x.SyId)
                    .ToList();
                var confirmChumonDetails = SyukkoDetails.Select(x => new TArrivalDetail
                {
                    ArId = GenerateNewArId(context), // 新しいIDを生成
                    PrId = x.PrId,
                    ArQuantity = x.SyQuantity
                }).ToList();
                context.AddRange(confirmChumonDetails);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("入荷詳細テーブルにデータを追加できませんでした", "エラー"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GenerateNewArId(SalesManagementContext context)
        {
            // TArrivalDetailの現在の最大IDを取得して+1
            return (context.TArrivalDetails.Max(x => (int?)x.ArId) ?? 0) + 1;
        }
        private void GenerateDataAtRegEmpID(string user)
        {
            using (var context = new SalesManagementContext())
            {
                var syukko = context.TSyukkos.SingleOrDefault(x => x.SyId == int.Parse(txb_ShipShipID.Text));
                var emp = context.MEmployees.SingleOrDefault(x => x.EmName == user);
                syukko.EmId = emp.EmId;
                context.SaveChanges();
                context.Dispose();
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
            txb_ShipPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_ShipPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Ship.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Ship.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Ship.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 出庫データの取得
            Syukko = syukkoDataAccess.GetSyukkoDspData();

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
            int pageSize = int.Parse(txb_ShipPageSize.Text);
            int pageNo = int.Parse(txb_ShipPage.Text) - 1;
            dataGrid_Ship.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            dataGrid_Ship.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Ship.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGrid_Ship.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Ship.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            lbl_ShipPage.Text = "/" + ((int)Math.Ceiling(Syukko.Count / (double)pageSize)) + "ページ";
            dataGrid_Ship.Refresh();
        }
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_ShipShipID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShipJOrderID.Text) &&
                string.IsNullOrWhiteSpace(txb_ShipEmpId.Text) &&
                string.IsNullOrWhiteSpace(txb_ShipSalesOffice.Text) &&
                string.IsNullOrWhiteSpace(txb_ShipCstmrID.Text) &&
                string.IsNullOrWhiteSpace(dtp_ShipDate.Text);
        }
        private void cmb_boxAddItems(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_ShipSelectForm.Items.Add("商品管理画面");
                cmb_ShipSelectForm.Items.Add("在庫管理画面");
                cmb_ShipSelectForm.Items.Add("社員管理画面");
                cmb_ShipSelectForm.Items.Add("受注管理画面");
                cmb_ShipSelectForm.Items.Add("注文管理画面");
                cmb_ShipSelectForm.Items.Add("入庫管理画面");
                cmb_ShipSelectForm.Items.Add("出庫管理画面");
                cmb_ShipSelectForm.Items.Add("入荷管理画面");
                cmb_ShipSelectForm.Items.Add("出荷管理画面");
                cmb_ShipSelectForm.Items.Add("売上管理画面");
                cmb_ShipSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_ShipSelectForm.Items.Add("商品管理画面");
                cmb_ShipSelectForm.Items.Add("在庫管理画面");
                cmb_ShipSelectForm.Items.Add("入庫管理画面");
                cmb_ShipSelectForm.Items.Add("出庫管理画面");
                cmb_ShipSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_ShipSelectForm.Items.Add("受注管理画面");
                cmb_ShipSelectForm.Items.Add("注文管理画面");
                cmb_ShipSelectForm.Items.Add("入荷管理画面");
                cmb_ShipSelectForm.Items.Add("出荷管理画面");
                cmb_ShipSelectForm.Items.Add("売上管理画面");
            }
        }

        private void btn_ShipInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btn_ShipShowDetail_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "出庫詳細データ",
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
                txb_ShipDetailID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_ShipShipID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
                txb_ShipProductID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                txb_ShipProductName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[3].Value.ToString();
                txb_ShipProductcnt.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[4].Value.ToString();

            };

            diarog.Controls.Add(dataGridView);
            if (txb_ShipShipID.Text != "")
            {
                int shipid = int.Parse(txb_ShipShipID.Text);
                SyukkoDetail = syukkoDetailDataAccess.GetSyukkoDetailSelectData(shipid);
            }
            else
            {
                SyukkoDetail = syukkoDetailDataAccess.GetSyukkoDetailData();
            }
            dataGridView.DataSource = SyukkoDetail;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }
        private void ClearInput()
        {
            txb_ShipShipID.Text = "";
            txb_ShipCstmrID.Text = "";
            txb_ShipCstmrName.Text = "";
            txb_ShipEmpId.Text = "";
            txb_ShipEmpName.Text = "";
            txb_ShipJOrderID.Text = "";
            txb_ShipSalesOffice.Text = "";
            txb_ShipSalesOfficeName.Text = "";
            dtp_ShipDate.Text = "";
            txb_ShipDetailID.Text = "";
            txb_ShipProductID.Text = "";
            txb_ShipProductName.Text = "";
            txb_ShipProductcnt.Text = "";
            CheckBox_ShipHidden.Checked = false;
            GetDataGridView();
        }

        private void btn_ShipHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_ShipHidden.Checked)
            {
                int syid = int.Parse(txb_ShipShipID.Text);
                HiddenReason = ShowHiddenReason(syid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_ShipHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int shipid)
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
                var syukko = context.TSyukkos.Where(c => c.SyId == shipid).FirstOrDefault();
                if (syukko != null && !string.IsNullOrEmpty(syukko.SyHidden))
                {
                    HideReason = syukko.SyHidden;
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
            if (!String.IsNullOrEmpty(txb_ShipShipID.Text.Trim()))
            {
                // 出庫IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_ShipShipID.Text.Trim()))
                {
                    MessageBox.Show("出庫IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
                // 出庫IDの文字数チェック
                if (txb_ShipShipID.TextLength > 2)
                {
                    MessageBox.Show("出庫IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
                if (!syukkoDataAccess.CheckClIdCDExistence(int.Parse(txb_ShipShipID.Text.Trim())))
                {
                    MessageBox.Show("入力された出庫IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_ShipShipID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("出庫IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ShipShipID.Focus();
                return false;
            }
            return true;
        }
        private void btn_ShipFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_ShipSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_ShipSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_ShipBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_ShipSelectForm.Items.Clear();
            F_Menu menu = Application.OpenForms.OfType<F_Menu>().FirstOrDefault();
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }

        ///////////////////////////////
        //メソッド名：btn_ShipChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_ShipChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btn_ShipPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShipPageSize.Text);
            dataGrid_Ship.DataSource = Syukko.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Ship.Refresh();
            //ページ番号の設定
            txb_ShipPage.Text = "1";
        }

        private void btn_ShipPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShipPageSize.Text);
            int pageNo = int.Parse(txb_ShipPage.Text) - 2;
            dataGrid_Ship.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Ship.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                txb_ShipPage.Text = (pageNo + 1).ToString();
            else
                txb_ShipPage.Text = "1";
        }

        private void btn_ShipNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShipPageSize.Text);
            int pageNo = int.Parse(txb_ShipPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Syukko.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Ship.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Ship.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Syukko.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_ShipPage.Text = lastPage.ToString();
            else
                txb_ShipPage.Text = (pageNo + 1).ToString();
        }

        private void btn_ShipLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_ShipPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Syukko.Count / (double)pageSize) - 1;
            dataGrid_Ship.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Ship.Refresh();
            //ページ番号の設定
            txb_ShipPage.Text = (pageNo + 1).ToString();
        }

        private void txb_ShipEmpId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShipEmpId.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShipEmpId.Text.Trim()))
                {
                    txb_ShipEmpName.Text = string.Empty;
                }
                else
                {
                    GetEmId(int.Parse(txb_ShipEmpId.Text));
                }
            }
            else
            {
                txb_ShipEmpId.Text = string.Empty;
                txb_ShipEmpName.Text = string.Empty;
            }
        }
        private void GetEmId(int empid)
        {
            using (var context = new SalesManagementContext())
            {
                var Emp = context.MEmployees.FirstOrDefault(x => x.EmId == empid);
                if (Emp != null)
                {
                    txb_ShipEmpName.Text = Emp.EmName;
                }
                else
                {
                    txb_ShipEmpName.Text = string.Empty;
                }
            }
        }

        private void txb_ShipSalesOffice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShipSalesOffice.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShipSalesOffice.Text.Trim()))
                {
                    txb_ShipSalesOfficeName.Text = string.Empty;
                }
                else
                {
                    GetSoId(int.Parse(txb_ShipSalesOffice.Text));
                }
            }
            else
            {
                txb_ShipSalesOffice.Text = string.Empty;
                txb_ShipSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_ShipSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_ShipSalesOfficeName.Text = string.Empty;
                }
            }
        }

        private void txb_ShipCstmrID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShipCstmrID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShipCstmrID.Text.Trim()))
                {
                    txb_ShipCstmrName.Text = string.Empty;
                }
                else
                {
                    GetCstmrId(int.Parse(txb_ShipCstmrID.Text));
                }
            }
            else
            {
                txb_ShipCstmrID.Text = string.Empty;
                txb_ShipCstmrName.Text = string.Empty;
            }
        }
        private void GetCstmrId(int cstmrid)
        {
            using (var context = new SalesManagementContext())
            {
                var Cstmr = context.MClients.FirstOrDefault(x => x.ClId == cstmrid);
                if (Cstmr != null)
                {
                    txb_ShipCstmrName.Text = Cstmr.ClName;
                }
                else
                {
                    txb_ShipCstmrName.Text = string.Empty;
                }
            }
        }

        private void txb_ShipDetailID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShipDetailID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShipDetailID.Text.Trim()))
                {
                    txb_ShipProductID.Text = string.Empty;
                }
                else
                {
                    GetShipDetailID(int.Parse(txb_ShipDetailID.Text));
                }
            }
            else
            {
                txb_ShipDetailID.Text = string.Empty;
            }
        }
        private void GetShipDetailID(int shipdetailid)
        {
            using (var context = new SalesManagementContext())
            {
                var shipDetail = context.TSyukkoDetails.FirstOrDefault(x => x.SyDetailId == shipdetailid);
                if (shipDetail != null)
                {
                    txb_ShipProductID.Text = shipDetail.PrId.ToString();
                    txb_ShipProductcnt.Text = shipDetail.SyQuantity.ToString();
                }
                else
                {
                    txb_ShipProductID.Text = string.Empty;
                }
            }
        }

        private void txb_ShipProductID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_ShipProductID.Text))
            {
                if (!dataInputFormCheck.CheckNumeric(txb_ShipProductID.Text.Trim()))
                {
                    txb_ShipProductID.Text = string.Empty;
                }
                else
                {
                    GetName(int.Parse(txb_ShipProductID.Text));
                }
            }
            else
            {
                txb_ShipProductID.Text = string.Empty;
                txb_ShipProductName.Text = string.Empty;
            }
        }
        private void GetName(int prodID)
        {
            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(x => x.PrId == prodID);
                if (product != null)
                {
                    txb_ShipProductName.Text = product.PrName;
                }
                else
                {
                    txb_ShipProductName.Text = string.Empty;
                }
            }
        }

        private void dataGrid_Ship_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_ShipShipID.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[0].Value.ToString();
            txb_ShipEmpId.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[1].Value?.ToString() ?? string.Empty;
            txb_ShipCstmrID.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[3].Value.ToString();
            txb_ShipSalesOffice.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[5].Value.ToString();
            txb_ShipJOrderID.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[7].Value.ToString();
            dtp_ShipDate.Text = dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[8].Value?.ToString() ?? string.Empty;
            int flg = int.Parse(dataGrid_Ship.Rows[dataGrid_Ship.CurrentRow.Index].Cells[10].Value.ToString());
            if (flg == 0)
            {
                CheckBox_ShipHidden.Checked = false;
            }
            else
            {
                CheckBox_ShipHidden.Checked = true;
            }
        }
    }
}
