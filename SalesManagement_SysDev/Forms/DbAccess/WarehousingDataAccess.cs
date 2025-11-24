using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class WarehousingDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetWarehousingData()
        //引　数   ：なし
        //戻り値   ：入庫データ
        //機　能   ：入庫データの取得
        ///////////////////////////////
        public List<TWarehousingDsp> GetWarehousingData()
        {
            List<TWarehousingDsp> warehousing = new List<TWarehousingDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TWarehousings
                         join t2 in context.MEmployees
                         on t1.EmId equals t2.EmId into t2Group
                         from t2 in t2Group.DefaultIfEmpty()
                         where t1.WaFlag != 2
                         select new
                         {
                             t1.WaId,
                             t1.HaId,
                             t1.EmId,
                             t2.EmName,
                             t1.WaDate,
                             t1.WaShelfFlag,
                             t1.WaFlag,
                             t1.WaHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    warehousing.Add(new TWarehousingDsp()
                    {
                        WaId = t.WaId,
                        HaId = t.HaId,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        WaDate = t.WaDate,
                        WaShelfFlg = t.WaShelfFlag,
                        WaFlag = t.WaFlag,
                        WaHidden = t.WaHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return warehousing;

        }

        ///////////////////////////////
        //メソッド名：GetWarehousingAllData()
        //引　数   ：なし
        //戻り値   ：表示用入庫データ
        //機　能   ：表示用入庫データの取得
        ///////////////////////////////
        public List<TWarehousingDsp> GetWarehousingAllData()
        {
            List<TWarehousingDsp> warehousing = new List<TWarehousingDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TWarehousings
                         join t2 in context.MEmployees
                         on t1.EmId equals t2.EmId into t2Group
                         from t2 in t2Group.DefaultIfEmpty()
                         select new
                         {
                             t1.WaId,
                             t1.HaId,
                             t1.EmId,
                             t2.EmName,
                             t1.WaDate,
                             t1.WaShelfFlag,
                             t1.WaFlag,
                             t1.WaHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    warehousing.Add(new TWarehousingDsp()
                    {
                        WaId = t.WaId,
                        HaId = t.HaId,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        WaDate = t.WaDate,
                        WaShelfFlg = t.WaShelfFlag,
                        WaFlag = t.WaFlag,
                        WaHidden = t.WaHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return warehousing;
        }
        ///////////////////////////////
        //メソッド名：CheckWaIdCDExistence()
        //引　数   ：入庫ID
        //戻り値   ：True or False
        //機　能   ：一致する入庫IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckWaIdCDExistence(int waid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //入庫IDで一致するデータが存在するか
                flg = context.TWarehousings.Any(x => x.WaId == waid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckEmIdCDExistence()
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
                flg = context.TWarehousings.Any(x => x.EmId == emid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckHOrderIdCDExistence()
        //引　数   ：発注ID
        //戻り値   ：True or False
        //機　能   ：一致する発注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckHOrderIdCDExistence(int horderid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //発注IDで一致するデータが存在するか
                flg = context.TWarehousings.Any(x => x.HaId == horderid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddWarehousingData()
        //引　数   ：入庫データ
        //戻り値   ：True or False
        //機　能   ：入庫データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddWarehousingData(TWarehousing regWarehousing)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TWarehousings.Add(regWarehousing);
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
