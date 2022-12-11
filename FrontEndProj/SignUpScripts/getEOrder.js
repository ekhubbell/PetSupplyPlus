
function getOrderStatus() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Eorder?key=noValue&search=noValue",
        success: populateOStatusDropDown,
        error: dang
    })
}
let values = ["in progress", "ordered", "shipped"];
function populateOStatusDropDown(result) {
   
    let eorderList = JSON.parse(JSON.stringify(result));
    let table = document.getElementById("myTable");
    let dropDown = document.getElementById("myTable");
    for (let i = 0; i < eorderList.length; i++) {
        let eorder = eorderList[i];
        let row = table.insertRow();
        let ordernum = row.insertCell(0);
        ordernum.innerHTML = eorder.oID;
        let custnum = row.insertCell(1);
        custnum.innerHTML = eorder.cID;
        let snum = row.insertCell(2);
        snum.innerHTML = eorder.total;
        let test = row.insertCell(3);
        //test.innerHTML = eorder.status
        let f = document.createElement("FORM");
        let s = document.createElement("SELECT");
        let opt = document.createElement("OPTION");
        let text = document.createTextNode(eorder.status);
        opt.setAttribute("selected", "selected");
        opt.setAttribute("value", eorder.status);
        opt.appendChild(text);
        s.appendChild(opt);
        for (let i = 0; i < values.length; i++) {
            if (eorder.status != values[i]) {
                let opt = document.createElement("OPTION");
                let text = document.createTextNode(values[i]);
                opt.setAttribute("selected", "selected");
                opt.setAttribute("value", values[i]);
                opt.appendChild(text);
                s.appendChild(opt);
            }
        }
        f.appendChild(s);
        test.appendChild(f);



        
        //let opt = document.createElement("OPTION");
        //opt.innerHTML = eorder.status
        //opt.setAttribute("value", eorderList[i].oID);
        //let txt = document.createTextNode(eorderList[i].status);
        //opt.appendChild(txt);
       // dropDown.appendChild(opt);
        

    }
    //$(document).ready(function () {
        //copies all contents of myDropDownListDiv into anotherDiv    $("#anotherDiv").html($("#myDropDownListDiv").html());
    //});
   
        

   }
   
    


function dang(x, y, error) {
    console.log(error);
}


//new function below

function getURL() {
    console.log(1);
    let data = document.getElementById("myTable").elements;

    let url = "ttps://localhost:7268/api/Orders/" + data[0].value ;
    console.log(url);
    return url;
}

function getsChange() {
    $.ajax({
        type: "PUT",
        dataType: "json",
        url: getURL(),
        success: populateOStatusDropDown,
        error: darn
    })
}



function darn(x, y, error) {
    console.log(error);
}