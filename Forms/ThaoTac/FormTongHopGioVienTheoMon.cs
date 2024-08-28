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
    public partial class FormTongHopGioVienTheoMon : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormTongHopGioVienTheoMon()
        {
            InitializeComponent();
        }

        private void FormTongHopGioVienTheoMon_Load(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tMonHoc");
            ft.FillComboBox(dt, comboBox1, "MaMH", "TenMH");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Không để trống thông tin môn học");
                return;
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien WHERE MaMH = N'" + comboBox1.SelectedValue.ToString() + "'");
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có giáo viên nào dạy môn " + comboBox1.SelectedValue.ToString());
                    return;
                }
                else
                {
                    dgvGiaoVien.DataSource = dt;

                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = "";
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Thông tin giáo viên đang để trống!");
                return;
            }
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 5]; // tro vao o A1
            exRange.Font.Size = 32;
            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "Thông tin các giáo viên môn " + dgvGiaoVien.Rows[0].Cells[4].Value.ToString();


            exSheet.Range["A4:A8"].Font.Size = 20;
            exSheet.Range["A4:A8"].Font.Bold = true;
            //in dong tieu de
            exSheet.Range["D3"].Value = "Mã giáo viên";
            exSheet.Range["D3"].ColumnWidth = 15;
            exSheet.Range["E3"].Value = "Họ tên giáo viên";
            exSheet.Range["E3"].ColumnWidth = 20;
            exSheet.Range["F3"].Value = "Giới tính";
            exSheet.Range["G3"].Value = "Địa chỉ";
            exSheet.Range["G3"].ColumnWidth = 26;
            exSheet.Range["H3"].Value = "Dạy môn";
            exSheet.Range["I3"].Value = "Chủ nhiệm lớp";
            //luu so dong de bdau in
            int dong = 4;
            DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien WHERE MaMH = N'"+ comboBox1.SelectedValue.ToString() +"'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                exSheet.Range["D" + (dong + i)].Value = dt.Rows[i][0].ToString();
                exSheet.Range["E" + (dong + i)].Value = dt.Rows[i][1].ToString();
                exSheet.Range["F" + (dong + i)].Value = dt.Rows[i][2].ToString();
                exSheet.Range["G" + (dong + i)].Value = dt.Rows[i][3].ToString();
                exSheet.Range["H" + (dong + i)].Value = dt.Rows[i][4].ToString();
                exSheet.Range["I" + (dong + i)].Value = dt.Rows[i][5].ToString();
            }

            exSheet.Name = "Thongtinhgiaovien";
            exBook.Activate();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 WorkBook| *.xls| Excel WorkBook | *.xlsx| All Files | *.*";
            save.FilterIndex = 2;
            if (save.ShowDialog() == DialogResult.OK)
                exBook.SaveAs(save.FileName.ToLower());
            exApp.Quit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
