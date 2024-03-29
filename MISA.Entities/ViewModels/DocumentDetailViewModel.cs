﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities.ViewModels
{
    /// <summary>
    /// Lớp để lấy dữ liệu chi tiết chứng từ
    /// Tạo bởi: NBDUONG(15/5/2019)
    /// </summary>
    public class DocumentDetailViewModel
    {
        #region Properties
        //Khóa chính
        public Guid DocumentDetailID { get; set; }
        //Diễn giải
        public string Description { get; set; }
        //Số tiền
        public decimal Amount { get; set; }
        //Loại chứng từ
        public string DocumentTypeName { get; set; }
        #endregion

        #region ForeignKeys
        //Khóa ngoại đến bảng DocumentType
        public Guid DocumentTypeID { get; set; }
        //Khóa ngoại đến bảng Document
        public Guid DocumentID { get; set; }
        #endregion

        #region Constructors
        //Hàm khởi tạo
        public DocumentDetailViewModel()
        {
            DocumentDetailID = Guid.NewGuid();
        }
        #endregion
    }
}
