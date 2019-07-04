using MISA.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Dictionary
{
    //Controller xử lý nghiệp vụ của chi tiết hóa đơn (DocumentDetail)
    //Tạo bởi: NBDUONG(1/7/2019)
    public class DocumentDetailDL : BaseDL<DocumentDetail>
    {
        //Hàm lấy dữ liệu của DocumentDetail
        //Tạo bởi: NBDUONG(1/7/2019)
        public List<DocumentDetail> GetDocumentDetails(string documentID)
        {
            return GetAllByAttribute("Proc_GetAllDataByAttribute", "View_DocumentDetail", "DocumentID", documentID);
        }
    }
}
