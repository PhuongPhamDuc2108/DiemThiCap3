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
    public partial class FormTimKiemHocSinh : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public FormTimKiemHocSinh()
        {
            InitializeComponent();
        }

        private void FormTimKiemHocSinh_Load(object sender, EventArgs e)
        {
            txtTim.Text = string.Empty;
            //Setup dgvHocSinh

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTim.Text = string.Empty;
        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "")
            {
                MessageBox.Show("Không để trống hộp tìm kiếm");
                txtTim.Focus();
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tHocSinh WHERE MaHS = N'" + txtTim.Text + "'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy học sinh với mã học sinh: " + txtTim.Text);
                    txtTim.Focus();
                }
                else
                {
                    dgvHocSinh.DataSource = dt;
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
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.Rows.Count == 0)
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
            exRange.Value = "Thông tin học sinh " + dgvHocSinh.Rows[0].Cells[0].Value.ToString();

            exSheet.Range["A4:A8"].Font.Size = 20;
            exSheet.Range["A4:A8"].Font.Bold = true;
            exSheet.Range["F4"].Value = "Mã học sinh: " + dgvHocSinh.Rows[0].Cells[0].Value.ToString();
            exSheet.Range["F5"].Value = "Họ tên học sinh: " + dgvHocSinh.Rows[0].Cells[1].Value.ToString();
            exSheet.Range["F6"].Value = "Ngày sinh: " + dgvHocSinh.Rows[0].Cells[2].Value.ToString();
            exSheet.Range["F7"].Value = "Giới tính: " + dgvHocSinh.Rows[0].Cells[3].Value.ToString();
            exSheet.Range["F8"].Value = "Mã lớp: " + dgvHocSinh.Rows[0].Cells[4].Value.ToString();

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

            DataTable dt = dtBase.ReadTable("SELECT * FROM tDiem WHERE MaHS = N'" + dgvHocSinh.Rows[0].Cells[0].Value.ToString() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                exSheet.Range["F" + (dong + i)].Value = dt.Rows[i][3].ToString();
                exSheet.Range["G" + (dong + i)].Value = dt.Rows[i][4].ToString();
                exSheet.Range["H" + (dong + i)].Value = dt.Rows[i][5].ToString();
                exSheet.Range["I" + (dong + i)].Value = dt.Rows[i][6].ToString();
                exSheet.Range["J" + (dong + i)].Value = dt.Rows[i][7].ToString();
            }
            exSheet.Range["I23"].Value = "Điểm trung bình tổng: " + dgvHocSinh.CurrentRow.Cells[6].Value.ToString();
            exSheet.Range["I24"].Value = "Xếp loại: " + dgvHocSinh.CurrentRow.Cells[5].Value.ToString();

            exSheet.Name = "Thongtinhocsinh";
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
