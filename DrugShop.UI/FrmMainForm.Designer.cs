namespace DrugShop.UI
{
    partial class FrmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采购入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调拨管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.库存管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报表查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.皮肤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.平铺窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.权限控制台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基础数据维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能FToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.显示VToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.显示VToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 功能FToolStripMenuItem
            // 
            this.功能FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.销售出库ToolStripMenuItem,
            this.采购入库ToolStripMenuItem,
            this.调拨管理ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.库存管理ToolStripMenuItem,
            this.报表查询ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.功能FToolStripMenuItem.Name = "功能FToolStripMenuItem";
            this.功能FToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.功能FToolStripMenuItem.Text = "功能（&F）";
            // 
            // 销售出库ToolStripMenuItem
            // 
            this.销售出库ToolStripMenuItem.Name = "销售出库ToolStripMenuItem";
            this.销售出库ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.销售出库ToolStripMenuItem.Text = "销售";
            this.销售出库ToolStripMenuItem.Click += new System.EventHandler(this.销售ToolStripMenuItem_Click);
            // 
            // 采购入库ToolStripMenuItem
            // 
            this.采购入库ToolStripMenuItem.Name = "采购入库ToolStripMenuItem";
            this.采购入库ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.采购入库ToolStripMenuItem.Text = "采购";
            this.采购入库ToolStripMenuItem.Click += new System.EventHandler(this.采购ToolStripMenuItem_Click);
            // 
            // 调拨管理ToolStripMenuItem
            // 
            this.调拨管理ToolStripMenuItem.Name = "调拨管理ToolStripMenuItem";
            this.调拨管理ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.调拨管理ToolStripMenuItem.Text = "调拨";
            this.调拨管理ToolStripMenuItem.Click += new System.EventHandler(this.调拨ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // 库存管理ToolStripMenuItem
            // 
            this.库存管理ToolStripMenuItem.Name = "库存管理ToolStripMenuItem";
            this.库存管理ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.库存管理ToolStripMenuItem.Text = "库存管理";
            this.库存管理ToolStripMenuItem.Click += new System.EventHandler(this.库存管理ToolStripMenuItem_Click);
            // 
            // 报表查询ToolStripMenuItem
            // 
            this.报表查询ToolStripMenuItem.Name = "报表查询ToolStripMenuItem";
            this.报表查询ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.报表查询ToolStripMenuItem.Text = "报表查询";
            this.报表查询ToolStripMenuItem.Click += new System.EventHandler(this.报表查询ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.退出ToolStripMenuItem.Text = "退出（&X）";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.编辑EToolStripMenuItem.Text = "编辑（&E）";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.保存ToolStripMenuItem.Text = "保存（&S）";
            // 
            // 显示VToolStripMenuItem
            // 
            this.显示VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.皮肤ToolStripMenuItem,
            this.窗体ToolStripMenuItem,
            this.平铺窗口ToolStripMenuItem});
            this.显示VToolStripMenuItem.Name = "显示VToolStripMenuItem";
            this.显示VToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.显示VToolStripMenuItem.Text = "显示（&V）";
            // 
            // 皮肤ToolStripMenuItem
            // 
            this.皮肤ToolStripMenuItem.Name = "皮肤ToolStripMenuItem";
            this.皮肤ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.皮肤ToolStripMenuItem.Text = "皮肤";
            // 
            // 窗体ToolStripMenuItem
            // 
            this.窗体ToolStripMenuItem.Name = "窗体ToolStripMenuItem";
            this.窗体ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // 平铺窗口ToolStripMenuItem
            // 
            this.平铺窗口ToolStripMenuItem.Name = "平铺窗口ToolStripMenuItem";
            this.平铺窗口ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.平铺窗口ToolStripMenuItem.Text = "平铺窗口";
            this.平铺窗口ToolStripMenuItem.Click += new System.EventHandler(this.平铺窗口ToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人密码修改ToolStripMenuItem,
            this.权限控制台ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.系统配置ToolStripMenuItem,
            this.基础数据维护ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.工具TToolStripMenuItem.Text = "工具（&T）";
            // 
            // 个人密码修改ToolStripMenuItem
            // 
            this.个人密码修改ToolStripMenuItem.Name = "个人密码修改ToolStripMenuItem";
            this.个人密码修改ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.个人密码修改ToolStripMenuItem.Text = "个人密码修改...";
            this.个人密码修改ToolStripMenuItem.Click += new System.EventHandler(this.个人密码修改ToolStripMenuItem_Click);
            // 
            // 权限控制台ToolStripMenuItem
            // 
            this.权限控制台ToolStripMenuItem.Name = "权限控制台ToolStripMenuItem";
            this.权限控制台ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.权限控制台ToolStripMenuItem.Text = "权限控制台...";
            this.权限控制台ToolStripMenuItem.Click += new System.EventHandler(this.权限控制台ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(154, 6);
            // 
            // 系统配置ToolStripMenuItem
            // 
            this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
            this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.系统配置ToolStripMenuItem.Text = "系统设置...";
            this.系统配置ToolStripMenuItem.Click += new System.EventHandler(this.系统配置ToolStripMenuItem_Click);
            // 
            // 基础数据维护ToolStripMenuItem
            // 
            this.基础数据维护ToolStripMenuItem.Name = "基础数据维护ToolStripMenuItem";
            this.基础数据维护ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.基础数据维护ToolStripMenuItem.Text = "基础数据维护";
            this.基础数据维护ToolStripMenuItem.Click += new System.EventHandler(this.基础数据维护ToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.帮助HToolStripMenuItem.Text = "帮助（&H）";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.关于AToolStripMenuItem.Text = "关于（&A）";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tslUserName,
            this.toolStripStatusLabel2,
            this.tslVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前用户：";
            // 
            // tslUserName
            // 
            this.tslUserName.AutoSize = false;
            this.tslUserName.ForeColor = System.Drawing.Color.Blue;
            this.tslUserName.Name = "tslUserName";
            this.tslUserName.Size = new System.Drawing.Size(100, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "程序版本：";
            // 
            // tslVersion
            // 
            this.tslVersion.AutoSize = false;
            this.tslVersion.ForeColor = System.Drawing.Color.Navy;
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(100, 17);
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "恒惠药店管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.FrmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采购入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 销售出库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 库存管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报表查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 调拨管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tslVersion;
        private System.Windows.Forms.ToolStripMenuItem 显示VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 皮肤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 权限控制台ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator 窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平铺窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基础数据维护ToolStripMenuItem;
    }
}