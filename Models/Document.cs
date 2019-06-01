using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Hàm xây dựng đối tượng chứng từ
    /// Tạo bởi: NBDUONG(15/5/2019)
    /// </summary>
    public class Document
    {
        //Id
        public Guid DocumentId { get; set; }
        //Loại chứng từ
        //Khóa ngoại đến bảng loại chứng từ
        public Guid DocumentTypeId { get; set; }
        //Mã chứng từ
        public string DocumentCode { get; set; }
        //Ngày chứng từ
        public DateTime DocumentDate { get; set; }
        //Tổng tiền
        public double TotalMoney { get; set; }
        //Số tiền phải trả
        public double MoneyHasToPay { get; set; }
        //Số tiền chưa trả
        public double MoneyHasNotPaid { get; set; }
        //Số tiền đã trả
        public double AmountPaid { get; set; }
        //Lý do
        public string Reason { get; set; }
        //Khóa ngoại đến bảng Person
        public Guid PersonId { get; set; }

        //Khóa ngoại đến bảng Employee
        public Guid EmployeeId { get; set; }
        
        //Hàm khởi tạo chứng từ
        public Document()
        {
            DocumentId = Guid.NewGuid();
            DocumentDate = DateTime.Now;
        }
    }
}