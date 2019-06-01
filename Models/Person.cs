using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    //Lớp đối tượng (khách hàng, nhân viên,...)
    //Tạo bởi: NBDUONG (15/5/2019)
    public class Person
    {
        //Id
        public Guid PersonId { get; set; }
        //Mã đối tượng
        public string PersonCode { get; set; }
        //Tên đối tượng
        public string PersonName { get; set; }
        //Địa chỉ
        public string Address { get; set; }
        //Khóa ngoại tới bảng loại đối tượng
        public Guid PersonTypeId { get; set; }

        //Hàm khởi tạo
        public Person()
        {
            PersonId = Guid.NewGuid();
        }
    }
}