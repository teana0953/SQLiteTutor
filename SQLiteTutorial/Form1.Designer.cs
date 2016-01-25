namespace SQLiteTutorial
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_logIn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_loadProgressBar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_openFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_createFile = new System.Windows.Forms.Button();
            this.btn_createExcelFile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_chooseFile = new System.Windows.Forms.Button();
            this.btn_loadFile = new System.Windows.Forms.Button();
            this.tb_filePath = new System.Windows.Forms.TextBox();
            this.tb_sheet = new System.Windows.Forms.TextBox();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.btn_openPDF = new System.Windows.Forms.Button();
            this.btn_openExe = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btn_openWeb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_pw
            // 
            this.tb_pw.Location = new System.Drawing.Point(52, 50);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '*';
            this.tb_pw.Size = new System.Drawing.Size(100, 22);
            this.tb_pw.TabIndex = 2;
            // 
            // tb_user
            // 
            this.tb_user.Location = new System.Drawing.Point(52, 22);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(100, 22);
            this.tb_user.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "PW";
            // 
            // btn_logIn
            // 
            this.btn_logIn.Location = new System.Drawing.Point(77, 87);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(75, 23);
            this.btn_logIn.TabIndex = 5;
            this.btn_logIn.Text = "LogIn";
            this.btn_logIn.UseVisualStyleBackColor = true;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(140, 10);
            this.progressBar1.TabIndex = 6;
            // 
            // btn_loadProgressBar
            // 
            this.btn_loadProgressBar.Location = new System.Drawing.Point(12, 153);
            this.btn_loadProgressBar.Name = "btn_loadProgressBar";
            this.btn_loadProgressBar.Size = new System.Drawing.Size(99, 23);
            this.btn_loadProgressBar.TabIndex = 7;
            this.btn_loadProgressBar.Text = "Load progress bar";
            this.btn_loadProgressBar.UseVisualStyleBackColor = true;
            this.btn_loadProgressBar.Click += new System.EventHandler(this.btn_loadProgressBar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Location = new System.Drawing.Point(374, 182);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(75, 23);
            this.btn_openFile.TabIndex = 8;
            this.btn_openFile.Text = "OpenFile";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(170, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 164);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(183, 184);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(94, 22);
            this.tb_search.TabIndex = 10;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(283, 182);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 11;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_createFile
            // 
            this.btn_createFile.Location = new System.Drawing.Point(246, 211);
            this.btn_createFile.Name = "btn_createFile";
            this.btn_createFile.Size = new System.Drawing.Size(75, 23);
            this.btn_createFile.TabIndex = 12;
            this.btn_createFile.Text = "Create File";
            this.btn_createFile.UseVisualStyleBackColor = true;
            this.btn_createFile.Click += new System.EventHandler(this.btn_createFile_Click);
            // 
            // btn_createExcelFile
            // 
            this.btn_createExcelFile.Location = new System.Drawing.Point(332, 211);
            this.btn_createExcelFile.Name = "btn_createExcelFile";
            this.btn_createExcelFile.Size = new System.Drawing.Size(117, 23);
            this.btn_createExcelFile.TabIndex = 13;
            this.btn_createExcelFile.Text = "Create Excel File";
            this.btn_createExcelFile.UseVisualStyleBackColor = true;
            this.btn_createExcelFile.Click += new System.EventHandler(this.btn_createExcelFile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(471, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(216, 193);
            this.dataGridView1.TabIndex = 14;
            // 
            // btn_chooseFile
            // 
            this.btn_chooseFile.Location = new System.Drawing.Point(471, 211);
            this.btn_chooseFile.Name = "btn_chooseFile";
            this.btn_chooseFile.Size = new System.Drawing.Size(75, 23);
            this.btn_chooseFile.TabIndex = 15;
            this.btn_chooseFile.Text = "Choose File";
            this.btn_chooseFile.UseVisualStyleBackColor = true;
            this.btn_chooseFile.Click += new System.EventHandler(this.btn_chooseFile_Click);
            // 
            // btn_loadFile
            // 
            this.btn_loadFile.Location = new System.Drawing.Point(471, 240);
            this.btn_loadFile.Name = "btn_loadFile";
            this.btn_loadFile.Size = new System.Drawing.Size(75, 23);
            this.btn_loadFile.TabIndex = 16;
            this.btn_loadFile.Text = "Load File";
            this.btn_loadFile.UseVisualStyleBackColor = true;
            this.btn_loadFile.Click += new System.EventHandler(this.btn_loadFile_Click);
            // 
            // tb_filePath
            // 
            this.tb_filePath.Location = new System.Drawing.Point(552, 211);
            this.tb_filePath.Name = "tb_filePath";
            this.tb_filePath.Size = new System.Drawing.Size(135, 22);
            this.tb_filePath.TabIndex = 17;
            // 
            // tb_sheet
            // 
            this.tb_sheet.Location = new System.Drawing.Point(552, 240);
            this.tb_sheet.Name = "tb_sheet";
            this.tb_sheet.Size = new System.Drawing.Size(135, 22);
            this.tb_sheet.TabIndex = 18;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(12, 223);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(218, 192);
            this.axAcroPDF1.TabIndex = 19;
            // 
            // btn_openPDF
            // 
            this.btn_openPDF.Location = new System.Drawing.Point(236, 392);
            this.btn_openPDF.Name = "btn_openPDF";
            this.btn_openPDF.Size = new System.Drawing.Size(75, 23);
            this.btn_openPDF.TabIndex = 20;
            this.btn_openPDF.Text = "Open PDF";
            this.btn_openPDF.UseVisualStyleBackColor = true;
            this.btn_openPDF.Click += new System.EventHandler(this.btn_openPDF_Click);
            // 
            // btn_openExe
            // 
            this.btn_openExe.Location = new System.Drawing.Point(332, 392);
            this.btn_openExe.Name = "btn_openExe";
            this.btn_openExe.Size = new System.Drawing.Size(89, 23);
            this.btn_openExe.TabIndex = 21;
            this.btn_openExe.Text = "Open exe file";
            this.btn_openExe.UseVisualStyleBackColor = true;
            this.btn_openExe.Click += new System.EventHandler(this.btn_openChrome_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipTitle = "Form1";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btn_openWeb
            // 
            this.btn_openWeb.Location = new System.Drawing.Point(246, 255);
            this.btn_openWeb.Name = "btn_openWeb";
            this.btn_openWeb.Size = new System.Drawing.Size(75, 23);
            this.btn_openWeb.TabIndex = 22;
            this.btn_openWeb.Text = "open web";
            this.btn_openWeb.UseVisualStyleBackColor = true;
            this.btn_openWeb.Click += new System.EventHandler(this.btn_openWeb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 427);
            this.Controls.Add(this.btn_openWeb);
            this.Controls.Add(this.btn_openExe);
            this.Controls.Add(this.btn_openPDF);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.tb_sheet);
            this.Controls.Add(this.tb_filePath);
            this.Controls.Add(this.btn_loadFile);
            this.Controls.Add(this.btn_chooseFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_createExcelFile);
            this.Controls.Add(this.btn_createFile);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_loadProgressBar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_logIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_pw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_logIn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_loadProgressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_createFile;
        private System.Windows.Forms.Button btn_createExcelFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_chooseFile;
        private System.Windows.Forms.Button btn_loadFile;
        private System.Windows.Forms.TextBox tb_filePath;
        private System.Windows.Forms.TextBox tb_sheet;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Button btn_openPDF;
        private System.Windows.Forms.Button btn_openExe;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btn_openWeb;
    }
}

