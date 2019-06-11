using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models.AjaxResult
{
    /// <summary>
    /// Lớp để lấy dữ liệu chứng từ
    /// Tạo bởi: NBDUONG(15/5/2019)
    /// </summary>
    public class DocumentAjaxResult
    {
        //Id
        public Guid DocumentId { get; set; }
        //Mã chứng từ
        public string DocumentCode { get; set; }
        //Ngày chứng từ
        public DateTime DocumentDate { get; set; }
        //Tổng tiền
        public double TotalMoney { get; set; }
        //Lý do
        public string Reason { get; set; }
        //Địa chỉ
        public string Address { get; set; }
        //Tên người nộp/nhận
        public string ReceiverName { get; set; } 
        //Loại chứng từ
        public string DocumentType { get; set; }
        //Mã đối tượng
        public string PersonCode { get; set; }
        //Tên đối tượng
        public string PersonName { get; set; }
        //Mã nhân viên
        public string EmployeeCode { get; set; }
        //Tên nhân viên
        public string EmployeeName { get; set; }
        //Số tiền phải trả
        public double MoneyHasToPay { get; set; }
        //Số tiền chưa trả
        public double MoneyHasNotPaid { get; set; }
        //Số tiền đã trả
        public double AmountPaid { get; set; }

        ////Khóa ngoại tới bảng loại chứng từ
        public Guid DocumentTypeId { get; set; }
        //Khóa ngoại tới bảng đối tượng
        public Guid PersonId { get; set; }
        //Khóa ngoại tới bảng nhân viên
        public Guid EmployeeId { get; set; }

        public DocumentAjaxResult()
        {
            DocumentId = Guid.NewGuid();
        }

        /// <summary>
        /// Hàm khởi tạo khi tạo mới chứng từ
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="document"></param>
        public DocumentAjaxResult(Document document)
        {
            DocumentId = document.DocumentId;
            DocumentCode = document.DocumentCode;
            DocumentDate = document.DocumentDate;
            TotalMoney = document.TotalMoney;
            Reason = document.Reason;
            Address = Extention.GetObjectById(document.PersonId).Address;
            ReceiverName = document.ReceiverName;
            DocumentType = Extention.GetDocumentTypeById(document.DocumentTypeId).DocumentTypeName;
            PersonName = Extention.GetObjectById(document.PersonId).PersonName;
            PersonCode = Extention.GetObjectById(document.PersonId).PersonCode;
            EmployeeCode = Extention.GetEmployeeById(document.EmployeeId).EmployeeCode;
            EmployeeName = Extention.GetEmployeeById(document.EmployeeId).EmployeeName;
            MoneyHasToPay = document.MoneyHasToPay;
            MoneyHasNotPaid = document.MoneyHasNotPaid;
            AmountPaid = document.AmountPaid;
            DocumentTypeId = document.DocumentTypeId;
            PersonId = document.PersonId;
            EmployeeId = document.EmployeeId;
        }
    }
}