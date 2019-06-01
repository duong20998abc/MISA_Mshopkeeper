using MISA.Mshopkeeper.Models;
using MISA.Mshopkeeper.Models.AjaxResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MISA.Mshopkeeper.Controllers
{
    /// <summary>
    /// Hàm điều khiển các hoạt động của Quỹ tiền
    /// Tạo bởi: NBDUONG(15/5/2019)
    /// </summary>
    [RoutePrefix("fund")]
    public class FundController : ApiController
    {
        /// <summary>
        /// Hàm lấy ra danh sách chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(17/5/2019)
        [Route("documents")]
        public async Task<IEnumerable<DocumentAjaxResult>> GetDocumentAsync()
        {
            try
            {
                List<DocumentAjaxResult> documents = new List<DocumentAjaxResult>();
                foreach (var item in MshopkeeperDB.Documents)
                {
                    var document = new DocumentAjaxResult(item);
                    documents.Add(document);
               }
                await Task.Delay(1000);
                return documents;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy ra chứng từ theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(18/5/2019)
        [Route("{id}")]
        public async Task<DocumentAjaxResult> GetDocumentById(Guid id)
        {
            try
            {
                Document document = MshopkeeperDB.Documents.FirstOrDefault(x => x.DocumentId == id);
                var documentAjaxResult = new DocumentAjaxResult(document);
                await Task.Delay(100);
                return documentAjaxResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy ra chứng từ theo đối tượng nộp/nhận
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(18/5/2019)
        [Route("documents/person/{id}")]
        public async Task<IEnumerable<DocumentAjaxResult>> GetDocumentsByPersonId(Guid id)
        {
            try
            {
                List<DocumentAjaxResult> listDocuments = new List<DocumentAjaxResult>();
                foreach(var item in MshopkeeperDB.Documents)
                {
                    if(item.PersonId == id)
                    {
                        var document = new DocumentAjaxResult(item);
                        listDocuments.Add(document);
                    }
                }
                await Task.Delay(100);
                return listDocuments;
            }
            catch (Exception)
            {
                return null;
            }                                                                                                                                                                                                                                       
        }

        /// <summary>
        /// Hàm lấy ra danh sách đối tượng nộp, nhận
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(18/5/2019)
        [Route("people")]
        public async Task<IEnumerable<PersonAjaxResult>> GetPersonAsync()
        {
            try
            {
                List<PersonAjaxResult> people = new List<PersonAjaxResult>();
                foreach (var item in MshopkeeperDB.People)
                {
                    var person = new PersonAjaxResult(item);
                    people.Add(person);
                }
                await Task.Delay(1000);
                return people;
            }
            catch (Exception)
            {
                return null;
            }
        }
    
        /// <summary>
        /// Hàm lấy ra danh sách đối tượng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(19/5/2019)
        [Route("people/{id}")]
        public async Task<PersonAjaxResult> GetPersonById(Guid id)
        {
            try
            {
                Person person = MshopkeeperDB.People.FirstOrDefault(x => x.PersonId == id);
                var personAjaxResult = new PersonAjaxResult(person);
                await Task.Delay(100);
                return personAjaxResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy ra danh sách loại chứng từ
        /// </summary>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(24/5/2019)
        [Route("documentsType")]
        public async Task<IEnumerable<DocumentType>> GetDocumentType()
        {
            try
            {
                await (Task.Delay(100));
                return MshopkeeperDB.DocumentTypes.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm lấy ra danh sách đối tượng theo loại đối tượng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(19/5/2019)
       [Route("people/personType/{id}")]
        public async Task<IEnumerable<PersonAjaxResult>> GetPeopleByPersonType(Guid id)
        {
            List<PersonAjaxResult> listPeople = new List<PersonAjaxResult>();
            try
            {
                foreach(var item in listPeople)
                {
                    var person = MshopkeeperDB.People.FirstOrDefault(x => x.PersonTypeId == id);
                    var personAjaxResult = new PersonAjaxResult(person);
                    listPeople.Add(personAjaxResult);
                }
                await Task.Delay(1000);
                return listPeople;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Hàm tạo mới chứng từ
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(23/5/2019)
        [HttpPost]
        [Route("documents/new")]
        public bool CreateNewDocument(DocumentAjaxResult documentAjaxResult)
        {
            try
            {
                Extention.CreateDocument(documentAjaxResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm thay đổi thông tin chứng từ
        /// </summary>
        /// <param name="documentAjaxResult"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(28/5/2019)
        [HttpPost]
        [Route("documents/edit/{id}")]
        public bool EditDocument(DocumentAjaxResult documentAjaxResult)
        {
            try
            {
                Extention.EditDocument(documentAjaxResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm xóa chứng từ
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        /// Tạo bởi: NBDUONG(30/5/2019)
        [HttpPost]
        [Route("documents/delete/{documentId}")]
        public bool DeleteDocument(Guid documentId)
        {
            try
            {
                Extention.DeleteDocument(documentId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}