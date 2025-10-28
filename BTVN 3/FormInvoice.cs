using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ministore
{
    public partial class FormInvoice : Form
    {
        private decimal total = 0;
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


        public FormInvoice()
        {
            InitializeComponent();
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            lvItems.View = View.Details;
            lvItems.FullRowSelect = true;
            lvItems.GridLines = true;
            LoadProductList();
        }

        private void LoadProductList()
        {
            lvItems.Items.Clear();
            foreach (var cat in products)
            {
                foreach (var p in cat.Value)
                {
                    int soLuong = 1; // mặc định 1 để test
                    decimal thanhTien = p.Gia * soLuong;
                    var item = new ListViewItem(p.Ma);
                    item.SubItems.Add(p.Ten);
                    item.SubItems.Add(p.Gia.ToString("N0"));
                    item.SubItems.Add(soLuong.ToString());
                    item.SubItems.Add(thanhTien.ToString("N0"));
                    lvItems.Items.Add(item);

                    total += thanhTien;
                }
            }

            lblTotal.Text = total.ToString("N0") + " VNĐ";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocumentInvoice;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocumentInvoice_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float y = 100;
            e.Graphics.DrawString("MINI STORE VIỆT", new Font("Arial", 16, FontStyle.Bold), Brushes.Red, 250, 50);
            e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 250, 80);

            e.Graphics.DrawString($"Khách hàng: {txtCustomer.Text}", new Font("Arial", 12), Brushes.Black, 100, y);
            y += 40;

            foreach (ListViewItem item in lvItems.Items)
            {
                e.Graphics.DrawString($"{item.SubItems[0].Text} - SL: {item.SubItems[2].Text} - Thành tiền: {item.SubItems[3].Text}",
                    new Font("Arial", 11), Brushes.Black, 100, y);
                y += 25;
            }

            y += 20;
            e.Graphics.DrawString($"Tổng tiền: {lblTotal.Text}", new Font("Arial", 12, FontStyle.Bold), Brushes.Blue, 100, y);
            y += 30;
            e.Graphics.DrawString($"Ngày in: {DateTime.Now}", new Font("Arial", 10), Brushes.Gray, 100, y + 10);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "hoadon.csv"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Mã,Tên sản phẩm,Giá,Số lượng,Thành tiền");
                        foreach (ListViewItem item in lvItems.Items)
                        {
                            sw.WriteLine($"{item.SubItems[0].Text},{item.SubItems[1].Text},{item.SubItems[2].Text},{item.SubItems[3].Text},{item.SubItems[4].Text}");
                        }
                    }
                    MessageBox.Show("Đã lưu hóa đơn ra file CSV!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
      
    }
}
