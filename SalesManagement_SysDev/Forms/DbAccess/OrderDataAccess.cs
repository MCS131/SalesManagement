using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class OrderDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetOrderData()
        //引　数   ：なし
        //戻り値   ：受注データ
        //機　能   ：受注データの取得
        ///////////////////////////////
        public List<TOrderDsp> GetOrderData()
        {
            List<TOrderDsp> jorder = new List<TOrderDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TOrders
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         where t1.OrFlag != 2
                         select new
                         {
                             t1.OrId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    jorder.Add(new TOrderDsp()
                    {
                        OrderId = t.OrId,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        EmpId = t.EmId,
                        EmpName = t.EmName,
                        ClID = t.ClId,
                        ClName = t.ClName,
                        ClCharge = t.ClCharge,
                        OrDate = t.OrDate.ToString("yyyy / MM / dd"),
                        OrStateFlag = t.OrStateFlag.ToString(),
                        OrFlag = t.OrFlag.ToString(),
                        OrHidden = t.OrHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return jorder;

        }

        ///////////////////////////////
        //メソッド名：GetOrderDspData()
        //引　数   ：なし
        //戻り値   ：表示用発注データ
        //機　能   ：表示用発注データの取得
        ///////////////////////////////
        public List<TOrder> GetOrderDspData()
        {
            List<TOrder> order = null;
            try
            {
                var context = new SalesManagementContext();
                order = context.TOrders.Where(x => x.OrFlag == 0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return order;
        }
        ///////////////////////////////
        //メソッド名：GetOrderAllData() 
        //引　数   ：なし
        //戻り値   ：一覧表示用受注データ
        //機　能   ：一覧表示用受注データの取得
        ///////////////////////////////
        public List<TOrderDsp> GetOrderAllData()
        {
            List<TOrderDsp> order = new List<TOrderDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TOrders
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         select new
                         {
                             t1.OrId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    order.Add(new TOrderDsp()
                    {
                        OrderId = t.OrId,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.EmName,
                        EmpId = t.EmId,
                        EmpName = t.ClName,
                        ClID = t.ClId,
                        ClName = t.ClName,
                        ClCharge = t.ClCharge,
                        OrDate = t.OrDate.ToString("yyyy / MM / dd"),
                        OrStateFlag = t.OrStateFlag.ToString(),
                        OrFlag = t.OrFlag.ToString(),
                        OrHidden = t.OrHidden,
                    });
                        
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return order;
        }
        ///////////////////////////////
        //メソッド名：CheckJOrderIDCDExistence()
        //引　数   ：受注ID
        //戻り値   ：True or False
        //機　能   ：一致する受注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckJOrderCDExistence(int jorderid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //受注IDで一致するデータが存在するか
                flg = context.TOrders.Any(x => x.OrId == jorderid);
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
                flg = context.MSalesOffices.Any(x => x.SoId == soid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckEmpIdCDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致する社員IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmpCDExistence(int empId)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.EmId == empId);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckCstmrIdCDExistence()
        //引　数   ：顧客ID
        //戻り値   ：True or False
        //機　能   ：一致する顧客IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckCstmrCDExistence(int cstmrId)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.MClients.Any(x => x.ClId == cstmrId);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckProductIDCDExistence()
        //引　数   ：商品ID
        //戻り値   ：True or False
        //機　能   ：一致する商品IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckProductIDCDExistence(int productid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //営業所IDで一致するデータが存在するか
                flg = context.MProducts.Any(x => x.PrId == productid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddJOrderData()
        //引　数   ：受注データ
        //戻り値   ：True or False
        //機　能   ：受注データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddJOrderData(TOrder regJOrder)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TOrders.Add(regJOrder);
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
        //メソッド名：ChangeStateFlgData()
        //引　数   ：受注状態フラグ変更データ
        //戻り値   ：True or False
        //機　能   ：受注状態フラグデータの変更
        ///////////////////////////////
        //public bool ChangeStateFlgData(int jorderid)
        //{
        //    try
        //    {
        //        var context = new SalesManagementContext();
        //        var stateflg = context.TOrders.Select(x => x.OrId == jorderid).FirstOrDefault();
        //        context.TOrders.Update()
        //        context.SaveChanges();
        //        context.Dispose();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}
        
    }
}
