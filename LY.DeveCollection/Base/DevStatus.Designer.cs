namespace LY.DeveCollection.Base
{
    partial class DevStatus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevStatus));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BgWait1 = new System.ComponentModel.BackgroundWorker();
            this.bttniStartTask = new System.Windows.Forms.ToolStripButton();
            this.bttniEndTask = new System.Windows.Forms.ToolStripButton();
            this.bbtniExit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deveiceTaskInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.localAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devpNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devConnectStatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collectStatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deveiceTaskInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.localAddressDataGridViewTextBoxColumn,
            this.DevName,
            this.iPUrlDataGridViewTextBoxColumn,
            this.execIDDataGridViewTextBoxColumn,
            this.devpNameDataGridViewTextBoxColumn,
            this.devConnectStatusDataGridViewCheckBoxColumn,
            this.collectStatusDataGridViewCheckBoxColumn,
            this.collFrequencyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.deveiceTaskInfoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1029, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.控制ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 控制ToolStripMenuItem
            // 
            this.控制ToolStripMenuItem.Name = "控制ToolStripMenuItem";
            this.控制ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.控制ToolStripMenuItem.Text = "控制";
            this.控制ToolStripMenuItem.Click += new System.EventHandler(this.控制ToolStripMenuItem_Click);
            // 
            // BgWait1
            // 
            this.BgWait1.WorkerReportsProgress = true;
            this.BgWait1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWait1_DoWork);
            this.BgWait1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWait1_RunWorkerCompleted);
            // 
            // bttniStartTask
            // 
            this.bttniStartTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttniStartTask.Image = ((System.Drawing.Image)(resources.GetObject("bttniStartTask.Image")));
            this.bttniStartTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttniStartTask.Name = "bttniStartTask";
            this.bttniStartTask.Size = new System.Drawing.Size(60, 22);
            this.bttniStartTask.Text = "开始任务";
            // 
            // bttniEndTask
            // 
            this.bttniEndTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttniEndTask.Image = ((System.Drawing.Image)(resources.GetObject("bttniEndTask.Image")));
            this.bttniEndTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttniEndTask.Name = "bttniEndTask";
            this.bttniEndTask.Size = new System.Drawing.Size(60, 22);
            this.bttniEndTask.Text = "结束任务";
            // 
            // bbtniExit
            // 
            this.bbtniExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bbtniExit.Image = ((System.Drawing.Image)(resources.GetObject("bbtniExit.Image")));
            this.bbtniExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbtniExit.Name = "bbtniExit";
            this.bbtniExit.Size = new System.Drawing.Size(36, 22);
            this.bbtniExit.Text = "退出";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttniStartTask,
            this.bttniEndTask,
            this.bbtniExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 253);
            this.panel1.TabIndex = 6;
            // 
            // deveiceTaskInfoBindingSource
            // 
            this.deveiceTaskInfoBindingSource.DataSource = typeof(LY.DeveCollection.DeveiceTaskInfo);
            // 
            // localAddressDataGridViewTextBoxColumn
            // 
            this.localAddressDataGridViewTextBoxColumn.DataPropertyName = "LocalAddress";
            this.localAddressDataGridViewTextBoxColumn.HeaderText = "LocalAddress";
            this.localAddressDataGridViewTextBoxColumn.Name = "localAddressDataGridViewTextBoxColumn";
            // 
            // DevName
            // 
            this.DevName.DataPropertyName = "DevName";
            this.DevName.HeaderText = "DevName";
            this.DevName.Name = "DevName";
            // 
            // iPUrlDataGridViewTextBoxColumn
            // 
            this.iPUrlDataGridViewTextBoxColumn.DataPropertyName = "IPUrl";
            this.iPUrlDataGridViewTextBoxColumn.HeaderText = "IPUrl";
            this.iPUrlDataGridViewTextBoxColumn.Name = "iPUrlDataGridViewTextBoxColumn";
            // 
            // execIDDataGridViewTextBoxColumn
            // 
            this.execIDDataGridViewTextBoxColumn.DataPropertyName = "ExecID";
            this.execIDDataGridViewTextBoxColumn.HeaderText = "ExecID";
            this.execIDDataGridViewTextBoxColumn.Name = "execIDDataGridViewTextBoxColumn";
            // 
            // devpNameDataGridViewTextBoxColumn
            // 
            this.devpNameDataGridViewTextBoxColumn.DataPropertyName = "DevpName";
            this.devpNameDataGridViewTextBoxColumn.HeaderText = "DevpName";
            this.devpNameDataGridViewTextBoxColumn.Name = "devpNameDataGridViewTextBoxColumn";
            // 
            // devConnectStatusDataGridViewCheckBoxColumn
            // 
            this.devConnectStatusDataGridViewCheckBoxColumn.DataPropertyName = "DevConnectStatus";
            this.devConnectStatusDataGridViewCheckBoxColumn.HeaderText = "DevConnectStatus";
            this.devConnectStatusDataGridViewCheckBoxColumn.Name = "devConnectStatusDataGridViewCheckBoxColumn";
            // 
            // collectStatusDataGridViewCheckBoxColumn
            // 
            this.collectStatusDataGridViewCheckBoxColumn.DataPropertyName = "CollectStatus";
            this.collectStatusDataGridViewCheckBoxColumn.HeaderText = "CollectStatus";
            this.collectStatusDataGridViewCheckBoxColumn.Name = "collectStatusDataGridViewCheckBoxColumn";
            // 
            // collFrequencyDataGridViewTextBoxColumn
            // 
            this.collFrequencyDataGridViewTextBoxColumn.DataPropertyName = "CollFrequency";
            this.collFrequencyDataGridViewTextBoxColumn.HeaderText = "CollFrequency";
            this.collFrequencyDataGridViewTextBoxColumn.Name = "collFrequencyDataGridViewTextBoxColumn";
            // 
            // DevStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 278);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DevStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备执行状态";
            this.Load += new System.EventHandler(this.DevStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deveiceTaskInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker BgWait1;
        private System.Windows.Forms.ToolStripButton bttniStartTask;
        private System.Windows.Forms.ToolStripButton bttniEndTask;
        private System.Windows.Forms.ToolStripButton bbtniExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 控制ToolStripMenuItem;
        private System.Windows.Forms.BindingSource deveiceTaskInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn localAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn execIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn devpNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn devConnectStatusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn collectStatusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collFrequencyDataGridViewTextBoxColumn;


    }
}