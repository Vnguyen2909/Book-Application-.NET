using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using DTO;

namespace BUS
{
    public class ProductBUS
    {
        public static Product Get(string ma)
        {
            return new Product(ProductDAO.Get(ma));
        }
        public static DataTable GetProduct()
        {
            return ProductDAO.GetProduct();
        }

        public static DataTable GetProductNhaXuatBan()
        {
            return ProductDAO.GetProductNhaSanXuat();
        }

        public static DataTable GetProductTacGia()
        {
            return ProductDAO.GetProductTacGia();
        }

        public static DataTable GetMaSach()
        {
            return ProductDAO.GetMaSach();
        }

        public static bool AddProduct(Product p)
        {
            if (!ProductDAO.CheckExist(p.MASACH))
            {
                return ProductDAO.AddProducts(p);
            }
            return false;
        }

        public static DataTable GetByName(string name)
        {
            return ProductDAO.GetByName(name);
        }

        public static bool Edit(Product product)
        {
            return ProductDAO.Edit(product);
        }

        public static bool Del(string masach)
        {
            return ProductDAO.Del(masach);
        }

        public static bool CheckExist(string ma)
        {
            return ProductDAO.CheckExist(ma);
        }

        public static DataTable TOP10()
        {
            return ProductDAO.TOP10();
        }

        public static bool SubtrackStock(string MASACH, int qty)
        {
            return ProductDAO.SubtrackStock(MASACH, qty);
        }

        public static bool PlusStock(string MASACH, int qty)
        {
            return ProductDAO.PlusStock(MASACH, qty);
        }
    }
}
