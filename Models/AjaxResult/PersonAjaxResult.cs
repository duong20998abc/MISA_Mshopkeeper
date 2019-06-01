using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models.AjaxResult
{
    public class PersonAjaxResult
    {
        //Id
        public Guid PersonId { get; set; }
        //Mã đối tượng
        public string PersonCode { get; set; }
        //Tên đối tượng
        public string PersonName { get; set; }
        //Địa chỉ
        public string Address { get; set; }
        //Loại đối tượng
        public string PersonType { get; set; }

        //Hàm khởi tạo
        public PersonAjaxResult(Person person)
        {
            PersonId = person.PersonId;
            PersonCode = person.PersonCode;
            PersonName = person.PersonName;
            Address = person.Address;
            PersonType = Extention.GetPersonTypeById(person.PersonTypeId).PersonTypeName;
        }
    }
}