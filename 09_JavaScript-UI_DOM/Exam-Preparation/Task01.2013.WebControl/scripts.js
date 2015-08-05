function createCalendar(selector, events) {

    var MONTH = 'June 2014';
    var DAYS = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var root = document.querySelector(selector);
    root.style.padding = '20px';
    var event = [];
    events.forEach(function (element) {
        var index = (element.date*1)-1;
        event[index] = element;
    });

    var docFrag = document.createDocumentFragment();

    var dayEl = document.createElement('div');
    dayEl.style.width = '150px';
    dayEl.style.height = '150px';
    dayEl.style.border = '1px solid black';
    dayEl.style.cssFloat = 'left';    

    var infoEl = document.createElement('p');
    infoEl.style.backgroundColor = 'lightgray';
    infoEl.style.borderBottom = '1px solid black';
    infoEl.style.margin = 'auto';
    infoEl.style.textAlign = 'center';
    infoEl.style.fontWeight = 'bold';

    var eventInfo = document.createElement('em');

    for (var i = 0; i < 30; i+=1) {
        var cloneDayEl = dayEl.cloneNode(true);
        var cloneInfoEl = infoEl.cloneNode(true);

        if (i % 7 === 0) {
            addClearFix(cloneDayEl);
        }

        var dayIndex = i % 7;
        cloneInfoEl.innerHTML = DAYS[dayIndex] + ' ' + (i + 1) + ' ' + MONTH;
        cloneDayEl.appendChild(cloneInfoEl);

        if (event[i] !== undefined) {
            var cloneEventInfo = eventInfo.cloneNode(true);
            cloneEventInfo.innerHTML = event[i].title + ' ' + event[i].hour + ' h';
            cloneDayEl.appendChild(cloneEventInfo);
        }       
        
        docFrag.appendChild(cloneDayEl);
    }

    root.appendChild(docFrag);

    root.addEventListener('mouseover', function (ev) {

        var targetEl = ev.target;
        if (targetEl.tagName === 'P') {
            targetEl.style.backgroundColor = 'darkgray';
        }
    });

    root.addEventListener('mouseout', function (ev) {
        var targetEl = ev.target;
        if (targetEl.tagName === 'P') {
            targetEl.style.backgroundColor = 'lightgray';
        }
    });

    root.addEventListener('click', function (ev) {
        var targetEl = ev.target;
        if (targetEl.tagName === 'DIV') {
            clearBackground();
            var kid = targetEl.getElementsByTagName('p')[0];
            kid.style.backgroundColor = 'white';
        }
    });

    function addClearFix(element) {
        element.style.clear = 'both';
    }

    function clearBackground() {
        var childrenTarget = root.getElementsByTagName('p'),
            len = childrenTarget.length;
        for (var i = 0; i < len; i+=1) {
            childrenTarget[i].style.backgroundColor = 'lightgray';
        }
    }
};