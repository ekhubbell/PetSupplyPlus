function getCustomer() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Items?searchBy=noValue&searchWord=noValue",
        success: printToTable,
        error: wellShit
    });
}
function printToTable(result) {
    var temp = JSON.parse(JSON.stringify(result));
    var customerData = temp.record.customer;
    var table = document.getElementById("testTable");
    for (let i = 0; i < custData.length; i++) {
        var customer = custData[i];
        var row = table.insertRow();

var item = row.insertCell(0);
item.innerHTML = customer.item;

var pettype = row.insertCell(1);
pettype.innerHTML = customer.pettype;

var price = row.insertCell(2);
price.innerHTML = customer.price;

        var cart = row.insertCell(3);
        var f = document.createElement("FORM");
        var n = document.createElement("INPUT");
        n.setAttribute("type", "number");
        f.appendChild(n);
        var s = document.createElement("INPUT");
        s.setAttribute("type", "submit");
        s.innerHTML = "add to cart";
        f.appendChild(s);
        f.setAttribute("action", "addToCart();");
        cart.appendChild(f);



    }
}

function wellShit(x, y, err) {
    document.getElementById("log").innerHTML = ("error" + err);
}
function addToCart() {
    console.log("put add to cart function here");
} 