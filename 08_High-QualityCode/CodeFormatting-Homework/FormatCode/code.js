/* Task:
 Format correctly the given JavaScript code given in the filecode.js.
 
 Unresolved JSLint issues:
 - eval is evil
 - unused functions
 - using dot notations instead of []
 */

(function () {
    'use strict';
    /*jslint browser:true*/
    /*global mouseMove, Event, popTip*/

    var browser = navigator.appName,
        addScroll = false,
        posX = 0,
        posY = 0;

    document.onmousemove = mouseMove;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    if (browser === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(evn) {
        if (browser === "Netscape") {
            posX = evn.pageX - 5;
            posY = evn.pageY;
        } else {
            posX = event.x - 5;
            posY = event.y;
        }

        if (browser === "Netscape") {
            if (document.layers['ToolTip'].visibility === 'show') {
                popTip();
            }
        } else {
            if (document.all['ToolTip'].style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function popTip() {

        var theLayer;

        if (browser === "Netscape") {
            theLayer = eval('document.layers[\'ToolTip\']');

            if ((posX + 120) > window.innerWidth) {
                posX = window.innerWidth - 150;
            }

            theLayer.left = posX + 10;
            theLayer.top = posY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = eval('document.all[\'ToolTip\']');

            if (theLayer) {
                posX = event.x - 5;
                posY = event.y;

                if (addScroll) {
                    posX = posX + document.body.scrollLeft;
                    posY = posY + document.body.scrollTop;
                }
                if ((posX + 120) > document.body.clientWidth) {
                    posX = posX - 150;
                }

                theLayer.style.pixelLeft = posX + 10;
                theLayer.style.pixelTop = posY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function hideTip() {

        var args = hideTip.arguments; // Unused variable !!!

        if (browser === "Netscape") {
            document.layers['ToolTip'].visibility = 'hide';
        } else {
            document.all['ToolTip'].style.visibility = 'hidden';
        }
    }

    function showFirstMenu() {

        var theLayer;

        if (browser === "Netscape") {
            theLayer = eval('document.layers[\'menu1\']');
            theLayer.visibility = 'show';
        } else {
            theLayer = eval('document.all[\'menu1\']');
            theLayer.style.visibility = 'visible';
        }
    }

    function hideFirstMenu() {
        if (browser === "Netscape") {
            document.layers['menu1'].visibility = 'hide';
        } else {
            document.all['menu1'].style.visibility = 'hidden';
        }
    }

    function showSecondMenu() {

        var theLayer;

        if (browser === "Netscape") {
            theLayer = eval('document.layers[\'menu2\']');
            theLayer.visibility = 'show';
        } else {
            theLayer = eval('document.all[\'menu2\']');
            theLayer.style.visibility = 'visible';
        }
    }

    function hideSecondMenu() {
        if (browser === "Netscape") {
            document.layers['menu2'].visibility = 'hide';
        } else {
            document.all['menu2'].style.visibility = 'hidden';
        }
    }

}());