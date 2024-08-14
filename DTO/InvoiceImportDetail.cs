using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class InvoiceImportDetail
    {
        public int Id { get; set; }
        public string MAHD { get; set; }
        public string MASACH { get; set; }
        public int SL { get; set; }
        public decimal GIATIEN { get; set; }

        public decimal TongTien{get; set;}

        public InvoiceImportDetail(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            MAHD = row["MAHD"].ToString();
            MASACH = row["MASACH"].ToString();
            SL = Convert.ToInt32(row["SL"]);
            GIATIEN = Convert.ToDecimal(row["GIATIEN"]);
            TongTien = SL * GIATIEN;
        }

        public InvoiceImportDetail()
        {
            
        }
    }
}
