/*****************
 Notifications
 *****************/
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

/*****************
 Onboarding Subscribe
 *****************/

const subscribeUrl = "/SubscribeToCommunity/Join"
const unSubscribeUrl = "/SubscribeToCommunity/Leave"

async function renderSubscription(id, el){
    await genericFetch(`${subscribeUrl}/${id}`).then(data => {
        if(data === "success") {
            el.innerText = "dejar"
            el.classList = "btn btn-clear onboarding-subscribed"
            el.onclick = () => { renderUnsubscription(id, el) };
        }
    });
}

async function renderUnsubscription(id, el){
    await genericFetch(`${unSubscribeUrl}/${id}`).then(data => {
        if(data === "success") {
            el.innerText = "seguir";
            el.classList = "btn btn-clear subscribe-button"
            el.onclick = () => { renderSubscription(id, el) };
        }
    });
}