using MiniStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ministore
{
    
    public partial class FormProduct : Form
    {
        private readonly Dictionary<string, List<(string Ma, string Ten, decimal Gia, int Ton)>> products =
            new Dictionary<string, List<(string, string, decimal, int)>>()
            {
                ["Thực phẩm"] = new List<(string, string, decimal, int)>()
                {
                    ("TP01", "Mì gói", 3500, 120),
                    ("TP02", "Gạo ST25", 18000, 50)
                },
                ["Đồ uống"] = new List<(string, string, decimal, int)>()
                {
                    ("DU01", "Coca-Cola", 10000, 200),
                    ("DU02", "Nước suối", 5000, 100)
                },
                ["Gia vị"] = new List<(string, string, decimal, int)>()
                {
                    ("GV01", "Muối", 3000, 80),
                    ("GV02", "Nước mắm", 12000, 40)
                },
                ["Đồ gia dụng"] = new List<(string, string, decimal, int)>()
                {
                    ("GD01", "Chảo chống dính", 150000, 20),
                    ("GD02", "Nồi cơm điện", 450000, 15)
                }
            };
        public FormProduct()
        {
            InitializeComponent();
            // Nếu ctxListView chưa được Designer khởi tạo (null) thì dừng
            if (ctxListView == null)
                return;

            // Lấy 2 ToolStripMenuItem đã tạo trong Designer (nếu Designer đổi tên thì sửa lại tên tương ứng)
            var xemItem = ctxListView.Items.OfType<ToolStripItem>()
                .FirstOrDefault(i => string.Equals(i.Name, "xemChiTietToolStripMenuItem", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(i.Text?.Trim(), "Xem chi tiết", StringComparison.OrdinalIgnoreCase));

            var xoaItem = ctxListView.Items.OfType<ToolStripItem>()
                .FirstOrDefault(i => string.Equals(i.Name, "xoáSảnPhẩmToolStripMenuItem", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(i.Name, "xoaSanPhamToolStripMenuItem", StringComparison.OrdinalIgnoreCase) // in case no accent
                                  || string.Equals(i.Text?.Trim(), "Xóa sản phẩm", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(i.Text?.Trim(), "Xoá sản phẩm", StringComparison.OrdinalIgnoreCase));

            // Gỡ handler trước rồi gán lại (đảm bảo không gán 2 lần)
            if (xemItem != null)
            {
                xemItem.Click -= xemChiTiếtToolStripMenuItem_Click;
                xemItem.Click += xemChiTiếtToolStripMenuItem_Click;
            }

            if (xoaItem != null)
            {
                xoaItem.Click -= xoáSảnPhẩmToolStripMenuItem_Click;
                xoaItem.Click += xoáSảnPhẩmToolStripMenuItem_Click;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Khởi tạo TreeView
            tvCategories.Nodes.Clear();
            foreach (var cat in products.Keys)
            {
                tvCategories.Nodes.Add(cat);
            }

            // Cấu hình ListView
            lvProducts.View = View.Details;
            lvProducts.FullRowSelect = true;
            lvProducts.GridLines = true;
           
            // Gán ContextMenuStrip
            lvProducts.ContextMenuStrip = ctxListView;

            // Sự kiện TreeView
            tvCategories.AfterSelect += TvCategories_AfterSelect;

            btnImport.Click += btnImport_Click;
            btnExport.Click += btnExport_Click;
            btnSimulateExport.Click += btnSimulateExport_Click;
        }
        
        private void TvCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
                LoadProductsByCategory(e.Node.Text);
        }
        private void LoadProductsByCategory(string category)
        {
            lvProducts.Items.Clear();
            if (!products.ContainsKey(category)) return;

            foreach (var p in products[category])
            {
                var item = new ListViewItem(p.Ma);
                item.SubItems.Add(p.Ten);
                item.SubItems.Add(p.Gia.ToString("N0"));
                item.SubItems.Add(p.Ton.ToString());
                lvProducts.Items.Add(item);
            }
        }
        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0) return;
            var item = lvProducts.SelectedItems[0];
            MessageBox.Show(
                $"Mã: {item.SubItems[0].Text}\nTên: {item.SubItems[1].Text}\nGiá: {item.SubItems[2].Text}\nTồn kho: {item.SubItems[3].Text}",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xoáSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0) return;
            var name = lvProducts.SelectedItems[0].SubItems[1].Text;
            if (MessageBox.Show($"Xóa sản phẩm '{name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lvProducts.SelectedItems[0].Remove();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.Title = "Chọn file CSV để nhập sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = System.IO.File.ReadAllLines(ofd.FileName);
                        lvProducts.Items.Clear();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(',');
                            if (parts.Length >= 4)
                            {
                                var item = new ListViewItem(parts[0]);
                                item.SubItems.Add(parts[1]);
                                item.SubItems.Add(parts[2]);
                                item.SubItems.Add(parts[3]);
                                lvProducts.Items.Add(item);
                            }
                        }

                        MessageBox.Show("Đã nhập dữ liệu từ file CSV!", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                    }
                }

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.Title = "Lưu danh sách sản phẩm ra file CSV";
                sfd.FileName = "DanhSachSanPham.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = new List<string>();
                        foreach (ListViewItem item in lvProducts.Items)
                        {
                            var line = string.Join(",",
                                item.SubItems[0].Text,
                                item.SubItems[1].Text,
                                item.SubItems[2].Text,
                                item.SubItems[3].Text);
                            lines.Add(line);
                        }

                        System.IO.File.WriteAllLines(sfd.FileName, lines);
                        MessageBox.Show("Đã xuất danh sách ra file CSV!", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
                    }
                }
            }
        }

        private async void btnSimulateExport_Click(object sender, EventArgs e)
        {
            progressBarExport.Minimum = 0;
            progressBarExport.Maximum = 100;
            progressBarExport.Value = 0;

            int totalProducts = 10;
            int step = 100 / totalProducts;

            for (int i = 1; i <= totalProducts; i++)
            {
                await Task.Delay(1000); // mô phỏng export từng sản phẩm
                progressBarExport.Value = Math.Min(progressBarExport.Value + step, progressBarExport.Maximum);
            }

            MessageBox.Show("Export hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
