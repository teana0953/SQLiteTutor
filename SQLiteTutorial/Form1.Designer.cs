﻿namespace SQLiteTutorial
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
            this.btn_createFile.Location = new System.Drawing.Point(283, 211);
            this.btn_createFile.Name = "btn_createFile";
            this.btn_createFile.Size = new System.Drawing.Size(75, 23);
            this.btn_createFile.TabIndex = 12;
            this.btn_createFile.Text = "Create File";
            this.btn_createFile.UseVisualStyleBackColor = true;
            this.btn_createFile.Click += new System.EventHandler(this.btn_createFile_Click);
            // 
            // btn_createExcelFile
            // 
            this.btn_createExcelFile.Location = new System.Drawing.Point(267, 240);
            this.btn_createExcelFile.Name = "btn_createExcelFile";
            this.btn_createExcelFile.Size = new System.Drawing.Size(117, 23);
            this.btn_createExcelFile.TabIndex = 13;
            this.btn_createExcelFile.Text = "Create Excel File";
            this.btn_createExcelFile.UseVisualStyleBackColor = true;
            this.btn_createExcelFile.Click += new System.EventHandler(this.btn_createExcelFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 266);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

