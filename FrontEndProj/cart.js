

//Get orderContent from the DB and put ito the html file

function getURL() {
    console.log(1);
    let data = document.getElementById("orderID").elements; //this is going to be the data passed from the login/userID for orders. 

    let url = "https://localhost:7268/api/https://localhost:7268/api/OrderContent/" + data[0].value;
    console.log(url);
    return url;
   }

function getOrderContent() {

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/https://localhost:7268/api/OrderContent",
        success: showOrderContent,
        error: dang
    })
   }



function showORderContent(result) {





}



