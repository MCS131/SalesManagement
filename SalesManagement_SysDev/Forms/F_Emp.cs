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
    public partial class F_Emp : Form
    {
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        PositionDataAccess positionDataAccess = new PositionDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の社員データ
        private static List<MEmployeeDsp> Emp;
        private static List<MSalesOfficeDsp> SaleOffice;
        private static List<MPositionDsp> Position;

        //名前・権限・日付設定
        internal static string HiddenReason = "";
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Emp()
        {
            InitializeComponent();
        }
        private void F_Emp_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_EmLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Emkengenmei.Text = "権限名：" + kengenmei;
            lbl_EmDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

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
            if (kengenmei == "物流" || kengenmei == "営業")
            {
                btn_EmAdd.Enabled = flg;
                btn_EmUpdate.Enabled = flg;
                CheckBox_EmHidden.Enabled = flg;
            }
        }

        private void btn_EmAdd_Click(object sender, EventArgs e)
        {
            //3.1 社員情報を登録
            if (!GetValidDataAtRegistration())
                return;
            var regCustomer = GenerateDataAtRegistration();
            RegistrationEmp(regCustomer);
        }
        ///////////////////////////////
        //          社員情報を得る
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            // 社員IDの適否
            if (!String.IsNullOrEmpty(txb_EmEmpID.Text.Trim()))
            {
                // 社員IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_EmEmpID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (txb_EmEmpID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmEmpID.Focus();
                return false;
            }

            //社員名の適否
            if (!String.IsNullOrEmpty(txb_EmEmpName.Text.Trim()))
            {
                // 社員名の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_EmEmpName.Text.Trim()))
                {
                    MessageBox.Show("社員名は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (txb_EmEmpName.TextLength > 50)
                {
                    MessageBox.Show("社員名は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpName.Focus();
                    return false;
                }
                // 社員名の存在チェック
                if (empDataAccess.CheckEmpNameCDExistence(txb_EmEmpName.Text.Trim()))
                {
                    MessageBox.Show("入力された社員名はすでに存在しています", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員名が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmEmpName.Focus();
                return false;
            }

            // 営業所IDの適否
            if (!String.IsNullOrEmpty(txb_EmSalesOffice.Text.Trim()))
            {
                // 営業所IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_EmSalesOffice.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (txb_EmSalesOffice.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!empDataAccess.CheckSoIdCDExistence(int.Parse(txb_EmSalesOffice.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmSalesOffice.Focus();
                return false;
            }

            // 役職IDの適否
            if (!String.IsNullOrEmpty(txb_EmPosition.Text.Trim()))
            {
                // 役職IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_EmPosition.Text.Trim()))
                {
                    MessageBox.Show("役職IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPosition.Focus();
                    return false;
                }
                // 役職IDの文字数チェック
                if (txb_EmSalesOffice.TextLength > 2)
                {
                    MessageBox.Show("役職IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!empDataAccess.CheckPoIdCDExistence(int.Parse(txb_EmPosition.Text.Trim())))
                {
                    MessageBox.Show("入力された役職IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPosition.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("役職IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmPosition.Focus();
                return false;
            }
            //パスワードの適否
            if (!String.IsNullOrEmpty(txb_EmPassword.Text.Trim()))
            {
                if (txb_EmPassword.Text.Length > 10)
                {
                    MessageBox.Show("パスワードは10文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPassword.Focus();
                    return false;
                }
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(txb_EmPhoneNum.Text.Trim()))
            {
                // 電話番号の数字とハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_EmPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("電話番号は数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (txb_EmPhoneNum.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
                // 電話番号の重複チェック
                if (empDataAccess.CheckEmphoneCDExistence(txb_EmPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("入力された電話番号は既に存在します", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmPhoneNum.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //          顧客情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：顧客登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private MEmployee GenerateDataAtRegistration()
        {
            int flg = 0;
            if (CheckBox_EmHidden.Checked)
            {
                flg = 2;
            }
            return new MEmployee
            {
                EmId = int.Parse(txb_EmEmpID.Text.Trim()),
                EmName = txb_EmEmpName.Text.Trim(),
                PoId = int.Parse(txb_EmPosition.Text.Trim()),
                SoId = int.Parse(txb_EmSalesOffice.Text.Trim()),
                EmPassword = txb_EmPassword.Text.Trim(),
                EmHiredate = dtp_EmHireDate.Value,
                EmPhone = txb_EmPhoneNum.Text.Trim(),
                EmFlag = flg
            };
        }
        ///////////////////////////////
        //         社員情報登録
        //メソッド名：RegistrationDivision()
        //引　数   ：顧客情報
        //戻り値   ：なし
        //機　能   ：顧客データの登録

        ///////////////////////////////
        private void RegistrationEmp(MEmployee regEmp)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 部署情報の登録
            bool flg = empDataAccess.AddEmpData(regEmp);
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
            txb_EmEmpID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void btn_EmpFormShow_Click(object sender, EventArgs e)
        {
            //フォームの表示
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_EmSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_EmSelectForm.Items.Clear();
            this.Hide();
        }
        private void btn_EmpBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_EmSelectForm.Items.Clear();
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
                cmb_EmSelectForm.Items.Add("顧客管理画面");
                cmb_EmSelectForm.Items.Add("商品管理画面");
                cmb_EmSelectForm.Items.Add("在庫管理画面");
                cmb_EmSelectForm.Items.Add("受注管理画面");
                cmb_EmSelectForm.Items.Add("注文管理画面");
                cmb_EmSelectForm.Items.Add("入庫管理画面");
                cmb_EmSelectForm.Items.Add("出庫管理画面");
                cmb_EmSelectForm.Items.Add("入荷管理画面");
                cmb_EmSelectForm.Items.Add("出荷管理画面");
                cmb_EmSelectForm.Items.Add("売上管理画面");
                cmb_EmSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_EmSelectForm.Items.Add("商品管理画面");
                cmb_EmSelectForm.Items.Add("在庫管理画面");
                cmb_EmSelectForm.Items.Add("入庫管理画面");
                cmb_EmSelectForm.Items.Add("出庫管理画面");
                cmb_EmSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_EmSelectForm.Items.Add("顧客管理画面");
                cmb_EmSelectForm.Items.Add("受注管理画面");
                cmb_EmSelectForm.Items.Add("注文管理画面");
                cmb_EmSelectForm.Items.Add("入荷管理画面");
                cmb_EmSelectForm.Items.Add("出荷管理画面");
                cmb_EmSelectForm.Items.Add("売上管理画面");
            }
        }

        ///////////////////////////////
        //メソッド名：btn_EmChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_EmChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        private void btn_EmUpdate_Click(object sender, EventArgs e)
        {
            // 3.2 社員情報更新
            if (!GetValidDataAtUpdate())
            {
                return;
            }
            var updCategory = GenerateDataAtUpdate();
            UpdateCategory(updCategory);
            ClearInput();
            SetDataGridView();
        }
        ///////////////////////////////
        //　妥当な社員更新データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            if (!String.IsNullOrEmpty(txb_EmEmpID.Text.Trim()))
            {
                if (!empDataAccess.CheckEmpCDExistence(int.Parse(txb_EmEmpID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmEmpID.Focus();
                return false;
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(txb_EmPhoneNum.Text.Trim()))
            {
                // 電話番号の数字とハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_EmPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("電話番号は数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (txb_EmPhoneNum.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
                // 電話番号の重複チェック
                if (!empDataAccess.CheckEmphoneCDExistence(txb_EmPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("入力された電話番号は存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPhoneNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmPhoneNum.Focus();
                return false;
            }

            // 営業所IDの適否
            if (!String.IsNullOrEmpty(txb_EmSalesOffice.Text.Trim()))
            {
                // 営業所IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_EmSalesOffice.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (txb_EmSalesOffice.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!empDataAccess.CheckSoIdCDExistence(int.Parse(txb_EmSalesOffice.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmSalesOffice.Focus();
                return false;
            }

            //社員名の適否
            if (!String.IsNullOrEmpty(txb_EmEmpName.Text.Trim()))
            {
                // 社員名の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_EmEmpName.Text.Trim()))
                {
                    MessageBox.Show("社員名は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (txb_EmEmpName.TextLength > 50)
                {
                    MessageBox.Show("社員名は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員名が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmEmpName.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_EmHidden.Checked)
            {
                if (HiddenReason == "")
                {
                    DialogResult result = MessageBox.Show("非表示理由を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　 顧客更新情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：顧客更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private MEmployee GenerateDataAtUpdate()
        {
            int flg = 0;
            if (CheckBox_EmHidden.Checked)
            {
                flg = 2;
            }
            if (flg == 0)
            {
                HiddenReason = "";
            }
            return new MEmployee
            {
                EmId = int.Parse(txb_EmEmpID.Text.Trim()),
                EmName = txb_EmEmpName.Text.Trim(),
                PoId = int.Parse(txb_EmPosition.Text.Trim()),
                SoId = int.Parse(txb_EmSalesOffice.Text.Trim()),
                EmPassword = txb_EmPassword.Text.Trim(),
                EmHiredate = dtp_EmHireDate.Value,
                EmPhone = txb_EmPhoneNum.Text.Trim(),
                EmFlag = flg,
                EmHidden = HiddenReason
            };
        }
        ///////////////////////////////
        //　 社員情報更新
        //メソッド名：UpdateCategory()
        //引　数   ：社員情報
        //戻り値   ：なし
        //機　能   ：社員情報の更新
        ///////////////////////////////
        private void UpdateCategory(MEmployee updCategory)
        {
            //更新確認メッセージ
            DialogResult result;
            result = MessageBox.Show("更新しますか？", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //社員情報の更新
            bool flg = empDataAccess.UpdateCategoryData(updCategory);
            if (flg == true)
            {
                MessageBox.Show("データを更新しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("データの更新に失敗しました。", "更新失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_EmShowList_Click(object sender, EventArgs e)
        {
            //3.3 社員一覧
            Emp = empDataAccess.GetEmployeeAllData();
            SetDataGridView();

        }
        private void btn_EmSearch_Click(object sender, EventArgs e)
        {
            // 3.4 社員検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                EmpSearch();
            }

        }
        ///////////////////////////////
        //         顧客情報検索
        //メソッド名：CstmrSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客データの検索
        ///////////////////////////////
        private void EmpSearch()
        {
            string empid = txb_EmEmpID.Text.Trim();
            string phonenum = txb_EmPhoneNum.Text.Trim();
            string empname = txb_EmEmpName.Text.Trim();
            string password = txb_EmPassword.Text.Trim();
            string position = txb_EmPosition.Text.Trim();
            string salesoffice = txb_EmSalesOffice.Text.Trim();
            string hiredate = dtp_EmHireDate.Value.ToString();

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
            int soId = -1;
            if (!string.IsNullOrEmpty(salesoffice))
            {
                if (int.TryParse(salesoffice, out int parsedID))
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
            var filterEmp = Emp
                .Where(c =>
                    (empID == -1 || c.EmployeeId == empID) &&
                    (string.IsNullOrEmpty(phonenum) || c.EmPhone.Contains(phonenum)) &&
                    (string.IsNullOrEmpty(empname) || c.EmployeeName.Contains(empname)) &&
                    (soId == -1 || (c.SalesOfficeID == soId)) &&
                    (string.IsNullOrEmpty(password) || c.EmPassward.Contains(password)) &&
                    (string.IsNullOrEmpty(position) || c.PositionID == int.Parse(position))).ToList();

            //画面に表示
            txb_EmPage.Text = "1";
            int pageSize = int.Parse(txb_EmPageSize.Text);
            dataGrid_Em.DataSource = filterEmp;
            lbl_EmPage.Text = "/" + ((int)Math.Ceiling((double)filterEmp.Count / pageSize)) + "ページ";
            dataGrid_Em.Refresh();
        }
        private void btn_CstmrFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_EmSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_EmSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_CstmrBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_EmSelectForm.Items.Clear();
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
            txb_EmEmpID.Text = "";
            txb_EmSalesOffice.Text = "";
            txb_EmSalesOfficeName.Text = "";
            txb_EmEmpName.Text = "";
            txb_EmPhoneNum.Text = "";
            txb_EmPassword.Text = "";
            txb_EmPosition.Text = "";
            txb_EmPositionName.Text = "";
            dtp_EmHireDate.Text = "";
            CheckBox_EmHidden.Checked = false;
            GetDataGridView();
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
            txb_EmPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_EmPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Em.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Em.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Em.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            Emp = empDataAccess.GetEmployeeDspData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：btn_EmFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void btn_EmFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_EmPageSize.Text);
            dataGrid_Em.DataSource = Emp.Take(pageSize).ToList();
        }
        ///////////////////////////////
        //メソッド名：btn_EmPrevPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void btn_EmPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_EmPageSize.Text);
            int pageNo = int.Parse(txb_EmPage.Text) - 2;
            dataGrid_Em.DataSource = Emp.Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
        ///////////////////////////////
        //メソッド名：btn_EmNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void btn_EmNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_EmPageSize.Text);
            int pageNo = int.Parse(txb_EmPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Emp.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Em.DataSource = Emp.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Em.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Emp.Count / (double)pageSize);
            if (pageNo >= lastPage)
                txb_EmPage.Text = lastPage.ToString();
            else
                txb_EmPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：btn_EmLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void btn_EmLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_EmPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Emp.Count / (double)pageSize) - 1;
            dataGrid_Em.DataSource = Emp.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Em.Refresh();
            //ページ番号の設定
            txb_EmPage.Text = (pageNo + 1).ToString();
        }


        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            int pageSize = int.Parse(txb_EmPageSize.Text);
            int pageNo = int.Parse(txb_EmPage.Text) - 1;
            dataGrid_Em.DataSource = Emp.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Em.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Em.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Em.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Em.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            //dataGridViewの総ページ数
            lbl_EmPage.Text = "/" + ((int)Math.Ceiling(Emp.Count / (double)pageSize)) + "ページ";

            dataGrid_Em.Refresh();

        }



        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_EmEmpID.Text) &&
                   string.IsNullOrWhiteSpace(txb_EmEmpName.Text) &&
                   string.IsNullOrWhiteSpace(txb_EmPhoneNum.Text) &&
                   string.IsNullOrWhiteSpace(txb_EmPassword.Text) &&
                   string.IsNullOrWhiteSpace(dtp_EmHireDate.Text) &&
                   string.IsNullOrWhiteSpace(txb_EmPosition.Text) &&
                   string.IsNullOrWhiteSpace(txb_EmSalesOffice.Text);
        }

        private void btn_EmShowSalesOffice_Click(object sender, EventArgs e)
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
                txb_EmSalesOffice.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_EmSalesOfficeName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            SaleOffice = salesOfficeDataAccess.GetSalesOfficeDspData();
            dataGridView.DataSource = SaleOffice;
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

        private void btn_EmShowPosition_Click(object sender, EventArgs e)
        {
            //フォームをダイアログ形式で表示
            Form diarog = new Form
            {
                Text = "役職データ",
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
                txb_EmPosition.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_EmPositionName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            };

            diarog.Controls.Add(dataGridView);
            Position = positionDataAccess.GetPositionDspData();
            dataGridView.DataSource = Position;
            //各列の文字位置の調整
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.Refresh();

            diarog.ShowDialog();
        }

        private void btn_EmInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void dataGrid_Em_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_EmEmpID.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[0].Value.ToString();
            txb_EmEmpName.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[1].Value.ToString();
            txb_EmSalesOffice.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[2].Value.ToString();
            txb_EmSalesOfficeName.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[3].Value.ToString();
            txb_EmPosition.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[4].Value.ToString();
            txb_EmPositionName.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[5].Value.ToString();
            dtp_EmHireDate.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[6].Value.ToString();
            txb_EmPassword.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[7].Value.ToString();
            txb_EmPhoneNum.Text = dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[8].Value.ToString();

            int flg = int.Parse(dataGrid_Em.Rows[dataGrid_Em.CurrentRow.Index].Cells[9].Value.ToString());
            if (flg == 0)
            {
                CheckBox_EmHidden.Checked = false;
            }
            else
            {
                CheckBox_EmHidden.Checked = true;
            }
        }

        private void btn_EmHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_EmHidden.Checked)
            {
                int strid = int.Parse(txb_EmEmpID.Text);
                HiddenReason = ShowHiddenReason(strid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_EmHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int empid)
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
                var Emp = context.MEmployees.Where(c => c.EmId == empid).FirstOrDefault();
                if (Emp != null && !string.IsNullOrEmpty(Emp.EmHidden))
                {
                    HideReason = Emp.EmHidden;
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
        //機　能   ：社員IDの適否
        //　　　　 ：エラーがない場合True
        //         ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidData()
        {
            if (!String.IsNullOrEmpty(txb_EmEmpID.Text.Trim()))
            {
                // 社員IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_EmEmpID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (txb_EmEmpID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
                if (!empDataAccess.CheckEmpCDExistence(int.Parse(txb_EmEmpID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmEmpID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_EmEmpID.Focus();
                return false;
            }
            return true;
        }

        private void txb_EmSalesOffice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_EmSalesOffice.Text))
            {
                if (int.TryParse(txb_EmSalesOffice.Text, out int stockId))
                {
                    GetSoId(int.Parse(txb_EmSalesOffice.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmSalesOffice.Text = string.Empty;
                }
            }
            else
            {
                txb_EmSalesOffice.Text = string.Empty;
                txb_EmSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_EmSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_EmSalesOfficeName.Text = string.Empty;
                }
            }
        }

        private void txb_EmPosition_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_EmPosition.Text))
            {
                if (int.TryParse(txb_EmPosition.Text, out int stockId))
                {
                    GetPoId(int.Parse(txb_EmPosition.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_EmPosition.Text = string.Empty;
                }
            }
            else
            {
                txb_EmPosition.Text = string.Empty;
                txb_EmPositionName.Text = string.Empty;
            }
        }
        private void GetPoId(int poid)
        {
            using (var context = new SalesManagementContext())
            {
                var Position = context.MPositions.FirstOrDefault(x => x.PoId == poid);
                if (Position != null)
                {
                    txb_EmPositionName.Text = Position.PoName;
                }
                else
                {
                    txb_EmPositionName.Text = string.Empty;
                }
            }
        }
    }
}
