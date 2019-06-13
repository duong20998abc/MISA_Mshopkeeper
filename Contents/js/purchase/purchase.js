


// Lóp này để điều khiển hành động mua hàng
// Người tạo: NTXUAN (28/04/2019)
class Purchase  {
   
    // Hàm khởi tạo
    // Người tạo: NTXUAN (28/04/2019)
    constructor() {
        // Biến cho phép dùng các phím tắt
        this.allowHotKey = true;
        this.initEvent();
    }

    // Khởi tạo các sự kiện trong trang mua hàng
    // Người tạo: NTXUAN (29/04/2019)
    initEvent() {
        this.setEventDefault();
        this.getDataFromServer(true);
        this.setResizeAble();
        this.setHeightForElement();
        this.setEventShowHide();
        this.setDatePickerForElement();
        this.setStatusChecked();
        this.setAllHotKey();
        this.setValueTimeRange();
        this.setEventMenuBarInvoice();
        this.setAllEventPaging();
        this.sortInvoiceByImportDate();
        this.setEventSearchFilterInvoice();
    }

    // Sự kiện dùng để lọc các hóa đơn theo người dùng nhập vào tìm kiếm
    // Người tạo: ntxuan (27/5/2019)
    setEventSearchFilterInvoice() {
        // Khi bấm vào icon search
        $(".header-column2 .option, .header-column3 .option, .header-column6 .option").click(function () {
            let TextFilter = $(this).next().val().trim();
            let TypeFilter = $(this).next().attr("class").trim();
            purchase.getDataFilter(TextFilter, TypeFilter);
        });
        // Khi nhấn enter tìm kiếm
        $(".header-column2 input, .header-column3 input, .header-column6 input").keydown(function () {
            if (event.keyCode === 13) {
                let TextFilter = $(this).val().trim();
                let TypeFilter = $(this).attr("class").trim();
                purchase.getDataFilter(TextFilter, TypeFilter);
            }
        });
    }

    // Hàm dùng để lọc dữ liệu
    // Người tạo: ntxuan (27/5/2019)
    getDataFilter(TextFilter, TypeFilter) {
        let IvoiceDto = {
            TextFilter: TextFilter,
            TypeFilter: TypeFilter
        };
        // Gọi ajax post dữ liệu lên server
        common.callAjaxToServer("POST", "/purchase/getDataFilter", IvoiceDto, function (result) {
            if (result) {
                purchase.renderListInvoice(true, result);
            } else {
                alert("lỗi");
            }
        });
    }
   
    // Hàm sắp xếp các hóa đơn theo ngày nhập
    // Người tạo: ntxuan (23/5/2019)
    sortInvoiceByImportDate() {
        $(".content-right .header-column1 input").change(function () {
            if ($(this).val() !== "") {
                let dateChange = common.convertStringJSToStringCsharp(this);
                let invoiceDto = {
                    FromDate: dateChange,
                    ToDate: dateChange
                };
                // Thực hiện load các hóa đơn có ngày tháng được chọn
                common.callAjaxToServer("Post", "/purchase/Invoices", invoiceDto, function (result) {
                    purchase.renderListInvoice(true, result);
                });
            }
        });

        // khi click vào button lấy dữ liệu thì load lại dữ liệu
        $(".content-right .getData").click(function () {
            let fromDate = $(".content-right .inputDateFrom");
            let toDate = $(".content-right .inputDateTo");
            $(".content-right .header-column1 input").val("");
            if (fromDate.val() !== "" && toDate.val() !== "") {
                let fromDateString = common.convertStringJSToStringCsharp(fromDate);
                let toDateString = common.convertStringJSToStringCsharp(toDate);
                let invoiceDto = {
                    FromDate: fromDateString,
                    ToDate: toDateString
                };
                // Thực hiện load các hóa đơn có ngày tháng được chọn
                common.callAjaxToServer("Post", "/purchase/Invoices", invoiceDto, function (result) {
                    purchase.renderListInvoice(true, result);
                });
            }
        });
    }
    
    // Hủy các sự kiện click khi không có dữ liệu hóa đơn
    // Người tạo: ntxuan (20/5/2019)
    setDisableEventButtonMenubar() {
        if ($(".content-right .list-content-invoice .row-clicked").length > 0) {
            $(".content-right .disable-button").removeClass("disable-button");
        } else {
            $(".content-right .btn-toggle-show").addClass("disable-button");
        }
    }
    
    // Thiết lập các sự kiện về phân trang
    // Người tạo: ntxuan (19/5/2019)
    setAllEventPaging() {
        // Khi bấm vào tải lại thì sẽ tải lại toàn bộ hóa đơn
        $(".content-right .wrapp-dataTable .footer-left .reload").click(function () {
            purchase.getDataFromServer(true);
        });
    }

    // Các sự kiện mặc định khi vào trang web
    // Người tạo: ntxuan (18/5/2019)
    setEventDefault() {
        // Khi focus vào ô nhập liệu thì select all
        $("input[type='text']").on("focus", function () {
            $(this).select();
        });
        // Nếu focus vào input thì viền màu hiện lên
        $(".purchaseForm  input").focus(function () {
            $(this).css("border-color", "#A6C8FF");
        });
        // Nếu blur vào input thì viền màu xám hiện lên
        $(".purchaseForm  input").blur(function () {
            $(this).css("border-color", "#c5c3c3");
        });
        // Nếu focus vào input thì viền màu hiện lên
        $(".purchaseForm .multiItem input").focus(function () {
            $(this).parent().css("border-color", "#A6C8FF");
        });
        // Nếu blur vào input thì viền màu xám hiện lên
        $(".purchaseForm .multiItem input").blur(function () {
            $(this).parent().css("border-color", "#c5c3c3");
        });
    }

    // Hàm truyền giá trị thời gian tương ứng cho hai ô input từ ngày, tới ngày
    // Người tạo: ntxuan (16/5/2019)
    setValueTimeRange() {
        // Mới đầu thì mặc định là tháng này
        common.changeDateTimeByCase("5", $(".inputDateFrom"), $(".inputDateTo"));
      
        // Nếu thay đổi thì hiển thị tương ứng
        $(".content-right .list-header-second select").change(function () {
            let value = $(this).val();
            common.changeDateTimeByCase(value, $(".inputDateFrom"), $(".inputDateTo"));
        });
    }

    // Thiết lập các phím tắt cho trang web
    // Người tạo: ntxuan (15/5/2019)
    setAllHotKey() {
        
        $(window).keydown(function (event) {
            // Bấm trl + 1 thì mở form thêm mới
            if (event.ctrlKey && event.keyCode === 97) {
                if (purchase.allowHotKey) {
                    purchaseFormDialog.openPurchaseAddNewForm();
                }
                event.preventDefault();
            }
            // Bấm trl + 2 thì mở form nhân bản
            if (event.ctrlKey && event.keyCode === 98) {
                if (purchase.allowHotKey) {
                    purchaseFormDialog.openPurchaseDuplicateForm();
                }
                event.preventDefault();
            }
            // Bấm trl + 3 thì mở form xem
            if (event.ctrlKey && event.keyCode === 99) {
                if (purchase.allowHotKey) {
                    purchaseFormDialog.openPurchaseViewForm();
                }
                event.preventDefault();
            }
            // Bấm trl + 4 thì mở form sửa
            if (event.ctrlKey && event.keyCode === 100) {
                if (purchase.allowHotKey) {
                    purchaseFormDialog.openPurchaseEditForm();
                }
                event.preventDefault();
            }
            // Bấm trl + D thì xóa hóa đơn đang chọn 
            if (event.ctrlKey && event.keyCode === 68) {
                if (purchase.allowHotKey) {
                    purchaseFormDialog.showMessageDeleteInvoice();
                }
                event.preventDefault();
            }
            // Bấm trl + S thì lưu form
            if (event.ctrlKey && event.keyCode === 83) {
                if (purchaseFormDialog.allowHotKey) {
                    purchaseFormDialog.btnSaveInvoice();
                }
                event.preventDefault();
            }
            // Bấm trl + Q thì đóng form
            if (event.ctrlKey && event.keyCode === 81) {
                if (purchaseFormDialog.allowHotKey) {
                    if (purchaseFormDialog.checkViewForm) {
                        purchaseFormDialog.closePurchaseForm();
                    } else {
                        dialogError.setMessageError("Dữ liệu chưa được lưu, bạn có muốn lưu không?");
                        $(".dialog-btnError").hide();
                        $(".dialog-error .icon-errors").attr("class", "icon-errors icon-dialog-question");
                        $(".dialog-Save").show();
                        $(".dialog-UnSave").show();
                        $(".dialog-cancel").show();
                        dialogError.openDialog();
                    }
                }
                event.preventDefault();
            }
            // Bấm F1 thì chuyển tab sang trợ giúp
            if (event.keyCode === 112) {
                window.open("http://help.mshopkeeper.vn/170101_nhap_hang.htm", '_blank');
                event.preventDefault();
            }
            // Bấm mũi tên lên thì chuyển load dữ liệu các sản phẩm của hóa đơn
            if (event.keyCode === 38) {
                if (purchase.allowHotKey) {
                    let rowFocus = $(".content-right .wrapp-dataTable .row-clicked");
                    purchase.loadInvoicePreviousOrNext(rowFocus, "previous");
                    purchase.autoRenderScrollTop();
                }
                event.preventDefault();
            }
            // Bấm mũi tên xuống thì chuyển load dữ liệu các sản phẩm của hóa đơn
            if (event.keyCode === 40) {
                if (purchase.allowHotKey) {
                    let rowFocus = $(".content-right .wrapp-dataTable .row-clicked");
                    purchase.loadInvoicePreviousOrNext(rowFocus, "next");
                    purchase.autoRenderScrollTop();
                }
                event.preventDefault();
            }
        });
    }

    // Tự động sinh thanh cuộn khi chiều cao dài quá
    // Người tạo: ntxuan(10/6/2019)
    autoRenderScrollTop() {
        let scrollTop = $(".list-content-invoice .row-clicked").offset().top - 229;
        let heightTableData = $(".list-content-invoice").height();
        if (scrollTop > heightTableData) {
            $(".list-content-invoice").scrollTop($(".list-content-invoice").scrollTop() + heightTableData);
        } else if (scrollTop < 0) {
            $(".list-content-invoice").scrollTop($(".list-content-invoice").scrollTop() - heightTableData + 36);
        }
    }

    // Hàm dùng để đổ dữ liệu lấy từ server các hóa đơn
    // Người tạo: ntxuan (23/5/2019)
    renderListInvoice(checkLoadProduct, result) {
        $(".list-content-invoice .row-data").remove();
        $(".item-index .check").find("img").attr("src", "");
        // Xóa dữ liệu cũ
        $(".content-right .list-data-bottom .detail-data").remove();
        if (result.length === 0) {
            $(".content-right .list-data-bottom .background-loading").hide();
        } else {
            if (checkLoadProduct) {
                // Thực hiện load danh sách các sản phẩm của hóa đơn đầu tiên
                purchase.loadProductsForInvoice(result[0].InvoiceId);
            }
            // Vòng lặp để đổ dữ liệu các hóa đơn ra giao diện hiển thị
            $.each(result, function (i, invoice) {
                $(".row-data-invoice-clone span").each(function () {
                    let fieldName = $(this).attr("fieldName");
                    let fieldData = $(this).attr("fieldData");
                    // Nếu ở dạng ngày tháng thì format lại dạng dd/MM/yyyy
                    if (fieldName === "ImportDate") {
                        invoice[fieldName] = new Date(invoice[fieldName]).toLocaleDateString('en-GB');
                    }
                    // Nếu dạng số thì format lại định dạng
                    if (fieldData === "Number") {
                        $(this).text(invoice[fieldName].formatNumber());
                    } else {
                        $(this).text(invoice[fieldName]);
                    }
                });
                // Append dòng dữ liệu vào body
                $(".list-content-invoice").append($(".row-data-invoice-clone").html());
                // Gán giá trị id của hóa đơn vào thuộc tính data của hàng đó
                $(".list-content-invoice .row-data:last").data("InvoiceId", invoice["InvoiceId"]);
                if (i % 2 !== 0) {
                    $(".list-content-invoice .row-data:last").addClass("row-add");
                }
            });
            // Thiết lập hàng đầu tiên được checked
            $(".list-content-invoice .row-data:first").addClass("row-clicked");
        }
        purchase.setDisableEventButtonMenubar();
    }

    // Hàm lấy dữ liệu các hóa đơn từ server
    // Người tạo: ntxuan (11/5/2019)
    getDataFromServer(checkLoadProduct) {
        $(".list-content-invoice .background-loading").show();
        common.callAjaxToServer("Get", "/purchase", null, function (result) {
                $(".list-content-invoice .background-loading").hide();
                if (result) {
                    purchase.renderListInvoice(checkLoadProduct, result);
                } else {
                    alert("Lỗi server lấy dữ liệu các hóa đơn");
                }
        });
    }

    // Lấy danh sách các sản phẩm theo id của hóa đơn truyền vào
    // Người tạo: ntxuan (11/5/2019)
    loadProductsForInvoice(invoiceId) {
        // Đặt lại chiều rộng cho loading
        $(".background-loading").width($(".content-right").width());
        // Xóa dữ liệu cũ
        $(".content-right .list-data-bottom .detail-data").remove();
        $(".content-right .list-data-bottom .background-loading").show();
        let url = "/purchase/GetProducs/" + invoiceId;
        // Thực hiện load các sản phẩm từ server theo id của hóa đơn truyền vào
        common.callAjaxToServer("Post", url, null, function (result) {
            if (result) {
                $(".content-right .list-data-bottom .background-loading").hide();
                // Vòng lặp đổ dữ liệu các sản phẩm vào body chứa danh sách sản phẩm
                $.each(result, function (i, product) {
                    $(".content-right .list-data-bottom").append($(".list-data-bottom-clone").html());
                    $(".content-right .list-data-bottom .detail-data:last span").each(function () {
                        let fieldName = $(this).attr("fieldName");
                        let fieldData = $(this).attr("fieldData");
                        if (fieldData === "Number") {
                            $(this).text(product[fieldName].formatNumber());
                            $(this).data("value", product[fieldName]);
                        } else {
                            $(this).text(product[fieldName]);
                        }
                    });
                    // Nếu dòng chẵn thì cho màu background khác dòng lẻp
                    if (i % 2 !== 0) {
                        $(".content-right .list-data-bottom .detail-data:last").addClass("row-add");
                    }
                });
                // Đồng bộ hóa lại dòng tổng tiền thanh toán cuối trang
                purchase.asyncRowTotalMoney(".content-right");
            } else {
                alert("Lỗi server lấy dữ liệu các sản phẩm");
            }
        });
    }

    // Hàm dùng để đổ dữ liệu các sản phẩm vào form
    // Người tạo : ntxuan(21/5/2019)
    loadProductToPurchaseForm() {
        let invoiceId = $(".content-right .wrapp-dataTable .row-clicked").data("InvoiceId");
        let url = "/purchase/GetProducs/" + invoiceId;
        // Thực hiện load các sản phẩm từ server theo id của hóa đơn truyền vào
        common.callAjaxToServer("Post", url, null, function (result) {
            if (result) {
                $(".form-addNew .list-data-bottom .other-row").remove();
                // Vòng lặp đổ dữ liệu các sản phẩm vào body chứa danh sách sản phẩm
                $.each(result, function (i, product) {
                    $(".row-dataProduct-form-clone [fieldname]").each(function () {
                        let fieldName = $(this).attr("fieldname");
                        let typeTag = $(this).attr("typeTag");
                        $(this).data("value", product[fieldName]);
                        if (typeTag === "input") {
                            $(this).val(product[fieldName].toLocaleString("de-DE"));
                        } else {
                            $(this).text(product[fieldName].toLocaleString("de-DE"));
                        }
                    });
                    $(".form-addNew .list-data-bottom").prepend($(".row-dataProduct-form-clone .other-row").clone(true));
                });
                // Đồng bộ hóa lại dòng tổng tiền thanh toán cuối trang
                purchase.asyncRowTotalMoney(".form-addNew .footer-content-right");
            } else {
                alert("Lỗi server lấy dữ liệu các sản phẩm");
            }
        });
    }

    // Đồng bộ hóa dòng tổng tiền thanh toán
    // Người tạo: ntxuan (11/5/2019)
    asyncRowTotalMoney(objectFocus) {
        // Thành tiền
        let sumMoney = 0;
        // tiền ck
        let amountCK = 0;
        // Tiền thuế
        let taxAmount = 0;
        // Tiền thanh toán
        let payAmount = 0;
        // Tính tổng các giá trị của tiền ck, thành tiền, .. để hiển thị cuối trang
        $(objectFocus).find(".list-data-bottom .other-row").each(function () {
            sumMoney  += $(this).find("[fieldName='Money']").data("value");
            amountCK  += $(this).find("[fieldName='DiscountMoney']").data("value");
            taxAmount += $(this).find("[fieldName='TaxMoney']").data("value");
            payAmount += $(this).find("[fieldName='PaidMoney']").data("value");
        });
        $(objectFocus).find(".footer-bottom .sumMoney").text(sumMoney.formatNumber());
        $(objectFocus).find(".footer-bottom .amountCK").text(amountCK.formatNumber());
        $(objectFocus).find(".footer-bottom .taxAmount").text(taxAmount.formatNumber());
        $(objectFocus).find(".footer-bottom .payAmount").text(payAmount.formatNumber());
    }

    // Hàm dùng để xóa một hóa đơn
    //Creatd By: ntxuan (18/5/2019)
    deleteInvoice() {
        let sumRowDelete = $('.content-right .wrapp-dataTable .row-clicked').length;
        if (sumRowDelete > 1) {
            purchaseFormDialog.deleteMultiInvoice();
        } else {
            // Lấy ra id của hóa đơn
            let invoiceId = $(".content-right .wrapp-dataTable .row-clicked").data("InvoiceId");
            let url = "/purchase/DeleteInvoice/" + invoiceId;
            // Dùng ajax gửi id lên server để xóa
            common.callAjaxToServer("Post", url, null, function (result) {
                if (result) {
                    purchase.getDataFromServer(true);
                } else {
                    alert("lỗi");
                }
            });
        }
    }

    // Hàm này sẽ reset lại form dùng chung
    // Người tạo: ntxuan (19/5/2019)
    resetFormCommon() {
        $(".form-addNew .sumMoney,.form-addNew .amountCK,.form-addNew .taxAmount,.form-addNew .payAmount").text("0");
        $(".form-addNew.purchaseForm").attr("class", "form-addNew purchaseForm");
    }

    // Hàm này dùng để xóa một hóa đơn
    // Người tạo: ntxuan (17/5/2019)
    setEventMenuBarInvoice() {
        // Nếu bấm vào icon xóa
        $(".content-right .list-header-top .btn-Delete").click(function () {
            purchaseFormDialog.showMessageDeleteInvoice();
        });

        // Nếu bấm vào icon nạp
        $(".content-right .list-header-top .btn-refresh").click(function () {
            purchase.getDataFromServer(true);
        });

        // Khi click vào button thêm mới thì form được hiển thị
        $(".content-right .btnAdd").click(function () {
            purchase.resetFormCommon();
            purchaseFormDialog.openPurchaseAddNewForm();
        });

        // Khi click vào button nhân bản thì form được hiển thị
        $(".content-right .btnDuplicate").click(function () {
            purchase.resetFormCommon();
            purchaseFormDialog.openPurchaseDuplicateForm();
        });

        // Khi click vào button xem thì form được hiển thị
        $(".content-right .btnView").click(function () {
            purchase.resetFormCommon();
            purchaseFormDialog.openPurchaseViewForm();
        });

        // Khi click vào button sửa thì form được hiển thị
        $(".content-right .btnEdit").click(function () {
            purchase.resetFormCommon();
            purchaseFormDialog.openPurchaseEditForm();
        });
       
    }

    // Dùng phím lên xuống để chọn các hóa đơn
    // Người tạo: ntxuan (19/5/2019)
    loadInvoicePreviousOrNext(rowCurrent, goal) {
        let invoiceId;
        let rowFocus;
        if (goal === "previous") {
            rowFocus = $(rowCurrent).prev();
            invoiceId = $(rowFocus).data("InvoiceId");
        }
        if (goal === "next") {
            rowFocus = $(rowCurrent).next();
            invoiceId = $(rowFocus).data("InvoiceId");
        }
        if (rowFocus && invoiceId) {
            $(".content-right .wrapp-dataTable .row-data img").attr("src", "");
            $(".content-right .wrapp-dataTable .row-clicked").removeClass("row-clicked");
            $(rowFocus).addClass("row-clicked");
            purchase.loadProductsForInvoice(invoiceId);
        }
    }

    // Khi click vào hàng dữ liệu hóa đơn thì load sản phẩm, nếu double click thì xem chi tiết hóa đơn
    // Người tạo: ntxuan (20/5/2019)
    setEventClickAndDoubleClickRowData() {
        var timer = 0;
        var delay = 250;
        var prevent = false;
        $("body")
            .on("click", ".content-right .wrapp-dataTable .data-column", function (event) {
                var focus = this;
                timer = setTimeout(function () {
                    if (!prevent) {
                        if (event.ctrlKey) {
                            $(focus).parent().addClass("row-clicked");
                        } else {
                            $(".content-right .wrapp-dataTable .row-data img").attr("src", "");
                            $(".content-right .wrapp-dataTable .row-clicked").removeClass("row-clicked");
                            $(focus).parent().addClass("row-clicked");
                        }
                        purchase.loadProductsForInvoice($(focus).parent().data("InvoiceId"));
                        purchase.checkStatusAllRowSelected();
                        purchase.setDisableEventButtonMenubar();
                    }
                    prevent = false;
                }, delay);
            })
            .on("dblclick", ".content-right .wrapp-dataTable .data-column", function () {
                clearTimeout(timer);
                prevent = true;
                $(".content-right .wrapp-dataTable .row-data img").attr("src", "");
                $(".content-right .wrapp-dataTable .row-clicked").removeClass("row-clicked");
                $(this).parent().addClass("row-clicked");
                purchase.resetFormCommon();
                purchaseFormDialog.openPurchaseViewForm();
                purchase.loadProductsForInvoice($(this).parent().data("InvoiceId"));
            });

        // Sự kiện khi click vào số phiếu nhập thì hiện form xem phiếu nhập hàng
        $("body").on("click", '.content-right span[fieldname="ImportNumber"]', function () {
            event.stopPropagation();
            purchase.resetFormCommon();
            $(".content-right .wrapp-dataTable .row-clicked").removeClass("row-clicked");
            $(this).closest(".row-data").addClass("row-clicked");
            purchaseFormDialog.openPurchaseViewForm();
        });
    }

    // Kiểm tra xem các hàng có được click chọn không
    // Người tạo: ntxuan (10/5/2019)
    checkStatusAllRowSelected() {
        let sumChecked = $(".content-right .list-content-invoice .row-clicked").length;
        let sumRow = $(".content-right .list-content-invoice .row-data").length;
        if (sumChecked === sumRow) {
            $(".item-index .check").find("img").attr("src", "/Contents/images/check.png");
            $(".data-index .check img").attr("src", "/Contents/images/check.png");
            $(".wrapp-dataTable .row-data").addClass("row-clicked");
        } else {
            $(".item-index .check").find("img").attr("src", "");
        }
    }

    // Thiết lập hiển thị checked cho các ô checkox
    // Người tạo: NTXUAN (29/04/2019)
    setStatusChecked() {

        this.setEventClickAndDoubleClickRowData();
        // Check hàng loạt hoặc hủy check hàng loạt
        $("body").on("click", ".item-index .check", function () {
            if ($(this).find("img").attr("src") === "") {
                $(this).find("img").attr("src", "/Contents/images/check.png");
                $(".data-index .check img").attr("src", "/Contents/images/check.png");
                $(".wrapp-dataTable .row-data").addClass("row-clicked");
            } else {
                $(this).find("img").attr("src", "");
                $(".data-index .check img").attr("src", "");
                $(".wrapp-dataTable .row-data").removeClass("row-clicked");
            }
            purchase.setDisableEventButtonMenubar();
        });

        // Check một ô và hủy một ô
        $("body").on("click", ".purchaseForm .check, .data-index .check", function () {
            if ($(this).find("img").attr("src") === "") {
                $(this).find("img").attr("src", "/Contents/images/check.png");
                $(this).closest(".row-data").addClass("row-clicked");
            } else {
                $(this).find("img").attr("src", "");
                $(this).closest(".row-data").removeClass("row-clicked");
            }
            purchase.checkStatusAllRowSelected();
            purchase.setDisableEventButtonMenubar();
        });

        // Xét background cho một dòng dữ liệu khi click vào
        $("body").on("click", ".content-right .footer-content-body .detail-data", function () {
            $(".content-right .footer-content-body .row-clicked").removeClass("row-clicked");
            $(this).addClass("row-clicked");
        });
    }

    // Thiết lập chức năng kéo co dãn cho các cột
    // Người tạo: NTXUAN (28/04/2019)
    setResizeAble() {

        // Co dãn 6 dữ liệu trong phần nhập hàng
        for (let i = 1; i < 6; i++) {
            let also = ".data-column" + i;
            $(`.header-column${i}`).resizable({
                alsoResize: also,
                handles: 'e',
                minWidth: 120
            });
        }

        // Co dãn 11 cột dữ liệu chi tiết phía dưới
        for (let i = 1; i < 11; i++) {
            let also = ".content-right .detailData" + i;
            $(`.content-right .detail-header-item${i}`).resizable({
                alsoResize: also,
                handles: 'e',
                minWidth: 100
            });
        }

        // Co dãn lên xuống giữa hai bảng dữ liệu
        $(".wrapp-dataTable").resizable({
            handles: 's'
        });
    }

    // Thiết lập hủy chức năng kéo co dãn cho các cột
    // Người tạo: NTXUAN (28/04/2019)
    removeResizeAble() {

        // Co dãn 6 dữ liệu trong phần nhập hàng
        for (let i = 1; i < 6; i++) {
            let also = ".data-column" + i;
            $(`.header-column${i}`).resizable("destroy");
        }
        // Co dãn 11 cột dữ liệu chi tiết phía dưới
        for (let i = 1; i < 11; i++) {
            let also = ".content-right .detailData" + i;
            $(`.content-right .detail-header-item${i}`).resizable("destroy");
        }
        // Co dãn lên xuống giữa hai bảng dữ liệu
        $(".wrapp-dataTable").resizable("destroy");
    }


    // Thiết lập chiều cao cho các phần tử khi mới vào trang và khi resize kích thước
    // Người tạo: NTXUAN (29/04/2019)
    setHeightForElement() {
        $('.content-right .footer-content-right').height($(".content-right").height() - $(".list-header-top").height() - $(".list-header-second").height() - $(".list-header-table").height() - $(".content-right .wrapp-dataTable").height());
        $(".content-right .footer-content-body").height($('.content-right .footer-content-right').height() - 80);

        // Khi co dãn thì chiều cao các phần tử khác tự co dãn theo
        $('.content-right .wrapp-dataTable').resize(function () {
            $('.content-right .footer-content-right').height($(".content-right").height() - $(".content-right .list-header-top").height() - $(".content-right .list-header-second").height() - $(".content-right .list-header-table").height() - $(".content-right .wrapp-dataTable").height());
            $(".content-right .footer-content-body").height($('.content-right .footer-content-right').height() - 80);
        });
    }

    // Thiết lập các sự kiện ẩn hiện cho các phần tử
    // Người tạo: NTXUAN (29/04/2019)
    setEventShowHide() {

        // Khi click vào tên thì hiện form tùy chọn đăng xuất
        $(".list-title .name").click(function () {
            $(".list-title .setting-option").toggle();
            $("#focus-blur").focus();
        });
        $(".header-column4 .wrapper-content .option").click(function () {
            $(".operator").hide();
            $(this).next().toggle();
            $("#focus-blur").focus();
        });
        $(".operator span").mousedown(function () {
            $(this).parent().prev().text($(this).find("b").text());
            $(this).parent().hide();
        });

        // Khi bấm vào mua hàng trên menu bên trái thì hiện tùy chọn điều hướng
        $(".purchase").parent().click(function () {
            $(".pupop-purchase").toggle();
        });

        // Đây là khi bấm ra ngoài popup và operator nó sẽ ẩn đi
        $("#focus-blur").blur(function () {
            $(".operator").hide();
            $(".list-title .setting-option").hide();
            $(".table-sku").hide();
        });

        // Bấm vào icon hình cuốn lịch sẽ hiển thị giao diện datepicker cho chọn ngày
        $(".icon-date").click(function () {
            $(".inputDateFrom").datepicker("show");
        });
        $(".icon-calander2").click(function () {
            $(".header-column1 input").datepicker("show");
        });
        $(".icon-date2").click(function () {
            $(".inputDateTo").datepicker("show");
        });
    }

    // Thiết lập datePicker cho các ô input nhập ngày tháng
    // Người tạo: NTXUAN (29/04/2019)
    setDatePickerForElement() {
        // Set datepicker cho input nhập ngày tháng
        $(".inputDateTo, .inputDateFrom, .header-column1 input,.purchaseForm .DateInput").datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            yearRange: '1950:2019'
        });
        // set timepicker cho input nhập giờ
        $('.timepicker').timepicker({
            timeFormat: 'h:mm p',
            interval: 30,
            minTime: '7 am',
            maxTime: '17 pm',
            defaultTime: '17',
            startTime: '5',
            dynamic: true,
            dropdown: true,
            scrollbar: true
        });
    }
}

// Khởi tạo biến dùng chung
var common = new Common();

// Khởi tạo một đối tượng mua hàng
// Người tạo: NTXUAN (28/04/2019)
var purchase = new Purchase();