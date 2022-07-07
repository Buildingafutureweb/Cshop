const cars = '{"data":["Saab", "BMW", "Benz", "Jay"]}';

const tr = function (html) {
    return "<tr>" + html + "</tr>"
}

const hasProductId = function (cartJson, productId) {
    let isExeist = false;
    $.each(cartJson, function (index, item) {

        if (item.productId == productId && isExeist == false) {
      //      alert(productId + " : " + item.productId);
            cartJson[index].quantity += 1;
            localStorage.cart = JSON.stringify(cartJson);
            isExeist = true;
        }
    });
    return isExeist;
}

const addCart = function (productId, productName, price, quantity) {
    const myCart = $.parseJSON(localStorage.cart)
    if (!hasProductId(myCart, productId)) {
        let item = { "productId": productId, "productName": productName, "price": price, "quantity": quantity };
        if (myCart != null) {
            myCart.push(item);
            localStorage.cart = JSON.stringify(myCart);
        }
    }
}


const updateCart = function () {
    if (localStorage.cart != null) {
        const myCart = $.parseJSON(localStorage.cart);
        $("#cart tbody").html("");

        $.each(myCart, function (index, item) {
            $("#cart tbody").append(tr('<td>' + item.productName + "</td><td class='text-center'>" + item.quantity + '</td><td>$'+ item.quantity * item.price + '</td>'));
        });
        $("#dropdownMenuButton").html("Cart(" + myCart.length + ")");
    }

}

// bind Click for AddToCart
$("#addtocart").click(function () {

    addCart(this.dataset.productId, this.dataset.productName, this.dataset.price, this.dataset.quantity);
    updateCart();

    const cartToast = $("#cartToast");
    $("#cartToast div.toast-body").html(this.dataset.productName + " has been added to the cart");
    const toast = new bootstrap.Toast(cartToast);
    toast.show();
    //toast.show() = function ()     {  setTimeout(function () { toast.show(); }, 50000);   }
});


// when windows loaded
$(document).ready(function () {
    //  localStorage.cart = cars;
    if (localStorage.cart == null)
        localStorage.cart = "[]"

    updateCart();

});
