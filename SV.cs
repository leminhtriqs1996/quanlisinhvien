using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class SV
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public string Khoa { get; set; }
        public DateTime Birthday { get; set; }
        public bool gender { get; set; }
        public double DHT { get; set; }

        
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object o)
        {
            if (this.MSSV.Equals( ((SV)o).MSSV) )
                return true;
            else return false;
        }
        public static bool CompareMSSV (Object o, Object o1)
        {
            return Double.Parse(((SV)o).MSSV) > Double.Parse(((SV)o1).MSSV);
        }
        public static bool CompareName(Object o, Object o1)
        {
            return (string.Compare(((SV)o).Name, ((SV)o1).Name) > 0);
        }
        public static bool CompareKhoa(Object o, Object o1)
        {
            return (string.Compare(((SV)o).Khoa, ((SV)o1).Khoa) > 0);
        }
    }
}
