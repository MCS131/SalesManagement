using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class HattyuDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetHattyuData()
        //引　数   ：なし
        //戻り値   ：発注データ
        //機　能   ：発注データの取得
        ///////////////////////////////
        public List<THattyuDsp> GetHattyuDspData()
        {
            List<THattyuDsp> hattyu = new List<THattyuDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.THattyus
                         join t2 in context.MMakers
                         on t1.MaId equals t2.MaId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId
                         select new
                         {
                             t1.HaId,
                             t1.MaId,
                             t2.MaName,
                             t1.EmId,
                             t3.EmName,
                             t1.HaDate,
                             t1.WaWarehouseFlag,
                             t1.HaFlag,
                             t1.HaHidden,
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    hattyu.Add(new THattyuDsp()
                    {
                        HaId = t.HaId,
                        MaId = t.MaId,
                        MaName = t.MaName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        HaDate = t.HaDate,
                        WaWarehouseFlag = t.WaWarehouseFlag,
                        HaFlag = t.HaFlag,
                        HaHidden = t.HaHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                return hattyu;
            }
        ///////////////////////////////
        //メソッド名：GetHattyuNotStockData()
        //引　数   ：なし
        //戻り値   ：表示用発注済未入庫データ
        //機　能   ：表示用発注済未入庫データの取得
        ///////////////////////////////
        public List<THattyuDsp> GetHattyuNotStockData()
        {
            List<THattyuDsp> hattyu = new List<THattyuDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.THattyus
                         join t2 in context.MMakers
                         on t1.MaId equals t2.MaId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId
                         where t1.WaWarehouseFlag == 0
                         select new
                         {
                             t1.HaId,
                             t1.MaId,
                             t2.MaName,
                             t1.EmId,
                             t3.EmName,
                             t1.HaDate,
                             t1.WaWarehouseFlag,
                             t1.HaFlag,
                             t1.HaHidden,
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    hattyu.Add(new THattyuDsp()
                    {
                        HaId = t.HaId,
                        MaId = t.MaId,
                        MaName = t.MaName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        HaDate = t.HaDate,
                        WaWarehouseFlag = t.WaWarehouseFlag,
                        HaFlag = t.HaFlag,
                        HaHidden = t.HaHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hattyu;
        }
        ///////////////////////////////
        //メソッド名：CheckHaIdCDExistence()
        //引　数   ：発注ID
        //戻り値   ：True or False
        //機　能   ：一致する発注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckHaIdCDExistence(int haid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //発注IDで一致するデータが存在するか
                flg = context.THattyus.Any(x => x.HaId == haid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckMaIdCDExistence()
        //引　数   ：メーカーID
        //戻り値   ：True or False
        //機　能   ：一致するメーカーIDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckMaIdCDExistence(int maid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //メーカーIDで一致するデータが存在するか
                flg = context.MMakers.Any(x => x.MaId == maid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ////////////////////////////////
        //メソッド名：CheckPrIdCDExistence()
        //引　数   ：商品ID
        //戻り値   ：True or False
        //機　能   ：一致する商品IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPrIdCDExistence(int prid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //商品IDで一致するデータが存在するか
                flg = context.MProducts.Any(x => x.PrId == prid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ////////////////////////////////
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
                flg = context.MEmployees.Any(x => x.EmId == emid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddHOrderData()
        //引　数   ：発注データ
        //戻り値   ：True or False
        //機　能   ：発注データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddHOrderData(THattyu regHOrder)
        {
            try
            {
                var context = new SalesManagementContext();
                context.THattyus.Add(regHOrder);
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
