using System;
using System.Collections.Generic;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp Khách hàng
    /// Lưu trữ thông tin khách hàng
    /// </summary>
    /// Created date: 28/05/2019
    /// Author: NTDuong
    public class Customer
    {
        #region MemberVariables
        /// <summary>
        /// ID Khách hàng
        /// </summary>
        private Guid _customerID;
        private string _customerCode;
        private string _customerName;
        private string _phoneNumber;
        private bool _gender;
        private DateTime _dateOfBirth;
        private string _customerGroupName;
        private string _note;
        private bool _status;
        #endregion

        #region Constructors
        public Customer() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_customerID"></param>
        /// <param name="_customerCode"></param>
        /// <param name="_customerName"></param>
        /// <param name="_phoneNumber"></param>
        /// <param name="_gender"></param>
        /// <param name="_dateOfBirth"></param>
        /// <param name="_customerGroupName"></param>
        /// <param name="_note"></param>
        /// <param name="_status"></param>
        public Customer(Guid _customerID, string _customerCode, string _customerName, string _phoneNumber, 
            bool _gender, DateTime _dateOfBirth, string _customerGroupName, string _note, bool _status)
        {
            this._customerID = _customerID;
            this._customerCode = _customerCode;
            this._customerName = _customerName;
            this._phoneNumber = _phoneNumber;
            this._gender = _gender;
            this._dateOfBirth = _dateOfBirth;
            this._customerGroupName = _customerGroupName;
            this._note = _note;
            this._status = _status;
        }


        #endregion

        #region Fields
        /// <summary>
        /// ID Khách hàng
        /// </summary>
        public Guid CustomerID
        {
            get
            {
                return _customerID;
            }

            set
            {
                _customerID = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return _customerCode;
            }

            set
            {
                _customerCode = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }

            set
            {
                _customerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        public bool Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
            }
        }

        public string CustomerGroupName
        {
            get
            {
                return _customerGroupName;
            }

            set
            {
                _customerGroupName = value;
            }
        }

        public string Note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value;
            }
        }

        public bool Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }
        #endregion

        #region Methods
        public static List<Customer> ListCustomer()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer(Guid.NewGuid(), "KH00001", "Nguyễn Tuấn Dương", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00002", "Nguyễn Tuấn Anh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00003", "Nguyễn Thị Linh", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00004", "Nguyễn Tuấn Minh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00005", "Nguyễn Tuấn Dương", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00006", "Nguyễn Tuấn Anh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00007", "Nguyễn Thị Linh", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00008", "Nguyễn Tuấn Minh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00009", "Nguyễn Tuấn Dương", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00010", "Nguyễn Tuấn Anh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00011", "Nguyễn Thị Linh", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00012", "Nguyễn Tuấn Minh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00013", "Nguyễn Tuấn Dương", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00014", "Nguyễn Tuấn Anh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00015", "Nguyễn Thị Linh", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00016", "Nguyễn Tuấn Minh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00017", "Nguyễn Tuấn Dương", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00018", "Nguyễn Tuấn Anh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false),
                new Customer(Guid.NewGuid(), "KH00019", "Nguyễn Thị Linh", "0123456789", false, DateTime.Now, "Khách VIP", "ghi chú", true),
                new Customer(Guid.NewGuid(), "KH00020", "Nguyễn Tuấn Minh", "0123456789", true, DateTime.Now, "Khách VIP", "ghi chú", false)
            };
            

            return customers;
        }
        #endregion
    }
}