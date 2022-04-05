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
    public partial class Form3 : Form
    {
        private String defaultQuery = "select product.product_id as 'Product_ID',product.product_name as 'Product_Name',product.price,kindOfProduct.name_of_kind as 'Name_Of_Kind' from product JOIN kindOfProduct on product.product_kindID = kindOfProduct.kind_ID";
        public void renderData(String query)
        {
            try
            {
                Conn conn = new Conn();
                DataTable product_table = conn.getData(query, "products");
                dataGridView1.DataSource = product_table;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            renderData(this.defaultQuery);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void clearSearchInfomation()
        {
            textBox1.Text = "";
            comboBox1.Text = "Product_ID";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            String searchBy = comboBox1.Text;
            String condition = textBox1.Text;
            if (condition != "")
            {
                String query = String.Format("select product.product_id as 'Product_ID',product.product_name as 'Product_Name',product.price,kindOfProduct.name_of_kind as 'Name_Of_Kind' from product JOIN kindOfProduct on product.product_kindID = kindOfProduct.kind_id where {0} = N'{1}'", searchBy, condition);
                renderData(query);
            }
            else
            {
                renderData(this.defaultQuery);
            }
            //clear search infomartion
            clearSearchInfomation();
        }

        private String getCurrentID()
        {
            return dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int product_id = Int32.Parse(getCurrentID());
                UpdateForm updateForm = new UpdateForm(product_id);
                updateForm.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertForm insertform = new InsertForm();
            insertform.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int product_id = Int32.Parse(getCurrentID());
                DeleteForm dl = new DeleteForm(product_id);
                dl.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
