

function getStates() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "https://localhost:7268/api/State",
        success: populateStateDropDown,
        error: dang
    })
}

function populateStateDropDown(result) {
    let stateList = JSON.parse(JSON.stringify(result));
    let dropDown = document.getElementById("states");
    for (let i = 0; i < stateList.length; i++) {
        let opt = document.createElement("OPTION");
        opt.setAttribute("value", stateList[i].id);
        let txt = document.createTextNode(stateList[i].abbr);
        opt.appendChild(txt);
        dropDown.appendChild(opt);
    }
}

function dang(x, y, error) {
    console.log(error);
}


