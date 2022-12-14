
function getEItems() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Items?searchBy=noValue&searchWord=noValue",
        success: populateOStatusDropDown,
        error: dang
    })
}

let values = ["in progress", "ordered", "shipped"];
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
        let qtynum = row.insertCell(3); //
        //qtynum.innerHTML = items.quantity
        //let f = document.createElement("FORM");
        //let s = document.createElement("SELECT");
        let opt = document.createElement("INPUT");
        let text = document.createTextNode(items.quantity);
        opt.setAttribute("type", "number");
        opt.setAttribute("value", items.quantity);
        opt.appendChild(text);
        qtynum.appendChild(opt);
        //s.appendChild(opt);
      /*  for (let i = 0; i < values.length; i++) {
            if (items.quantity != values[i]) {
                let opt = document.createElement("INPUT");
                let text = document.createTextNode(values[i]);
                opt.setAttribute("type", "number");
                opt.setAttribute("value", values[i]);
                opt.appendChild(text);
                s.appendChild(opt);
            }
        }
        f.appendChild(s);
        qtynum.appendChild(f);*/
        let buttonc = row.insertCell(4);
        let btn = document.createElement("INPUT");
        btn.setAttribute("type", "button");
        btn.setAttribute("value", "UPDATE");
        buttonc.appendChild(btn)


    }
   
    }


function dang(x, y, error) {
    console.log(error);
}


