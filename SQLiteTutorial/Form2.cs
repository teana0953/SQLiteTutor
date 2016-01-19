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
            timer1.Start();

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
        string Gender;

        private void btn_save_Click(object sender, EventArgs e)
        {
            //--- Open connection to database
            try
            {
                string Query = "INSERT INTO employeeinfo (eid,name,surname,age,gender,DOB) VALUES('"+this.tb_eid.Text+ "','" + this.tb_name.Text + "','" + this.tb_surname.Text + "','" + this.tb_age.Text + "','"+Gender+"','"+dateTimePicker1.Text+"')";
                DataBaseOperation.ConnectToDataBase(dbConnectionString,Query,ref sqliteCon,ref sqliteCmd);
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
                string Query = "UPDATE employeeinfo SET eid='"+this.tb_eid.Text+ "',name='" + this.tb_name.Text + "',surname='" + this.tb_surname.Text + "',age='" + this.tb_age.Text + "',gender = '"+Gender+"',DOB = '"+dateTimePicker1.Text+"' WHERE eid = '" + this.tb_eid.Text + "'";
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
                listView1.Items.Clear();
                string Query = "SELECT eid,name,surname,age FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString, Query, ref sqliteCon, ref sqliteCmd);

                //--- add data to dataGrid
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(sqliteCmd);
                DataTable dataTable = new DataTable("employeeinfo");    //name of database
                dataAdp.Fill(dataTable);

                listView1.BeginUpdate();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    DataRow dataRow = dataTable.Rows[i];
                    ListViewItem listItem = new ListViewItem(dataRow["eid"].ToString());
                    listItem.SubItems.Add(dataRow["name"].ToString());
                    listItem.SubItems.Add(dataRow["surname"].ToString());
                    listItem.SubItems.Add(dataRow["age"].ToString());
                    listView1.Items.Add(listItem);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                listView1.EndUpdate();
                dataAdp.Update(dataTable);

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //--- data export to dataGridView
            try
            {
                //dataGridView1.Columns.Clear();
                string Query = "SELECT eid,name,surname,age FROM employeeinfo";
                DataBaseOperation.ConnectToDataBase(dbConnectionString, Query, ref sqliteCon, ref sqliteCmd);

                //--- add data to dataGrid
                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(sqliteCmd);
                DataTable dataTable = new DataTable();    //name of database
                dataAdp.Fill(dataTable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dataTable;
                dataGridView1.DataSource = bSource;
                dataAdp.Update(dataTable);

                //--- export to excel  (需都為字串才能存入excel)
                DataSet dataSet = new DataSet("New_DataSet");
                dataSet.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                dataAdp.Fill(dataTable);
                dataSet.Tables.Add(dataTable);
                ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls",dataSet);

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_loadChart_Click(object sender, EventArgs e)
        {
            //this.chart1.Series["Age"].Points.AddXY("Max",33);
            //this.chart1.Series["Score"].Points.AddXY("Max", 90);

            //this.chart1.Series["Age"].Points.AddXY("carl", 20);
            //this.chart1.Series["Score"].Points.AddXY("carl", 70);

            //this.chart1.Series["Age"].Points.AddXY("Mark", 50);
            //this.chart1.Series["Score"].Points.AddXY("Mark", 56);

            //this.chart1.Series["Age"].Points.AddXY("Alli", 40);
            //this.chart1.Series["Score"].Points.AddXY("Alli", 30);

            string Query = "SELECT * FROM employeeinfo";
            try
            {
                DataBaseOperation.ConnectToDataBase(dbConnectionString, Query, ref sqliteCon, ref sqliteCmd);
                SQLiteDataReader reader = sqliteCmd.ExecuteReader();
                while (reader.Read())
                {
                    this.chart1.Series["Age"].Points.AddXY(reader.GetValue(1),reader.GetValue(3));
                }
                sqliteCon.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lb_time.Text = dateTime.ToString();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                tb_eid.Text = row.Cells["eid"].Value.ToString();
                tb_name.Text = row.Cells["name"].Value.ToString();
                tb_surname.Text = row.Cells["surname"].Value.ToString();
                tb_age.Text = row.Cells["age"].Value.ToString();
            }
        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void rb_female_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }
    }
}
