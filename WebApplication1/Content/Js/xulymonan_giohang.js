//function changeMenu(evt, pageName){
//  //set het tabcontent ve ẩn
//  var i, tabcontent, tablinks;
//  tabcontent = document.getElementsByClassName("tabcontent");
//  for(i=0; i<tabcontent.length; i++)
//  {
//      tabcontent[i].style.display = "none";
//  }

//  tablinks = document.getElementsByClassName("tablinks");
//  for (i = 0; i < tablinks.length; i++) {
//    tablinks[i].className = tablinks[i].className.replace(" active", "");
//  }
//  document.getElementById(pageName).style.display = "block";
//  evt.currentTarget.className += " active";
    
//}



//fixed navbar
window.addEventListener('scroll', function(){
  var st = $(window).scrollTop();
  var navbar = document.getElementsByClassName('ftco_navbar')[0];
  if(st>200)
  {
    navbar.classList.add('haha');
  }
  else{
    navbar.classList.remove('haha');
  }
});



function openBill (){
  if(document.getElementsByClassName("detail")[0].style.display == "none")
  {
    document.getElementsByClassName("detail")[0].style.display = "block";
  }
  else{
    document.getElementsByClassName("detail")[0].style.display = "none";
  }
}


function closeBill()
{
  if(document.getElementsByClassName("detail")[0].style.display == "none")
  {
    document.getElementsByClassName("detail")[0].style.display = "block";
  }
  else{
    document.getElementsByClassName("detail")[0].style.display = "none";
  }


}




//phần xử lý đặt hàng
//if (document.readyState == 'loading') {
//  document.addEventListener('DOMContentLoaded', ready)
//} else {
//  ready()
//}

//function ready() {
//  var removeCartItemButtons = document.getElementsByClassName('btn-danger')
//  for (var i = 0; i < removeCartItemButtons.length; i++) {
//      var button = removeCartItemButtons[i]
//      button.addEventListener('click', removeCartItem)
//  }

//  var quantityInputs = document.getElementsByClassName('cart-quantity-input')
//  for (var i = 0; i < quantityInputs.length; i++) {
//      var input = quantityInputs[i]
//      input.addEventListener('change', quantityChanged)
//  }

//  var addToCartButtons = document.getElementsByClassName('order-button')
//  for (var i = 0; i < addToCartButtons.length; i++) {
//      var button = addToCartButtons[i]
//      button.addEventListener('click', addToCartClicked)
//  }

//  document.getElementsByClassName('btn-purchase')[0].addEventListener('click', purchaseClicked);
//}


//function updateCartTotal()
//{
//  var cart_item_container= document.getElementsByClassName('cart-items')[0];
//  var cart_rows = cart_item_container.getElementsByClassName("cart-row");
//  var total=0;
//  for(var i=0; i<cart_rows.length; i++)
//  {
//    var cart_row = cart_rows[i];
//    var priceElement = cart_row.getElementsByClassName("cart-price")[0];
//    var quantityElement = cart_row.getElementsByClassName("cart-quantity-input")[0];
//    var price = parseFloat(priceElement.innerText.replace('đ',''))
//    var quantity = quantityElement.value
//    total = total+price*quantity;
  
//  }
//  //hien thi len 
//  document.getElementsByClassName("cart-total-price")[0].innerText = total + "đ"
//  document.getElementsByClassName("money")[0].innerText = total + "đ"
//}



//function removeCartItem(event) {
//  var buttonClicked = event.target
//  buttonClicked.parentElement.parentElement.remove()
//  updateCartTotal()
//}

//function quantityChanged(event) {
//  var input = event.target

//  if (isNaN(input.value) || input.value <= 0) {
//      input.value = 1
//  }
//  updateCartTotal()
//}

//$(document).ready(function () {
//    $('.')
//})


//function addToCartClicked(event)
//{
//  var button = event.target;
//  var shopitem = button.parentElement.parentElement.parentElement
//  var image = shopitem.getElementsByClassName("menu-img")[0].src;
//  var title = shopitem.getElementsByClassName("food-name")[0].innerText;
//  var price = shopitem.getElementsByClassName("price")[0].innerText;

//  addItemToCart(image, title, price);
//}

//function addItemToCart(image, title, price)
//{
//  var cart_row = document.createElement('div');
//  cart_row.classList.add('cart-row')
//  var cartRowContents = `
//  <div class="cart-item cart-column">
//      <img class="cart-item-image" src="${image}" width="100" height="100">
//      <span class="cart-item-title">${title}</span>
//  </div>
//  <span class="cart-price cart-column">${price}</span>

//  <div class="cart-quantity cart-column">
//      <input class="cart-quantity-input" type="number" value="1">
//      <button class="btn-danger" type="button">HUỶ</button>
//  </div>`

//  cart_row.innerHTML = cartRowContents
//  var cartItem = document.getElementsByClassName('cart-items')[0];
//  cartItem.append(cart_row);

//  updateCartTotal();

  ////them event cho nut bam moi
  //cart_row.getElementsByClassName('btn-danger')[0].addEventListener('click', removeCartItem);
  //cart_row.getElementsByClassName('cart-quantity-input')[0].addEventListener('change', quantityChanged);

  
//}

function getAllMonAn(id) {
    var model = $('#dataModel');
    $.ajax({
        url: '/Menu/LayMonAn/' + id,
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    });
}

function addToCart(mamonan, soluong, trangthai, thoigian) {
    var model = $('#dataCart');
    $.ajax({
        data: { "mamonan": mamonan, "soluong": soluong, "trangthai": trangthai, "thoigian": thoigian},
        url: '/Cart/AddItem/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    })
}


function Xacnhandathang() {
    $.ajax({
        url: '/Cart/AddDatMon/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            if (data.status === "success") {
                alert("Đặt món thành công");
            }
            else if (data.status === "failed") {
                alert(data.message);
            }
        }
    }
    )
}

function getMonTrongGioHang(trangthai) {
    var model = $('#monantheotrangthai');
    $.ajax({
        data: { "trangthai": trangthai },
        url: '/Cart/HienThiMonTrongGioHang/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    })
}


function getMonDaDat(maban) {
    var model = $('#monantheotrangthai');
    $.ajax({
        data: { "maban": maban },
        url: '/Cart/LayMonDaDat/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    })
}

function HuyMon(mamonan) {
    var model = $('#monantheotrangthai');
    $.ajax({
        data: { "mamonan": mamonan },
        url: '/Cart/HuyMonAn/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    })
}


function ThayDoiSoLuong(mamonan) {
    var input = (event.target);
    var soluong = input.value;
    var model = $('#monantheotrangthai');
    $.ajax({
        data: { "soluong": soluong, "mamonan": mamonan },
        url: '/Cart/ThayDoiSoLuong/',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    })
}
