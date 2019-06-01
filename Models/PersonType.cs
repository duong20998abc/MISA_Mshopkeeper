using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    //Lớp loại đối tượng
    //Tạo bởi: NBDUONG(15/5/2019)
    public class PersonType
    {
        //Id
        public Guid PersonTypeId { get; set; }
        //Tên loại
        public string PersonTypeName { get; set; }

        //Hàm khởi tạo
        public PersonType()
        {
            PersonTypeId = Guid.NewGuid();
        }
    }
}