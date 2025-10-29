using Ministore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore
{
    public partial class Ministore : Form
    {
        
        public Ministore()
        {
            InitializeComponent();
            // events
           
            this.SizeChanged += Ministore_SizeChanged;
            this.IsMdiContainer = true;
            this.MdiChildActivate += FormMain_MdiChildActivate;

            timerClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initial status
            
            tsslForm.Text = "Form hiện tại: ";
            timerClock.Start();

            // Gán notify icon context menu (Restore, Exit)
            if (notifyIconTray != null && notifyIconTray.ContextMenuStrip == null)
            {
                var cms = new ContextMenuStrip();
                var mRestore = new ToolStripMenuItem("Khôi phục");
                var mExit = new ToolStripMenuItem("Thoát");
                mRestore.Click += (s, ev) => RestoreFromTray();
                mExit.Click += (s, ev) => Application.Exit();
                cms.Items.Add(mRestore);
                cms.Items.Add(new ToolStripSeparator());
                cms.Items.Add(mExit);
                notifyIconTray.ContextMenuStrip = cms;
            }

            // Gán sự kiện cho menu
            đăngNhậpToolStripMenuItem.Click += (s, ev) => ShowLoginDialog();
            đăngXuấtToolStripMenuItem.Click += (s, ev) => DoLogout();
            thoátToolStripMenuItem.Click += (s, ev) => Close();
            giớiThiệuToolStripMenuItem.Click += (s, ev) => MessageBox.Show("Ứng dụng quản lý Mini Store.\nPhiên bản 1.0");
            liênHệToolStripMenuItem.Click += (s, ev) => MessageBox.Show("Liên hệ: support@ministore.vn");
            sảnPhẩmToolStripMenuItem.Click += (s, ev) => OpenFormProduct();
            

            // Gán sự kiện cho ToolStrip
            tsbLogin.Click += (s, ev) => đăngNhậpToolStripMenuItem.PerformClick();
            tsbLogout.Click += (s, ev) => đăngXuấtToolStripMenuItem.PerformClick();
            tsbExit.Click += (s, ev) => Close();
            tsbProduct.Click += (s, ev) => sảnPhẩmToolStripMenuItem.PerformClick();
            
            //Gán logo
            pictureBox1.Image = BTVN_3.Properties.Resources.logo;

            
        }

        private void Ministore_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                if (notifyIconTray != null)
                {
                    notifyIconTray.Visible = true;
                    notifyIconTray.ShowBalloonTip(700, "MiniStore", "Ứng dụng đã thu nhỏ vào khay hệ thống", ToolTipIcon.Info);
                }
            }
        }
        private void notifyIconTray_MouseDoubleClick(object sender, EventArgs e)
        {
            RestoreFromTray();
        }



        private void TimerClock_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void ToolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var text = toolStripTextBoxSearch.Text;
            // If the active MDI child implements ISearchable, forward the text
            if (this.ActiveMdiChild is ISearchable searchable)
            {
                searchable.ApplySearch(text);
            }
        }
        // Khi MDI child thay đổi (mở / active / close), update label form hiện tại
        private void FormMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                tsslForm.Text = "Form hiện tại: " + this.ActiveMdiChild.Text;
                
            }
            else
            {
                tsslForm.Text = "Form hiện tại: -";
            }
        }
        private void SetCurrentFormLabel(string formName)
        {
            if (string.IsNullOrEmpty(formName) || formName == "-")
                tsslForm.Text = "Form hiện tại: -";
            else
                tsslForm.Text = $"Form hiện tại: {formName}";
        }
        private void ShowLoginDialog()
        {
            using (var dlg = new global::Ministore.SimpleLoginDialog())
            {
                var res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var username = dlg.UserName?.Trim();
                    if (string.IsNullOrEmpty(username)) username = "(không tên)";
                    tsslUser.Text = $"Người dùng: {username}";
                }
            }
        }
        private void DoLogout()
        {
            tsslUser.Text = "Người dùng: (chưa đăng nhập)";
        }

        private void OpenFormProduct()
        {
            // Kiểm tra nếu form đã mở thì kích hoạt nó thay vì mở mới
            foreach (Form f in this.MdiChildren)
            {
                if (f is FormProduct)
                {
                    f.Activate();
                    return;
                }
            }

            // Nếu chưa có thì mở mới
            var frm = new FormProduct();
            frm.MdiParent = this;
            frm.Text = "Quản lý sản phẩm"; // Tên hiển thị trên thanh tiêu đề
            frm.Show();

            // Cập nhật StatusStrip
            tsslForm.Text = "Form hiện tại: " + frm.Text;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployee f = new FormEmployee();
            f.MdiParent = this;
            f.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduct f = new FormProduct();
            f.MdiParent = this;
            f.Show();
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInvoice f = new FormInvoice();
            f.MdiParent = this;
            f.Show();
        }

        private void RestoreFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            if (notifyIconTray != null) notifyIconTray.Visible = false;
        }
        
    }
}
