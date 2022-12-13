// JavaScript source code
let id;

function ParseURL() {
    let url = document.location.href;
    let params = url.split('?')[1].split('&'); //customer.html?id=1
    let data = {};
    let tmp;
    for (let i = 0; i < params.length; i++) {
        tmp = params[i].split('=');
        data[tmp[0]] = tmp[1];
    }
    id = data.id;
}

function NextPage(url) {
    if (url.indexOf('?') == -1) {
        url += "?";
    }
    url += "id=" + encodeURIComponent(id);

    document.location.href = url;
}