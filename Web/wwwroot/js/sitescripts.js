const notificationsUrl = "/notifications/test"
const messagesUrl = "/notifications/test"

async function genericFetch(url){
    const fetchGenericThings = await fetch(url, { credentials: "include"});
    return await fetchGenericThings.json();
}

async function renderNotificationsCount(){
    const notificationsCount = await genericFetch(notificationsUrl);
    let notificationsLink = document.getElementById("notification-pill");
    
    let spanElement = document.createElement("span");
    spanElement.classList = "badge bg-danger";
    spanElement.innerText = notificationsCount.value;
    
    notificationsLink.appendChild(spanElement);
}

async function renderMessagesCount(){
    const notificationsCount = await genericFetch(messagesUrl);
    let notificationsLink = document.getElementById("messages-pill");

    let spanElement = document.createElement("span");
    spanElement.classList = "badge bg-danger";
    spanElement.innerText = notificationsCount.value;

    notificationsLink.appendChild(spanElement);
}