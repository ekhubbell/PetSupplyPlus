

//Get orderContent from the DB and put ito the html file
let orderID;


function getOrderContent(custID) {

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Orders/Customer/cart/" + custID,
        success: showOrderContent,
        error: function (x, y, error) {
            dang("getOrderContent", error);
        }
    })
}

function getOrderCost(ordID) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/CostAndTax/TC/" + ordID,
        success: showTotal,
        error: function (x, y, error) {
            dang("getOrderContent", error);
        }
    })
}

function updateQuantity(orderID, itemID) {
    let val = document.getElementById(itemID).value;
    if (val < 1) {
        removeItem(orderID, itemID);
    }
    else {
        $.ajax({
            url: "https://localhost:7268/api/OrderContent/Put/" + orderID + "/" + itemID + "/" + val,
            type: 'PUT',
            success: function (data) { NextPage('cart.html') },
            error: function (x, y, error) {
                dang("updatQuantity", error);
            }
        })
    }
}

function removeItem(orderID, itemID) {
    $.ajax({
        url: "https://localhost:7268/api/OrderContent/Delete/" + orderID + "/" + itemID,
        type: 'DELETE',
        success: function (data) { NextPage('cart.html') },
        error: function (x, y, error) {
            dang("updatQuantity", error);
        }
    })
}


function showOrderContent(result) {
    let cart = JSON.parse(JSON.stringify(result));
    orderID = cart[0].orderID;
    let bask = document.getElementById("basket");
    fillBasket(bask, cart);
    getOrderCost(orderID);

}

function showTotal(result) {
    CostAndTax = JSON.parse(JSON.stringify(result));

    document.getElementById("basket-subtotal").innerHTML = CostAndTax.subTotal;
    document.getElementById("basket-tax").innerHTML = CostAndTax.tax;
    document.getElementById("basket-total").innerHTML = CostAndTax.total;
}

function fillBasket(basket, cart) {

    for (let i = 0; i < cart.length; i++) {
        let item = cart[i];
        let basketProduct = document.createElement("DIV");
        basketProduct.setAttribute("class", "basket-product");

        let itemP = document.createElement("DIV");
        itemP.setAttribute("class", "item");

        let prodDet = document.createElement("DIV");
        prodDet.setAttribute("class", "product-details");

        let header = document.createElement("H1");
        let strongHead = document.createElement("STRONG");
        let spanHead = document.createElement("SPAN");
        spanHead.setAttribute("class", "item-quantity");
        spanHead.innerHTML = item.quantity;
        strongHead.innerHTML = spanHead
        header.innerHTML = strongHead + " " + item.name;

        let desc = document.createElement("P");
        let strongDesc = document.createElement("STRONG");
        strongDesc.innerHTML = item.desc;
        desc.appendChild(strongDesc);

        prodDet.appendChild(header);
        prodDet.appendChild(desc);

        itemP.appendChild(prodDet);
        basketProduct.appendChild(itemP);

        let price = document.createElement("DIV");
        price.setAttribute("class", "price");
        price.innerHTML = item.price;

        basketProduct.appendChild(price);

        let quant = document.createElement("DIV");
        let changeQuant = document.createElement("INPUT");
        changeQuant.setAttribute("type", "number");
        changeQuant.setAttribute("id", item.itemID);
        changeQuant.setAttribute("onchange", "updateQuantity(" + item.orderID + "," + item.itemID +");");
        changeQuant.setAttribute("value", item.quantity);
        changeQuant.setAttribute("min", "0");
        changeQuant.setAttribute("class", "quantity-field");

        quant.appendChild(changeQuant);
        basketProduct.appendChild(quant);

        let subtotal = document.createElement("DIV");
        subtotal.setAttribute("class", "subtotal");
        subtotal.innerHTML = item.totalPrice;

        basketProduct.appendChild(subtotal);

        basket.appendChild(basketProduct);
    }

}



function dang(location, error) {
    document.getElementById("log").innerHTML = location + ": " + error;
}