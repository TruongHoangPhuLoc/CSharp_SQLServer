using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class DeleteForm : Form
    {
        private int? product_id;
        public DeleteForm(int product_id)
        {
            InitializeComponent();
            this.product_id = product_id;
        }
        private void fillProductInformation()
        {
            try
            {
                String query = String.Format("select * from product where product_id = {0}", this.product_id);
                List<Product> productlist = CommonFunction.getProductList(query);
                Product product = productlist[0];
                /*
                product.product_id = productlist[0].product_id;
                product.product_name = productlist[0].product_name;
                product.price = productlist[0].price;
                */
                textBox1.Text = product.product_id.ToString();
                textBox2.Text = product.product_name;
                textBox3.Text = product.price.ToString();

                //get default kind_of_product and there is only row
                String defaultKind_ID = String.Format("select * from kindOfProduct where kind_id = {0}", product.kind_id);
                List<KindOfProduct> kopl = CommonFunction.getKindOfProductList(defaultKind_ID);
                KindOfProduct kop = kopl[0];
                textBox4.Text = kop.kind_id.ToString() + "." + " " + kop.kind_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            fillProductInformation();
        }

        private void deleteProduct()
        {
            try
            {
                String query = String.Format("Delete from product where product_id = {0}", textBox1.Text);
                Conn conn = new Conn();
                conn.alterData(query, "delete");
                MessageBox.Show("Success to delete");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                deleteProduct();
                Form3 f3 = new Form3();
                f3.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}
