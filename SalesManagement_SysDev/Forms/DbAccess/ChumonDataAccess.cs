using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ChumonDataAccess
    {
        ///////////////////////////////
        //メソッド名：GeTChumonData()
        //引　数   ：なし
        //戻り値   ：注文データ
        //機　能   ：注文データの取得
        ///////////////////////////////
        public List<TChumonDsp> GetChumonData()
        {
            List<TChumonDsp> tchumon = new List<TChumonDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TChumons
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         where t1.ChFlag != 2
                         select new
                         {
                             t1.ChId,
                             t1.OrId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    tchumon.Add(new TChumonDsp()
                    {
                        ChId = t.ChId,
                        OrId = t.OrId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmpID = t.EmId,
                        EmName = t.EmName,
                        ClID = t.ClId,
                        ClName = t.ClName,
                        ChDate = t.ChDate,
                        ChStateFlg = t.ChStateFlag.ToString(),
                        ChFlg = t.ChFlag.ToString(),
                        ChHidden = t.ChHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tchumon;

        }
        ///////////////////////////////
        //メソッド名：GeTChumonAllData()
        //引　数   ：なし
        //戻り値   ：注文データ
        //機　能   ：すべての注文データの取得
        ///////////////////////////////
        public List<TChumonDsp> GetChumonAllData()
        {
            List<TChumonDsp> tchumon = new List<TChumonDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TChumons
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         select new
                         {
                             t1.ChId,
                             t1.OrId,
                             t1.SoId,
                             t2.SoName,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    tchumon.Add(new TChumonDsp()
                    {
                        ChId = t.ChId,
                        OrId = t.OrId,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        EmpID = t.EmId,
                        EmName = t.EmName,
                        ClID = t.ClId,
                        ClName = t.ClName,
                        ChDate = t.ChDate,
                        ChStateFlg = t.ChStateFlag.ToString(),
                        ChFlg = t.ChFlag.ToString(),
                        ChHidden = t.ChHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tchumon;

        }
        ///////////////////////////////
        //メソッド名：GetChumonDspData()
        //引　数   ：なし
        //戻り値   ：表示用注文データ
        //機　能   ：表示用注文データの取得
        ///////////////////////////////
        public List<TChumon> GetChumonDspData()
        {
            List<TChumon> chumon = null;
            try
            {
                var context = new SalesManagementContext();
                chumon = context.TChumons.Where(x => x.ChFlag == 0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return chumon;
        }
        ///////////////////////////////
        //メソッド名：AddChumonData()
        //引　数   ：注文データ
        //戻り値   ：True or False
        //機　能   ：注文データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddChumonData(TChumon regChumon)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TChumons.Add(regChumon);
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
        //メソッド名：CheckChumonIDCDExistence()
        //引　数   ：注文ID
        //戻り値   ：True or False
        //機　能   ：一致する注文IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckChumonCDExistence(int chumonid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //注文IDで一致するデータが存在するか
                flg = context.TChumons.Any(x => x.ChId == chumonid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckEmpIDCDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致する社員IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmpIDCDExistence(int empid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.EmId == empid);
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
