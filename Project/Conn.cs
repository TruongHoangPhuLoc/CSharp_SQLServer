using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Conn
    {
        private SqlConnection conn;
        private String source;
        private String username;
        private String password;
        private String catalog;
        public Conn()
        {
            this.source = ".";
            this.username = "sa";
            this.password = "123";
            this.catalog = "gymstore";
            String establish = String.Format("Data source ={0}; user id = {1}; password={2}; initial catalog = {3}",this.source,this.username,this.password,this.catalog);
            this.conn = new SqlConnection(establish);
        }
        public void openConn()
        {
            try
            {
                this.conn.Open();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
            
        }
        public void closeConn()
        {
            try
            {
                this.conn.Close();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getData(String query, String tableName)
        {
            try
            {
                this.conn.Open();
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, this.conn);
                dataAdapter.Fill(dataset, tableName);
                this.conn.Close();
                return dataset.Tables[tableName];
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void insertData(SqlDataAdapter sqlDataAdapter, String query)
        {
            SqlCommand command = new SqlCommand(query, this.conn);
            sqlDataAdapter.InsertCommand = command;
            sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }
        private void updateData(SqlDataAdapter sqlDataAdapter, String query)
        {
            SqlCommand command = new SqlCommand(query, this.conn);
            sqlDataAdapter.UpdateCommand = command;
            sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
        }
        private void deleteData(SqlDataAdapter sqlDataAdapter, String query)
        {
            SqlCommand command = new SqlCommand(query, this.conn);
            sqlDataAdapter.DeleteCommand = command;
            sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
        }
        public void alterData(String query, String operation)
        {
            try
            {
                this.conn.Open();
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                switch (operation.ToLower())
                {
                    case "insert":
                        this.insertData(dataAdapter, query);
                        break;
                    case "update":
                        this.updateData(dataAdapter, query);
                        break;
                    case "delete":
                        this.deleteData(dataAdapter, query);
                        break;
                }
                this.conn.Close();
                 
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
