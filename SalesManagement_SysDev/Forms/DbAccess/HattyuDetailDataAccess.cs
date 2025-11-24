using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class HattyuDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetHattyuDetailData()
        //引　数   ：なし
        //戻り値   ：発注詳細データ
        //機　能   ：発注詳細データの取得
        ///////////////////////////////
        public List<THattyuDetail> GetHattyuDetailData()
        {
            List<THattyuDetail> hattyudetail = null;
            try
            {
                var context = new SalesManagementContext();
                hattyudetail = context.THattyuDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hattyudetail;

        }

        ///////////////////////////////
        //メソッド名：GetHattyuDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用発注詳細データ
        //機　能   ：表示用発注詳細データの取得
        ///////////////////////////////
        public List<THattyuDetailDsp> GetHattyuDetailDspData()
        {
            List<THattyuDetailDsp> hattyudetail = new List<THattyuDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.THattyuDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.HaDetailId,
                             t1.HaId,
                             t1.PrId,
                             t2.PrName,
                             t1.HaQuantity,
                         };
                foreach (var t in tb)
                {
                    hattyudetail.Add(new THattyuDetailDsp
                    {
                        HaDetailId = t.HaDetailId,
                        HaId = t.HaId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        HaQuantity = t.HaQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hattyudetail;
        }
        ///////////////////////////////
        //メソッド名：AddDetailData()
        //引　数   ：発注詳細情報データ
        //戻り値   ：True or False
        //機　能   ：発注詳細データの追加
        //          ：追加成功の場合True
        //          ：追加失敗の場合False
        ///////////////////////////////
        public bool AddDetailData(THattyuDetail regDetail)
        {
            try
            {
                var context = new SalesManagementContext();
                context.THattyuDetails.Add(regDetail);
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
        public List<THattyuDetailDsp> GetHattyuDetailSelectData(int horderid)
        {
            List<THattyuDetailDsp> DspData = new List<THattyuDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.THattyuDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.HaId == horderid
                         select new
                         {
                             t1.HaDetailId,
                             t1.HaId,
                             t1.PrId,
                             t2.PrName,
                             t1.HaQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new THattyuDetailDsp
                    {
                        HaDetailId = t.HaDetailId,
                        HaId = t.HaId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        HaQuantity = t.HaQuantity,
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
