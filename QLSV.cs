using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class QLSV
    {
        public delegate bool Compare(object o1, object o2);
        public Compare p;
        public SV[] listSV { get; set; }
        public int count { get; set; }

        public QLSV()
        {
            //ham tao ra cac doi tuong SV trong listSV
            Add(new SV() { MSSV = "1", Name = "Rio Ferdinand", Khoa = "CNTT", Birthday = DateTime.Parse("12/16/1996"), DHT = 9.5, gender = true });
            Add(new SV() { MSSV = "2", Name = "Nemamja Vidic", Khoa = "Marketing", Birthday = DateTime.Parse("12/26/1997"), DHT = 5.5, gender = false });
            Add(new SV() { MSSV = "3", Name = "Chicharito", Khoa = "Du Lich", Birthday = DateTime.Parse("12/06/1998"), DHT = 6.5, gender = true });
            Add(new SV() { MSSV = "4", Name = "Dimitar Berbatov", Khoa = "Ngon Ngu Anh", Birthday = DateTime.Parse("11/17/1999"), DHT = 9.9, gender = false });
            Add(new SV() { MSSV = "5", Name = "Wayne Rooney", Khoa = "Kinh Te", Birthday = DateTime.Parse("02/28/1991"), DHT = 5.7, gender = true });
            Add(new SV() { MSSV = "6", Name = "Edwin Van der Sar", Khoa = "Ngon Ngu Nhat", Birthday = DateTime.Parse("03/31/1992"), DHT = 3.6, gender = true });
            Add(new SV() { MSSV = "8", Name = "Calos Tevez", Khoa = "CNTT", Birthday = DateTime.Parse("05/16/1993"), DHT = 10, gender = false });
            Add(new SV() { MSSV = "9", Name = "Luis Nani", Khoa = "CNTT", Birthday = DateTime.Parse("01/16/2000"), DHT = 10, gender = true });
            Add(new SV() { MSSV = "10", Name = "David Beckham", Khoa = "Du Lich", Birthday = DateTime.Parse("08/13/1993"), DHT = 10, gender = false });
            Add(new SV() { MSSV = "11", Name = "David De Gea", Khoa = "Marketing", Birthday = DateTime.Parse("09/12/1992"), DHT = 10, gender = true });
            Add(new SV() { MSSV = "12", Name = "Paul Pogba", Khoa = "Ngon Ngu Anh", Birthday = DateTime.Parse("05/26/2001"), DHT = 10, gender = false });
            Add(new SV() { MSSV = "13", Name = "Joan Mata", Khoa = "Du Lich", Birthday = DateTime.Parse("09/16/1990"), DHT = 10, gender = true });
            Add(new SV() { MSSV = "14", Name = "Patrice Evra", Khoa = "Ngon Ngu Nhat", Birthday = DateTime.Parse("07/16/1989"), DHT = 10, gender = false });
            Add(new SV() { MSSV = "15", Name = "Michael Carrick", Khoa = "Ngon Ngu Nhat", Birthday = DateTime.Parse("05/16/1995"), DHT = 10, gender = true });
            Add(new SV() { MSSV = "16", Name = "Ole Gunnar Solskjær", Khoa = "Marketing", Birthday = DateTime.Parse("05/16/1994"), DHT = 10, gender = false });
        }

        /*
        public void CreateDB()
        {
            //ham tao ra cac doi tuong SV trong listSV
            Add(new SV() { MSSV = "1", Name = "Nguyen Van A", Khoa = "CNTT", Birthday = DateTime.Parse("12/06/1996"), DHT = 9.5, gender = true });
            Add(new SV() { MSSV = "2", Name = "Do Nam Trung", Khoa = "Marketing", Birthday = DateTime.Parse("12/06/1996"), DHT = 5.5, gender = false });
            Add(new SV() { MSSV = "3", Name = "Tap Can Binh", Khoa = "Du Lich", Birthday = DateTime.Parse("12/06/1996"), DHT = 6.5, gender = true });
            Add(new SV() { MSSV = "4", Name = "Kim Jong un", Khoa = "Ngon Ngu Anh", Birthday = DateTime.Parse("11/06/1996"), DHT = 9.9, gender = false });
            Add(new SV() { MSSV = "5", Name = "Iron Man", Khoa = "Kinh Te", Birthday = DateTime.Parse("12/06/1996"), DHT = 5.7, gender = true });
            Add(new SV() { MSSV = "6", Name = "Lionel Messi", Khoa = "Ngon Ngu Nhat", Birthday = DateTime.Parse("12/06/1996"), DHT = 3.6, gender = true });
            Add(new SV() { MSSV = "7", Name = "Marcus Rashfosh", Khoa = "CNTT", Birthday = DateTime.Parse("12/06/1996"), DHT = 10, gender = false });

        }
        */
        public void Add(SV s)
        {
            // add SV vao cuoi listSV
            if (this.count == 0)
            {
                this.listSV = new SV[this.count + 1];
                this.listSV[this.count] = s;
            } 
            else
            {
                SV[] temp = new SV[this.count];
                temp = this.listSV;
                this.listSV = new SV[this.count + 1];
                for ( int i = 0; i < this.count; i++)
                {
                    this.listSV[i] = temp[i];
                }
                this.listSV[this.count] = s;
            }
            this.count++;
        }
        public string[] GetListNameKhoa()
        {
            // lay cac string Khoa khong trung nhau va luu vao mang string
            string[] listNameKhoa = new string[this.count]; 
            for (int i = 0; i < this.count; i++)
            {
                listNameKhoa[i] = this.listSV[i].Khoa;
            }
            return listNameKhoa.Distinct().ToArray();
        }
        public SV[] GetListSVByKhoa(string k)
        {
            // lay cac doi tuong sinh vien co thuoc tinh Khoa = k , tra ve 1 mang
            
            if (k.Equals("ALL"))
                return this.listSV;
            else
            {
                SV[] listSVByKhoa = null;
                int count = 0;
                foreach (SV s in this.listSV)
                {
                    if (s.Khoa.Equals(k))
                    {
                        if (count == 0)
                        {
                            listSVByKhoa = new SV[count + 1];
                            listSVByKhoa[count] = s;
                        }
                        else
                        {
                            SV[] temp = new SV[count];
                            temp = listSVByKhoa;
                            listSVByKhoa = new SV[count + 1];
                            for (int i = 0; i < count; i++)
                            {
                                listSVByKhoa[i] = temp[i];
                            }
                            listSVByKhoa[count] = s;
                        }
                        count++;
                    }
                }
                return listSVByKhoa;
            }
            
        }
        public void RemoveAt(int index)
        {
            // xoa doi tuong SV trong listSV tai vi tri index
            if (index == 0 )
            {
                SV[] temp = new SV[this.count - 1];
                for (int i = 0; i < this.count -1 ; i++)
                {
                    temp[i] = this.listSV[i + 1];
                }
                this.listSV = temp;
            }
            else if (index == count-1)
            {
                SV[] temp = new SV[this.count];
                temp = this.listSV;
                this.listSV = new SV[this.count - 1];
                for (int i = 0; i < this.count - 1; i++)
                {
                    this.listSV[i] = temp[i];
                }
            } else
            {
                SV[] temp = new SV[this.count];
                temp = this.listSV;
                this.listSV = new SV[this.count - 1];
                for (int i=0,j=0; i < this.count ; i++ ,j++)
                {
                    if ( i == index )
                    {
                        j--;
                        continue;
                    }
                    this.listSV[j] = temp[i];
                }
            }
            count--;
        }
        public void DelSV(string m)
        {
            // tim trong listSV co doi tuong SV nao ma MSSV = m -> tra ve vi tri tim duoc
            int index = -1;
            for (int i = 0; i< this.count; i ++)
            {
                if ((this.listSV[i]).MSSV.Equals(m))
                    index = i;
            }
            // Xoa doi tuong do di su dung RemoveAt()
            if (index != -1)
                RemoveAt(index);
        }
        public SV[] GetListSVByName(string name)
        {
            SV[] listSVByName = null;
            int count = 0;
            // tim kiem cac doi tuong SV trong listSV theo name
            foreach(SV s in this.listSV)
            {
                if (s.Name.Contains(name))
                {
                    if (count == 0)
                    {
                        listSVByName = new SV[count + 1];
                        listSVByName[count] = s;
                    }
                    else
                    {
                        SV[] temp = new SV[count];
                        temp = listSVByName;
                        listSVByName = new SV[count + 1];
                        for (int i = 0; i < count; i++)
                        {
                            listSVByName[i] = temp[i];
                        }
                        listSVByName[count] = s;
                    }
                    count++;
                }
            }
            return listSVByName;
        }
        public void Sort(string khoa)
        {
            
            if (khoa.Equals("MSSV"))
            {
                p = new Compare(SV.CompareMSSV);
            }
            if (khoa.Equals("Name"))
            {
                p = new Compare(SV.CompareName);
            }
            if (khoa.Equals("Khoa"))
            {
                p = new Compare(SV.CompareKhoa);
            }

            for (int i=0; i< count -1  ; i++)
            {
                for (int j=i+1; j< count; j++)
                {
                   if ( p(this.listSV[i],this.listSV[j]) )
                    {
                        SV temp = this.listSV[i];
                        this.listSV[i] = this.listSV[j];
                        this.listSV[j] = temp;
                    }
                }
            }
        }

        public SV GetSV(string m)
        {
            // tim kiem, tra ve doi tuong SV co MSSV = m
            SV sv = new SV();
            foreach (SV s in this.listSV)
            {
                if (s.MSSV.Equals(m))
                {
                    sv = s;
                    break;
                }
            }
            return sv;
        }
        public int IndexOf(SV s)
        {
            //tra ve vi tri cua SV s
            int index = -1;
            for (int i=0; i< this.count; i++)
            {
                if (this.listSV[i].Equals(s))
                    index = i;
            }
            return index;
        }
    }
}
