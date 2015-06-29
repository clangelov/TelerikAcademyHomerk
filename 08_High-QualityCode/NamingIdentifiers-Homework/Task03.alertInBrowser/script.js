function alertInBrowser() {
    'use strict';
    var currentWindow = window,
        browser = currentWindow.navigator.appCodeName,
        isBrowserMozila = (browser === 'Mozilla');

    if (isBrowserMozila) {
        alert("Yes");
    } else {
        alert("No");
    }
}