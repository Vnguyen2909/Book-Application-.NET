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
    public class ProductTypeBUS
    {
        public static DataTable GetProductType()
        {
            return ProductTypeDAO.GetProductType();
        }
        public static ProductType Get(int masach)
        {
            if (ProductTypeDAO.CheckExist(masach))
            {
                return new ProductType(ProductTypeDAO.Get(masach));
            }
            return null;
        }
        public static bool AddProductType(ProductType pt)
        {
            if (!ProductTypeDAO.CheckExist(pt.MALOAISACH))
            {
                return ProductTypeDAO.AddProductType(pt);
            }
            return false;
        }
        public static bool CheckID(int ma)
        {
            if (ProductTypeDAO.CheckExist(ma))
            {
                return false;
            }
            return true;
        }
        public static bool CheckName(string name)
        {
            if (ProductTypeDAO.CheckName(name))
            {
                return false;
            }
            return true;
        }
        public static bool DelProductType(int masach)
        {
            return ProductTypeDAO.Del(masach);
        }
        public static bool EditProductType(ProductType pt)
        {
            return ProductTypeDAO.Edit(pt);
        }
        public static bool CheckExist(int ma)
        {
            return ProductTypeDAO.CheckExist(ma);
        }

        public static DataTable GetByName(string name)
        {
            return ProductTypeDAO.GetByName(name);
        }
    }
}
