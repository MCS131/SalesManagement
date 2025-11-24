using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SaleDataAccess
    {

        ///////////////////////////////
        //メソッド名：CheckSaIdCDExistence()
        //引　数   ：売上ID
        //戻り値   ：True or False
        //機　能   ：一致する売上IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSaIdCDExistence(int said)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //営業所IDで一致するデータが存在するか
                flg = context.TSales.Any(x => x.SaId == said);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckSaIdCDExistence()
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
                flg = context.TSales.Any(x => x.ClId == clid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckSaIdCDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致する社員IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmIdCDExistence(int emid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.TSales.Any(x => x.EmId == emid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckSaIdCDExistence()
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
                flg = context.TSales.Any(x => x.SoId == soid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckSaIdCDExistence()
        //引　数   ：受注ID
        //戻り値   ：True or False
        //機　能   ：一致する受注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckOrIdCDExistence(int orid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //受注IDで一致するデータが存在するか
                flg = context.TSales.Any(x => x.OrId == orid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }



        ///////////////////////////////
        //メソッド名：GetSaleData()
        //引　数   ：なし
        //戻り値   ：売上データ
        //機　能   ：売上データの取得
        ///////////////////////////////
        public List<TSale> GetSaleData()
        {
            List<TSale> sale = null;
            try
            {
                var context = new SalesManagementContext();
                sale = context.TSales.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sale;
        }

        ///////////////////////////////
        //メソッド名：GetSaleDspData()
        //引　数   ：なし
        //戻り値   ：表示用売上データ
        //機　能   ：表示用売上データの取得
        ///////////////////////////////
        public List<TSaleDsp> GetSaleDspData()
        {
            List<TSaleDsp> sales = new List<TSaleDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TSales
                         join t2 in context.MClients
                         on t1.ClId equals t2.ClId
                         join t3 in context.MSalesOffices
                         on t1.SoId equals t3.SoId
                         join t4 in context.TOrders
                         on t1.OrId equals t4.OrId
                         join t5 in context.MEmployees
                         on t1.EmId equals t5.EmId
                         where t1.SaFlag != 2
                         select new
                         {
                             t1.SaId,
                             t1.ClId,
                             t2.ClName,
                             t1.SoId,
                             t3.SoName,
                             t1.EmId,
                             t5.EmName,
                             t1.OrId,
                             t1.SaDate,
                             t1.SaFlag,
                             t1.SaHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    sales.Add(new TSaleDsp()
                    {
                        SalesID = t.SaId,
                        ClientID = t.ClId,
                        ClName = t.ClName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        EmpID = t.EmId,
                        EmpName = t.EmName,
                        JOrderID = t.OrId,
                        SaDate = t.SaDate,
                        SalesFlag = t.SaFlag,
                        SalesHidden = t.SaHidden
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sales;
        }

        ///////////////////////////////
        //メソッド名：GetSaleAllData()
        //引　数   ：なし
        //戻り値   ：表示用売上データ
        //機　能   ：表示用売上データの取得
        ///////////////////////////////
        public List<TSaleDsp> GetSaleAllData()
        {
            List<TSaleDsp> sales = new List<TSaleDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TSales
                         join t2 in context.MClients
                         on t1.ClId equals t2.ClId
                         join t3 in context.MSalesOffices
                         on t1.SoId equals t3.SoId
                         join t4 in context.TOrders
                         on t1.OrId equals t4.OrId
                         join t5 in context.MEmployees
                         on t1.EmId equals t5.EmId
                         select new
                         {
                             t1.SaId,
                             t1.ClId,
                             t2.ClName,
                             t1.SoId,
                             t3.SoName,
                             t1.EmId,
                             t5.EmName,
                             t1.OrId,
                             t1.SaDate,
                             t1.SaFlag,
                             t1.SaHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    sales.Add(new TSaleDsp()
                    {
                        SalesID = t.SaId,
                        ClientID = t.ClId,
                        ClName = t.ClName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.EmName,
                        EmpID = t.EmId,
                        EmpName = t.EmName,
                        JOrderID = t.OrId,
                        SaDate = t.SaDate,
                        SalesFlag = t.SaFlag,
                        SalesHidden = t.SaHidden
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sales;
        }

        ///////////////////////////////
        //メソッド名：UpdateSalesData()
        //引　数   ：売上データ
        //戻り値   ：True or False
        //機　能   ：売上データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateSalesData(TSale updSales)
        {
            try
            {
                var context = new SalesManagementContext();
                var sales = context.TSales.Single(x => x.SaId == updSales.SaId);
                sales.ClId = updSales.ClId;
                sales.OrId = updSales.OrId;
                sales.EmId = updSales.EmId;
                sales.SoId = updSales.SoId;
                sales.SaFlag = updSales.SaFlag;
                sales.SaHidden = updSales.SaHidden;
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
        //メソッド名：AddSaleData()
        //引　数   ：売上データ
        //戻り値   ：True or False
        //機　能   ：売上データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSaleData(TSale regSale)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TSales.Add(regSale);
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
