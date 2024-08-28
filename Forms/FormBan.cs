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
    public partial class FormBan : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        HelperFunctions ft = new HelperFunctions();
        public FormBan()
        {
            InitializeComponent();
        }

        void ResetData()
        {
            txtSoTiet.Text = string.Empty;
        }

        private void FormBan_Load(object sender, EventArgs e)
        {
            ResetData();
            comboBoxMaGV.Enabled = false;
            comboBoxMaLop.Enabled = false;
            comboBoxMaMH.Enabled = false;   
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            DataTable dt = dtBase.ReadTable("SELECT * FROM tBan");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Mã giáo viên chủ nhiệm";
            dataGridView1.Columns[1].HeaderText = "Mã môn học";
            dataGridView1.Columns[2].HeaderText = "Mã lớp";
            dataGridView1.Columns[3].HeaderText = "Số tiết";
        }

        private void comboBoxMaGV_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tGiaoVien");
            ft.FillComboBox(dt, comboBoxMaGV, "MaGV", "MaGV");
        }

        private void comboBoxMaLop_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tLop");
            ft.FillComboBox(dt, comboBoxMaLop, "MaLop", "MaLop");
        }

        private void comboBoxMaMH_Click(object sender, EventArgs e)
        {
            DataTable dt = dtBase.ReadTable("SELECT * FROM tMonHoc");
            ft.FillComboBox(dt, comboBoxMaMH, "MaMH", "MaMH");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            comboBoxMaMH.Enabled = true;
            comboBoxMaLop.Enabled = true;
            comboBoxMaGV.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(comboBoxMaGV.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Không được để trống mã giáo viên");
                return;
            }
            else if(comboBoxMaLop.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Không được để trống mã lớp");
                return;
            }
            else if(comboBoxMaMH.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Không được để trống mã môn học");
                return;
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tBan WHERE MaGV=N'" + comboBoxMaGV.SelectedValue.ToString() + 
                    "' AND MaLop=N'"+ comboBoxMaLop.SelectedValue.ToString()+"'");
                DataTable dtMaGV = dtBase.ReadTable("SELECT * FROM tBan WHERE MaGV=N'" + comboBoxMaGV.SelectedValue.ToString() + "'");
                DataTable dtMaLop = dtBase.ReadTable("SELECT * FROM tBan WHERE MaLop=N'" + comboBoxMaLop.SelectedValue.ToString() + "'");
                if (dt.Rows.Count == 0 && dtMaLop.Rows.Count < 1 && dtMaGV.Rows.Count < 1)
                {
                    dtBase.DataUpdate("INSERT INTO tBan VALUES(N'" + comboBoxMaGV.SelectedValue.ToString() + "', N'"+ comboBoxMaMH.SelectedValue.ToString() +"'," +
                        "N'"+ comboBoxMaLop.SelectedValue.ToString() +"', N'"+ txtSoTiet.Text +"')");
                    dataGridView1.DataSource = dtBase.ReadTable("SELECT * FROM tBan");
                }
                else
                {
                    MessageBox.Show("1 giáo viên chỉ chủ nhiệm 1 lớp!");
                    return;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
