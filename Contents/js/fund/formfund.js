//Hàm Fund

////Các biến để sử dụng thêm mới Dialog
////Tạo bởi: NBDUONG(3/5/2019)
//var check;
//var popup;
//var messageDialog;
//var chooseObjectPay;
//var chooseStaff;


//Tạo bởi: NBDUONG (2/5/2019)
class Fund {
    //Phương thức khởi tạo
    //Tạo bởi: NBDUONG(2/5/2019)
    constructor() {
        this.initEvent();
        //check = new Dialog('#formDetail', 960, 750, this);
        //Các nút trong form Chọn hóa đơn trả nợ
        var buttons =
            [
                {
                    html: '<div class="receiptFormDetail-btnHelp-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnHelp-text receiptFormDetail-text">Trợ giúp</span>',
                    class: "receiptFormDetail-btnHelp",
                    click: function () { }
                },
                {
                    html: '<div class="receiptFormDetail-btnPayDebt-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Trả nợ</span>',
                    class: "receiptFormDetail-btnPayDebt",
                    click: function () {
                        alert('asd');
                        $('.receiptFormDetail-btnPayDebt').css('background-color', '#026b97');
                    }
                },
                {
                    html: '<div class="receiptFormDetail-btnCancel-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnCancel-text receiptFormDetail-text">Hủy bỏ</span>',
                    class: "receiptFormDetail-btnCancel",
                    click: function () { fund.popup.closeDialog(); }
                }
            ];

        //Các nút trong form Chọn đối tượng
        var buttonChooseObjectForm =
            [
                {
                    html: '<div class="receiptFormDetail-btnHelp-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnHelp-text receiptFormDetail-text">Trợ giúp</span>',
                    class: "receiptFormDetail-btnHelp",
                    click: function () { }
                },
                {
                    html: '<div class="receiptFormDetail-btnPayDebt-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Chọn</span>',
                    class: "receiptFormDetail-btnPayDebt",
                    click: function () {
                        let staffCode = $('.reciptFormDetail_tableData .table-row.choose-background').children().eq(1).find('span').text();
                        let staffName = $('.reciptFormDetail_tableData .table-row.choose-background').children().eq(2).find('span').text();
                        $(".input-staffCode").val(staffCode);
                        $(".input-staffName").val(staffName);
                        $('#formChooseObject').dialog('close');
                        $('#formChooseStaff').dialog('close');
                    }
                },
                {
                    html: '<div class="receiptFormDetail-btnCancel-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnCancel-text receiptFormDetail-text">Hủy bỏ</span>',
                    class: "receiptFormDetail-btnCancel",
                    click: function () {
                        fund.chooseObjectPay.closeDialog();
                        fund.chooseStaff.closeDialog();
                    }
                }
            ];

        //Các nút trong form message
        var buttonMessage =
            [
                {
                    html: '<div class="receiptFormDetail-btnSave-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Lưu</span>',
                    class: "alertDialog_btnSave alertDialog_btn",
                    click: function () { fund.saveNewDocument(); }
                },
                {
                    html: '<div class="receiptFormDetail-btnDelete-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Xóa</span>',
                    class: "alertDialog_btnDelete alertDialog_btn",
                    click: function () {
                        fund.deleteDocument();
                        fund.messageDialog.closeDialog();
                    }
                },
                {
                    html: '<div class="receiptFormDetail-btnNotSave-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Không lưu</span>',
                    class: "alertDialog_btnNotSave alertDialog_btn",
                    click: function () {
                        fund.messageDialog.closeDialog();
                        fund.check.closeDialog();
                    }
                },
                {
                    html: '<div class="receiptFormDetail-btnCancel-icon receiptFormDetail-icon left-float"></div><span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Hủy bỏ</span>',
                    class: "alertDialog_btnCancel alertDialog_btn",
                    click: function () { fund.messageDialog.closeDialog(); }
                },
                {
                    html: '<span class="receiptFormDetail-btnPayDebt-text receiptFormDetail-text">Đồng ý</span>',
                    class: "alertDialog_btnAccept alertDialog_btn",
                    click: function () { fund.messageDialog.closeDialog(); }
                }
            ];

        this.supplierCodes = [];
        this.employeeCodes = [];
        this.employeeNames = [];
        this.supplierNames = [];
        this.checkViewForm = false;
        this.checkEditForm = false;
        //Tạo mới dialog
        this.check = new Dialog('#formDetail', 960, 750, this);
        this.popup = new Dialog('#recipeFormDetail', 800, 600, this, buttons);
        this.messageDialog = new Dialog('#alertDialog', 400, 170, this, buttonMessage);
        this.chooseObjectPay = new Dialog('#formChooseObject', 800, 500, this, buttonChooseObjectForm);
        this.chooseStaff = new Dialog('#formChooseStaff', 800, 500, this, buttonChooseObjectForm);
    }

    //Hàm khởi tạo sự kiện
    //Tạo bởwi: NBDUONG (3/5/2019)
    initEvent() {
        this.getDataFundFromServer();
        this.resizeColumn();
        this.getCurrentDate();
        this.autoAdjustHeight();
        this.validateData();
        this.getPaidMoney();
        this.onRowClick();
        this.changeDateRangeWithOption();
        this.selectStaff();
        this.loadEmployeeListFromServer();
        this.loadSuppliersListFromServer();
        this.loadDocumentTypeFromServer();
        this.setHotKey();
        this.setInputEvent();
        this.setTabOrder();
        this.closeFormMessage();
        this.checkSupplierCodeValidateInput();
        this.ifIsNaN();
        this.setDefaultButton();
        this.validateInputData();
        this.clickSave();
        this.asyncData();
    }

    setDefaultButton() {
        $('#btnCollectMoney').click(this.addCollectMoney);
        $('#btnPayMoney').click(this.addPayMoney);
        $('#btnView').click(this.viewDocument);
        $('#btnEdit').click(this.editDocument);
        $('#btnDuplicate').click(this.duplicateDocument);
        $('#btnDelete').click(this.deleteDocumentDialog);
        $('#btnRefresh').click(this.refreshDocument);
        $('.choose-pay-recipt').click(this.choosePayDebtRecipt);
        $('#choose-object').click(this.chooseObjectPay);
        $('.choose-object-paydebt').click(this.chooseStaffPaydebt);
        //$('#formDetail #save-formDetail').click(this.alertMessage);
    }

    asyncData() {
        $('input[fieldName="DocumentDate2"]').val($('input[fieldName="DocumentDate"]').val());
        $('input[fieldName="DocumentDate"]').change(function () {
            $('input[fieldName="DocumentDate2"]').val($(this).val());
            $('input[fieldName="DocumentDate"]').val($(this).val());
        });

        $('input[fieldName="DocumentCode"]').change(function () {
            $('input[fieldName="DocumentCode"]').val($(this).val());
        });

        $('input[fieldName="TotalMoney"]').change(function () {
            $('input[fieldName="TotalMoney"]').val($(this).val());
        });

        $('input[fieldName="DocumentType"]').change(function () {
            $('input[fieldName="DocumentType"]').val($(this).val());
        });

        $('input[fieldName="Reason"]').change(function () {
            $('input[fieldName="Reason"]').val($(this).val());
        });

        $('input[fieldName="Address"]').change(function () {
            $('input[fieldName="Address"]').val($(this).val());
        });

        $('input[fieldName="PersonCode"]').change(function () {
            $('input[fieldName="PersonCode"]').val($(this).val());
        });
         
        $('input[fieldName="EmployeeCode"]').change(function () {
            $('input[fieldName="EmployeeCode"]').val($(this).val());
        });
    }

    //Hàm hiển thị khoảng thời gian theo lựa chọn tương ứng trong comboBox
    //Tạo bởi: NBDUONG(16/5/2019)
    changeDateRangeWithOption() {
        changeDateTimeByCase("5", $('.select-from-date'), $('.select-to-date'));
        $('.select-month select').change(function () {
            let value = $(this).val();
            changeDateTimeByCase(value, $('.select-from-date'), $('.select-to-date'));
        });
    }

    //Disable nút khi không có bản ghi
    //Tạo bởi: NBDUONG(20/5/2019)
    disableButton() {
        $('.middle-content_header-list-button .btnCanBeDisabled').addClass('disable');
    }
    //Enable nút khi có bản ghi
    //Tạo bởi: NBDUONG(20/5/2019)
    enableButton() {
        $('.middle-content_header-list-button .btnCanBeDisabled').removeClass('disable');
    }

    //Hàm lấy dữ liệu từ trên server
    //Tạo bởi: NBDUONG (15/5/2019)
    getDataFundFromServer() {
        var totalMoney = 0;
        $('.middle-content_table-data .table-data_list-data').html("");
        $('.MISABody-part_middle-content .footer-content_detail-table-data .detail-table-data_list-data').html("");
        $('.detailTotalMoney span').text("0");
        $('.total-money-row_fifth-column span').text("0");
        $('.MISABody-part_middle-content .loading').show();
        $.ajax({
            type: "GET",
            url: "/fund/documents",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('.MISABody-part_middle-content .loading').hide();
                if (response.length === 0) {
                    fund.disableButton();
                } else {
                    fund.enableButton();
                    //Ẩn loading
                    $('.MISABody-part_middle-content .loading').hide();
                    //Truyền dữ liệu vào mỗi cột
                    $.each(response, function (index, item) {
                        $('.middle-content_table-data .row-clone span').each(function () {
                            var fieldData = $(this).parent().attr("fieldName");
                            var dataType = $(this).parent().attr("dataType");
                            var value = item[fieldData] ? item[fieldData] : ""; // Kiểm tra dữ liệu rỗng

                            if (dataType === "date") {
                                item[fieldData] = new Date(item[fieldData]).toLocaleDateString('en-GB');
                                $(this).text(item[fieldData]);
                            } else if (dataType === "number") {
                                $(this).text(item[fieldData].formatNumber());
                                $(this).data('value', item[fieldData]);
                                totalMoney += $(this).data('value');
                                $('.total-money-row_fifth-column span').text(totalMoney.formatNumber());
                            } else {
                                $(this).text(item[fieldData]);
                            }
                        });

                        //Append dữ liệu vào bảng dữ liệu
                        $('.middle-content_table-data .table-data_list-data').append($('.row-clone').html());
                        //Gán Id cho dòng được click
                        $('.middle-content_table-data .table-row:last-child').data("DocumentId", item["DocumentId"]);
                        $('.middle-content_table-data .table-row:last-child').data("DocumentCode", item["DocumentCode"]);
                        $('.middle-content_table-data .table-row:last-child').data("DocumentType", item["DocumentType"]);

                        //Các dòng liền nhau có màu khác nhau
                        if (index % 2 !== 0) {
                            $('.middle-content_table-data .table-data_list-data .table-row:last-child').addClass('row-even');
                        } else if (index % 2 === 0) {
                            $('.middle-content_table-data .table-data_list-data .table-row:last-child').removeClass('row-even');
                        }

                        //Thiết lập hàng đầu tiên được check
                        $(".middle-content_table-data .table-data_list-data .table-row").eq(0).addClass("choose-background");
                    });
                    fund.loadDocumentDataDefault(response[0].DocumentId);
                }
            }
        });
    }
    //Hàm lấy dữ liệu từ trên server
    //Tạo bởi: NBDUONG (15/5/2019)
    loadDocumentDataDefault(id) {
        $('.MISABody-part_middle-content .footer-content_detail-table-data .detail-table-data_list-data').html("");
        //Hiển thị loading
        $('.footer-content_detail-table-data .loading').show();
        $.ajax({
            type: "GET",
            url: "/fund/" + id,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //Ẩn loading
                $('.footer-content_detail-table-data .loading').hide();
                //Đẩy dữ liệu vào các dòng
                $('.footer-content_detail-table-data .footer-table-row-clone span').each(function () {
                    let fieldName = $(this).parent().attr("fieldName");
                    let fieldData = $(this).parent().attr("dataType");
                    if (fieldData === "number") {
                        $(this).text(result[fieldName].formatNumber());
                        $('.detailTotalMoney span').text(result[fieldName].formatNumber());
                    } else {
                        $(this).text(result[fieldName]);
                    }
                });
                $('.MISABody-part_middle-content .footer-content_detail-table-data .detail-table-data_list-data').append($('.footer-table-row-clone').html());
            }
        });
    }

    //Lấy ra danh sách nhân viên từ trên sever
    //Tạo bởi: NBDUONG(17/5/2019)
    loadEmployeeListFromServer() {
        $.ajax({
            type: "GET",
            url: "/purchase/GetEmployees",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //Xóa trắng danh sách nhân viên trước khi cập nhật lại dữ liệu mới
                $('#formChooseStaff .reciptFormDetail_tableData .detail-table-data_list-data').html("");
                $.each(result, function (index, item) {
                    //Lấy ra các dòng có attribute fieldName
                    let listElements = $(".formChooseStaff_table-row-clone div[fieldName]");
                    $.each(listElements, function (i, element) {
                        let fieldName = $(element).attr("fieldName");
                        $(element).find('span').text(item[fieldName]);
                    });
                    //Gán dữ liệu về id của nhân viên cho dòng
                    $('.formChooseStaff_table-row-clone .table-row').data("EmployeeId", item["EmployeeId"]);
                    $('#formChooseStaff .reciptFormDetail_tableData .detail-table-data_list-data').append($('.formChooseStaff_table-row-clone .table-row').clone(true));
                    //Nếu dòng có thứ tự là chẵn thì hiển thị background cho hàng chẵn
                    if (index % 2 === 0) {
                        $("#formChooseStaff .reciptFormDetail_tableData .detail-table-data_list-data .table-row:last-child").addClass("row-even");
                    }

                    //Lấy ra các dòng có attribute fieldName trong bảng dropdown chọn nhân viên
                    let listElementsDropdownMenu = $('.employee-table-row-clone div[fieldName]');
                    $.each(listElementsDropdownMenu, function (i, element) {
                        let fieldName = $(element).attr("fieldName");
                        $(element).find('span').text(item[fieldName]);
                    });
                    $('.employee-table-row-clone .table-row').data("EmployeeId", item["EmployeeId"]);
                    fund.employeeCodes.push(item["EmployeeCode"]);
                    fund.employeeNames.push(item["EmployeeName"]);
                    $(".recipeFormDetail_formStaff .detail-table-data_list-data").append($(".employee-table-row-clone .table-row").clone(true));
                });
                // Xét trạng thái checked cho dòng đầu tiên
                $("#formChooseStaff .reciptFormDetail_tableData .detail-table-data_list-data .table-row:first-child").addClass("choose-background");
                // Xét trạng thái checked cho input radio đầu tiên
                $("#formChooseStaff .reciptFormDetail_tableData .detail-table-data_list-data .table-row:first-child input").prop("checked", true);
            }
        });
    }

    //Lấy ra danh sách nhân viên từ trên sever
    //Tạo bởi: NBDUONG(17/5/2019)
    loadSuppliersListFromServer() {
        $.ajax({
            type: "GET",
            url: "/fund/people",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //Xóa trắng danh sách nhà cung cấp trước khi cập nhật lại dữ liệu mới
                $('#formChooseObject .reciptFormDetail_tableData .detail-table-data_list-data').html("");
                $.each(result, function (index, item) {
                    //Lấy ra các dòng có attribute fieldName
                    let listElements = $(".formChooseObject_table-row-clone div[fieldName]");
                    $.each(listElements, function (i, element) {
                        let fieldName = $(element).attr("fieldName");
                        $(element).find('span').text(item[fieldName]);
                    });
                    //Gán dữ liệu về id của nhà cung cấp cho dòng
                    $('.formChooseObject_table-row-clone .table-row').data("PersonId", item["PersonId"]);
                    $('#formChooseObject .reciptFormDetail_tableData .detail-table-data_list-data').append($('.formChooseObject_table-row-clone .table-row').clone(true));
                    //Nếu dòng có thứ tự là chẵn thì hiển thị background cho hàng chẵn
                    if (index % 2 === 0) {
                        $("#formChooseObject .reciptFormDetail_tableData .detail-table-data_list-data .table-row:last-child").addClass("row-even");
                    }

                    //Lấy ra các dòng có attribute fieldName trong bảng dropdown chọn đối tượng (hiện tại là nhà cung cấp)
                    let listElementsDropdownMenu = $('.recipeFormDetail_supplier-table-row-clone div[fieldName]');
                    $.each(listElementsDropdownMenu, function (i, element) {
                        let fieldName = $(element).attr("fieldName");
                        $(element).find('span').text(item[fieldName]);
                    });
                    $('#recipeFormDetail .recipeFormDetail_supplier-table-row-clone .table-row').data("PersonId", item["PersonId"]);
                    $("#recipeFormDetail .recipeFormDetail_formSupplier .detail-table-data_list-data").append($(".recipeFormDetail_supplier-table-row-clone .table-row").clone(true));

                    //Lấy ra các dòng có attribute fieldName trong bảng dropdown chọn đối tượng (hiện tại là nhà cung cấp)
                    let listElementsDropdown = $('.supplier-table-row-clone div[fieldName]');
                    $.each(listElementsDropdown, function (i, element) {
                        let fieldName = $(element).attr("fieldName");
                        $(element).find('span').text(item[fieldName]);
                    });
                    $('#formDetail .supplier-table-row-clone .table-row').data("PersonId", item["PersonId"]);
                    fund.supplierCodes.push(item["PersonCode"]);
                    fund.supplierNames.push(item["PersonName"]);
                    $("#formDetail .recipeFormDetail_formSupplier .detail-table-data_list-data").append($(".supplier-table-row-clone .table-row").clone(true));
                });
                // Xét trạng thái checked cho dòng đầu tiên
                $("#formChooseObject .reciptFormDetail_tableData .detail-table-data_list-data .table-row:first-child").addClass("choose-background");
                // Xét trạng thái checked cho input radio đầu tiên
                $("#formChooseObject .reciptFormDetail_tableData .detail-table-data_list-data .table-row:first-child input").prop("checked", true);
            }
        });
    }

    //Lấy ra danh sách loại chứng từ tử trên sever
    //Tạo bởi: NBDUONG(20/5/2019)
    loadDocumentTypeFromServer() {
        $.ajax({
            type: "GET",
            url: "/fund/documentsType",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //Xóa trắng danh sách nhà cung cấp trước khi cập nhật lại dữ liệu mới
                $('.document-type-dropdown .detail-table-data_list-data').html("");
                $.each(result, function (index, item) {
                    //Lấy ra các dòng có attribute fieldName
                    let element = $(".document-type-row-clone div[fieldName]");
                    let fieldName = $(element).attr("fieldName");
                    $(element).find('span').text(item[fieldName]);
                    //Gán dữ liệu về id của nhà cung cấp cho dòng
                    $(element).parent().data("DocumentTypeId", item["DocumentTypeId"]);
                    $('.document-type-dropdown .detail-table-data_list-data').append($('.document-type-row-clone .table-row').clone(true));
                });
                // Xét trạng thái checked cho dòng đầu tiên
                $(".document-type-dropdown .table-row:first-child").addClass("choose-background");
            }
        });
    }

    //Tạo mới chứng từ
    //Tạo bởi: NBDUONG(24/5/2019)
    createNewDocument() {
        let document = {};
        $("#formDetail input[fieldName]").each(function () {
            let fieldData = $(this).attr("fieldName");
            if ($(this).attr("dataType") === "date") {
                let dateString = $(this).datepicker("getDate");
                let dateFormat = $.datepicker.formatDate("yy-mm-dd", dateString);
                let dateCurrent = new Date();
                document[fieldData] = dateFormat + dateCurrent.getFullTimeCurrent();
            } 
            else {
                document[fieldData] = $(this).val();
            }
        });
        //Check nếu là edit thông tin chứng từ
        if (fund.checkEditForm) {
            fund.editDocumentData(document);
        } else {
            $.ajax({
                type: "POST",
                url: "/fund/documents/new",
                data: JSON.stringify(document),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function () {
                    fund.getDataFundFromServer();
                    fund.check.closeDialog();
                },
                error: function (e) {
                    alert(e.responseText);
                }
            });
        }
    }

    //Thay đổi thông tin chứng từ
    //Tạo bởi: NBDUONG(28/5/2019)
    editDocumentData(document) {
        let documentId = $('.middle-content_table-data .table-row.choose-background').data("DocumentId");
        document["DocumentId"] = documentId;
        $.ajax({
            type: "POST",
            url: "/fund/documents/edit/" + documentId,
            data: JSON.stringify(document),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function () {
                fund.getDataFundFromServer();
                fund.check.closeDialog();
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }

    //Save 1 chứng từ, có thể là thêm mới hoặc thay đổi thông tin hoặc nhân bản
    //Tạo bởi: NBDUONG(28/5/2019)
    saveNewDocument() {
        let flag = true;
        if ($('.formDetail-info.formDetail-info-other input[fieldName="PersonCode"]').val() === "") {
            fund.messageDialog.changeContentAlertMessage("Trường đối tượng không được bỏ trống. Vui lòng kiểm tra lại");
            fund.messageDialog.changeIconAlertMessage("alert-icon-warning");
            flag = false;
        } else if ($('.formDetail-info.formDetail-info-other input[fieldName="EmployeeCode"]').val() === "") {
            fund.messageDialog.changeContentAlertMessage("Trường nhân viên không được bỏ trống. Vui lòng kiểm tra lại");
            fund.messageDialog.changeIconAlertMessage("alert-icon-warning");
            flag = false;
        }

        if (flag) {
            $('#formDetail').hide();
            fund.createNewDocument();
        } else {
            fund.alertMessage();
            $('#alertDialog').addClass('warning-message');
            fund.changeButtonMessageDialog();
        }
    }

    //Hàm xử lý bấm nút save trong form
    //Tạo bởi: NBDUONG(28/5/2019)
    clickSave() {
        $('#save-formDetail').click(function () {
            fund.saveNewDocument();
        });
    }

    //Thay đổi trạng thái các nút trong form thông báo khi hiển thị các nội dung khác nhau
    //Tạo bởi: NBDUONG(30/5/2019)
    changeButtonMessageDialog() {
        if ($('#alertDialog').hasClass('warning-message')) {
            $('.warning-message').next().find('.alertDialog_btnAccept').show();
            $('.warning-message').next().find('.alertDialog_btnSave').hide();
            $('.warning-message').next().find('.alertDialog_btnNotSave').hide();
            $('.warning-message').next().find('.alertDialog_btnCancel').hide();
            $('.warning-message').next().find('.alertDialog_btnDelete').hide();
        }
        else if ($('#alertDialog').hasClass('close-form-message')) {
            $('.close-form-message').next().find('.alertDialog_btnAccept').hide();
            $('.close-form-message').next().find('.alertDialog_btnDelete').hide();
            $('.close-form-message').next().find('.alertDialog_btnSave').show();
            $('.close-form-message').next().find('.alertDialog_btnNotSave').show();
            $('.close-form-message').next().find('.alertDialog_btnCancel').show();
        }
        else if ($('#alertDialog').hasClass('delete-form-message')) {
            $('.delete-form-message').next().find('.alertDialog_btnAccept').hide();
            $('.delete-form-message').next().find('.alertDialog_btnDelete').show();
            $('.delete-form-message').next().find('.alertDialog_btnSave').hide();
            $('.delete-form-message').next().find('.alertDialog_btnNotSave').hide();
            $('.delete-form-message').next().find('.alertDialog_btnCancel').show();
        }
    }

    //Xóa chứng từ
    //Tạo bởi: NBDUONG(30/5/2019)
    deleteDocument() {
        let documentId = $('.middle-content_table-data .table-row.choose-background').data("DocumentId");
        $.ajax({
            type: "POST",
            url: "/fund/documents/delete/" + documentId,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function () {
                fund.getDataFundFromServer();
            },
            error: function (e) {
                alert(e.responseText);
            }
        });
    }

    deleteDocumentDialog() {
        fund.alertMessage();
        $('#alertDialog').addClass("delete-form-message");
        $('span#ui-id-3').text("Xóa dữ liệu");
        fund.messageDialog.changeIconAlertMessage("alert-icon-question");
        let documentCode = $('.middle-content_table-data .table-row.choose-background').data("DocumentCode");
        let documentType = $('.middle-content_table-data .table-row.choose-background').data("DocumentType");
        fund.messageDialog.changeContentAlertMessage("Bạn có chắc chắn muốn xóa " + documentType + " " + documentCode + " không");
        fund.changeButtonMessageDialog();
    }

    //Nạp lại dữ liệu cho chứng từ
    //Tạo bởi: NBDUONG(31/5/2019)
    refreshDocument() {
        fund.getDataFundFromServer();
    }

    //Click vào dòng trong bảng dữ liệu hiển thị với background chọn đồng thời trả về dữ liệu của dòng đó
    // Hiển thị dữ liệu tương ứng trong bảng chi tiết phía dưới
    //Tạo bởi: NBDUONG(16/5/2019)
    onRowClick() {
        $('body').on('click', '.middle-content_table-data .table-data_list-data .table-row.flex', function () {
            //Bỏ background hàng chọn
            $('.middle-content_table-data .table-row.flex').removeClass('choose-background');
            $('.middle-content_table-data .table-row.flex .data-item_first-column').removeClass('choose-background');
            $(this).addClass('choose-background');

            //Lấy ra id của chứng từ khi click vào dòng chứng từ đó
            var id = $(this).data("DocumentId");
            //Hiển thị loading
            $('.footer-content_detail-table-data .loading').show();
            fund.loadDocumentDataDefault(id);
        });
    }

    //Điều chỉnh độ rộng, độ dài của các cột
    //Tạo bởi: NBDUONG (6/5/2019)
    resizeColumn() {
        for (let i = 2; i < 7; i++) {
            let also = '.data-item' + i;
            $(`.header-table-column${i}`).resizable({
                alsoResize: also,
                handles: 'e',
                minWidth: 150,
                maxWidth: 600
            });
        }

        $('.middle-content_table-data').resizable({
            handles: 's',
            maxHeight: 400,
            minHeight: 300
        });
    }

    //Điều chỉnh chiều rộng chiều cao các cột đồng thời điều chỉnh chiều cao của các div có liên quan trong giao diện
    //Tạo bởi: NBDUONG(8/5/2019)
    autoAdjustHeight() {
        $('.middle-content_upper-part .middle-content_table-data').resize(function () {
            $('.middle-content_upper-part .footer-content_detail-table-data').height($('.middle-content_upper-part').height()
                - 36 - 53 - $('.middle-content_upper-part .middle-content_table-data').height() - 64 - 130);
            $(".middle-content_upper-part .detail-table-data_list-data").height($('.middle-content_upper-part .footer-content_detail-table-data').height() - 50);
        });
    }

    //Tạo hot key cho trang giao diện, sử dụng hotkey để mở nhanh các form
    //Tạo bởi: NBDUONG(18/5/2019)
    setHotKey() {
        $(window).keydown(function (event) {
            // Bấm ctrl + 1 thì mở form thêm mới
            if (event.ctrlKey && event.keyCode === 49) {
                fund.openDropdownMenuAdd();
                event.preventDefault();
            }

            // Bấm ctrl + Q thì đóng form thêm mới
            if (event.ctrlKey && event.keyCode === 81) {
                fund.closeFormDialog();
                event.preventDefault();
            }

            // Bấm ctrl + S thì lưu thêm mới
            if (event.ctrlKey && event.keyCode === 83) {
                fund.saveNewDocument();
                event.preventDefault();
            }

            // Bấm F1 thì chuyển tab sang trợ giúp
            if (event.keyCode === 112) {
                window.open("http://help.mshopkeeper.vn/170103_thu_tien_mat.htm", '_blank');
                event.preventDefault();
            }
            
            // Bấm mũi tên xuống thì di chuyển tới dòng tiếp theo đồng thời load dữ liệu của hàng đó xuống bảng chi tiết 
            if (event.keyCode === 40) {
                let rowFocus = $('.middle-content_table-data .table-row.choose-background');
                fund.loadDocumentByHotKey(rowFocus, "next");
                event.preventDefault();
            }
            // Bấm mũi tên lên trên thì di chuyển tới dòng phía trên theo đồng thời load dữ liệu của hàng đó xuống bảng chi tiết 
            if (event.keyCode === 38) {
                let rowFocus = $('.middle-content_table-data .table-row.choose-background');
                fund.loadDocumentByHotKey(rowFocus, "previous");
                event.preventDefault();
            }

            if (event.ctrlKey && event.keyCode === 65) {
                $('.table-data_list-data .table-row').addClass("choose-background");
                $('.table-data_list-data .table-row').find('img').attr('src', "/Contents/images/check.png");
                $('.choose-all').find('img').attr('src', "/Contents/images/check.png");
                event.preventDefault();
            }
        });
    }

    //Hàm bấm nút lên xuống trong danh sách bản ghi thì chuyển tới các dòng tương ứng và load dữ liệu dòng đó
    //Tạo bởi: NBDUONG(22/5/2019)
    loadDocumentByHotKey(rowCurrent, nextStep) {
        let documentId;
        let rowFocus;
        if (nextStep === "next") {
            rowFocus = $(rowCurrent).next();
            documentId = $(rowFocus).data("DocumentId");
        }
        if (nextStep === "previous") {
            rowFocus = $(rowCurrent).prev();
            documentId = $(rowFocus).data("DocumentId");
        }
        //Khi thỏa mãn
        if (rowFocus && documentId) {
            $('.middle-content_table-data .choose-background').removeClass("choose-background");
            $(rowFocus).addClass("choose-background");
            fund.loadDocumentDataDefault(documentId);
        }
    }

    //Sắp xếp vị trí tab của form
    //Tạo bởi: NBDUONG(19/5/2019)
    setTabOrder() {
        $('#focusguard-2').on('focus', function () {
            $('#focusguard-1').focus();
        });
        $('#focusguard-3').on('focus', function () {
            $('#focusguard-4').focus();
        });
    }

    //Set các sự kiện mặc định trong các input
    //Tạo bởi: NBDUONG(19/5/2019)
    setInputEvent() {
        $('input[type="text"]').on('focus', function () {
            $(this).select();
        });
        // Nếu focus vào input thì viền màu hiện lên
        $("#formDetail input").focus(function () {
            $(this).css("border-color", "#A6C8FF");
        });
        // Nếu blur vào input thì viền màu xám hiện lên
        $("#formDetail input").blur(function () {
            $(this).css("border-color", "#d0d0d0");
        });
    }

    //Hàm mở dropdown chọn Phiếu thu tiền hoặc phiếu chi tiền
    //Tạo bởi: NBDUONG(18/5/2019)
    openDropdownMenuAdd() {
        $('#btnAdd').trigger('click');
    }

    //Hàm lấy dữ liệu trong các hàng để hiển thị lên input tương ứng
    //Tạo bởi: NBDUONG (6/5/2019)
    getSupplierData(supplierCode, supplierName) {
        $('.supplier-code').val(supplierCode);
        $('.supplier-name').val(supplierName);
    }

    //Hàm lấy dữ liệu trong các hàng để hiển thị lên input tương ứng
    //Tạo bởi: NBDUONG (6/5/2019)
    getObjectData(objectName) {
        $('#formChooseObject .objectComboBox_dropdown-menu').prev().prev().val(objectName);
    }

    //Hàm lấy dữ liệu trong các hàng để hiển thị lên input tương ứng
    //Tạo bởi: NBDUONG (6/5/2019)
    getPaidTypeData(objectName) {
        $('.checkPaidType-dropdown-menu').prev().prev().prev().val(objectName);
    }

    //Hàm lấy dữ liệu trong các hàng để hiển thị lên input tương ứng
    //Tạo bởi: NBDUONG (6/5/2019)
    getStaffData(staffName, staffCode) {
        $('.recipeFormDetail_formStaff').prev().prev().prev().val(staffCode);
        $('.recipeFormDetail_formStaff').parent().next().val(staffName);
    }

    //Hàm đồng bộ dữ liệu giữa mã nhà cung cấp và tên nhà cung cấp
    //Tạo bởi: NBDUONG (6/5/2019)
    asyncDataValue(supplierCode, supplierName) {
        $('.supplier-name-paydebt').val(supplierName);
        $('.supplier-code-paydebt').val(supplierCode);
        $('.supplier-name').val(supplierName);
        $('.supplier-code').val(supplierCode);
        var reasonPayDebt = "Trả nợ cho " + supplierName;
        $('.reason-paydebt').val(reasonPayDebt);
    }

    //Hàm lấy giá trị của input Số trả, nếu nhập số âm thì mặc định là 0
    //Tạo bởi: NBDUONG (12/5/2019)
    validateData() {
        //Nếu giá trị số trả âm thì mặc định là 0
        $("#recipeFormDetail .formDetail_general-info_left-item_list-input .left-item-input.left-item-without-icon input").change(function () {
            if ($(this).val() < 0 || $(this).val() === "") {
                $(this).val(0);
            }
        });
    }

    //Hàm xử lý validate độ dài input
    //Tạo bởi: NBDUONG(18/5/2019)
    validateInput(element, length) {
        $(element).keydown(function () {
            if ($(this).val().length > length) {
                $(this).next().show();
                $(this).next().attr("title", "Trường này không được vượt quá " + length + " kí tự");
                $(this).addClass('border-red');
                $(this).css('outline', 'none');
            } else {
                $(this).removeClass('border-red');
                $(this).next().hide();
                $(this).css('outline', '1px solid #A6C8FF');
            }
        });

        $(element).blur(function () {
            if ($(this).val().length > length) {
                $(this).val("");
                $(this).removeClass('border-red');
                $(this).next().hide();
            }
        });
    }

    //Gọi hàm xử lý validate chiều dài input nhập vào
    //Tạo bởi: NBDUONG(18/5/2019)
    validateInputData() {
        this.validateInput('input[inputType="Name"]', 128);
        this.validateInput('input[inputType="Reason"]', 255);
    }

    //Kiểm tra input chọn đối tượng có trong bảng chọn đối tượng hay không
    //Nếu input nhập vào trùng với mã đối tượng hiển thị tên và các trường tương ứng
    //Tạo bởi: NBDUONG(23/5/2019)
    checkSupplierCodeValidateInput() {
        //Bấm ra ngoài vùng input mã đối tượng
        $('.supplier-code').focusout(function () {
            let suppliercode = $(this).val().trim();
            //Nếu input nhập vào không trùng mã có trong bảng
            if (!fund.supplierCodes.includes(suppliercode)) {
                $(this).val("");
                $(this).parent().addClass('border-red');
                $(this).closest('.left-item-input-with-icon').next().show();
                $('input[fieldName="PersonName"]').val("");
                $('input[fieldName="Reason"]').val("");
                $('input[fieldName="PersonId"]').val("");
            } else {
                $('.recipeFormDetail_formSupplier .detail-data-item[fieldName="PersonCode"]').each(function () {
                    if (suppliercode === $(this).text().trim()) {
                        let supplierName = $(this).next().text().trim();
                        let supplierId = $(this).parent().data("PersonId");
                        $('.formDetail-info-other input[fieldName="PersonCode"]').val(suppliercode);
                        $('.formDetail-info-other input[fieldName="PersonName"]').val(supplierName);
                        $('.formDetail-info-other input[fieldName="Reason"]').val("Trả nợ cho " + supplierName);
                        $('input[fieldName="PersonId"]').val(supplierId);
                        $('.supplier-code').parent().removeClass('border-red');
                        $('.supplier-code').closest('.left-item-input-with-icon').next().hide();
                    }
                });
            }
        });

        //Bấm ra ngoài vùng input tên đối tượng
        $('.supplier-name').focusout(function () {
            let suppliername = $(this).val().trim();
            //Nếu input nhập vào không trùng mã có trong bảng
            if (!fund.supplierNames.includes(suppliername)) {
                $(this).val("");
                $('input[fieldName="PersonCode"]').val("");
                $('input[fieldName="Reason"]').val("");
                $('input[fieldName="PersonId"]').val("");
            } else {
                $('.recipeFormDetail_formSupplier .detail-data-item[fieldName="PersonName"]').each(function () {
                    if (suppliername === $(this).text().trim()) {
                        let suppliercode = $(this).prev().text().trim();
                        let supplierId = $(this).parent().data("PersonId");
                        $('.formDetail-info-other input[fieldName="PersonCode"]').val(suppliercode);
                        $('.formDetail-info-other input[fieldName="PersonName"]').val(suppliername);
                        $('.formDetail-info-other input[fieldName="Reason"]').val("Trả nợ cho " + suppliername);
                        $('input[fieldName="PersonId"]').val(supplierId);
                    }
                });
            }
        });

        //Bấm ra ngoài vùng input mã nhân viên
        $('.employee-code').focusout(function () {
            let employeecode = $(this).val().trim();
            //Nếu input nhập vào không trùng mã có trong bảng   
            if (!fund.employeeCodes.includes(employeecode)) {
                $(this).val("");
                $(this).parent().addClass('border-red');
                $(this).parent().next().show();
                $('input[fieldName="EmployeeCode"]').val("");
                $('input[fieldName="EmployeeName"]').val("");
                $('input[fieldName="EmployeeId"]').val("");
            } else {
                $('.recipeFormDetail_formStaff .detail-data-item[fieldName="EmployeeCode"]').each(function () {
                    if (employeecode === $(this).text().trim()) {
                        let employeeName = $(this).next().text().trim();
                        let employeeId = $(this).parent().data("EmployeeId");
                        $('.formDetail-info-other input[fieldName="EmployeeCode"]').val(employeecode);
                        $('.formDetail-info-other input[fieldName="EmployeeName"]').val(employeeName);
                        $('input[fieldName="EmployeeId"]').val(employeeId);
                        $('.employee-code').parent().removeClass('border-red');
                        $('.employee-code').closest('.left-item-input-with-icon').next().hide();
                    }
                });
            }
        });
    }

    //Hàm thay đổi số trả và số chưa trả tương ứng khi nhập số tiền muốn trả trong form Chọn hóa đơn trả nợ
    //Tạo bởi: NBDUONG(14/5/2019)
    getPaidMoney() {
        $('.input-paidMoney').focusout(function () {
            var inputPaidMoney = parseInt($(this).val());
            fund.getMoney(inputPaidMoney);
            fund.getTotalMoney();
        });
    }

    //Hàm cập nhật các giá trị tiền chưa trả và số trả trong bảng tương ứng với số trả nhập vào từ input
    //Tạo bởi: NBDUONG(14/5/2019)
    getMoney(money) {
        var hasToPayObject = $('#recipeFormDetail .table-row .hasToPay span');
        var amountPaidObject = $('#recipeFormDetail .table-row .amountPaid span');
        var hasNotPaidObject = $('#recipeFormDetail .table-row .hasNotPaid span');

        //Vòng lặp để thay đổi giá trị tiền chưa trả và số trả tương ứng khi nhập input số trả
        for (var i = 0; i < hasToPayObject.length; i++) {
            if (money > 0) {
                let moneyHasNotPaid = parseInt(hasToPayObject[i].innerText);
                if (money > moneyHasNotPaid) {
                    money = parseInt(money - moneyHasNotPaid);
                    $(amountPaidObject[i]).text(moneyHasNotPaid.formatNumber());
                    $(hasNotPaidObject[i]).text("0");
                } else {
                    $(amountPaidObject[i]).text(money.formatNumber());
                    $(hasNotPaidObject[i]).text(parseInt(moneyHasNotPaid - money));
                    for (var j = 1; j <= hasToPayObject.length - i; j++) {
                        $(amountPaidObject[i + j]).text("0");
                        $(hasNotPaidObject[i + j]).text(parseInt(moneyHasNotPaid));
                    }
                    break;
                }
            }
        }
    }

    //Tính tổng tiền phải trả và chưa trả trong form Chọn hóa đơn trả nợ
    //Tạo bởi: NBDUONG (17/5/2019)
    getTotalMoney() {
        //Có thể sử dụng let hoặc var để khai báo
        // Sử dụng let để khai báo biến chỉ hoạt động trong phạm vi khối của vòng lặp
        let totalMoneyHasToPay = 0;
        let totalMoneyHasNotPaid = 0;

        $('#recipeFormDetail .reciptFormDetail_tableData .table-row').each(function () {
            totalMoneyHasToPay += parseInt($(this).find('span[fieldName="hastoPay"]').text());
            totalMoneyHasNotPaid += parseInt($(this).find('span[fieldName="hasNotPaid"]').text());
        });

        $('.totalMoneyHasToPay span').text(totalMoneyHasToPay.formatNumber());
        if (isNaN($('.totalMoneyHasToPay span').text())) {
            $('.totalMoneyHasToPay span').text("0");
        }
        $('.totalMoneyHasNotPaid span').text(totalMoneyHasNotPaid.formatNumber());
        if (isNaN($('.totalMoneyHasNotPaid span').text())) {
            $('.totalMoneyHasNotPaid span').text("0");
        }
    }

    //Check xem số ở input nhập vào có phải là dạng number hay không
    //Tạo bởi: NBDUONG(24/5/2019)
    ifIsNaN() {
        $('input[fieldName="TotalMoney"]').blur(function () {
            if (isNaN($(this).val())) {
                $(this).val("0");
            }
        });
    }

    //Bấm vào 1 hàng trong dropdown menu có dữ liệu -> input ở trên hiển thị dữ liệu tương ứng với dữ liệu trong dòng đó
    //Tạo bởi: NBDUONG (6/5/2019)
    selectStaff() {
        $('#recipeFormDetail .recipeFormDetail_formSupplier .table-row').mousedown(function () {
            let supplierCode = $(this).find('.detail-data-item_first-column').text().trim();
            let supplierName = $(this).find('.detail-data-item_second-column').text().trim();
            fund.asyncDataValue(supplierCode, supplierName);
            $(this).parents('.recipeFormDetail_formSupplier').hide();
            $(this).parents('.recipeFormDetail_formSupplier').prev().hide();
            $(this).parents('#recipeFormDetail').find('.recipeForm_disablePayDate').hide();
            $(this).parents('#recipeFormDetail').find('.recipeForm_disableGetData').hide();
        });

        $('#formChooseObject .objectComboBox_dropdown-menu .option-row').mousedown(function () {
            let objectName = $(this).text().trim();
            fund.getObjectData(objectName);
            $(this).parent().hide();
        });

        $('body').on('mousedown', '#formDetail .recipeFormDetail_formSupplier .detail-table-data_list-data .table-row', function () {
            let supplierCode = $(this).find('.detail-data-item_first-column').text().trim();
            let supplierName = $(this).find('.detail-data-item_second-column').text().trim();
            fund.getSupplierData(supplierCode, supplierName);
            $(this).parents('.recipeFormDetail_formSupplier').hide();
            $('#formDetail input[fieldName="PersonId"]').val($(this).data("PersonId"));
        });

        $('body').on('mousedown', '#formDetail .recipeFormDetail_formStaff .table-row', function () {
            let supplierCode = $(this).find('.detail-data-item_first-column').text().trim();
            let supplierName = $(this).find('.detail-data-item_second-column').text().trim();
            $('.employee-code').val(supplierCode);
            $('.employee-name').val(supplierName);
            $(this).parents('.recipeFormDetail_formStaff').hide();
            $('#formDetail input[fieldName="EmployeeId"]').val($(this).data("EmployeeId"));
        });

        $('body').on('mousedown', '.document-type-dropdown .table-row', function () {
            let documentType = $(this).find('span').text().trim();
            $('.document-type-input input[fieldName="DocumentTypeName"]').val(documentType);
            $(this).parents('.document-type-dropdown').hide();
            $('#formDetail input[fieldName="DocumentTypeId"]').val($(this).data("DocumentTypeId"));
            alert($(this).data("DocumentTypeId"));
        });

        $('.checkPaidType-dropdown-menu .option-row').mousedown(function () {
            let objectName = $(this).text().trim();
            fund.getPaidTypeData(objectName);
            $(this).parent().hide();
        });
    }
    
    closeFormDialog() {
        fund.alertMessage();
        $('#alertDialog').addClass("close-form-message");
        $('span#ui-id-3').text("Dữ liệu chưa được lưu");
        fund.messageDialog.changeContentAlertMessage("Dữ liệu đã thay đổi. Bạn có muốn lưu không?");
        fund.messageDialog.changeIconAlertMessage("alert-icon-question");
        fund.changeButtonMessageDialog();
    }

    closeFormMessage() {
        $('body').on('click', '#btnCloseFormDialog', function () {
            fund.closeFormDialog();
        });
    }

    //Hàm mặc định lấy ngày hiện tại trong input
    //Tạo bởi: NBDUONG (8/5/2019)
    getCurrentDate() {
        $('#recipeFormDetail .select-date-pay, #formDetail .formDetail-info-paydebt .select-date-pay').change(function () {
            if ($(this).val() === "") {
                $(this).val($(this).attr("data-previous"));
            } else {
                $(this).attr("data-previous", $(this).val());
            }
        });
    }

    getCurrentDocumentCode() {
        $('input[fieldName="DocumentCode"]').change(function () {
            if ($(this).val() === "") {
                $(this).val($(this).attr("data-previous"));
            } else {
                $(this).attr("data-previous", $(this).val());
            }
        });
    }

    //Hàm xử lý khi chọn nút "Thêm phiếu thu"
    //Tạo bởi: NBDUONG(2/5/2019)
    addCollectMoney() {
        fund.checkViewForm = false;
        fund.checkEditForm = false;
        fund.check.openDialog();
        $('#formDetail').addClass("add-collect-money");
        $('span#ui-id-1').text("Thêm phiếu thu");
        $('span#ui-id-2').text("Chọn hóa đơn thu nợ");
        $('.navigation-bar_item.choose-pay-recipt.flex span').text("Chọn hóa đơn thu nợ");
        $('.formDetail-info.formDetail-info-other').find('.right-item-info.flex').hide();
        $('.formDetail-info.formDetail-info-other').find('.choosePaidType').hide();
        $('#formDetail input').val("");
        let documentCode = "PT" + Math.random().toString().substr(2, 6);
        $('#formDetail input[fieldName="DocumentCode"]').val(documentCode);
        fund.check.setValueTimeDefault();
        fund.enableInput();
    }

    //Hàm xử lý khi chọn nút "Thêm phiếu chi"
    //Tạo bởi: NBDUONG(2/5/2019)
    addPayMoney() {
        fund.checkViewForm = false;
        fund.checkEditForm = false;
        fund.check.openDialog();
        $('#formDetail').addClass("add-pay-money");
        $('span#ui-id-1').text("Thêm phiếu chi");
        $('span#ui-id-2').text("Chọn hóa đơn trả nợ");
        $('.navigation-bar_item.choose-pay-recipt.flex span').text("Chọn hóa đơn trả nợ");
        $('.formDetail-info.formDetail-info-other').find('.right-item-info.flex').show();
        $('.formDetail-info.formDetail-info-other').find('.choosePaidType').show();
        $('#formDetail input').val("");
        let documentCode = "PC" + Math.random().toString().substr(2, 6);
        $('#formDetail input[fieldName="DocumentCode"]').val(documentCode);
        fund.check.setValueTimeDefault();
        fund.enableInput();
    }

    enableInput() {
        $("#formDetail input").prop('disabled', false);
        $("#formDetail input[fieldName='EmployeeName'], #formDetail .formDetail-info.formDetail-info-paydebt input[fieldName='PersonCode']").prop('disabled', true);
        $("#formDetail .formDetail-info.formDetail-info-paydebt input[fieldName='PersonName']").eq(0).prop('disabled', true);
    }

    viewDocument() {
        fund.checkViewForm = true;
        fund.checkEditForm = false;
        fund.check.openDialog();
        $('#formDetail').addClass("view-document");
        $('span#ui-id-1').text("Phiếu thu");
        $(".view-document input").prop('disabled', true);
        fund.loadDataToForm();
    }

    editDocument() {
        fund.checkEditForm = true;
        fund.checkViewForm = false;
        fund.check.openDialog();
        $('#formDetail').addClass("edit-document");
        $('span#ui-id-1').text("Sửa phiếu thu");
        fund.loadDataToForm();
        fund.enableInput();
    }

    duplicateDocument() {
        fund.check.openDialog();
        $('#formDetail').addClass("duplicate-document");
        $('span#ui-id-1').text("Nhân bản phiếu thu");
        fund.loadDataToForm(true);
        fund.enableInput();
    }

    //Hàm xử lý khi chọn nút "Chọn hóa đơn trả nợ" 
    //Tạo bởi: NBDUONG(6/5/2019)
    choosePayDebtRecipt() {
        fund.popup.openDialog();
        fund.popup.setValueTimeDefault();
        fund.getTotalMoney();
    }

    //Hàm xử lý khi bấm icon search (thuộc input chọn đối tượng) trong input của form Khác khi Thêm phiếu chi
    //Tạo bởi: NBDUONG(9/5/2019)
    chooseObjectPay() {
        $(".input-staffCode").removeClass("input-staffCode");
        $(".input-staffName").removeClass("input-staffName");
        $(this).prev().prev().addClass('input-staffCode');
        $(this).parent().next().next().addClass('input-staffName');
        fund.chooseObjectPay.openDialog();
        $('span#ui-id-4').text("Chọn đối tượng");
        fund.chooseObjectPay.setValueTimeDefault();
    }

    //Hàm xử lý khi bấm icon search (thuộc input chọn nhân viên) trong input của form Khác khi Thêm phiếu chi
    //Tạo bởi: NBDUONG(9/5/2019)
    chooseStaffPaydebt() {
        $(".input-staffCode").removeClass("input-staffCode");
        $(".input-staffName").removeClass("input-staffName");
        $(this).prev().prev().addClass('input-staffCode');
        $(this).parent().next().addClass('input-staffName');
        fund.chooseStaff.openDialog();
        $('span#ui-id-5').text("Chọn nhân viên");
        fund.chooseStaff.setValueTimeDefault();
    }

    //Hàm hiện thông báo khi lưu
    alertMessage() {
        fund.messageDialog.openDialog();
        $('span#ui-id-3').text("MShopkeeper");
        $('.alertDialog-icon').removeAttr('alert-icon-warning');
        $('.alertDialog-icon').removeClass('alert-icon-question');
    }

    loadDataToForm(checkDuplicate) {
        let documentId = $('.middle-content_table-data .table-row.choose-background').data("DocumentId");
        $.ajax({
            type: "GET",
            url: "/fund/" + documentId,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response) {
                    $('#formDetail input[fieldName]').each(function () {
                        let fieldName = $(this).attr("fieldName");
                        let dataType = $(this).attr("dataType");
                        if (dataType === "date") {
                            //var value = response[fieldName];
                            var value = new Date(response[fieldName]).toLocaleDateString('en-GB');
                            $(this).val(value);
                        } else {
                            $(this).val(response[fieldName]);
                        }
                    });
                    if (checkDuplicate) {
                        $('#formDetail input[fieldName="DocumentCode"]').val("PT" + Math.random().toString().substr(2, 6));
                    }
                } else {
                    alert("fail");
                }
            }
        });
    }
}

// 1 đối tượng khởi tạo của lớp Fund
//Tạo bởi: NBDUONG (2/5/2019)
var fund = new Fund();