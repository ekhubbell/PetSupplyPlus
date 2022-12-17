

let orderInfo;
let orderStatusOptions = ["ordered", "in progress", "Shipped"];

function getOrderId(customerID) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Orders/Customer/" + customerID,
        success: function (result) {
            orderInfo = JSON.parse(JSON.stringify(result));
            populateOrderDropDown(orderInfo);
        },
        error: function (x, y, error) {
            dang("getOrderID", error);
        }
    })
}

function selectOrder() {
    let orderID = document.getElementById("ordID").value;
    order = orderInfo.find(o => o.orderID == orderID);
    orderStatus(order);
    getOrder(orderID);
}

function populateOrderDropDown(orders) {
    let dropDown = document.getElementById("ordID");

    let firstPaid = -1;
    for (let i = 0; i < orders.length; i++) {
        console.log(orders[i].paid);
        if (orders[i].paid == "paid") {
            if (firstPaid == -1) {
                firstPaid = i;
            }
            let opt = document.createElement("OPTION");
            opt.setAttribute("value", orders[i].orderID);
            let txt = document.createTextNode(orders[i].orderID);
            opt.appendChild(txt);
            dropDown.appendChild(opt);
        }
    }
    if (firstPaid != -1) {

        orderStatus(orders[firstPaid]);
        getOrder(orders[firstPaid].orderID);
    }
}



function orderStatus(order) {
    let statusMarkers = [document.getElementById("confirmed"), document.getElementById("progress"), document.getElementById("shipped")];
    let index = orderStatusOptions.indexOf(order.status);
    for (let i = 0; i <= index; i++) {
        statusMarkers[i].setAttribute("class", "step active");
    }
    for (let i = index + 1; i < statusMarkers.length; i++) {
        statusMarkers[i].setAttribute("class", "step");
    }
}

function getOrder(id) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/OrderContent/" + id,
        success: displayOrderContent,
        error: function (x, y, error) {
            dang("getOrder", error);
        }

    })
}

function displayOrderContent(results) {
    contents = JSON.parse(JSON.stringify(results));
    let list = document.getElementById("list");
    list.innerHTML = "";
    console.log("ordercontents: " + contents.length);
    for (let i = 0; i < contents.length; i++) {
        getItem(contents[i], list);
    }
}

function createHTMLContent(content, item, list) {
    let node = document.createElement("LI");
    node.setAttribute("class", "col-md-4");

    let fig = document.createElement("FIGURE");
    fig.setAttribute("class", "itemside mb-3");

    let figCap = document.createElement("FIGCAPTION");
    figCap.setAttribute("class", "info align-self-center");

    let title = document.createElement("P");
    title.setAttribute("class", "title");
    title.innerHTML = item.name + " <br> Quantity: " + content.quantity + " <br>Price per Unit: " + item.price;

    let total = document.createElement("SPAN");
    total.setAttribute("class", "text-muted");
    total.innerHTML = "$" + content.price;

    figCap.appendChild(title);
    figCap.appendChild(total);
    fig.appendChild(figCap);
    node.appendChild(fig);
    list.appendChild(node);
}

function getItem(content, list) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Items/" + content.itemID,
        success: function (result) {
            item = JSON.parse(JSON.stringify(result));
            createHTMLContent(content, item, list);
        },
        error: function (x, y, error) {
            dang("getItem", error);
        }
    });
}

function dang(location, error) {
    document.getElementById("log").innerHTML = location+": "+ error;
}
