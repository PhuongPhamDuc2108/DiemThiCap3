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
    public partial class FormDiem : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormDiem()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }
        
        void ResetValue()
        {

            txtMaMH.Text = string.Empty;
            txtDiemHS1.Text = string.Empty;
            txtDiemHS2.Text = string.Empty;
            txtDiemHS3.Text = string.Empty;
            comboBoxMonHoc.Text = string.Empty;
        }

        private void FormDiem_Load(object sender, EventArgs e)
        {
            ResetValue();
            DataTable dt = dtBase.ReadTable("SELECT * FROM tMonHoc");
            ft.FillComboBox(dt, comboBoxMonHoc, "MaMH", "TenMH");
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;

            txtMaMH.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            ResetValue();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (comboBoxMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Không bỏ trống môn học");
                return;
            }
            else if(txtMaHS.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã học sinh");
                txtMaHS.Focus();
            }
            else if (txtDiemHS1.Text == "")
            {
                MessageBox.Show("Không bỏ trống điểm hệ số 1");
                txtDiemHS1.Focus();
            }
            else if (txtDiemHS2.Text == "")
            {
                MessageBox.Show("Không bỏ trống điểm hệ số 2");
                txtDiemHS2.Focus();
            }
            else if (txtDiemHS3.Text == "")
            {
                MessageBox.Show("Không bỏ trống điểm hệ số 3");
                txtDiemHS3.Focus();
            }
            else
            {
                DataTable hs = dtBase.ReadTable("SELECT * FROM tHocSinh where MaHS = N'" + txtMaHS.Text + "'");
                if(hs.Rows.Count > 0)
                {
                    DataTable dt = dtBase.ReadTable("SELECT * FROM tDiem WHERE TenMH='" + comboBoxMonHoc.SelectedValue.ToString() + "' AND MaHS='" + txtMaHS.Text + "'");
                    if (dt.Rows.Count == 0)
                    {
                        double dtbhocky = 0;
                        string xepLoai = "";
                        dtbhocky = (Convert.ToDouble(txtDiemHS1.Text) + Convert.ToDouble(txtDiemHS2.Text) * 2 + Convert.ToDouble(txtDiemHS3.Text) * 3) / 6.0;
                        if (dtbhocky >= 9) xepLoai = "Xuất Sắc";
                        else if (dtbhocky >= 8) xepLoai = "Giỏi";
                        else if (dtbhocky >= 6.5) xepLoai = "Khá";
                        else xepLoai = "Trung Bình";

                        dtBase.DataUpdate("INSERT INTO tDiem VALUES(N'" + comboBoxMonHoc.SelectedValue.ToString() + "', N'" + txtMaHS.Text + "', N'" + txtMaMH.Text + "', "
                             + Convert.ToDecimal(txtDiemHS1.Text) + "," + Convert.ToDecimal(txtDiemHS2.Text) + "," + Convert.ToDecimal(txtDiemHS3.Text) + "," + Convert.ToDecimal(dtbhocky) + ", N'" + xepLoai + "')");
                        MessageBox.Show("Nhập điểm thành công!");
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Học sinh không tồn tại mã đã có điểm môn " + comboBoxMonHoc.SelectedValue + "! Vui lòng chọn mục sửa điểm");
                        comboBoxMonHoc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại học sinh với mã: " + txtMaHS.Text);
                    txtMaHS.Focus();
                }
            }
        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaMH.Text = comboBoxMonHoc.SelectedValue.ToString();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
