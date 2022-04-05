using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        private Account myaccount;
        public Form1()
        {
            InitializeComponent();
            this.myaccount = new Account();
            this.myaccount.firstName = null;
            this.myaccount.lastName = null;
            //dont need to use
            this.myaccount.username = null;
            this.myaccount.password = null;
            this.myaccount.id = null;
        }
        
        public bool validLogin()
        {
            try
            {
                Conn conn = new Conn();
                String query = String.Format("Select * from [dbo].[account] where username = '{0}' and pass = '{1}'", textBox1.Text, textBox2.Text);
                DataTable account = conn.getData(query, "accounts");
                if (account.Rows.Count != 0)
                {
                    Account lg = new Account();
                    this.myaccount.firstName = account.Rows[0].ItemArray[3].ToString();
                    this.myaccount.lastName = account.Rows[0].ItemArray[4].ToString();
                    return true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public void switchToForm2(Account validLogin)
        {
            Form2 f2 = new Form2(validLogin);
            f2.Show();
        }
        public void clearLoginInformation()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (validLogin())
            {
                MessageBox.Show("Success to login");
                switchToForm2(this.myaccount);
            }
            else
            {
                MessageBox.Show("Fail to login");
            }
            //clear all
            clearLoginInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
