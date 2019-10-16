using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class DetailForm : Form
    {
        public string MSSV { get; set; }
        public delegate void MyDel(SV[] arr);
        public MyDel d;
        public DetailForm(string m, MyDel dd)
        {
            InitializeComponent();
            this.MSSV = m;
            this.d = dd;
            ShowDetail();
        }
        public void ShowDetail()
        {
            if ( this.MSSV != "" )
            {
                // edit
                SV s = MainForm.db.GetSV(this.MSSV);
                textMSSV.Text = s.MSSV;
                textName.Text = s.Name;
                textKhoa.Text = s.Khoa;
                textDHT.Text = s.DHT.ToString();
                if (s.gender)
                    radioButtonMale.Select();
                else radioButtonFemale.Select();
                dateTimeBirthDay.Value =  s.Birthday;
            }
            else
            {
                //add
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Khoi tao doi tuong SV voi thuoc tinh lay tu giao dien
            SV s = new SV() {
                MSSV = textMSSV.Text,
                Name = textName.Text,
                Khoa = textKhoa.Text, DHT = Double.Parse(textDHT.Text),
                gender = (radioButtonMale.Checked),
                Birthday = dateTimeBirthDay.Value
            };
            if ( MainForm.db.IndexOf(s) >= 0)
            {
                // edit
                MainForm.db.listSV[MainForm.db.IndexOf(s)] = s;
            }
            else
            {
                // add
                MainForm.db.Add(s);
            }
           
            d(MainForm.db.listSV);
            this.Close();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
