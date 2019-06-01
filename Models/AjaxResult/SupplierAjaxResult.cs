using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models.AjaxResult
{
    /// <summary>
    /// Lớp dùng để lấy dữ liệu của nhà cung cấp
    /// </summary>
    /// Người tạo: ntxuan (13/5/2019)
    public class SupplierAjaxResult
    {
        // Id nhà cung cấp
        public Guid SupplierId { get; set; }
        // Mã nhà cung cấp
        public string SupplierCode { get; set; }
        // Tên nhà cung cấp
        public string SupplierName { get; set; }
        // Địa chỉ nhà cung cấp
        public string Address { get; set; }

        /// <summary>
        /// Hàm khởi tạo khi tạo mới đối tượng
        /// </summary>
        /// <param name="supplier">Đối tượng nhà cung cấp truyền vào</param>
        /// Người tạo: ntxuan (13/5/2019)
        public SupplierAjaxResult(Supplier supplier)
        {
            SupplierId = supplier.SupplierId;
            SupplierCode = supplier.SupplierCode;
            SupplierName = supplier.SupplierName;
            Address = supplier.Address;
        }
    }
}