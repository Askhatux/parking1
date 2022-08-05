using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login1 = textBox1.Text;
            String password1 = textBox2.Text;

            DB dbase = new DB();
            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE login = @log AND password = @pass", dbase.getConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = login1;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password1;

            adapter.SelectCommand = command;
            adapter.Fill(table1);
            if (table1.Rows.Count > 0)
            {  
                this.Hide();
                Search_number sn = new Search_number();
                sn.Show();
            }
            else
            {
                MessageBox.Show("Login or password is not correct");
                Application.Exit();
            }
        }
    }
}
