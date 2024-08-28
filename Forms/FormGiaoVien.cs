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
    public partial class FormGiaoVien : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormGiaoVien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gioitinh = "";
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Không để trống giới tính giáo viên");
                return;
            }
            else if (rdoNam.Checked == false && rdoNu.Checked == true) gioitinh = "Nữ";
            else gioitinh = "Nam";

            if (txtMaGV.Text == "")
            {
                MessageBox.Show("Không để trống mã giáo viên");
                txtMaGV.Focus();
            }
            else if(txtTenGV.Text == "")
            {
                MessageBox.Show("Không để trống tên giáo viên");
                txtTenGV.Focus();
            }
            else if(txtDiaChi.Text == "")
            {
                MessageBox.Show("Không để trống địa chỉ giáo viên");
                txtDiaChi.Focus();
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien WHERE MaGV = N'" + txtMaGV.Text + "'");
                if(dt.Rows.Count == 0)
                {
                    dtBase.DataUpdate("INSERT INTO tGiaoVien(MaGV, TenGV, GioiTinh, DiaChi) VALUES(N'"+ txtMaGV.Text +"', N'"+ txtTenGV.Text +"', N'"+ gioitinh +"'," +
                        "N'"+ txtDiaChi.Text +"')");
                    dgvGiaoVien.DataSource = dtBase.ReadTable("SELECT * FROM tGiaoVien"); ;
                }
                else
                {
                    MessageBox.Show("Mã giáo viên đã tồn tại! Vui lòng nhập mã khác");
                    txtMaGV.Focus();
                }
            }
        }

        void ResetData ()
        {
            txtMaGV.Text = string.Empty;
            txtTenGV.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }

        private void FormGiaoVien_Load(object sender, EventArgs e)
        {
            ResetData();
            txtMaGV.Enabled = false;
            txtTenGV.Enabled = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien");
            dgvGiaoVien.DataSource = dt;
            dgvGiaoVien.Columns[0].HeaderText = "Mã giáo viên";
            dgvGiaoVien.Columns[1].HeaderText = "Tên giáo viên";
            dgvGiaoVien.Columns[2].HeaderText = "Giới tính";
            dgvGiaoVien.Columns[3].HeaderText = "Địa chỉ";
            dgvGiaoVien.Columns[4].HeaderText = "Tổ";
        }

        private void comboBoxToMon_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            ResetData();
            btnLuu.Enabled = true;
            txtMaGV.Enabled = true;
            txtTenGV.Enabled = true;
        }

        private void comboBoxMaLop_Click(object sender, EventArgs e)
        {
            
        }
    }
}
