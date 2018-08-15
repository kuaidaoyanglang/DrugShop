namespace DrugShop.UI
{
    partial class FrmPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermission));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddUser = new System.Windows.Forms.ToolStripButton();
            this.tsbModifyUser = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveUser = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveSetting = new System.Windows.Forms.ToolStripButton();
            this.tsbResourceList = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.flpResourcePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddUser,
            this.tsbModifyUser,
            this.tsbRemoveUser,
            this.tsbSaveSetting,
            this.tsbResourceList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(789, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddUser
            // 
            this.tsbAddUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddUser.Image")));
            this.tsbAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddUser.Name = "tsbAddUser";
            this.tsbAddUser.Size = new System.Drawing.Size(92, 22);
            this.tsbAddUser.Text = "添加用户(&C)";
            this.tsbAddUser.Click += new System.EventHandler(this.tsbAddUser_Click);
            // 
            // tsbModifyUser
            // 
            this.tsbModifyUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbModifyUser.Image")));
            this.tsbModifyUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModifyUser.Name = "tsbModifyUser";
            this.tsbModifyUser.Size = new System.Drawing.Size(96, 22);
            this.tsbModifyUser.Text = "修改用户(&M)";
            this.tsbModifyUser.Click += new System.EventHandler(this.tsbModifyUser_Click);
            // 
            // tsbRemoveUser
            // 
            this.tsbRemoveUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveUser.Image")));
            this.tsbRemoveUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveUser.Name = "tsbRemoveUser";
            this.tsbRemoveUser.Size = new System.Drawing.Size(93, 22);
            this.tsbRemoveUser.Text = "删除用户(&D)";
            this.tsbRemoveUser.Click += new System.EventHandler(this.tsbRemoveUser_Click);
            // 
            // tsbSaveSetting
            // 
            this.tsbSaveSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveSetting.Image")));
            this.tsbSaveSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveSetting.Name = "tsbSaveSetting";
            this.tsbSaveSetting.Size = new System.Drawing.Size(115, 22);
            this.tsbSaveSetting.Text = "保存权限设置(&S)";
            this.tsbSaveSetting.Click += new System.EventHandler(this.tsbSaveSetting_Click);
            // 
            // tsbResourceList
            // 
            this.tsbResourceList.Image = ((System.Drawing.Image)(resources.GetObject("tsbResourceList.Image")));
            this.tsbResourceList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResourceList.Name = "tsbResourceList";
            this.tsbResourceList.Size = new System.Drawing.Size(124, 22);
            this.tsbResourceList.Text = "初始化权限列表(&I)";
            this.tsbResourceList.Click += new System.EventHandler(this.tsbResourceList_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvUserList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flpResourcePanel);
            this.splitContainer1.Size = new System.Drawing.Size(789, 493);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowDrop = true;
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column1,
            this.Column6,
            this.Column9});
            this.dgvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserList.Location = new System.Drawing.Point(0, 0);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            this.dgvUserList.RowTemplate.Height = 23;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(789, 179);
            this.dgvUserList.TabIndex = 1;
            this.dgvUserList.SelectionChanged += new System.EventHandler(this.dgvUserList_SelectionChanged);
            // 
            // flpResourcePanel
            // 
            this.flpResourcePanel.AutoScroll = true;
            this.flpResourcePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpResourcePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpResourcePanel.Location = new System.Drawing.Point(0, 0);
            this.flpResourcePanel.Name = "flpResourcePanel";
            this.flpResourcePanel.Size = new System.Drawing.Size(789, 310);
            this.flpResourcePanel.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "流水号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "用户编码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "用户姓名";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "管理员";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "是否激活";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "备注信息";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // FrmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 518);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "权限控制台";
            this.Load += new System.EventHandler(this.FrmPermission_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tsbAddUser;
        private System.Windows.Forms.ToolStripButton tsbModifyUser;
        private System.Windows.Forms.ToolStripButton tsbRemoveUser;
        private System.Windows.Forms.ToolStripButton tsbSaveSetting;
        private System.Windows.Forms.ToolStripButton tsbResourceList;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.FlowLayoutPanel flpResourcePanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}