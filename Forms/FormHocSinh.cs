using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaiTapLon.Forms
{
    public partial class FormHocSinh : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormHocSinh()
        {
            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void ResetValue()
        {
            txtHoTenHS.Text = string.Empty;
            txtMaHocSinh.Text = string.Empty;
            comboBoxMaLop.Text = string.Empty;
            richtxtGhiChu.Text = string.Empty;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            dtpNgaySinh.Checked = false;
        }

        private void FormHocSinh_Load(object sender, EventArgs e)
        {
            DataTable dtHocSinh = dtBase.ReadTable("SELECT * FROM tHocSinh");
            dgvHocSinh.DataSource = dtHocSinh;

            //Setup dgvHocSinh
            dgvHocSinh.Columns[0].HeaderText = "Mã học sinh";
            dgvHocSinh.Columns[1].HeaderText = "Họ và tên";
            dgvHocSinh.Columns[2].HeaderText = "Ngày sinh";
            dgvHocSinh.Columns[3].HeaderText = "Giới tính";
            dgvHocSinh.Columns[4].HeaderText = "Mã lớp";
            dgvHocSinh.Columns[5].HeaderText = "Xếp loại";
            dgvHocSinh.Columns[6].HeaderText = "DTB";
            dgvHocSinh.Columns[7].HeaderText = "Ghi chú";
            dgvHocSinh.Columns[0].Width = 100;
            dgvHocSinh.Columns[1].Width = 110;
            dgvHocSinh.Columns[2].Width = 80;
            dgvHocSinh.Columns[3].Width = 80;
            dgvHocSinh.Columns[4].Width = 80;
            dgvHocSinh.Columns[5].Width = 90;
            dgvHocSinh.Columns[7].Width = 150;

            dtHocSinh.Dispose();

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
            comboBoxMaLop.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            comboBoxMaLop.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaHocSinh.Text == "")
            {
                MessageBox.Show("Không được để trống mã học sinh");
                txtMaHocSinh.Focus();
            }
            else
            {
                if(txtHoTenHS.Text == "")
                {
                    MessageBox.Show("Không được để trống tên học sinh");
                    txtMaHocSinh.Focus();
                }
                else if(rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    MessageBox.Show("Nhập giới tính học sinh");
                    return;
                }
                else
                {
                    DataTable dt = dtBase.ReadTable("SELECT * FROM tHocSinh WHERE MaHS='"+ txtMaHocSinh.Text +"'");

                    string gioitinh = "";
                    if (rdoNam.Checked == true)
                    {
                        gioitinh = rdoNam.Text;
                    }
                    else
                    {
                        gioitinh = rdoNu.Text;
                    }

                    DateTime dateNgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);

                    if (dt.Rows.Count == 0)
                    {
                        dtBase.DataUpdate("INSERT INTO tHocSinh(MaHS,TenHS, NgaySinh, GioiTinh, MaLop, GhiChu) VALUES(N'" + txtMaHocSinh.Text + "', N'" + txtHoTenHS.Text + "', " +
                            "N'"+ String.Format("{0:MM/dd/yyyy}", dateNgaySinh) + "', N'"+ gioitinh +"', N'" + comboBoxMaLop.SelectedValue + "', N'" + richtxtGhiChu.Text + "')");
                        dgvHocSinh.DataSource = dtBase.ReadTable("SELECT * FROM tHocSinh");
                    }
                    else
                    {
                        MessageBox.Show("Mã học sinh đã tồn tại");
                        txtMaHocSinh.Focus();
                    }    
                }
            }
        }

        private void comboBoxMaLop_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("select * from tLop");
            ft.FillComboBox(dt, comboBoxMaLop, "MaLop", "TenLop");
        }

        private void comboBoxMaLop_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "HS" + comboBoxMaLop.SelectedValue.ToString();
            txtMaHocSinh.Text = ft.MaHSAutoGenerator("tHocSinh", str, "MaHS");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if(txtMaHocSinh.Text == "")
            {
                MessageBox.Show("Thông tin học sinh đang để trống!");
                return;
            }
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 8]; // tro vao o A1
            exRange.Font.Size = 32;
            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "Thông tin học sinh " + txtMaHocSinh.Text;

            string gioitinh = "";
            if (rdoNam.Checked == true)
            {
                gioitinh = rdoNam.Text;
            }
            else
            {
                gioitinh = rdoNu.Text;
            }

            exSheet.Range["A4:A8"].Font.Size = 20;
            exSheet.Range["A4:A8"].Font.Bold = true;
            exSheet.Range["F4"].Value = "Mã học sinh: " + txtMaHocSinh.Text;
            exSheet.Range["F5"].Value = "Họ tên học sinh: " + txtHoTenHS.Text;
            exSheet.Range["F6"].Value = "Ngày sinh: " + dtpNgaySinh.Text;
            exSheet.Range["F7"].Value = "Giới tính: " + gioitinh;

            //in dong tieu de
            exSheet.Range["F11:J11"].Font.Size = 12;
            exSheet.Range["F11:J11"].Font.Bold = true;
            exSheet.Range["F11"].Value = "Hệ số 1";
            exSheet.Range["G11"].Value = "Hệ số 2";
            exSheet.Range["H11"].Value = "Hệ số 3";
            exSheet.Range["I11"].Value = "ĐTB Tổng";
            exSheet.Range["I11"].ColumnWidth = 15;
            exSheet.Range["J11"].Value = "Xếp loại";
            exSheet.Range["E12"].Value = "Toán";
            exSheet.Range["E13"].Value = "Anh";
            exSheet.Range["E14"].Value = "Văn";
            exSheet.Range["E15"].Value = "Địa Lý";
            exSheet.Range["E16"].Value = "GDCD";
            exSheet.Range["E17"].Value = "GDQP";
            exSheet.Range["E18"].Value = "Hoá Học";
            exSheet.Range["E19"].Value = "Lịch Sử";
            exSheet.Range["E20"].Value = "Sinh Học";
            exSheet.Range["E21"].Value = "Vật Lý";
            //luu so dong de bdau in
            int dong = 12;

            DataTable dt = dtBase.ReadTable("SELECT * FROM tDiem WHERE MaHS = N'" + txtMaHocSinh.Text + "'");
            for(int i = 0; i < dt.Rows.Count; i ++)
            {
                exSheet.Range["F" + (dong+i)].Value = dt.Rows[i][3].ToString();
                exSheet.Range["G" + (dong+i)].Value = dt.Rows[i][4].ToString();
                exSheet.Range["H" + (dong+i)].Value = dt.Rows[i][5].ToString();
                exSheet.Range["I" + (dong+i)].Value = dt.Rows[i][6].ToString();
                exSheet.Range["J" + (dong+i)].Value = dt.Rows[i][7].ToString();
            }
            exSheet.Range["I23"].Value = "Điểm trung bình tổng: " + dgvHocSinh.CurrentRow.Cells[6].Value.ToString();
            exSheet.Range["I24"].Value = "Xếp loại: " + dgvHocSinh.CurrentRow.Cells[5].Value.ToString();

            exSheet.Name = "Thongtinhocsinh";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 WorkBook| *.xls| Excel WorkBook | *.xlsx| All Files | *.*";
            save.FilterIndex = 2;
            if(save.ShowDialog()==DialogResult.OK)
                exBook.SaveAs(save.FileName.ToLower());
            exApp.Quit();
        }

        private void FormHocSinh_Click(object sender, EventArgs e)
        {

        }

        private void dgvHocSinh_Click(object sender, EventArgs e)
        {
            txtMaHocSinh.Text = dgvHocSinh.CurrentRow.Cells[0].Value.ToString();
            txtHoTenHS.Text = dgvHocSinh.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvHocSinh.CurrentRow.Cells[2].Value;
            _ = dgvHocSinh.CurrentRow.Cells[3].Value.ToString() == "Nam" ? rdoNam.Checked = true : rdoNu.Checked = true;
            comboBoxMaLop.Text = dgvHocSinh.CurrentRow.Cells[4].Value.ToString();

            richtxtGhiChu.Text = dgvHocSinh.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHocSinh.Text == "")
            {
                MessageBox.Show("Không được để trống mã học sinh");
                txtMaHocSinh.Focus();
            }
            else
            {
                if (txtHoTenHS.Text == "")
                {
                    MessageBox.Show("Không được để trống tên học sinh");
                    txtMaHocSinh.Focus();
                }
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    MessageBox.Show("Không để trống giới tính học sinh");
                    return;
                }
                else
                {
                    string gioitinh = "";
                    if (rdoNam.Checked == true)
                    {
                        gioitinh = rdoNam.Text;
                    }
                    else
                    {
                        gioitinh = rdoNu.Text;
                    }
                    DateTime dateNgaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
                    dtBase.DataUpdate("UPDATE tHocSinh SET TenHS = N'" + txtHoTenHS.Text + "', NgaySinh = CAST(" +
                            "N'" + String.Format("{0:MM/dd/yyyy}", dateNgaySinh) + "' AS DATETIME), GioiTinh = N'" + gioitinh + "'," +
                            " MaLop =  N'" + comboBoxMaLop.Text + "', GhiChu = N'" + richtxtGhiChu.Text + "' WHERE MaHS = N'" + txtMaHocSinh.Text + "'");
                    dgvHocSinh.DataSource = dtBase.ReadTable("SELECT * FROM tHocSinh");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.DataUpdate("DELETE tHocSinh WHERE MaHS='" + txtMaHocSinh.Text + "'");
                dgvHocSinh.DataSource = dtBase.ReadTable("Select * from tHocSinh");
            }
        }
    }
}
/*ve hoc them in exdel, dang nhap, tim kiem*/