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
    public partial class UpdateForm : Form
    {
        private int? product_id;
        public UpdateForm(int product_id)
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
                comboBox1.Text = kop.kind_id.ToString() + "." + " " + kop.kind_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillCombobox1()
        {
            try
            {
                String query = "select * from kindOfProduct";
                List<KindOfProduct> kopl = CommonFunction.getKindOfProductList(query);
                foreach (KindOfProduct item in kopl)
                {
                    String formatitem = item.kind_id.ToString() + "." + " " + item.kind_name;
                    comboBox1.Items.Add(formatitem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            fillProductInformation();
            fillCombobox1();
        }
        private void submitUpdate()
        {
            try
            {
                //product information
                Product product = new Product();
                product.product_id = Int32.Parse(textBox1.Text);
                product.product_name = textBox2.Text;
                String[] temp = comboBox1.Text.ToString().Split('.');
                product.kind_id = Int32.Parse(temp[0]);
                product.price = Int32.Parse(textBox3.Text);
                //query
                String query = String.Format("Update product Set product_name = N'{0}', product_kindID = {1}, price = {2} Where Product_ID = {3}", product.product_name, product.kind_id, product.price,product.product_id);
                Conn conn = new Conn();
                conn.alterData(query, "update");
                MessageBox.Show("Success to update product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submitUpdate();
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}
