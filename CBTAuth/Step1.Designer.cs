
namespace CBTAuth
{
    partial class Step1
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
            this.txtMatno = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pikStudent = new System.Windows.Forms.PictureBox();
            this.btnAuth = new System.Windows.Forms.Button();
            this.lblStdName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.EnumBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboPrinters = new System.Windows.Forms.ComboBox();
            this.DeviceIDCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCourses = new System.Windows.Forms.ComboBox();
            this.btnEnroll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pikStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Num";
            // 
            // txtMatno
            // 
            this.txtMatno.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMatno.Location = new System.Drawing.Point(76, 31);
            this.txtMatno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMatno.Name = "txtMatno";
            this.txtMatno.Size = new System.Drawing.Size(239, 47);
            this.txtMatno.TabIndex = 1;
            this.txtMatno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(76, 98);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(239, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pikStudent
            // 
            this.pikStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pikStudent.Location = new System.Drawing.Point(343, 31);
            this.pikStudent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pikStudent.Name = "pikStudent";
            this.pikStudent.Size = new System.Drawing.Size(252, 271);
            this.pikStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pikStudent.TabIndex = 3;
            this.pikStudent.TabStop = false;
            // 
            // btnAuth
            // 
            this.btnAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAuth.Location = new System.Drawing.Point(343, 381);
            this.btnAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(178, 48);
            this.btnAuth.TabIndex = 4;
            this.btnAuth.Text = "Authenticate";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // lblStdName
            // 
            this.lblStdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStdName.ForeColor = System.Drawing.Color.Red;
            this.lblStdName.Location = new System.Drawing.Point(343, 312);
            this.lblStdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStdName.Name = "lblStdName";
            this.lblStdName.Size = new System.Drawing.Size(251, 49);
            this.lblStdName.TabIndex = 5;
            this.lblStdName.Text = "Status";
            this.lblStdName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(529, 381);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(34, 48);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "R";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenDevice);
            this.groupBox1.Controls.Add(this.EnumBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboPrinters);
            this.groupBox1.Controls.Add(this.DeviceIDCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboCourses);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(9, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 194);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(76, 154);
            this.btnOpenDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(194, 27);
            this.btnOpenDevice.TabIndex = 103;
            this.btnOpenDevice.Text = "Activate";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click_1);
            // 
            // EnumBtn
            // 
            this.EnumBtn.Location = new System.Drawing.Point(240, 69);
            this.EnumBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnumBtn.Name = "EnumBtn";
            this.EnumBtn.Size = new System.Drawing.Size(30, 73);
            this.EnumBtn.TabIndex = 102;
            this.EnumBtn.Text = "R";
            this.EnumBtn.Click += new System.EventHandler(this.EnumBtn_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 101;
            this.label4.Text = "Scanner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 100;
            this.label2.Text = "Printer";
            // 
            // comboPrinters
            // 
            this.comboPrinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboPrinters.FormattingEnabled = true;
            this.comboPrinters.Location = new System.Drawing.Point(74, 26);
            this.comboPrinters.Name = "comboPrinters";
            this.comboPrinters.Size = new System.Drawing.Size(196, 26);
            this.comboPrinters.TabIndex = 98;
            // 
            // DeviceIDCombo
            // 
            this.DeviceIDCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceIDCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeviceIDCombo.ItemHeight = 18;
            this.DeviceIDCombo.Location = new System.Drawing.Point(74, 69);
            this.DeviceIDCombo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeviceIDCombo.Name = "DeviceIDCombo";
            this.DeviceIDCombo.Size = new System.Drawing.Size(158, 26);
            this.DeviceIDCombo.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "Course";
            // 
            // comboCourses
            // 
            this.comboCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboCourses.FormattingEnabled = true;
            this.comboCourses.Location = new System.Drawing.Point(76, 110);
            this.comboCourses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboCourses.Name = "comboCourses";
            this.comboCourses.Size = new System.Drawing.Size(156, 26);
            this.comboCourses.TabIndex = 95;
            // 
            // btnEnroll
            // 
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEnroll.Location = new System.Drawing.Point(569, 381);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(34, 48);
            this.btnEnroll.TabIndex = 96;
            this.btnEnroll.Text = "E";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // Step1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 441);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblStdName);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.pikStudent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMatno);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Step1";
            this.Text = "Undergraduate Screener";
            this.Load += new System.EventHandler(this.Step1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pikStudent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatno;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pikStudent;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Label lblStdName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button EnumBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPrinters;
        private System.Windows.Forms.ComboBox DeviceIDCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCourses;
        private System.Windows.Forms.Button btnEnroll;
    }
}