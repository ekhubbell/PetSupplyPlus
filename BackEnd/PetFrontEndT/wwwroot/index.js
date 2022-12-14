

 function getURL()
 {
     console.log(1);
     let data = document.getElementById("login-form").elements;
     
     let url = "https://localhost:7268/api/C_usernames/" + data[0].value+ "/log?password=" + data[1].value;
     console.log(url);
     return url;
}



function getLoginInfo() {
    console.log(0);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: getURL(),
        success: validUser,    /// add the function below
        error: dang
    })
    console.log(3);
}


function validUser(result) {
    console.log(4);

    let link = JSON.parse(JSON.stringify(result)); //
    console.log(link.link);
    let nextPage = link.link;
    if (link.userID != "") {
        nextPage += "?id=" + encodeURIComponent(link.userID);
    }
    location.href = nextPage;

}




function dang(x, y, error) {
    console.log(error);
}


