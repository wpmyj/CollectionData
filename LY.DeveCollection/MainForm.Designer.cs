namespace LY.DeveCollection
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.tsbtntext = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OperatorList = new System.Windows.Forms.ListBox();
            this.TaskEnd = new System.Windows.Forms.Button();
            this.TaskStart = new System.Windows.Forms.Button();
            this.StutasList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPPortText = new System.Windows.Forms.TextBox();
            this.groupBoxNew = new System.Windows.Forms.GroupBox();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.groupBoxOnlie = new System.Windows.Forms.GroupBox();
            this.listBoxOnline = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxNew.SuspendLayout();
            this.groupBoxOrder.SuspendLayout();
            this.groupBoxOnlie.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsbtnStart,
            this.tsbtnExit,
            this.tsbtntext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1255, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tlsbtnStart
            // 
            this.tlsbtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlsbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("tlsbtnStart.Image")));
            this.tlsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnStart.Name = "tlsbtnStart";
            this.tlsbtnStart.Size = new System.Drawing.Size(60, 22);
            this.tlsbtnStart.Text = "开始任务";
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(36, 22);
            this.tsbtnExit.Text = "退出";
            // 
            // tsbtntext
            // 
            this.tsbtntext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtntext.Image = ((System.Drawing.Image)(resources.GetObject("tsbtntext.Image")));
            this.tsbtntext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtntext.Name = "tsbtntext";
            this.tsbtntext.Size = new System.Drawing.Size(36, 22);
            this.tsbtntext.Text = "测试";
            this.tsbtntext.Visible = false;
            this.tsbtntext.Click += new System.EventHandler(this.tsbtntext_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1255, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1255, 155);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "WorkbenchCode";
            this.Column1.HeaderText = "工作台编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "WorkbenchName";
            this.Column2.HeaderText = "工作台名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TaskStatus";
            this.Column3.HeaderText = "任务状态";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CurrCount";
            this.Column4.HeaderText = "子任务个数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxOnlie);
            this.groupBox1.Controls.Add(this.groupBoxOrder);
            this.groupBox1.Controls.Add(this.groupBoxNew);
            this.groupBox1.Controls.Add(this.TaskEnd);
            this.groupBox1.Controls.Add(this.TaskStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IPPortText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1255, 221);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监听状态";
            // 
            // OperatorList
            // 
            this.OperatorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperatorList.FormattingEnabled = true;
            this.OperatorList.ItemHeight = 12;
            this.OperatorList.Location = new System.Drawing.Point(3, 17);
            this.OperatorList.Name = "OperatorList";
            this.OperatorList.Size = new System.Drawing.Size(390, 169);
            this.OperatorList.TabIndex = 5;
            // 
            // TaskEnd
            // 
            this.TaskEnd.Location = new System.Drawing.Point(12, 103);
            this.TaskEnd.Name = "TaskEnd";
            this.TaskEnd.Size = new System.Drawing.Size(79, 32);
            this.TaskEnd.TabIndex = 4;
            this.TaskEnd.Text = "结束监听";
            this.TaskEnd.UseVisualStyleBackColor = true;
            this.TaskEnd.Click += new System.EventHandler(this.button2_Click);
            // 
            // TaskStart
            // 
            this.TaskStart.Location = new System.Drawing.Point(12, 45);
            this.TaskStart.Name = "TaskStart";
            this.TaskStart.Size = new System.Drawing.Size(83, 32);
            this.TaskStart.TabIndex = 3;
            this.TaskStart.Text = "开始监听";
            this.TaskStart.UseVisualStyleBackColor = true;
            this.TaskStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // StutasList
            // 
            this.StutasList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StutasList.FormattingEnabled = true;
            this.StutasList.ItemHeight = 12;
            this.StutasList.Location = new System.Drawing.Point(3, 17);
            this.StutasList.Name = "StutasList";
            this.StutasList.Size = new System.Drawing.Size(303, 169);
            this.StutasList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "监听端口：";
            // 
            // IPPortText
            // 
            this.IPPortText.Location = new System.Drawing.Point(6, 182);
            this.IPPortText.Name = "IPPortText";
            this.IPPortText.ReadOnly = true;
            this.IPPortText.Size = new System.Drawing.Size(100, 21);
            this.IPPortText.TabIndex = 1;
            this.IPPortText.Text = "8899";
            // 
            // groupBoxNew
            // 
            this.groupBoxNew.Controls.Add(this.OperatorList);
            this.groupBoxNew.Location = new System.Drawing.Point(823, 23);
            this.groupBoxNew.Name = "groupBoxNew";
            this.groupBoxNew.Size = new System.Drawing.Size(396, 189);
            this.groupBoxNew.TabIndex = 6;
            this.groupBoxNew.TabStop = false;
            this.groupBoxNew.Text = "指令日志";
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.StutasList);
            this.groupBoxOrder.Location = new System.Drawing.Point(121, 23);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(309, 189);
            this.groupBoxOrder.TabIndex = 7;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "连接状态";
            // 
            // groupBoxOnlie
            // 
            this.groupBoxOnlie.Controls.Add(this.listBoxOnline);
            this.groupBoxOnlie.Location = new System.Drawing.Point(490, 23);
            this.groupBoxOnlie.Name = "groupBoxOnlie";
            this.groupBoxOnlie.Size = new System.Drawing.Size(299, 189);
            this.groupBoxOnlie.TabIndex = 8;
            this.groupBoxOnlie.TabStop = false;
            this.groupBoxOnlie.Text = "在线连接";
            // 
            // listBoxOnline
            // 
            this.listBoxOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOnline.FormattingEnabled = true;
            this.listBoxOnline.ItemHeight = 12;
            this.listBoxOnline.Location = new System.Drawing.Point(3, 17);
            this.listBoxOnline.Name = "listBoxOnline";
            this.listBoxOnline.Size = new System.Drawing.Size(293, 169);
            this.listBoxOnline.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备应用端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxNew.ResumeLayout(false);
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOnlie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tlsbtnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsbtntext;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button TaskEnd;
        private System.Windows.Forms.Button TaskStart;
        private System.Windows.Forms.ListBox StutasList;
        private System.Windows.Forms.TextBox IPPortText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox OperatorList;
        private System.Windows.Forms.GroupBox groupBoxOnlie;
        private System.Windows.Forms.ListBox listBoxOnline;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.GroupBox groupBoxNew;
    }
}

