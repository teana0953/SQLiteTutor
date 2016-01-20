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

//---- from youtube
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;  
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
//---
using System.Data.OleDb;    // load excel to dataGridView
using System.Diagnostics;


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
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    //form2 = null;
                    //this.Show();
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

        private void btn_loadProgressBar_Click(object sender, EventArgs e)
        {
            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strFileName = openFileDialog1.FileName;
                    string fileText = File.ReadAllText(strFileName);
                    richTextBox1.Text = fileText;
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            int index = 0;
            String temp = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = temp;
            while (index < richTextBox1.Text.LastIndexOf(tb_search.Text))
            {
                richTextBox1.Find(tb_search.Text,index,richTextBox1.TextLength,RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = richTextBox1.Text.IndexOf(tb_search.Text,index)+1;
            }
        }

        private void btn_createFile_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("Test_File.txt");
            streamWriter.Write("Hi! Youtube! How are u?\r\n");
            streamWriter.Write("Hi! Youtube! How are u?\r\n");
            streamWriter.Write("Hi! Youtube! How are u?");
            streamWriter.Close();
        }

        private void btn_createExcelFile_Click(object sender, EventArgs e)
        {
            //create new xls file
            string file = "newdoc.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");
            worksheet.Cells[0, 1] = new Cell((short)1);
            worksheet.Cells[0, 2] = new Cell(9999999);
            worksheet.Cells[0, 3] = new Cell((decimal)3.45);
            worksheet.Cells[0, 4] = new Cell("Text string");
            worksheet.Cells[0, 5] = new Cell("Second string");
            worksheet.Cells[0, 6] = new Cell(32764.5, "#,##0.00");
            worksheet.Cells[0, 7] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
            worksheet.Cells.ColumnWidth[0, 1] = 3000;
            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);

            // open xls file
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];       
        }

        private void btn_chooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tb_filePath.Text = openFileDialog.FileName;
            }
        }

        private void btn_loadFile_Click(object sender, EventArgs e)
        {
            string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + tb_filePath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("SELECT * FROM ["+tb_sheet.Text+"$]", conn);
            DataTable dt = new DataTable();

            myDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_openPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axAcroPDF1.src = openFileDialog.FileName;
            }
        }

        private void btn_openChrome_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                Process.Start(FilePath);
            }
        }
    }
}
