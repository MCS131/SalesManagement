using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.Forms.DbAccess;
using SalesManagement_SysDev.Context;
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
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using SalesManagement_SysDev.Forms;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class F_Customer : Form
    {
        //データベースアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        //データグリッドビュー用の顧客データ
        private static List<MClientDsp> Client;
        private static List<MSalesOfficeDsp> SaleOffice;

        internal static string HiddenReason = "";
        //名前・権限・日付設定
        internal static string loginName = "";
        internal static string kengenmei = "";
        internal static DateTime loginTime = DateTime.Now;
        public F_Customer()
        {
            InitializeComponent();
        }
        private void F_Customer_Load(object sender, EventArgs e)
        {
            //ログイン名・権限名・日付表示
            lbl_CstmrLoginuser.Text = "ログインユーザー：" + loginName;
            lbl_Cstmrkengenmei.Text = "権限名：" + kengenmei;
            lbl_CstmrDate.Text = "日付：" + loginTime.ToString("yyyy/MM/dd");

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
                btn_CstmrAdd.Enabled = flg;
                btn_CstmrAppdate.Enabled = flg;
                CheckBox_CstmrHidden.Enabled = flg;
            }

        }
        private void btn_CstmrAdd_Click(object sender, EventArgs e)
        {
            //3.1 顧客情報を登録
            if (!GetValidDataAtRegistration())
                return;
            var regCustomer = GenerateDataAtRegistration();
            RegistrationClient(regCustomer);
        }

        ///////////////////////////////
        //          顧客情報を得る
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            // 電話番号の適否
            if (!String.IsNullOrEmpty(txb_CstmrPhoneNum.Text.Trim()))
            {
                // 電話番号の数字とハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_CstmrPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("電話番号は数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (txb_CstmrPhoneNum.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
                // 電話番号の重複チェック
                if (clientDataAccess.CheckClphoneCDExistence(txb_CstmrPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("入力された電話番号は既に存在します", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrPhoneNum.Focus();
                return false;
            }

            // FAXの適否
            if (!String.IsNullOrEmpty(txb_CstmrFax.Text.Trim()))
            {
                // FAXの数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_CstmrFax.Text.Trim()))
                {
                    MessageBox.Show("FAXは数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (txb_CstmrFax.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
                // FAXの重複チェック
                if (clientDataAccess.CheckClphoneCDExistence(txb_CstmrFax.Text.Trim()))
                {
                    MessageBox.Show("入力されたFAXは既に存在します", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("FAXが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrFax.Focus();
                return false;
            }

            // 営業所IDの適否
            if (!String.IsNullOrEmpty(txb_CstmrSalesOfficeID.Text.Trim()))
            {
                // 営業所IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_CstmrSalesOfficeID.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (txb_CstmrSalesOfficeID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!clientDataAccess.CheckSoIdCDExistence(int.Parse(txb_CstmrSalesOfficeID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrSalesOfficeID.Focus();
                return false;
            }

            //顧客名の適否
            if (!String.IsNullOrEmpty(txb_CstmrName.Text.Trim()))
            {
                // 顧客名の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_CstmrName.Text.Trim()))
                {
                    MessageBox.Show("顧客名は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrName.Focus();
                    return false;
                }
                // 顧客名の文字数チェック
                if (txb_CstmrName.TextLength > 50)
                {
                    MessageBox.Show("顧客名は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrName.Focus();
                    return false;
                }
                // 顧客名の存在チェック
                if (clientDataAccess.CheckCstmrNameCDExistence(txb_CstmrName.Text.Trim()))
                {
                    MessageBox.Show("入力された顧客名はすでに存在しています", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客名が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrName.Focus();
                return false;
            }

            // 郵便番号の適否
            if (!String.IsNullOrEmpty(txb_CstmrPostNum.Text.Trim()))
            {
                // 郵便番号の数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_CstmrPostNum.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPostNum.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (txb_CstmrPostNum.TextLength != 7)
                {
                    MessageBox.Show("郵便番号は7文字です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPostNum.Focus();
                    return false;
                }
                // 郵便番号の存在チェック
                if (clientDataAccess.CheckPostalCDExistence(txb_CstmrPostNum.Text.Trim()))
                {
                    MessageBox.Show("入力された郵便番号はすでに存在しています", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPostNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("郵便番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrPostNum.Focus();
                return false;
            }

            // 住所の適否
            if (!String.IsNullOrEmpty(txb_CstmrAddr.Text.Trim()))
            {
                // 住所の文字数チェック
                if (txb_CstmrAddr.TextLength > 50)
                {
                    MessageBox.Show("住所は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrAddr.Focus();
                    return false;
                }
                // 住所の存在チェック
                if (clientDataAccess.CheckaddrCDExistence(txb_CstmrAddr.Text.Trim()))
                {
                    MessageBox.Show("入力された住所はすでに存在しています", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrAddr.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("住所が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrAddr.Focus();
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
        private MClient GenerateDataAtRegistration()
        {
            int flg = 0;
            if (CheckBox_CstmrHidden.Checked)
            {
                flg = 2;
            }
            return new MClient
            {
                SoId = int.Parse(txb_CstmrSalesOfficeID.Text.Trim()),
                ClName = txb_CstmrName.Text.Trim(),
                ClAddress = txb_CstmrAddr.Text.Trim(),
                ClPhone = txb_CstmrPhoneNum.Text.Trim(),
                ClPostal = txb_CstmrPostNum.Text.Trim(),
                ClFax = txb_CstmrFax.Text.Trim(),
                ClFlag = flg,
            };
        }

        ///////////////////////////////
        //         顧客情報登録
        //メソッド名：RegistrationClient()
        //引　数   ：顧客情報
        //戻り値   ：なし
        //機　能   ：顧客データの登録
        ///////////////////////////////
        private void RegistrationClient(MClient regClient)
        {
            // 登録確認メッセージ
            DialogResult result;
            result = MessageBox.Show("登録しますか？", "登録確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 部署情報の登録
            bool flg = clientDataAccess.AddClientData(regClient);
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
            txb_CstmrID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void btn_CstmrAppdate_Click(object sender, EventArgs e)
        {
            // 3.2 顧客情報更新
            if (!GetValidDataAtUpdate())
            {
                return;
            }
            var updClient = GenerateDataAtUpdate();
            UpdateClient(updClient);
            ClearInput();
            SetDataGridView();
        }
        ///////////////////////////////
        //　妥当な顧客更新データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //顧客IDの存在チェック
            if (!String.IsNullOrEmpty(txb_CstmrID.Text.Trim()))
            {
                if (!clientDataAccess.CheckClIdCDExistence(int.Parse(txb_CstmrID.Text.Trim())))
                {
                    MessageBox.Show("入力された顧客IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrSalesOfficeID.Focus();
                return false;
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(txb_CstmrPhoneNum.Text.Trim()))
            {
                // 電話番号の数字とハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_CstmrPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("電話番号は数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (txb_CstmrPhoneNum.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
                // 電話番号の重複チェック
                if (!clientDataAccess.CheckClphoneCDExistence(txb_CstmrPhoneNum.Text.Trim()))
                {
                    MessageBox.Show("入力された電話番号は存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPhoneNum.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrPhoneNum.Focus();
                return false;
            }

            // FAXの適否
            if (!String.IsNullOrEmpty(txb_CstmrFax.Text.Trim()))
            {
                // FAXの数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(txb_CstmrFax.Text.Trim()))
                {
                    MessageBox.Show("FAXは数字と-を入力してください", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (txb_CstmrFax.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
                // FAXの重複チェック
                if (!clientDataAccess.CheckClFaxCDExistence(txb_CstmrFax.Text.Trim()))
                {
                    MessageBox.Show("入力されたFAXは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrFax.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("FAXが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrFax.Focus();
                return false;
            }

            // 営業所IDの適否
            if (!String.IsNullOrEmpty(txb_CstmrSalesOfficeID.Text.Trim()))
            {
                // 営業所IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_CstmrSalesOfficeID.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (txb_CstmrSalesOfficeID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!clientDataAccess.CheckSoIdCDExistence(int.Parse(txb_CstmrSalesOfficeID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrSalesOfficeID.Focus();
                return false;
            }
            //顧客名の適否
            if (!String.IsNullOrEmpty(txb_CstmrName.Text.Trim()))
            {
                // 顧客名の数字チェック
                if (!dataInputFormCheck.CheckFullWidth(txb_CstmrName.Text.Trim()))
                {
                    MessageBox.Show("顧客名は全て全角入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrName.Focus();
                    return false;
                }
                // 顧客名の文字数チェック
                if (txb_CstmrName.TextLength > 50)
                {
                    MessageBox.Show("顧客名は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客名が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrName.Focus();
                return false;
            }

            // 郵便番号の適否
            if (!String.IsNullOrEmpty(txb_CstmrPostNum.Text.Trim()))
            {
                // 郵便番号の数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_CstmrPostNum.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPostNum.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (txb_CstmrPostNum.TextLength != 7)
                {
                    MessageBox.Show("郵便番号は7文字です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrPostNum.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("郵便番号が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrPostNum.Focus();
                return false;
            }

            // 住所の適否
            if (!String.IsNullOrEmpty(txb_CstmrAddr.Text.Trim()))
            {
                // 住所の文字数チェック
                if (txb_CstmrAddr.TextLength > 50)
                {
                    MessageBox.Show("住所は50文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrAddr.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("住所が入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrAddr.Focus();
                return false;
            }
            //チェックボックスがチェックありの時非表示理由を入力しているかチェック
            if (CheckBox_CstmrHidden.Checked)
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
        //　 顧客更新情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：顧客更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private MClient GenerateDataAtUpdate()
        {
            int flg = 0;
            if (CheckBox_CstmrHidden.Checked)
            {
                flg = 2;
            }
            return new MClient
            {
                ClId = int.Parse(txb_CstmrID.Text.Trim()),
                ClPhone = txb_CstmrPhoneNum.Text.Trim(),
                ClFax = txb_CstmrFax.Text.Trim(),
                SoId = int.Parse(txb_CstmrSalesOfficeID.Text.Trim()),
                ClName = txb_CstmrName.Text.Trim(),
                ClAddress = txb_CstmrAddr.Text.Trim(),
                ClPostal = txb_CstmrPostNum.Text.Trim(),
                ClFlag = flg,
                ClHidden = HiddenReason
            };
        }
        ///////////////////////////////
        //　 顧客情報更新
        //メソッド名：UpdateClient()
        //引　数   ：顧客情報
        //戻り値   ：
        //機　能   ：顧客情報の更新
        ///////////////////////////////
        private void UpdateClient(MClient updClient)
        {
            //更新確認メッセージ
            DialogResult result;
            result = MessageBox.Show("更新しますか？", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //顧客情報の更新
            bool flg = clientDataAccess.UpdateClientData(updClient);
            if (flg == true)
            {
                MessageBox.Show("データを更新しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("データの更新に失敗しました。", "更新失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CstmrShowList_Click(object sender, EventArgs e)
        {
            //3.3 顧客一覧
            Client = clientDataAccess.GetClientAllData();
            SetDataGridView();

        }

        private void btn_CstmrSearch_Click(object sender, EventArgs e)
        {
            // 3.4 顧客検索
            if (CheckAllTextBoxesFilled() == true)
            {
                SetFormDataGridView();
            }
            else
            {
                CstmrSearch();
            }

        }
        ///////////////////////////////
        //         顧客情報検索
        //メソッド名：CstmrSearch()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客データの検索
        ///////////////////////////////
        private void CstmrSearch()
        {
            int flg = 0;
            if (CheckBox_CstmrHidden.Checked)
            {
                flg = 2;
            }

            string cstmrid = txb_CstmrID.Text.Trim();
            string phonenum = txb_CstmrPhoneNum.Text.Trim();
            string fax = txb_CstmrFax.Text.Trim();
            string officeid = txb_CstmrSalesOfficeID.Text.Trim();
            string cstmrname = txb_CstmrName.Text.Trim();
            string post = txb_CstmrPostNum.Text.Trim();
            string addr = txb_CstmrAddr.Text.Trim();

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
            var filterCstmr = Client
                .Where(c =>
                (customerID == -1 || c.ClientId == customerID) &&
                (string.IsNullOrEmpty(phonenum) || c.ClientPhone.Contains(phonenum)) &&
                (string.IsNullOrEmpty(fax) || c.ClientFax.Contains(fax)) &&
                (soId == -1 || (c.SalesOfficeID == soId)) &&
                (string.IsNullOrEmpty(cstmrname) || c.ClientName.Contains(cstmrname)) &&
                (string.IsNullOrEmpty(post) || c.ClientPostal.Contains(post)) &&
                (string.IsNullOrEmpty(addr) || c.ClientAddress.Contains(addr))).ToList();
            //検索結果があった場合画面に表示　無かった場合エラーメッセージを表示
            if (!filterCstmr.Any())
            {
                MessageBox.Show("検索結果が見つかりませんでした", "検索失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //画面に表示
                txb_CstmrPage.Text = "1";
                int pageSize = int.Parse(txb_CstmrPageSize.Text);
                dataGrid_Cstmr.DataSource = filterCstmr;
                lbl_CstmrPage.Text = "/" + ((int)Math.Ceiling(filterCstmr.Count / (double)pageSize)) + "ページ";
                dataGrid_Cstmr.Refresh();

            }
        }
        private void btn_CstmrFormShow_Click(object sender, EventArgs e)
        {
            //---フォームの表示---
            SelectForm selectForm = new SelectForm();
            string frmname = cmb_CstmrSelectForm.Text;
            selectForm.OpenForm(frmname);
            cmb_CstmrSelectForm.Items.Clear();
            this.Hide();
        }

        private void btn_CstmrBack_Click(object sender, EventArgs e)
        {
            //戻るボタン
            cmb_CstmrSelectForm.Items.Clear();
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
            txb_CstmrID.Text = "";
            txb_CstmrSalesOfficeID.Text = "";
            txb_CstmrSalesOfficeName.Text = "";
            txb_CstmrName.Text = "";
            txb_CstmrPostNum.Text = "";
            txb_CstmrAddr.Text = "";
            txb_CstmrFax.Text = "";
            txb_CstmrPhoneNum.Text = "";
            CheckBox_CstmrHidden.Checked = false;
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
            txb_CstmrPageSize.Text = "10";
            //dataGridViewのページ番号指定
            txb_CstmrPage.Text = "1";
            //読み取り専用に指定
            dataGrid_Cstmr.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGrid_Cstmr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGrid_Cstmr.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            Client = clientDataAccess.GetClientData();

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
            int pageSize = int.Parse(txb_CstmrPageSize.Text);
            int pageNo = int.Parse(txb_CstmrPage.Text) - 1;
            dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGrid_Cstmr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid_Cstmr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            dataGrid_Cstmr.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrid_Cstmr.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            lbl_CstmrPage.Text = "/" + ((int)Math.Ceiling(Client.Count / (double)pageSize)) + "ページ";

            dataGrid_Cstmr.Refresh();

        }


        ///////////////////////////////
        //メソッド名：btn_CstmrFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void btn_CstmrFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_CstmrPageSize.Text);
            dataGrid_Cstmr.DataSource = Client.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Cstmr.Refresh();
            //ページ番号の設定
            txb_CstmrPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrPrevPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void btn_CstmrPrevPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_CstmrPageSize.Text);
            int pageNo = int.Parse(txb_CstmrPage.Text) - 2;
            dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Cstmr.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
            {
                txb_CstmrPage.Text = (pageNo + 1).ToString();
            }
            else
            {
                txb_CstmrPage.Text = "1";
            }
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void btn_CstmrNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_CstmrPageSize.Text);
            int pageNo = int.Parse(txb_CstmrPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Cstmr.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Client.Count / (double)pageSize);
            if (pageNo >= lastPage)
            {
                txb_CstmrPage.Text = lastPage.ToString();
            }
            else
            {
                txb_CstmrPage.Text = (pageNo + 1).ToString();
            }
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void btn_CstmrLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(txb_CstmrPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            dataGrid_Cstmr.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGrid_Cstmr.Refresh();
            //ページ番号の設定
            txb_CstmrPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：btn_CstmrChangeSize_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void btn_CstmrChangeSize_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void dataGrid_Cstmr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            txb_CstmrID.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[0].Value.ToString();
            txb_CstmrName.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[1].Value.ToString();
            txb_CstmrSalesOfficeID.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[2].Value.ToString();
            txb_CstmrAddr.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[3].Value.ToString();
            txb_CstmrSalesOfficeName.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[4].Value.ToString();
            txb_CstmrPhoneNum.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[5].Value.ToString();
            txb_CstmrPostNum.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[6].Value.ToString();
            txb_CstmrFax.Text = dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[7].Value.ToString();

            int flg = int.Parse(dataGrid_Cstmr.Rows[dataGrid_Cstmr.CurrentRow.Index].Cells[8].Value.ToString());
            if (flg == 0)
            {
                CheckBox_CstmrHidden.Checked = false;
            }
            else
            {
                CheckBox_CstmrHidden.Checked = true;
            }
        }
        private bool CheckAllTextBoxesFilled()
        {
            return string.IsNullOrWhiteSpace(txb_CstmrID.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrPhoneNum.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrFax.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrSalesOfficeID.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrName.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrPostNum.Text) &&
                   string.IsNullOrWhiteSpace(txb_CstmrAddr.Text);
        }

        private void btn_CstmrHiddenReason_Click(object sender, EventArgs e)
        {
            if (!GetValidData())
            {
                return;
            }
            if (CheckBox_CstmrHidden.Checked)
            {
                int cstmrid = int.Parse(txb_CstmrID.Text);
                HiddenReason = ShowHiddenReason(cstmrid);
            }
            else
            {
                MessageBox.Show("チェックボックスをチェックしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBox_CstmrHidden.Focus();
            }
        }
        private static string ShowHiddenReason(int cstmrid)
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
                var customer = context.MClients.Where(c => c.ClId == cstmrid).FirstOrDefault();
                if (customer != null && !string.IsNullOrEmpty(customer.ClHidden))
                {
                    HideReason = customer.ClHidden;
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
            if (!String.IsNullOrEmpty(txb_CstmrID.Text.Trim()))
            {
                // 顧客IDの数字チェック
                if (!dataInputFormCheck.CheckNumeric(txb_CstmrID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは全て数字入力です", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrID.Focus();
                    return false;
                }
                // 顧客IDの文字数チェック
                if (txb_CstmrID.TextLength > 2)
                {
                    MessageBox.Show("顧客IDは2文字までです", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrID.Focus();
                    return false;
                }
                if (!clientDataAccess.CheckClIdCDExistence(int.Parse(txb_CstmrID.Text.Trim())))
                {
                    MessageBox.Show("入力された顧客IDは存在していません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客IDが入力されていません", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_CstmrID.Focus();
                return false;
            }
            return true;
        }
        private void cmb_boxAddItem(string kengen)
        {
            //comboboxにアイテムを追加
            if (kengen == "管理者")
            {
                cmb_CstmrSelectForm.Items.Add("商品管理画面");
                cmb_CstmrSelectForm.Items.Add("在庫管理画面");
                cmb_CstmrSelectForm.Items.Add("社員管理画面");
                cmb_CstmrSelectForm.Items.Add("受注管理画面");
                cmb_CstmrSelectForm.Items.Add("注文管理画面");
                cmb_CstmrSelectForm.Items.Add("入庫管理画面");
                cmb_CstmrSelectForm.Items.Add("出庫管理画面");
                cmb_CstmrSelectForm.Items.Add("入荷管理画面");
                cmb_CstmrSelectForm.Items.Add("出荷管理画面");
                cmb_CstmrSelectForm.Items.Add("売上管理画面");
                cmb_CstmrSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "物流")
            {
                cmb_CstmrSelectForm.Items.Add("商品管理画面");
                cmb_CstmrSelectForm.Items.Add("在庫管理画面");
                cmb_CstmrSelectForm.Items.Add("入庫管理画面");
                cmb_CstmrSelectForm.Items.Add("出庫管理画面");
                cmb_CstmrSelectForm.Items.Add("発注管理画面");
            }
            else if (kengen == "営業")
            {
                cmb_CstmrSelectForm.Items.Add("受注管理画面");
                cmb_CstmrSelectForm.Items.Add("注文管理画面");
                cmb_CstmrSelectForm.Items.Add("入荷管理画面");
                cmb_CstmrSelectForm.Items.Add("出荷管理画面");
                cmb_CstmrSelectForm.Items.Add("売上管理画面");
            }
        }

        private void btn_CstmrShowSalesOffice_Click(object sender, EventArgs e)
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
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            //データグリッドをダブルクリックするとテクストボックスに表示
            dataGridView.CellDoubleClick += (s, e) =>
            {
                txb_CstmrSalesOfficeID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[0].Value.ToString();
                txb_CstmrSalesOfficeName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[1].Value.ToString();
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

        private void btn_CstmrInputClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void txb_CstmrID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_CstmrSalesOfficeID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_CstmrSalesOfficeID.Text))
            {
                if (int.TryParse(txb_CstmrSalesOfficeID.Text, out int stockId))
                {
                    GetSoId(int.Parse(txb_CstmrSalesOfficeID.Text));
                }
                else
                {
                    MessageBox.Show("数値を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txb_CstmrSalesOfficeID.Text = string.Empty;
                }
            }
            else
            {
                txb_CstmrSalesOfficeID.Text = string.Empty;
                txb_CstmrSalesOfficeName.Text = string.Empty;
            }
        }
        private void GetSoId(int soid)
        {
            using (var context = new SalesManagementContext())
            {
                var SalesOffice = context.MSalesOffices.FirstOrDefault(x => x.SoId == soid);
                if (SalesOffice != null)
                {
                    txb_CstmrSalesOfficeName.Text = SalesOffice.SoName;
                }
                else
                {
                    txb_CstmrSalesOfficeID.Text = string.Empty;
                }
            }
        }
    }
}
