using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class InvoiceSaleBUS
    {
        public static DataTable GetAll()
        {
            return InvoiceSaleDAO.GetAll();
        }
        public static bool Add(InvoiceSale invoice)
        {
            return InvoiceSaleDAO.Add(invoice);
        }

        public static bool Edit(InvoiceSale invoice)
        {
            return InvoiceSaleDAO.Edit(invoice);
        }

        public static bool Delete(string ma)
        {
            return InvoiceSaleDAO.Del(ma);
        }

        public static InvoiceSale GetByMAHD(string ma)
        {
            return new InvoiceSale(InvoiceSaleDAO.GetByMAHD(ma));
        }

        public static DataTable GetByName(string ma)
        {
            return InvoiceSaleDAO.GetByName(ma);
        }

        public static DataTable GetStat()
        {
            return InvoiceSaleDAO.GetStat();
        }

        public static DataTable GetByYearEnH(string ma)
        {
            return InvoiceSaleDAO.GetByYearEnH(ma);
        }
        public static DataTable GetByDayEnH(string d, string m, string y)
        {
            return InvoiceSaleDAO.GetByDayEnH(d, m, y);
        }
        public static DataTable GetDayToDay(DateTime dt1, DateTime dt2)
        {
            return InvoiceSaleDAO.GetDayToDay(dt1, dt2);
        }
        public static DataTable GetDay(DateTime dt1)
        {
            return InvoiceSaleDAO.GetDay(dt1);
        }
        public static DataTable GetByMonthEnH(string m, string y)
        {
            return InvoiceSaleDAO.GetByMonthEnH(m, y);
        }
        public static object GetDoanhThuDayToDay(DateTime dt1, DateTime dt2)
        {
            return InvoiceSaleDAO.GetDoanhThuDayToDay(dt1, dt2);
        }
        public static DataTable GetDoanhThuMonth(string m, string y)
        {
            return InvoiceSaleDAO.GetDoanhThuMonth(m, y);
        }
        public static DataTable GetDoanhThuYear(string y)
        {
            return InvoiceSaleDAO.GetDoanhThuYear(y);
        }
        public static DataTable GetByDayTotal(string d, string m, string y)
        {
            return InvoiceSaleDAO.GetByDayTotalEnH(d, m, y);
        }

        public static DataTable GetByMonthTotal(string m, string y)
        {
            return InvoiceSaleDAO.GetByMonthTotalEnH(m, y);
        }

        public static DataTable GetByYearTotal(string y)
        {
            return InvoiceSaleDAO.GetByYearTotalEnH(y);
        }
        public static DataTable GetCHITIETHD(string ma)
        {
            return InvoiceSaleDAO.GetCHITIETHD(ma);
        }
    }
}
