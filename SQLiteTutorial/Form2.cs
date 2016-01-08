using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;      //定義 DataSet, Tables, Rows, Columns
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLiteTutorial
{
    
    public partial class Form2 : Form
    {
        string dbConnectionString = @"Data Source=database.db;version = 3";
        SQLiteCommand sqliteCmd;
        SQLiteConnection sqliteCon;
        public Form2()
        {
            InitializeComponent();
            fill_comboBox();
            fill_Listbox();

            //--- load data in DataGridView
            try
            {
                string Query = "SELECT eid,name,surname,age FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString, Query, ref sqliteCon, ref sqliteCmd);

                //--- add data to dataGrid
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(sqliteCmd);
                DataTable dataTable = new DataTable("employeeinfo");    //name of database
                dataAdp.Fill(dataTable);
                dataGridView1.DataSource = dataTable.DefaultView;
                dataAdp.Update(dataTable);

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void btn_save_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //--- Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "INSERT INTO employeeinfo (eid,name,surname,age) VALUES('"+this.tb_eid.Text+ "','" + this.tb_name.Text + "','" + this.tb_surname.Text + "','" + this.tb_age.Text + "')";
                SQLiteCommand sqliteCmd = new SQLiteCommand(Query, sqliteCon);
                sqliteCmd.ExecuteNonQuery();
                fill_comboBox();
                MessageBox.Show("Saved");
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            //--- Open connection to database
            try
            {
                sqliteCon.Open();
                string Query = "UPDATE employeeinfo SET eid='"+this.tb_eid.Text+ "',name='" + this.tb_name.Text + "',surname='" + this.tb_surname.Text + "',age='" + this.tb_age.Text + "' WHERE eid = '" + this.tb_eid.Text + "' ";
                SQLiteCommand sqliteCmd = new SQLiteCommand(Query, sqliteCon);
                sqliteCmd.ExecuteNonQuery();
                MessageBox.Show("Updated");
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        { 
            //--- Open connection to database
            try
            {
                string Query = "DELETE FROM employeeinfo WHERE eid = '"+tb_eid.Text+"'";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
                MessageBox.Show("Deleted");
                sqliteCon.Close();
                fill_comboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fill_comboBox()
        {
            cb_name.Items.Clear();
            try
            {
                string Query = "SELECT * FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
                SQLiteDataReader reader = sqliteCmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(1);    //data from column 1
                    cb_name.Items.Add(name);
                }
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fill_Listbox()
        {
            listBox1.Items.Clear();
            try
            {
                string Query = "SELECT * FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
                SQLiteDataReader reader = sqliteCmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(1);    //data from column 1
                    string surname = reader.GetString(2);
                    listBox1.Items.Add(name+" "+surname);
                }
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM employeeinfo WHERE name = '"+cb_name.Text+"'";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
                SQLiteDataReader reader = sqliteCmd.ExecuteReader();
                while (reader.Read())
                {
                    string eid = reader.GetValue(0).ToString();     //需注意data的型態，可用GetValue()會自動選型態
                    string name = reader.GetString(1);    //data from column 1
                    string surname = reader.GetString(2);
                    string age = reader.GetInt32(3).ToString();
                    tb_eid.Text = eid;
                    tb_name.Text = name;
                    tb_surname.Text = surname;
                    tb_age.Text = age;
                }
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_loadTable_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT eid,name,surname,age FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);

                //--- add data to dataGrid
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(sqliteCmd);
                DataTable dataTable = new DataTable("employeeinfo");    //name of database
                dataAdp.Fill(dataTable);
                dataGridView1.DataSource = dataTable.DefaultView;
                dataAdp.Update(dataTable);

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
