using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp quản lý thông tin của các phiếu
    /// </summary>
    /// Người tạo : ntxuan(10/5/2019)
    public class Invoice
    {
        // ID của phiếu
        public Guid InvoiceId { get; set; }
        // Số phiếu nhập
        public string ImportNumber { get; set; }
        // Số phiếu chi
        public string ExpenditureNumber { get; set; }
        // Diễn giải
        public string Explanation { get; set; }
        // Ngày nhập
        public DateTime ImportDate { get; set; }
        // Giờ nhập
        public string ImportTime { get; set; }
        // KHóa ngoại tới bảng nhà cung cấp
        public Guid SupplierId { get; set; }
        // Khóa ngoại tới bảng nhân viên
        public Guid EmployeeId { get; set; }
        // Loại hóa đơn
        public int TypeInvoice { get; set; }
        // Địa chỉ
        public string Address { get; set; }
        // Người giao
        public string Deliver { get; set; }
        // Người nhận
        public string Receiver { get; set; }
        // Lý do chi
        public string ReasonExpenditure { get; set; }
        // Mã số thuế
        public string TaxCode { get; set; }
        // Số hóa đơn
        public string InvoiceNumber { get; set; }
        // Ngày hóa đơn
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Hàm khỏi tạo mặc định khi khởi tạo đối tượng mới
        /// </summary>
        /// Người tạo: ntxuan(11/5/2019)
        public Invoice()
        {
            InvoiceId = Guid.NewGuid();
        }
    }
}