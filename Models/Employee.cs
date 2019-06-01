using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp nhân viên
    /// </summary>
    /// Người tạo: ntxuan (10/5/2019)
    public class Employee
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
        /// Hàm khỏi tạo mặc định khi tạo đối tượng
        /// </summary>
        /// Người tạo: ntxuan(11/5/2019)
        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }
    }
}