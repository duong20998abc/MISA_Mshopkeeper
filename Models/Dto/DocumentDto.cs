using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Mshopkeeper.Models.Dto
{
    public class DocumentDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TextFilter { get; set; }
        public string TypeFilter { get; set; }
    }
}