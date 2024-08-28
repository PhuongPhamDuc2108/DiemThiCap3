using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.Forms
{
    public partial class FormLop : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormLop()
        {
            InitializeComponent();
        }

        void ResetData()
        {
            txtMaLop.Text = string.Empty;
            txtTenLop.Text = string.Empty; 
        }

        private void FormLop_Load(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tLop");
            dgvLop.DataSource = dt;

            dgvLop.Columns[0].HeaderText = "Mã lớp";
            dgvLop.Columns[1].HeaderText = "Tên lớp";
            dgvLop.Columns[1].HeaderText = "GVCN";
            dgvLop.Columns[0].Width = 150;
            dgvLop.Columns[1].Width = 150;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetData();
            btnLuu.Enabled = true;
            txtMaLop.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaLop.Text == "")
            {
                MessageBox.Show("Không được để trống mã lớp");
                txtMaLop.Focus();
            }
            else
            {
                if(txtTenLop.Text == "")
                {
                    MessageBox.Show("Không được để trống tên lớp");
                    txtTenLop.Focus();
                }

                else
                {
                    DataTable dataCoSan = dtBase.ReadTable("SELECT * FROM tLop WHERE MaLop ='" + txtMaLop.Text+"'");
                    if(dataCoSan.Rows.Count == 0)
                    {
                        dtBase.DataUpdate("INSERT INTO tLop(MaLop, TenLop) VALUES(N'" + txtMaLop.Text + "', N'" + txtTenLop.Text + "')");
                        dgvLop.DataSource = dtBase.ReadTable("SELECT * FROM tLop");
                    }
                    else
                    {
                        MessageBox.Show("Mã lớp này đã tồn tại. Bạn phải nhập mã khác");
                        txtMaLop.Focus();
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxGVCN_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
