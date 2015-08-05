/* globals module */
function solve() {

  return function (selector, items) {
    
      var container = document.querySelector(selector);

      var zoomImage = document.createElement('div');
      zoomImage.classList.add('image-preview');
      zoomImage.style.width = '65%';
      zoomImage.style.height = '500px';
      zoomImage.style.cssFloat = 'left';
      zoomImage.style.textAlign = 'center';

      var zoomHeader = document.createElement('h2');
      zoomHeader.innerHTML = items[0].title;

      var imagePrv = document.createElement('img');
      imagePrv.style.width = '60%';
      imagePrv.style.borderRadius = '10px';
      imagePrv.setAttribute('src', items[0].url);
      imagePrv.setAttribute('alt', items[0].title);      

      var rightImages = document.createElement('div');      
      rightImages.style.width = '30%';
      rightImages.style.height = '500px';
      rightImages.style.overflow = 'auto';
      rightImages.style.textAlign = 'center';

      var inputField = document.createElement('input');
      inputField.setAttribute('type', 'text');      
      var inputHeader = document.createElement('h4');
      inputHeader.innerHTML = 'Filter';
      rightImages.appendChild(inputHeader);
      rightImages.appendChild(inputField);

      var docFrag = document.createDocumentFragment();

      var listItemsUl = document.createElement('ul');
      listItemsUl.style.listStyleType = 'none';

      docFrag.appendChild(listItemsUl);

      var liEl = document.createElement('li');
      liEl.classList.add('image-container');
      liEl.style.listStyleType = 'none';
      var titleEl = document.createElement('h4');
      var imgEl = document.createElement('img');
      imgEl.style.width = '250px';
      imgEl.style.borderRadius = '5px';      

      items.forEach(function (item) {

          var cloneLi = liEl.cloneNode(true);
          var titleToAdd = titleEl.cloneNode(true);
          titleToAdd.innerHTML = item.title;
          var imgElToAdd = imgEl.cloneNode(true);
          imgElToAdd.setAttribute('src', item.url);
          imgElToAdd.setAttribute('alt', item.title);          
          cloneLi.appendChild(titleToAdd);
          cloneLi.appendChild(imgElToAdd);
          docFrag.appendChild(cloneLi);
      });

      rightImages.appendChild(docFrag);

      rightImages.addEventListener('click', function (ev) {

          var currentEl = ev.target;
          if (currentEl.tagName === 'IMG') {
              
              zoomHeader.innerHTML = currentEl.getAttribute('alt');
              imagePrv.setAttribute('src', currentEl.getAttribute('src'));
              imagePrv.setAttribute('alt', currentEl.getAttribute('alt'));
          }

      });

      rightImages.addEventListener('mouseover', function (ev) {

          var currentEl = ev.target;
          if (currentEl.tagName === 'IMG') {
              currentEl.parentElement.style.backgroundColor = 'gray';
          }
      });

      rightImages.addEventListener('mouseout', function (ev) {
          
          var currentEl = ev.target;
          if (currentEl.tagName === 'IMG') {
              currentEl.parentElement.style.backgroundColor = '';
          }
      });

      inputField.addEventListener('keyup', function () {

          var text = this.value;
          var regexFilter = new RegExp(text, 'i');
          var liChildren = rightImages.getElementsByTagName('li');
          for (var i = 0, len = liChildren.length; i < len; i += 1) {
              var currentLi = liChildren[i];
              var headText = currentLi.firstElementChild.innerHTML;
              
              if (regexFilter.test(headText)) {
                  currentLi.style.display = '';
              } else {
                  currentLi.style.display = 'none';
              }
          }
      });


      zoomImage.appendChild(zoomHeader);
      zoomImage.appendChild(imagePrv);      
      container.appendChild(zoomImage);
      container.appendChild(rightImages);
      
  };
}

// module.exports = solve;