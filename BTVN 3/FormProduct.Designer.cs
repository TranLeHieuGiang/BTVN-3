namespace Ministore
{
    partial class FormProduct
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.btnSimulateExport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tvCategories = new System.Windows.Forms.TreeView();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoáSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.progressBarExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnSimulateExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnImport);
            this.splitContainer1.Panel1.Controls.Add(this.tvCategories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvProducts);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(12, 229);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(239, 23);
            this.progressBarExport.TabIndex = 1;
            // 
            // btnSimulateExport
            // 
            this.btnSimulateExport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSimulateExport.Location = new System.Drawing.Point(176, 164);
            this.btnSimulateExport.Name = "btnSimulateExport";
            this.btnSimulateExport.Size = new System.Drawing.Size(75, 41);
            this.btnSimulateExport.TabIndex = 1;
            this.btnSimulateExport.Text = "Mô phỏng Export";
            this.btnSimulateExport.UseVisualStyleBackColor = false;
            this.btnSimulateExport.Click += new System.EventHandler(this.btnSimulateExport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExport.Location = new System.Drawing.Point(87, 173);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnImport.Location = new System.Drawing.Point(10, 173);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(56, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tvCategories
            // 
            this.tvCategories.BackColor = System.Drawing.Color.Wheat;
            this.tvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCategories.Location = new System.Drawing.Point(0, 0);
            this.tvCategories.Name = "tvCategories";
            this.tvCategories.Size = new System.Drawing.Size(266, 450);
            this.tvCategories.TabIndex = 0;
            
            // 
            // lvProducts
            // 
            this.lvProducts.BackColor = System.Drawing.Color.Wheat;
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(0, 0);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(530, 450);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tồn kho";
            // 
            // ctxListView
            // 
            this.ctxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemChiTiếtToolStripMenuItem,
            this.xoáSảnPhẩmToolStripMenuItem});
            this.ctxListView.Name = "ctxListView";
            this.ctxListView.Size = new System.Drawing.Size(150, 48);
            // 
            // xemChiTiếtToolStripMenuItem
            // 
            this.xemChiTiếtToolStripMenuItem.Name = "xemChiTiếtToolStripMenuItem";
            this.xemChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.xemChiTiếtToolStripMenuItem.Text = "Xem chi tiết";
            this.xemChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtToolStripMenuItem_Click);
            // 
            // xoáSảnPhẩmToolStripMenuItem
            // 
            this.xoáSảnPhẩmToolStripMenuItem.Name = "xoáSảnPhẩmToolStripMenuItem";
            this.xoáSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.xoáSảnPhẩmToolStripMenuItem.Text = "Xoá sản phẩm";
            this.xoáSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.xoáSảnPhẩmToolStripMenuItem_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormProduct";
            this.Text = "Quản lý danh mục";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCategories;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip ctxListView;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoáSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.Button btnSimulateExport;
        private System.Windows.Forms.ProgressBar progressBarExport;
    }
}