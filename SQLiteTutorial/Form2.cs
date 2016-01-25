using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;      //定義 DataSet, Tables, Rows, Columns
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text.pdf.parser;   // read pdf in richtextbox

/*using Excel = Microsoft.Office.Interop.Excel;*/   // add referance -> COM -> Microsoft Excel Object Library



namespace SQLiteTutorial
{
    
    public partial class Form2 : Form
    {
        string dbConnectionString = @"Data Source=database.db;version = 3";
        SQLiteCommand sqliteCmd;
        SQLiteConnection sqliteCon;
        DataTable dataTable;

        Button btn = new Button();
        public Form2(string userName)
        {
            InitializeComponent();
            this.btn.Click += new System.EventHandler(this.btn_Click);
            label7.Text = "Hello! "+ userName;
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
                dataTable = new DataTable("employeeinfo");    //name of database
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
                dataTable = new DataTable("employeeinfo");    //name of database
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

                //--- export to excel by other method
                #region use pc's MicrosoftExcel
                //Excel.Application excelApp;
                //Excel._Workbook wBook;
                //Excel._Worksheet wSheet;
                //Excel.Range wRange;

                //string pathFile = @"D:\test";
                //excelApp = new Excel.Application();
                //excelApp.Visible = true;
                //excelApp.DisplayAlerts = false;
                //excelApp.Workbooks.Add(Type.Missing);   // add new workbook
                //wBook = excelApp.Workbooks[1];          // use first workbook
                //wBook.Activate();                       // 設定活頁簿焦點

                //wSheet = (Excel._Worksheet)wBook.Worksheets[1];  // 引用第一個工作表
                //wSheet.Name = "工作表測試";
                //wSheet.Activate();

                //excelApp.Cells[1, 1] = "Excel測試";

                //// 設定第1列資料
                //excelApp.Cells[1, 1] = "名稱";
                //excelApp.Cells[1, 2] = "數量";
                //// 設定第1列顏色
                //wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
                //wRange.Select();
                //wRange.Font.Color = ColorTranslator.ToOle(Color.White);
                //wRange.Interior.Color = ColorTranslator.ToOle(Color.DimGray);

                //// 設定第2列資料
                //excelApp.Cells[2, 1] = "AA";
                //excelApp.Cells[2, 2] = "10";

                //// 設定第3列資料
                //excelApp.Cells[3, 1] = "BB";
                //excelApp.Cells[3, 2] = "20";

                //// 設定第4列資料
                //excelApp.Cells[4, 1] = "CC";
                //excelApp.Cells[4, 2] = "30";

                //// 設定第5列資料
                //excelApp.Cells[5, 1] = "總計";

                ////另存活頁簿
                //wBook.SaveAs(pathFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //MessageBox.Show("儲存文件於 " + Environment.NewLine + pathFile);

                ////關閉活頁簿
                //wBook.Close(false, Type.Missing, Type.Missing);

                ////關閉Excel
                //excelApp.Quit();

                ////釋放Excel資源
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                //wBook = null;
                //wSheet = null;
                //wRange = null;
                //excelApp = null;
                //GC.Collect();
                #endregion
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

        private void btn_createPDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            string pdfFileName = "Test.pdf";
            PdfWriter wri = PdfWriter.GetInstance(doc,new FileStream(pdfFileName,FileMode.Create));
            doc.Open(); // Open Document to write

            // add image
            iTextSharp.text.Image JPEG = iTextSharp.text.Image.GetInstance("Basic_logo.jpg");

            // resize image
            //JPEG.ScalePercent(50f);
            JPEG.ScaleToFit(150f,150f);
            JPEG.Border = iTextSharp.text.Rectangle.BOX;
            JPEG.BorderColor = iTextSharp.text.BaseColor.YELLOW;
            JPEG.BorderWidth = 1f;
            // location of image
            JPEG.SetAbsolutePosition(doc.PageSize.Width -32f-212f,doc.PageSize.Height - 36f);
            doc.Add(JPEG);

            // write some content
            Paragraph paragraph = new Paragraph("This is my first line using Paragraph.\n Hello world!");
            // add the above created text using different class object to our PDF document
            doc.Add(paragraph);

            //--- 編號為羅馬編號
            RomanList romanlist = new RomanList(true,15);   // true:lowwer case, 50: 編號後的間距
            romanlist.IndentationLeft = 30f;
            romanlist.Add("One");
            romanlist.Add("two");
            romanlist.Add("Three");
            romanlist.Add("Four");
            romanlist.Add("Five");

            //doc.Add(romanlist);

            List list = new List(List.ORDERED,40f);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 40f;  // 向左移

            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Roman List");
            list.Add(romanlist);        // list in list
            list.Add("Four");
            list.Add("Five");

            doc.Add(list);

            paragraph = new Paragraph("\n");

            doc.Add(paragraph);
            //PdfPTable table = new PdfPTable(3);
            ////--- table header
            //PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL,20f,iTextSharp.text.Font.NORMAL,iTextSharp.text.BaseColor.YELLOW)));
            //cell.BackgroundColor = new iTextSharp.text.BaseColor(0,150,0);  // RGB
            //cell.Colspan = 3;   // header size expand to 3 column
            //cell.HorizontalAlignment = 1; // 0 = Left, 1 = Centre, 2 = Right
            //table.AddCell(cell);
            ////---

            //table.AddCell("Col 1 Row 1");
            //table.AddCell("Col 2 Row 1");
            //table.AddCell("Col 3 Row 1");

            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");
            //doc.Add(table);

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            // add the headers from the DGV to the table
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
            }

            // Flag the firt row as a header
            table.HeaderRows = 1;

            // add the actual rows from the DGV to the table
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k,j].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[k,j].Value.ToString()));
                    }
                }
            }

            doc.Add(table);

            // add chart to pdf
            var chartimage = new MemoryStream();
            chart1.SaveImage(chartimage, ChartImageFormat.Tiff);
            iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            Chart_image.ScalePercent(150f);
            doc.Add(Chart_image);

            doc.Close();

            //--- After finish create pdf, open the file's path
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                #region 開路徑
                //if (!Directory.Exists(path))
                //{
                //    DirectoryInfo di = Directory.CreateDirectory(path);
                //}
                //System.Diagnostics.Process.Start(path);
                #endregion

                #region 開路徑後選擇執行exe
                //OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.InitialDirectory = path;
                //openFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    string FilePath = openFileDialog.FileName;
                //    Process.Start(FilePath);
                //}
                #endregion

                #region automatically open PDF teached by youtube
                System.Diagnostics.Process.Start(path+@"\"+pdfFileName);
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btn_readPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string filePath;
            dlg.Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName.ToString();

                string strText = string.Empty;
                try
                {
                    PdfReader reader = new PdfReader(filePath);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        String s = PdfTextExtractor.GetTextFromPage(reader,page,its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default,Encoding.UTF8,Encoding.Default.GetBytes(s)));
                        strText += s;
                        richTextBox1.Text = strText;
                    }
                    reader.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }
            }
            StreamWriter File = new StreamWriter("PDF_to_Text.txt");
            File.Write(richTextBox1.Text);
            File.Close();
    }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dataTable);
            DV.RowFilter = string.Format("surname Like '%{0}%'",tb_search.Text);   // databaseColumn Like...
            dataGridView1.DataSource = DV;

        }

        private void tb_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)   // 8 : backspace key 46: delete key
            {
                e.Handled = true;
                //MessageBox.Show("Please enter valid value");
            }
        }

        private void btn_createBtn_Click(object sender, EventArgs e)
        {
            btn.Parent = this;
            btn.Location = new System.Drawing.Point(900,143);
            btn.Size = new System.Drawing.Size(94,42);
            btn.Name = "Button_Name";
            btn.Text = "New Button";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you");
        }
    }
}
