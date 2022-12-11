
function getOrderStatus() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/Eorder?key=noValue&search=noValue",
        success: populateOStatusDropDown,
        error: dang
    })
}

function populateOStatusDropDown(result) {
    let eorderList = JSON.parse(JSON.stringify(result));
    let table = document.getElementById("myTable");
    let dropDown = document.getElementById("myTable");
    for (let i = 0; i < eorderList.length; i++) {
        let eorder = eorderList[i];
        let row = table.insertRow();
        let ordernum = row.insertCell(0);
        ordernum.innerHTML = eorder.oID
        let custnum = row.insertCell(1);
        custnum.innerHTML = eorder.cID
        let snum = row.insertCell(2);
        snum.innerHTML = eorder.total
        let test = row.insertCell(3);
        test.innerHTML = eorder.status
        //let opt = document.createElement("OPTION");
        //opt.innerHTML = eorder.status
        //opt.setAttribute("value", eorderList[i].oID);
        //let txt = document.createTextNode(eorderList[i].status);
        //opt.appendChild(txt);
       // dropDown.appendChild(opt);
        

    }
    $(document).ready(function () {
        //copies all contents of myDropDownListDiv into anotherDiv    $("#anotherDiv").html($("#myDropDownListDiv").html());
    });
   
        

   }
   
    


function dang(x, y, error) {
    console.log(error);
}


