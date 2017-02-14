namespace AnalyseHealthData
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.browseButton = new System.Windows.Forms.Button();
            this.exportFolderTextBox = new System.Windows.Forms.TextBox();
            this.analyseButton = new System.Windows.Forms.Button();
            this.exportFolderbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.readFilebutton = new System.Windows.Forms.Button();
            this.deathCertFileTextBox = new System.Windows.Forms.TextBox();
            this.deathCertBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.filterDeathButton = new System.Windows.Forms.Button();
            this.meargeDeathDataButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "43 แฟ้ม Folder ";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(129, 3);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(629, 20);
            this.filePathTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.60131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.39869F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.browseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.filePathTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deathCertFileTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.deathCertBrowseButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.exportFolderbutton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.exportFolderTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(896, 409);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(764, 3);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // exportFolderTextBox
            // 
            this.exportFolderTextBox.Location = new System.Drawing.Point(129, 65);
            this.exportFolderTextBox.Name = "exportFolderTextBox";
            this.exportFolderTextBox.Size = new System.Drawing.Size(629, 20);
            this.exportFolderTextBox.TabIndex = 8;
            // 
            // analyseButton
            // 
            this.analyseButton.Location = new System.Drawing.Point(3, 34);
            this.analyseButton.Name = "analyseButton";
            this.analyseButton.Size = new System.Drawing.Size(120, 23);
            this.analyseButton.TabIndex = 6;
            this.analyseButton.Text = "Merge Health Data";
            this.analyseButton.UseVisualStyleBackColor = true;
            this.analyseButton.Click += new System.EventHandler(this.analyseButton_Click);
            // 
            // exportFolderbutton
            // 
            this.exportFolderbutton.Location = new System.Drawing.Point(764, 65);
            this.exportFolderbutton.Name = "exportFolderbutton";
            this.exportFolderbutton.Size = new System.Drawing.Size(75, 20);
            this.exportFolderbutton.TabIndex = 9;
            this.exportFolderbutton.Text = "Browse";
            this.exportFolderbutton.UseVisualStyleBackColor = true;
            this.exportFolderbutton.Click += new System.EventHandler(this.exportFolderbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Export Folder";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(129, 95);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(629, 258);
            this.statusTextBox.TabIndex = 4;
            this.statusTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "สถานะการทำงาน";
            // 
            // readFilebutton
            // 
            this.readFilebutton.Location = new System.Drawing.Point(3, 3);
            this.readFilebutton.Name = "readFilebutton";
            this.readFilebutton.Size = new System.Drawing.Size(120, 23);
            this.readFilebutton.TabIndex = 3;
            this.readFilebutton.Text = "Read File";
            this.readFilebutton.UseVisualStyleBackColor = true;
            this.readFilebutton.Click += new System.EventHandler(this.readFilebutton_Click);
            // 
            // deathCertFileTextBox
            // 
            this.deathCertFileTextBox.Location = new System.Drawing.Point(129, 34);
            this.deathCertFileTextBox.Name = "deathCertFileTextBox";
            this.deathCertFileTextBox.Size = new System.Drawing.Size(629, 20);
            this.deathCertFileTextBox.TabIndex = 10;
            // 
            // deathCertBrowseButton
            // 
            this.deathCertBrowseButton.Location = new System.Drawing.Point(764, 34);
            this.deathCertBrowseButton.Name = "deathCertBrowseButton";
            this.deathCertBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.deathCertBrowseButton.TabIndex = 11;
            this.deathCertBrowseButton.Text = "Browse";
            this.deathCertBrowseButton.UseVisualStyleBackColor = true;
            this.deathCertBrowseButton.Click += new System.EventHandler(this.deathCertBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "ข้อมูล สบรส (csv)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.meargeDeathDataButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.filterDeathButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.readFilebutton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.analyseButton, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(764, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.5625F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.4375F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(129, 258);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // filterDeathButton
            // 
            this.filterDeathButton.Location = new System.Drawing.Point(3, 63);
            this.filterDeathButton.Name = "filterDeathButton";
            this.filterDeathButton.Size = new System.Drawing.Size(120, 23);
            this.filterDeathButton.TabIndex = 7;
            this.filterDeathButton.Text = "Filter Traffic Death ";
            this.filterDeathButton.UseVisualStyleBackColor = true;
            this.filterDeathButton.Click += new System.EventHandler(this.mergeDeathButton_Click);
            // 
            // meargeDeathDataButton
            // 
            this.meargeDeathDataButton.Location = new System.Drawing.Point(3, 93);
            this.meargeDeathDataButton.Name = "meargeDeathDataButton";
            this.meargeDeathDataButton.Size = new System.Drawing.Size(120, 23);
            this.meargeDeathDataButton.TabIndex = 8;
            this.meargeDeathDataButton.Text = "Merge Death ";
            this.meargeDeathDataButton.UseVisualStyleBackColor = true;
            this.meargeDeathDataButton.Click += new System.EventHandler(this.meargeDeathDataButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 449);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Analyse 43 Health File";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button readFilebutton;
        private System.Windows.Forms.RichTextBox statusTextBox;
        private System.Windows.Forms.Button analyseButton;
        private System.Windows.Forms.TextBox exportFolderTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportFolderbutton;
        private System.Windows.Forms.TextBox deathCertFileTextBox;
        private System.Windows.Forms.Button deathCertBrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button filterDeathButton;
        private System.Windows.Forms.Button meargeDeathDataButton;
    }
}

