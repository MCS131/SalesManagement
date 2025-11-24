using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class StockDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetStockData()
        //引　数   ：なし
        //戻り値   ：在庫データ
        //機　能   ：在庫データの取得
        ///////////////////////////////
        public List<TStockDsp> GetStockData()
        {
            List<TStockDsp> stock = new List<TStockDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TStocks
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.StFlag != 2
                         select new
                         {
                             t1.StId,
                             t1.PrId,
                             t2.PrName,
                             t1.StQuantity,
                             t1.StFlag,
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    stock.Add(new TStockDsp()
                    {
                        StId = t.StId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        StQuantity = t.StQuantity,
                        StFlag = t.StFlag,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stock;
        }
        ///////////////////////////////
        //メソッド名：GetStockAllData()
        //引　数   ：なし
        //戻り値   ：在庫データ
        //機　能   ：在庫データの取得
        ///////////////////////////////
        public List<TStockDsp> GetStockAllData()
        {
            List<TStockDsp> stock = new List<TStockDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TStocks
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.StId,
                             t1.PrId,
                             t2.PrName,
                             t1.StQuantity,
                             t1.StFlag,
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    stock.Add(new TStockDsp()
                    {
                        StId = t.StId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        StQuantity = t.StQuantity,
                        StFlag = t.StFlag,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stock;
        }
        
        ///////////////////////////////
        //メソッド名：CheckStockIDCDExistence()
        //引　数   ：在庫ID
        //戻り値   ：True or False
        //機　能   ：一致する在庫IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckStockCDExistence(int stockid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //在庫IDで一致するデータが存在するか
                flg = context.TStocks.Any(x => x.StId == stockid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
    }
}
