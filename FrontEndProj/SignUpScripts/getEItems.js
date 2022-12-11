
function getEItems() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Items?searchBy=noValue&searchWord=noValue",
        success: populateOStatusDropDown,
        error: dang
    })
}

function populateOStatusDropDown(result) {
    let eitemsList = JSON.parse(JSON.stringify(result));
    let table = document.getElementById("myTable");
    for (let i = 0; i < eitemsList.length; i++) {
        let items = eitemsList[i];
        let row = table.insertRow();
        let itemnum = row.insertCell(0);
        itemnum.innerHTML = items.name
        let custnum = row.insertCell(1);
        custnum.innerHTML = items.petType
        let snum = row.insertCell(2);
        snum.innerHTML = items.price
        let qtynum = row.insertCell(3);
        qtynum.innerHTML = items.quantity

        //let opt = document.createElement("OPTION");
       // opt.setAttribute("value", stateList[i].id);
       // let txt = document.createTextNode(stateList[i].abbr);
      //  opt.appendChild(txt);
      //  dropDown.appendChild(opt);
        // wont let me do insertCell(3); says it is out of range????

    }
   
    }


function dang(x, y, error) {
    console.log(error);
}


