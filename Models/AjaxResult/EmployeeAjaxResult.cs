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
    public class EmployeeAjaxResult
    {
        // id nhân viên
        public Guid EmployeeId { get; set; }
        // Tên nhân viên
        public string EmployeeName { get; set; }
        // Mã nhân viên
        public string EmployeeCode { get; set; }
        // Địa chỉ
        public string Address { get; set; }

        /// <summary>
        /// Hàm khởi tạo các giá trị mặc định khi tạo mới đối tượng
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên truyền vào</param>
        /// Người tạo: ntxuan (13/5/2019)
        public EmployeeAjaxResult(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            EmployeeName = employee.EmployeeName;
            EmployeeCode = employee.EmployeeCode;
            Address = employee.Address;
        }
    }
}