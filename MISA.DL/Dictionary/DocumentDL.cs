using MISA.Entities;
using MISA.Mshopkeeper.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Dictionary
{
    /// <summary>
    /// Hàm xử lý thao tác với dữ liệu về chứng từ
    /// Kế thừa lớp BaseDL xử lý nghiệp vụ tổng quát
    /// </summary>
    /// Tạo bởi: NBDUONG(19/6/2019)
    public class DocumentDL : BaseDL<Document>
    {
        /// <summary>
        /// Hàm lấy dữ liệu tất cả chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public List<Document> GetDocumentData()
        {
            return GetAll("Proc_GetAllData", "Document");
        }

        /// <summary>
        /// Hàm get dữ liệu chứng từ
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(27/6/2019)
        public AjaxResult GetDataPagination(int pageNumber, int pageSize, string where)
        {
            return GetDataPaginationBase("Proc_GetDocuments", "View_Document", pageNumber, pageSize, where);
        }

        /// <summary>
        /// Hàm lấy ra tổng số chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(22/6/2019)
        public int GetTotalDocument()
        {
            return GetTotalRecord("Proc_GetTotalRows", "Document");
        }

        /// <summary>
        /// Hàm lấy dữ liệu chứng từ theo Id
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public Document GetDocumentByID(string documentID)
        {
            return GetByAttribute("Proc_GetDataByAttribute", "Document", "DocumentID", documentID);
        }

        /// <summary>
        /// Hàm lấy dữ liệu tất cả chứng từ theo loại chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public List<Document> GetDocumentsByDocumentType(string Id)
        {
            return GetAllByAttribute("Proc_GetAllDataByAttribute", "Document", "DocumentTypeID", Id);
        }

        /// <summary>
        /// Hàm lấy dữ liệu tất cả chứng từ theo đối tượng
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public List<Document> GetDocumentsByPerson(string Id)
        {
            return GetAllByAttribute("Proc_GetAllDataByAttribute", "Document", "PersonID", Id);
        }

        /// <summary>
        /// Hàm lấy mã chứng từ sinh tự động
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(25/6/2019)
        public List<string> GetAutoRenderDocumentCode()
        {
            var listCode = new List<string>();
            using (DataAccess dataAccess = new DataAccess())
            {
                var sqlCommand = dataAccess.SqlCommand;
                sqlCommand.CommandText = "Proc_GetDocumentCodeAuto";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var documentCollectCode = (string)sqlDataReader.GetValue(0);
                    var documentPayCode = (string)sqlDataReader.GetValue(1);
                    listCode.Add(documentCollectCode);
                    listCode.Add(documentPayCode);
                    break;
                }
            }
            return listCode;
        }

        /// <summary>
        /// Hàm lấy chứng từ theo mã chứng từ
        /// </summary>
        /// <param name="documentCode"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(24/6/2019)
        public Document GetDocumentByDocumentCode(string documentCode)
        {
            return GetByAttribute("Proc_GetDataByAttribute", "Document", "DocumentCode", documentCode);
        }

        /// <summary>
        /// Hàm tạo mới chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public int CreateDocument(Document document)
        {
            return SaveEntity("Proc_CreateDocument", document);
        }

        /// <summary>
        /// Hàm thay đổi thông tin chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public int UpdateDocument(Document document)
        {
            return SaveEntity("Proc_UpdateDocument", document);
        }

        /// <summary>
        /// Hàm xóa chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(20/6/2019)
        public int DeleteDocument(string documentID)
        {
            return DeleteEntity("Proc_DeleteData", "Document", "DocumentID", documentID);
        }

        /// <summary>
        /// Hàm get dữ liệu chứng từ
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="tableName"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(27/6/2019)
        public AjaxResult GetDataPaginationBase(string storeName, string tableName, int pageNumber, int pageSize, string where)
        {
            var ajaxResult = new AjaxResult();
            var entities = new List<DocumentViewModel>();
            using (DataAccess dataAccess = new DataAccess())
            {
                // Khởi tạo đối tượng SqlDataReader hứng dữ liệu trả về:
                var sqlCommand = dataAccess.SqlCommand;
                sqlCommand.CommandText = storeName;
                sqlCommand.Parameters.AddWithValue("@TableName", tableName);
                sqlCommand.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize);
                sqlCommand.Parameters.AddWithValue("@Where", where);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var entity = new DocumentViewModel();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        // Lấy ra tên propertyName dựa vào tên cột của field hiện tại:
                        var propertyName = sqlDataReader.GetName(i);
                        // Lấy ra giá trị của field hiện tại:
                        var propertyValue = sqlDataReader.GetValue(i);
                        // Gán Value cho Property tương ứng:
                        var propertyInfo = entity.GetType().GetProperty(propertyName);
                        if (propertyInfo != null && propertyValue != DBNull.Value)
                        {
                            propertyInfo.SetValue(entity, propertyValue);
                        }
                    }
                    ajaxResult.TotalCount = (int)sqlDataReader.GetValue(20);
                    entities.Add(entity);
                }
            }

            ajaxResult.Data = entities;
            return ajaxResult;
        }
    }
}
