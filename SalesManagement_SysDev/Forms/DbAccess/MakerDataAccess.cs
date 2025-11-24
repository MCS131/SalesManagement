using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class MakerDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetMakerData()
        //引　数   ：なし
        //戻り値   ：メーカデータ
        //機　能   ：メーカデータの取得
        ///////////////////////////////
        public List<MMaker> GetMakerData()
        {
            List<MMaker> maker = null;
            try
            {
                var context = new SalesManagementContext();
                maker = context.MMakers.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maker;

        }

        ///////////////////////////////
        //メソッド名：GetMakerDspData()
        //引　数   ：なし
        //戻り値   ：表示用メーカデータ
        //機　能   ：表示用メーカデータの取得
        ///////////////////////////////
        public List<MMakerDsp> GetMakerDspData()
        {
            List<MMakerDsp> maker = new List<MMakerDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.MMakers
                         where t1.MaFlag != 2
                         select new
                         {
                             t1.MaId,
                             t1.MaName,
                             t1.MaAddress,
                             t1.MaPhone,
                             t1.MaPostal,
                             t1.MaFax,
                             t1.MaFlag,
                             t1.MaHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    maker.Add(new MMakerDsp()
                    {
                        MakerId = t.MaId,
                        MakerName = t.MaName,
                        MakerAddress = t.MaAddress,
                        MakerPhone = t.MaPhone,
                        MakerPostal = t.MaPostal,
                        MakerFax = t.MaFax,
                        MakerFlg = t.MaFlag,
                        MakerHidden = t.MaHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return maker;
        }
    }
}
