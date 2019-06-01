using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp đại diện cho bảng nhà cung cấp
    /// </summary>
    /// Người tạo: ntxuan(10/5/2019)
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        // Mã nhà cung cấp
        public string SupplierCode { get; set; }
        // Tên nhà cung cấp
        public string SupplierName { get; set; }
        // Địa chỉ
        public string Address { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc đinh khi tạo đối tượng
        /// </summary>
        /// Người tạo: ntxuan(11/5/2019)
        public Supplier()
        {
            SupplierId = Guid.NewGuid();
        }
    }
}