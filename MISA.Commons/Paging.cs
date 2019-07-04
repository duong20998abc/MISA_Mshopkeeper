using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Commons
{
    //Class tạo đối tượng phân trang
    //Tạo bởi: NBDUONG(26/6/2019)
    public class Paging<T>
    {
        public List<T> Entities { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
    }
}
