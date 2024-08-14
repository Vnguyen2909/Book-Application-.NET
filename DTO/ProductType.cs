using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class ProductType
    {
        public int MALOAISACH { get; set; }
        public string LOAISACH { get; set; }

        public ProductType()
        {

        }
        public ProductType(DataRow row)
        {
            MALOAISACH = int.Parse(row["MALOAISACH"].ToString());
            LOAISACH = row["LOAISACH"].ToString();
        }
    }
}
