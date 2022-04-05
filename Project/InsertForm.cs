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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            fillCombobox1();
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
                //set default value
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertProduct()
        {
            try
            {
                Product newproduct = new Product();
                newproduct.product_name = textBox1.Text;
                newproduct.kind_id = Int32.Parse(comboBox1.Text.Split('.')[0]);
                newproduct.price = Int32.Parse(textBox2.Text);
                String query = String.Format("insert into product(product_name,product_kindID,price) values (N'{0}',{1},{2})",newproduct.product_name,newproduct.kind_id,newproduct.price);
                Conn conn = new Conn();
                conn.alterData(query, "insert");
                MessageBox.Show("Success to insert product");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insertProduct();
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
