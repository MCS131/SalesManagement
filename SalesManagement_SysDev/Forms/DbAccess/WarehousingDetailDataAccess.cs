using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class WarehousingDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetWarehousingDetailData()
        //引　数   ：なし
        //戻り値   ：入庫詳細データ
        //機　能   ：入庫詳細データの取得
        ///////////////////////////////
        public List<TWarehousingDetail> GetWarehousingDetailData()
        {
            List<TWarehousingDetail> warehousingdetail = null;
            try
            {
                var context = new SalesManagementContext();
                warehousingdetail = context.TWarehousingDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return warehousingdetail;

        }
            

        ///////////////////////////////
        //メソッド名：GetWarehousingDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用入庫詳細データ
        //機　能   ：表示用入庫詳細データの取得
        ///////////////////////////////
        public List<TWarehousingDetailDsp> GetWarehousingDetailDspData()
        {
            List<TWarehousingDetailDsp> warehousingdetail = new List<TWarehousingDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TWarehousingDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.WaDetailId,
                             t1.WaId,
                             t1.PrId,
                             t2.PrName,
                             t1.WaQuantity,
                         };
                foreach (var t in tb)
                {
                    warehousingdetail.Add(new TWarehousingDetailDsp
                    {
                        WaDetailId = t.WaDetailId,
                        WaId = t.WaId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        PrQuantity = t.WaQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return warehousingdetail;
        }
        public List<TWarehousingDetailDsp> GetWarehousingDetailSelectData(int strid)
        {
            List<TWarehousingDetailDsp> DspData = new List<TWarehousingDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TWarehousingDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.WaId == strid
                         select new
                         {
                             t1.WaDetailId,
                             t1.WaId,
                             t1.PrId,
                             t2.PrName,
                             t1.WaQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TWarehousingDetailDsp
                    {
                        WaDetailId = t.WaDetailId,
                        WaId = t.WaId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        PrQuantity = t.WaQuantity,
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
