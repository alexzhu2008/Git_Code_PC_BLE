namespace SEL_BLE_SDK_PC_CSharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lvEvent = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDevices = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvOperationRecord = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btSearchDevice = new System.Windows.Forms.ToolStripButton();
            this.btConnectDevice = new System.Windows.Forms.ToolStripButton();
            this.btSetTimeIcon = new System.Windows.Forms.ToolStripButton();
            this.btnGetRecord = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 1008);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1432, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lvEvent
            // 
            this.lvEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvEvent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvEvent.GridLines = true;
            this.lvEvent.Location = new System.Drawing.Point(0, 810);
            this.lvEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvEvent.Name = "lvEvent";
            this.lvEvent.Size = new System.Drawing.Size(1432, 198);
            this.lvEvent.TabIndex = 5;
            this.lvEvent.UseCompatibleStateImageBehavior = false;
            this.lvEvent.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Event";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Param";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            this.columnHeader4.Width = 712;
            // 
            // lvDevices
            // 
            this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDevices.FullRowSelect = true;
            this.lvDevices.GridLines = true;
            this.lvDevices.Location = new System.Drawing.Point(3, 23);
            this.lvDevices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(308, 752);
            this.lvDevices.TabIndex = 6;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Address";
            this.columnHeader5.Width = 112;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 149;
            // 
            // lvOperationRecord
            // 
            this.lvOperationRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvOperationRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOperationRecord.FullRowSelect = true;
            this.lvOperationRecord.GridLines = true;
            this.lvOperationRecord.Location = new System.Drawing.Point(3, 23);
            this.lvOperationRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvOperationRecord.Name = "lvOperationRecord";
            this.lvOperationRecord.Size = new System.Drawing.Size(1112, 752);
            this.lvOperationRecord.TabIndex = 8;
            this.lvOperationRecord.UseCompatibleStateImageBehavior = false;
            this.lvOperationRecord.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "时间";
            this.columnHeader7.Width = 131;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "序号";
            this.columnHeader8.Width = 72;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "事件类型";
            this.columnHeader9.Width = 66;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btSearchDevice,
            this.btConnectDevice,
            this.btSetTimeIcon,
            this.btnGetRecord,
            this.btnDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1432, 31);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btSearchDevice
            // 
            this.btSearchDevice.Image = global::SEL_BLE_SDK_PC_CSharp.Properties.Resources.search;
            this.btSearchDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSearchDevice.Name = "btSearchDevice";
            this.btSearchDevice.Size = new System.Drawing.Size(106, 28);
            this.btSearchDevice.Text = "搜索设备";
            this.btSearchDevice.Click += new System.EventHandler(this.bleSearchBtn_Click);
            // 
            // btConnectDevice
            // 
            this.btConnectDevice.Image = global::SEL_BLE_SDK_PC_CSharp.Properties.Resources.connect;
            this.btConnectDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btConnectDevice.Name = "btConnectDevice";
            this.btConnectDevice.Size = new System.Drawing.Size(106, 28);
            this.btConnectDevice.Text = "连接设备";
            this.btConnectDevice.Click += new System.EventHandler(this.bleConnect_Click);
            // 
            // btSetTimeIcon
            // 
            this.btSetTimeIcon.Enabled = false;
            this.btSetTimeIcon.Image = global::SEL_BLE_SDK_PC_CSharp.Properties.Resources.clock;
            this.btSetTimeIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSetTimeIcon.Name = "btSetTimeIcon";
            this.btSetTimeIcon.Size = new System.Drawing.Size(106, 28);
            this.btSetTimeIcon.Text = "设置时间";
            this.btSetTimeIcon.Click += new System.EventHandler(this.btSetTime_Click);
            // 
            // btnGetRecord
            // 
            this.btnGetRecord.Enabled = false;
            this.btnGetRecord.Image = global::SEL_BLE_SDK_PC_CSharp.Properties.Resources.download;
            this.btnGetRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetRecord.Name = "btnGetRecord";
            this.btnGetRecord.Size = new System.Drawing.Size(106, 28);
            this.btnGetRecord.Text = "获取记录";
            this.btnGetRecord.Click += new System.EventHandler(this.btnGetRecord_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(106, 28);
            this.btnDisconnect.Text = "断开连接";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvDevices);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(314, 779);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device List";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvOperationRecord);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(314, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1118, 779);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Records";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "人员名";
            this.columnHeader10.Width = 96;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 1030);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvEvent);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvEvent;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvOperationRecord;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btSearchDevice;
        private System.Windows.Forms.ToolStripButton btConnectDevice;
        private System.Windows.Forms.ToolStripButton btSetTimeIcon;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton btnGetRecord;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}

