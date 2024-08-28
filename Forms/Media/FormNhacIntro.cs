using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.Forms.Media
{
    public partial class FormNhacIntro : Form
    {
        OpenFileDialog openFileDialog;
        string[] filePaths;
        string[] fileNames;
        public FormNhacIntro()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            //    OpenFileDialog.Filter
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openFileDialog.FileNames; //lay cai duong dan
                fileNames = openFileDialog.SafeFileNames; // lay ten cua file
                foreach (var item in fileNames)
                {
                    this.lsbDanhSachPhat.Items.Add(item);
                }
            }
        }

        private void lsbDanhSachPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbDanhSachPhat.SelectedIndex != -1)
            {
                int choose = lsbDanhSachPhat.SelectedIndex;
                axWindowsMediaPlayer1.URL = filePaths[choose];
                this.textBox1.Text = fileNames[choose];
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNhacIntro_FormClosed(object sender, FormClosedEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
