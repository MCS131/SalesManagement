using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ShipmentDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetShipmentAllData()
        //引　数   ：なし
        //戻り値   ：出荷データ
        //機　能   ：出荷データの取得
        ///////////////////////////////
        public List<TShipmentDsp> GetShipmentAllData()
        {
            List<TShipmentDsp> shipment = new List<TShipmentDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TShipments
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         select new
                         {
                             t1.ShId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.OrId,
                             t1.ShFinishDate,
                             t1.ShStateFlag,
                             t1.ShFlag,
                             t1.ShHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    shipment.Add(new TShipmentDsp()
                    {
                        ShId = t.ShId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        OrId = t.OrId,
                        ShDate = t.ShFinishDate,
                        ShStateFlg = t.ShStateFlag,
                        ShFlg = t.ShFlag,
                        ShHidden = t.ShHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return shipment;

        }

        ///////////////////////////////
        //メソッド名：GetShipmentDspData()
        //引　数   ：なし
        //戻り値   ：表示用出荷データ
        //機　能   ：表示用出荷データの取得
        ///////////////////////////////
        public List<TShipmentDsp> GetShipmentDspData()
        {
            List<TShipmentDsp> shipment = new List<TShipmentDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TShipments
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         where t1.ShFlag != 2
                         select new
                         {
                             t1.ShId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.OrId,
                             t1.ShFinishDate,
                             t1.ShStateFlag,
                             t1.ShFlag,
                             t1.ShHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    shipment.Add(new TShipmentDsp()
                    {
                        ShId = t.ShId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        OrId = t.OrId,
                        ShDate = t.ShFinishDate,
                        ShStateFlg = t.ShStateFlag,
                        ShFlg = t.ShFlag,
                        ShHidden = t.ShHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return shipment;
        }
        ///////////////////////////////
        //メソッド名：AddShipData()
        //引　数   ：出荷データ
        //戻り値   ：True or False
        //機　能   ：出荷データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddShipData(TShipment regShip)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TShipments.Add(regShip);
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
        //メソッド名：CheckShIdCDExistence()
        //引　数   ：出荷ID
        //戻り値   ：True or False
        //機　能   ：一致する出荷IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckShIdCDExistence(int shid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //出荷IDで一致するデータが存在するか
                flg = context.TShipments.Any(x => x.ShId == shid);
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
