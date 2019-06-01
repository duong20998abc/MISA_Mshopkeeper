using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models.AjaxResult
{
    /// <summary>
    /// Lớp hiển lấy dữ liệu chi tiết của một sản phẩm để hiển thị xuống client
    /// </summary>
    /// Người tạo: ntxuan (13/5/2019)
    public class InvoiceDetailAjaxResult
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

        // Thành tiền
        public double Money { get; set; }
        // Tiền CK
        public double DiscountMoney { get; set; }
        // Tiền Thuế
        public double TaxMoney { get; set; }
        // Tiền Thanh toán
        public double PaidMoney { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        /// Người tạo: ntxuan (28/5/2019)
        public InvoiceDetailAjaxResult()
        {
            InvoiceDetailId = Guid.NewGuid();
        }

        /// <summary>
        /// Hàm khỏi tạo mặc định các tham số của đối tượng
        /// </summary>
        /// <param name="invoiceDetail">Một hóa đơn chi tiết</param>
        /// Người tạo: ntxuan (13/5/2019)
        public InvoiceDetailAjaxResult(InvoiceDetail invoiceDetail)
        {
            InvoiceDetailId = invoiceDetail.InvoiceDetailId;
            InvoiceId = invoiceDetail.InvoiceId;
            ProductName = invoiceDetail.ProductName;
            SKU = invoiceDetail.SKU;
            Unit = invoiceDetail.Unit;
            Storage = invoiceDetail.Storage;
            UnitPrice = invoiceDetail.UnitPrice;
            DiscountPercentage = invoiceDetail.DiscountPercentage;
            TaxPercentage = invoiceDetail.TaxPercentage;
            Quantity = invoiceDetail.Quantity;
            Money = Quantity * UnitPrice;
            DiscountMoney = (Money * DiscountPercentage * 0.01);
            TaxMoney = (Money - DiscountMoney) * TaxPercentage * 0.01;
            PaidMoney = Money - DiscountMoney + TaxMoney;
        }
    }
}