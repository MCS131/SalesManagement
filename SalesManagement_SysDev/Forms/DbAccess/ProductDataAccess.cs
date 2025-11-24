using Microsoft.VisualBasic;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ProductDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetProductData()
        //引　数   ：なし
        //戻り値   ：商品データ
        //機　能   ：商品データの取得
        ///////////////////////////////
        public List<MProduct> GetProductData()
        {
            List<MProduct> product = null;
            try
            {
                var context = new SalesManagementContext();
                product = context.MProducts.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return product;

        }

        ///////////////////////////////
        //メソッド名：GetProductDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品データ
        //機　能   ：表示用商品データの取得
        ///////////////////////////////
        public List<MProductDsp> GetProductDspData()
        {
            List<MProductDsp> product = new List<MProductDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MProducts
                         join t2 in context.MMakers
                         on t1.MaId equals t2.MaId
                         join t3 in context.MSmallClassifications
                         on t1.ScId equals t3.ScId
                         where t1.PrFlag != 2
                         select new
                         {
                             t1.PrId,
                             t1.PrName,
                             t1.MaId,
                             t2.MaName,
                             t1.Price,
                             t1.PrSafetyStock,
                             t1.ScId,
                             t3.ScName,
                             t1.PrModelNumber,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach( var t in tb)
                {
                    product.Add(new MProductDsp()
                    {
                        ProductID = t.PrId,
                        ProductName = t.PrName,
                        MakerID = t.MaId,
                        MakerName = t.MaName,
                        Price = t.Price,
                        SafeStockNum = t.PrSafetyStock,
                        ScID = t.ScId,
                        ScName = t.ScName,
                        PrModelNum = t.PrModelNumber,
                        PrColor = t.PrColor,
                        PrReleeseDate = t.PrReleaseDate.ToString("yyyy/MM/dd"),
                        PrFlag = t.PrFlag,
                        PrHiddenReason = t.PrHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return product;
        }

        ///////////////////////////////
        //メソッド名：GetProductAllData()
        //引　数   ：なし
        //戻り値   ：表示用商品データ
        //機　能   ：表示用商品データの取得
        ///////////////////////////////
        public List<MProductDsp> GetProductAllData()
        {
            List<MProductDsp> product = new List<MProductDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MProducts
                         join t2 in context.MMakers
                         on t1.MaId equals t2.MaId
                         join t3 in context.MSmallClassifications
                         on t1.ScId equals t3.ScId
                         select new
                         {
                             t1.PrId,
                             t1.PrName,
                             t1.MaId,
                             t2.MaName,
                             t1.Price,
                             t1.PrSafetyStock,
                             t1.ScId,
                             t3.ScName,
                             t1.PrModelNumber,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    product.Add(new MProductDsp()
                    {
                        ProductID = t.PrId,
                        ProductName = t.PrName,
                        MakerID = t.MaId,
                        MakerName = t.MaName,
                        Price = t.Price,
                        SafeStockNum = t.PrSafetyStock,
                        ScID = t.ScId,
                        ScName = t.ScName,
                        PrModelNum = t.PrModelNumber,
                        PrColor = t.PrColor,
                        PrReleeseDate = t.PrReleaseDate.ToString("yyyy/MM/dd"),
                        PrFlag = t.PrFlag,
                        PrHiddenReason = t.PrHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return product;
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

        ///////////////////////////////
        //メソッド名：CheckSoIdCDExistence()
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

        ///////////////////////////////
        //メソッド名：CheckScIdCDExistence()
        //引　数   ：小分類ID
        //戻り値   ：True or False
        //機　能   ：一致する小分類IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckScIdCDExistence(int scid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //小分類IDで一致するデータが存在するか
                flg = context.MSmallClassifications.Any(x => x.ScId == scid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddProductData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public int? AddProductData(MProduct regProduct)
        {
            try
            {
                var context = new SalesManagementContext();
                context.MProducts.Add(regProduct);
                context.SaveChanges();
                context.Dispose();

                return regProduct.PrId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：UpdateProductData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateProductData(MProduct updPrdct)
        {
            try
            {
                var context = new SalesManagementContext();
                var product = context.MProducts.Single(x => x.PrId == updPrdct.PrId);
                product.MaId = updPrdct.MaId;
                product.PrName = updPrdct.PrName;
                product.Price = updPrdct.Price;
                product.PrSafetyStock = updPrdct.PrSafetyStock;
                product.ScId = updPrdct.ScId;
                product.PrModelNumber = updPrdct.PrModelNumber;
                product.PrColor = updPrdct.PrColor;
                product.PrReleaseDate = updPrdct.PrReleaseDate;
                product.PrFlag = updPrdct.PrFlag;
                product.PrHidden = updPrdct.PrHidden;
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
