using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    public class CommonFunction
    {
        public static List<Product> getProductList(String query)
        {
            List<Product> productlist = new List<Product>();
            try
            {
                Conn conn = new Conn();
                DataTable product_table = conn.getData(query, "products");
                foreach (DataRow row in product_table.Rows)
                {
                    Product product = new Product();
                    product.product_id = Int32.Parse(row.ItemArray[0].ToString());
                    product.product_name = row.ItemArray[1].ToString();
                    product.kind_id = Int32.Parse(row.ItemArray[2].ToString());
                    product.price = Int32.Parse(row.ItemArray[3].ToString());
                    productlist.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productlist;
        }


        public static List<KindOfProduct> getKindOfProductList(String query)
        {
            List<KindOfProduct> kindOfProductslist = new List<KindOfProduct>();
            try
            {
                Conn conn = new Conn();
                DataTable kindtable = conn.getData(query, "kindOfProduct");
                foreach (DataRow row in kindtable.Rows)
                {
                    KindOfProduct kop = new KindOfProduct();
                    kop.kind_id = Int32.Parse(row.ItemArray[0].ToString());
                    kop.kind_name = row.ItemArray[1].ToString();
                    kindOfProductslist.Add(kop);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kindOfProductslist;
        }
    }
}

