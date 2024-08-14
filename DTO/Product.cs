using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class Product
    {
        public string MASACH { get; set; }
        public int MALOAISACH { get; set; }
        public string TENSACH { get; set; }
        public int THELOAI { get; set; }
        public int MATACGIA { get; set; }
        public int MANHAXUATBAN { get; set; }
        public decimal GIATIEN { get; set; }
        public int SLTK { get; set; }
        public string ANH { get; set; }

        public Product()
        {

        }

        public Product(DataRow row)
        {
            MASACH = row["MASACH"].ToString();
            MALOAISACH = Convert.ToInt32(row["MALOAISACH"]);
            TENSACH = row["TENSACH"].ToString();
            //THELOAI = row["THELOAI"].ToString();
            MATACGIA = Convert.ToInt32(row["MATG"]);
            MANHAXUATBAN = Convert.ToInt32(row["MANXB"]);
            GIATIEN = Convert.ToDecimal(row["GIATIEN"]);
            SLTK = Convert.ToInt32(row["SLTK"]);
            ANH = row["ANH"].ToString();
        }

    }
}
