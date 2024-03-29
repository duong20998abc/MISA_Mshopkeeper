﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Commons
{
    public class Filter
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// Hàm thực hiện build chuỗi câu điều kiện Where
        /// </summary>
        /// <param name="filters">List các trường Filter</param>
        /// <returns>chuỗi where cho câu truy vấn dữ liệu</returns>
        /// Tạo bởi: NBDUONG (26/06/2018)
        public static string BuildWhereFilterCondition(List<Filter> filters)
        {
            //string where = string.Empty;
            StringBuilder where = new StringBuilder();
            foreach (var item in filters)
            {
                switch (item.DataType)
                {
                    case "decimal":
                    case "number": 
                    case "float":
                        where.AppendFormat(" AND {0} {1} {2}", item.Field, item.Type, item.Value);
                        break;
                    default:
                        where.Append(BuildFilterWhereConditionForStringType(item));
                        break;
                }
            }

            return where.ToString();
        }
        /// <summary>
        /// Hàm thực hiện build chuỗi câu điều kiện Where - sử dụng cho kiểu dữ liệu của input là string
        /// </summary>
        /// <param name="filters">List các trường Filter</param>
        /// <returns>chuỗi where cho câu truy vấn dữ liệu</returns>
        /// Tạo bởi: NBDUONG (26/06/2018)
        private static string BuildFilterWhereConditionForStringType(Filter filter)
        {
            string where = string.Empty;
            switch (filter.Type)
            {
                case "=":
                    where = String.Format(" AND {0} = N'{1}'", filter.Field, filter.Value);
                    break;
                case "+":
                    where = String.Format(" AND {0} LIKE N'{1}%'", filter.Field, filter.Value);
                    break;
                case "-":
                    where = String.Format(" AND {0} LIKE N'%{1}'", filter.Field, filter.Value);
                    break;
                case "!":
                    where = String.Format(" AND {0} NOT LIKE N'%{1}%'", filter.Field, filter.Value);
                    break;
                case ">":
                    where = String.Format(" AND {0} > N'{1}'", filter.Field, filter.Value);
                    break;
                case "<":
                    where = String.Format(" AND {0} < N'{1}'", filter.Field, filter.Value);
                    break;
                case "&ge;":
                    where = String.Format(" AND {0} >= N'{1}'", filter.Field, filter.Value);
                    break;
                case "&le;":
                    where = String.Format(" AND {0} <= N'{1}'", filter.Field, filter.Value);
                    break;
                default:
                    where = String.Format(" AND {0} LIKE N'%{1}%'", filter.Field, filter.Value);
                    break;
            }
            if(filter.Value == "Tất cả")
            {
                where = "";
            }
            return where;
        }
    }
}
