using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Bảng chứa thông tin của sản phẩm
    /// </summary>
    /// Người tạo: ntxuan(10/5/2019)
    public class Product
    {
        // Id của sản phẩm
        public Guid ProductId { get; set; }
        // Tên sản phẩm
        public string ProductName { get; set; }
        // Mã SKU
        public string SKU { get; set; }
        // Đơn vị tính
        public string Unit { get; set; }
        // Kho
        public string Storage { get; set; }
        // Đơn giá
        public double UnitPrice { get; set; }
        // Mã vạch
        public string Barcode { get; set; }

        /// <summary>
        /// Hàm khỏi tạo mặc định khi tao đối tượng mới
        /// </summary>
        /// Người tạo: ntxuan(11/5/2019)
        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}