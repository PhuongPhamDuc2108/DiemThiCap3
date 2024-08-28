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

namespace BaiTapLon.Forms.TimKiem
{
    public partial class FormTimKiemGiaoVien : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public FormTimKiemGiaoVien()
        {
            InitializeComponent();
        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "")
            {
                MessageBox.Show("Không để trống mã giáo viên");
                txtTim.Focus();
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien WHERE MaGV = N'" + txtTim.Text + "'");
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy giáo viên với mã giáo viên: " + txtTim.Text);
                    txtTim.Focus();
                }
                else
                {
                    dgvGiaoVien.DataSource = dt;
                    dgvGiaoVien.Columns[0].HeaderText = "Mã giáo viên";
                    dgvGiaoVien.Columns[1].HeaderText = "Họ và tên";
                    dgvGiaoVien.Columns[2].HeaderText = "Giới tính";
                    dgvGiaoVien.Columns[3].HeaderText = "Địa chỉ";
                    dgvGiaoVien.Columns[4].HeaderText = "Mã môn học";
                    dgvGiaoVien.Columns[5].HeaderText = "GVCN";
                    dgvGiaoVien.Columns[0].Width = 100;
                    dgvGiaoVien.Columns[1].Width = 110;
                    dgvGiaoVien.Columns[2].Width = 80;
                    dgvGiaoVien.Columns[3].Width = 100;
                    dgvGiaoVien.Columns[4].Width = 80;
                    dgvGiaoVien.Columns[5].Width = 90;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTim.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvGiaoVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin giáo viên");
                return;
            }
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 8]; // tro vao o A1
            exRange.Font.Size = 32;
            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "Thông tin giáo viên " + dgvGiaoVien.Rows[0].Cells[0].Value.ToString();

            exSheet.Range["A4:A8"].Font.Size = 20;
            exSheet.Range["A4:A8"].Font.Bold = true;
            exSheet.Range["F4"].Value = "Mã giáo viên: " + dgvGiaoVien.Rows[0].Cells[0].Value.ToString();
            exSheet.Range["F5"].Value = "Họ tên giáo viên: " + dgvGiaoVien.Rows[0].Cells[1].Value.ToString();
            exSheet.Range["F6"].Value = "Giới tính: " + dgvGiaoVien.Rows[0].Cells[2].Value.ToString();
            exSheet.Range["F7"].Value = "Địa chỉ: " + dgvGiaoVien.Rows[0].Cells[3].Value.ToString();
            exSheet.Range["F8"].Value = "Mã môn học: " + dgvGiaoVien.Rows[0].Cells[4].Value.ToString();
            exSheet.Range["F9"].Value = "GVCN: " + dgvGiaoVien.Rows[0].Cells[5].Value.ToString();

            exSheet.Name = "Thongtingiaovien";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 WorkBook| *.xls| Excel WorkBook | *.xlsx| All Files | *.*";
            save.FilterIndex = 2;
            if (save.ShowDialog() == DialogResult.OK)
                exBook.SaveAs(save.FileName.ToLower());
            exApp.Quit();
        }
    }
}
