function createAccount() {
    console.log("2");
    let data = $(document.forms["loginForm"]).serializeArray();
    var dataToPost =
    {
        "custId": "-10",
        "firstName": data[0].value, //first name
        "lastName": data[1].value, //last name
        "address": data[2].value, //addresss
        "city": data[3].value, //city
        "stateId": "", //state
        "zipcode": data[4].value, //zipcode
        "email": data[5].value, //email
        "phone": data[6].value, //phone#
        "password": data[7].value

    };

    $.ajax({
        type: "POST", //this is like the functions we made, each one is either a "get","put","post",or "delete"
        dataType: "json", //this tells ajax that we want the data it returns in the form of JSON
        contentType: 'application/json',
        crossDomain: true,
        url: "https://localhost:7268/api/Customer", //this is where you put the request URL(currently, it is a bin I made using https://jsonbin.io/) 
        data: JSON.stringify(dataToPost),
        success: (data, textStatus, xhr) => { console.log(data); },//this is the function I want to call when the data is received
        error: function (xhr, textStatus, errorThrown, r, t, y) {
            console.log(':(');
        }
    });
}

function getAccountInfo() {
    let temp;



    temp = {

        "cust_ID": -10,
        "firstName": data[0].value, //first name
        "lastName": data[1].value, //last name
        "address": data[2].value, //addresss
        "city": data[3].value, //city
        "state_ID": data[4].value, //state
        "zipcode": data[5].value, //zipcode
        "email": data[6].value, //email
        "phone": data[7].value, //phone#
        "password": data[8].value
    }
    document.getElementById("log").innerHTML = temp;
    return temp;
}