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
    public partial class FormVideo : Form
    {
        string videoPath, videoTitle;
        public FormVideo()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void FormVideo_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Khuôn viên trường");
            comboBox1.Items.Add("Một ngày đi học");
            comboBox1.Items.Add("Các hoạt động khoa học");
        }

        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.play();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.pause();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.stop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                wmpVideo.URL = "D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\video\\gioithieu.mp4";
                System.IO.StreamReader sr = new System.IO.StreamReader("D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\text\\khuonvien.txt");
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                wmpVideo.URL = "D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\video\\aday.mp4";
                System.IO.StreamReader sr = new System.IO.StreamReader("D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\text\\aday.txt");
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                wmpVideo.URL = "D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\video\\khoahoc.mp4";
                System.IO.StreamReader sr = new System.IO.StreamReader("D:\\LTTQ\\BAITAPLON-20240828T071555Z-001\\BAITAPLON\\text\\lab.txt");
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            comboBox1.Items.Clear();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Khuôn viên trường");
            comboBox1.Items.Add("Một ngày đi học");
            comboBox1.Items.Add("Các hoạt động khoa học");
        }

        private void FormVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            wmpVideo.Ctlcontrols.stop();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "MP4 File| *.mp4|All File|*.*" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                videoPath = openFileDialog.FileName;
                videoTitle = openFileDialog.SafeFileName;
                wmpVideo.URL = videoPath;
            }
        }
    }
}
