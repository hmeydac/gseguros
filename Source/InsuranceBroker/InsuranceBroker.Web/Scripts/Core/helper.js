function callAction(action, controller, param) {
    if (!param) {
        param = '';
    }

    window.location = "/Administration/" + controller + "/" + action + "/" + param;
}

function submit() {
    $('form').submit();
}
