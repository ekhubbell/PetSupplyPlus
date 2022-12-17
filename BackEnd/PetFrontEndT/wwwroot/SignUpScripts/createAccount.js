let username;
let password;

function createAccount() {
    console.log("2");
    let data = $(document.forms["loginForm"]).serializeArray();
    username = data[6].value;
    password = data[8].value;
    var dataToPost =
    {
        "custId": "-10",
        "firstName": data[0].value, //first name
        "lastName": data[1].value, //last name
        "address": data[2].value, //addresss
        "city": data[3].value, //city
        "stateId": data[4].value, //state
        "zipcode": data[5].value, //zipcode
        "email": data[6].value, //email
        "phone": data[7].value, //phone#
        "password": data[8].value
    
    };

    $.ajax({
        type: "POST", //this is like the functions we made, each one is either a "get","put","post",or "delete"
        dataType: "json", //this tells ajax that we want the data it returns in the form of JSON
        contentType: 'application/json; charset=utf-8',
        crossDomain: true,
        url: "https://localhost:7268/api/Customer", //this is where you put the request URL(currently, it is a bin I made using https://jsonbin.io/) 
        data: JSON.stringify(dataToPost),
        success: (data, textStatus, xhr) => { console.log(data); },//this is the function I want to call when the data is received
        error: function (xhr, textStatus, errorThrown, r, t, y) {
            getLoginInfo();
        }
    })
}



function getLoginInfo() {
    let url = "https://localhost:7268/api/C_usernames/" + username + "/log?password=" + password;
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: validUser,    /// add the function below
        error: dang
    })
}


function validUser(result) {
    let link = JSON.parse(JSON.stringify(result));
    let nextPage = link.link;
    if (link.userID != "") {
        nextPage += "?id=" + encodeURIComponent(link.userID);
    }
    location.href = nextPage;

}