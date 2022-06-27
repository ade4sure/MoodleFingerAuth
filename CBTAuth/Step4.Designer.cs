﻿
namespace CBTAuth
{
    partial class Step4
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
            this.btnEnroll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.EnumBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboPrinters = new System.Windows.Forms.ComboBox();
            this.DeviceIDCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCourses = new System.Windows.Forms.ComboBox();
            this.lblStdName = new System.Windows.Forms.Label();
            this.pikStudent = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMatno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pikStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEnroll.Location = new System.Drawing.Point(357, 368);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(251, 48);
            this.btnEnroll.TabIndex = 105;
            this.btnEnroll.Text = "Finger Capture";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 194);
            this.groupBox1.TabIndex = 104;
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
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // EnumBtn
            // 
            this.EnumBtn.Location = new System.Drawing.Point(240, 69);
            this.EnumBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnumBtn.Name = "EnumBtn";
            this.EnumBtn.Size = new System.Drawing.Size(30, 73);
            this.EnumBtn.TabIndex = 102;
            this.EnumBtn.Text = "R";
            this.EnumBtn.Click += new System.EventHandler(this.EnumBtn_Click);
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
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "Camera";
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
            // lblStdName
            // 
            this.lblStdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStdName.ForeColor = System.Drawing.Color.Red;
            this.lblStdName.Location = new System.Drawing.Point(357, 300);
            this.lblStdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStdName.Name = "lblStdName";
            this.lblStdName.Size = new System.Drawing.Size(251, 49);
            this.lblStdName.TabIndex = 102;
            this.lblStdName.Text = "StudentName";
            this.lblStdName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pikStudent
            // 
            this.pikStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pikStudent.Location = new System.Drawing.Point(357, 19);
            this.pikStudent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pikStudent.Name = "pikStudent";
            this.pikStudent.Size = new System.Drawing.Size(251, 269);
            this.pikStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pikStudent.TabIndex = 100;
            this.pikStudent.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(113, 86);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(176, 36);
            this.btnSearch.TabIndex = 99;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMatno
            // 
            this.txtMatno.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMatno.Location = new System.Drawing.Point(90, 19);
            this.txtMatno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMatno.Name = "txtMatno";
            this.txtMatno.Size = new System.Drawing.Size(239, 47);
            this.txtMatno.TabIndex = 98;
            this.txtMatno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 97;
            this.label1.Text = "Num";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(626, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 182);
            this.pictureBox1.TabIndex = 106;
            this.pictureBox1.TabStop = false;
            // 
            // Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 435);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStdName);
            this.Controls.Add(this.pikStudent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtMatno);
            this.Controls.Add(this.label1);
            this.Name = "Step4";
            this.Text = "Step4";
            this.Load += new System.EventHandler(this.Step4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pikStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button EnumBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPrinters;
        private System.Windows.Forms.ComboBox DeviceIDCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCourses;
        private System.Windows.Forms.Label lblStdName;
        private System.Windows.Forms.PictureBox pikStudent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMatno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}