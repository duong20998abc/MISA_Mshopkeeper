
$(document).ready(function () {
    //popup Thêm KH đóng khi ấn nút "X" 
    //Created by NTDUONG (13/05/2019)
    $("#addNew-close-button").click(function () {
        $("#popup-addNew").hide();
    });

    //popup Thêm KH hiện lên khi ấn nút "Thêm mới" 
    //Created by NTDUONG (13/05/2019)
    $("#customer-add").click(function () {
        $("#popup-addNew").show();
    });

    //popup Sửa thông tin KH đóng khi ấn nút "X"
    //Created by NTDUONG (13/05/2019)
    $("#edit-close-button").click(function () {
        $("#popup-edit").hide();
    });

    //popup Sửa thông tin KH hiện lên khi ấn nút "Sửa" 
    //Created by NTDUONG (13/05/2019)
    $("#customer-edit").click(function () {
        $("#popup-edit").show();
    });

    //đóng (mở) popup cảnh báo lưu dữ liệu 
    //Created by NTDUONG (13/05/2019)
    $("#cancel-addNew").click(function () {
        $("#popup-warning-save").show();
    });
    $("#back-to-addNew-popup1").click(function () {
        $("#popup-warning-save").hide();
    });
    $("#back-to-addNew-popup2").click(function () {
        $("#popup-warning-save").hide();
    });
    $("#back-to-main-screen1").click(function () {
        $("#popup-warning-save").hide();
        $("#popup-addNew").hide();
    });
    $("#back-to-main-screen2").click(function () {
        $("#popup-warning-save").hide();
        $("#popup-addNew").hide();
    });

    //đóng (mở) popup cảnh báo xóa dữ liệu 
    //Created by NTDUONG (13/05/2019)
    $("#customer-delete").click(function () {
        $("#popup-warning-delete").show();
    });
    $("#cancel-delete1").click(function () {
        $("#popup-warning-delete").hide();
    });
    $("#cancel-delete2").click(function () {
        $("#popup-warning-delete").hide();
    });
    $("#cancel-delete3").click(function () {
        $("#popup-warning-delete").hide();
    });

    //đóng (mở) popup thêm mới nhóm KH 
    //Created by NTDUONG (16/05/2019)
    $("#more").click(function () {
        $("#popup-add-group").show();
    });
    $("#back-to-addNew-popup3").click(function () {
        $("#popup-add-group").hide();
    });
    $("#back-to-addNew-popup4").click(function () {
        $("#popup-add-group").hide();
    });
    $("#back-to-addNew-popup5").click(function () {
        $("#popup-add-group").hide();
    });
    $("#back-to-addNew-popup6").click(function () {
        $("#popup-add-group").hide();
    });

    //Mở (đóng) dropdown menu người dùng khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#user-expand').on('click touch', function () {
        $('.user-option-box').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#user-expand')) {
            $('.user-option-box').hide();
        }
    });

    //Mở (đóng) dropdown menu chọn chi nhánh khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#branch-selection-expand').on('click touch', function () {
        $('.branch-selection').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#branch-selection-expand')) {
            $('.branch-selection').hide();
        }
    });

    //Mở (đóng) dropdown menu chọn giới tính khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#gender-expand').on('click touch', function () {
        $('.gender-selection').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#gender-expand')) {
            $('.gender-selection').hide();
        }
    });

    //Mở (đóng) dropdown menu chọn nhóm KH khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#group-expand').on('click touch', function () {
        $('.group-selection').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#group-expand')) {
            $('.group-selection').hide();
        }
    });

    //Mở (đóng) dropdown menu chọn trạng thái khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#status-expand').on('click touch', function () {
        $('.status-selection').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#status-expand')) {
            $('.status-selection').hide();
        }
    });

    //Mở (đóng) dropdown menu chọn số lượng hiển thị khi ấn nút "expand"
    //Created by NTDUONG (16/05/2019)
    $('#footer-expand').on('click touch', function () {
        $('.amount-selection').show();
    });
    $(document).on('click touch', function (event) {
        if (!$(event.target).parents().addBack().is('#footer-expand')) {
            $('.amount-selection').hide();
        }
    });

    //Thiết lập datepicker cho các ô input nhập ngày tháng
    //Created by NTDUONG (18/05/2019)
    $(function () {
        $('.datepicker').datepicker();
    });
    $(".header-column-icon-calender").click(function () {
        $(".datepicker").datepicker("show");
    });
    $(function () {
        $('#datepicker2').datepicker();
    });
    $("#icon-calender2").click(function () {
        $("#datepicker2").datepicker("show");
    });
    $(function () {
        $('#datepicker3').datepicker();
    });
    $("#icon-calender3").click(function () {
        $("#datepicker3").datepicker("show");
    });
    $(".datepicker, #datepicker2, #datepicker3").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        yearRange: '1950:2019'
    });

    //Chức năng chọn các option trong combo box rồi hiển thị lên input
    //Created by NTDUONG (18/05/2019)
    $(function () {
        $(".dropdown-menu-row-text").click(function () {
            var text = $(this).text();
            $("input#sex").val(text);
        });
    });

    customerJS.loadData();
    customerJS.initEvents();
});

class CustomerJS {
    constructor() { }
    
    initEvents() {
        $(document).on('click', '.checkbox', this.onClickCheckbox);
    }

    loadData() {
        var url = '/customers';
        $.ajax({
            url: url,
            type: 'GET',
            data: '',
            success: function (result) {
                console.log(result);
                $('.table-data').html(' ');
                var fields = $('.table-header .table-header-column');
                $.each(result, function (index, item) {
                    var row = $('<div class="table-data-row"></div>');
                    row.append('<div class="row-index"><div class="checkbox"></div></div>');
                    $.each(fields, function (idx, elem) {
                        var fieldData = $(elem).attr('data-field');
                        var html = `<div class="data-column${idx + 1}">` + `<span class="table-text">${item[fieldData]}</span></div>`;
                        row.append(html);
                    })
                    $('.table-data').append(row);
                })
                
            },
            error: function (result) {

            }
        })
    }

    onClickCheckbox() {
        var currentCb = $(this);
        if (currentCb.hasClass('check')) {
             currentCb.removeClass('check').addClass('uncheck');
        }
        else {
             currentCb.removeClass('uncheck').addClass('check');
        }
    }
}

var customerJS = new CustomerJS();