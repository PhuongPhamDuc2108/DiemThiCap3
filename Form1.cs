using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class Form1 : Form
    {
        public static string userName = string.Empty;
        public static string chucVu = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void họcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormHocSinh formHocSinh = new Forms.FormHocSinh();
            formHocSinh.ShowDialog();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormLop formLop = new Forms.FormLop();
            formLop.ShowDialog();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormGiaoVien formGiaoVien = new Forms.FormGiaoVien();
            formGiaoVien.ShowDialog();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormDiem formDiem = new Forms.FormDiem();
            formDiem.ShowDialog();
        }

        private void tổToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormBan formBan = new Forms.FormBan();
            formBan.ShowDialog();
        }

        private void họcSinhTimKiemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.TimKiem.FormTimKiemHocSinh formTKHS= new Forms.TimKiem.FormTimKiemHocSinh();
            formTKHS.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Forms.Authenticator.Login formDN = new Forms.Authenticator.Login(); 
            formDN.ShowDialog();
            if(chucVu != "Giáo viên" && chucVu != "Học sinh")
            {
                label1.Text = "Xin chào Guest";
                họcSinhToolStripMenuItem.Enabled = false;
                điểmToolStripMenuItem.Enabled = false;
                lớpToolStripMenuItem.Enabled = false;
                giáoViênToolStripMenuItem.Enabled = false;
                tổToolStripMenuItem.Enabled = false;
            }
            else if(chucVu != "Giáo viên" && chucVu == "Học sinh")
            {
                label1.Text = "Xin chào học sinh " + userName;
                họcSinhToolStripMenuItem.Enabled = false;
                điểmToolStripMenuItem.Enabled = false;
                lớpToolStripMenuItem.Enabled = false;
                giáoViênToolStripMenuItem.Enabled = false;
                tổToolStripMenuItem.Enabled = false;
            }
            else
            {
                label1.Text += "Xin chào thày/cô " + userName;
            }    
        }

        private void giáoViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.TimKiem.FormTimKiemGiaoVien formGV = new Forms.TimKiem.FormTimKiemGiaoVien();
            formGV.ShowDialog();
        }

        private void tổngKếtTheoLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ThaoTac.FormTongHopHocSinhTheoLop formTongHopTheoLop = new Forms.ThaoTac.FormTongHopHocSinhTheoLop();
            formTongHopTheoLop.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Authenticator.Login formLogIn = new Forms.Authenticator.Login();  
            formLogIn.ShowDialog();
            if (chucVu != "Giáo viên")
            {
                label1.Text = "Xin chào học sinh " + userName;
                họcSinhToolStripMenuItem.Enabled = false;
                điểmToolStripMenuItem.Enabled = false;
                lớpToolStripMenuItem.Enabled = false;
                giáoViênToolStripMenuItem.Enabled = false;
                tổToolStripMenuItem.Enabled = false;
            }
            else
            {
                label1.Text = "Xin chào thày/cô " + userName;
                họcSinhToolStripMenuItem.Enabled = true;
                điểmToolStripMenuItem.Enabled = true;
                lớpToolStripMenuItem.Enabled = true;
                giáoViênToolStripMenuItem.Enabled = true;
                tổToolStripMenuItem.Enabled = true;
            }
        }

        private void danhSáchGVTheoMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ThaoTac.FormTongHopGioVienTheoMon formTongHopGioVienTheoMon = new Forms.ThaoTac.FormTongHopGioVienTheoMon();
            formTongHopGioVienTheoMon.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void videoHoạtĐộngCủaTrườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Media.FormVideo formVideo = new Forms.Media.FormVideo();
            formVideo.ShowDialog();
        }

        private void nhạcHoạtĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Media.FormNhacIntro formNhacIntro = new Forms.Media.FormNhacIntro();
            formNhacIntro.ShowDialog();
        }
    }
}
