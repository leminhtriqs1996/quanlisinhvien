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
    public partial class MainForm : Form
    {
        public static QLSV db = new QLSV();
        public MainForm()
        {
            InitializeComponent();
            //db.CreateDB();
            DesignListView();
            ShowListView(db.listSV);
            GetComboBoxKhoa();
            GetComboBoxSort();


        }

        public void DesignListView()
        {
            //tao cac column cho ListView
            ColumnHeader ch = new ColumnHeader();
            ch.Text = "MSSV";
            ch.Width = 200;
            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "NAME";
            ch1.Width = 200;
            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "Khoa";
            ch2.Width = 200;
            listView1.Columns.Add(ch);
            listView1.Columns.Add(ch1);
            listView1.Columns.Add(ch2);
        }
        public void ShowListView(SV[] listSV)
        {
            //clear ListView truoc khi hien thi moi
            listView1.Items.Clear();
            //load cac doi tuong SV cua db.ListSV len ListView
            if (listSV != null)
            {
                foreach (SV s in listSV)
                {
                    ListViewItem i = new ListViewItem(s.MSSV);
                    i.SubItems.Add(s.Name);
                    i.SubItems.Add(s.Khoa);
                    listView1.Items.Add(i);
                }
            }
            
        }
        public void GetComboBoxKhoa()
        {
            //them item "ALL" vao comboboxKhoa
            comboBoxKhoa.Items.Add("ALL");
            // lay cac string cua db.GetListNameKhoa()  add vao ComboBoxKhoa
            foreach (string s in db.GetListNameKhoa())
            {
                comboBoxKhoa.Items.Add(s);
            }
            // thiet lap combobox lua chon item "ALL"
            comboBoxKhoa.SelectedIndex = 0;
        }
        public void GetComboBoxSort()
        {
            comboBoxSort.Items.Add("MSSV");
            comboBoxSort.Items.Add("Name");
            comboBoxSort.Items.Add("Khoa");
            comboBoxSort.SelectedIndex = 0;
        }

        private void ComboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lay string Khoa o comboBox
            string Khoa = comboBoxKhoa.Items[comboBoxKhoa.SelectedIndex].ToString();
            //clear ListView truoc khi hien thi moi
            listView1.Items.Clear();
            //ShowListView(db.GetListSVByKhoa(Khoa));
            ShowListView(db.GetListSVByKhoa(Khoa));
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            // lay cac row duoc lua chon tren ListView
            ListView.SelectedListViewItemCollection del_row = listView1.SelectedItems;
            foreach(ListViewItem i in del_row)
            {
                //lay duoc MSSV cua moi row i
                string mssv = i.Text;
                // xoa bang cach goi ham db.DelSV(m)
                db.DelSV(mssv);
            }
            // lay string Khoa o comboBox
            string Khoa = comboBoxKhoa.Items[comboBoxKhoa.SelectedIndex].ToString();
            
            //ShowListView(db.GetListSVByKhoa(Khoa));
            ShowListView(db.GetListSVByKhoa(Khoa));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DetailForm df = new DetailForm("", ShowListView);
            df.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // MSSV lay tu Row dang duoc chon trong listview
            try
            {
                string MSSV = listView1.SelectedItems[0].Text;
                DetailForm df = new DetailForm(MSSV, ShowListView);
                df.Show();
            }
            catch
            {
                
            }
               
                
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            ShowListView(db.GetListSVByName(txtSearch.Text));
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            // kiem tra Sort theo thuoc tinh nao dua tren comboBoxSort
            string TT_Sort = comboBoxSort.Items[comboBoxSort.SelectedIndex].ToString();
            // dung switch case  de kiem tra chuoi TT_Sort de goi cac ham Sort
            
            db.Sort(TT_Sort);

            ShowListView(db.listSV);
        }

        
    }
}
