namespace DrugShop.UI
{
    partial class FrmStockOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockOut));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("销售单录入");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("作废我的销售单");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("冲销我的销售单");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("查询我的销售单");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("我的销售单", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("作废全部销售单");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("冲销全部销售单");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("查询全部销售单");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("全部销售单", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("客户退货单录入");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("客户退货单作废");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("客户退货单查询");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("客户退货", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("按药品汇总销售量");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("按品种汇总销售量");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("按产地汇总销售量");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("按单据作者汇总销售量");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("销售量查询", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbShowTree = new System.Windows.Forms.ToolStripButton();
            this.tsbHideTree = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowTree,
            this.tsbHideTree});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbShowTree
            // 
            this.tsbShowTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowTree.Image")));
            this.tsbShowTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowTree.Name = "tsbShowTree";
            this.tsbShowTree.Size = new System.Drawing.Size(128, 24);
            this.tsbShowTree.Text = "显示导航栏（&M）";
            this.tsbShowTree.Click += new System.EventHandler(this.tsbShowTree_Click);
            // 
            // tsbHideTree
            // 
            this.tsbHideTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideTree.Image")));
            this.tsbHideTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideTree.Name = "tsbHideTree";
            this.tsbHideTree.Size = new System.Drawing.Size(125, 24);
            this.tsbHideTree.Text = "隐藏导航栏（&D）";
            this.tsbHideTree.Click += new System.EventHandler(this.tsbHideTree_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(784, 534);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(280, 532);
            this.splitContainer2.SplitterDistance = 423;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 25;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.ImageKey = "MISC1096.ICO";
            treeNode1.Name = "节点1";
            treeNode1.SelectedImageKey = "REDTICK.ICO";
            treeNode1.Tag = "销售单录入";
            treeNode1.Text = "销售单录入";
            treeNode2.ImageKey = "MISC1096.ICO";
            treeNode2.Name = "节点4";
            treeNode2.SelectedImageKey = "REDTICK.ICO";
            treeNode2.Tag = "作废我的销售单";
            treeNode2.Text = "作废我的销售单";
            treeNode3.ImageKey = "MISC1096.ICO";
            treeNode3.Name = "节点5";
            treeNode3.SelectedImageKey = "REDTICK.ICO";
            treeNode3.Tag = "冲销我的销售单";
            treeNode3.Text = "冲销我的销售单";
            treeNode4.ImageKey = "MISC1096.ICO";
            treeNode4.Name = "节点4";
            treeNode4.SelectedImageKey = "REDTICK.ICO";
            treeNode4.Tag = "查询我的销售单";
            treeNode4.Text = "查询我的销售单";
            treeNode5.ImageKey = "reading material.ico";
            treeNode5.Name = "节点0";
            treeNode5.SelectedImageKey = "reading material.ico";
            treeNode5.Tag = "执行开票员所关联的开票操作";
            treeNode5.Text = "我的销售单";
            treeNode6.ImageKey = "MISC1096.ICO";
            treeNode6.Name = "节点5";
            treeNode6.SelectedImageKey = "REDTICK.ICO";
            treeNode6.Tag = "作废全部销货单";
            treeNode6.Text = "作废全部销售单";
            treeNode7.ImageKey = "MISC1096.ICO";
            treeNode7.Name = "节点6";
            treeNode7.SelectedImageKey = "REDTICK.ICO";
            treeNode7.Tag = "冲销全部销货单";
            treeNode7.Text = "冲销全部销售单";
            treeNode8.ImageKey = "MISC1096.ICO";
            treeNode8.Name = "节点7";
            treeNode8.SelectedImageKey = "REDTICK.ICO";
            treeNode8.Tag = "查询全部销货单";
            treeNode8.Text = "查询全部销售单";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "节点3";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Tag = "执行所有的入库单操作";
            treeNode9.Text = "全部销售单";
            treeNode10.ImageKey = "MISC1096.ICO";
            treeNode10.Name = "节点1";
            treeNode10.SelectedImageKey = "REDTICK.ICO";
            treeNode10.Tag = "客户退货单录入";
            treeNode10.Text = "客户退货单录入";
            treeNode11.ImageKey = "MISC1096.ICO";
            treeNode11.Name = "节点2";
            treeNode11.SelectedImageKey = "REDTICK.ICO";
            treeNode11.Tag = "客户退货单作废";
            treeNode11.Text = "客户退货单作废";
            treeNode12.ImageKey = "MISC1096.ICO";
            treeNode12.Name = "节点3";
            treeNode12.SelectedImageKey = "REDTICK.ICO";
            treeNode12.Tag = "客户退货单查询";
            treeNode12.Text = "客户退货单查询";
            treeNode13.ImageKey = "reading material.ico";
            treeNode13.Name = "节点0";
            treeNode13.SelectedImageKey = "reading material.ico";
            treeNode13.Tag = "客户退货";
            treeNode13.Text = "客户退货";
            treeNode14.ImageKey = "MISC1096.ICO";
            treeNode14.Name = "节点6";
            treeNode14.SelectedImageKey = "REDTICK.ICO";
            treeNode14.Tag = "按药品汇总销货单";
            treeNode14.Text = "按药品汇总销售量";
            treeNode15.ImageKey = "MISC1096.ICO";
            treeNode15.Name = "节点8";
            treeNode15.SelectedImageKey = "REDTICK.ICO";
            treeNode15.Tag = "按品种汇总销货单";
            treeNode15.Text = "按品种汇总销售量";
            treeNode16.ImageKey = "MISC1096.ICO";
            treeNode16.Name = "节点9";
            treeNode16.SelectedImageKey = "REDTICK.ICO";
            treeNode16.Tag = "按产地汇总销货单";
            treeNode16.Text = "按产地汇总销售量";
            treeNode17.ImageKey = "MISC1096.ICO";
            treeNode17.Name = "节点10";
            treeNode17.SelectedImageKey = "REDTICK.ICO";
            treeNode17.Tag = "按经办人汇总销货单";
            treeNode17.Text = "按单据作者汇总销售量";
            treeNode18.ImageKey = "reading material.ico";
            treeNode18.Name = "节点0";
            treeNode18.SelectedImageKey = "reading material.ico";
            treeNode18.Tag = "入库量查询";
            treeNode18.Text = "销售量查询";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9,
            treeNode13,
            treeNode18});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(280, 423);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MISC1096.ICO");
            this.imageList1.Images.SetKeyName(1, "REDTICK.ICO");
            this.imageList1.Images.SetKeyName(2, "reading material.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明：";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(13, 17);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(261, 79);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "操作说明";
            // 
            // FrmStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStockOut";
            this.ShowIcon = false;
            this.Text = "销售出库";
            this.Load += new System.EventHandler(this.FrmStockIn_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbShowTree;
        private System.Windows.Forms.ToolStripButton tsbHideTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescription;
    }
}