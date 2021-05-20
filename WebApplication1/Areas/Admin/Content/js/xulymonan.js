function getAll(id) {
    var model = $('#dataModel');
    $.ajax({
        url: '/MonAn/GetFoodData/' + id,
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    });
}

function getDetailBill(id) {
    var model = $('#dataBill');
    $.ajax({
        url: '/HoaDon/GetBill/' + id,
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    });
}




function getQuantity(id) {
    var model = $();
    $.ajax

}


