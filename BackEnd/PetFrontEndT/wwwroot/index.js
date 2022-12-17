

 function getURL()
 {
     let data = document.getElementById("login-form").elements;
     
     let url = "https://localhost:7268/api/C_usernames/" + data[0].value+ "/log?password=" + data[1].value;
     console.log(url);
     return url;
}



function getLoginInfo() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: getURL(),
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




function dang(x, y, error) {
    console.log(error);
}


