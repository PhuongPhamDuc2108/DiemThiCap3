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

namespace BaiTapLon.Forms.ThaoTac
{
    public partial class FormTongHopHocSinhTheoLop : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormTongHopHocSinhTheoLop()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Không để trống tên lớp");
                return;
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT MaHS, TenHS, NgaySinh, GioiTinh, tHocSinh.MaLop, XepLoai, DTB, GhiChu FROM tHocSinh INNER JOIN tLop" +
                    " ON tHocSinh.MaLop = tLop.MaLop WHERE tHocSinh.MaLop = N'" + comboBox1.SelectedValue.ToString() + "' ");
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

        private void FormTongHopHocSinhTheoLop_Load(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tLop");
            ft.FillComboBox(dt, comboBox1, "MaLop", "TenLop");
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
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
            exRange.Value = "Thông tin lớp " + dgvHocSinh.Rows[0].Cells[4].Value.ToString();

            
            exSheet.Range["A4:A8"].Font.Size = 20;
            exSheet.Range["A4:A8"].Font.Bold = true;
            //in dong tieu de
            exSheet.Range["B3"].Value = "Mã học sinh";
            exSheet.Range["B3"].ColumnWidth = 12;
            exSheet.Range["C3"].Value = "Họ tên học sinh";
            exSheet.Range["C3"].ColumnWidth = 18;
            exSheet.Range["D3"].Value = "Ngày sinh";
            exSheet.Range["D3"].ColumnWidth = 15;
            exSheet.Range["E3"].Value = "Giới tính";
            exSheet.Range["F3"].Value = "Mã lớp";
            exSheet.Range["F11:J11"].Font.Size = 12;
            exSheet.Range["F11:J11"].Font.Bold = true;
            exSheet.Range["G3"].Font.Size = 32;
            exSheet.Range["G3"].Font.Bold = true;
            exSheet.Range["G3"].Font.Color = Color.Blue;
            exSheet.Range["G3"].Value = "Điểm trung bình các môn";
            exSheet.Range["G4"].Value = "Toán";
            exSheet.Range["H4"].Value = "Anh";
            exSheet.Range["I4"].Value = "Văn";
            exSheet.Range["J4"].Value = "Địa Lý";
            exSheet.Range["K4"].Value = "GDCD";
            exSheet.Range["L4"].Value = "GDQP";
            exSheet.Range["M4"].Value = "Hoá Học";
            exSheet.Range["N4"].Value = "Lịch Sử";
            exSheet.Range["O4"].Value = "Sinh Học";
            exSheet.Range["P4"].Value = "Vật Lý";
            exSheet.Range["Q3"].Value = "Xếp loại";
            exSheet.Range["R3"].Value = "ĐTB Tổng";
            //luu so dong de bdau in
            int dong = 5;
            int count = 0;
            double tongDiem = 0;
            DataTable dtHS = dtBase.ReadTable("SELECT * FROM tHocSinh WHERE tHocSinh.MaLop = N'"+comboBox1.SelectedValue.ToString()+"'");
            for (int i = 0; i < dtHS.Rows.Count; i++)
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tDiem WHERE MaHS = N'"+ dtHS.Rows[i][0] +"'");
                exSheet.Range["B" + (dong + i)].Value = dtHS.Rows[i][0].ToString();
                exSheet.Range["C" + (dong + i)].Value = dtHS.Rows[i][1].ToString();
                exSheet.Range["D" + (dong + i)].Value = dtHS.Rows[i][2].ToString();
                exSheet.Range["E" + (dong + i)].Value = dtHS.Rows[i][3].ToString();
                exSheet.Range["F" + (dong + i)].Value = dtHS.Rows[i][4].ToString();
                exSheet.Range["Q" + (dong + i)].Value = dtHS.Rows[i][5].ToString();
                exSheet.Range["R" + (dong + i)].Value = dtHS.Rows[i][6].ToString();
                Console.WriteLine(dtHS.Rows[i][0]);
                int soDong = 0;
                try
                {
                    exSheet.Range["G" + (dong + i)].Value = dt.Rows[soDong][6].ToString();
                    exSheet.Range["H" + (dong + i)].Value = dt.Rows[soDong + 1][6].ToString();
                    exSheet.Range["I" + (dong + i)].Value = dt.Rows[soDong + 2][6].ToString();
                    exSheet.Range["J" + (dong + i)].Value = dt.Rows[soDong + 3][6].ToString();
                    exSheet.Range["K" + (dong + i)].Value = dt.Rows[soDong + 4][6].ToString();
                    exSheet.Range["L" + (dong + i)].Value = dt.Rows[soDong + 5][6].ToString();
                    exSheet.Range["M" + (dong + i)].Value = dt.Rows[soDong + 6][6].ToString();
                    exSheet.Range["N" + (dong + i)].Value = dt.Rows[soDong + 7][6].ToString();
                    exSheet.Range["O" + (dong + i)].Value = dt.Rows[soDong + 8][6].ToString();
                    exSheet.Range["P" + (dong + i)].Value = dt.Rows[soDong + 9][6].ToString();
                } catch {
                    exSheet.Range["G" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["H" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["I" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["J" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["K" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["L" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["M" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["N" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["O" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["P" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["Q" + (dong + i)].Value = "Chưa tổng kết";
                    exSheet.Range["R" + (dong + i)].Value = "Chưa tổng kết";
                }
            }

            exSheet.Name = "Thongtinhocsinh";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 WorkBook| *.xls| Excel WorkBook | *.xlsx| All Files | *.*";
            save.FilterIndex = 2;
            if (save.ShowDialog() == DialogResult.OK)
                exBook.SaveAs(save.FileName.ToLower());
            exApp.Quit();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = "";
        }
    }
}
