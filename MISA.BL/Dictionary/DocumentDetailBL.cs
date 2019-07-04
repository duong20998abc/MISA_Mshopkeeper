using MISA.Commons;
using MISA.DL.Dictionary;
using MISA.Entities.Dictionary;
using MISA.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Dictionary
{
    //Hàm xử lý tầng nghiệp vụ của DocumentDetail
    //Tạo bởi: NBDUONG(1/7/2019)
    public class DocumentDetailBL : BaseBL
    {
        //Tham số lấy dữ liệu từ tầng DL
        //Tạo bởi: NBDUONG(1/7/2019)
        private DocumentDetailDL _documentDetailDL;

        //Constructor
        public DocumentDetailBL()
        {
            _documentDetailDL = new DocumentDetailDL();
        }

        //Hàm lấy dữ liệu tất cả chi tiết chứng từ
        //Tạo bởi: NBDUONG(1/7/2019)
        public List<DocumentDetail> GetAllDocumentDetails(Guid documentDetailID)
        {
            var codeConvert = Common.ConvertToNvarchar(documentDetailID);
            return _documentDetailDL.GetDocumentDetails(codeConvert);
        }
    }
}
