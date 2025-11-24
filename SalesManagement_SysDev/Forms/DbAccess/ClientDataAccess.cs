using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ClientDataAccess    {
        ///////////////////////////////
        //メソッド名：CheckClIdCDExistence()
        //引　数   ：顧客ID
        //戻り値   ：True or False
        //機　能   ：一致する顧客IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckClIdCDExistence(int clid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //顧客IDで一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClId == clid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckSoIdCDExistence()
        //引　数   ：営業所ID
        //戻り値   ：True or False
        //機　能   ：一致する営業所IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSoIdCDExistence(int soid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //営業所IDで一致するデータが存在するか
                flg = context.MClients.Any(x => x.SoId == soid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckPostalCDExistence()
        //引　数   ：郵便番号
        //戻り値   ：True or False
        //機　能   ：一致する郵便番号の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPostalCDExistence(string postal)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //郵便番号で一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClPostal == postal);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckCstmrNameCDExistence()
        //引　数   ：顧客名
        //戻り値   ：True or False
        //機　能   ：一致する顧客名の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckCstmrNameCDExistence(string cstmrname)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //顧客名で一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClName == cstmrname);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckClphoneCDExistence()
        //引　数   ：電話番号
        //戻り値   ：True or False
        //機　能   ：一致する電話番号の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckClphoneCDExistence(string Clphone)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //電話番号で一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClPhone == Clphone);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckClFaxCDExistence()
        //引　数   ：Fax
        //戻り値   ：True or False
        //機　能   ：一致するFAXの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckClFaxCDExistence(string ClFax)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //Faxで一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClFax == ClFax);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckaddrCDExistence()
        //引　数   ：住所
        //戻り値   ：True or False
        //機　能   ：一致する住所の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckaddrCDExistence(string Addr)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //住所で一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClAddress == Addr);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetClientData()
        //引　数   ：なし
        //戻り値   ：顧客データ
        //機　能   ：顧客データの取得
        ///////////////////////////////
        public List<MClientDsp> GetClientData()
        {
            List<MClientDsp> client = new List<MClientDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MClients
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         where t1.ClFlag != 2
                         select new
                         {
                             t1.ClId,
                             t1.ClName,
                             t1.SoId,
                             t2.SoName,
                             t1.ClAddress,
                             t1.ClPhone,
                             t1.ClPostal,
                             t1.ClFax,
                             t1.ClFlag,
                             t1.ClHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach( var t in tb)
                {
                    client.Add(new MClientDsp()
                    {
                        ClientId = t.ClId,
                        ClientName = t.ClName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        ClientAddress = t.ClAddress,
                        ClientPhone = t.ClPhone,
                        ClientPostal = t.ClPostal,
                        ClientFax = t.ClFax,
                        ClientFlag = t.ClFlag,
                        ClientHidden = t.ClHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return client;
        }

        ///////////////////////////////
        //メソッド名：GetClientAllData() 
        //引　数   ：なし
        //戻り値   ：一覧表示用顧客データ
        //機　能   ：一覧表示用顧客データの取得
        ///////////////////////////////
        public List<MClientDsp> GetClientAllData()
        {
            List<MClientDsp> client = new List<MClientDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MClients
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         select new
                         {
                             t1.ClId,
                             t1.ClName,
                             t1.SoId,
                             t2.SoName,
                             t1.ClAddress,
                             t1.ClPhone,
                             t1.ClPostal,
                             t1.ClFax,
                             t1.ClFlag,
                             t1.ClHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    client.Add(new MClientDsp()
                    {
                        ClientId = t.ClId,
                        ClientName = t.ClName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        ClientAddress = t.ClAddress,
                        ClientPhone = t.ClPhone,
                        ClientPostal = t.ClPostal,
                        ClientFax = t.ClFax,
                        ClientFlag = t.ClFlag,
                        ClientHidden = t.ClHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return client;
        }
     
        ///////////////////////////////
        //メソッド名：AddClientData()
        //引　数   ：顧客データ
        //戻り値   ：True or False
        //機　能   ：顧客データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddClientData(MClient regClient)
        {
            try
            {
                var context = new SalesManagementContext();
                context.MClients.Add(regClient);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        ///////////////////////////////
        //メソッド名：UpdateClientData()
        //引　数   ：顧客データ
        //戻り値   ：True or False
        //機　能   ：顧客データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateClientData(MClient updCstmr)
        {
            try
            {
                var context = new SalesManagementContext();
                var customer = context.MClients.Single(x => x.ClId == updCstmr.ClId);
                customer.ClPhone = updCstmr.ClPhone;
                customer.ClFax = updCstmr.ClFax;
                customer.SoId = updCstmr.SoId;
                customer.ClName = updCstmr.ClName;
                customer.ClAddress = updCstmr.ClAddress;
                customer.ClPostal = updCstmr.ClPostal;
                customer.ClFlag = updCstmr.ClFlag;
                customer.ClHidden = updCstmr.ClHidden;
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
