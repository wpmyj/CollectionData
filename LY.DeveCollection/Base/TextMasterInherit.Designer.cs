namespace LY.DeveCollection.Base
{
    partial class TextMasterInherit
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
            this.button1 = new System.Windows.Forms.Button();
            this.OrigiDataEdit = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IPEdit = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.DevIDEdit = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.VisIDEdit = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.PortEdit = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.AddressEdit = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.LenghtEdit = new DevExpress.XtraEditors.TextEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrigiDataEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevIDEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisIDEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenghtEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "连接数采仪";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrigiDataEdit
            // 
            this.OrigiDataEdit.Location = new System.Drawing.Point(306, 217);
            this.OrigiDataEdit.Name = "OrigiDataEdit";
            this.OrigiDataEdit.Size = new System.Drawing.Size(100, 20);
            this.OrigiDataEdit.TabIndex = 1;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(306, 348);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "原始量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "实际量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP地址:";
            // 
            // IPEdit
            // 
            this.IPEdit.EditValue = "192.168.1.180";
            this.IPEdit.Location = new System.Drawing.Point(87, 22);
            this.IPEdit.Name = "IPEdit";
            this.IPEdit.Size = new System.Drawing.Size(100, 20);
            this.IPEdit.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "设备ID：";
            // 
            // DevIDEdit
            // 
            this.DevIDEdit.EditValue = "1";
            this.DevIDEdit.Location = new System.Drawing.Point(306, 22);
            this.DevIDEdit.Name = "DevIDEdit";
            this.DevIDEdit.Size = new System.Drawing.Size(100, 20);
            this.DevIDEdit.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "访问ID：";
            // 
            // VisIDEdit
            // 
            this.VisIDEdit.EditValue = "255";
            this.VisIDEdit.Location = new System.Drawing.Point(522, 22);
            this.VisIDEdit.Name = "VisIDEdit";
            this.VisIDEdit.Size = new System.Drawing.Size(100, 20);
            this.VisIDEdit.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "端口号：";
            // 
            // PortEdit
            // 
            this.PortEdit.EditValue = "502";
            this.PortEdit.Location = new System.Drawing.Point(87, 78);
            this.PortEdit.Name = "PortEdit";
            this.PortEdit.Size = new System.Drawing.Size(100, 20);
            this.PortEdit.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "地址：";
            // 
            // AddressEdit
            // 
            this.AddressEdit.EditValue = "606";
            this.AddressEdit.Location = new System.Drawing.Point(306, 78);
            this.AddressEdit.Name = "AddressEdit";
            this.AddressEdit.Size = new System.Drawing.Size(100, 20);
            this.AddressEdit.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "字节长度：";
            // 
            // LenghtEdit
            // 
            this.LenghtEdit.EditValue = "2";
            this.LenghtEdit.Location = new System.Drawing.Point(522, 83);
            this.LenghtEdit.Name = "LenghtEdit";
            this.LenghtEdit.Size = new System.Drawing.Size(100, 20);
            this.LenghtEdit.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 51);
            this.button2.TabIndex = 17;
            this.button2.Text = "获取数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(39, 320);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(53, 12);
            this.Status.TabIndex = 18;
            this.Status.Text = "连接状态";
            // 
            // TextMasterInherit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 393);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LenghtEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddressEdit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PortEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VisIDEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DevIDEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.OrigiDataEdit);
            this.Controls.Add(this.button1);
            this.Name = "TextMasterInherit";
            this.Text = "TextMasterInherit";
            ((System.ComponentModel.ISupportInitialize)(this.OrigiDataEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevIDEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisIDEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenghtEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.TextEdit OrigiDataEdit;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit IPEdit;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit DevIDEdit;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit VisIDEdit;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit PortEdit;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit AddressEdit;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit LenghtEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Status;
    }
}