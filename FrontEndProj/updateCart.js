// JavaScript source code

let urltext = ParseURL();

function getEItems() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: urltext,
        success: populateCartTable,
        error: BrianMessedUp
    })
}



function populateCartTable(result) {
    let getCartList = JSON.parse(JSON.stringify(result));
    let table = document.getElementById("indexTable");
    for (let i = 0; i < getCartList.length; i++) {
        let items = getCartList[i];
        let row = table.insertRow();
        let itemnum = row.insertCell(0);
        itemnum.innerHTML = items.name           //item name 
        let custnum = row.insertCell(1);
        custnum.innerHTML = items.petType
        let snum = row.insertCell(2);
        snum.innerHTML = items.price
        let qtynum = row.insertCell(3); //
        //qtynum.innerHTML = items.quantity
       
       


    }

}




function BrianMessedUp(x, y, error) {
    console.log(error);
}