using System;
using System.Collections.Generic;

namespace MISA.Mshopkeeper.Models
{
    /// <summary>
    /// Lớp dùng để khởi tạo dữ liệu cho các bảng dữ liệu
    /// </summary>
    /// Người tạo: ntxuan(11/5/2019)
    public class MshopkeeperDB
    {
        /// <summary>
        /// Danh sách nhân viên
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Employee> Employees = new List<Employee>
            {
                new Employee{EmployeeName = "Nguyễn Tiến Xuân", EmployeeCode = "NV00001", EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),Address = "Phú thọ"},
                new Employee{EmployeeName = "Nguyễn Văn Hùng", EmployeeCode = "NV00002", EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"),Address = "Hà Nội"},
                new Employee{EmployeeName = "Nguyễn Tuấn Đức", EmployeeCode = "NV00003", EmployeeId = new Guid("c23ae13f-b072-49ab-ae52-54d9e05ff3ba"),Address = "Thanh Hóa"},
                new Employee{EmployeeName = "Nguyễn Quốc Bình", EmployeeCode = "NV00004", EmployeeId = new Guid("49d59456-856c-4552-a08c-16a54558545e"),Address = "Nghệ An"},
                new Employee{EmployeeName = "Nguyễn Quang Hiếu", EmployeeCode = "NV00005", EmployeeId = new Guid("6456d442-d02b-4096-8016-42e7b4b5c1cc"),Address = "Hà Tĩnh"},
                new Employee{EmployeeName = "Nguyễn Nam Cường", EmployeeCode = "NV00006", EmployeeId = new Guid("6f262394-3897-4407-96f1-32a96ff9ced2"),Address = "Quảng Bình"},
                new Employee{EmployeeName = "Trần Văn An", EmployeeCode = "NV00007", EmployeeId = new Guid("7cadf25f-5c97-47c2-94b9-327ef59f3790"),Address = "Quảng Trị"},
                new Employee{EmployeeName = "Trần Văn Chung", EmployeeCode = "NV00008", EmployeeId = new Guid("d7d74a71-4731-431d-92e2-0ea6208df9d9"),Address = "Thanh Hóa"},
                new Employee{EmployeeName = "Cao Quyết Thắng", EmployeeCode = "NV00009", EmployeeId = new Guid("20f729e6-e6a6-4079-9d40-d79256e7c19d"),Address = "Nghệ An"},
                new Employee{EmployeeName = "Đỗ Tiến Thắng", EmployeeCode = "NV000010", EmployeeId = new Guid("94efb818-4beb-4c4e-b8cc-0f960391e783"),Address = "Hà Nội"}
            };

        /// <summary>
        /// Danh sách hóa đơn
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Invoice> Invoices = new List<Invoice>
            {
                new Invoice{TypeInvoice = 1,Deliver = "Cao Đức Mạnh", Explanation = "Mua hàng online", ImportDate = new DateTime(2018, 6, 1), ImportNumber = "N0001",ImportTime = "3:00",EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"),SupplierId = new Guid("1ffb11a4-43ff-4a6f-9583-096280d540d5"), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Tiến Việt", Explanation = "Mua hàng online2", ImportDate = new DateTime(2018, 3, 11), ImportNumber = "N0002",ImportTime = "4:00",EmployeeId = new Guid("49d59456-856c-4552-a08c-16a54558545e"),SupplierId = new Guid("a5a59a2c-e4e9-4239-a802-5c31ae503b38"), InvoiceId = new Guid("3df2f0fb-9a61-4e71-96a0-eb68c3951528") },
                new Invoice{TypeInvoice = 1,Deliver = "Đỗ Quốc Tuấn", Explanation = "Mua hàng online3", ImportDate = new DateTime(2019, 5, 9), ImportNumber = "N0003",ImportTime = "6:00",EmployeeId = new Guid("7cadf25f-5c97-47c2-94b9-327ef59f3790"),SupplierId = new Guid("90e88365-9aac-4b55-85c7-bfbe17078ec6"), InvoiceId = new Guid("446c214e-f9bd-42ec-a6aa-a5a3084c57e5") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Thị Hoa", Explanation = "Mua hàng online4", ImportDate = new DateTime(2019, 5, 22), ImportNumber = "N0004",ImportTime = "7:00",EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),SupplierId = new Guid("b473bd63-2b57-4008-b10a-38d59ad7180c"), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Thị Thu", Explanation = "Mua hàng online5", ImportDate =new DateTime(2019, 5, 6), ImportNumber = "N0005",ImportTime = "9:00",EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),SupplierId = new Guid("90e88365-9aac-4b55-85c7-bfbe17078ec6"), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430") },
                new Invoice{TypeInvoice = 1,Deliver = "Đỗ Thị Nhung", Explanation = "Mua hàng online6", ImportDate = new DateTime(2018, 11, 14), ImportNumber = "N0006",ImportTime = "10:00",EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"),SupplierId = new Guid("b473bd63-2b57-4008-b10a-38d59ad7180c"), InvoiceId = new Guid("cc90e872-a317-4771-b46f-e0f0f17e9031") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Tiến Thắng", Explanation = "Mua hàng online7", ImportDate = new DateTime(2018, 12, 21), ImportNumber = "N0007",ImportTime = "10:00",EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"),SupplierId = new Guid("a5a59a2c-e4e9-4239-a802-5c31ae503b38"), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0") },
                new Invoice{TypeInvoice = 1,Deliver = "Đỗ Đức Dũng", Explanation = "Mua hàng online8", ImportDate = new DateTime(2019, 4, 5), ImportNumber = "N0008",ImportTime = "10:00",EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),SupplierId = new Guid("a5a59a2c-e4e9-4239-a802-5c31ae503b38"), InvoiceId = new Guid("75965e0f-4ba7-4309-a8b5-e68880e9f780") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Việt Dũng", Explanation = "Mua hàng online9", ImportDate =new DateTime(2019, 5, 21), ImportNumber = "N0009",ImportTime = "10:00",EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),SupplierId = new Guid("5bba3efb-49b3-48a0-94e3-6609c7470895"), InvoiceId = new Guid("c3797e3f-3a0b-40ec-b4de-1450dfda7571") },
                new Invoice{TypeInvoice = 1,Deliver = "Nguyễn Thị Ngân", Explanation = "Mua hàng online10", ImportDate = new DateTime(2019, 5, 17), ImportNumber = "N00010",ImportTime = "2:00",EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"),SupplierId = new Guid("b20d7c60-2252-4731-93d6-774432777138"), InvoiceId = new Guid("7c96e7a0-d499-4222-94ba-8de93c952dec") }
            };

        /// <summary>
        /// Danh sách nhà cung cấp
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Supplier> Suppliers = new List<Supplier>
            {
                new Supplier{SupplierName = "Nhà may Việt Hà", Address = "Hà Nội", SupplierCode = "SUP000001", SupplierId = new Guid("1ffb11a4-43ff-4a6f-9583-096280d540d5")},
                new Supplier{SupplierName = "Nhà may Quảng Châu", Address = "Hà Nội", SupplierCode = "SUP000002", SupplierId = new Guid("b473bd63-2b57-4008-b10a-38d59ad7180c")},
                new Supplier{SupplierName = "Nhà may Hồng Vân", Address = "Hà Nội", SupplierCode = "SUP000003", SupplierId = new Guid("dcc839f4-01de-4608-95e5-7ca45537eb5f")},
                new Supplier{SupplierName = "ZENA", Address = "Hà Nội", SupplierCode = "SUP000004", SupplierId = new Guid("a5a59a2c-e4e9-4239-a802-5c31ae503b38")},
                new Supplier{SupplierName = "JUNA", Address = "Hà Nội", SupplierCode = "SUP000005", SupplierId = new Guid("90e88365-9aac-4b55-85c7-bfbe17078ec6")},
                new Supplier{SupplierName = "Nhà may Phú thọ", Address = "Phú Thọ", SupplierCode = "SUP000006", SupplierId = new Guid("5bba3efb-49b3-48a0-94e3-6609c7470895")},
                new Supplier{SupplierName = "Nhà may Hà Nam", Address = "Thanh Hóa", SupplierCode = "SUP000007", SupplierId = new Guid("e5e4d1a2-be5f-4df5-a1ba-016f98c35543")},
                new Supplier{SupplierName = "Nhà may Hòa Bình", Address = "Nghệ An", SupplierCode = "SUP000008", SupplierId = new Guid("8663a6af-dac5-46d5-bbde-c70800551ad9")},
                new Supplier{SupplierName = "Nhà may Nghệ An", Address = "Hà Tĩnh", SupplierCode = "SUP000009", SupplierId = new Guid("83d15df2-c415-42a2-b213-e6cbaf3e8208")},
                new Supplier{SupplierName = "Nhà may Hà Nội", Address = "Quảng Bình", SupplierCode = "SUP0000010", SupplierId = new Guid("b20d7c60-2252-4731-93d6-774432777138")}
            };

        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Product> Products = new List<Product>
            {
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo phông trắng", SKU = "APT-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 100000, Barcode="N0000001"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo phông đen", SKU = "APT-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 120000, Barcode="N0000002"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo sơ mi trắng", SKU = "ASM-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 300000, Barcode="N0000003"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo phông xanh", SKU = "APT-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 100000, Barcode="N0000004"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo sơ mi xanh", SKU = "ASM-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 240000, Barcode="N0000005"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Áo sơ mi đen", SKU = "ASM-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 250000, Barcode="N0000006"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Váy đen", SKU = "V-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 280000, Barcode="N0000007"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Váy trắng", SKU = "V-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 150000, Barcode="N0000008"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Váy hồng", SKU = "V-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 350000, Barcode="N0000009"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Quần đùi", SKU = "Q-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 14000, Barcode="N0000010"},
                new Product{ProductId = Guid.NewGuid(), ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 160000, Barcode="N00000011"},
            };

        /// <summary>
        /// Danh sách hóa đơn chi tiết
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<InvoiceDetail> InvoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail {DiscountPercentage = 10, Quantity = 20, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo phông trắng", SKU = "APT-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 100000,  TaxPercentage = 5},
                new InvoiceDetail {DiscountPercentage = 12, Quantity = 16, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo phông đen", SKU = "APT-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 120000,   TaxPercentage = 15},
                new InvoiceDetail {DiscountPercentage = 14, Quantity = 24, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo sơ mi trắng", SKU = "ASM-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 300000, TaxPercentage = 10},
                new InvoiceDetail {DiscountPercentage = 15, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo phông xanh", SKU = "APT-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 100000,  TaxPercentage = 11},
                new InvoiceDetail {DiscountPercentage = 20, Quantity = 25, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo sơ mi xanh", SKU = "ASM-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 240000,  TaxPercentage = 5},
                new InvoiceDetail {DiscountPercentage = 30, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("023a9335-1c97-4d34-8db4-aa8c55596349"),ProductName = "Áo sơ mi đen", SKU = "ASM-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 250000,  TaxPercentage = 15},
                new InvoiceDetail {DiscountPercentage = 24, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("3df2f0fb-9a61-4e71-96a0-eb68c3951528"),ProductName = "Váy đen", SKU = "V-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 280000,   TaxPercentage = 20},
                new InvoiceDetail {DiscountPercentage = 52, Quantity = 15, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("3df2f0fb-9a61-4e71-96a0-eb68c3951528"),ProductName = "Váy trắng", SKU = "V-02", Storage = "cty", Unit = "Chiếc", UnitPrice = 150000,  TaxPercentage = 30},
                new InvoiceDetail {DiscountPercentage = 15, Quantity = 12, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("446c214e-f9bd-42ec-a6aa-a5a3084c57e5"),ProductName = "Váy hồng", SKU = "V-03", Storage = "cty", Unit = "Chiếc", UnitPrice = 350000,  TaxPercentage = 40},
                new InvoiceDetail {DiscountPercentage = 22, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("446c214e-f9bd-42ec-a6aa-a5a3084c57e5"),ProductName = "Quần đùi", SKU = "Q-01", Storage = "cty", Unit = "Chiếc", UnitPrice = 14000,  TaxPercentage = 20},
                new InvoiceDetail {DiscountPercentage = 12, Quantity = 16, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("446c214e-f9bd-42ec-a6aa-a5a3084c57e5"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 160000, TaxPercentage = 35},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 19, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Váy trắng", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 250000, TaxPercentage = 20},
                new InvoiceDetail {DiscountPercentage = 42, Quantity = 18, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 230000,  TaxPercentage = 45},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 14, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Váy trắng", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 14000,  TaxPercentage = 65},
                new InvoiceDetail {DiscountPercentage = 31, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 170000,  TaxPercentage = 75},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 19, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 160000,  TaxPercentage = 45},
                new InvoiceDetail {DiscountPercentage = 13, Quantity = 12, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("9b90aaef-37d0-431d-94d4-44cfbc889fe6"),ProductName = "Áo sơ mi đen", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 180000, TaxPercentage = 95},
                new InvoiceDetail {DiscountPercentage = 22, Quantity = 11, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Váy trắng", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 190000,  TaxPercentage = 23},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 160000, TaxPercentage =34},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 31, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 230000,  TaxPercentage = 45},
                new InvoiceDetail {DiscountPercentage = 42, Quantity = 31, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Áo sơ mi đen", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 145000,  TaxPercentage = 26},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 41, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 40000,  TaxPercentage = 27},
                new InvoiceDetail {DiscountPercentage = 62, Quantity = 21, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Áo sơ mi đen", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 60000, TaxPercentage = 37},
                new InvoiceDetail {DiscountPercentage = 72, Quantity = 31, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("99aa78b2-1273-42ee-b147-8fce1dff2430"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 80000,  TaxPercentage = 28},
                new InvoiceDetail {DiscountPercentage = 72, Quantity = 31, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("c3797e3f-3a0b-40ec-b4de-1450dfda7571"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 80000,  TaxPercentage = 28},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 13, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0"),ProductName = "Áo sơ mi đen", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 20000,  TaxPercentage = 27},
                new InvoiceDetail {DiscountPercentage = 23, Quantity = 14, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 350000,  TaxPercentage = 29},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 15, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 570000,  TaxPercentage = 19},
                new InvoiceDetail {DiscountPercentage = 34, Quantity = 16, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 290000, TaxPercentage = 27},
                new InvoiceDetail {DiscountPercentage = 32, Quantity = 17, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("a63ca6ea-7c23-447e-a8a9-b4dde3e476f0"),ProductName = "Quần jeans", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 200000,  TaxPercentage = 28},
                new InvoiceDetail {DiscountPercentage = 56, Quantity = 18, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("7c96e7a0-d499-4222-94ba-8de93c952dec"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 160000,  TaxPercentage = 20},
                new InvoiceDetail {DiscountPercentage = 78, Quantity = 19, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("7c96e7a0-d499-4222-94ba-8de93c952dec"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 300000,  TaxPercentage = 24},
                new InvoiceDetail {DiscountPercentage = 43, Quantity = 20, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("7c96e7a0-d499-4222-94ba-8de93c952dec"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 400000,  TaxPercentage = 27},
                new InvoiceDetail {DiscountPercentage = 43, Quantity = 20, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("cc90e872-a317-4771-b46f-e0f0f17e9031"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 400000,  TaxPercentage = 27},
                new InvoiceDetail {DiscountPercentage = 43, Quantity = 20, InvoiceDetailId = Guid.NewGuid(), InvoiceId = new Guid("75965e0f-4ba7-4309-a8b5-e68880e9f780"),ProductName = "Áo sơ mi xanh", SKU = "Q-02J", Storage = "cty", Unit = "Chiếc", UnitPrice = 400000,  TaxPercentage = 27}
            };                     

        /// <summary>
        /// Danh sách loại người
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<PersonType> PersonTypes = new List<PersonType>
            {
                new PersonType { PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101"), PersonTypeName = "Nhân viên"},
                new PersonType { PersonTypeId = new Guid("6986a672-b4f0-4df3-869c-7004ddec928b"), PersonTypeName = "Nhà cung cấp"},
                new PersonType { PersonTypeId = new Guid("79da8d68-f4ee-47d5-8642-ebec58bdd79b"), PersonTypeName = "Đối tác giao hàng"},
                new PersonType { PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7"), PersonTypeName = "Khách hàng"}
            };

        /// <summary>
        /// Danh sách đối tượng
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Person> People = new List<Person>
            {
                new Person { PersonId = new Guid("2b8b1085-210f-42b4-997b-6f9db2041369"), PersonCode = "NV00001", PersonName = "Cristiano Ronaldo", Address = "Bồ Đào Nha", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("29eab216-552e-4716-9111-1aa841edc3bf"), PersonCode = "NV00002", PersonName = "Ronaldo Lima", Address = "Brazil", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("f72adfc0-5cc9-4f78-8b5a-dc716346c78c"), PersonCode = "NV00003", PersonName = "Andrea Pirlo", Address = "Italia", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("29230529-c12e-4252-97e0-bffc267bb979"), PersonCode = "NV00004", PersonName = "Michel Platini", Address = "Pháp", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("1724a967-ebdf-48db-b61c-f4a3ea5a8cb5"), PersonCode = "NV00005", PersonName = "Ronaldinho", Address = "Brazil", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("8db1b70b-651b-4672-8ca6-721a8f8d11d0"), PersonCode = "NV00006", PersonName = "Zinedine Zidane", Address = "Pháp", PersonTypeId = new Guid("98a56b0c-c92b-43b3-8252-c5eff3413101")},
                new Person { PersonId = new Guid("ace8e765-9629-4f29-8317-af4d35b2deeb"), PersonCode = "DTGH00001", PersonName = "Giao hàng nhanh", Address = "Hà Nội", PersonTypeId = new Guid("79da8d68-f4ee-47d5-8642-ebec58bdd79b")},
                new Person { PersonId = new Guid("c27e6242-14f7-4c5a-9b7d-28ec2a48582f"), PersonCode = "DTGH00002", PersonName = "Giao hàng tiết kiệm", Address = "Hà Nội", PersonTypeId = new Guid("79da8d68-f4ee-47d5-8642-ebec58bdd79b")},
                new Person { PersonId = new Guid("a67dd408-eb14-4fb9-be3b-68c23d5a82f6"), PersonCode = "KH00001", PersonName = "Nguyễn Văn Đức", Address = "Mù Căng Chải - Sơn La", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("5dc667fa-06d9-4557-9dda-2bc2e1fae678"), PersonCode = "KH00002", PersonName = "Nguyễn Trung Chiến", Address = "Hà Nội", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("c7161377-48b8-444c-8282-b681deff340b"), PersonCode = "KH00003", PersonName = "Ngô Văn Hoàn", Address = "TP Hồ Chí Minh", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("9dbfdb0d-f877-4ee1-be70-a06796354e49"), PersonCode = "KH00004", PersonName = "Đỗ Tiến Minh", Address = "Bắc Giang", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("4854d2d0-d1da-484f-8852-da52b679e3cb"), PersonCode = "KH00005", PersonName = "Hoàng Trung Hiếu", Address = "Phú Yên", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("1c71667e-ca64-4963-bb44-a11f07f70ed5"), PersonCode = "KH00006", PersonName = "Hồ Vĩnh Khoa", Address = "Lào Cai", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
                new Person { PersonId = new Guid("7ae86f42-80cb-4cbf-86bb-451a0ec32abc"), PersonCode = "KH00007", PersonName = "Trịnh Văn Cường", Address = "Hải Phòng", PersonTypeId = new Guid("c79484cf-79a5-4340-8cbb-b1ebf04377d7")},
            };

        /// <summary>
        /// Danh sách loại chứng từ
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<DocumentType> DocumentTypes = new List<DocumentType>
            {
                new DocumentType {DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), DocumentTypeName = "Phiếu thu nợ - Tiền mặt"},
                new DocumentType {DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), DocumentTypeName = "Phiếu trả nợ - Tiền mặt"},
                new DocumentType {DocumentTypeId = new Guid("c6e3e2a8-384c-4528-baea-36b09ef2d812"), DocumentTypeName = "Phiếu chi tiền mặt"}
            };

        /// <summary>
        /// Danh sách chứng từ
        /// </summary>
        /// Người tạo: ntxuan (17/5/2019)
        public static List<Document> Documents = new List<Document>
            {
                new Document{ DocumentId = new Guid("809caf24-4f77-42bd-a0b4-f144ebda10e8"), DocumentCode = "PT00001", DocumentDate = new DateTime(2019,3,14), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("c7161377-48b8-444c-8282-b681deff340b"), TotalMoney = 5000000, MoneyHasToPay = 1250000, MoneyHasNotPaid = 1250000, AmountPaid = 0, EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"), ReceiverName = "Ngô Đức Hiếu", IsPaid = false, CheckType = 1},
                new Document{ DocumentId = new Guid("a2677880-6db4-4a6c-a7c0-9170406479f5"), DocumentCode = "PC00002", DocumentDate = new DateTime(2019,3,17), Reason = "Trả nợ cho khách hàng", DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), PersonId = new Guid("7ae86f42-80cb-4cbf-86bb-451a0ec32abc"), TotalMoney = 1000000 ,MoneyHasToPay = 750000, MoneyHasNotPaid = 750000, AmountPaid = 0, EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"), ReceiverName = "Nguyễn Chí Dũng", IsPaid = true, CheckType = 1},
                new Document{ DocumentId = new Guid("cae67572-58ab-49ce-90f6-45c7b1bbc590"), DocumentCode = "PC00003", DocumentDate = new DateTime(2019,4,29), Reason = "Trả nợ cho khách hàng", DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), PersonId = new Guid("4854d2d0-d1da-484f-8852-da52b679e3cb"), TotalMoney = 2000000, MoneyHasToPay = 1350000, MoneyHasNotPaid = 1250000, AmountPaid = 0, EmployeeId = new Guid("c23ae13f-b072-49ab-ae52-54d9e05ff3ba"), ReceiverName = "Hoàng Hải Hồng", IsPaid = true, CheckType = 2},
                new Document{ DocumentId = new Guid("3cabb741-c511-4d17-8dc8-c24cf2e55ff7"), DocumentCode = "PC00004", DocumentDate = new DateTime(2019,5,12), Reason = "Trả nợ cho khách hàng", DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), PersonId = new Guid("1c71667e-ca64-4963-bb44-a11f07f70ed5"), TotalMoney = 3000000, MoneyHasToPay = 1450000, MoneyHasNotPaid = 1250000, AmountPaid = 0, EmployeeId = new Guid("49d59456-856c-4552-a08c-16a54558545e"), ReceiverName = "Vi Tiểu Bảo", IsPaid = true, CheckType = 2},
                new Document{ DocumentId = new Guid("6b7d7627-32ee-4d7a-b0c9-c214f399da4d"), DocumentCode = "PT00005", DocumentDate = new DateTime(2019,4,27), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("a67dd408-eb14-4fb9-be3b-68c23d5a82f6"), TotalMoney = 4000000, MoneyHasToPay = 1550000, MoneyHasNotPaid = 1250000, AmountPaid = 0, EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"), ReceiverName = "Tiêu Văn Phong", IsPaid = false, CheckType = 1},
                new Document{ DocumentId = new Guid("752167a1-7665-4138-80ef-fa53093fd7ff"), DocumentCode = "PT00006", DocumentDate = new DateTime(2019,3,20), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("a67dd408-eb14-4fb9-be3b-68c23d5a82f6"), TotalMoney = 500000, MoneyHasToPay = 250000, MoneyHasNotPaid = 1250000, AmountPaid = 0, EmployeeId = new Guid("7cadf25f-5c97-47c2-94b9-327ef59f3790"), ReceiverName = "Trần Văn Tiến", IsPaid = true, CheckType = 1},
                new Document{ DocumentId = new Guid("edfd4dfa-22ac-4ed6-a768-c8f84dc5d0e5"), DocumentCode = "PC00007131", DocumentDate = new DateTime(2019,4,15), Reason = "Lương tháng 5", DocumentTypeId = new Guid("c6e3e2a8-384c-4528-baea-36b09ef2d812"), PersonId = new Guid("29eab216-552e-4716-9111-1aa841edc3bf"), TotalMoney = 15000000, MoneyHasToPay = 950000, MoneyHasNotPaid = 950000, AmountPaid = 0, EmployeeId = new Guid("49d59456-856c-4552-a08c-16a54558545e"), ReceiverName = "Đỗ Minh Đức", IsPaid = true, CheckType = 1},
                new Document{ DocumentId = new Guid("c743ac0b-9510-4585-ac29-674cfc7e5ef0"), DocumentCode = "PC0000112", DocumentDate = new DateTime(2019,5,19), Reason = "Lương tháng 5", DocumentTypeId = new Guid("c6e3e2a8-384c-4528-baea-36b09ef2d812"), PersonId = new Guid("29230529-c12e-4252-97e0-bffc267bb979"), TotalMoney = 15000000, MoneyHasToPay = 950000, MoneyHasNotPaid = 950000, AmountPaid = 0, EmployeeId = new Guid("7cadf25f-5c97-47c2-94b9-327ef59f3790"), ReceiverName = "Võ Văn Tòng", IsPaid = false, CheckType = 2},
                new Document{ DocumentId = new Guid("6b9a236b-7f3c-49be-b8a7-62a2986bf32a"), DocumentCode = "PT00008", DocumentDate = new DateTime(2019,2,28), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("5dc667fa-06d9-4557-9dda-2bc2e1fae678"), TotalMoney = 2500000, MoneyHasToPay = 2500000, MoneyHasNotPaid = 2000000, AmountPaid = 0, EmployeeId = new Guid("4d02ec22-af36-4b51-b799-d206414e38af"), ReceiverName = "Trịnh Hòa Khởi", IsPaid = true, CheckType = 1},
                new Document{ DocumentId = new Guid("591b2e73-fafe-4bd7-aa41-e06d87d5c395"), DocumentCode = "PT00009", DocumentDate = new DateTime(2019,3,7), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("c7161377-48b8-444c-8282-b681deff340b"), TotalMoney = 3500000, MoneyHasToPay = 3500000, MoneyHasNotPaid = 3000000, AmountPaid = 0, EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"), ReceiverName = "Lương Khải Siêu", IsPaid = true, CheckType = 2},
                new Document{ DocumentId = new Guid("566c5f4f-964f-46ba-a6ae-a4a0241d8fee"), DocumentCode = "PT00010", DocumentDate = new DateTime(2019,3,8), Reason = "Trả nợ cho khách hàng", DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), PersonId = new Guid("1724a967-ebdf-48db-b61c-f4a3ea5a8cb5"), TotalMoney = 2500000, MoneyHasToPay = 2500000, MoneyHasNotPaid = 2500000, AmountPaid = 0, EmployeeId = new Guid("6f262394-3897-4407-96f1-32a96ff9ced2"), ReceiverName = "Vũ Chiến Thắng", IsPaid = true, CheckType = 1},
                new Document{ DocumentId = new Guid("3f1cebc6-4590-4549-85ab-49dd46de2050"), DocumentCode = "PT00011", DocumentDate = new DateTime(2019,3,9), Reason = "Trả nợ cho khách hàng", DocumentTypeId = new Guid("a0b7fc93-66c8-4cb1-a416-e756f758e34f"), PersonId = new Guid("c7161377-48b8-444c-8282-b681deff340b"), TotalMoney = 1500000, MoneyHasToPay = 1500000, MoneyHasNotPaid = 1500000, AmountPaid = 0, EmployeeId = new Guid("20f729e6-e6a6-4079-9d40-d79256e7c19d"), ReceiverName = "Hà Minh Quang", IsPaid = false, CheckType = 2},
                new Document{ DocumentId = new Guid("4d722374-2963-478c-ba0c-f894d8e8554e"), DocumentCode = "PT00012", DocumentDate = new DateTime(2019,3,10), Reason = "Thu nợ của khách hàng", DocumentTypeId = new Guid("910ecf6a-d30f-4d72-b0af-47281ebcda11"), PersonId = new Guid("1c71667e-ca64-4963-bb44-a11f07f70ed5"), TotalMoney = 4500000, MoneyHasToPay = 4500000, MoneyHasNotPaid = 4500000, AmountPaid = 0, EmployeeId = new Guid("734994cf-cc7a-4e41-8815-13fa3aa06d09"), ReceiverName = "Hoàng Phi Hồng", IsPaid = false, CheckType = 1}
            };
    }
}