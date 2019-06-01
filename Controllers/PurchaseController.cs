using MISA.Mshopkeeper.Models;
using MISA.Mshopkeeper.Models.AjaxResult;
using MISA.Mshopkeeper.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MISA.Mshopkeeper.Controllers
{
    /// <summary>
    /// Lớp controller điều khiển các hoạt động trong mục mua hàng
    /// </summary>
    /// Người tạo: ntxuan (11/5/2019)
    [RoutePrefix("Purchase")]
    public class PurchaseController : ApiController
    {
        /// <summary>
        /// Lấy các hóa đơn để hiển thị 
        /// </summary>
        /// <returns>Danh sách hóa đơn</returns>
        /// Người tạo: ntxuan (11/5/2019)
        [Route("")]
        public async Task<IEnumerable<InvoiceAjaxResult>> GetAsync()
        {
            try
            {
                List<InvoiceAjaxResult> invoiceAjaxResults = new List<InvoiceAjaxResult>();
                foreach (var item in MshopkeeperDB.Invoices)
                {
                    var invoiceAjaxResult = new InvoiceAjaxResult(item);
                    invoiceAjaxResults.Add(invoiceAjaxResult);
                }
                await Task.Delay(500);
                return invoiceAjaxResults.OrderByDescending(s => s.ImportDate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy hóa đơn theo id
        /// </summary>
        /// <param name="invoiceId">Id của hóa đơn</param>
        /// <returns>Hóa đơn chi tiết</returns>
        [HttpPost]
        [Route("Invoice/{invoiceId}")]
        public InvoiceAjaxResult PostInvoice(Guid invoiceId)
        {
            try
            {
                var invoice = Extention.GetInvoiceById(invoiceId);
                var invoiceAjaxResult = new InvoiceAjaxResult(invoice);
                return invoiceAjaxResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy hóa đơn theo ngày tạo
        /// </summary>
        /// <param name="invoiceId">ngày tạo của hóa đơn</param>
        /// <returns>Hóa đơn chi tiết</returns>
        [HttpPost]
        [Route("Invoices")]
        public IEnumerable<InvoiceAjaxResult> PostInvoices(InvoiceDto invoiceDto)
        {
            try
            {
                var invoices = Extention.GetListInvoiceByImportDate(invoiceDto.FromDate, invoiceDto.ToDate);
                List<InvoiceAjaxResult> invoiceAjaxResults = new List<InvoiceAjaxResult>();
                foreach (var item in invoices)
                {
                    var invoiceAjaxResult = new InvoiceAjaxResult(item);
                    invoiceAjaxResults.Add(invoiceAjaxResult);
                }
                return invoiceAjaxResults.OrderByDescending(s => s.ImportDate); 
            }
            catch (Exception)
            {
                return null;
            }
          
        }

        /// <summary>
        /// Lấy danh sách các sản phẩm theo id của hóa đơn
        /// </summary>
        /// <param name="invoiceId">Id của hóa đơn</param>
        /// <returns>Danh sách các sản phẩm</returns>
        /// Người tạo: ntxuan (11/5/2019)
        [Route("GetProducs/{invoiceId}")]
        public async Task<IEnumerable<InvoiceDetailAjaxResult>> Post(Guid invoiceId)
        {
            try
            {
                List<InvoiceDetailAjaxResult> InvoiceDetailAjaxResults = new List<InvoiceDetailAjaxResult>();
                List<InvoiceDetail> invoiceDetails = Extention.GetListInvoiceDetailsByInvoiceId(invoiceId);
                foreach (var item in invoiceDetails)
                {
                    var InvoiceDetailAjaxResult = new InvoiceDetailAjaxResult(item);
                    InvoiceDetailAjaxResults.Add(InvoiceDetailAjaxResult);
                }
                await Task.Delay(300);
                return InvoiceDetailAjaxResults;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy danh sách các nhà cung cấp để đổ dữ liệu xuống client
        /// </summary>
        /// <returns>Danh sách nhà cung cấp</returns>
        /// Người tạo: ntxuan (13/5/2019)
        [Route("GetSuppliers")]
        public IEnumerable<SupplierAjaxResult> GetSuppliers()
        {
            try
            {
                List<SupplierAjaxResult> suppliers = new List<SupplierAjaxResult>();
                foreach (var item in MshopkeeperDB.Suppliers)
                {
                    var supplierAjaxResult = new SupplierAjaxResult(item);
                    suppliers.Add(supplierAjaxResult);
                }
                return suppliers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy danh sách nhân viên để trả dữ liệu cho client
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// Người tạo: ntxuan (13/5/2019)
        [Route("GetEmployees")]
        public IEnumerable<EmployeeAjaxResult> GetEmployees()
        {
            try
            {
                List<EmployeeAjaxResult> employees = new List<EmployeeAjaxResult>();
                foreach (var item in MshopkeeperDB.Employees)
                {
                    var employeeAjaxResult = new EmployeeAjaxResult(item);
                    employees.Add(employeeAjaxResult);
                }
                return employees;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lưu hóa đơn lên server
        /// </summary>
        /// <returns>trạng thái thành công/ thất bại</returns>
        /// Người tạo: ntxuan (17/5/2019)
        [HttpPost]
        [Route("SaveNewInvoice")]
        public Guid SaveNewInvoice(InvoiceAjaxResult invoiceAjaxResult)
        {
            return Extention.CreateInvoice(invoiceAjaxResult);
        }

        /// <summary>
        /// Hàm lưu hóa đơn lên server khi sửa đổi
        /// </summary>
        /// <returns>trạng thái thành công/ thất bại</returns>
        /// Người tạo: ntxuan (17/5/2019)
        [HttpPost]
        [Route("SaveEditInvoice")]
        public Guid SaveEditInvoice(InvoiceAjaxResult invoiceAjaxResult)
        {
            return Extention.SaveEditInvoice(invoiceAjaxResult);
        }

        /// <summary>
        /// Hàm lưu các sản phẩm của hóa đơn
        /// </summary>
        /// <returns>trạng thái thành công/ thất bại</returns>
        /// Người tạo: ntxuan (17/5/2019)
        [HttpPost]
        [Route("SaveListInvoiceDetail")]
        public bool SaveListInvoiceDetail(List<InvoiceDetailAjaxResult> invoiceDetailAjaxResults)
        {
            try
            {
                var InvoiceId = invoiceDetailAjaxResults[0].InvoiceId;
                var listInvoiceDetail = MshopkeeperDB.InvoiceDetails.Where(s => s.InvoiceId == InvoiceId).ToList();
                foreach (var item in listInvoiceDetail)
                {
                        MshopkeeperDB.InvoiceDetails.Remove(item);
                }

                foreach (var item in invoiceDetailAjaxResults)
                {
                    var invoiceDetail = Extention.MapInvoiceDetailAjaxResultToInvoiceDetail(item);
                    MshopkeeperDB.InvoiceDetails.Add(invoiceDetail);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm xóa một hóa đơn
        /// </summary>
        /// <returns>trạng thái thành công/ thất bại</returns>
        /// Người tạo: ntxuan (17/5/2019)
        [HttpPost]
        [Route("DeleteInvoice/{invoiceId}")]
        public bool DeleteInvoice(Guid invoiceId)
        {
            try
            {
                Extention.DeleteInvoice(invoiceId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm dùng để xóa nhiều hóa đơn
        /// </summary>
        /// <returns>Trạng thái thành công</returns> 
        /// Người tạo: ntxuan (25/5/2019)
        [HttpPost]
        [Route("DeleteMultiInvoice")]
        public bool DeleteMultiInvoice(List<Guid> listInvoiceId)
        {
            try
            {
                foreach (var InvoiceId in listInvoiceId)
                {
                    Extention.DeleteInvoice(InvoiceId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm dùng để xóa nhiều hóa đơn
        /// </summary>
        /// <returns>Trạng thái thành công</returns>
        /// Người tạo: ntxuan (25/5/2019)
        [HttpPost]
        [Route("GetDataFilter")]
        public IEnumerable<InvoiceAjaxResult> GetDataFilter(InvoiceDto invoiceDto)
        {
            try
            {
                List<InvoiceAjaxResult> invoiceAjaxResults = new List<InvoiceAjaxResult>();

                foreach (var item in Extention.GetListInvoiceByFilter(invoiceDto))
                {
                    var invoiceAjaxResult = new InvoiceAjaxResult(item);
                    invoiceAjaxResults.Add(invoiceAjaxResult);
                }
                return invoiceAjaxResults;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm dùng để lấy tất các hàng hóa
        /// </summary>
        /// <returns>Danh sách hàng hóa</returns>
        /// Người tạo: ntxuan (25/5/2019)
        [HttpGet]
        [Route("GetListMerchandise")]
        public IEnumerable<Product> GetListMerchandise()
        {
            try
            {
                return MshopkeeperDB.Products;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
