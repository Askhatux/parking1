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
    public partial class Search_number : Form
    {
        public Search_number()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String carnumber = textBox1.Text;

            DB dbase2 = new DB();
            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT balance FROM `balance` WHERE car_number = @cnumber", dbase2.getConnection());
            command.Parameters.Add("@cnumber", MySqlDbType.VarChar).Value = carnumber;

            adapter.SelectCommand = command;
            adapter.Fill(table2);
            string returnedValue ="0";

            if (table2.Rows.Count > 0)
            {
                returnedValue = table2.Rows[0][0].ToString();
                MessageBox.Show(returnedValue);
            }
            else
            {
                MessageBox.Show("Does not exist");
                
            }
            Application.Exit();
        }
    }
}
