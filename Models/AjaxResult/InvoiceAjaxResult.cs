using System;

namespace MISA.Mshopkeeper.Models.AjaxResult
{
    /// <summary>
    /// Lớp lấy dữ liệu của hóa đơn để hiển thị xuống giao diện
    /// </summary>
    /// Người tạo: ntxuan (13/5/2019)
    public class InvoiceAjaxResult
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
        // Ngày hóa đơn
        public DateTime InvoiceDate { get; set; }
        // Giờ nhập
        public string ImportTime { get; set; }
        // Tên nhà cung cấp
        public string SupplierName { get; set; }
        // Mã nhà cung cấp
        public string SupplierCode { get; set; }
        // Tên nhân viên
        public string EmployeeName { get; set; }
        // Mã nhân viên
        public string EmployeeCode { get; set; }
        // Thành tiền
        public double Money { get; set; }
        // Loại hóa đơn
        public int TypeInvoice { get; set; }
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
        // KHóa ngoại tới bảng nhà cung cấp
        public Guid SupplierId { get; set; }
        // Khóa ngoại tới bảng nhân viên
        public Guid EmployeeId { get; set; }
        // Địa chỉ
        public string Address { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định khi tạo đối tượng
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public InvoiceAjaxResult()
        {
            InvoiceId = Guid.NewGuid();
        }

        /// <summary>
        /// Hàm khỏi tạo đối tượng mặc định sẽ gán các giá trị 
        /// </summary>
        /// <param name="invoice">Tham số hóa đơn truyền vào</param>
        /// Người tạo: ntxuan (13/5/2019)
        public InvoiceAjaxResult(Invoice invoice)
        {
            InvoiceId = invoice.InvoiceId;
            ImportDate = invoice.ImportDate;
            ImportNumber = invoice.ImportNumber;
            Explanation = invoice.Explanation;
            ImportTime = invoice.ImportTime;
            Deliver = invoice.Deliver;
            Receiver = invoice.Receiver;
            SupplierName = Extention.GetSupplierById(invoice.SupplierId).SupplierName;
            SupplierCode = Extention.GetSupplierById(invoice.SupplierId).SupplierCode;
            EmployeeName = Extention.GetEmployeeById(invoice.EmployeeId).EmployeeName;
            EmployeeCode = Extention.GetEmployeeById(invoice.EmployeeId).EmployeeCode;
            Money = Extention.GetSumMoneyByInvoiceId(invoice.InvoiceId);
            TypeInvoice = invoice.TypeInvoice;
            ReasonExpenditure = invoice.ReasonExpenditure;
            ExpenditureNumber = invoice.ExpenditureNumber;
            TaxCode = invoice.TaxCode;
            InvoiceNumber = invoice.InvoiceNumber;
            SupplierId = invoice.SupplierId;
            EmployeeId = invoice.EmployeeId;
            Address = invoice.Address;
            InvoiceDate = invoice.InvoiceDate;
        }
    }
}