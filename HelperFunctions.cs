using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public class HelperFunctions
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public void FillComboBox(DataTable dt, ComboBox cb, string display, string value)
        {
            cb.DataSource = dt;
            cb.DisplayMember = display;
            cb.ValueMember = value;
        }

        public string MaHSAutoGenerator(string tenBang, string maBatDau, string TruongMa)
        {
            int id = 1;
            bool dung = false;
            string ma = "";
            DataTable dataTable = new DataTable();
            while (dung == false)
            {
                dataTable = dtBase.ReadTable("SELECT * FROM " + tenBang + " WHERE " + TruongMa + " = " + "N'"+ maBatDau + id.ToString() +"'");
                if (dataTable.Rows.Count == 0)
                {
                    dung = true;
                }
                else
                {
                    id++;
                    dung = false;
                }
            }
            ma = maBatDau + id.ToString();
            return ma;
        }
    }
}
