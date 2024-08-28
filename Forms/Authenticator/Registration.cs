using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.Forms.Authenticator
{
    public partial class Registration : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Không được để trống tên tài khoản");
                textBox1.Focus();
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Không được để trống mật khẩu");
                textBox2.Focus();
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống chức vụ");
                textBox2.Focus();
            }
            else
            {
                DataTable dt = dtBase.ReadTable("SELECT * FROM tUserLogin WHERE userName = N'" + textBox1.Text + "'");
                if(dt.Rows.Count == 0)
                {
                    int selectedIndex = comboBox1.SelectedIndex;
                    dtBase.DataUpdate("INSERT tUserLogIn VALUES(N'"+textBox1.Text+"', N'"+ textBox2.Text +"', N'"+ comboBox1.Items[selectedIndex].ToString() +"')");
                    Form1.chucVu = comboBox1.Items[selectedIndex].ToString();
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại tài khoản!");
                    textBox1.Focus();
                }
                
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Học sinh");
            comboBox1.Items.Add("Giáo viên");
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            
        }
    }
}
