using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Hàm xây dựng đối tượng loại chứng từ
    /// Tạo bởi: NBDUONG (15/5/2019)
    /// </summary>
    public class DocumentType
    {
        //Id
        public Guid DocumentTypeId { get; set; }
        //Tên loại đối tượng
        public string DocumentTypeName { get; set; }

        //Hàm khởi tạo đối tượng loại chứng từ
        public DocumentType()
        {
            DocumentTypeId = Guid.NewGuid();
        }
    }
}