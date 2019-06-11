using MISA.Mshopkeeper.Models.AjaxResult;
using MISA.Mshopkeeper.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// lớp chứa các hàm thêm sửa xóa của các lớp entity
    /// </summary>
    /// Người tạo: ntxuan(11/5/2019)
    public class Extention
    {
        /// <summary>
        /// Hàm lấy nhân viên theo id truyền vào
        /// </summary>
        /// <param name="Id">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// Người tạo: ntxuan(11/5/2019)
        public static Employee GetEmployeeById(Guid Id)
        {
            var employee = MshopkeeperDB.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            return employee;
        }

        /// <summary>
        /// Lấy nhà cung cấp theo id truyền vào
        /// </summary>
        /// <param name="Id">Id của nhà cung cấp</param>
        /// <returns>Nhà cung cấp</returns>
        /// Người tạo: ntxuan(11/5/2019)
        public static Supplier GetSupplierById(Guid Id)
        {
            var supplier = MshopkeeperDB.Suppliers.FirstOrDefault(x => x.SupplierId == Id);
            return supplier;
        }

        /// <summary>
        /// Lấy hóa đơn theo id truyền vào
        /// </summary>
        /// <param name="Id">Id của hóa đơn truyền vào</param>
        /// <returns>Hóa đơn</returns>
        /// Người tạo: ntxuan(11/5/2019)
        public static Invoice GetInvoiceById(Guid Id)
        {
            var invoice = MshopkeeperDB.Invoices.FirstOrDefault(x => x.InvoiceId == Id);
            return invoice;
        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="Id">Id của sản phẩm truyền vào</param>
        /// <returns>Sản phẩm</returns>
        /// Người tạo: ntxuan(11/5/2019)
        public static Product GetProductById(Guid Id)
        {
            var product = MshopkeeperDB.Products.FirstOrDefault(x => x.ProductId == Id);
            return product;
        }

        /// <summary>
        /// Lấy hóa đơn chi tiết
        /// </summary>
        /// <param name="Id">Id của hóa đơn chi tiết</param>
        /// <returns>Hóa đơn chi tiết</returns>
        /// Người tạo: ntxuan(11/5/2019)
        public static List<InvoiceDetail> GetListInvoiceDetailsByInvoiceId(Guid Id)
        {
            var invoiceDetail = MshopkeeperDB.InvoiceDetails.Where(x => x.InvoiceId == Id).ToList();
            return invoiceDetail;
        }

        /// <summary>
        /// Hàm dùng để xóa một hóa đơn theo id truyền vào
        /// </summary>
        /// <param name="invoiceId">Id hóa đơn</param>
        /// Người tạo: ntxuan (17/5/2019)
        public static void DeleteInvoice(Guid invoiceId)
        {
            var invoice = GetInvoiceById(invoiceId);
            foreach (var invoiceDetail in GetListInvoiceDetailsByInvoiceId(invoiceId))
            {
                MshopkeeperDB.InvoiceDetails.Remove(invoiceDetail);
            }
            MshopkeeperDB.Invoices.Remove(invoice);
        }

        /// <summary>
        /// Hàm dùng để thêm mới một hóa đơn
        /// </summary>
        /// <param name="invoiceAjaxResult"></param>
        public static Guid CreateInvoice(InvoiceAjaxResult invoiceAjaxResult)
        {
            var invoice = MapInvoiceAjaxResultToInvoice(invoiceAjaxResult);
            MshopkeeperDB.Invoices.Add(invoice);
            return invoice.InvoiceId;
        }

        /// <summary>
        /// Hàm dùng để lưu  một hóa đơn
        /// </summary>
        /// <param name="invoiceAjaxResult"></param>
        public static Guid SaveEditInvoice(InvoiceAjaxResult invoiceAjaxResult)
        {
            var invoice = MshopkeeperDB.Invoices.FirstOrDefault(s => s.InvoiceId == invoiceAjaxResult.InvoiceId);
            // Ánh xạ các thuộc tính tương ứng
            invoice.ImportNumber = invoiceAjaxResult.ImportNumber;
            invoice.ExpenditureNumber = invoiceAjaxResult.ExpenditureNumber;
            invoice.Explanation = invoiceAjaxResult.Explanation;
            invoice.ImportDate = invoiceAjaxResult.ImportDate;
            invoice.ImportTime = invoiceAjaxResult.ImportTime;
            invoice.SupplierId = invoiceAjaxResult.SupplierId;
            invoice.EmployeeId = invoiceAjaxResult.EmployeeId;
            invoice.TypeInvoice = invoiceAjaxResult.TypeInvoice;
            invoice.Address = invoiceAjaxResult.Address;
            invoice.Deliver = invoiceAjaxResult.Deliver;
            invoice.Receiver = invoiceAjaxResult.Receiver;
            invoice.ReasonExpenditure = invoiceAjaxResult.ReasonExpenditure;
            invoice.TaxCode = invoiceAjaxResult.TaxCode;
            invoice.InvoiceNumber = invoiceAjaxResult.InvoiceNumber;
            invoice.InvoiceDate = invoiceAjaxResult.InvoiceDate;

            return invoice.InvoiceId;
        }

        /// <summary>
        /// Hàm tính tổng số tiền của một hóa đơn
        /// </summary>
        /// <param name="invoiceId">Id của hóa đơn chuyền vào</param>
        /// <returns>Tổng số tiền</returns>
        /// Người tạo: ntxuan (13/5/2019)
        public static double GetSumMoneyByInvoiceId(Guid invoiceId)
        {
            List<InvoiceDetail> invoiceDetails = GetListInvoiceDetailsByInvoiceId(invoiceId);
            double SumMoney = 0;
            foreach (var item in invoiceDetails)
            {
                SumMoney += item.UnitPrice * item.Quantity;
            }
            return SumMoney;
        }

        /// <summary>
        /// Hàm lấy dữ liệu loại chứng từ theo id
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static DocumentType GetDocumentTypeById(Guid Id)
        {
            var documentType = MshopkeeperDB.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == Id);
            return documentType;
        }

        /// <summary>
        /// Hàm lấy dữ liệu chứng từ theo id
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Document GetDocumentById(Guid Id)
        {
            var document = MshopkeeperDB.Documents.FirstOrDefault(x => x.DocumentId == Id);
            return document;
        }

        /// <summary>
        /// Hàm lấy dữ liệu chứng từ theo người nộp/ nhận
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static List<Document> GetDocumentsByPersonId(Guid Id)
        {
            var documents = MshopkeeperDB.Documents.Where(x => x.DocumentId == Id).ToList();
            return documents;
        }

        /// <summary>
        /// Hàm lấy dữ liệu chứng từ theo loại chứng từ
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static List<Document> GetDocumentsByDocumentType(Guid Id)
        {
            var documents = MshopkeeperDB.Documents.Where(x => x.DocumentTypeId == Id).ToList();
            return documents;
        }

        /// <summary>
        /// Hàm lấy dữ liệu đối tượng theo loại đối tượng
        /// Tạo bởi: NBDUONG(15/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Person GetObjectById(Guid Id)
        {
            var @object = MshopkeeperDB.People.FirstOrDefault(x => x.PersonId == Id);
            return @object;
        }

        /// <summary>
        /// Hàm lấy dữ liệu loại đối tượng theo id
        /// Tạo bởi: NBDUONG(19/5/2019)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static PersonType GetPersonTypeById(Guid id)
        {
            var personType = MshopkeeperDB.PersonTypes.FirstOrDefault(x => x.PersonTypeId == id);
            return personType;
        }

        /// <summary>
        /// Hàm tạo mới chứng từ
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// Tạo bởi: NBDUONG(23/5/2019)
        public static void CreateDocument(DocumentAjaxResult documentAjaxResult)
        {
            var document = MapDocumentAjaxResultToDocument(documentAjaxResult);
            MshopkeeperDB.Documents.Add(document);
        }

        /// <summary>
        /// Hàm thay đổi thông tin chứng từ
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// Tạo bởi: NBDUONG(28/5/2019)
        public static void EditDocument(DocumentAjaxResult documentAjaxResult)
        {
            //Lấy ra chứng từ có id tương ứng
            var document = MshopkeeperDB.Documents.FirstOrDefault(x => x.DocumentId == documentAjaxResult.DocumentId);
            //Ánh xạ các thuộc tính tương ứng
            document.DocumentCode = documentAjaxResult.DocumentCode;
            document.DocumentDate = documentAjaxResult.DocumentDate;
            document.DocumentTypeId = documentAjaxResult.DocumentTypeId;
            document.Reason = documentAjaxResult.Reason;
            document.ReceiverName = documentAjaxResult.ReceiverName;
            document.TotalMoney = documentAjaxResult.TotalMoney;
            document.PersonId = documentAjaxResult.PersonId;
            document.AmountPaid = documentAjaxResult.AmountPaid;
            document.MoneyHasNotPaid = documentAjaxResult.MoneyHasNotPaid;
            document.MoneyHasToPay = documentAjaxResult.MoneyHasToPay;
            document.EmployeeId = documentAjaxResult.EmployeeId;
        }

        /// <summary>
        /// Hàm xóa chứng từ
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// Tạo bởi: NBDUONG(30/5/2019)
        public static void DeleteDocument(Guid documentId)
        {
            var document = GetDocumentById(documentId);
            MshopkeeperDB.Documents.Remove(document);
        }

        /// <summary>
        /// Ánh xạ từ DocumentAjaxResult sang Document
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// <returns>Document</returns>
        /// Tạo bởi: NBDUONG(23/5/2019)
        public static Document MapDocumentAjaxResultToDocument(DocumentAjaxResult documentAjaxResult)
        {
            var document = new Document();
            document.DocumentCode = documentAjaxResult.DocumentCode;
            document.DocumentDate = documentAjaxResult.DocumentDate;
            document.DocumentTypeId = documentAjaxResult.DocumentTypeId;
            document.Reason = documentAjaxResult.Reason;
            document.ReceiverName = documentAjaxResult.ReceiverName;
            document.TotalMoney = documentAjaxResult.TotalMoney;
            document.PersonId = documentAjaxResult.PersonId;
            document.AmountPaid = documentAjaxResult.AmountPaid;
            document.MoneyHasNotPaid = documentAjaxResult.MoneyHasNotPaid;
            document.MoneyHasToPay = documentAjaxResult.MoneyHasToPay;
            document.EmployeeId = documentAjaxResult.EmployeeId;
        
            return document;
        }

        /// <summary>
        /// Hàm để ánh xạ từ lớp InvoiceAjaxResult sang lớp Invoice
        /// </summary>
        /// <returns>Invoice</returns>
        /// Người tạo: ntxuan (17/5/2019)
        public static Invoice MapInvoiceAjaxResultToInvoice(InvoiceAjaxResult invoiceAjaxResult)
        {
            var invoice = new Invoice();
            // Ánh xạ các thuộc tính tương ứng
            invoice.ImportNumber = invoiceAjaxResult.ImportNumber;
            invoice.ExpenditureNumber = invoiceAjaxResult.ExpenditureNumber;
            invoice.Explanation = invoiceAjaxResult.Explanation;
            invoice.ImportDate = invoiceAjaxResult.ImportDate;
            invoice.ImportTime = invoiceAjaxResult.ImportTime;
            invoice.SupplierId = invoiceAjaxResult.SupplierId;
            invoice.EmployeeId = invoiceAjaxResult.EmployeeId;
            invoice.TypeInvoice = invoiceAjaxResult.TypeInvoice;
            invoice.Address = invoiceAjaxResult.Address;
            invoice.Deliver = invoiceAjaxResult.Deliver;
            invoice.Receiver = invoiceAjaxResult.Receiver;
            invoice.ReasonExpenditure = invoiceAjaxResult.ReasonExpenditure;
            invoice.TaxCode = invoiceAjaxResult.TaxCode;
            invoice.InvoiceNumber = invoiceAjaxResult.InvoiceNumber;
            invoice.InvoiceDate = invoiceAjaxResult.InvoiceDate;

            return invoice;
        }

        /// <summary>
        /// Hàm để ánh xạ từ lớp InvoiceDetailAjaxResult sang lớp InvoiceDetail
        /// </summary>
        /// <returns>InvoiceDetail</returns>
        /// Người tạo: ntxuan (17/5/2019)
        public static InvoiceDetail MapInvoiceDetailAjaxResultToInvoiceDetail(InvoiceDetailAjaxResult invoiceDetailAjaxResult)
        {
            var invoiceDetail = new InvoiceDetail();
            // Ánh xạ các thuộc tính tương ứng
            invoiceDetail.InvoiceDetailId = invoiceDetailAjaxResult.InvoiceDetailId;
            invoiceDetail.InvoiceId = invoiceDetailAjaxResult.InvoiceId;
            invoiceDetail.ProductName = invoiceDetailAjaxResult.ProductName;
            invoiceDetail.SKU = invoiceDetailAjaxResult.SKU;
            invoiceDetail.Unit = invoiceDetailAjaxResult.Unit;
            invoiceDetail.Storage = invoiceDetailAjaxResult.Storage;
            invoiceDetail.UnitPrice = invoiceDetailAjaxResult.UnitPrice;
            invoiceDetail.DiscountPercentage = invoiceDetailAjaxResult.DiscountPercentage;
            invoiceDetail.TaxPercentage = invoiceDetailAjaxResult.TaxPercentage;
            invoiceDetail.Quantity = invoiceDetailAjaxResult.Quantity;

            return invoiceDetail;
        }

        /// <summary>
        /// Hàm để so sánh hai giá trị datetime
        /// </summary>
        /// <param name="date1">Giá trị datetime1</param>
        /// <param name="date2">Giá trị datetime2</param>
        /// <returns>Giá trị nguyên</returns>
        public static int CompareDate(DateTime date1, DateTime date2)
        {
            DateTime date1Compare = new DateTime(date1.Year, date1.Month, date1.Day);
            DateTime date2Compare = new DateTime(date2.Year, date2.Month, date2.Day);
            int value = DateTime.Compare(date1Compare, date2Compare);
            return value;
        }

        /// <summary>
        /// Hàm lấy danh sách các hóa đơn theo một khoảng nào đó
        /// </summary>
        /// <param name="formDate">Ngày bắt đầu</param>
        /// <param name="toDate">Ngày kết thúc</param>
        /// <returns></returns>
        public static List<Invoice> GetListInvoiceByImportDate(DateTime formDate, DateTime toDate)
        {
            var invoices = new List<Invoice>();
            foreach (var invoice in MshopkeeperDB.Invoices)
            {
                if (CompareDate(formDate,invoice.ImportDate) <= 0 && CompareDate(toDate, invoice.ImportDate) >= 0)
                {
                    invoices.Add(invoice);
                }
            }
            return invoices;
        }

        /// <summary>
        /// Hàm lấy các hóa đơn theo đầu vào lọc
        /// </summary>
        /// <returns>Danh sách hóa đơn</returns>
        /// Người tạo: ntxuan(27/5/2019)
        public static List<Invoice> GetListInvoiceByFilter(InvoiceDto invoiceDto)
        {
            var invoices = new List<Invoice>();

            if (invoiceDto.TypeFilter == "search-importNumber")
            {
                invoices = MshopkeeperDB.Invoices.Where(s => s.ImportNumber.ToLower().Contains(invoiceDto.TextFilter.ToLower())).ToList();
            }
            else if (invoiceDto.TypeFilter == "search-supplierName")
            {
                invoices = MshopkeeperDB.Invoices.Where(s => Extention.GetSupplierById(s.SupplierId).SupplierName.ToLower().Contains(invoiceDto.TextFilter.ToLower())).ToList();
            }
            else if (invoiceDto.TypeFilter == "search-explanation")
            {
                invoices = MshopkeeperDB.Invoices.Where(s => s.Explanation.ToLower().Contains(invoiceDto.TextFilter.ToLower())).ToList();
            }
           
            return invoices;
        }
    }
}