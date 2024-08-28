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
    public partial class FormQuenMatKhau : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tUserLogIn WHERE userName = N'" + txtTimKiem.Text + "'");
            if(dt.Rows.Count == 0)
            {
                labelTKkotontai.Text = "Tài khoản không tồn tại";
            }
            else
            {
                MessageBox.Show("Mật khẩu của tài khoản " + txtTimKiem.Text + " là: " + dt.Rows[0][1].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
