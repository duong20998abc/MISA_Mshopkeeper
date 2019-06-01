using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp đại diện cho bảng chi tiết phiếu 
    /// </summary>
    /// Người tạo: ntxuan(10/5/2019)
    public class InvoiceDetail
    {
        // Mã hóa đơn chi tiết
        public Guid InvoiceDetailId { get; set; }
        // Mã hóa đơn ( khóa ngoại)
        public Guid InvoiceId { get; set; }
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
        // %CK
        public int DiscountPercentage { get; set; }
        // Thuế suất
        public int TaxPercentage { get; set; }
        // Số lượng hàng hóa
        public int Quantity { get; set; }

        /// <summary>
        /// Hàm khỏi tạo mặc định khi tao đối tượng mới
        /// </summary>
        /// Người tạo: ntxuan(11/5/2019)
        public InvoiceDetail()
        {
            InvoiceDetailId = Guid.NewGuid();
        }
    }
}