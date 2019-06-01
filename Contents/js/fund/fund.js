//File js với các hàm được sử dụng trong file fund.html
//Tạo bởi: NBDUONG (30/4/2019)

//Hàm chạy khi mọi dữ liệu trong cây DOM đã được load hết
//Tạo bởi: NBDUONG (30/4/2019)
$(document).ready(function () {
    //Menu sổ xuống khi click nút
    //Tạo bởi: NBDUONG(3/5/2019)
    $('.header-middle-item_main-content_user').click(function () {
        $('.user-name_dropdown-menu').toggle();
    });

    //Menu sổ xuống khi click nút
    //Tạo bởi: NBDUONG(3/5/2019)
    $('.header-middle-item_main-content_comboBox').click(function () {
        $('.comboBox_dropdown-menu').toggle();
    });

    //Thêm Datepicker cho các input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.select-from-date, .select-to-date, .input-pickdate, .select-date-pay, #recipeFormDetail .select-date-pay').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        yearRange: '1900:2099'
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.select-date-from .icon.icon-calendar').click(function () {
        $('.select-from-date').datepicker("show");
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.select-date-to .icon.icon-calendar-to').click(function () {
        $('.select-to-date').datepicker("show");
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.column-input_input-date-icon').click(function () {
        $('.input-pickdate').datepicker("show");
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('#formDetail .formDetail-info-paydebt .input-calendar-icon').click(function () {
        $('#formDetail .formDetail-info-paydebt .select-date-pay').datepicker("show");
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('#formDetail .formDetail-info-other .input-calendar-icon').click(function () {
        $('#formDetail .formDetail-info-other .select-date-pay').datepicker("show");
    });

    //Bấm icon hình cuốn lịch để hiện ra datetimepicker tương ứng với input
    //Tạo bởi: NBDUONG (3/5/2019)
    $('#recipeFormDetail .input-calendar-icon').click(function () {
        $(this).prev().datepicker("show");
    });

    //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_second-column .input-option').click(function () {
        $('.header-table_second-column .select-option-menu').toggle();
    });

    //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_third-column .input-option').click(function () {
        $('.header-table_third-column .select-option-menu').toggle();
    });

     //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_fourth-column .column-input_input-arrow-icon').click(function () {
        $('.header-table_fourth-column .select-option-menu').toggle();
    });

     //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_fifth-column .input-option').click(function () {
        $('.header-table_fifth-column .select-option-menu').toggle();
    });

     //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_sixth-column .input-option').click(function () {
        $('.header-table_sixth-column .select-option-menu').toggle();
    });

     //Bấm vào nút -> Mở dropdown menu
    //Tạo bởi: NBDUONG (3/5/2019)
    $('.header-table_seventh-column .input-option').click(function () {
        $('.header-table_seventh-column .select-option-menu').toggle();
    });

    //Bấm vào Quỹ tiền ở menu bên trái -> mở ra div chứa các lựa chọn để truy cập các trang con trong phân hệ Quỹ tiền
    //Tạo bởi: NBDUONG(3/5/2019)
    $('#getFund').click(function () {
        $('.fund-menu').toggle();
    });

    //Bấm vào nút Add hiện dropdown menu với lựa chọn Thêm phiếu thu, Thêm phiếu chi
    //Tạo bởi: NBDUONG(3/5/2019)
    $('#btnAdd').click(function () {
        $('.choose-option-add').toggle();
    });

    //Bấm vào icon mũi tên xuống ở mục thu chi trong form hiện dropdown chọn loại chứng từ
    //Tạo bởi: NBDUONG(25/5/2019)
    $('.document-type-arrow').click(function () {
        $('.document-type-dropdown').show();
    });

    //Lựa chọn show dữ liệu tương ứng khi chọn tab Chi tiết hoặc Chứng từ trong form Thêm phiếu chi (phần Trả nợ)
    //Tạo bởi: NBDUONG (4/5/2019)
    $('.formDetail_intro-document').click(function () {
        $('.formDetail_table-document-data').show();
        $('.formDetail_table-detail-data').hide();
        $('.formDetail_intro-document').css('border-bottom', '2px solid #026b97').css('color', '#026b97');
        $('.formDetail_intro-detail').css('border-bottom', 'none').css('color', '#757575');
    });

    //Lựa chọn show dữ liệu tương ứng khi chọn tab Chi tiết hoặc Chứng từ trong form Thêm phiếu chi (phần Trả nợ)
    //Tạo bởi: NBDUONG (4/5/2019)
    $('.formDetail_intro-detail').click(function () {
        $('.formDetail_table-detail-data').show();
        $('.formDetail_table-document-data').hide();
        $('.formDetail_intro-detail').css('border-bottom', '2px solid #026b97').css('color', '#026b97');
        $('.formDetail_intro-document').css('border-bottom', 'none').css('color', '#757575');
    });

    //Bấm vào input radio để lựa chọn Khác hoặc Trả nợ trong form Thêm phiếu chi
    //Tạo bởi: NBDUONG(6/5/2019)
    $(".formDetail_navigation-bar #radio1").change(function () {
        if ($(this).is(":checked")) {
            //formContext.setDefaultClickRadio1();
            $('.formDetail-info-other').show();
            $('.formDetail-info-paydebt').hide();
            $('.navigation-bar_item.choose-pay-recipt').hide();
        }
    });

    //Bấm vào input radio để lựa chọn Khác hoặc Trả nợ trong form Thêm phiếu chi
    //Tạo bởi: NBDUONG(6/5/2019)
    $(".formDetail_navigation-bar #radio2").change(function () {
        if ($(this).is(":checked")) {
            //formContext.setDefaultClickRadio2();
            $('.formDetail-info-paydebt').show();
            $('.formDetail-info-other').hide();
            $('.navigation-bar_item.choose-pay-recipt').show();
        }
    });

    //Bấm vào input radio để lựa chọn Khác hoặc Trả nợ trong form Thêm phiếu chi
    //Tạo bởi: NBDUONG(6/5/2019)
    $('.reciptFormDetail_tableData .table-row').click(function () {
        $(this).find('input').prop('checked', true);
        $(".reciptFormDetail_tableData .table-row.choose-background").removeClass("choose-background");
        $(this).addClass('choose-background');
    });

    //Mở ra các dropdown menu khi bấm nút
    //Tạo bởi: NBDUONG(6/5/2019)
    $('#recipeFormDetail .formDetail_general-info_left-item_list-input .input-dropdown-icon').click(function () {
        $(this).next().next().toggle();
    });

    //Mở ra các dropdown menu khi bấm nút
    //Tạo bởi: NBDUONG(6/5/2019)
    $('#formDetail .formDetail-info.formDetail-info-other .left-item-input-with-icon .input-dropdown-icon').click(function () {
        $(this).next().next().toggle();
    });

    //Mở ra các dropdown menu khi bấm nút
    //Tạo bởi: NBDUONG(6/5/2019)
    $('#formDetail .formDetail-info.formDetail-info-paydebt .left-item-input-with-icon .input-dropdown-icon').click(function () {
        $(this).next().next().toggle();
    });

     //Mở ra các dropdown menu khi bấm nút
    //Tạo bởi: NBDUONG(6/5/2019)
    $('#formDetail .formDetail-info.formDetail-info-other .show-checkPaidType').click(function () {
        $(this).next().next().toggle();
    });


    //Bấm vào checkbox
    //Tạo bởi: NBDUONG (6/5/2019)    
    $('.MISABody-part_middle-content .middle-content_header-table .choose-all').click(function () {
        if ($(this).find('img').attr('src') === '') {
            $(this).find('img').attr('src', "/Contents/images/check.png"); 
            $('.choose-row img').attr('src', "/Contents/images/check.png");
            $(this).addClass('non-background');
            $('.choose-row').addClass('non-background');
            $('.table-data_list-data .table-row.flex').addClass('choose-background');
        } else {
            $(this).find('img').attr('src', '');
            $('.choose-row img').attr('src', '');
            $(this).removeClass('non-background');
            $('.choose-row').removeClass('non-background');
            $('.table-data_list-data .table-row.flex').removeClass('choose-background');
        }
    });

    //Bấm vào checkbox
    //Tạo bởi: NBDUONG (6/5/2019)
    $('body').on('click', '.choose-row', function () {
        if ($(this).find('img').attr('src') === '') {
            $(this).find('img').attr('src', '/Contents/images/check.png');
            $(this).addClass('non-background');
            $(this).parents('.table-row.flex').addClass('choose-background');
        } else {
            $(this).find('img').attr('src', '');
            $(this).removeClass('non-background');
            $(this).parents('.table-row.flex').removeClass('choose-background');
        }
    });

    //Bấm vào checkbox
    //Tạo bởi: NBDUONG (6/5/2019)
    $('body').on('click', '.choose-all-receiptForm', function () {
        if ($(this).find('img').attr('src') === '') {
            $(this).find('img').attr('src', '/Contents/images/check.png');
            $('.choose-row-receiptForm img').attr('src', '/Contents/images/check.png');
            $(this).addClass('non-background');
            $('.choose-row-receiptForm').addClass('non-background');
            $('#recipeFormDetail .reciptFormDetail_tableData .table-row.flex').addClass('choose-background');
        } else {
            $(this).find('img').attr('src', '');
            $('.choose-row-receiptForm img').attr('src', '');
            $(this).removeClass('non-background');
            $('.choose-row-receiptForm').removeClass('non-background');
            $('#recipeFormDetail .reciptFormDetail_tableData .table-row.flex').removeClass('choose-background');
        }
    });

    //Bấm vào checkbox trong form chọn hóa đơn
    $('.choose-row-receiptForm').click(function () {
        if ($(this).find('img').attr('src') === '') {
            $(this).find('img').attr('src', '/Contents/images/check.png');
            $(this).addClass('non-background');
            $(this).closest('.table-row').addClass('choose-background');
        } else {
            $(this).find('img').attr('src', '');
            $(this).removeClass('non-background');
            $(this).closest('.table-row').removeClass('choose-background');
        }
    });

    //Bấm vào checkbox trong form chọn hóa đơn
    $('.choose-selectPaidType').click(function () {
        if ($(this).hasClass('background-checked')) {
            $(this).removeClass('background-checked');
            $(this).addClass('background-uncheck');
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('.input-dropdown-icon_disable').show();
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('input').attr('disabled', 'disabled');
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('input').val('Chi phí');
        } else {
            $(this).addClass('background-checked');
            $(this).removeClass('background-uncheck');
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('.input-dropdown-icon_disable').hide();
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('input').removeAttr('disabled');
            $(this).parents('.formDetail_general-info_right-item_list-info').next().children().eq(2).find('input').val('Chi phí');
        }
    });

    //Bấm vào nút mũi tên trong form Chọn đối tượng -> Menu sổ xuống
    $('.nav_objectComboBox .icon-arrow-down').click(function () {
        $(this).next().toggle();
    });

    //Lấy ngày mặc định là ngày hiện tại trong các input về ngày
    //Tạo bởi: NBDUONG (8/5/2019)
    //fund.getCurrentDate();

    //Bấm vào dòng được chọn
    //Tạo bởi: NBDUONG (8/5/2019)
    $('.footer-content_detail-table-data .detail-table-data_list-data .table-row.flex').on('click', function () {
        $('.footer-content_detail-table-data .detail-table-data_list-data .table-row.flex').removeClass('choose-background');
        $(this).addClass('choose-background');
    });

    //Bấm vào dòng được chọn có chứa input thì hiển thị placeholder của input
    //Tạo bởi: NBDUONG (8/5/2019)
    $('.footer-content_detail-table-data .detail-table-data_list-data .table-row.flex input').on('focus', function () {
        $(this).attr('placeholder', 'Nhập dữ liệu');
    });

    //Bấm ra ngoài thì input dạng number sẽ hiển thị val theo dạng số
    //Tạo bởi: NBDUONG(16/5/2019)
    //$('.footer-content_detail-table-data input[dataType="number"]').focusout(function () {
    //    $(this).val(parseInt($(this).val()).formatNumber());
    //}); 
});

//Hàm xử lý khi bấm ra ngoài dropdown menu sẽ tự động ẩn các dropdown menu đó 
//Tạo bởi: NBDUONG (3/5/2019)
$(document).mouseup(function (e) {
    var container = $('.user-name_dropdown-menu, .comboBox_dropdown-menu, .fund-menu, .recipeFormDetail_formSupplier, #formChooseObject .objectComboBox_dropdown-menu, .recipeFormDetail_formStaff, .select-option-menu.left-float, .choose-option-add, .document-type-dropdown');
    if (!container.is(e.target) && container.has(e.target).length === 0) {
        container.hide();
    }
});

//Bấm ra ngoài input thì mất placeholder
//Tạo bởi: NBDUONG (8/5/2019)
$(document).mouseup(function (e) {
    var container = $('.footer-content_detail-table-data .detail-table-data_list-data .table-row.flex input');
    if (!container.is(e.target) && container.has(e.target).length === 0) {
        container.attr('placeholder','');
    }
});

// 1 đối tượng khởi tạo của lớp Dialog
//Tạo bởi: NBDUONG (2/5/2019)
var dialog = new Dialog();


