using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SalesOfficeDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSalesOfficeData()
        //引　数   ：なし
        //戻り値   ：営業所データ
        //機　能   ：営業所データの取得
        ///////////////////////////////
        public List<MSalesOffice> GetOrderData()
        {
            List<MSalesOffice> salesoffice = null;
            try
            {
                var context = new SalesManagementContext();
                salesoffice = context.MSalesOffices.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesoffice;

        }

        ///////////////////////////////
        //メソッド名：GetSalesOfficeDspData()
        //引　数   ：なし
        //戻り値   ：表示用営業所データ
        //機　能   ：表示用営業所データの取得
        ///////////////////////////////
        public List<MSalesOfficeDsp> GetSalesOfficeDspData()
        {
            List<MSalesOfficeDsp> salesoffice = new List<MSalesOfficeDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.MSalesOffices
                         where t1.SoFlag != 2
                         select new
                         {
                             t1.SoId,
                             t1.SoName,
                             t1.SoAddress,
                             t1.SoPhone,
                             t1.SoPostal,
                             t1.SoFax,
                             t1.SoFlag,
                             t1.SoHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    salesoffice.Add(new MSalesOfficeDsp()
                    {
                        SaleId = t.SoId,
                        SaleName = t.SoName,
                        SaleAddr = t.SoAddress,
                        SalePhone = t.SoPhone,
                        SalePostal = t.SoPostal,
                        SaleFax = t.SoFax,
                        SaleFlg = t.SoFlag,
                        SaleHidden = t.SoHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesoffice;
        }
    }
}
