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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
        private bool isMatchPassWord()
        {
            if (String.Equals(textBox4.Text, textBox5.Text))
            {
                return true;
            }
            return false;
        }
        private bool isExistUserName()
        {
            try
            {
                String Username = textBox3.Text;
                Conn conn = new Conn();
                String query = String.Format("Select * from account where username = N'{0}'", Username);
                DataTable account_table = conn.getData(query, "accounts");
                if (account_table.Rows.Count == 0)
                {
                    return false;
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        private bool isvalidPasswordLength()
        {
            if (textBox4.Text.Length >= 255 || textBox5.Text.Length >= 255)
            {
                return false;
            }
            if(textBox4.Text.Length < 3 || textBox5.Text.Length < 3 )
            {
                return false;
            }
            return true;
        }
        private bool isvalidUsernameLength()
        {
            if(textBox3.Text.Length >= 255)
            {
                return false;
            }
            if(textBox3.Text.Length <= 0)
            {
                return false;
            }
            return true;
        }
        private bool validSignUp()
        {
            if(!isMatchPassWord())
            {
                MessageBox.Show("Password does not match");
                return false;
            }
            if(isExistUserName())
            {
                MessageBox.Show("Username has already existed");
                return false;
            }
            if(!isvalidPasswordLength())
            {
                MessageBox.Show("Invalid Password's length");
                return false;
            }
            if(!isvalidUsernameLength())
            {
                MessageBox.Show("Invalid Username's length");
                return false;
            }
            return true;
        }
        private Account getAccount()
        {
            Account account = new Account();
            account.firstName = textBox1.Text;
            account.lastName = textBox2.Text;
            account.username = textBox3.Text;
            account.password = textBox4.Text;
            return account;
        }
        private void signUp(Account account)
        {
            try
            {
                Conn conn = new Conn();
                String query = String.Format("Insert into account(username,pass,first_name,last_name) values(N'{0}',N'{1}',N'{2}',N'{3}')",account.username,account.password,account.firstName,account.lastName);
                conn.alterData(query, "insert");
                MessageBox.Show("Success to SignUp");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(validSignUp())
            {
                Account account = getAccount();
                signUp(account);
                Form2 f2 = new Form2(account);
                f2.Show();
                this.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
