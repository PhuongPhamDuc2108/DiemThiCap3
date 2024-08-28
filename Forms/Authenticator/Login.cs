using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.Forms.Authenticator
{
    public partial class Login : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tUserLogIn WHERE userName = N'"+ txtUserName.Text +"'");
            if(dt.Rows.Count == 0)
            {
                labelSaiUserName.Text = "Không tồn tại tài khoản " + txtUserName.Text;
                labelSaiPassword.Text = string.Empty;
                labelQuenMatKhau.Text = string.Empty;
            }
            else if(dt.Rows.Count == 1)
            {
                labelSaiUserName.Text = string.Empty;
                if (txtPassWord.Text.Trim() != dt.Rows[0][1].ToString().Trim())
                {
                    labelSaiPassword.Text = "Sai mật khẩu";
                    labelQuenMatKhau.Text = "Quên mật khẩu? Bấm để tìm lại";
                }
                else
                {
                    Form1.userName = txtUserName.Text;
                    Form1.chucVu = dt.Rows[0][2].ToString();
                    this.Close();
                }
            }
        }

        private void labelQuenMatKhau_Click(object sender, EventArgs e)
        {
            FormQuenMatKhau formQuen = new FormQuenMatKhau();
            formQuen.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration formRes = new Registration();
            formRes.ShowDialog();
        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                button3_Click(sender, e);
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                button3_Click(sender, e);
            }
        }
    }
}
