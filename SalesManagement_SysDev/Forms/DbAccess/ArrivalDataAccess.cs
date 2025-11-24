using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ArrivalDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetArrivalData()
        //引　数   ：なし
        //戻り値   ：入荷データ
        //機　能   ：入荷データの取得
        ///////////////////////////////
        public List<TArrivalDsp> GetArrivalData()
        {
            List<TArrivalDsp> arrival = new List<TArrivalDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TArrivals
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         where t1.ArFlag != 2
                         select new
                         {
                             t1.ArId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.OrId,
                             t1.ArDate,
                             t1.ArStateFlag,
                             t1.ArFlag,
                             t1.ArHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    arrival.Add(new TArrivalDsp
                    {
                        ArId = t.ArId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        OrId = t.OrId,
                        ArDate = t.ArDate,
                        ArStateFlg = t.ArStateFlag,
                        ArFlg = t.ArFlag,
                        ArHidden = t.ArHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arrival;

        }

        ///////////////////////////////
        //メソッド名：GetArrivalAllData()
        //引　数   ：なし
        //戻り値   ：表示用入荷データ
        //機　能   ：表示用入荷データの取得
        ///////////////////////////////
        public List<TArrivalDsp> GetArrivalAllData()
        {
            List<TArrivalDsp> arrival = new List<TArrivalDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TArrivals
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         select new
                         {
                             t1.ArId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.OrId,
                             t1.ArDate,
                             t1.ArStateFlag,
                             t1.ArFlag,
                             t1.ArHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    arrival.Add(new TArrivalDsp
                    {
                        ArId = t.ArId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        OrId = t.OrId,
                        ArDate = t.ArDate,
                        ArStateFlg = t.ArStateFlag,
                        ArFlg = t.ArFlag,
                        ArHidden = t.ArHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arrival;
        }
        ///////////////////////////////
        //メソッド名：CheckArIDCDExistence()
        //引　数   ：入荷ID
        //戻り値   ：True or False
        //機　能   ：一致する入荷IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckArIDCDExistence(int arid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //入荷IDで一致するデータが存在するか
                flg = context.TArrivals.Any(x => x.ArId == arid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddArrivalData()
        //引　数   ：入荷データ
        //戻り値   ：True or False
        //機　能   ：入荷データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddArrivalData(TArrival regArrival)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TArrivals.Add(regArrival);
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
