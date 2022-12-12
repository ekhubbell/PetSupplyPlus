function createAccount() {
    console.log("2");
    let data = $(document.forms["loginForm"]).serializeArray();
    
    $.ajax({
        type: "POST",//this is like the functions we made, each one is either a "get","put","post",or "delete"
        dataType: "json",//this tells ajax that we want the data it returns in the form of JSON
        processData: "false",
        url: "https://localhost:7268/api/Customer/post",//this is where you put the request URL(currently, it is a bin I made using https://jsonbin.io/) 
        data: {

            "Cust_ID": "\"" +-10 +"\"",

            "firstName": data[0].value.toString(), //first name

            "lastName": data[1].value.toString(), //last name

            "address": data[2].value.toString(), //addresss

            "city": data[3].value.toString(), //city

            "state_ID": data[4].value.toString(), //state

            "zipcode": "\"" + data[5].value.toString(), //zipcode

            "email": "\"" + data[6].value.toString(), //email

            "phone": "\"" + data[7].value.toString(), //phone#

            "password": data[8].value.toString()

        },
        contentType: "application/json;charset=utf-8",
        success: (data, textStatus, xhr) => { console.log(data); },//this is the function I want to call when the data is received
        error: function (xhr, textStatus, errorThrown) {
            console.log(':(');
        }
    });
}

function getAccountInfo() {
    let temp;

    

    temp = {
        "": -10,
        "": data[0].value, //first name
        "": data[1].value, //last name
        "": data[2].value, //addresss
        "": data[3].value, //city
        "": data[4].value, //state
        "": data[5].value, //zipcode
        "": data[6].value, //email
        "": data[7].value, //phone#
        "": data[8].value
    }
    document.getElementById("log").innerHTML = temp;
    return temp;


}
