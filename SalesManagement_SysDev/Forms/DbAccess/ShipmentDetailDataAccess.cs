using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ShipmentDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetshgDetailData()
        //引　数   ：なし
        //戻り値   ：出荷詳細データ
        //機　能   ：出荷詳細データの取得
        ///////////////////////////////
        public List<TShipmentDetailDsp> GetShgDetailData()
        {
            List<TShipmentDetailDsp> shgdetail = new List<TShipmentDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TShipmentDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.ShDetailId,
                             t1.ShId,
                             t1.PrId,
                             t2.PrName,
                             t1.ShQuantity,
                         };
                foreach (var t in tb)
                {
                    shgdetail.Add(new TShipmentDetailDsp
                    {
                        ShDetailId = t.ShDetailId,
                        ShId = t.ShId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ShQuantity = t.ShQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return shgdetail;

        }


        ///////////////////////////////
        //メソッド名：GetShipmentDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用出荷詳細データ
        //機　能   ：表示用出荷詳細データの取得
        ///////////////////////////////
        public List<TShipmentDetail> GetShipmentDetailDspData()
        {
            List<TShipmentDetail> shipmentdetail = null;
            try
            {
                var context = new SalesManagementContext();
                shipmentdetail = context.TShipmentDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return shipmentdetail;
        }
        public List<TShipmentDetailDsp> GetShgDetailSelectData(int shgid)
        {
            List<TShipmentDetailDsp> DspData = new List<TShipmentDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TShipmentDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.ShId == shgid
                         select new
                         {
                             t1.ShDetailId,
                             t1.ShId,
                             t1.PrId,
                             t2.PrName,
                             t1.ShQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TShipmentDetailDsp
                    {
                        ShDetailId = t.ShDetailId,
                        ShId = t.ShId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ShQuantity = t.ShQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DspData;
        }
    }
}
