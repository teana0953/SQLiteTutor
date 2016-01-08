using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;


namespace SQLiteTutorial
{
    public partial class Form1 : Form
    {
        string dbConnectionString = @"Data Source=database.db;version = 3";
        SQLiteCommand sqliteCmd;
        SQLiteConnection sqliteCon;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
            //--- Open connection to database
            try
            {
                string Query = "SELECT * FROM employeeinfo WHERE username= '"+tb_user.Text+"'AND password='"+ tb_pw.Text+"'";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
                SQLiteDataReader reader = sqliteCmd.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    count++;

                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    //this.Hide();
                    sqliteCon.Close();
                    //--- Opeining second form
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and password Try Again");
                }
                else if (count < 1)
                {
                    MessageBox.Show("Username and password is not correct");
                }
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
