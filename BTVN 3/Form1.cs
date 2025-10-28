using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ministore
{
    public partial class FormEmployee : Form
    {
       
        public FormEmployee()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ten = txtTen.Text.Trim();
            var chucVu = txtChucVu.Text.Trim();
            if (!decimal.TryParse(txtLuong.Text.Trim(), out var luong))
            {
                MessageBox.Show("Lương phải là số.");
                return;
            }

            // thêm 1 dòng tương ứng với thứ tự cột trong Designer
            dgvNhanVien.Rows.Add(ten, chucVu, luong.ToString("N0"));
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtTen.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                dgvNhanVien.Rows.RemoveAt(dgvNhanVien.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0) return;
            var row = dgvNhanVien.SelectedRows[0];
            row.Cells[0].Value = txtTen.Text.Trim();       // cột 0 = Tên
            row.Cells[1].Value = txtChucVu.Text.Trim();    // cột 1 = Chức vụ
            row.Cells[2].Value = txtLuong.Text.Trim();     // cột 2 = Lương
            dgvNhanVien.ClearSelection();
            ClearInputs();

        }

       

    }
}
